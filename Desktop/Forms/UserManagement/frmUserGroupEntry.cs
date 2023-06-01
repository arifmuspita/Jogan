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
    public partial class frmUserGroupEntry : Desktop.BaseForms.frmBaseEntry
    {
        protected override bool ValidateForm()
        {
            bool ret = true;
            if (txtGroupID.Text == "") { toolTip.Show("Please fill this first", txtGroupID);  ret = false; }
            if (txtGroupName.Text == "") { toolTip.Show("Please fill this first", txtGroupName); ret = false; }
            return ret;
        }
        protected override void Transaction(DBProjectEntities model = null)
        {
            DateTime dt = DateTime.Now;
            M_USER_GROUP ug = DBEntities.M_USER_GROUPS.Where(x => x.Group_ID == (string)ID).FirstOrDefault();
            if (ug == null) {
                DBEntities.M_USER_GROUPS.Add(
                    new M_USER_GROUP
                    {
                        Created_Date = dt,
                        Created_User = UserProp.User_Name,
                        Group_ID = txtGroupID.Text,
                        Group_Name=txtGroupName.Text,
                       
                        Updated_Date= dt,
                        Updated_User= UserProp.User_Name
                    });
            } else
            {
                ug.Group_ID = txtGroupID.Text;
                ug.Group_Name = txtGroupName.Text; ;
                ug.Updated_Date = dt;
                ug.Updated_User = UserProp.User_ID;
                DBEntities.Entry(ug).CurrentValues.SetValues(ug);
            }
            DBEntities.SaveChanges();
        }
        protected override void DoOpenData(DBProjectEntities model)
        {
            M_USER_GROUP ug = DBEntities.M_USER_GROUPS.Where(x => x.Group_ID == (string)ID).FirstOrDefault();
            txtGroupID.Text = "";
            txtGroupName.Text = "";
            if (ug != null)
            {
                txtGroupID.Text = ug.Group_ID;
                txtGroupName.Text = ug.Group_Name;
            }
        } 
        public frmUserGroupEntry()
        {
            InitializeComponent();
        }
    }
}
