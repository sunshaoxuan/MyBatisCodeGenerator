using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Generator
{
    public class AggVOGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.AggVO;

        public override string GetSavedFileName(string defaultExt, Dictionary<string, string> tagData)
        {
            string fileName = GetItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G07) Do not define AggVO file name.");
            }

            fileName = fileName + "AggVO" + defaultExt;

            return fileName;
        }

        public override string GetClassSpace()
        {
            return $"{GetItemDefine("CLASSROOT")}.vo.aggvo";
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

        public AggVOGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = false;
        }
    }
}
