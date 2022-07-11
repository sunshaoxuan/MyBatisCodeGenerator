using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class CreateTableGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            string fileName = getItemDefine("TABLENAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G04) Do not define TableName.");
            }
            fileName = "CreateTable_" + fileName + defaultExt;

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

        public CreateTableGenerator()
        {
            fileExtension = ".sql";
            generateByMeta = true;
            isMultiLangGenerator =false;
        }
    }
}