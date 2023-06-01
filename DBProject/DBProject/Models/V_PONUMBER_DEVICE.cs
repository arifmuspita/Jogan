using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class V_PONUMBER_DEVICE
    {
        public int ID { get; set; }
        public string PO_Number { get; set; }
        public string AQL_Reference { get; set; }
        public string Noise_Type_Parameter_Ref { get; set; }
        public string Signal_Device_ID_Ref { get; set; }
        public string Status { get; set; }
        public string Device_ID { get; set; }
        public string User_ID { get; set; }
        public System.DateTime Start_Test { get; set; }
        public System.DateTime End_Test { get; set; }
        public System.DateTime Created_Date { get; set; }
        public int Quantity { get; set; }
        public int LotBox_Position_Fukuda { get; set; }
        public int LotBox_Position_Laser { get; set; }
        public string LotBox_ID { get; set; }
        public string Device_Name { get; set; }
        public string Device_Status { get; set; }
        public string Test_Mode_Default { get; set; }
    }
}
