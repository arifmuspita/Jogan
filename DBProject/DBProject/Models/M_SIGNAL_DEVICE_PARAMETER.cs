using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class M_SIGNAL_DEVICE_PARAMETER:BaseColumns
    {
        [Key]
        public Int32 ID { get; set; }
        [Required]
        public string Device_ID { get; set; }
        [Required]
        public double No_DUT_Offset { get; set; }
        [Required]
        public double Offset_Min { get; set; }
        [Required]
        public double Offset_Max { get; set; }
        [Required]
        public double Offset_HLimit { get; set; }
        [Required]
        public double Offset_Grp_Min { get; set; }
        [Required]
        public double Offset_Grp_Max { get; set; }
        [Required]
        public double No_Response { get; set; }
        [Required]
        public double Response_Min { get; set; }
        [Required]
        public double Response_Max { get; set; }
        [Required]
        public double Response_Grp_Min { get; set; }
        [Required]
        public double Response_Grp_Max { get; set; }
        [Required]
        public double Match_Correlation_Factor { get; set; }
        [Required]
        public double Match_Signal_Max { get; set; }
        [Required]
        public double Resistance_Min { get; set; }
        [Required]
        public int First_Soak_Time { get; set; }
        [Required]
        public int Second_Soak_Time { get; set; }
        [Required]
        public int Lauda_Setting { get; set; }
        [Required]
        public int BB_Setting { get; set; }
        [Required]
        public int BB_Temperature_HL { get; set; }
        [Required]
        public int BB_Temperature_LL { get; set; }
        [Required]
        public int Sample_Rate { get; set; }
        [Required]
        public double High_Cutof_Frequency { get; set; }
        [Required]
        public double Low_Cutof_Frequency { get; set; }
        [Required]
        public int Measurement_Duration { get; set; }
        [Required]
        public double Measurement_Duration_2 { get; set; }
        [Required]
        public double Temperature_Coe { get; set; }
        [Required]
        public double Testing_Voltage { get; set; }
        [Required]
        public double Resistance { get; set; }  

        public virtual M_DEVICE M_SIGNAL_DEVICE_PARAMETER_M_DEVICES { get; set; }
    }
}