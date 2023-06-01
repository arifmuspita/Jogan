using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class MasterBoxNG:BaseColumns
    {
        [StringLength(50), Required]
        public string BoxNGID { get; set; }
    }
}