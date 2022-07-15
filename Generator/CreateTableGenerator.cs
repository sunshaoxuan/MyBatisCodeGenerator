using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class CreateTableGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.CreateTable;

        public override string GetSavedFileName(string defaultExt)
        {
            string fileName = GetItemDefine("TABLENAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G04) Do not define TableName.");
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
            String designItem = "GENERATE FIELD";
            String compareValue = "Y";

            List<Dictionary<string, string>> details = TemplateUtils.GetDesignMetaDetailByValue(DesignData, designItem, compareValue);
            return details.Count > 0;
        }

        public CreateTableGenerator()
        {
            FileExtension = ".sql";
            GenerateByMeta = true;
            IsMultiLangGenerator =false;
        }
    }
}