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
            Entity = 0, SqlProvider = 1, Mapper = 2, MapperExtend = 3, CreateTable = 4, InsertData = 5, MultiLanguage = 6, VO = 7,
            MultiLangEntity = 60, MultiLangSqlProvider = 61, MultiLangMapper = 62, MultiLangMapperExtend = 63, MultiLangCreateTable = 64, MultiLangInsertData = 65
        }

        public static string templateApply(DataTable dt, string templateText, string author, bool isMeta, bool isMultiLang, Dictionary<String, String> defRefs, bool isVO)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(templateText);
            applySwitches(dt, sb, isMeta, isMultiLang);
            applyFixedDefines(dt, sb, defRefs);
            applyMiscDefines(author, sb);
            applySetDefines(dt, sb, isMeta, isMultiLang, defRefs, isVO);
            return sb.ToString();
        }

        private static void applySwitches(DataTable dt, StringBuilder sb, bool isMeta, bool isMultiLang)
        {
            if (isMeta)
            {
                if (getMetaDetailByDefinedLines(dt, isMultiLang).Count == 0)
                {
                    throw new Exception("No file to generated.");
                }
            }
            else
            {
                if (getDataDetailByDefinedLines(dt, isMultiLang).Count == 0)
                {
                    throw new Exception("No file to generated.");
                }
            }
        }

        private static void applySetDefines(DataTable table, StringBuilder sb, bool isMeta, bool isMultiLang, Dictionary<String, String> defRefs, bool isVO)
        {
            //$HASMULTILANGPROPERTY
            replaceSetTag(table, sb, "$HASMULTILANGPROPERTY$", isMeta, true, isVO);

            //$FOREACH PROPERTY$
            replaceSetTag(table, sb, "$FOREACH PROPERTY$", isMeta, isMultiLang, isVO);

            //$FOREACH PROPERTY EXCEPT PK$
            replaceSetTag(table, sb, "$FOREACH PROPERTY EXCEPT PK$", isMeta, isMultiLang, isVO);

            //$FOREACH MULTILANG PROPERTY$
            replaceSetTag(table, sb, "$FOREACH MULTILANG PROPERTY$", isMeta, isMultiLang, isVO);

            //$FOREACH FIELD
            replaceSetTag(table, sb, "$FOREACH FIELD$", isMeta, isMultiLang, isVO);

            //$FOREACH FIELD EXCEPT PK$
            replaceSetTag(table, sb, "$FOREACH FIELD EXCEPT PK$", isMeta, isMultiLang, isVO);

            //$FOREACH MULTILANG PROPERTY$
            replaceSetTag(table, sb, "$FOREACH MULTILANG FIELD$", isMeta, isMultiLang, isVO);

            //$FOREACH VO
            replaceSetTag(table, sb, "$FOREACH VO$", isMeta, isMultiLang, isVO);

            //$FOREACH MULTILANG VO
            replaceSetTag(table, sb, "$FOREACH MULTILANG VO$", isMeta, true, isVO);

            //$INSERTDATASET$
            replaceInsertData(table, sb, "$INSERTDATASET$", isMultiLang, defRefs);

            //$INSERTMULTILANGDATASET$
            replaceInsertData(table, sb, "$INSERTMULTILANGDATASET$", isMultiLang, defRefs);
        }

        private static void replaceInsertData(DataTable table, StringBuilder sb, string tag, bool isMultiLang, Dictionary<String, String> defRefs)
        {
            if (tag.Equals("$INSERTDATASET$") || tag.Equals("$INSERTMULTILANGDATASET$"))
            {
                StringBuilder resultSQL = new StringBuilder();
                List<Dictionary<string, string>> metaDetail = getMetaDetailByDefinedLines(table, isMultiLang);
                List<Dictionary<string, string>> dataDetail = getDataDetailByDefinedLines(table, isMultiLang);

                Dictionary<string, string> fieldTypes = new Dictionary<string, string>();
                foreach (Dictionary<string, string> item in metaDetail)
                {
                    fieldTypes.Add(item["FIELD NAME"].ToUpper(), item["DATA TYPE"]);
                }

                if (dataDetail.Count > 0)
                {
                    SnowFlakeWorker sf = new SnowFlakeWorker(dataDetail.Count);

                    StringBuilder insertSQL = new StringBuilder();
                    int lineNo = 0;
                    foreach (Dictionary<string, string> data in dataDetail)
                    {
                        if (lineNo == 0)
                        {
                            insertSQL.Append("INSERT INTO ");
                            insertSQL.Append(getItemDefine(table, "TABLENAME", defRefs) + (isMultiLang ? "_res" : ""));

                            int colNo = 0;
                            string fields = "(";
                            foreach (KeyValuePair<string, string> item in data)
                            {
                                colNo++;
                                fields += item.Key + (colNo == data.Count ? "" : ",");
                            }
                            fields += ")";
                            insertSQL.Append(fields);
                            lineNo++;
                        }

                        int col = 0;
                        StringBuilder valueSQL = new StringBuilder();
                        valueSQL.Append(" VALUES ");
                        string values = "(";
                        foreach (KeyValuePair<string, string> item in data)
                        {
                            col++;
                            values += (isMultiLang ? getItemValueByName(item) : getSQLValue(item.Key, item.Value, fieldTypes, sf)) + (col == data.Count ? "" : ",");
                        }
                        values += ")";
                        valueSQL.Append(values);
                        valueSQL.Append(";\r\n");

                        resultSQL.Append(insertSQL);
                        resultSQL.Append(valueSQL);
                    }
                }

                sb.Replace("$INSERTDATASET$", resultSQL.ToString()).Replace("$INSERTMULTILANGDATASET$", resultSQL.ToString());
            }
        }

        private static string getItemValueByName(KeyValuePair<string, string> item)
        {
            if (item.Key.ToUpper().EndsWith("ID"))
            {
                return item.Value;
            }
            else if (item.Key.ToUpper().EndsWith("TIME"))
            {
                return "'" + ExcelUtils.transferDateValue(item.Value) + "'";
            }
            else
            {
                return "'" + item.Value + "'";
            }
        }

        private static List<Dictionary<string, string>> getDataDetailByDefinedLines(DataTable table, bool isMultiLang)
        {
            String blockStartTag = isMultiLang ? "$MYBATIS MULTILANG DATA START$" : "$MYBATIS DATA START$";
            String blockEndTag = isMultiLang ? "$MYBATIS MULTILANG DATA END$" : "$MYBATIS DATA END$";

            bool enterBlock = false;
            bool findProperty = false;
            int indexLine = -1;

            List<Dictionary<string, string>> detail = new List<Dictionary<string, string>>();
            string[] headers = null;
            foreach (DataRow row in table.Rows)
            {
                Dictionary<string, string> valueInfo = new Dictionary<string, string>();

                if (row[0].ToString().ToUpper().Equals(blockStartTag))
                {
                    enterBlock = true;
                }

                if (!enterBlock)
                {
                    continue;
                }

                if (row[0].ToString().ToUpper().Equals(blockEndTag))
                {
                    enterBlock = false;
                    break;
                }

                if (!String.IsNullOrEmpty(row[0].ToString()) && row[0].ToString().ToUpper().Equals("INITIAL DATA") && !findProperty)
                {
                    findProperty = true;
                    indexLine = 0;
                }

                if (findProperty)
                {
                    if (indexLine == 0)
                    {
                        int headerCount = 0;
                        for (int i = 1; i < table.Columns.Count; i++)
                        {
                            if (!String.IsNullOrEmpty(row[i].ToString()))
                            {
                                headerCount++;
                            }
                        }

                        if (headerCount > 0)
                        {
                            headers = new string[headerCount];
                            for (int i = 1; i <= headers.Length; i++)
                            {
                                headers[i - 1] = row[i].ToString().ToUpper();
                            }
                        }
                    }
                    else
                    {
                        if (headers != null && headers.Length > 0)
                        {
                            for (int i = 1; i <= headers.Length; i++)
                            {
                                valueInfo.Add(headers[i - 1], row[i].ToString());
                            }

                            if (!string.IsNullOrEmpty(valueInfo["ID"]))
                            {
                                detail.Add(valueInfo);
                            }
                        }
                    }

                    indexLine++;
                }
            }

            return detail;
        }

        private static string getSQLValue(string key, string value, Dictionary<string, string> fieldTypes, SnowFlakeWorker sf)
        {
            if (fieldTypes[key].ToUpper().Equals("BIGINT"))
            {
                if (value.ToUpper().Equals("$AUTOSNOWFLAKE$"))
                {
                    return sf.nextId().ToString();
                }
                else
                {
                    return value;
                }
            }
            else if (fieldTypes[key].ToUpper().StartsWith("INT") || fieldTypes[key].ToUpper().EndsWith("INT") || fieldTypes[key].ToUpper().Equals("DOUBLE") || fieldTypes[key].ToUpper().StartsWith("DECIMAL"))
            {
                return value;
            }
            else if (fieldTypes[key].ToUpper().StartsWith("VARCHAR") || fieldTypes[key].ToUpper().Equals("JSON") || fieldTypes[key].ToUpper().StartsWith("TEXT"))
            {
                return "'" + value + "'";
            }
            else if (fieldTypes[key].ToUpper().Equals("DATETIME"))
            {
                return "'" + ExcelUtils.transferDateValue(value) + "'";
            }
            else { return ""; }
        }

        private static void replaceSetTag(DataTable table, StringBuilder sb, string tag, bool isMeta, bool isMultiLang, bool isVO)
        {
            string beginTag = tag.Trim().Insert(tag.LastIndexOf("$"), " BEGIN");
            string endTag = tag.Trim().Insert(tag.LastIndexOf("$"), " END");

            while (sb.ToString().Contains(beginTag))
            {
                int blockStartIndex = sb.ToString().IndexOf(beginTag);
                int blockEndIndex = sb.ToString().IndexOf(endTag) + endTag.Length;
                string block = sb.ToString().Substring(blockStartIndex, blockEndIndex - blockStartIndex);

                int seedStartIndex = blockStartIndex + beginTag.Length;
                int seedEndIndex = blockEndIndex - endTag.Length - 1;
                string seed = sb.ToString().Substring(seedStartIndex, seedEndIndex - seedStartIndex);

                bool exceptPK = tag.ToUpper().Contains("EXCEPT PK");

                List<Dictionary<string, string>> metaDetail = getMetaDetailByDefinedLines(table, isMultiLang);
                List<Dictionary<string, string>> dataDetail = getDataDetailByDefinedLines(table, isMultiLang);
                Dictionary<string, string> pkFieldInfo = getPKFieldInfo(table);

                List<Dictionary<string, string>> detail = isMeta ? metaDetail : dataDetail;
                StringBuilder tempSB = new StringBuilder();

                if (!tag.Equals("$HASMULTILANGPROPERTY$"))
                {
                    if (isMultiLang)
                    {
                        if (!isVO && detail.Count == 0)
                        {
                            throw new Exception("No file to generated.");
                        }
                    }
                    else
                    {
                        if (pkFieldInfo == null)
                        {
                            throw new Exception("PK field not defined");
                        }
                    }

                    if (pkFieldInfo.Count > 0)
                    {
                        sb.Replace("$PKFIELDNAME$", pkFieldInfo["FIELD NAME"]);
                        sb.Replace("$PKPROPERTYNAME$", pkFieldInfo["PROPERTY NAME"]);
                        sb.Replace("$PKFIELDDATATYPE$", getJDBCType(pkFieldInfo["DATA TYPE"]));
                        sb.Replace("$PKFIELDJAVATYPE$", getJavaType(pkFieldInfo["DATA TYPE"]));
                        sb.Replace("$PKGETMETHOD$", getPropertyGetMethod(pkFieldInfo["PROPERTY NAME"]));
                    }

                    if (isMeta)
                    {
                        applyMetaSetTags(tag, seed, exceptPK, metaDetail, tempSB);
                    }
                    else
                    {
                        applyDataSetTags(tag, seed, exceptPK, dataDetail, metaDetail, tempSB);
                    }
                }
                else
                {
                    if (isMeta && isMultiLang && detail.Count == 0)
                    {
                        tempSB.Clear();
                    }
                    else
                    {
                        tempSB.Append(seed);
                    }
                }

                sb.Replace(block, tempSB.ToString());
            }
        }

        private static void applyDataSetTags(string tag, string seed, bool exceptPK, List<Dictionary<string, string>> dataDetail, List<Dictionary<string, string>> defineDetail, StringBuilder tempSB)
        {
            int index = 0;
            foreach (Dictionary<string, string> dataRow in dataDetail)
            {
                index++;
                tempSB.Append(seed);

                foreach (KeyValuePair<string, string> cell in dataRow)
                {
                    //`$FIELDNAME$` $FIELDDATATYPE$ $CHARACTERTAG$ $DEFAULTTAG$ COMMENT '$PROPERTYDESC$',
                    string fieldName = cell.Key;
                    Dictionary<string, string> itemDefine = getFieldDefine(defineDetail, fieldName);
                    if(itemDefine != null)
                    {
                        tempSB.Append(seed);
                        replaceMetaSetItem(dataDetail, tempSB, index, itemDefine);
                    }
                }
            }
        }

        private static Dictionary<string, string> getFieldDefine(List<Dictionary<string, string>> defineDetail, string fieldName)
        {
            foreach (Dictionary<string, string> item in defineDetail)
            {
                if (item["FIELD NAME"].Equals(fieldName))
                {
                    return item;
                }
            }

            return null;
        }

        private static void applyMetaSetTags(string tag, string seed, bool exceptPK, List<Dictionary<string, string>> dataDetail, StringBuilder tempSB)
        {
            int index = 0;
            foreach (Dictionary<string, string> item in dataDetail)
            {
                index++;
                if (tag.Contains("VO"))
                {
                    if(tag.Contains(" MULTILANG "))
                    {
                        if (item["DATA TYPE"].ToUpper().EndsWith("_ML"))
                        {
                            tempSB.Append(seed);
                            replaceMetaSetItem(dataDetail, tempSB, index, item);
                        }
                    }
                    else
                    {
                         if (!item["DATA TYPE"].ToUpper().EndsWith("_ML"))
                        {
                            tempSB.Append(seed);
                            replaceMetaSetItem(dataDetail, tempSB, index, item);
                        }
                    }
                }
                else if (tag.Contains("PROPERTY"))
                {
                    if (item.ContainsKey("PRIMARY KEY") && item.ContainsKey("GENERATE FIELD"))
                    {
                        if (exceptPK && item["PRIMARY KEY"].ToUpper().Equals("Y") ||
                        item["GENERATE PROPERTY"].ToUpper().Equals("N"))
                        {
                            continue;
                        }
                        else
                        {
                            tempSB.Append(seed);
                            replaceMetaSetItem(dataDetail, tempSB, index, item);

                        }
                    }
                }
                else if (tag.Contains("FIELD"))
                {
                    if (item.ContainsKey("PRIMARY KEY") && item.ContainsKey("GENERATE FIELD"))
                    {
                        if (exceptPK && item["PRIMARY KEY"].ToUpper().Equals("Y") ||
                            item["GENERATE FIELD"].ToUpper().Equals("N"))
                        {
                            continue;
                        }
                        else
                        {
                            tempSB.Append(seed);
                            replaceMetaSetItem(dataDetail, tempSB, index, item);
                        }
                    }
                }

                    if (item.ContainsKey("PRIMARY KEY") && item["PRIMARY KEY"].ToUpper().Equals("Y"))
                    {
                        tempSB.Replace("$IDRESULTTAG$", ",id=true");
                    }
                    else
                    {
                        tempSB.Replace("$IDRESULTTAG$", "");
                    }
            }
        }

        private static string getJavaType(string dataType)
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
                return "Double";
            }
            else { return ""; }
        }

        private static void replaceMetaSetItem(List<Dictionary<string, string>> detail, StringBuilder tempSB, int index, Dictionary<string, string> item)
        {
            tempSB.Replace("$FIELDNAME$", item["FIELD NAME"]);
            tempSB.Replace("$COMMAEXCEPTLAST$", index == detail.Count ? "" : ","); 
            tempSB.Replace("$PROPERTYNAME$", item["PROPERTY NAME"]);
            tempSB.Replace("$PROPERTYDATATYPE$", getJDBCType(item["DATA TYPE"]));
            tempSB.Replace("$PROPERTYJAVATYPE$", getJavaType(item["DATA TYPE"]));
            tempSB.Replace("$PROPERTYVODATATYPE$", item["VO DATA TYPE"]);
            tempSB.Replace("$PROPERTYGETMETHOD$", getPropertyGetMethod(item["PROPERTY NAME"]));
            tempSB.Replace("$PROPERTYSETMETHOD$", getPropertySetMethod(item["PROPERTY NAME"]));
            tempSB.Replace("$PROPERTYDESC$", item["DESCIPTION"]);
            tempSB.Replace("$FIELDDATATYPE$", getSQLDataType(item["DATA TYPE"], item["FIELD LENGTH"]));
            tempSB.Replace("$CHARACTERTAG$", getSQLCharacterTag(item["DATA TYPE"]));
            tempSB.Replace("$DEFAULTTAG$", getSQLDefaultTag(item["DEFAULT VALUE"], item["CAN BE NULL"]));
            tempSB.Replace("$PROPERTYGETMETHOD$", getGetMethod(item["PROPERTY NAME"]));
        }

        private static string getPropertySetMethod(string propName)
        {
            return "set" + propName.Substring(0, 1).ToUpper() + propName.Substring(1);
        }

        private static string getPropertyGetMethod(string propName)
        {
            return "get" + propName.Substring(0, 1).ToUpper() + propName.Substring(1);
        }

        private static string getGetMethod(string propertyName)
        {
            return "get" + propertyName.Substring(0, 1).ToUpper() + propertyName.Substring(1);
        }

        private static string getSQLDefaultTag(string defaultValue, string notNull)
        {
            if(string.IsNullOrEmpty(notNull) || notNull.ToUpper().Equals("Y")) { 
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

        private static string getSQLCharacterTag(string dataType)
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

        private static string getSQLDataType(string dataType, string length)
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
                return "decimal";
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
            }else if (dataType.ToUpper().StartsWith("TEXT"))
            {
                return "text";
            }
            else { return ""; }
        }

        private static string getJDBCType(string dataType)
        {
            if (dataType.ToUpper().Equals("BIGINT"))
            {
                return "JdbcType.BIGINT";
            }
            else if (dataType.ToUpper().Equals("TINYINT"))
            {
                return "JdbcType.TINYINT";
            }
            else if (dataType.ToUpper().StartsWith("INT"))
            {
                return "JdbcType.INTEGER";
            }
            else if (dataType.ToUpper().StartsWith("VARCHAR") || dataType.ToUpper().Equals("JSON") || dataType.ToUpper().StartsWith("TEXT"))
            {
                return "JdbcType.VARCHAR";
            }
            else if (dataType.ToUpper().Equals("DATETIME"))
            {
                return "JdbcType.TIMESTAMP";
            }
            else if (dataType.ToUpper().StartsWith("DOUBLE"))
            {
                return "JdbcType.DOUBLE";
            }
            else if (dataType.ToUpper().Equals("DECIMAL"))
            {
                return "JdbcType.DECIMAL";
            }

            else { return ""; }
        }

        private static Dictionary<string, string> getPKFieldInfo(DataTable table)
        {
            Dictionary<string, string> valueInfo = new Dictionary<string, string>();

            String blockStartTag = "$MYBATIS META DESIGN START$";
            String blockEndTag = "$MYBATIS META DESIGN END$";

            bool enterBlock = false;

            bool findProperty = false;
            int indexLine = -1;
            string[] headers = new string[table.Columns.Count - 1];

            foreach (DataRow row in table.Rows)
            {
                Dictionary<string, string> tmpInfo = new Dictionary<string, string>();

                if (row[0].ToString().ToUpper().Equals(blockStartTag))
                {
                    enterBlock = true;
                }

                if (!enterBlock)
                {
                    continue;
                }

                if (row[0].ToString().ToUpper().Equals(blockEndTag))
                {
                    enterBlock = false;
                    break;
                }

                if (row[0].ToString().ToUpper().Equals("PROPERTIES") && !findProperty)
                {
                    findProperty = true;
                    indexLine = 0;
                }

                if (findProperty)
                {
                    if (indexLine == 0)
                    {
                        for (int i = 1; i < table.Columns.Count; i++)
                        {
                            headers[i - 1] = row[i].ToString().ToUpper();
                        }
                    }
                    else
                    {
                        for (int i = 1; i < table.Columns.Count; i++)
                        {
                            tmpInfo.Add(headers[i - 1], row[i].ToString());
                        }

                        if(tmpInfo["PRIMARY KEY"].ToString().ToUpper().EndsWith("Y"))
                        {
                            valueInfo = tmpInfo;
                            break;
                        }

                    }

                    indexLine++;
                }

            }

            return valueInfo;
        }

        private static List<Dictionary<string, string>> getMetaDetailByDefinedLines(DataTable table, bool isMultiLang)
        {
            List<Dictionary<string, string>> detail = new List<Dictionary<string, string>>();

            String blockStartTag = "$MYBATIS META DESIGN START$";
            String blockEndTag = "$MYBATIS META DESIGN END$";

            bool enterBlock = false;

            bool findProperty = false;
            int indexLine = -1;
            string[] headers = new string[table.Columns.Count - 1];

            foreach (DataRow row in table.Rows)
            {
                if (row[0].ToString().ToUpper().Equals(blockStartTag))
                {
                    enterBlock = true;
                }

                if (!enterBlock)
                {
                    continue;
                }

                if (row[0].ToString().ToUpper().Equals(blockEndTag))
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
                        for (int i = 1; i < table.Columns.Count; i++)
                        {
                            headers[i - 1] = row[i].ToString().ToUpper();
                        }
                    }
                    else
                    {
                        for (int i = 1; i < table.Columns.Count; i++)
                        {
                            valueInfo.Add(headers[i - 1], row[i].ToString());
                        }

                        if (!string.IsNullOrEmpty(valueInfo["PROPERTY NAME"]))
                        {
                            if (isMultiLang && valueInfo["DATA TYPE"].ToString().ToUpper().EndsWith("_ML"))
                            {
                                detail.Add(valueInfo);
                            }
                            else if (!isMultiLang && !valueInfo["DATA TYPE"].ToString().ToUpper().EndsWith("_ML"))
                            {
                                detail.Add(valueInfo);
                            }
                        }
                    }

                    indexLine++;
                }

            }

            return detail;
        }

        private static void applyFixedDefines(DataTable table, StringBuilder sb, Dictionary<String, String> defRefs)
        {
            //$ENTITYNAMESPACE$
            replaceTag(table, sb, "$ENTITYNAMESPACE$", "ENTITYNAMESPACE", "", "", defRefs);

            //$MAPPERNAMESPACE$
            replaceTag(table, sb, "$MAPPERNAMESPACE$", "MAPPERNAMESPACE", "", "", defRefs);

            //$SQLPROVIDERNAMESPACE$
            replaceTag(table, sb, "$SQLPROVIDERNAMESPACE$", "SQLPROVIDERNAMESPACE", "", "", defRefs);

            //$VONAMESPACE$
            replaceTag(table, sb, "$VONAMESPACE$", "VONAMESPACE", "", "", defRefs);

            //$ENTITYDESC$
            replaceTag(table, sb, "$ENTITYDESC$", "ENTITYDESC", "", "", defRefs);

            //$ENTITYNAME$
            replaceTag(table, sb, "$ENTITYNAME$", "ENTITYNAME", "", "", defRefs);

            //$TABLENAME$
            replaceTag(table, sb, "$TABLENAME$", "TABLENAME", "", "", defRefs);

            //$PARENT$
            replaceTag(table, sb, "$PARENT$", "PARENTCLASS", " extends ", "", defRefs);

            //$INTERFACES$
            replaceTag(table, sb, "$INTERFACES$", "INTERFACES", " implements ", "", defRefs);

            //$MULTILANGBASECLASS$
            replaceTag(table, sb, "$MULTILANGBASECLASS$", "MULTILANGBASECLASS", "", "", defRefs);
        }

        private static void replaceTag(DataTable table, StringBuilder sb, string templateTag, string excelTag, string prefix, string suffix, Dictionary<String, String> defRefs)
        {
            string tag = getItemDefine(table, excelTag, defRefs);
            sb.Replace(templateTag, (string.IsNullOrEmpty(tag) ? "" : prefix + tag + suffix));
        }

        private static void applyMiscDefines(string author, StringBuilder sb)
        {
            //$AUTHOR$
            sb.Replace("$AUTHOR$", author);
            //$DATE$
            sb.Replace("$DATE$", DateTime.Now.ToString("yyyy-MM-dd")) ;
        }

        internal static String getSavedPath(String basePath, String spaceName)
        {
            string savedPath = string.Empty;
            if (!basePath.EndsWith("\\"))
            {
                savedPath = basePath + "\\";
            }

            savedPath = savedPath + (string.IsNullOrEmpty(spaceName) ? "" : spaceName.Replace(".", "\\"));
            return savedPath;
        }

        public static string getItemDefine(DataTable table, string itemTag, Dictionary<String, String> defRefs)
        {
            string itemDefine = string.Empty;

            if (defRefs.ContainsKey(itemTag))
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
