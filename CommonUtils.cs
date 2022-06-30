using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBatisCodeGenerator
{
    public class CommonUtils
    {
        public static string readTextFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return "";
            }

            return File.ReadAllText(fileName, Encoding.UTF8);
        }
        public static Object readSerialzationDataFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            //读取对象到窗体
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            //通过反序列化还原对象
            Object obj = bf.Deserialize(fs);
            fs.Close();
            return obj;
        }

        public static void writeSerializationDataToFile(string fileName, Object serializationObj)
        {
            //保存对象到文本文件中(序列化)
            FileStream fs = new FileStream(fileName, FileMode.Create);
            //创建二进制格式化器
            BinaryFormatter bf = new BinaryFormatter();
            //调用序列化方法
            bf.Serialize(fs, serializationObj);
            //关闭数据流
            fs.Close();
        }

        public static void setRichTextBoxTextColor(RichTextBox rtbControl)
        {
            int startPos = 0;
            int findPos = 0;
            while (findPos >= 0)
            {
                findPos = rtbControl.Find("$", startPos, RichTextBoxFinds.MatchCase);
                if (findPos >= 0)
                {
                    int closePos = rtbControl.Find("$", findPos + 1, RichTextBoxFinds.MatchCase);
                    rtbControl.SelectionStart = findPos;
                    rtbControl.SelectionLength = closePos - findPos + 1;
                    rtbControl.SelectionColor = Color.DarkRed;
                    startPos = closePos + 1;
                }
            }
        }
    }
}
