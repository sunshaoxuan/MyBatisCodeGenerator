using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MultiLangEntityGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            string fileName = getItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G60) Do not define EntityNameSpace.");
            }

            fileName = fileName + "ResEntity" + defaultExt;

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

        public MultiLangEntityGenerator()
        {
            fileExtension = ".java";
            generateByMeta = true;
            isMultiLangGenerator = true;
        }
    }
}
