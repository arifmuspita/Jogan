using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class MasterLotBox:BaseColumns
    {
        [StringLength(50), Required]
        public string LotBoxID { get; set; }
        [StringLength(250), Required]
        public string LotBoxDescription { get; set; }
    }
}