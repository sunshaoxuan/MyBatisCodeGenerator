using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MultiLangMapperExtendGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.MultiLangMapperExtend;

        public override string GetSavedFileName(string defaultExt)
        {
            String fileName = GetItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G63) Do not define EntityNameSpace.");
            }

            fileName = fileName + "ResEntityExtendMapper" + defaultExt;
            return fileName;
        }

        public override string GetClassSpace()
        {
            return GetItemDefine("MAPPERNAMESPACE") + ".extend";
        }

        public override string GetRootPath()
        {
            return BaseSourcePath;
        }

        public override bool IsGeneratable()
        {
            return TemplateUtils.MultiLangDefined(DesignData);
        }

        public MultiLangMapperExtendGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = true;
        }
    }
}
