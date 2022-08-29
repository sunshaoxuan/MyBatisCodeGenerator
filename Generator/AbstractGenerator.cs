using MyBatisCodeGenerator.Transformer;
using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static MyBatisCodeGenerator.Utils.TemplateUtils;

namespace MyBatisCodeGenerator.Generator
{
    public abstract class AbstractGenerator
    {
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 代码保存根文件夹
        /// </summary>
        public string BaseSourcePath { get; set; }

        /// <summary>
        /// 脚本保存根文件夹
        /// </summary>
        public string BaseScriptPath { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string FileExtension { get; set; }

        /// <summary>
        /// 是否创建不存在的文件夹，默认：是
        /// </summary>
        public Boolean IsCreatePath { get; set; } = true;

        /// <summary>
        /// 是否覆盖已存在的文件，默认：是
        /// </summary>
        public Boolean IsOverwriteExists { get; set; } = true;

        /// <summary>
        /// 完整定义数据表
        /// </summary>
        public Dictionary<string, DataTable> ExcelData { get; set; }

        /// <summary>
        /// 设置数据表
        /// </summary>
        public DataTable DesignData { get; set; }

        /// <summary>
        /// 是否多语生成器
        /// </summary>
        public Boolean IsMultiLangGenerator { get; set; }

        /// <summary>
        /// 是否元数据生成器
        /// </summary>
        public Boolean GenerateByMeta { get; set; }

        /// <summary>
        /// 生成器类型
        /// </summary>
        public abstract TemplateTypeEnum GeneratorType { get; }

        /// <summary>
        /// 自定义参数
        /// </summary>
        public Dictionary<string,string> DefRefs { get; set; }

        /// <summary>
        /// 是否VO
        /// </summary>
        public Boolean IsVO { get; set; }

        /// <summary>
        /// 是否多文件生成器
        /// </summary>
        public Boolean IsMultiFile { get; set; } = false;

        /// <summary>
        /// 默认转换器
        /// </summary>
        public SortedList<int, AbstractTransformer> DefaultTransformers { get; set; }

        /// <summary>
        /// 多语资源
        /// </summary>
        public Dictionary<string, Dictionary<string, string[]>> MultiLangRefInfo { get; set; }

        /// <summary>
        /// 多文件生成器动态标记数据
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> MultiFileTagData { get; set; }

        /// <summary>
        /// 按模板及设置生成代码
        /// </summary>
        /// <param name="templateText">模板内容</param>
        /// <returns></returns>
        public string Run(string templateText)
        {
            if (!IsGeneratable())
            {
                return string.Empty;
            }

            string filename = string.Empty;
            if (IsMultiFile)
            {
                foreach (KeyValuePair<string, Dictionary<string, string>> tagData in this.MultiFileTagData)
                {
                    filename += (tagData.Key + ":[" + RunGenerator(ReplaceMultiFileTags(templateText, tagData.Value), tagData.Value) + "] \r\n");
                }
            }
            else
            {
                filename = RunGenerator(templateText, null);
            }
            return filename;
        }

        private string ReplaceMultiFileTags(string templateText, Dictionary<string, string> tagData)
        {
            foreach (KeyValuePair<string, string> tagdata in tagData)
            {
                templateText = templateText.Replace(tagdata.Key, tagdata.Value);
            }
            return templateText;
        }

        private string RunGenerator(string templateText, Dictionary<string, string> tagData)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(templateText);


            foreach (KeyValuePair<int, AbstractTransformer> transformer in this.DefaultTransformers)
            {
                transformer.Value.ExcelData = ExcelData;
                transformer.Value.DesignData = DesignData;
                transformer.Value.OriginalContent = sb;
                transformer.Value.DefRefs = DefRefs;
                transformer.Value.Transform();

                if (MultiLangRefInfo == null)
                {
                    MultiLangRefInfo = new Dictionary<string, Dictionary<string, string[]>>();
                }
                TemplateUtils.RegisterMultiLangRefInfo(MultiLangRefInfo, transformer.Value.MultiLangRefInfo);
            }

            TemplateUtils.ApplyMiscDefines(Author, sb);

            string contentText = sb.ToString();

            if (string.IsNullOrEmpty(contentText.Trim()))
            {
                return string.Empty;
            }

            string savedFilename = GetSavedFileName(FileExtension, tagData);
            CommonUtils.WriteTextFile(savedFilename, GetSavedPath(GetRootPath()), contentText, IsCreatePath, IsOverwriteExists, false, true);
            return savedFilename;
        }

        /// <summary>
        /// 取实际保存路径
        /// </summary>
        /// <param name="basePath">根路径</param>
        /// <returns></returns>
        public string GetSavedPath(string basePath)
        {
            return TemplateUtils.GetSavedPath(basePath, GetClassSpace());
        }

        /// <summary>
        /// 取保存文件名
        /// </summary>
        /// <param name="table"></param>
        /// <param name="defaultExt"></param>
        /// <param name="tagData"></param>
        /// <returns></returns>
        public abstract string GetSavedFileName(string defaultExt, Dictionary<string, string> tagData);

        /// <summary>
        /// 取代码类命名空间
        /// </summary>
        /// <returns></returns>
        public abstract string GetClassSpace();

        /// <summary>
        /// 取保存根路径
        /// </summary>
        /// <returns></returns>
        public abstract string GetRootPath();

        public string GetItemDefine(string itemTag)
        {
            return TemplateUtils.GetItemDefine(DesignData, itemTag, DefRefs);
        }

        /// <summary>
        /// 是否具备生成条件
        /// </summary>
        /// <returns></returns>
        public abstract bool IsGeneratable();

        public string CreateTablePrefix { get; set; }
        public string InsertDataPrefix { get; set; }
    }
}
