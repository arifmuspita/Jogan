using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_TRANSACTION_CANCEL:BaseColumns
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string PO_Number { get; set; }
        [Required]
        public string Superior_User_ID { get; set; }
        [Required]
        public string User_ID { get; set; }
        public string Reason { get; set; }

        public virtual T_TRANSACTION_INPUT T_TRANSACTION_CANCEL__T_TRANSACTION_INPUT { get; set; }
        public virtual M_USER T_TRANSACTION_CANCEL__M_USER { get; set; }
    }
}
