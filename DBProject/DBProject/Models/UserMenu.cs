using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class UserMenu:BaseColumns2
    {
        public UserMenu() : base()
        {
            AllowAdd = true;
            AllowDelete = true;
            AllowEdit = true;
        }
        [Required]
        public int UserID { get; set; }
        [Required]
        public int MenuID { get; set; }
        [Required]
        public bool AllowRead { get; set; }
        [Required]
        public bool AllowAdd { get; set; }
        [Required]
        public bool AllowDelete { get; set; }
        [Required]
        public bool AllowEdit { get; set; }
        [Required]
        public bool AllowReport { get; set; }
        public virtual M_USER UserMenu_User { get; set; }
        public virtual M_MENU UserMenu_Menu { get; set; }
    }
}