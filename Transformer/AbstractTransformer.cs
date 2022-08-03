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
        /// 完整定义数据表
        /// </summary>
        public Dictionary<string, DataTable> ExcelData { get; set; }

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

        public void ConditionalReplace()
        {
            string condBeginTag = "$IF ";
            string condElse = "$ELSE$";
            string condEndTag = "$END IF$";

            while (OriginalContent.ToString().Contains(condBeginTag))
            {
                int blockStartIndex = OriginalContent.ToString().IndexOf(condBeginTag);
                int elseIndex = OriginalContent.ToString().IndexOf(condElse);
                int blockEndIndex = OriginalContent.ToString().IndexOf(condEndTag) + condEndTag.Length;
                string condition = OriginalContent.ToString().Substring(blockStartIndex + condBeginTag.Length, OriginalContent.ToString().IndexOf("$", blockStartIndex + 1) - blockStartIndex - condBeginTag.Length).Trim();

                if (blockEndIndex < blockStartIndex)
                {
                    throw new Exception("[$IF$] tag define invalid.");
                }

                string block = OriginalContent.ToString().Substring(blockStartIndex, blockEndIndex - blockStartIndex);

                int truePartSeedStartIndex = blockStartIndex + condBeginTag.Length + condition.Length + 1;
                int truePartSeedEndIndex = elseIndex - 1;
                int falsePartSeedStartIndex = elseIndex + condElse.Length;
                int falsePartSeedEndIndex = blockEndIndex - condEndTag.Length;
                string truePartSeed = OriginalContent.ToString().Substring(truePartSeedStartIndex, truePartSeedEndIndex - truePartSeedStartIndex + 1);
                string falsePartSeed = OriginalContent.ToString().Substring(falsePartSeedStartIndex, falsePartSeedEndIndex - falsePartSeedStartIndex);

                bool conditionValue = false;
                if (condition.StartsWith("HASMULTILANGPROPERTY"))
                {
                    conditionValue = TemplateUtils.MultiLangDefined(DesignData);
                }
                else if (condition.StartsWith("HASAGGVO"))
                {
                    conditionValue = TemplateUtils.AggVODefined(DesignData);
                }
                else if (condition.StartsWith("HASVERSION"))
                {
                    conditionValue = TemplateUtils.VersionPropertyDefined(DesignData);
                }
                else if (condition.StartsWith("HASBIZKEY"))
                {
                    conditionValue = TemplateUtils.BizKeyDefined(DesignData);
                }
                else if (condition.StartsWith("BIZKEYCONTAINVARCHAR"))
                {
                    conditionValue = TemplateUtils.BizKeyContainVarchar(DesignData);
                }

                if (conditionValue)
                {
                    OriginalContent = OriginalContent.Replace(block, truePartSeed);
                }
                else
                {
                    OriginalContent = OriginalContent.Replace(block, falsePartSeed);
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
            tempSB.Replace("$PROPERTYVODATATYPE_REMOVEVO$", item["VO DATA TYPE"].EndsWith("VO") ? item["VO DATA TYPE"].Replace("VO", "") : item["VO DATA TYPE"]);
            tempSB.Replace("$LOWER_PROPERTYVODATATYPE_REMOVEVO$", TemplateUtils.replaceSeed("", "", item["VO DATA TYPE"].EndsWith("VO") ? item["VO DATA TYPE"].Replace("VO", "") : item["VO DATA TYPE"], "$LOWER_PROPERTYVODATATYPE$"));
            tempSB.Replace("$PROPERTYDATATYPE$", TemplateUtils.GetJDBCType(item["DATA TYPE"]));
            tempSB.Replace("$PROPERTYJAVATYPE$", TemplateUtils.GetJavaType(item["DATA TYPE"]));
            tempSB.Replace("$PROPERTYVODATATYPE$", item["VO DATA TYPE"]);
            tempSB.Replace("$PROPERTYGETMETHOD$", TemplateUtils.GetPropertyGetMethod(item["PROPERTY NAME"]));
            tempSB.Replace("$PROPERTYSETMETHOD$", TemplateUtils.GetPropertySetMethod(item["PROPERTY NAME"]));
            tempSB.Replace("$PROPERTYDESC$", item["DESCRIPTION"]);
            tempSB.Replace("$FIELDDATATYPE$", TemplateUtils.GetSQLDataType(item["DATA TYPE"], item["FIELD LENGTH"]));
            tempSB.Replace("$CHARACTERTAG$", TemplateUtils.GetSQLCharacterTag(item["DATA TYPE"]));
            tempSB.Replace("$DEFAULTTAG$", TemplateUtils.GetSQLDefaultTag(item["DEFAULT VALUE"], item["CAN BE NULL"]));
            tempSB.Replace("$PROPERTYGETMETHOD$", TemplateUtils.GetGetMethod(item["PROPERTY NAME"]));
            tempSB.Replace("%AUTO4SN%", index.ToString("D4"));

            if (tempSB.ToString().Contains("$BIGINT"))
            {
                if ("Long".Equals(TemplateUtils.GetJavaType(item["DATA TYPE"]))) {

                    tempSB.Remove(tempSB.ToString().IndexOf("$BIGINT BEGIN$"), "$BIGINT BEGIN$".Length);
                    tempSB.Remove(tempSB.ToString().IndexOf("$BIGINT END$"), "$BIGINT END$".Length);
                }
                else
                {
                    tempSB.Remove(tempSB.ToString().IndexOf("$BIGINT BEGIN$"),
                        tempSB.ToString().IndexOf("$BIGINT END$") + "$BIGINT END$".Length - tempSB.ToString().IndexOf("$BIGINT BEGIN$"));
                }
            }

            if (tempSB.ToString().Contains("$IFFORMATTEDDATE"))
            {
                if ("Date".Equals(TemplateUtils.GetJavaType(item["DATA TYPE"])))
                {
                    tempSB.Remove(tempSB.ToString().IndexOf("$IFFORMATTEDDATE BEGIN$"), "$IFFORMATTEDDATE BEGIN$".Length);
                    tempSB.Remove(tempSB.ToString().IndexOf("$IFFORMATTEDDATE END$"), "$IFFORMATTEDDATE END$".Length);
                }
                else
                {
                    tempSB.Remove(tempSB.ToString().IndexOf("$IFFORMATTEDDATE BEGIN$"),
                        tempSB.ToString().IndexOf("$IFFORMATTEDDATE END$") + "$IFFORMATTEDDATE END$".Length - tempSB.ToString().IndexOf("$IFFORMATTEDDATE BEGIN$"));
                }
            }

            if (tempSB.ToString().Contains("$IFVERSION "))
            {
                if ("VERSION".Equals(item["FIELD NAME"].ToUpper()))
                {
                    tempSB.Remove(tempSB.ToString().IndexOf("$IFVERSION BEGIN$"), "$IFVERSION BEGIN$".Length);
                    tempSB.Remove(tempSB.ToString().IndexOf("$IFVERSION ELSE$"),
                        tempSB.ToString().IndexOf("$IFVERSION END$") + "$IFVERSION END$".Length - tempSB.ToString().IndexOf("$IFVERSION ELSE$"));
                }
                else
                {
                    tempSB.Remove(tempSB.ToString().IndexOf("$IFVERSION BEGIN$"),
                        tempSB.ToString().IndexOf("$IFVERSION ELSE$") + "$IFVERSION ELSE$".Length - tempSB.ToString().IndexOf("$IFVERSION BEGIN$"));
                    tempSB.Remove(tempSB.ToString().IndexOf("$IFVERSION END$"), "$IFVERSION END$".Length);
                }
            }
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

        /// <summary>
        /// 多语资源
        /// </summary>
        public Dictionary<string, Dictionary<String, string[]>> MultiLangRefInfo { get; set; }

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
                int i = 0, j = 0;
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
                        j++;
                        continue;
                    }
                    else
                    {
                        ReplaceMetaSetItem(tempSB, i - j, item, metaDetail.Count - skiped);
                        tempSB.Replace("$IDRESULTTAG$", TemplateUtils.IsPrimaryKeyItem(item) ? ", id = true" : "");

                        string[] resinfo = RegisterMultiLangRefInfo(DesignData, item, i);
                        tempSB.Replace("$MULTILANGRESCATALOG$", resinfo[1]);
                        tempSB.Replace("$MULTILANGRESID$", resinfo[2]);
                    }
                    finalSB.Append(tempSB);
                }
                OriginalContent.Replace(block, finalSB.ToString());
            }
        }

        private string[] RegisterMultiLangRefInfo(DataTable designData, Dictionary<string, string> item, int idx)
        {
            string entityName = TemplateUtils.GetItemDefine(designData, "ENTITYNAME", null);
            string entityDesc = TemplateUtils.GetItemDefine(designData, "ENTITYDESC", null);
            string itemKey = item["FIELD NAME"];
            string itemShowName = item["DESCRIPTION"];
            string itemResCatalog = "meta_" + TemplateUtils.replaceSeed("", "", entityName, "$ENTITYNAME_LOWER$");
            string itemResID = $"mt{idx.ToString("D4")}";

            Dictionary<string, Dictionary<string, string>> commonMultiLang = GetCommonMultiLangResFromDB();

            string[] resInfo = MatchMultiLangRes(itemShowName, commonMultiLang);

            if (resInfo != null)
            {
                return new string[] { "", resInfo[0], resInfo[1] };
            }
            else
            {
                if (MultiLangRefInfo == null)
                {
                    MultiLangRefInfo = new Dictionary<string, Dictionary<string, string[]>>();
                }

                if (!MultiLangRefInfo.ContainsKey(entityName))
                {
                    MultiLangRefInfo.Add(entityName, new Dictionary<string, string[]>());
                }

                if (!MultiLangRefInfo[entityName].ContainsKey(itemKey))
                {
                    MultiLangRefInfo[entityName].Add(itemKey, new string[3]);
                }

                if (itemResCatalog.StartsWith("meta_"))
                {
                    if (!MultiLangRefInfo[entityName].ContainsKey(""))
                    {
                        MultiLangRefInfo[entityName].Add("", new string[] { entityDesc, itemResCatalog, "mt0000" });

                    }
                }

                MultiLangRefInfo[entityName][itemKey] = new string[] { itemShowName, itemResCatalog, itemResID };
                return MultiLangRefInfo[entityName][itemKey];
            }
        }

        private string[] MatchMultiLangRes(string itemShowName, Dictionary<string, Dictionary<string, string>> commonMultiLang)
        {
            foreach (KeyValuePair<string, Dictionary<string, string>> catalogDic in commonMultiLang)
            {
                foreach (KeyValuePair<string, string> resinfo in catalogDic.Value)
                {
                    if (resinfo.Value.Equals(itemShowName))
                    {
                        return new string[] { catalogDic.Key, resinfo.Key };
                    }
                }
            }

            return null;
        }

        private Dictionary<string, Dictionary<string, string>> GetCommonMultiLangResFromDB()
        {
            return TemplateUtils.GetCommonMultiLangResFromDB();
        }
    }
}