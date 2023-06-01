using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.BaseForms
{
    public partial class frmAuthentication : Desktop.BaseForms.frmBaseDB
    {
        public event EventHandler OnSubmitSucceed;
        public event EventHandler OnSubmitFail;
        protected override bool ValidateForm()
        {
            bool ret = true;
            if (txtUserID.Text == "") { toolTip.Show("Fill fill User ID first", txtUserID); txtUserID.Focus(); ret = false; }
            if (txtPassword.Text == "") { toolTip.Show("Fill fill Password first", txtPassword); txtPassword.Focus(); ret = false; }
            //if (txtReason.Text == "") { toolTip.Show("Fill fill Reason first", txtReason); txtReason.Focus(); ret = false; }
            return ret;
        }

        protected virtual bool Submit(string Desc="")
        {
            bool ret = true;
            if (Desc == "") Desc = "LOGIN";
            using (var db = new DBProjectEntities())
            {
                string pass = Commons.Commons.EncryptMD5(txtPassword.Text);
                M_USER u = db.M_USERS.Where(x => x.User_ID == txtUserID.Text && x.Password == pass).FirstOrDefault();
                if (u == null)
                {
                    ret = false;
                    AddLoginHistory(db, txtUserID.Text, Desc +" FAILED");
                }
                else
                {
                    AddLoginHistory(db, txtUserID.Text, Desc + " FAILED");
                }
                db.SaveChanges();
            }
            return ret;
        }
        public frmAuthentication()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (Submit())
                {
                    if (SaveData(true, false))
                    {
                        if (OnSubmitSucceed != null) { OnSubmitSucceed(sender, e); }
                    }
                    else
                    {
                        if (OnSubmitFail != null) { OnSubmitFail(sender, e); }
                    }
                    Close();
                }
            }
        }
    }
}
