using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    /// <summary>
    /// 是否存在多语段转换器
    /// 
    /// $HASMULTILANGPROPERTY$
    /// </summary>
    public class MultiLangPartExistsTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 2;
        }

        public override string GetTag()
        {
            return "$HASMULTILANGPROPERTY$";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return false;
        }

        public override bool IsValid()
        {
            return TemplateUtils.MultiLangDefined(DesignData);
        }

        public override void Transform()
        {
            SimpleReplace();
        }
    }
}