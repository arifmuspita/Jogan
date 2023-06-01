using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms.UserManagement
{
    public partial class frmUserEntry : Desktop.BaseForms.frmBaseEntry
    {
        protected override bool ValidateForm()
        {
            bool ret = base.ValidateForm();
             if (ret)
            {
                M_USER u = DBEntities.M_USERS.Where(x => x.User_ID == txtBagdeNo.Text).FirstOrDefault();
                if (u != null)
                {
                    ret = false;
                    toolTip.Show("Bagde No already exist", txtBagdeNo);
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
            M_USER ug = DBEntities.M_USERS.Where(x => x.User_ID == (string)ID).FirstOrDefault();
            if (ug == null)
            {
                DBEntities.M_USERS.Add(
                    new M_USER
                    {
                        Created_Date = dt,
                        Created_User = UserProp.User_ID,
                        User_ID = txtBagdeNo.Text,
                        Is_Active = true, 
                        Name = txtName.Text,
                        //UserName = txtUserName.Text,
                        Password = Commons.Commons.EncryptMD5(txtPassword.Text), 
                        Group_ID =  (string)cmbGroupID.SelectedValue,
                        Updated_Date = dt,
                        Updated_User = UserProp.User_ID
                    });
            }
            else
            {
                
                ug.Is_Active = chkIsActive.Checked;
                ug.Name = txtName.Text;
                //ug.Password = Commons.Commons.EncryptMD5(txtPassword.Text); ;
                ug.Group_ID = (string)cmbGroupID.SelectedValue;
                ug.Updated_Date = dt;
                ug.Updated_User = UserProp.User_ID;
                DBEntities.Entry(ug).CurrentValues.SetValues(ug);
            }
            DBEntities.SaveChanges();
        }
        protected override void DoOpenData(DBProjectEntities model)
        {
            V_USER_GROUP ug = DBEntities.V_USER_GROUPS.Where(x => x.User_ID == (string)ID).FirstOrDefault();
            txtBagdeNo.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtPassword.Text = "";
            txtUserName.Text = "";
            txtPassword.Enabled = (string)ID == "";
            chkIsActive.Checked = true;
            if (ug != null)
            {
              
                txtName.Text = ug.Name;
                txtPassword.Text = ug.Password; 
                chkIsActive.Checked = ug.Is_Active;
            }

            var ug2 = DBEntities.V_USER_GROUPS.OrderBy(x => x.Group_ID).ToList();
            cmbGroupID.ValueMember = "Group_ID";
            cmbGroupID.DisplayMember = "Group_Name";
            cmbGroupID.DataSource = ug2;
            if (ug != null)
            {
                cmbGroupID.SelectedValue = ug.ID;
            }
        }
        public frmUserEntry()
        {
            InitializeComponent();
        }
    }
}
