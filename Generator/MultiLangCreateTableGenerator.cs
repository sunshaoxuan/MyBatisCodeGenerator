using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MultiLangCreateTableGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            string fileName = getItemDefine("TABLENAME") + "_res";

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G64) Do not define TableName.");
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

        public MultiLangCreateTableGenerator()
        {
            fileExtension = ".sql";
            generateByMeta = true;
            isMultiLangGenerator = true;
        }
    }
}