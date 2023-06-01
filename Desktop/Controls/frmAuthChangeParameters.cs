using DBProject.Models;
using Desktop.Forms;
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
    public partial class frmAuthChangeParameters : Desktop.BaseForms.frmAuthentication
    {
        private Control FFocusControl { get; set; }
        private T_TRANSACTION_INPUT TransactionInput { get; set; }
        protected override void OnFormShown(object sender, EventArgs e)
        {
            panelMessage.Parent = this;
            base.OnFormShown(sender, e);            
        }

        protected override bool Submit(string Desc = "")
        {
            return base.Submit("CHANGE PARAMETER LOGIN");
        }
        protected override void Transaction(DBProjectEntities model = null)
        {
            using (var db = new DBProjectEntities())
            {
                DateTime dt = DateTime.Now;
                T_TRANSACTION_INPUT input = db.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == TransactionInput.PO_Number).FirstOrDefault();
                if (input != null)
                {
                    Commons.Commons.CopyProperties(TransactionInput, input);
                    input.Updated_Date = DateTime.Now;
                    db.Entry(input).CurrentValues.SetValues(input);
                    db.SaveChanges();
                }
            }
        }
        public frmAuthChangeParameters()
        {
            InitializeComponent();
        }
        public frmAuthChangeParameters(T_TRANSACTION_INPUT ATransactionInput)
        {
            TransactionInput = ATransactionInput;
            InitializeComponent();
            using (var db = new DBProjectEntities())
            {
                M_DEVICE dvc = db.M_DEVICES.Where(x => x.Device_ID == ATransactionInput.Device_ID).FirstOrDefault();
                txtCurrDeviceID.Text = dvc.Device_ID;
                txtCurrDeviceName.Text = dvc.Device_Name;
            }
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TextBox txtID = txtDeviceID1;
            TextBox txtName = txtDeviceName1;
            string tag = (string)btn.Tag;
            if (tag == "2")
            {
                txtID = txtDeviceID2;
                txtName = txtDeviceName2;
            }
            frmSearchDevice frm = new frmSearchDevice(txtID, txtName, txtCurrDeviceID.Text);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                using (var db = new DBProjectEntities())
                {
                    int cch = 0;
                    if (tag == "1")
                    {
                        cch = db.M_NOISE_DEVICES.Where(x => x.Device_ID == txtID.Text).Count();
                        if (cch == 0) { FFocusControl = txtID; panelMessage.Message = "Noise paramater for device : " + txtID.Text + " not found\r\n\r\nPlease contact your administrator"; }
                        else
                        {
                            M_NOISE_DEVICE noise = DBEntities.M_NOISE_DEVICES.Where(x => x.Device_ID == txtID.Text).FirstOrDefault();
                            txtNoiseParam.Text = noise.Test_Type_ID;
                            TransactionInput.Noise_Type_Parameter_Ref = noise.Test_Type_ID;
                            btnSubmit.Enabled = true;
                        }

                    }
                    if (tag == "2")
                    {
                        cch = db.M_SIGNAL_DEVICE_PARAMETERS.Where(x => x.Device_ID == txtID.Text).Count();
                        if (cch == 0) { FFocusControl = txtID; panelMessage.Message = "Signal paramater for device : " + txtID.Text + " not found\r\n\r\nPlease contact your administrator"; }
                        else
                        {
                            TransactionInput.Signal_Device_ID_Ref = txtID.Text;
                            btnSubmit.Enabled = true;
                        }
                    }
                }
            }
        }

        private void panelMessage_OnCloseClick(object sender, EventArgs e)
        {
            if (FFocusControl != null) FFocusControl.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
