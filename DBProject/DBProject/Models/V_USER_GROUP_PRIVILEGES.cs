using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class V_USER_GROUP_PRIVILEGES
    {
        public int ID { get; set; }
        //public int Menu_ID { get; set; }
        public string Group_ID { get; set; }
        public string Group_Name { get; set; }
        public bool Allow_Report { get; set; }
        public bool Allow_Read { get; set; }
        public bool Allow_Add { get; set; }
        public bool Allow_Delete { get; set; }
        public bool Allow_Edit { get; set; }
        public bool Allow_Export { get; set; }
        public Nullable<int> Parent_ID { get; set; }
        public bool Detail { get; set; }
        public string Module { get; set; }
        public string Module_Parent { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Menu_For { get; set; }
        public bool Is_Active { get; set; } 
        public string Created_User { get; set; } 
        public DateTime Created_Date { get; set; } 
        public string Updated_User { get; set; } 
        public DateTime Updated_Date { get; set; }
    }
}
