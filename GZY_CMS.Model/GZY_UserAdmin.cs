using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GZY_CMS.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class GZY_UserAdmin
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        [MaxLength(100)]
        public string PassWord { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
