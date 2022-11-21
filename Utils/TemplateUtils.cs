using Google.Protobuf.WellKnownTypes;
using MyBatisCodeGenerator.Transformer;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Utils
{
    public class TemplateUtils
    {
        public enum TemplateTypeEnum
        {
            Entity = 0, SqlProvider = 1, Mapper = 2, MapperExtend = 3, CreateTable = 4,
            InsertData = 5, MultiLanguage = 6, VO = 7, AggVO = 8, Rest = 9, Service = 10,
            ServiceImpl = 11, AggDTO = 12, DTO = 13, Handler = 14,
            MultiLangEntity = 60, MultiLangSqlProvider = 61, MultiLangMapper = 62,
            MultiLangMapperExtend = 63, MultiLangCreateTable = 64, MultiLangInsertData = 65
        }

        internal static bool BizKeyDefined(DataTable designData)
        {
            List<Dictionary<string, string>> details = GetAllDesignMetaDetail(designData);
            foreach (Dictionary<string, string> detail in details)
            {
                if (TemplateUtils.IsBizKeyItem(detail))
                {
                    return true;
                }
            }

            return false;
        }

        internal static bool VersionPropertyDefined(DataTable designData)
        {
            List<Dictionary<string, string>> rst = GetDesignMetaDetailByValue(designData, "FIELD NAME", "version");
            return rst.Count > 0;
        }

        public static string designStartTag = "$MYBATIS META DESIGN START$";
        public static string designEndTag = "$MYBATIS META DESIGN END$";
        public static string dataStartTag = "$MYBATIS DATA START$";
        public static string dataEndTag = "$MYBATIS DATA END$";
        public static string multiLangStartTag = "$MYBATIS MULTILANG DATA START$";
        public static string multiLangEndTag = "$MYBATIS MULTILANG DATA END$";

        internal static List<Dictionary<string, string>> GeMultiLangDataDetail(DataTable designData)
        {

            List<Dictionary<string, string>> detail = new List<Dictionary<string, string>>();
            bool enterBlock = false;

            bool findProperty = false;
            int indexLine = -1;
            string[] headers = new string[designData.Columns.Count - 1];

            foreach (DataRow row in designData.Rows)
            {
                if (row[0].ToString().ToUpper().Equals(multiLangStartTag))
                {
                    enterBlock = true;
                }

                if (!enterBlock)
                {
                    continue;
                }

                if (row[0].ToString().ToUpper().Equals(multiLangEndTag))
                {
                    enterBlock = false;
                    break;
                }

                Dictionary<string, string> valueInfo = new Dictionary<string, string>();
                if (row[0].ToString().ToUpper().Equals("INITIAL DATA") && !findProperty)
                {
                    findProperty = true;
                    indexLine = 0;
                }

                if (findProperty)
                {
                    if (indexLine == 0)
                    {
                        for (int i = 1; i < designData.Columns.Count; i++)
                        {
                            headers[i - 1] = row[i].ToString().ToUpper();
                        }
                    }
                    else
                    {
                        for (int i = 1; i < designData.Columns.Count; i++)
                        {
                            valueInfo.Add(headers[i - 1], row[i].ToString());
                        }

                        if (!string.IsNullOrEmpty(valueInfo["ID"]))
                        {
                            detail.Add(valueInfo);
                        }
                    }

                    indexLine++;
                }

            }

            return detail;
        }

        public static Boolean MultiLangDefined(DataTable designData)
        {
            List<Dictionary<string, string>> details = GetAllDesignMetaDetail(designData);
            foreach (Dictionary<string, string> detail in details)
            {
                if (TemplateUtils.IsMultiLangItem(detail))
                {
                    return true;
                }
            }

            return false;
        }

        public static Boolean AggVODefined(DataTable designData)
        {
            List<Dictionary<string, string>> details = GetAllDesignMetaDetail(designData);
            foreach (Dictionary<string, string> detail in details)
            {
                if (TemplateUtils.IsAggVOItem(detail))
                {
                    return true;
                }
            }

            return false;
        }

        public static List<Dictionary<string, string>> GetAllDesignMetaDetail(DataTable designData)
        {
            List<Dictionary<string, string>> detail = new List<Dictionary<string, string>>();
            bool enterBlock = false;

            bool findProperty = false;
            int indexLine = -1;
            string[] headers = new string[designData.Columns.Count - 1];

            foreach (DataRow row in designData.Rows)
            {
                if (row[0].ToString().ToUpper().Equals(designStartTag))
                {
                    enterBlock = true;
                }

                if (!enterBlock)
                {
                    continue;
                }

                if (row[0].ToString().ToUpper().Equals(designEndTag))
                {
                    enterBlock = false;
                    break;
                }

                Dictionary<string, string> valueInfo = new Dictionary<string, string>();
                if (row[0].ToString().ToUpper().Equals("PROPERTIES") && !findProperty)
                {
                    findProperty = true;
                    indexLine = 0;
                }

                if (findProperty)
                {
                    if (indexLine == 0)
                    {
                        for (int i = 1; i < designData.Columns.Count; i++)
                        {
                            headers[i - 1] = row[i].ToString().ToUpper();
                        }
                    }
                    else
                    {
                        for (int i = 1; i < designData.Columns.Count; i++)
                        {
                            valueInfo.Add(headers[i - 1], row[i].ToString());
                        }

                        if (!string.IsNullOrEmpty(valueInfo["PROPERTY NAME"]))
                        {
                            detail.Add(valueInfo);
                        }
                    }

                    indexLine++;
                }

            }

            return detail;
        }

        internal static bool BizKeyContainVarchar(DataTable designData)
        {
            List<Dictionary<string, string>> details = GetAllDesignMetaDetail(designData);
            foreach (Dictionary<string, string> detail in details)
            {
                if (TemplateUtils.IsBizKeyItem(detail))
                {
                    if (TemplateUtils.IsVarcharItem(detail))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool IsVarcharItem(Dictionary<string, string> item)
        {
            return item.ContainsKey("DATA TYPE") && item["DATA TYPE"].ToUpper().Equals("VARCHAR");
        }

        public static List<Dictionary<string, string>> GetDesignMetaDetailByValue(DataTable designData, string designItem, string compareValue)
        {
            List<Dictionary<string, string>> detail = new List<Dictionary<string, string>>();
            bool enterBlock = false;

            bool findProperty = false;
            int indexLine = -1;
            string[] headers = new string[designData.Columns.Count - 1];

            foreach (DataRow row in designData.Rows)
            {
                if (row[0].ToString().ToUpper().Equals(designStartTag))
                {
                    enterBlock = true;
                }

                if (!enterBlock)
                {
                    continue;
                }

                if (row[0].ToString().ToUpper().Equals(designEndTag))
                {
                    enterBlock = false;
                    break;
                }

                Dictionary<string, string> valueInfo = new Dictionary<string, string>();
                if (row[0].ToString().ToUpper().Equals("PROPERTIES") && !findProperty)
                {
                    findProperty = true;
                    indexLine = 0;
                }

                if (findProperty)
                {
                    if (indexLine == 0)
                    {
                        for (int i = 1; i < designData.Columns.Count; i++)
                        {
                            headers[i - 1] = row[i].ToString().ToUpper();
                        }
                    }
                    else
                    {
                        for (int i = 1; i < designData.Columns.Count; i++)
                        {
                            valueInfo.Add(headers[i - 1], row[i].ToString());
                        }

                        if (!string.IsNullOrEmpty(valueInfo["PROPERTY NAME"]))
                        {
                            if (valueInfo.ContainsKey(designItem))
                            {
                                if (valueInfo[designItem].ToString().Equals(compareValue))
                                {
                                    detail.Add(valueInfo);
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    indexLine++;
                }

            }

            return detail;
        }

        public static List<Dictionary<string, string>> GetMultiLangInsertData(DataTable designData)
        {
            List<Dictionary<string, string>> detail = new List<Dictionary<string, string>>();
            bool enterBlock = false;

            bool findProperty = false;
            int indexLine = -1;
            string[] headers = new string[designData.Columns.Count - 1];

            foreach (DataRow row in designData.Rows)
            {
                if (row[0].ToString().ToUpper().Equals(multiLangStartTag))
                {
                    enterBlock = true;
                }

                if (!enterBlock)
                {
                    continue;
                }

                if (row[0].ToString().ToUpper().Equals(multiLangEndTag))
                {
                    enterBlock = false;
                    break;
                }

                Dictionary<string, string> valueInfo = new Dictionary<string, string>();
                if (row[0].ToString().ToUpper().Equals("INITIAL DATA") && !findProperty)
                {
                    findProperty = true;
                    indexLine = 0;
                }

                if (findProperty)
                {
                    if (indexLine == 0)
                    {
                        for (int i = 1; i < designData.Columns.Count; i++)
                        {
                            headers[i - 1] = row[i].ToString().ToUpper();
                        }
                    }
                    else
                    {
                        for (int i = 1; i < designData.Columns.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(headers[i - 1]))
                            {
                                valueInfo.Add(headers[i - 1], row[i].ToString());
                            }
                        }

                        if (!string.IsNullOrEmpty(valueInfo["ID"]))
                        {
                            detail.Add(valueInfo);
                        }
                    }

                    indexLine++;
                }

            }

            return detail;
        }

        private static Dictionary<string, Dictionary<string, string>> commonMultiLangInfo = new Dictionary<string, Dictionary<string, string>>();
        public static string connectionString = "";
        internal static Dictionary<string, Dictionary<string, string>> GetCommonMultiLangResFromDB()
        {
            if(commonMultiLangInfo.Count > 0)
            {
                return commonMultiLangInfo;
            }

            if (!string.IsNullOrEmpty(connectionString))
            {
                try
                {
                    MySqlConnection conn = getNewConntection(connectionString);
                    conn.Open();

                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("select catalog, resource_id, resource_value from rc_multilang where catalog = 'common' and lang='CH'", conn);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            string catalog = reader.GetString(0);
                            string resid = reader.GetString(1);
                            string resvalue = reader.GetString(2);
                            if (!commonMultiLangInfo.ContainsKey(catalog))
                            {
                                commonMultiLangInfo.Add(catalog, new Dictionary<string, string>());
                            }

                            if (!commonMultiLangInfo[catalog].ContainsKey(resid))
                            {
                                commonMultiLangInfo[catalog].Add(resid, resvalue);
                            }
                        }
                        reader.Close();
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                finally { }
            }

            return commonMultiLangInfo;
        }

        private static MySqlConnection mySqlConnection = null;

        internal static MySqlConnection getNewConntection(string connectionString)
        {
            if(mySqlConnection == null)
            {
                mySqlConnection = new MySqlConnection(connectionString);
            }
            return mySqlConnection;
        }

        public static List<Dictionary<string, string>> GetInsertDataDetail(DataTable designData)
        {
            List<Dictionary<string, string>> detail = new List<Dictionary<string, string>>();
            bool enterBlock = false;

            bool findProperty = false;
            int indexLine = -1;
            string[] headers = new string[designData.Columns.Count - 1];

            foreach (DataRow row in designData.Rows)
            {
                if (row[0].ToString().ToUpper().Equals(dataStartTag))
                {
                    enterBlock = true;
                }

                if (!enterBlock)
                {
                    continue;
                }

                if (row[0].ToString().ToUpper().Equals(dataEndTag))
                {
                    enterBlock = false;
                    break;
                }

                Dictionary<string, string> valueInfo = new Dictionary<string, string>();
                if (row[0].ToString().ToUpper().Equals("INITIAL DATA") && !findProperty)
                {
                    findProperty = true;
                    indexLine = 0;
                }

                if (findProperty)
                {
                    if (indexLine == 0)
                    {
                        for (int i = 1; i < designData.Columns.Count; i++)
                        {
                            headers[i - 1] = row[i].ToString().ToUpper();
                        }
                    }
                    else
                    {
                        for (int i = 1; i < designData.Columns.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(headers[i - 1]))
                            {
                                valueInfo.Add(headers[i - 1], row[i].ToString());
                            }
                        }

                        if ((valueInfo.ContainsKey("ID") && !string.IsNullOrEmpty(valueInfo["ID"])) || !valueInfo.ContainsKey("ID"))
                        {
                            detail.Add(valueInfo);
                        }
                    }

                    indexLine++;
                }

            }

            return detail;
        }


        internal static string GetItemValueByName(KeyValuePair<string, string> item)
        {
            if (item.Key.ToUpper().EndsWith("ID"))
            {
                return item.Value;
            }
            else if (item.Key.ToUpper().EndsWith("TIME"))
            {
                if (!string.IsNullOrEmpty(item.Value) && (item.Value.ToUpper().Contains("NOW()") || item.Value.ToUpper().Contains("SYSDATE()")))
                {
                    return "now()";
                }
                else
                {
                    return $"'{ExcelUtils.transferDateValue(item.Value)}'";
                }
            }
            else
            {
                return $"'{item.Value}'";
            }
        }


        internal static string GetSQLValue(string key, string value, Dictionary<string, string> fieldTypes)
        {
            if (fieldTypes.ContainsKey(key))
            {
                if (fieldTypes[key].ToUpper().Equals("BIGINT"))
                {
                    if (value.ToUpper().Equals("$AUTOSNOWFLAKE$"))
                    {
                        return Snowflake.Instance().GetId().ToString();
                    }
                    else
                    {
                        return string.IsNullOrEmpty(value) ? "null" : value;
                    }
                }
                else if (fieldTypes[key].ToUpper().StartsWith("INT") || fieldTypes[key].ToUpper().EndsWith("INT") || fieldTypes[key].ToUpper().Equals("DOUBLE") || fieldTypes[key].ToUpper().StartsWith("DECIMAL"))
                {
                    return string.IsNullOrEmpty(value) ? "null" : value;
                }
                else if (fieldTypes[key].ToUpper().StartsWith("VARCHAR") || fieldTypes[key].ToUpper().Equals("JSON") || fieldTypes[key].ToUpper().StartsWith("TEXT"))
                {
                    return $"'{value}'";
                }
                else if (fieldTypes[key].ToUpper().Equals("DATETIME"))
                {
                    if (!string.IsNullOrEmpty(value) && (value.ToUpper().Contains("NOW()") || value.ToUpper().Contains("SYSDATE()")))
                    {
                        return "now()";
                    }
                    else
                    {
                        return $"'{ExcelUtils.transferDateValue(value)}'";
                    }
                }
                else
                {
                    return "null";
                }
            }
            else
            {
                return "null";
            }
        }

        public static string GetJavaType(string dataType)
        {
            if (dataType.ToUpper().Equals("BIGINT"))
            {
                return "Long";
            }
            else if (dataType.ToUpper().Equals("TINYINT"))
            {
                return "Byte";
            }
            else if (dataType.ToUpper().StartsWith("VARCHAR") || dataType.ToUpper().Equals("JSON") || dataType.ToUpper().StartsWith("TEXT"))
            {
                return "String";
            }
            else if (dataType.ToUpper().Equals("DATETIME"))
            {
                return "Date";
            }
            else if (dataType.ToUpper().StartsWith("INT") || dataType.ToUpper().EndsWith("INT"))
            {
                return "Integer";
            }
            else if (dataType.ToUpper().StartsWith("DOUBLE") || dataType.ToUpper().Equals("DECIMAL"))
            {
                return "BigDecimal";
            }
            else { return ""; }
        }


        public static string GetPropertySetMethod(string propName)
        {
            return "set" + propName.Substring(0, 1).ToUpper() + propName.Substring(1);
        }

        public static string GetPropertyGetMethod(string propName)
        {
            return "get" + propName.Substring(0, 1).ToUpper() + propName.Substring(1);
        }

        public static string GetGetMethod(string propertyName)
        {
            return "get" + propertyName.Substring(0, 1).ToUpper() + propertyName.Substring(1);
        }

        public static string GetSQLDefaultTag(string defaultValue, string notNull)
        {
            if (string.IsNullOrEmpty(notNull) || notNull.ToUpper().Equals("Y"))
            {
                if (!string.IsNullOrEmpty(defaultValue))
                {
                    return "DEFAULT '" + defaultValue + "'";
                }
                else
                {
                    return "DEFAULT NULL";
                }
            }
            else
            {
                return "NOT NULL";
            }
        }

        public static string GetSQLCharacterTag(string dataType)
        {
            if (dataType.ToUpper().Equals("VARCHAR"))
            {
                return "CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci";
            }
            else
            {
                return "";
            }
        }

        public static string GetSQLDataType(string dataType, string length)
        {
            if (dataType.ToUpper().Equals("BIGINT"))
            {
                return "bigint";
            }
            else if (dataType.ToUpper().Equals("TINYINT"))
            {
                return "tinyint";
            }
            else if (dataType.ToUpper().StartsWith("INT"))
            {
                return "int";
            }
            else if (dataType.ToUpper().StartsWith("DOUBLE"))
            {
                return "double";
            }
            else if (dataType.ToUpper().Equals("DECIMAL"))
            {
                return "double";
            }
            else if (dataType.ToUpper().StartsWith("VARCHAR"))
            {
                return "varchar(" + length + ")";
            }
            else if (dataType.ToUpper().Equals("DATETIME"))
            {
                return "datetime";
            }
            else if (dataType.ToUpper().Equals("JSON"))
            {
                return "json";
            }
            else if (dataType.ToUpper().StartsWith("TEXT"))
            {
                return "text";
            }
            else { return ""; }
        }

        public static string GetJDBCType(string dataType)
        {
            if (dataType.ToUpper().Equals("BIGINT"))
            {
                return "BIGINT";
            }
            else if (dataType.ToUpper().Equals("TINYINT"))
            {
                return "TINYINT";
            }
            else if (dataType.ToUpper().StartsWith("INT"))
            {
                return "INTEGER";
            }
            else if (dataType.ToUpper().StartsWith("VARCHAR") || dataType.ToUpper().Equals("JSON") || dataType.ToUpper().StartsWith("TEXT"))
            {
                return "VARCHAR";
            }
            else if (dataType.ToUpper().Equals("DATETIME"))
            {
                return "VARCHAR";
            }
            else if (dataType.ToUpper().StartsWith("DOUBLE"))
            {
                return "DOUBLE";
            }
            else if (dataType.ToUpper().Equals("DECIMAL"))
            {
                return "DOUBLE";
            }

            else { return ""; }
        }

        public static void ApplyFixedDefines(DataTable table, StringBuilder sb, Dictionary<string, string> defRefs)
        {
            //$CLASSROOT$
            ReplaceTag(table, sb, "$CLASSROOT$", "CLASSROOT", "", "", defRefs);

            //$ENTITYDESC$
            ReplaceTag(table, sb, "$ENTITYDESC$", "ENTITYDESC", "", "", defRefs);

            //$ENTITYNAME$
            ReplaceTag(table, sb, "$ENTITYNAME$", "ENTITYNAME", "", "", defRefs);

            //$ENTITYNAME_LOWER$
            ReplaceTag(table, sb, "$ENTITYNAME_LOWER$", "ENTITYNAME", "", "", defRefs);

            //$ENTITYNAME_UPPER$
            ReplaceTag(table, sb, "$ENTITYNAME_UPPER$", "ENTITYNAME", "", "", defRefs);

            //$LOWER_ENTITYNAME$
            ReplaceTag(table, sb, "$LOWER_ENTITYNAME$", "ENTITYNAME", "", "", defRefs);

            //$UPPER_ENTITYNAME$
            ReplaceTag(table, sb, "$UPPER_ENTITYNAME$", "ENTITYNAME", "", "", defRefs);

            //$MULTILANGRESCATALOG$
            ReplaceTag(table, sb, "$MULTILANGRESCATALOG$", "ENTITYNAME", "", "", defRefs);
            
            //$TABLENAME$
            ReplaceTag(table, sb, "$TABLENAME$", "TABLENAME", "", "", defRefs);

            //$DATABASENAME$
            ReplaceTag(table, sb, "$DATABASENAME$", "DATABASENAME", "", "", defRefs);

            //$PARENT$
            ReplaceTag(table, sb, "$PARENTCLASS$", "PARENTCLASS", " extends ", "", defRefs);

            //$INTERFACES$
            ReplaceTag(table, sb, "$INTERFACES$", "INTERFACES", " implements ", "", defRefs);

            //$MULTILANGBASECLASS$
            ReplaceTag(table, sb, "$MULTILANGBASECLASS$", "MULTILANGBASECLASS", "", "", defRefs);
        }

        public static void RegisterMultiLangRefInfo(Dictionary<string, Dictionary<string, string[]>> baseInfo, Dictionary<string, Dictionary<string, string[]>> multiLangRefInfo)
        {
            if (multiLangRefInfo != null && multiLangRefInfo.Count > 0)
            {
                foreach (KeyValuePair<string, Dictionary<string, string[]>> keyvalue in multiLangRefInfo)
                {
                    if (!baseInfo.ContainsKey(keyvalue.Key))
                    {
                        baseInfo.Add(keyvalue.Key, new Dictionary<string, string[]>());
                    }

                    foreach(KeyValuePair<string, string[]> innerkeyvalue in keyvalue.Value)
                    {
                        if (!baseInfo[keyvalue.Key].ContainsKey(innerkeyvalue.Key))
                        {
                            baseInfo[keyvalue.Key].Add(innerkeyvalue.Key, new string[3]);
                        }

                        baseInfo[keyvalue.Key][innerkeyvalue.Key] = innerkeyvalue.Value;
                    }
                }
            }
        }

        public static void ReplaceTag(DataTable table, StringBuilder sb, string templateTag, string excelTag, string prefix, string suffix, Dictionary<string, string> defRefs)
        {
            string tagValue = GetItemDefine(table, excelTag, defRefs);
            string seed = replaceSeed(prefix, suffix, tagValue, templateTag);
            if (templateTag.Contains("$MULTILANGRESCATALOG$"))
            {
                string itemResCatalog = "meta_" + TemplateUtils.replaceSeed("", "", tagValue, "$ENTITYNAME_LOWER$");
                sb.Replace(templateTag, itemResCatalog);
            }
            else
            {
                sb.Replace(templateTag, (string.IsNullOrEmpty(tagValue) ? "" : seed));
            }
        }

        public static string replaceSeed(string prefix, string suffix, string tagValue, string seed)
        {
            if (seed.Trim().StartsWith("$UPPER_"))
            {
                tagValue = string.IsNullOrEmpty(tagValue) ? "" : $"{tagValue.Substring(0, 1).ToUpper()}{tagValue.Substring(1)}";
            }
            else if (seed.Trim().StartsWith("$LOWER_"))
            {
                tagValue = string.IsNullOrEmpty(tagValue) ? "" : $"{tagValue.Substring(0, 1).ToLower()}{tagValue.Substring(1)}";
            }

            if (seed.Trim().EndsWith("_LOWER$"))
            {
                tagValue = $"{prefix.ToLower()}{tagValue.ToLower()}{suffix.ToLower()}";
            }
            else if (seed.Trim().EndsWith("_UPPER$"))
            {
                tagValue = $"{prefix.ToUpper()}{tagValue.ToUpper()}{suffix.ToUpper()}";
            }
            else
            {
                tagValue = $"{prefix}{tagValue}{suffix}";
            }

            return tagValue;
        }

        public static void ApplyMiscDefines(string author, StringBuilder sb)
        {
            //$AUTHOR$
            sb.Replace("$AUTHOR$", author);
            //$DATE$
            sb.Replace("$DATE$", DateTime.Now.ToString("yyyy-MM-dd"));
        }

        internal static string GetSavedPath(string basePath, string spaceName)
        {
            string savedPath = string.Empty;
            if (!basePath.EndsWith("\\"))
            {
                savedPath = $"{basePath}\\";
            }

            savedPath += string.IsNullOrEmpty(spaceName) ? "" : spaceName.Replace(".", "\\");
            return savedPath;
        }

        /// <summary>
        /// 是否多语项目
        /// </summary>
        /// <param name="item">元定义项目</param>
        /// <returns></returns>
        public static bool IsMultiLangItem(Dictionary<string, string> item)
        {
            return item.ContainsKey("VO DATA TYPE") && item["VO DATA TYPE"].Equals("MultiLangVO[]");
        }

        /// <summary>
        /// 是否业务主键项目
        /// </summary>
        /// <param name="item">元定义项目</param>
        /// <returns></returns>
        public static bool IsBizKeyItem(Dictionary<string, string> item)
        {
            return item.ContainsKey("BIZ KEY") && item["BIZ KEY"].Equals("Y");
        }

        /// <summary>
        /// 是否主键项目
        /// </summary>
        /// <param name="item">元定义项目</param>
        /// <returns></returns>
        public static bool IsPrimaryKeyItem(Dictionary<string, string> item)
        {
            return item.ContainsKey("PRIMARY KEY") && item["PRIMARY KEY"].Equals("Y");
        }

        /// <summary>
        /// 是否聚合项目
        /// </summary>
        /// <param name="item">元定义项目</param>
        /// <returns></returns>
        public static bool IsAggVOItem(Dictionary<string, string> item)
        {
            return item.ContainsKey("DATA TYPE") && item["DATA TYPE"].Equals("AggVO");
        }

        public static string GetItemDefine(DataTable table, string itemTag, Dictionary<string, string> defRefs)
        {
            string itemDefine = string.Empty;

            if (defRefs != null && defRefs.ContainsKey(itemTag))
            {
                itemDefine = defRefs[itemTag];
            }
            else
            {
                foreach (DataRow row in table.Rows)
                {
                    if (string.IsNullOrEmpty(itemDefine))
                    {
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            if (row[i].ToString().ToUpper() == itemTag)
                            {
                                itemDefine = row[i + 1].ToString();
                                break;
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(itemDefine))
                    {
                        break;
                    }
                }
            }

            return itemDefine;
        }
    }
}
