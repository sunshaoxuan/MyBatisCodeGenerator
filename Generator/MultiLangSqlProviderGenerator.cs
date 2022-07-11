using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Generator
{
    internal class MultiLangSqlProviderGenerator : AbstractGenerator
    {
        public override string getSavedFileName(string defaultExt)
        {
            string fileName = getItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G61) Do not define EntityNameSpace.");
            }

            fileName = fileName + "ResEntitySqlProvider" + defaultExt;

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

        public MultiLangSqlProviderGenerator()
        {
            fileExtension = ".java";
            generateByMeta = true;
            isMultiLangGenerator = true;
        }
    }
}