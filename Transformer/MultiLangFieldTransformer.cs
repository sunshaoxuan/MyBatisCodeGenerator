using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class MultiLangFieldTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 18;
        }

        public override string GetTag()
        {
            return "$FOREACH MULTILANG FIELD$";
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
