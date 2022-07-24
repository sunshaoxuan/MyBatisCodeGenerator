using MyBatisCodeGenerator.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class BizKeyTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 21;
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
                    if (item.ContainsKey("BIZ KEY") && item["BIZ KEY"].Equals("Y"))
                    {
                        OriginalContent.Replace("$BIZKEYFIELDNAME$", item["FIELD NAME"]);
                        OriginalContent.Replace("$BIZKEYPROPERTYNAME$", item["PROPERTY NAME"]);
                        OriginalContent.Replace("$BIZKEYFIELDDATATYPE$", TemplateUtils.GetJDBCType(item["DATA TYPE"]));
                        OriginalContent.Replace("$BIZKEYFIELDJAVATYPE$", TemplateUtils.GetJavaType(item["DATA TYPE"]));
                        OriginalContent.Replace("$BIZKEYGETMETHOD$", TemplateUtils.GetPropertyGetMethod(item["PROPERTY NAME"]));
                        OriginalContent.Replace("$BIZKEYWHERECONDITION$",
                            "$BIZKEYWHERECONDITION$ OR " + item["FIELD NAME"] + "= #{bizKeyValue,jdbcType=" + TemplateUtils.GetJDBCType(item["DATA TYPE"]) + "}");
                    }
                }

                OriginalContent.Replace("$BIZKEYWHERECONDITION$", "");
            }
        }
    }
}