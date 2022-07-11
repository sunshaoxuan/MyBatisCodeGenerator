using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MultiLangMapperGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            String fileName = getItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G62) Do not define EntityNameSpace.");
            }

            fileName = fileName + "ResEntityMapper" + defaultExt;
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

        public MultiLangMapperGenerator()
        {
            fileExtension = ".java";
            generateByMeta = true;
            isMultiLangGenerator = true;
        }
    }
}
