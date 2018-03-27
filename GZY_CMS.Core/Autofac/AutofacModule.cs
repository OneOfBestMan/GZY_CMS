using Autofac;
using GZY_CMS.Core.Repository;
using GZY_CMS.Infrastructure;
using GZY_CMS.Utility.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GZY_CMS.Core.Autofac
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Type baseType = typeof(IDependency);
            
            DirectoryAssemblyFinder daf = new DirectoryAssemblyFinder();
            var assemblyss = daf.FindAll();
            //调试用
            //var AllServices = assemblyss
            //   .SelectMany(s => s.GetTypes())
            //   .Where(p => baseType.IsAssignableFrom(p) && p != baseType).ToArray();

          
            builder.RegisterAssemblyTypes(assemblyss)
                .Where(p => baseType.IsAssignableFrom(p) && p != baseType)
                .AsImplementedInterfaces().PropertiesAutowired()
                .InstancePerLifetimeScope();
           //注入泛型仓储服务,支持多上下文
           builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).PropertiesAutowired().InstancePerLifetimeScope();

        }
    }

}
