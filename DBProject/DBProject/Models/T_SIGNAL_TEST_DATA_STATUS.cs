using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_SIGNAL_TEST_DATA_STATUS: T_BASE_TEST_STATUS
    {
        //[Key]
        //public Int32 ID { get; set; }
        //[Required]
        //public string PO_Number { get; set; }
        //[Required]
        //public string Jig_ID { get; set; }
        //[Required]
        //public string Machine_ID { get; set; }
        //public virtual M_JIG T_SIGNAL_TEST_DATA_STATUS_M_JIG { get; set; }
        //public virtual M_MACHINE_TESTER T_SIGNAL_TEST_DATA_STATUS_M_MACHINE_TESTER { get; set; }
        //public virtual T_NOISE_TEST_DATA_MASTER T_SIGNAL_TEST_DATA_STATUS_T_NOISE_TEST_DATA_MASTER { get; set; }
        public virtual T_TRANSACTION_INPUT AA { get; set; }
    }
}
