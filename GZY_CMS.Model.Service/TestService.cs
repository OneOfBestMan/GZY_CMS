using GZY_CMS.Core.Repository;
using GZY_CMS.IService;
using GZY_CMS.Model;
using System;
using System.Linq;

namespace GZY_CMS.Service
{
    public class TestService : ITestService
    {

        public Repository<GZY_UserAdmin, GZYCMSContext> MyProperty { get; set; }
        public int Add()
        {
            MyProperty.GetList(a=>1==1).ToList();
            return 1;
        }
    }
}
