using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MapperGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            String fileName = getItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G03) Do not define EntityNameSpace.");
            }

            fileName = fileName + "EntityMapper" + defaultExt;
            return fileName;
        }

        public override string getClassSpace()
        {
            return getItemDefine("MAPPERNAMESPACE");
        }

        public override string getRootPath()
        {
            return baseSourcePath;
        }

        public MapperGenerator()
        {
            fileExtension = ".java";
            generateByMeta = true;
            isMultiLangGenerator = false;
        }
    }
}
