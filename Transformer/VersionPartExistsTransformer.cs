using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class VersionPartExistsTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 4;
        }

        public override string GetTag()
        {
            return "$HASVERSION$";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return item.ContainsKey("FIELD NAME") && "VERSION".Equals(item["FIELD NAME"].ToUpper());
        }

        public override bool IsValid()
        {
            return TemplateUtils.VersionPropertyDefined(DesignData);
        }

        public override void Transform()
        {
            SimpleReplace();
        }
    }
}
