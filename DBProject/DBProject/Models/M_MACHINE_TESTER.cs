using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class M_MACHINE_TESTER:BaseColumns
    {
        [ Key]
        public string Machine_ID { get; set; }
        [StringLength(250), Required]
        public string Machine_Name { get; set; }
        [StringLength(150), Required]
        public string Machines_Type { get; set; }
        public int Machine_Number { get; set; }
        public int Machine_Line_Number { get; set; }
    }
}