using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Generator
{
    internal class GeneratorFactory
    {
        public static AbstractGenerator createGenerator(TemplateUtils.TemplateTypeEnum tmpType)
        {
            AbstractGenerator abstractGenerator = null;
            switch (tmpType)
            {
                case TemplateUtils.TemplateTypeEnum.Entity:
                    abstractGenerator = new EntityGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.SqlProvider:
                    abstractGenerator = new SqlProviderGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.Mapper:
                    abstractGenerator = new MapperGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.MapperExtend:
                    abstractGenerator = new MapperExtendGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.CreateTable:
                    abstractGenerator = new CreateTableGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.InsertData:
                    abstractGenerator = new InsertDataGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.MultiLangEntity:
                    abstractGenerator = new MultiLangEntityGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.MultiLangMapper:
                    abstractGenerator = new MultiLangMapperGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.MultiLangMapperExtend:
                    abstractGenerator = new MultiLangMapperExtendGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.MultiLangSqlProvider:
                    abstractGenerator = new MultiLangSqlProviderGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.MultiLangCreateTable:
                    abstractGenerator = new MultiLangCreateTableGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.MultiLangInsertData:
                    abstractGenerator = new MultiLangInsertDataGenerator();
                    break;
                case TemplateUtils.TemplateTypeEnum.VO:
                    abstractGenerator = new VOGenerator();
                    break;
                default:
                    break;
            }

            return abstractGenerator;
        }
    }
}
