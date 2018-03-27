using Autofac;
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
            //注入测试服务
            // builder.RegisterType<TestService>().As<ITestService>();
            DirectoryAssemblyFinder daf = new DirectoryAssemblyFinder();
            var assemblyss = daf.FindAll();
            //批量注入
            var assemblys = AppDomain.CurrentDomain.GetAssemblies();
            //string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("file:///", "");
            //var typesToRegister = asm.GetTypes()
            //Assembly asm = Assembly.LoadFile(assembleFileName);
            var AllServices = assemblyss
               .SelectMany(s => s.GetTypes())
               .Where(p => baseType.IsAssignableFrom(p) && p != baseType).ToArray();
            builder.RegisterAssemblyTypes(assemblyss)
                .Where(p => baseType.IsAssignableFrom(p) && p != baseType)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

        }
    }
}
