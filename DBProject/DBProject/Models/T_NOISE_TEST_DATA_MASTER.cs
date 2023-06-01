using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace DBProject.Models
{
    public class T_NOISE_TEST_DATA_MASTER: T_BASE_MASTER
    { 
        [StringLength(250), Required]
        public string Type_Test { get; set; }
        [ForeignKey("PO_Number")]
        public virtual T_TRANSACTION_INPUT T_NOISE_TEST_DATA_MASTER_T_TRANSACTION_INPUT { get; set; }
    }
}