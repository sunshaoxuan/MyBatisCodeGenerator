using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Generator
{
    public class ServiceGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.Service;

        public override string GetClassSpace()
        {
            return $"{GetItemDefine("CLASSROOT")}.inf";
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
                throw new Exception("(ERRNO:G10) Do not define service file name.");
            }

            fileName = "I" + fileName + "Service" + defaultExt;

            return fileName;
        }

        public override bool IsGeneratable()
        {
            return true;
        }

        public ServiceGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = false;
        }
    }
}
