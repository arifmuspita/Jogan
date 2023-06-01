
using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public enum LoginStatus { lsSucceed,lsFail};
    public delegate void LoginHandler(object sender, UserProp AUserProp, LoginStatus ALoginStatus);
    public partial class frmLogin : Desktop.BaseForms.frmBaseDB
    {
        public event LoginHandler OnLogin;
        //public event EventHandler OnLoginFail;
        public Form MainForm { get; set; }
        protected override void OnCloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        { 
            using (var db = new DBProjectEntities())
            {
                string pass = Commons.Commons.EncryptMD5(txtPasswd.Text);
                M_USER u = db.M_USERS.Where(x => x.User_ID == txtBadgeNo.Text && x.Password == pass).FirstOrDefault();
                if (u == null)
                {
                    AddLoginHistory(db,txtBadgeNo.Text, "LOGIN FAILED");
                    MessageBox.Show("Your Username and/or Password not valid.\r\nPlease Try Again");
                    if (OnLogin != null) OnLogin(this, UserProp, LoginStatus.lsFail);
                }
                else
                {
                    UserProp.User_Group_ID = u.Group_ID;
                    UserProp.User_Group_Name = "";
                    UserProp.User_ID = u.User_ID;
                    UserProp.User_Name = u.Name;
                    //BagdeNo = "";
                    //UserID = u.User_ID;
                    //UserGroupID = u.Group_ID;
                    //UserName = u.Name;

                    if (SaveData(true, false))
                    {
                        txtBadgeNo.Text = "";
                        txtPasswd.Text = "";
                        if (OnLogin != null) OnLogin(this, UserProp,LoginStatus.lsSucceed);
                        Close();
                        //frmAccesses frm = new frmAccesses(UserID, UserName, UserGroupID, BagdeNo);
                        ////frm.CreateAccess();
                        //frm.ShowDialog();
                        
                    }
                }
                
            }
        }
        protected override void Transaction(DBProjectEntities model=null)
        { 
            AddLoginHistory(DBEntities,UserProp.User_ID, "NORMAL LOGIN");
            DBEntities.SaveChanges();
        }
        public frmLogin()
        {
            InitializeComponent();
        }

        public frmLogin(Form AMainForm)
        {
            MainForm = AMainForm;
            InitializeComponent();
        }

        private void frmLogin_Resize(object sender, EventArgs e)
        {
            gbLogin.Width = (pnlMain.Width - 40);
            gbLogin.Top = (pnlMain.Height - gbLogin.Height) / 2;
            gbLogin.Left = (pnlMain.Width - gbLogin.Width) / 2;
        }
    }
}
