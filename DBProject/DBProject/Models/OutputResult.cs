using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class OutputResult:BaseColumns
    {
        [Required]
        public string PONumber { get; set; }
        [Required]
        public int MasterDeviceID { get; set; }
        [Required]
        public int MasterLotBoxID { get; set; }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int TotalGoodQty { get; set; }
        [Required]
        public int TotalRejectQty { get; set; }
        //[Required]
        //public  int BoxNGID { get; set; }

        //public virtual MasterBoxNG OutputResult_BoxNG { get; set; }
        public virtual M_DEVICE OutputResult_Device { get; set; }
        public virtual MasterLotBox OutputResult_LotBox { get; set; } 
        public virtual M_USER OutputResult_User { get; set; }
    }
}