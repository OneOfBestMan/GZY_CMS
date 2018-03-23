using Autofac;
using GZY_CMS.IService;
using GZY_CMS.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace GZY_CMS.Core.Autofac
{
    public class AutofacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //注入测试服务
            builder.RegisterType<TestService>().As<ITestService>();

        }
    }
}
