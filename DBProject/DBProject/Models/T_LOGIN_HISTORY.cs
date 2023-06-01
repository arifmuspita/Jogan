using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_LOGIN_HISTORY:BaseColumns
    {
        [Key]
        public Int32 ID { get; set; }
        [Required]
        public string User_ID { get; set; }
        [Required]
        public DateTime Login_Date { get; set; }

        public string Description { get; set; }
        public virtual M_USER T_LOGIN_HISTORY_M_USER { get; set; }
    }
}
