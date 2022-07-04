using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator
{
    enum TemplateType
    {
        Entity, SqlProvider, Mapper, CreateTable, InsertData
    }

    public class TemplateUtils
    {
        public static string templateApply(DataTable dt, string templateText, string author)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(templateText);
            applyFixedDefines(dt, sb);
            applySetDefines(dt, sb);
            applyMiscDefines(author, sb);
            return sb.ToString();
        }

        private static void applySetDefines(DataTable table, StringBuilder sb)
        {
            //$FOREACH PROPERTY$
            replaceSetTag(table, sb, "$FOREACH PROPERTY$");

            //$FOREACH PROPERTY EXCEPT PK$
            replaceSetTag(table, sb, "$FOREACH PROPERTY EXCEPT PK$");

            //$FOREACH FIELD
            replaceSetTag(table, sb, "$FOREACH FIELD$");

            //$FOREACH FIELD EXCEPT PK$
            replaceSetTag(table, sb, "$FOREACH FIELD EXCEPT PK$");

            //$INSERTDATASET$
            replaceInsertData(table, sb, "$INSERTDATASET$");
        }

        private static void replaceInsertData(DataTable table, StringBuilder sb, string tag)
        {
            if (tag.Equals("$INSERTDATASET$"))
            {
                StringBuilder resultSQL = new StringBuilder();
                List<Dictionary<string, string>> detail = getDetailByDefinedLines(table);
                List<Dictionary<string, string>> dataList = getDataListByDesign(table);

                Dictionary<string, string> fieldTypes = new Dictionary<string, string>();
                foreach (Dictionary<string, string> item in detail)
                {
                    fieldTypes.Add(item["FIELD NAME"].ToUpper(), item["DATA TYPE"]);
                }

                if (dataList.Count > 0)
                {
                    SnowFlakeWorker sf = new SnowFlakeWorker(dataList.Count);

                    StringBuilder insertSQL = new StringBuilder();
                    int lineNo = 0;
                    foreach (Dictionary<string, string> data in dataList)
                    {
                        if (lineNo == 0)
                        {
                            insertSQL.Append("INSERT INTO ");
                            insertSQL.Append(getItemDefine(table, "TABLENAME"));

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
                            values += getSQLValue(item.Key, item.Value, fieldTypes, sf) + (col == data.Count ? "" : ",");
                        }
                        values += ")";
                        valueSQL.Append(values);
                        valueSQL.Append(";\r\n");

                        resultSQL.Append(insertSQL);
                        resultSQL.Append(valueSQL);
                    }
                }

                sb.Replace("$INSERTDATASET$", resultSQL.ToString());
            }
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
            else if (fieldTypes[key].ToUpper().Equals("TINYINT"))
            {
                return value;
            }
            else if (fieldTypes[key].ToUpper().Equals("VARCHAR") || fieldTypes[key].ToUpper().Equals("JSON"))
            {
                return "'" + value + "'";
            }
            else if (fieldTypes[key].ToUpper().Equals("DATETIME"))
            {
                return "'" + ExcelUtils.transferDateValue(value) + "'";
            }
            else { return ""; }
        }

        private static void replaceSetTag(DataTable table, StringBuilder sb, string tag)
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

                List<Dictionary<string, string>> detail = getDetailByDefinedLines(table);
                Dictionary<string, string> pkFieldInfo = getPKFieldInfo(detail);

                if(pkFieldInfo == null)
                {
                    throw new Exception("PK field not defined");
                }

                StringBuilder tempSB = new StringBuilder();
                int index = 0;
                foreach (Dictionary<string, string> item in detail)
                {
                    index++;

                    if (tag.Contains("PROPERTY"))
                    {
                        if (exceptPK && item["PRIMARY KEY"].ToUpper().Equals("Y") ||
                            item["GENERATE PROPERTY"].ToUpper().Equals("N"))
                        {
                            continue;
                        }
                        else
                        {
                            tempSB.Append(seed);
                            replaceSetItem(detail, tempSB, index, item);

                        }
                    }
                    else if (tag.Contains("FIELD"))
                    {
                        if (exceptPK && item["PRIMARY KEY"].ToUpper().Equals("Y") ||
                            item["GENERATE FIELD"].ToUpper().Equals("N"))
                        {
                            continue;
                        }
                        else
                        {
                            tempSB.Append(seed);
                            replaceSetItem(detail, tempSB, index, item);
                        }
                    }

                    if (item["PRIMARY KEY"].ToUpper().Equals("Y"))
                    {
                        tempSB.Replace("$IDRESULTTAG$", ",id=true");
                    }
                    else
                    {
                        tempSB.Replace("$IDRESULTTAG$", "");
                    }
                }

                sb.Replace("$PKFIELDNAME$", pkFieldInfo["FIELD NAME"]);
                sb.Replace("$PKPROPERTYNAME$", pkFieldInfo["PROPERTY NAME"]);
                sb.Replace("$PKFIELDDATATYPE$", getJDBCType(pkFieldInfo["DATA TYPE"]));
                sb.Replace("$PKFIELDJAVATYPE$", getJavaType(pkFieldInfo["DATA TYPE"]));

                sb.Replace(block, tempSB.ToString());
            }
        }

        private static List<Dictionary<string, string>> getDataListByDesign(DataTable table)
        {
            List<Dictionary<string, string>> detail = new List<Dictionary<string, string>>();

            bool findProperty = false;
            int indexLine = -1;
            string[] headers = new string[table.Columns.Count - 1];

            foreach (DataRow row in table.Rows)
            {
                Dictionary<string, string> valueInfo = new Dictionary<string, string>();
                if (row[0].ToString().ToUpper().Equals("$MYBATIS DATA END$"))
                {
                    break;
                }

                if (row[0].ToString().ToUpper().Equals("INITIAL DATA") && !findProperty)
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
                            if (!string.IsNullOrEmpty(headers[i - 1]))
                            {
                                valueInfo.Add(headers[i - 1], row[i].ToString());
                            }
                        }

                        if (!string.IsNullOrEmpty(valueInfo[headers[0]]))
                        {
                            detail.Add(valueInfo);
                        }
                    }

                    indexLine++;
                }

            }

            return detail;
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
            else if (dataType.ToUpper().Equals("VARCHAR") || dataType.ToUpper().Equals("JSON"))
            {
                return "String";
            }
            else if (dataType.ToUpper().Equals("DATETIME"))
            {
                return "Date";
            }
            else { return ""; }
        }

        private static void replaceSetItem(List<Dictionary<string, string>> detail, StringBuilder tempSB, int index, Dictionary<string, string> item)
        {
            tempSB.Replace("$FIELDNAME$", item["FIELD NAME"]);
            tempSB.Replace("$COMMAEXCEPTLAST$", index == detail.Count ? "" : ","); 
            tempSB.Replace("$PROPERTYNAME$", item["PROPERTY NAME"]);
            tempSB.Replace("$PROPERTYDATATYPE$", getJDBCType(item["DATA TYPE"]));
            tempSB.Replace("$PROPERTYJAVATYPE$", getJavaType(item["DATA TYPE"]));
            tempSB.Replace("$PROPERTYDESC$", item["DESCIPTION"]);
            tempSB.Replace("$FIELDDATATYPE$", getSQLDataType(item["DATA TYPE"], item["FIELD LENGTH"]));
            tempSB.Replace("$CHARACTERTAG$", getSQLCharacterTag(item["DATA TYPE"]));
            tempSB.Replace("$DEFAULTTAG$", getSQLDefaultTag(item["DEFAULT VALUE"], item["CAN BE NULL"]));
            tempSB.Replace("$PROPERTYGETMETHOD$", getGetMethod(item["PROPERTY NAME"]));
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
            else if (dataType.ToUpper().Equals("VARCHAR"))
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
            else if (dataType.ToUpper().Equals("VARCHAR") || dataType.ToUpper().Equals("JSON"))
            {
                return "JdbcType.VARCHAR";
            }
            else if (dataType.ToUpper().Equals("DATETIME"))
            {
                return "JdbcType.TIMESTAMP";
            }
            else { return ""; }
        }

        private static Dictionary<string, string> getPKFieldInfo(List<Dictionary<string, string>> detail)
        {
            foreach (Dictionary<string, string> item in detail)
            {
                if (item["PRIMARY KEY"].ToUpper().Equals("Y") || item["PRIMARY KEY"].Equals("1") || item["PRIMARY KEY"].ToUpper().Equals("YES"))
                {
                    return item;
                }
            }

            return null;
        }

        private static List<Dictionary<string, string>> getDetailByDefinedLines(DataTable table)
        {
            List<Dictionary<string, string>> detail = new List<Dictionary<string, string>>();

            bool findProperty = false;
            int indexLine = -1;
            string[] headers = new string[table.Columns.Count - 1];

            foreach (DataRow row in table.Rows)
            {
                Dictionary<string, string> valueInfo = new Dictionary<string, string>();
                if (row[0].ToString().ToUpper().Equals("$MYBATIS META DESIGN END$"))
                {
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

        private static void applyFixedDefines(DataTable table, StringBuilder sb)
        {
            //$ENTITYNAMESPACE$
            replaceTag(table, sb, "$ENTITYNAMESPACE$", "ENTITYNAMESPACE", "", "");

            //$MAPPERNAMESPACE$
            replaceTag(table, sb, "$MAPPERNAMESPACE$", "MAPPERNAMESPACE", "", "");

            //$ENTITYDESC$
            replaceTag(table, sb, "$ENTITYDESC$", "ENTITYDESC", "", "");

            //$ENTITYNAME$
            replaceTag(table, sb, "$ENTITYNAME$", "ENTITYNAME", "", "");

            //$TABLENAME$
            replaceTag(table, sb, "$TABLENAME$", "TABLENAME", "", "");

            //$PARENT$
            replaceTag(table, sb, "$PARENT$", "PARENTCLASS", " extends ", "");

            //$INTERFACES$
            replaceTag(table, sb, "$INTERFACES$", "INTERFACES", " implements ", "");

        }

        private static void replaceTag(DataTable table, StringBuilder sb, string templateTag, string excelTag, string prefix, string suffix)
        {
            string tag = getItemDefine(table, excelTag);
            sb.Replace(templateTag, (string.IsNullOrEmpty(tag) ? "" : prefix + tag + suffix));
        }

        private static void applyMiscDefines(string author, StringBuilder sb)
        {
            //$AUTHOR$
            sb.Replace("$AUTHOR$", author);
            //$DATE$
            sb.Replace("$DATE$", DateTime.Now.ToString("yyyy-MM-dd")) ;
        }

        internal static string getSavedPath(DataTable table, string basePath, TemplateType templateType)
        {
            string savedPath = string.Empty;
            if (!basePath.EndsWith("\\"))
            {
                savedPath = basePath + "\\";
            }

            string spaceName = string.Empty;

            if (templateType.Equals(TemplateType.Entity))
            {
                spaceName = getItemDefine(table, "ENTITYNAMESPACE");

                if (string.IsNullOrEmpty(spaceName))
                {
                    throw new Exception("(ERRNO:G05) Do not define EntityNameSpace.");
                }
            }
            else if (templateType.Equals(TemplateType.SqlProvider) || templateType.Equals(TemplateType.Mapper))
            {
                spaceName = getItemDefine(table, "MAPPERNAMESPACE");

                if (string.IsNullOrEmpty(spaceName))
                {
                    throw new Exception("(ERRNO:G06) Do not define MapperNameSpace.");
                }
            }

            savedPath = savedPath + (string.IsNullOrEmpty(spaceName) ? "" : spaceName.Replace(".", "\\"));
            return savedPath;
        }

        private static string getItemDefine(DataTable table, string itemTag)
        {
            string itemDefine = string.Empty;

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

            return itemDefine;
        }

        internal static string getSavedFileName(DataTable table, TemplateType templateType, string defaultExt)
        {
            string tagName = string.Empty;

            if (templateType.Equals(TemplateType.Entity))
            {
                tagName = getItemDefine(table, "ENTITYNAME");

                if (string.IsNullOrEmpty(tagName))
                {
                    throw new Exception("(ERRNO:G01) Do not define EntityNameSpace.");
                }

                tagName = tagName + "Entity" + defaultExt;
            }
            else if (templateType.Equals(TemplateType.SqlProvider))
            {
                tagName = getItemDefine(table, "ENTITYNAME");

                if (string.IsNullOrEmpty(tagName))
                {
                    throw new Exception("(ERRNO:G02) Do not define EntityNameSpace.");
                }

                tagName = tagName + "EntitySqlProvider" + defaultExt;
            }
            else if (templateType.Equals(TemplateType.Mapper))
            {
                tagName = getItemDefine(table, "ENTITYNAME");

                if (string.IsNullOrEmpty(tagName))
                {
                    throw new Exception("(ERRNO:G03) Do not define EntityNameSpace.");
                }

                tagName = tagName + "EntityMapper" + defaultExt;
            }
            else if (templateType.Equals(TemplateType.CreateTable) || templateType.Equals(TemplateType.InsertData))
            {
                tagName = getItemDefine(table, "TABLENAME");

                if (string.IsNullOrEmpty(tagName))
                {
                    throw new Exception("(ERRNO:G04) Do not define TableName.");
                }
                tagName = templateType.ToString().ToUpper()+ "_"+tagName + defaultExt;
            }

            return tagName;
        }
    }
}
