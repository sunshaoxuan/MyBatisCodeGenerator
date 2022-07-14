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
            return 1;
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
            List<Dictionary<string, string>> details = GetProcessData();
            foreach(Dictionary<string, string> detail in details)
            {
                if (TemplateUtils.IsBizKeyItem(detail))
                {
                    return true;
                }
            }

            return false;
        }

        public override void Transform()
        {
            SimpleReplace();
        }
    }
}
