using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class M_NOISE_DEVICE : BaseColumns
    {
        [Key]
        public Int32 ID { get; set; }
        public string Test_Type_ID { get; set; } 
        public string Device_ID { get; set; }
        public virtual M_DEVICE M_NOISE_DEVICE_M_DEVICES { get; set; }
        public virtual M_NOISE_DEVICE_PARAMETER M_DEVICES_M_NOISE_DEVICE_PARAMETER { get; set; }
    }
}
