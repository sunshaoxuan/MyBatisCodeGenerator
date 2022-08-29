﻿using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Data;

namespace MyBatisCodeGenerator.Generator
{
    internal class MultiLangInsertDataGenerator : AbstractGenerator
    {
        public override TemplateUtils.TemplateTypeEnum GeneratorType => TemplateUtils.TemplateTypeEnum.MultiLangInsertData;

        public override string GetSavedFileName(string defaultExt, Dictionary<string, string> tagData)
        {
            string fileName = GetItemDefine("TABLENAME") + "_res";

            if (string.IsNullOrEmpty(fileName))
            {
                throw new Exception("(ERRNO:G65) Do not define TableName.");
            }
            fileName = InsertDataPrefix + fileName + defaultExt;

            return fileName;
        }

        public override string GetClassSpace()
        {
            return string.Empty;
        }

        public override string GetRootPath()
        {
            return BaseScriptPath;
        }

        public override bool IsGeneratable()
        {
            List<Dictionary<string, string>> details = TemplateUtils.GetInsertDataDetail(DesignData);
            return details.Count > 0;
        }

        public MultiLangInsertDataGenerator()
        {
            FileExtension = ".sql";
            GenerateByMeta = false;
            IsMultiLangGenerator = true;
        }
    }
}