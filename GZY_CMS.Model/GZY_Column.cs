using System;
using System.Collections.Generic;
using System.Text;

namespace GZY_CMS.Model
{

    /// <summary>
    /// 栏目表
    /// </summary>
    public class GZY_Column
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public int SortNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnDescription { get; set; }
    }
}
