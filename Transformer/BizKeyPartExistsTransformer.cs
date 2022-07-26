using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class BizKeyPartExistsTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 2;
        }

        public override string GetTag()
        {
            return "$HASBIZKEY$";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return item.ContainsKey("BIZ KEY") && item["BIZ KEY"].Equals("Y");
        }

        public override bool IsValid()
        {
            return TemplateUtils.BizKeyDefined(DesignData);
        }

        public override void Transform()
        {
            SimpleReplace();
        }
    }
}
