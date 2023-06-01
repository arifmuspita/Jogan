using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
   public class V_LASER_STATION
    {
        public int ID { get; set; }
        public string LotBox_ID { get; set; }
        public string LotBox_NG_ID { get; set; }
        public string Status { get; set; }
        public string Created_User { get; set; }
        public System.DateTime Created_Date { get; set; }
        public string Updated_User { get; set; }
        public System.DateTime Updated_Date { get; set; }
        public int LotBox_Position { get; set; }
    }
}
