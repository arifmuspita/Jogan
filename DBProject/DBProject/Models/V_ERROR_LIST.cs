using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public   class V_MESSAGE
    {
        public int ID { get; set; }
        public string Message_Code { get; set; }
        public string Message_Name { get; set; }
        public string Hardware_ID { get; set; }
        public string Status { get; set; }
        public bool MarkAsDelete { get; set; }
        public Nullable<System.DateTime> Created_Date { get; set; }
        public string Impact { get; set; }
    }
}
