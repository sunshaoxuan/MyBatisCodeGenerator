using MyBatisCodeGenerator.Transformer;
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
            return $"{GetItemDefine("CLASSROOT")}.impl.handler." + entityName.ToLower();
        }

        public override string GetRootPath()
        {
            return BaseSourcePath;
        }

        public override string GetSavedFileName(string defaultExt, Dictionary<string, string> tagData)
        {
            string fileName = GetItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G09) Do not define service implemtn file name.");
            }

            fileName = fileName + tagData["$HANDLERTYPE$"] + "Handler" + defaultExt;

            return fileName;
        }

        public override bool IsGeneratable()
        {
            string entityName = GetItemDefine("ENTITYNAME");

            foreach (KeyValuePair<string, DataTable> kv in ExcelData)
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
                            return true;
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
            IsMultiFile = true;
            MultiFileTagData = new Dictionary<string, Dictionary<string, string>>();
            MultiFileTagData.Add("Save Handler", new Dictionary<string, string>());
            MultiFileTagData["Save Handler"].Add("$HANDLERTYPE$", "Save");
            MultiFileTagData["Save Handler"].Add("$LOWER_HANDLERTYPE$", "save");
            MultiFileTagData["Save Handler"].Add("$HANDLERTYPENAME$", "保存");
            MultiFileTagData.Add("Delete Handler", new Dictionary<string, string>());
            MultiFileTagData["Delete Handler"].Add("$HANDLERTYPE$", "Delete");
            MultiFileTagData["Delete Handler"].Add("$LOWER_HANDLERTYPE$", "delete");
            MultiFileTagData["Delete Handler"].Add("$HANDLERTYPENAME$", "删除");
        }
    }
}
