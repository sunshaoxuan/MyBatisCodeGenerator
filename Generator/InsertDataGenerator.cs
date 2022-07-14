using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class InsertDataGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.InsertData;

        public override string GetSavedFileName(string defaultExt)
        {
            string fileName = GetItemDefine("TABLENAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G05) Do not define TableName.");
            }
            fileName = "InsertData_" + fileName + defaultExt;

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
            List<Dictionary<string, string>> details = TemplateUtils.GetInsertDataDetail(DesignData);
            return details.Count > 0;
        }

        public InsertDataGenerator()
        {
            FileExtension = ".sql";
            GenerateByMeta = false;
            IsMultiLangGenerator = false;
        }
    }
}