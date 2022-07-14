using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class NoPKFieldTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 7;
        }

        public override string GetTag()
        {
            return "$FOREACH FIELD EXCEPT PK$";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return !TemplateUtils.IsMultiLangItem(item) && !TemplateUtils.IsAggVOItem(item) && !TemplateUtils.IsPrimaryKeyItem(item);
        }

        public override bool IsValid()
        {
            return true;
        }

        public override void Transform()
        {
            DoCommonTransform();
        }
    }
}
