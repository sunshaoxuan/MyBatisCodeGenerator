using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class AggVOTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 15;
        }

        public override string GetTag()
        {
            return "$FOREACH AGG VO$";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return TemplateUtils.IsAggVOItem(item);
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
