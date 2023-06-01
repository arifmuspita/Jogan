using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_ERROR_LIST : BaseColumns
    {
        [Key]
        public int ID { get; set; }
        [StringLength(50)]
        public string Message_Code { get; set; }
        [StringLength(50)]
        public string Hardware_ID { get; set; }
        [StringLength(50)]
        public string Status { get; set; }
        //[StringLength(500)]
        public string Description { get; set; }
        public bool MarkAsDelete { get; set; }
        [ForeignKey("Message_Code")]
        public virtual M_ERROR_LIST A { get; set; }
    }
}
