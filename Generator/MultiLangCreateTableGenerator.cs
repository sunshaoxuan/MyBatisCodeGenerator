using MyBatisCodeGenerator.Utils;
using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MultiLangCreateTableGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.MultiLangCreateTable;

        public override string GetSavedFileName(string defaultExt)
        {
            string fileName = GetItemDefine("TABLENAME") + "_res";

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G64) Do not define TableName.");
            }
            fileName = CreateTablePrefix + fileName + defaultExt;

            return fileName;
        }

        public override string GetClassSpace()
        {
            return String.Empty;
        }

        public override string GetRootPath()
        {
            return BaseScriptPath;
        }

        public override bool IsGeneratable()
        {
            return TemplateUtils.MultiLangDefined(DesignData);
        }

        public MultiLangCreateTableGenerator()
        {
            FileExtension = ".sql";
            GenerateByMeta = true;
            IsMultiLangGenerator = true;
        }
    }
}