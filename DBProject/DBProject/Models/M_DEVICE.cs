using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class M_DEVICE : BaseColumns
    {
        [ Key]
        public string Device_ID { get; set; }
        [StringLength(250), Required]
        public string Device_Name { get; set; }
        //[StringLength(200), Required]
        //public string DeviceGroup { get; set; }
        [StringLength(200), Required]
        public string Device_Status { get; set; }
        [StringLength(200), Required]
        public string Test_Mode_Default { get; set; }
    }
}