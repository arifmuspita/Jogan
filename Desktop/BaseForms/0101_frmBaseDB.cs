using DBProject.Models; 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;

namespace Desktop.BaseForms
{
   
    public partial class frmBaseDB : frmBase
    {
        private UserProp FUserProp;
        [Browsable(false)]
        public UserProp UserProp
        {
            get
            {
                if (FUserProp == null) FUserProp = new UserProp();
                return FUserProp;
            }
            set { FUserProp = value; }
        }
        protected virtual void ResetInput(Control ParentControl)
        {
            List<Control> c = ParentControl.Controls.OfType<TextBox>().Cast<Control>().ToList();
            foreach (TextBox item in c)
            {
                TextBox txt = (TextBox)item;
                txt.Text = "";
            }
            c = ParentControl.Controls.OfType<ComboBox>().Cast<Control>().ToList();
            foreach (ComboBox item in c)
            {
                ComboBox txt = (ComboBox)item;
                txt.SelectedIndex = 0;
            }
        }
        protected override void OnFormShown(object sender, EventArgs e)
        {
            FDBEntities = new DBProjectEntities();
            base.OnFormShown(sender, e);
            Application.DoEvents();
            OpenData();
        }
        protected virtual void DoOpenData(DBProjectEntities model = null)
        {
        }
        private void OpenData(int id = -1)
        {
            DoOpenData(FDBEntities);
            //if (id == -1)
            //{
            //    using (var db = new DBProjectEntities())
            //    {
            //        DoOpenData(db);
            //    }
            //}
        }
        protected virtual void Transaction(DBProjectEntities model = null)
        {

        }
        protected virtual bool ValidateForm()
        {
            return true;
        }

        protected bool SaveData(bool SkipValidate = false, bool ShowMassage = true)
        {
            bool ret = false;
            if (ValidateForm() || SkipValidate)
            {
                try
                {
                    using (TransactionScope trans = new TransactionScope())
                    {
                        using (var db = new DBProjectEntities())
                        {
                            Transaction(db);
                            db.SaveChanges();
                            ret = true;
                        }
                        trans.Complete();
                        if (ShowMassage) { MessageBox.Show("Success update/insert/delete data"); }
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("<br/>", errorMessages);

                    // Combine the original exception message with the new one.
                    //var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                    string msg = "The validation errors are: <br/>" + fullErrorMessage;
                    if (ShowMassage)
                    { MessageBox.Show("Error while update/insert/delete data.\r\nError description : \r\n" + msg); }
                    ret = false;
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    if (e.InnerException != null)
                    {
                        msg = msg + "<br/>" + e.InnerException.Message;
                        if (e.InnerException.InnerException != null)
                        {
                            msg = msg + "<br/>" + e.InnerException.InnerException.Message;
                        }
                    }
                    if (ShowMassage)
                    { MessageBox.Show("Error while update/insert/delete data.\r\nError description : \r\n" + msg); }
                    ret = false;
                }
            }
            return ret;
        }

        public virtual void SetUserData(string userid, string username, string usergroup, string bagdeno, string modulename = "")
        {
            //BagdeNo = "";
            //UserID = userid;
            //UserGroupID = usergroup;
            //UserName = username;
            //ModuleName = modulename;
            UserProp.User_Group_ID = usergroup;
            UserProp.User_Group_Name = "";
            UserProp.User_ID = userid;
            UserProp.Module_Name = modulename;
        }
        public virtual void SetUserData(UserProp AUserProp)
        {
            UserProp = AUserProp;
        }
        public delegate void OnOpenForm(Form sender);
        public Form OpenForm(string FormName, Form AMDIParent, Size ASize, UserProp AUserProp, OnOpenForm AOnOpenForm=null)
        {
            var _formName = (from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                             where t.Name.Equals(FormName)
                             select t.FullName).Single();
            Form frm = (Form)Activator.CreateInstance(Type.GetType(_formName));
            if (ASize.Width!=0) frm.Width = ASize.Width;
            if (ASize.Height!=0) frm.Height = ASize.Height;
            if (frm is frmBaseDB) { (frm as frmBaseDB).UserProp = AUserProp; }
            if (AMDIParent != null)
            {
                frm.MdiParent = AMDIParent;
                frm.Show();
            }
            else {
                if (AOnOpenForm != null) AOnOpenForm(frm);
                frm.ShowDialog();
            }
            return frm;
        }
        public Form OpenForm(string FormName)
        {
            var _formName = (from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                             where t.Name.Equals(FormName)
                             select t.FullName).Single();
            return (Form)Activator.CreateInstance(Type.GetType(_formName));

        }
        private bool FExitProc;
        [Browsable(false)]
        public bool ExitProc
        {
            get { return FExitProc; }
            set { FExitProc = value; }
        }
        //[Browsable(false)]
        //public string BagdeNo { get; set; }
        //[Browsable(false)]
        //[Browsable(false)]
        //public string UserGroupID { get; set; }
        //[Browsable(false)]
        //public string UserName { get; set; }
        [Browsable(false)]
        public string ModuleName { get; set; }
        //public string UserID { get; set; }
        private DBProjectEntities FDBEntities;
        [Browsable(false)]
        public DBProjectEntities DBEntities
        {
            get { if (FDBEntities == null) { FDBEntities = new DBProjectEntities(); } return FDBEntities; }
        }
        public frmBaseDB()
        {
            InitializeComponent();
        }
        protected override void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            FDBEntities.Dispose();
        }
        public void AddLoginHistory(DBProjectEntities DB, string UserID, string Desc)
        {
            DateTime dt = DateTime.Now;
            T_LOGIN_HISTORY lh = new T_LOGIN_HISTORY
            {
                Created_Date = dt,
                Created_User = UserID,
                Login_Date = dt,
                User_ID = UserID,
                Description = Desc,
                ID = 0
            };
            DB.T_LOGIN_HISTORIES.Add(lh);
            //DB.SaveChanges();
        }
    }
}
