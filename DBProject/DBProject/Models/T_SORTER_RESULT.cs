using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class T_SORTER_RESULT: T_BASE_TEST_STATUS
    {
        [ForeignKey("PO_Number")]
        public virtual T_TRANSACTION_INPUT T_TRANSACTION_INPUT { get; set; }
    }
}
