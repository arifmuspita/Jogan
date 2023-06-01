using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class M_BOOKING_STATION : BaseColumns
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Noise_Room_Number { get; set; }
        [Required]
        public int Signal_Room_Number { get; set; }
        [Required]
        public int Resistance_Room_Number { get; set; }
        [Required]
        public int Line_Number { get; set; }
    }
}
