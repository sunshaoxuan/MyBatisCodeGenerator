using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public abstract class AbstractTransformer
    {
        /// <summary>
        /// 执行标记
        /// </summary>
        public abstract string GetTag();

        /// <summary>
        /// 原始内容
        /// </summary>
        public StringBuilder OriginalContent { get; set; }

        /// <summary>
        /// 模型定义数据表
        /// </summary>
        public DataTable DesignData { get; set; }

        /// <summary>
        /// 自定义参数
        /// </summary>
        public Dictionary<String, String> DefRefs { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        /// <returns></returns>
        public abstract int GetOrder();

        /// <summary>
        /// 转换
        /// </summary>
        /// <returns></returns>
        public abstract void Transform();

        /// <summary>
        /// 取待处理数据集
        /// </summary>
        /// <returns></returns>
        public List<Dictionary<string, string>> GetProcessData()
        {
            return TemplateUtils.GetAllDesignMetaDetail(DesignData);
        }

        public List<Dictionary<string, string>> GetInsertData()
        {
            return TemplateUtils.GetInsertDataDetail(DesignData);
        }

        public List<Dictionary<string, string>> GetMultiLangInsertData()
        {
            return TemplateUtils.GetMultiLangInsertData(DesignData);
        }

        public void SimpleReplace()
        {
            while (OriginalContent.ToString().Contains(GetBeginTag()))
            {
                int blockStartIndex = OriginalContent.ToString().IndexOf(GetBeginTag());
                int blockEndIndex = OriginalContent.ToString().IndexOf(GetEndTag()) + GetEndTag().Length;

                if (blockEndIndex < blockStartIndex)
                {
                    throw new Exception("[" + GetTag() + "] tag define invalid.");
                }

                string block = OriginalContent.ToString().Substring(blockStartIndex, blockEndIndex - blockStartIndex);

                int seedStartIndex = blockStartIndex + GetBeginTag().Length;
                int seedEndIndex = blockEndIndex - GetEndTag().Length;
                string seed = OriginalContent.ToString().Substring(seedStartIndex, seedEndIndex - seedStartIndex);

                if (IsValid())
                {
                    OriginalContent = OriginalContent.Replace(block, seed);
                }
                else
                {
                    OriginalContent = OriginalContent.Replace(block, "");
                }
            }
        }

        public abstract bool IsValid();

        internal List<Dictionary<string, string>> GetGeneratedMetaDetail()
        {
            return TemplateUtils.GetDesignMetaDetailByValue(DesignData, "GENERATE PROPERTY", "Y");
        }

        internal List<Dictionary<string, string>> GetGeneratedFieldDetail()
        {
            return TemplateUtils.GetDesignMetaDetailByValue(DesignData, "GENERATE FIELD", "Y");
        }

        internal void ReplaceMetaSetItem(StringBuilder tempSB, int index, Dictionary<string, string> item, int totalCount)
        {
            tempSB.Replace("$FIELDNAME$", item["FIELD NAME"]);
            tempSB.Replace("$COMMAEXCEPTLAST$", index == totalCount ? "" : ",");
            tempSB.Replace("$PROPERTYNAME$", item["PROPERTY NAME"]);
            tempSB.Replace("$UPPER_PROPERTYNAME$", TemplateUtils.replaceSeed("", "", item["PROPERTY NAME"], "$UPPER_PROPERTYNAME$"));
            tempSB.Replace("$LOWER_PROPERTYNAME$", TemplateUtils.replaceSeed("", "", item["PROPERTY NAME"], "$LOWER_PROPERTYNAME$"));
            tempSB.Replace("$UPPER_PROPERTYVODATATYPE$", TemplateUtils.replaceSeed("", "", item["VO DATA TYPE"], "$UPPER_PROPERTYVODATATYPE$"));
            tempSB.Replace("$LOWER_PROPERTYVODATATYPE$", TemplateUtils.replaceSeed("", "", item["VO DATA TYPE"], "$LOWER_PROPERTYVODATATYPE$"));
            tempSB.Replace("$PROPERTYDATATYPE$", TemplateUtils.GetJDBCType(item["DATA TYPE"]));
            tempSB.Replace("$PROPERTYJAVATYPE$", TemplateUtils.GetJavaType(item["DATA TYPE"]));
            tempSB.Replace("$PROPERTYVODATATYPE$", item["VO DATA TYPE"]);
            tempSB.Replace("$PROPERTYGETMETHOD$", TemplateUtils.GetPropertyGetMethod(item["PROPERTY NAME"]));
            tempSB.Replace("$PROPERTYSETMETHOD$", TemplateUtils.GetPropertySetMethod(item["PROPERTY NAME"]));
            tempSB.Replace("$PROPERTYDESC$", item["DESCIPTION"]);
            tempSB.Replace("$FIELDDATATYPE$", TemplateUtils.GetSQLDataType(item["DATA TYPE"], item["FIELD LENGTH"]));
            tempSB.Replace("$CHARACTERTAG$", TemplateUtils.GetSQLCharacterTag(item["DATA TYPE"]));
            tempSB.Replace("$DEFAULTTAG$", TemplateUtils.GetSQLDefaultTag(item["DEFAULT VALUE"], item["CAN BE NULL"]));
            tempSB.Replace("$PROPERTYGETMETHOD$", TemplateUtils.GetGetMethod(item["PROPERTY NAME"]));
            tempSB.Replace("%AUTO4SN%", index.ToString("D4"));
        }

        internal string GetBeginTag()
        {
            return GetTag().Trim().Insert(GetTag().LastIndexOf("$"), " BEGIN");
        }

        internal string GetEndTag()
        {
            return GetTag().Trim().Insert(GetTag().LastIndexOf("$"), " END");
        }

        /// <summary>
        /// 是否应处理项目
        /// </summary>
        /// <param name="item">元定义项目</param>
        /// <returns></returns>
        public abstract bool IsTransformItem(Dictionary<string, string> item);

        internal void DoCommonTransform()
        {
            while (OriginalContent.ToString().Contains(GetBeginTag()))
            {
                int blockStartIndex = OriginalContent.ToString().IndexOf(GetBeginTag());
                int blockEndIndex = OriginalContent.ToString().IndexOf(GetEndTag()) + GetEndTag().Length;

                if (blockEndIndex < blockStartIndex)
                {
                    throw new Exception("[" + GetTag() + "] tag define invalid.");
                }

                string block = OriginalContent.ToString().Substring(blockStartIndex, blockEndIndex - blockStartIndex);

                int seedStartIndex = blockStartIndex + GetBeginTag().Length;
                int seedEndIndex = blockEndIndex - GetEndTag().Length;
                string seed = OriginalContent.ToString().Substring(seedStartIndex, seedEndIndex - seedStartIndex);

                List<Dictionary<string, string>> metaDetail = GetProcessData();
                int i = 0;
                int skiped = 0;
                foreach (Dictionary<string, string> item in metaDetail)
                {
                    if (!IsTransformItem(item))
                    {
                        skiped++;
                    }
                }

                StringBuilder finalSB = new StringBuilder();
                foreach (Dictionary<string, string> item in metaDetail)
                {
                    i++;
                    StringBuilder tempSB = new StringBuilder();
                    tempSB.Append(seed);

                    if (!IsTransformItem(item))
                    {
                        continue;
                    }
                    else
                    {
                        ReplaceMetaSetItem(tempSB, i, item, metaDetail.Count - skiped + 1);
                        tempSB.Replace("$IDRESULTTAG$", TemplateUtils.IsPrimaryKeyItem(item) ? ", id = true" : "");
                    }
                    finalSB.Append(tempSB);
                }
                OriginalContent.Replace(block, finalSB.ToString());
            }
        }
    }
}
