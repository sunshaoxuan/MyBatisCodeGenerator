using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MapperExtendGenerator : AbstractGenerator
    {
        public override string getClassSpace()
        {
            return getItemDefine("MAPPERNAMESPACE") + ".extend";
        }

        public override string getRootPath()
        {
            return baseSourcePath;
        }

        public override string getSavedFileName(string defaultExt)
        {
            String fileName = getItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G03) Do not define EntityNameSpace.");
            }

            fileName = fileName + "EntityExtendMapper" + defaultExt;
            return fileName;
        }

        public MapperExtendGenerator()
        {
            fileExtension = ".java";
            generateByMeta = true;
            isMultiLangGenerator = false;
        }
    }
}
