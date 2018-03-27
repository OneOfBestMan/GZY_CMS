using GZY_CMS.Core.Autofac;
using GZY_CMS.Core.Repository;
using GZY_CMS.IService;
using GZY_CMS.Model;
using System;
using System.Linq;

namespace GZY_CMS.Service
{
    public class TestService : ITestService
    {

        public IRepository<GZY_UserAdmin,GZYCMSContext> MyProperty { get; set; }


        //public TestService(TRepository<GZY_UserAdmin>  Property)
        //{
        //    MyProperty = Property;
        //}
        public int Add()
        {
            MyProperty.GetList(a => 1 == 1).ToList();
            return 1;
        }
    }
}
