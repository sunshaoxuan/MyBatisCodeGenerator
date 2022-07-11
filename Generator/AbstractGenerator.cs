using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        public String author { get; set; }

        /// <summary>
        /// 代码保存根文件夹
        /// </summary>
        public String baseSourcePath { get; set; }

        /// <summary>
        /// 脚本保存根文件夹
        /// </summary>
        public String baseScriptPath { get; set; }

        /// <summary>
        /// 文件扩展名
        /// </summary>
        public String fileExtension { get; set; }

        /// <summary>
        /// 是否创建不存在的文件夹，默认：是
        /// </summary>
        public Boolean isCreatePath { get; set; } = true;

        /// <summary>
        /// 是否覆盖已存在的文件，默认：是
        /// </summary>
        public Boolean isOverwriteExists { get; set; } = true;

        /// <summary>
        /// 设置数据表
        /// </summary>
        public DataTable dataTable { get; set; }

        /// <summary>
        /// 是否多语生成器
        /// </summary>
        public Boolean isMultiLangGenerator{ get; set; }

        /// <summary>
        /// 是否元数据生成器
        /// </summary>
        public Boolean generateByMeta { get; set; }

        /// <summary>
        /// 自定义参数
        /// </summary>
        public Dictionary<String,String> defRefs { get; set; }

        /// <summary>
        /// 是否VO
        /// </summary>
        public Boolean isVO { get; set; }

        /// <summary>
        /// 按模板及设置生成代码
        /// </summary>
        /// <param name="templateText">模板内容</param>
        /// <returns></returns>
        public String run(string templateText)
        {
            String contentText = TemplateUtils.templateApply(dataTable, templateText, author, generateByMeta, isMultiLangGenerator, defRefs, isVO);

            if (string.IsNullOrEmpty(contentText.Trim()))
            {
                return String.Empty;
            }

            string savedFilename = getSavedFileName(fileExtension);
            CommonUtils.writeTextFile(savedFilename, getSavedPath(getRootPath()), contentText, isCreatePath, isOverwriteExists, false, true);
            return savedFilename;
        }

        /// <summary>
        /// 取实际保存路径
        /// </summary>
        /// <param name="basePath">根路径</param>
        /// <returns></returns>
        public String getSavedPath(string basePath)
        {
            return TemplateUtils.getSavedPath(basePath, getClassSpace());
        }

        /// <summary>
        /// 取保存文件名
        /// </summary>
        /// <param name="table"></param>
        /// <param name="defaultExt"></param>
        /// <returns></returns>
        public abstract String getSavedFileName(string defaultExt);

        /// <summary>
        /// 取代码类命名空间
        /// </summary>
        /// <returns></returns>
        public abstract String getClassSpace();

        /// <summary>
        /// 取保存根路径
        /// </summary>
        /// <returns></returns>
        public abstract String getRootPath();

        internal string getItemDefine(string itemTag)
        {
            return TemplateUtils.getItemDefine(dataTable, itemTag, defRefs);
        }
    }
}
