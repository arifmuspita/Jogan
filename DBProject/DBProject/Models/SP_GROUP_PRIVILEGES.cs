using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class SP_GROUP_PRIVILEGES
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Detail { get; set; }
        public int Total_Child { get; set; }
        public bool Allow_Read { get; set; }
        public bool Allow_Add { get; set; }
        public bool Allow_Edit { get; set; }
        public bool Allow_Delete { get; set; }
        public bool Allow_Report { get; set; }
    }
}
