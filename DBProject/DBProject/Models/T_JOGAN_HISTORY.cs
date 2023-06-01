using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_JOGAN_HISTORY :BaseColumns
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Object_Activity { get; set; }
        [Required]
        public string Last_Activity { get; set; }
    }
}
