using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class M_JIG : BaseColumns
    {
        [  Key]
        public string Jig_ID { get; set; }
        //[StringLength(250), Required]
        //public string JigDescription { get; set; }
        [StringLength(250), Required]
        public string Jig_Carrier_Name{ get; set; }
    }
}