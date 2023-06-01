using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace DBProject.Models
{
    public class M_USER : BaseColumns
    {
        [Key]
        public string User_ID { get; set; }
        [Required]
        public string Group_ID { get; set; }
        [StringLength(250), Required]
        public string Name { get; set; }
        [StringLength(250), Required]
        public string Password { get; set; }
        [Required]
        public bool Is_Active { get; set; }
        public virtual M_USER_GROUP M_USER_M_USER_GROUP { get; set; }
    }
}