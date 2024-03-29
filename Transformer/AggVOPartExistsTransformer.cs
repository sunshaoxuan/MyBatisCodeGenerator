﻿using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class AggVOPartExistsTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 1;
        }

        public override string GetTag()
        {
            return "$HASAGGVO$";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return item.ContainsKey("DATA TYPE") && "AGGVO".Equals(item["DATA TYPE"].ToUpper());
        }

        public override bool IsValid()
        {
            return TemplateUtils.AggVODefined(DesignData);
        }

        public override void Transform()
        {
            SimpleReplace();
        }
    }
}
