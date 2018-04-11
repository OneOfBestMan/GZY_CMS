using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GZY_CMS.Core.Autofac
{
    public static class AutofacConfiguring
    {

        public static void RegisterController(this IServiceCollection services)
        {
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
        }

        /// <summary>
        /// 替换Core自带容器为Autofac
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceProvider ReplacementIOC(this IServiceCollection services,Module module)
        {
            var containerBuilder = new ContainerBuilder();
           
            containerBuilder.RegisterModule(module);
            var manager = new ApplicationPartManager();
            var date = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var item in date)
            {
                manager.ApplicationParts.Add(new AssemblyPart(item));
            }
            manager.FeatureProviders.Add(new ControllerFeatureProvider());
            var feature = new ControllerFeature();
            manager.PopulateFeature(feature);
            containerBuilder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }
    }
}
