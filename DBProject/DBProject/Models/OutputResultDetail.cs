using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class OutputResultDetail:BaseColumns
    {
        [Required]
        public int OutputResultID { get; set; }
        [Required]
        public int MasterJigCarrierID { get; set; }
        [Required]
        public int GoodQty { get; set; }
        [Required]
        public int RejectNG1Qty { get; set; }
        [Required]
        public int RejectNG2Qty { get; set; }
        [Required]
        public int RejectNG3Qty { get; set; }
        [Required]
        public int RejectNG4Qty { get; set; }
        [Required]
        public int RejectNG5Qty { get; set; }
        [Required]
        public int NODQty { get; set; }

        public virtual M_JIG OutputResultDetail_JIGCarrier { get; set; }
        public virtual OutputResult OutputResultDetail_OutputResult { get; set; }
    }
}