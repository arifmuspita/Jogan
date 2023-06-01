using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class V_USER_GROUP_PRIVILEGES_IS_SET
    {
        public int ID { get; set; }
        public string Group_ID { get; set; }
        public string Group_Name { get; set; }
        public  bool Is_Set { get; set; }
       
    }
}
