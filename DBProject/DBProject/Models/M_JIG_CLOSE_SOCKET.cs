using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class M_JIG_CLOSE_SOCKET: BaseCloseSocket
    {
        [Key]
        public Int32 ID { get; set; }
        public string Jig_ID { get; set; }
        //public int Jig_ID2 { get; set; }
        public virtual M_JIG M_JIG_CLOSE_SOCKET__M_JIG { get; set; }
    }
}
