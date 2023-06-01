using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class M_NOISE_DEVICE_PARAMETER_TYPE : BaseColumns
    {
        //    [Required]
        //    public int DeviceID { get; set; }
        //    [Required]
        //    public int DeviceNoiseTestParameterTypeID { get; set; }

        //    public virtual DeviceNoiseTestParameter DeviceNoiseTestParameter_DeviceNoiseTestParameterType { get; set; }
        //    public virtual Device DeviceNoiseTestParameter_Device { get; set; }

        [Key]
        public string Test_Type_ID { get; set; } 
        public string Test_Type { get; set; }
    }
}