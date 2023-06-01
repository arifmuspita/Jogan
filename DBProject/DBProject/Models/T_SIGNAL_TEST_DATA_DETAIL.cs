using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class T_SIGNAL_TEST_DATA_DETAIL : T_BASE_TEST_DETAIL
    {
        //    [Key]
        //    public Int32 ID { get; set; }
        //    [Required]
        //    public string PO_Number { get; set; }
        //    [Required]
        //    public string Jig_ID { get; set; }
        //    [Required]
        //    public string Machine_ID { get; set; }

        //    public virtual M_JIG T_SIGNAL_TEST_DATA_DETAIL_M_JIG { get; set; }
        //    public virtual M_MACHINE_TESTER T_SIGNAL_TEST_DATA_DETAIL_M_MACHINE_TESTER { get; set; }
        [Required]
        public double Cooling_Plate_Temperature { get; set; }
        //public virtual T_SIGNAL_TEST_DATA_MASTER T_SIGNAL_TEST_DATA_DETAIL_T_SIGNAL_TEST_DATA_MASTER { get; set; }
        public virtual T_TRANSACTION_INPUT AA { get; set; }
        //[Required]
        //public string TypeTest { get; set; }
        //[Required]
        //public int LotBoxID { get; set; }
        //[Required]
        //public DateTime Date { get; set; }

    }
}