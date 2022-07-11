using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MultiLangInsertDataGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            string fileName = getItemDefine("TABLENAME") + "_res";

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G65) Do not define TableName.");
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

        public MultiLangInsertDataGenerator()
        {
            fileExtension = ".sql";
            generateByMeta = false;
            isMultiLangGenerator = true;
        }
    }
}