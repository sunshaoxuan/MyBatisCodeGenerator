using MyBatisCodeGenerator.Utils;
using System;

namespace MyBatisCodeGenerator.Generator
{
    public class RestGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.Rest;

        public override string GetClassSpace()
        {
            return $"{GetItemDefine("CLASSROOT")}.rest";
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
                throw new Exception("(ERRNO:G09) Do not define rest file name.");
            }

            fileName = fileName + "Rest" + defaultExt;

            return fileName;
        }

        public override bool IsGeneratable()
        {
            return true;
        }

        public RestGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = false;
        }
    }
}
