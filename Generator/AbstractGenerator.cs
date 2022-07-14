using MyBatisCodeGenerator.Transformer;
using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static MyBatisCodeGenerator.Utils.TemplateUtils;

namespace MyBatisCodeGenerator.Generator
{
    public abstract class AbstractGenerator
    {
        /// <summary>
        /// 作者
        /// </summary>
        public String Author { get; set; }

        /// <summary>
        /// 代码保存根文件夹
        /// </summary>
        public String BaseSourcePath { get; set; }

        /// <summary>
        /// 脚本保存根文件夹
        /// </summary>
        public String BaseScriptPath { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public String FileExtension { get; set; }

        /// <summary>
        /// 是否创建不存在的文件夹，默认：是
        /// </summary>
        public Boolean IsCreatePath { get; set; } = true;

        /// <summary>
        /// 是否覆盖已存在的文件，默认：是
        /// </summary>
        public Boolean IsOverwriteExists { get; set; } = true;

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
        public Dictionary<String,String> DefRefs { get; set; }

        /// <summary>
        /// 是否VO
        /// </summary>
        public Boolean IsVO { get; set; }

        /// <summary>
        /// 默认转换器
        /// </summary>
        public SortedList<int, AbstractTransformer> DefaultTransformers { get; set; }

        /// <summary>
        /// 按模板及设置生成代码
        /// </summary>
        /// <param name="templateText">模板内容</param>
        /// <returns></returns>
        public String Run(string templateText)
        {
            if (!IsGeneratable())
            {
                return String.Empty;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(templateText);


            foreach (KeyValuePair<int, AbstractTransformer> transformer in this.DefaultTransformers)
            {
                transformer.Value.DesignData = DesignData;
                transformer.Value.OriginalContent = sb;
                transformer.Value.DefRefs = DefRefs;
                transformer.Value.Transform();
            }

            TemplateUtils.ApplyMiscDefines(Author, sb);

            String contentText = sb.ToString();

            if (string.IsNullOrEmpty(contentText.Trim()))
            {
                return String.Empty;
            }

            string savedFilename = GetSavedFileName(FileExtension);
            CommonUtils.WriteTextFile(savedFilename, GetSavedPath(GetRootPath()), contentText, IsCreatePath, IsOverwriteExists, false, true);
            return savedFilename;
        }

        /// <summary>
        /// 取实际保存路径
        /// </summary>
        /// <param name="basePath">根路径</param>
        /// <returns></returns>
        public String GetSavedPath(string basePath)
        {
            return TemplateUtils.GetSavedPath(basePath, GetClassSpace());
        }

        /// <summary>
        /// 取保存文件名
        /// </summary>
        /// <param name="table"></param>
        /// <param name="defaultExt"></param>
        /// <returns></returns>
        public abstract String GetSavedFileName(string defaultExt);

        /// <summary>
        /// 取代码类命名空间
        /// </summary>
        /// <returns></returns>
        public abstract String GetClassSpace();

        /// <summary>
        /// 取保存根路径
        /// </summary>
        /// <returns></returns>
        public abstract String GetRootPath();

        public string GetItemDefine(string itemTag)
        {
            return TemplateUtils.GetItemDefine(DesignData, itemTag, DefRefs);
        }

        /// <summary>
        /// 是否具备生成条件
        /// </summary>
        /// <returns></returns>
        public abstract Boolean IsGeneratable();
    }
}
