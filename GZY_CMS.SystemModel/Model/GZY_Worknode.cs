using System;
using System.Collections.Generic;
using System.Text;

namespace GZY_CMS.SystemModel
{
    /// <summary>
    /// 资源实体
    /// </summary>
    public class GZY_Worknode
    {
        public int ID { get; set; }
        public Nullable<int> Upperid { get; set; }
        public Nullable<int> Appid { get; set; }
        public string Node_abbre { get; set; }
        public string Node_href { get; set; }
        public string NodeValid { get; set; }
        public Nullable<System.DateTime> Lrsj { get; set; }
        public Nullable<int> Node_type { get; set; }
        public Nullable<bool> Issys { get; set; }
    }
}
