using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class T_USER_SESSION
    {
       [Key]
       public Int32 ID { get; set; }
        [Required]
        public string User_ID { get; set; }
        [StringLength(500), Required]
        public string Session_ID { get; set; }
        [StringLength(500), Required]
        public string Session_Token { get; set; }
        //public string C1st_Soak_Time { get; set; }
        public virtual M_USER T_USER_SESSIONn_M_USER { get; set; }
    }
}