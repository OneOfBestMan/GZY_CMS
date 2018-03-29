using System;
using System.Collections.Generic;
using System.Text;

namespace GZY_CMS.SystemModel
{
    public class GZY_SystemTable
    {
        public int ID { get; set; }
        public string SystemName { get; set; }
       
        public string ValidYN { get; set; }
        public Nullable<System.DateTime> Lrsj { get; set; }

    }
}
