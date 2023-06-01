using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class V_BOOKING_ROOM_MACHINE
    {
        public int ID { get; set; }
        public int Line_Number { get; set; }
        public int Noise_Room_Number { get; set; }
        public string Machine_Noise { get; set; }
        public int Signal_Room_Number { get; set; }
        public string Machine_Signal { get; set; }
        public int Resistance_Room_Number { get; set; }
        public string Machine_Resistance { get; set; }
    }
}
