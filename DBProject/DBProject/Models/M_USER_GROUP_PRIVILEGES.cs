using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class M_USER_GROUP_PRIVILEGES : BaseColumns2
    {
        public M_USER_GROUP_PRIVILEGES() : base()
        {
            Allow_Add = true;
            Allow_Delete = true;
            Allow_Edit = true;
            Allow_Export = true;
            Allow_Report = true;
        }
        [Key]
        public int ID { get; set; }
        [Required]
        public string Group_ID { get; set; }  
        [Required]
        public int Menu_ID { get; set; }
        [Required]
        public bool Allow_Read { get; set; }
        [Required]
        public bool Allow_Add { get; set; }
        [Required]
        public bool Allow_Delete { get; set; }
        [Required]
        public bool Allow_Edit { get; set; }
        [Required]
        public bool Allow_Export { get; set; }
        [Required]
        public bool Allow_Report { get; set; }
        public virtual M_USER_GROUP M_USER_GROUP_PRIVILEGES_M_USER_GROUP { get; set; }
        [ForeignKey("Menu_ID")]
        public virtual M_MENU M_USER_GROUP_PRIVILEGES_M_MENU { get; set; }
    }
}
