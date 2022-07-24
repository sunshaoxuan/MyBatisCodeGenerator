using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class CommonFieldTransformer : AbstractTransformer
    {
        public override string GetTag()
        {
            return "$FOREACH FIELD$";
        }

        public override bool IsValid()
        {
            return true;
        }

        public override void Transform()
        {
            DoCommonTransform();
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return !TemplateUtils.IsMultiLangItem(item) && !TemplateUtils.IsAggVOItem(item);
        }

        public override int GetOrder()
        {
            return 14;
        }
    }
}
