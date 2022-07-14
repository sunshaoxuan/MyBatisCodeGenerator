using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class PKItemTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 16;
        }

        public override string GetTag()
        {
            return "";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return false;
        }

        public override bool IsValid()
        {
            return true;
        }

        public override void Transform()
        {
            List<Dictionary<string, string>> data = GetProcessData();

            if (data.Count > 0)
            {
                foreach (Dictionary<string, string> item in data)
                {
                    if (item.ContainsKey("PRIMARY KEY") && item["PRIMARY KEY"].Equals("Y"))
                    {
                        OriginalContent.Replace("$PKFIELDNAME$", item["FIELD NAME"]);
                        OriginalContent.Replace("$PKPROPERTYNAME$", item["PROPERTY NAME"]);
                        OriginalContent.Replace("$PKFIELDDATATYPE$", TemplateUtils.GetJDBCType(item["DATA TYPE"]));
                        OriginalContent.Replace("$PKFIELDJAVATYPE$", TemplateUtils.GetJavaType(item["DATA TYPE"]));
                        OriginalContent.Replace("$PKGETMETHOD$", TemplateUtils.GetPropertyGetMethod(item["PROPERTY NAME"]));
                    }
                }
            }
        }
    }
}
