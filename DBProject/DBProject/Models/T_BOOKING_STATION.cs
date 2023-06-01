using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_BOOKING_STATION : BaseColumns
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Queue_ID { get; set; }

        [Required]
        public int Noise_Room_Number { get; set; }
        [Required]
        public bool ByPassTestNoise { get; set; }
        [Required]
        public int Signal_Room_Number { get; set; }
        [Required]
        public bool ByPassTestSignal { get; set; }
        [Required]
        public int Resistance_Room_Number { get; set; }
        [Required]
        public bool ByPassTestResistance { get; set; }
        [Required]
        public string PO_Number { get; set; }
        [Required]
        public string Device_ID { get; set; }
        [Required]
        public string Jig_ID { get; set; }
        [Required]
        public string Close_Socket_Numbers { get; set; }
        [Required]
        public string Status { get; set; }
        //public int? T_QUEUE_ROOM__M_QUEUE_ROOM_ID { get; set; }
        [Required]
        public int Device_Qty { get; set; }
        [ForeignKey("Queue_ID")]
        public virtual M_BOOKING_STATION T_QUEUE_ROOM__M_QUEUE_ROOM { get; set; }
        public virtual T_TRANSACTION_INPUT T_TRANSACTION__M_QUEUE_ROOM { get; set; }
        public virtual M_DEVICE T_TRANSACTION_DEVICE__M_DEVICES { get; set; }
    }
}
