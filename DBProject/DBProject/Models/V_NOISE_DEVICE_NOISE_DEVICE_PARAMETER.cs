using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER
    {
        public int ID { get; set; }
        public string Device_ID { get; set; }
        public string Device_Name { get; set; }
        public string Test_Type_ID { get; set; }
        public string Test_Type_Name { get; set; }
        public int Soak_Time { get; set; }
        public int Measurement_Duration { get; set; }

    }
}
