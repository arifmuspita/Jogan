using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_TRANSACTION_LASER: T_BASE_TRANSACTION
    {
        public int LotBox_Position { get; set; }
        [Required]
        public int Quantity { get; set; }
        [StringLength(100)]
        public string LotBox_ID { get; set; }
        [StringLength(100)]
        public string LotBox_NG_ID { get; set; }
        //public virtual M_DEVICES BaseTransaction__M_DEVICES { get; set; }
        //public virtual M_USER BaseTransaction__M_USER { get; set; }
    }
}
