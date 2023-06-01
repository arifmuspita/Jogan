using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class M_MACHINE_TESTER_CALIBRATION_TYPE: BaseColumns
    {
        
        //[Required]
        //public int M_MACHINE_TESTERMachine_ID { get; set; }
        [ Key]
        public string Calibration_Type { get; set; } 

        //public virtual M_MACHINE_TESTER M_MACHINE_TESTER_CALIBRATION_M_MACHINE_TESTER { get; set; }
    }
}