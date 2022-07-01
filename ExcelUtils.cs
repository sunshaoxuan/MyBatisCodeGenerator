using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator
{
    public class ExcelUtils
    {
        public static string transferDateValue(string strNumber)
        {
            return DateTime.FromOADate(Double.Parse(strNumber)).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static Dictionary<string, DataTable> GetExcelTableByOleDB(string strExcelPath)
        {
            try
            {
                Dictionary<string, DataTable> dicExcel = new Dictionary<string, DataTable>();
                //数据表
                DataSet ds = new DataSet();
                //获取文件扩展名
                string strExtension = Path.GetExtension(strExcelPath);
                string strFileName = Path.GetFileName(strExcelPath);
                //Excel的连接
                OleDbConnection objConn = null;
                switch (strExtension)
                {
                    case ".xls":
                        objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strExcelPath + ";" + "Extended Properties=\"Excel 8.0;HDR=NO;IMEX=1;\"");
                        break;
                    case ".xlsx":
                        objConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strExcelPath + ";" + "Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1;\"");
                        break;
                    default:
                        objConn = null;
                        break;
                }
                if (objConn == null)
                {
                    return null;
                }
                objConn.Open();
                //获取Excel中所有Sheet表的信息
                DataTable schemaTable = objConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                //获取Excel的第一个Sheet表名
                for (int rowNo = 0; rowNo <= schemaTable.Rows.Count - 1; rowNo++)
                {
                    string tableName = schemaTable.Rows[rowNo][2].ToString().Trim();
                    string strSql = "select * from [" + tableName + "]";
                    //获取Excel指定Sheet表中的信息
                    OleDbCommand objCmd = new OleDbCommand(strSql, objConn);
                    OleDbDataAdapter myData = new OleDbDataAdapter(strSql, objConn);
                    myData.Fill(ds, tableName);//填充数据
                    objConn.Close();
                    //dtExcel即为excel文件中指定表中存储的信息
                    dicExcel.Add(tableName, ds.Tables[tableName]);
                }
                return dicExcel;
            }
            catch
            {
                return null;
            }
        }
    }
}
