using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Generator
{
    public class ServiceImplGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.ServiceImpl;

        public override string GetClassSpace()
        {
            return $"{GetItemDefine("CLASSROOT")}.service.impl";
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

            fileName = fileName + "ServiceImpl" + defaultExt;

            return fileName;
        }

        public override bool IsGeneratable()
        {
            return true;
        }

        public ServiceImplGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = false;
        }
    }
}
