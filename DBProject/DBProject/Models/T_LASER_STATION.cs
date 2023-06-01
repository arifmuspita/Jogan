using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_LASER_STATION:BaseColumns
    {
        [Key]
        public int ID { get; set; }
        public string LotBox_ID { get; set; }
        public string LotBox_NG_ID { get; set; }
        public string Status { get; set; }
        public int LotBox_Position { get; set; }
        public bool Is_Downgrade { get; set; }
    }
}
