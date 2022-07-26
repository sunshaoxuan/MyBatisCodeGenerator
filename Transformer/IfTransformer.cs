using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    internal class IfTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 6;
        }

        public override string GetTag()
        {
            return "$IF$";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return true;
        }

        public override bool IsValid()
        {
            return false;
        }

        public override void Transform()
        {
            ConditionalReplace();
        }
    }
}
