using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class M_NG_CONFIG:BaseColumns
    { 
        [Key]
        public int ID { get; set; }
        
        public int Box_Index { get; set; }
        [StringLength(25)]
        public string Box_ID { get; set; }
        [StringLength(25)]
        public string NG_Code { get; set; }
        [StringLength(50)]
        public string Date_String { get; set; } 
    }
}
