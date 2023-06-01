using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class OutputResultRejectDetail:BaseColumns
    {
        [Required]
        public int OutputResultID { get; set; }
        [Required]
        public int MasterJigCarrierID { get; set; }
        [Required]
        public int SocketNumber { get; set; }
        [Required]
        public string Status { get; set; }
        
        public virtual M_JIG OutputResultRejectDetail_JIGCarrier{ get; set; }
        public virtual OutputResult OutputResultRejectDetail_OutputResult { get; set; }
    }
}