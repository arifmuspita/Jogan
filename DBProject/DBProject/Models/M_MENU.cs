using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class M_MENU:BaseColumns2
    {
        public M_MENU()
        {
            Module_Parent = "";
            Detail = false;
            Module = "";
            Menu_For = "";
        }
        [Key]
        public int ID { get; set; }
        public int? Parent_ID { get; set; }
        public bool Detail { get; set; }
        [StringLength(100), Required]
        public string Module { get; set; }
        [StringLength(100), DefaultValue("")]
        public string Module_Parent { get; set; }
        [StringLength(100), Required, DefaultValue(""),]
        public string Menu_For { get; set; }
        public int? Image_Index { get; set; }
        //[Required]
        //public bool Is_Active { get; set; }
    }
}