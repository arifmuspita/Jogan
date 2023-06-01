using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace DBProject.Models
{
    public class T_NOISE_TEST_DATA_DETAIL: T_BASE_TEST_DETAIL
    {
         
        //public virtual T_NOISE_TEST_DATA_MASTER T_NOISE_TEST_DATA_DETAIL_T_NOISE_TEST_DATA_MASTER { get; set; }
        public virtual T_TRANSACTION_INPUT AA { get; set; }
    }
}