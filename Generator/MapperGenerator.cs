using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MapperGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.Mapper;

        public override string GetSavedFileName(string defaultExt, Dictionary<string, string> tagData)
        {
            string fileName = GetItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G03) Do not define mapper file name.");
            }

            fileName = $"{fileName}EntityMapper{defaultExt}";
            return fileName;
        }

        public override string GetClassSpace()
        {
            return $"{GetItemDefine("CLASSROOT")}.dao";
        }

        public override string GetRootPath()
        {
            return BaseSourcePath;
        }

        public override bool IsGeneratable()
        {
            string designItem = "GENERATE FIELD";
            string compareValue = "Y";

            List<Dictionary<string, string>> details = TemplateUtils.GetDesignMetaDetailByValue(DesignData, designItem, compareValue);
            return details.Count > 0;
        }

        public MapperGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = false;
        }
    }
}
