using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class SqlProviderGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.SqlProvider;

        public override string GetSavedFileName(string defaultExt)
        {
            String fileName = GetItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G02) Do not define EntityNameSpace.");
            }

            fileName = fileName + "EntitySqlProvider" + defaultExt;
            return fileName;
        }

        public override string GetClassSpace()
        {
            return GetItemDefine("SQLPROVIDERNAMESPACE");
        }

        public override string GetRootPath()
        {
            return BaseSourcePath;
        }

        public override bool IsGeneratable()
        {
            String designItem = "GENERATE FIELD";
            String compareValue = "Y";

            List<Dictionary<string, string>> details = TemplateUtils.GetDesignMetaDetailByValue(DesignData, designItem, compareValue);
            return details.Count > 0;
        }

        public SqlProviderGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = false;
        }
    }
}
