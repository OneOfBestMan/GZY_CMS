using GZY_CMS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using GZY_CMS.SystemModel;

namespace GZY_CMS.IService
{
    public interface IUserService : IDependency
    {
        int Add();

        List<GZY_User> Select(string Loginname,string Name, string ValidYN,int index, int rows, out int total);
    }
}
