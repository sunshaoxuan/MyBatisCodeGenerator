using MyBatisCodeGenerator.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBatisCodeGenerator.Generator
{
    internal class GeneratorFactory
    {
        private static List<AbstractGenerator> generators = null;

        public static List<AbstractGenerator> GetAllGenerator()
        {
            if (generators == null)
            {
                Type[] types = Assembly.GetExecutingAssembly().GetTypes();

                List<AbstractGenerator> defaultGenerator = new List<AbstractGenerator>();
                foreach (Type type in types)
                {
                    if (type.BaseType.Equals(typeof(AbstractGenerator)))
                    {
                        AbstractGenerator generator = (AbstractGenerator)System.Activator.CreateInstance(type);
                        defaultGenerator.Add(generator);
                    }
                }

                generators = defaultGenerator;
            }

            return generators;
        }

        public static AbstractGenerator CreateGenerator(TemplateUtils.TemplateTypeEnum tmpType)
        {
            AbstractGenerator abstractGenerator = null;

            foreach (AbstractGenerator generator in GetAllGenerator())
            {
                if (generator.GeneratorType.Equals(tmpType))
                {
                    abstractGenerator = generator;
                }
            }
            
            return abstractGenerator;
        }
    }
}
