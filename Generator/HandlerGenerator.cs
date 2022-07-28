using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Generator
{
    public class HandlerGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.Handler;

        public override string GetClassSpace()
        {
            string entityName = GetItemDefine("ENTITYNAME");
            return $"{GetItemDefine("CLASSROOT")}.service.handler." + entityName.ToLower();
        }

        public override string GetRootPath()
        {
            return BaseSourcePath;
        }

        public override string GetSavedFileName(string defaultExt)
        {
            string fileName = GetItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G09) Do not define service implemtn file name.");
            }

            fileName = fileName + "SaveHandler" + defaultExt;

            return fileName;
        }

        public override bool IsGeneratable()
        {
            string entityName = GetItemDefine("ENTITYNAME");

            foreach (KeyValuePair<String, DataTable> kv in ExcelData)
            {
                if (!kv.Value.Equals(DesignData))
                {
                    List<Dictionary<string, string>> defines = TemplateUtils.GetDesignMetaDetailByValue(kv.Value, "DATA TYPE", "AggVO");
                    foreach (Dictionary<string, string> define in defines)
                    {
                        if (define.ContainsKey("VO DATA TYPE") && 
                            (define["VO DATA TYPE"].ToUpper().Equals(entityName.ToUpper() + "AGGVO")
                            || define["VO DATA TYPE"].ToUpper().Equals(entityName.ToUpper() + "VO")))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public HandlerGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = false;
        }
    }
}
