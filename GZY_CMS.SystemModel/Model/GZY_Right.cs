using System;
using System.Collections.Generic;
using System.Text;

namespace GZY_CMS.SystemModel
{
    /// <summary>
    /// 角色实体
    /// </summary>
    public class GZY_Right
    {
        
        public int ID { get; set; }

        /// <summary>
        ///  角色描述
        /// </summary>
        public string Disname { get; set; }
        /// <summary>
        /// 角色说明
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 是否有效
        /// </summary>
        public string ValidYN { get; set; }

        /// <summary>
        /// 是否系统内置
        /// </summary>
        public Nullable<bool> Issys { get; set; }
    }
}
