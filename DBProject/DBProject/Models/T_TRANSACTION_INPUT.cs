using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_TRANSACTION_INPUT : T_BASE_TRANSACTION
    {
        public T_TRANSACTION_INPUT()
        {
            AQL_Reference = "";
            LotBox_Position_Fukuda = 0;
            LotBox_Position_Laser = 0;
            LotBox_Position_Laser_Downgrade = 0;
            Noise_Type_Parameter_Ref = "";
            Signal_Device_ID_Ref = "";
            Status = "";
            Start_Test = DateTime.Now;
            End_Test = Start_Test;
            Quantity = 0;
            ApplyNoiseTest = true;
            ApplySignalTest = true;
            ApplyResistanceTest = true;
        }
        [StringLength(100)]
        public string AQL_Reference { get; set; }
        public int LotBox_Position_Fukuda { get; set; }
        public int LotBox_Position_Laser { get; set; }
        public int LotBox_Position_Laser_Downgrade { get; set; }
        [StringLength(100)]
        public string Noise_Type_Parameter_Ref { get; set; }
        [StringLength(100)]
        public string Signal_Device_ID_Ref { get; set; }
        [StringLength(100)]
        public string Status { get; set; }
        [StringLength(100)]
        public string LotBox_ID { get; set; }
        [Required]
        public DateTime Start_Test { get; set; }
        [Required]
        public DateTime End_Test { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string Default_Test_Mode{ get; set; }
        //these three fields needed when recreating booking machine (when 1 or more machine(s) error/off)
        [Required]
        public bool ApplyNoiseTest { get; set; }
        [Required]
        public bool ApplySignalTest { get; set; }
        [Required]
        public bool ApplyResistanceTest { get; set; }
        //public virtual M_DEVICES BaseTransaction__M_DEVICES { get; set; }
        //public virtual M_USER BaseTransaction__M_USER { get; set; }
    }
}
