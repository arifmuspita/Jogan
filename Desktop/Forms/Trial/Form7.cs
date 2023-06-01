using Commons;
using DBProject.Models;
using Desktop.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Trial
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        private void SearchPONumber()
        {
            using (var db = new DBProjectEntities())
            {
                T_TRANSACTION_INPUT inp = db.T_TRANSACTION_INPUTS.Where(x => x.LotBox_ID == txtLotBoxID.Text && x.Status == "QUEUE").FirstOrDefault();
                if (inp == null)
                {
                    MessageBox.Show("PO Number for this LotBox ID : " + txtLotBoxID.Text + " not found");
                }
                else
                {
                    fukudaNormalTestControl1.TransactionInput = inp;
                    fukudaNormalTestControl1.DeviceID = inp.Device_ID;
                    fukudaNormalTestControl1.PONumber = inp.PO_Number;
                    fukudaNormalTestControl1.LotBoxID = inp.LotBox_ID;
                    fukudaNormalTestControl1.Quantity = inp.Quantity.ToString();
                    fukudaNormalTestControl1.AQLReference = inp.AQL_Reference;
                }
            }
        }  
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPONumber();
        }

        private void fukudaNormalTestControl1_OnTransactionMachineBook(object sender, TransactionMachineState e)
        {
            //if (e.Machine_Type == "NOISE")
            //{
            //    if (e.Machine_Number == 1) e.Status = DesktopProperties.MachineState.msOff;
            //    if (e.Machine_Number == 2) e.Status = DesktopProperties.MachineState.msOn;
            //    if (e.Machine_Number == 3) e.Status = DesktopProperties.MachineState.msOn;
            //    if (e.Machine_Number == 4) e.Status = DesktopProperties.MachineState.msOn;
            //    if (e.Machine_Number == 5) e.Status = DesktopProperties.MachineState.msOn;
            //    if (e.Machine_Number == 6) e.Status = DesktopProperties.MachineState.msOn;
            //    if (e.Machine_Number == 7) e.Status = DesktopProperties.MachineState.msOff;
            //    if (e.Machine_Number == 8) e.Status = DesktopProperties.MachineState.msOn;
            //}
            //if (e.Machine_Type == "RESISTANCE")
            //{
            //    if (e.Machine_Number == 1) e.Status = DesktopProperties.MachineState.msOff;
            //    if (e.Machine_Number == 2) e.Status = DesktopProperties.MachineState.msOn;
            //}
        }
    }
}
