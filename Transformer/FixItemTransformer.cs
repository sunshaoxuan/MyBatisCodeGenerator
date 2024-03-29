﻿using MyBatisCodeGenerator.Utils;
using System.Collections.Generic;

namespace MyBatisCodeGenerator.Transformer
{
    public class FixItemTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 20;
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
            TemplateUtils.ApplyFixedDefines(DesignData, OriginalContent, DefRefs);
        }
    }
}
