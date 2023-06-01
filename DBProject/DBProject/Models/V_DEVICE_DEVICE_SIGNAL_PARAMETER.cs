using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class V_DEVICE_DEVICE_SIGNAL_PARAMETER
    {
        public int ID { get; set; }
        public string Device_Name { get; set; }
        public string Device_ID { get; set; }
        public double No_DUT_Offset { get; set; }
        public double Offset_Min { get; set; }
        public double Offset_Max { get; set; }
        public double Offset_HLimit { get; set; }
        public double Offset_Grp_Min { get; set; }
        public double Offset_Grp_Max { get; set; }
        public double No_Response { get; set; }
        public double Response_Min { get; set; }
        public double Response_Max { get; set; }
        public double Response_Grp_Min { get; set; }
        public double Response_Grp_Max { get; set; }
        public double Match_Correlation_Factor { get; set; }
        public Nullable<double> Match_Signal_Max { get; set; }
        public double Resistance_Min { get; set; }
        public int First_Soak_Time { get; set; }
        public int Second_Soak_Time { get; set; }
        public int Lauda_Setting { get; set; }
        public int BB_Setting { get; set; }
        public int BB_Temperature_HL { get; set; }
        public int BB_Temperature_LL { get; set; }
        public int Sample_Rate { get; set; }
        public double High_Cutof_Frequency { get; set; }
        public double Low_Cutof_Frequency { get; set; }
        public int Measurement_Duration { get; set; }
        public double Measurement_Duration_2 { get; set; }
        public double Temperature_Coe { get; set; }
        public double Testing_Voltage { get; set; }
        public double Resistance { get; set; }
        public string Created_User { get; set; }
        public System.DateTime Created_Date { get; set; }
        public string Updated_User { get; set; }
        public System.DateTime Updated_Date { get; set; }

    }
}
