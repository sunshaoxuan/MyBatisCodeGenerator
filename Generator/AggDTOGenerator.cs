using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;

namespace MyBatisCodeGenerator.Generator
{
    public class AggDTOGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.AggDTO;

        public override string GetSavedFileName(string defaultExt, Dictionary<string, string> tagData)
        {
            string fileName = GetItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G12) Do not define AggVO file name.");
            }

            fileName = fileName + "AggDTO" + defaultExt;

            return fileName;
        }

        public override string GetClassSpace()
        {
            return $"{GetItemDefine("CLASSROOT")}.rest.dto";
        }
        public override string GetRootPath()
        {
            return BaseSourcePath;
        }

        public override bool IsGeneratable()
        {
            List<Dictionary<string, string>> metaDetail = TemplateUtils.GetAllDesignMetaDetail(DesignData);
            foreach (Dictionary<string, string> meta in metaDetail)
            {
                if (TemplateUtils.IsAggVOItem(meta))
                {
                    return true;
                }
            }
            return false;
        }

        public AggDTOGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = false;
        }
    }
}
