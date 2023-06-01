using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class M_ERROR_LIST :BaseColumns
    { 
        [Key, StringLength(50)]
        public string Message_Code { get; set; }

        [Required, StringLength(250)]
        public string Message_Name { get; set; }
        [Required, StringLength(250)]
        public string Impact { get; set; } //Low, Medium, High
        //public string A { get; set; } //Low, Medium, High
    }
}
