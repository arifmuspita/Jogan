using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_SORTER_SUMMARY:BaseColumns
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string PO_Number { get; set; }
        [Required]
        public string Jig_ID { get; set; }
        [Required]
        public int Qty_Pass { get; set; }
        [Required]
        public int Qty_Downgrade { get; set; }
        [Required]
        public int Qty_Reject { get; set; }
        [Required]
        public int Qty_NG1 { get; set; }
        [Required]
        public int Qty_NG2 { get; set; }
        [Required]
        public int Qty_NG3 { get; set; }
        [Required]
        public int Qty_NG4 { get; set; }
        [Required]
        public int Qty_NG5 { get; set; }
        [Required]
        public int Qty_NG6 { get; set; }
        [Required]
        public int Qty_NG7 { get; set; }
        [Required]
        public int Qty_NG_Other { get; set; }
        [Required]
        public int Qty_NOD { get; set; }
        [ForeignKey("PO_Number")]
        public virtual T_TRANSACTION_INPUT T_TRANSACTION_INPUT { get; set; }
    }
}
