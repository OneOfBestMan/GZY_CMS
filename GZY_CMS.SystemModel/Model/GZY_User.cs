using System;
using System.Collections.Generic;
using System.Text;

namespace GZY_CMS.SystemModel
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class GZY_User
    {
        public int ID { get; set; }
        public string Loginname { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ValidYN { get; set; }
        public Nullable<bool> Sex { get; set; }
    }
}
