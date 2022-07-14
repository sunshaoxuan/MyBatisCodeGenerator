using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class MultiLangPropertyTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 5;
        }

        public override string GetTag()
        {
            return "$FOREACH MULTILANG PROPERTY$";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return TemplateUtils.IsMultiLangItem(item);
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
