using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class M_DEVICE_NG:BaseColumns
    {
        [ Key]
        public string Device_NG_ID { get; set; }
        [StringLength(200), Required]
        public string Device_NG_Type { get; set; }
    }
}