using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class EntityGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            string fileName = getItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G01) Do not define EntityNameSpace.");
            }

            fileName = fileName + "Entity" + defaultExt;

            return fileName;
        }

        public override string getClassSpace()
        {
            return getItemDefine("ENTITYNAMESPACE");
        }
        public override string getRootPath()
        {
            return baseSourcePath;
        }

        public EntityGenerator()
        {
            fileExtension = ".java";
            generateByMeta = true;
            isMultiLangGenerator = false;
        }
    }
}
