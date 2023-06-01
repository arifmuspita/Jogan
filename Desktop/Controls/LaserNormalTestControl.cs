using Commons;
using DBProject.Models;
using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controls
{
    public partial class LaserNormalTestControl : Desktop.BaseControls.BaseControl
    {
        public override event EventMachineBook OnTransactionMachineBook;
        public bool FAllowChange { get; set; }

        // private bool FISDowngrade;
        //public bool ISDowngrade { get { return FISDowngrade; } set { FISDowngrade = value; } }

        protected override void Transaction(DBProjectEntities model = null)
        {
            //T_TRANSACTION_INPUT inp = model.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == txtPONumber.Text).FirstOrDefault();
            //if (inp != null)
            //{
            //    DateTime dt = DateTime.Now;
            //    TransactionSorter.PO_Number = txtPONumber.Text;
            //    TransactionSorter.Created_Date = dt;
            //    TransactionSorter.Created_User = User_ID;
            //    TransactionSorter.Device_ID = inp.Device_ID;
            //    TransactionSorter.LotBox_Position = LotboxPosition;
            //    TransactionSorter.Quantity = Convert.ToInt32(txtQuantity.Text);
            //    TransactionSorter.Updated_Date = dt;
            //    TransactionSorter.Updated_User = User_ID;
            //}
            DateTime dt = DateTime.Now;
            //model.T_TRANSACTION_SORTERS.Add(TransactionSorter);
            T_LASER_STATION ls = new T_LASER_STATION
            {
                Created_Date = dt,
                Created_User = UserID,
                ID = 0,
                LotBox_ID = txtLotBoxID.Text,
                LotBox_NG_ID = txtLotBoxNGID.Text,
                LotBox_Position = LotboxPosition,
                Status = "READY",
                Updated_Date = dt,
                Updated_User = UserID,
                Is_Downgrade = chkDowngrade.Checked
            };
            model.T_LASER_STATIONS.Add(ls);
        }

        protected override bool SetReadyClick(object sender, EventArgs e)
        {
            return SaveData(false, false, pnlMain);
        }

        private void placeholderTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        public LaserNormalTestControl()
        {
            InitializeComponent();
            FAllowChange = true;
        }

        private void chkDowngrade_CheckedChanged(object sender, EventArgs e)
        {
            //if (!FAllowChange) return;
            //txtLotBoxNGID.Enabled = chkDowngrade.Checked;
            //if (!DesignMode)
            //{
            //    if (chkDowngrade.Checked)
            //    {
            //        using (var db = new DBProjectEntities())
            //        {
            //            T_TRANSACTION_INPUT inp = db.T_TRANSACTION_INPUTS.Where(x => x.Status == "READY" && x.Default_Test_Mode == "Downgrade").FirstOrDefault();
            //            if (inp == null)
            //            {
            //                panelMessage.Message = "None of ready PO Numbers on fukuda side for Downgrade Test";
            //                FAllowChange = false;
            //                chkDowngrade.Checked = false;
            //                FAllowChange = true;
            //            }
            //        }
            //    }
            //}
        }
    }
}

