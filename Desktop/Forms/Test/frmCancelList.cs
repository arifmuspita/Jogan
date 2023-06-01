using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms.Test
{
    public partial class frmCancelList : Desktop.BaseForms.frmBaseEntry
    {
        public string PONumber { get; set; }
        protected override bool ValidateForm()
        {
            bool ret = base.ValidateForm();
            if (ret)
            {
                string pass = Commons.Commons.EncryptMD5(txtUserID.Text);
                M_USER u = DBEntities.M_USERS.Where(x => x.User_ID == txtUserID.Text && x.Password == pass).FirstOrDefault();
                if (u != null)
                {
                    ret = false;
                    //toolTip.Show("Bagde No already exist", txtUserID);
                    MessageBox.Show("Your User ID and/or Password invalid");
                }
            }
            return ret;
        }
        protected override void OnFormShown(object sender, EventArgs e)
        {
            BaseColumnsClass = typeof(M_USER);
            base.OnFormShown(sender, e);
        }
        protected override void Transaction(DBProjectEntities model = null)
        {
            DateTime dt = DateTime.Now;

            DBEntities.T_TRANSACTION_CANCELS.Add(
                new T_TRANSACTION_CANCEL
                {
                    Created_Date = dt,
                    Created_User = UserProp.User_ID,
                    User_ID = UserProp.User_ID,
                    Superior_User_ID = txtUserID.Text,
                    PO_Number= PONumber,
                    Reason = txtReason.Text,
                    Updated_Date = dt,
                    Updated_User = UserProp.User_ID
                });
            T_TRANSACTION_INPUT inp = DBEntities.T_TRANSACTION_INPUTS.Where(x => x.PO_Number==PONumber).FirstOrDefault();
            if (inp != null)
            {
                inp.Status = "CANCEL";
                DBEntities.Entry(inp).CurrentValues.SetValues(inp);
            }
            DBEntities.SaveChanges();
        }
        public frmCancelList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
