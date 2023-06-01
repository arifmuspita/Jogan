using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class M_NOISE_DEVICE_PARAMETER:BaseColumns
    {
        //[Key]
        //public Int32 ID { get; set; }

        //[Required]
        //public string Device_ID { get; set; }
        [Key]
        public string Test_Type_ID { get; set; }
        [Required]
        public string Test_Type_Name { get; set; }
        [Required]
        public int Noise_Limit { get; set; }
        [Required]
        public int Soak_Time { get; set; }
        [Required]
        public int Measurement_Duration { get; set; }
        [Required]
        public int Lauda_Setting { get; set; }
        [Required]
        public int BB_Temperature_HL { get; set; }
        [Required]
        public int BB_Temperature_LL { get; set; }
        [Required]
        public int Upper_Temp_Tolerance { get; set; }
        [Required]
        public int Lower_Temp_Tolearance { get; set; }
        [Required]
        public int Sample_Rate { get; set; }
        [Required]
        public double No_DUT_Offset { get; set; }
        [Required]
        public double Offset_HLimit { get; set; }
        [Required]
        public double Offset_LLimit { get; set; }
        [Required]
        public double Cut_Off_Freq { get; set; }
        [Required]
        public bool Moving_Window { get; set; }
        [Required]
        public double Correlation_Factor { get; set; }
        [Required]
        public int Testing_Voltage { get; set; }
        [Required]
        public int Lauda_Setting1{ get; set; }


        //public virtual M_DEVICES M_NOISE_DEVICE_PARAMETER_M_DEVICES_ { get; set; }
        //public virtual M_NOISE_DEVICE_PARAMETER_TYPE M_NOISE_DEVICE_PARAMETER_M_NOISE_DEVICE_PARAMETER_TYPE { get; set; }
    }
}