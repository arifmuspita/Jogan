using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_RESISTANCE_TEST_DATA_MASTER : T_BASE_MASTER
    {
        [ForeignKey("PO_Number")]
        public virtual T_TRANSACTION_INPUT T_RESISTANCE_TEST_DATA_MASTER_T_TRANSACTION_INPUT { get; set; }
    }
}
