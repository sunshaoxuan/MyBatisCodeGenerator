using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Transformer
{
    public class MultiLangInsertDataTransformer : AbstractTransformer
    {
        public override int GetOrder()
        {
            return 12;
        }

        public override string GetTag()
        {
            return "$INSERTMULTILANGDATASET$";
        }

        public override bool IsTransformItem(Dictionary<string, string> item)
        {
            return !TemplateUtils.IsAggVOItem(item);
        }

        public override bool IsValid()
        {
            return true;
        }

        public override void Transform()
        {
            if (!OriginalContent.ToString().Contains(GetTag()))
            {
                return;
            }

            StringBuilder resultSQL = new StringBuilder();

            Dictionary<string, string> metaDetail = new Dictionary<string, string>();
            foreach (Dictionary<string, string> item in GetGeneratedMetaDetail())
            {
                if (TemplateUtils.IsAggVOItem(item))
                {
                    continue;
                }

                metaDetail.Add(item["FIELD NAME"].ToUpper(), item["DATA TYPE"]);
            }

            List<Dictionary<string, string>> dataDetail = GetMultiLangInsertData();

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
                        insertSQL.Append(TemplateUtils.GetItemDefine(DesignData, "TABLENAME", DefRefs) + "_res");

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
                        values += TemplateUtils.GetItemValueByName(item) + (col == data.Count ? "" : ",");
                    }
                    values += ")";
                    valueSQL.Append(values);
                    valueSQL.Append(";\r\n");

                    resultSQL.Append(insertSQL);
                    resultSQL.Append(valueSQL);
                }
            }

            OriginalContent.Replace(GetTag(), resultSQL.ToString());
        }
    }
}
