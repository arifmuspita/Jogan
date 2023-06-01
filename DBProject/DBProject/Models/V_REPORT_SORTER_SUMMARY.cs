using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject.Models
{
    public class V_REPORT_SORTER_SUMMARY
    {
        public int ID { get; set; }
        public string PO_Number { get; set; }       
        public byte[] PO_Number_Barcode { get; set; }
        public int Qty_Pass { get; set; }
        public int Qty_Downgrade { get; set; }
        public int Qty_Reject { get; set; }
        public int Qty_NG1 { get; set; }
        public int Qty_NG2 { get; set; }
        public int Qty_NG3 { get; set; }
        public int Qty_NG4 { get; set; }
        public int Qty_NG5 { get; set; }
        public int Qty_NG6 { get; set; }
        public int Qty_NG7 { get; set; }
        public int Qty_NG_Other { get; set; }
        public int Qty_NOD { get; set; }
        public int Quantity { get; set; }
        public string LotBox_ID { get; set; }
        public string LotBox_Laser { get; set; }
        public string LotBox_NG_ID { get; set; }
        public string Device_ID { get; set; }
        public byte[] Device_ID_Barcode { get; set; }
    }
}
