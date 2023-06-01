using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class M_MACHINE_TESTER_CALIBRATION: BaseSocket
    {
        [Key]
        public Int32 ID { get; set; }
        [Required]
        public string Machine_ID { get; set; }
        [Required]
        public string Calibration_Type { get; set; } 
        //public string Calibration_Type2 { get; set; }
        public virtual M_MACHINE_TESTER M_MACHINE_TESTER_CALIBRATION_M_MACHINE_TESTER { get; set; }
        public virtual M_MACHINE_TESTER_CALIBRATION_TYPE M_MACHINE_TESTER_CALIBRATION_M_MACHINE_TESTER_CALIBRATION_TYPE { get; set; }
    }
}