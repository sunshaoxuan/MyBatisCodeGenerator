using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Generator
{
    internal class MultiLangSqlProviderGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.MultiLangSqlProvider;

        public override string GetSavedFileName(string defaultExt, Dictionary<string, string> tagData)
        {
            string fileName = GetItemDefine("ENTITYNAME");

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G61) Do not define multilang sql provider file name.");
            }

            fileName = $"{fileName}ResEntitySqlProvider{defaultExt}";

            return fileName;
        }

        public override string GetClassSpace()
        {
            return $"{GetItemDefine("CLASSROOT")}.dao.provider";
        }

        public override string GetRootPath()
        {
            return BaseSourcePath;
        }

        public override bool IsGeneratable()
        {
            return TemplateUtils.MultiLangDefined(DesignData);
        }

        public MultiLangSqlProviderGenerator()
        {
            FileExtension = ".java";
            GenerateByMeta = true;
            IsMultiLangGenerator = true;
        }
    }
}