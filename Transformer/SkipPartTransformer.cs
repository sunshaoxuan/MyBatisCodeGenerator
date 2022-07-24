using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer  
{
    internal class SkipPartTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 5;
        }

        public override string GetTag()
        {
            return "$SKIP$";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return false;
        }

        public override bool IsValid()
        {
            return false;
        }

        public override void Transform()
        {
            SimpleReplace();
        }
    }
}
