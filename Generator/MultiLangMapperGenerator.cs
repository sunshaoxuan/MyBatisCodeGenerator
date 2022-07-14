using MyBatisCodeGenerator.Utils;
using System;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MultiLangMapperGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.MultiLangMapper;

        public override string GetSavedFileName(string defaultExt)
        {
            String fileName = GetItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G62) Do not define EntityNameSpace.");
            }

            fileName = fileName + "ResEntityMapper" + defaultExt;
            return fileName;
        }

        public override string GetClassSpace()
        {
            return GetItemDefine("MAPPERNAMESPACE");
        }

        public override string GetRootPath()
        {
            return BaseSourcePath;
        }

        public override bool IsGeneratable()
        {
            return TemplateUtils.MultiLangDefined(DesignData);
        }

        public MultiLangMapperGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = true;
        }
    }
}
