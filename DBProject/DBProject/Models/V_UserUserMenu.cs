using System;
using System.Collections.Generic;
using System.Linq;


namespace DBProject.Models
{
    public class V_USER_GROUP_PRIVILEGE
    {
        public int ID { get; set; }
        public int MenuID { get; set; }
        public string GroupID { get; set; }
        public string GroupName { get; set; }
        public string Name { get; set; }
        public string BagdeNo { get; set; }
        public string UserName { get; set; }
        public int UserGroupID { get; set; }
        public bool AllowRead { get; set; }
        public bool AllowAdd { get; set; }
        public bool AllowDelete { get; set; }
        public bool AllowEdit { get; set; }
        public Nullable<int> Parent_ID { get; set; }
        public bool Detail { get; set; }
        public string Module { get; set; }
        public string Module_Parent { get; set; }
        public string Code { get; set; }
        public string MenuName { get; set; }
    }
}