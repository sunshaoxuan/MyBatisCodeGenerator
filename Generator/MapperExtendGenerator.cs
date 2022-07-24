using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MapperExtendGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.MapperExtend;

        public override string GetClassSpace()
        {
            return $"{GetItemDefine("CLASSROOT")}.dao.extend";
        }

        public override string GetRootPath()
        {
            return BaseSourcePath;
        }

        public override string GetSavedFileName(string defaultExt)
        {
            String fileName = GetItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G03) Do not define mapper extend file name.");
            }

            fileName = $"{fileName}EntityExtendMapper{defaultExt}";
            return fileName;
        }

        public override bool IsGeneratable()
        {
            String designItem = "GENERATE FIELD";
            String compareValue = "Y";

            List<Dictionary<string, string>> details = TemplateUtils.GetDesignMetaDetailByValue(DesignData, designItem, compareValue);
            return details.Count > 0;
        }

        public MapperExtendGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = false;
        }
    }
}
