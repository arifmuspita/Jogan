using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.BaseControls
{
    public partial class frmAuthCancelTest : Desktop.BaseForms.frmAuthentication
    {
        public string PO_Number { get; set; }
        protected override bool ValidateForm()
        {
            bool ret = base.ValidateForm();
            if (!ret)
            {
                if (txtReason.Text == "") { toolTip.Show("Fill fill Reason first", txtReason); txtReason.Focus(); ret = false; }
            }
            return ret;
        }

        protected override bool Submit(string Desc = "")
        {
           return base.Submit("CANCEL TEST LOGIN");
        }
        protected override void Transaction(DBProjectEntities model = null)
        {
            using (var db = new DBProjectEntities())
            {
                DateTime dt = DateTime.Now;
                T_TRANSACTION_CANCEL cancel = new T_TRANSACTION_CANCEL
                {
                    Created_Date = dt,
                    Created_User = txtUserID.Text,
                    ID = 0,
                    PO_Number = PO_Number,
                    Reason = txtReason.Text,
                    Superior_User_ID = txtUserID.Text,
                    User_ID = UserProp.User_ID,
                    Updated_Date = dt,
                    Updated_User = txtUserID.Text
                };
                db.T_TRANSACTION_CANCELS.Add(cancel);
                db.SaveChanges();
            }
        }
        public frmAuthCancelTest()
        {
            InitializeComponent();
        }
        public frmAuthCancelTest(string userid, string ponumber)
        {
            UserProp.User_ID = userid;
            PO_Number = ponumber;
            InitializeComponent();
        }
    }
}
