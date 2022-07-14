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

namespace MyBatisCodeGenerator.Utils
{
    public class CommonUtils
    {
        /// <summary>
        /// Read a text file
        /// </summary>
        /// <param name="fileName">Full file name with path</param>
        /// <returns>Content of the text file</returns>
        public static string ReadTextFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return "";
            }

            return File.ReadAllText(fileName, Encoding.UTF8);
        }

        /// <summary>
        /// Write a text file
        /// </summary>
        /// <param name="fileName">File name without path</param>
        /// <param name="fullPath">Full path without file name</param>
        /// <param name="contentStr">Content of text file</param>
        /// <param name="createNonExistsDir">If create all Non-Exists directories.</param>
        /// <param name="isOverwrite">If over write the file when it exists</param>
        /// <param name="isAppend">if append the content to exists file</param>
        /// <param name="isSkip">If skip saving when not over write the file,  if not skip, throws a exception</param>
        public static void WriteTextFile(string fileName, string fullPath, string contentStr, bool createNonExistsDir, bool isOverwrite, bool isAppend, bool isSkip)
        {
            if(!fullPath.EndsWith("\\"))
            {
                fullPath = fullPath + "\\";
            }

            if (File.Exists(fullPath + fileName))
            {
                if (isOverwrite)
                {
                    File.Delete(fullPath + fileName);
                }
                else
                {
                    if (!isSkip)
                    {
                        throw new Exception("File ["+fullPath + fileName+"] already exists.");
                    }
                    else
                    {
                        return;
                    }
                }
            }

            if (!Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }
            File.WriteAllText(fullPath+fileName, contentStr, Encoding.UTF8);
        }

        /// <summary>
        /// Get object from reading serialized data file
        /// </summary>
        /// <param name="fileName">Full file name of serialization data</param>
        /// <returns></returns>
        public static Object ReadSerializationDataFromFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return null;
            }

            //Read data serialization file
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            //restore a object from serialization data
            Object obj = bf.Deserialize(fs);
            fs.Close();
            return obj;
        }

        public static void WriteSerializationDataToFile(string fileName, Object serializationObj)
        {
            //Create a file to write
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, serializationObj);
            fs.Close();
        }

        /// <summary>
        /// Set RichTextBox Color for Tags surround with '$'
        /// </summary>
        /// <param name="rtbControl"></param>
        /// <param name="customColor"></param>
        public static void SetRichTextBoxTextColor(RichTextBox rtbControl, Color customColor)
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
                    rtbControl.SelectionColor = customColor;
                    startPos = closePos + 1;
                }
            }
        }

        public static void Log(string content)
        {
            string fileFullPath = Application.StartupPath + @"\log_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log";
            WriteTextFile(@"\log_" + DateTime.Today.ToString("yyyy_MM_dd") + ".log", 
                Application.StartupPath, 
                DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss") + "\t" + content + "\r\n", 
                true, false, true, true);
        }
    }
}
