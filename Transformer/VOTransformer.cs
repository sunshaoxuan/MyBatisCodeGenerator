using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class VOTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 9;
        }

        public override string GetTag()
        {
            return "$FOREACH VO$";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return !TemplateUtils.IsMultiLangItem(item);
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
