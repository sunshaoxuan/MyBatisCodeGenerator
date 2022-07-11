using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MultiLangMapperExtendGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            String fileName = getItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G63) Do not define EntityNameSpace.");
            }

            fileName = fileName + "ResEntityExtendMapper" + defaultExt;
            return fileName;
        }

        public override string getClassSpace()
        {
            return getItemDefine("MAPPERNAMESPACE") + ".extend";
        }

        public override string getRootPath()
        {
            return baseSourcePath;
        }

        public MultiLangMapperExtendGenerator()
        {
            fileExtension = ".java";
            generateByMeta = true;
            isMultiLangGenerator = true;
        }
    }
}
