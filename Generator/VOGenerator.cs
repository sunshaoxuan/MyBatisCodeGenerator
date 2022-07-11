using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Generator
{
    public class VOGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            string fileName = getItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G07) Do not define EntityNameSpace.");
            }

            fileName = fileName + "VO" + defaultExt;

            return fileName;
        }

        public override string getClassSpace()
        {
            return getItemDefine("VONAMESPACE");
        }
        public override string getRootPath()
        {
            return baseSourcePath;
        }

        public VOGenerator()
        {
            fileExtension = ".java";
            generateByMeta = true;
            isMultiLangGenerator = false;
        }
    }
}
