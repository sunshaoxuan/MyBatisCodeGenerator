using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class SqlProviderGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            String fileName = getItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G02) Do not define EntityNameSpace.");
            }

            fileName = fileName + "EntitySqlProvider" + defaultExt;
            return fileName;
        }

        public override string getClassSpace()
        {
            return getItemDefine("SQLPROVIDERNAMESPACE");
        }

        public override string getRootPath()
        {
            return baseSourcePath;
        }

        public SqlProviderGenerator()
        {
            fileExtension = ".java";
            generateByMeta = true;
            isMultiLangGenerator = false;
        }
    }
}
