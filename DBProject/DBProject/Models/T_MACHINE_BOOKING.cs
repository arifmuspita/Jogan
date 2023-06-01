using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_MACHINE_BOOKING:BaseColumns
    {
        [Key]
        public Int32 ID { get; set; }
        [Required]
        public string Machine_ID { get; set; }
        [Required]
        public Int32 Booking_ID { get; set; }
        [ForeignKey("Machine_ID")]
        public virtual M_MACHINE_TESTER C { get; set; }
        [ForeignKey("Booking_ID")]
        public virtual T_BOOKING_STATION D { get; set; }
    }
}
