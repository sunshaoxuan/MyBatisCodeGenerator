using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;

namespace MyBatisCodeGenerator.Generator
{
    public class AggVORequestGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.AggVORequest;

        public override string GetSavedFileName(string defaultExt)
        {
            string fileName = GetItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G12) Do not define AggVO file name.");
            }

            fileName = fileName + "AggVORequest" + defaultExt;

            return fileName;
        }

        public override string GetClassSpace()
        {
            return $"{GetItemDefine("CLASSROOT")}.rest.request";
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

        public AggVORequestGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = false;
        }
    }
}
