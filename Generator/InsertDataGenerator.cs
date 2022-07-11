using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class InsertDataGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            string fileName = getItemDefine("TABLENAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G05) Do not define TableName.");
            }
            fileName = "InsertData_" + fileName + defaultExt;

            return fileName;
        }

        public override string getClassSpace()
        {
            return String.Empty;
        }

        public override string getRootPath()
        {
            return baseScriptPath;
        }

        public InsertDataGenerator()
        {
            fileExtension = ".sql";
            generateByMeta = false;
            isMultiLangGenerator = false;
        }
    }
}