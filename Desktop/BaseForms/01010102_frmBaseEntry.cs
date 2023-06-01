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
    public partial class frmBaseEntry : Desktop.BaseForms.frmBaseTransactions
    {
        public Type BaseColumnsClass { get; set; }
        
        protected override bool ValidateForm()
        {
            bool ret = true;
            bool isbreak = false;
            if (BaseColumnsClass != null)
            {
                List<Control> c = pnlMain.Controls.OfType<TextBox>().Cast<Control>().ToList();
                foreach (TextBox item in c)
                {
                    TextBox txt = (TextBox)item;
                    string tag = (string)txt.Tag;
                    if (tag != "")
                    {
                        ret = Commons.Commons.IsRequiredField(BaseColumnsClass, tag);
                        if (ret)
                        {
                            if (txt.Text == "") { toolTip.Show("Please fill this field first", txt); ret = false; isbreak = true; break; }
                        }
                    }
                }
                c.Clear();
                if (!isbreak)
                {
                    c = pnlMain.Controls.OfType<ComboBox>().Cast<Control>().ToList();
                    foreach (ComboBox item in c)
                    {
                        ComboBox txt = (ComboBox)item;
                        string tag = (string)txt.Tag;
                        if (tag != "")
                        {
                            ret = Commons.Commons.IsRequiredField(BaseColumnsClass, tag);
                            if (ret)
                            {
                                if (txt.SelectedValue == null) { toolTip.Show("Please choice this field first", txt); ret = false; isbreak = true; break; }
                            }
                        }
                    }
                }
                c.Clear();
            } 
            return ret;
        }
        protected override void OnAfterSave()
        {
            if (FormList != null)
            {
                FormList.RefreshData(true);
                DialogResult result1 = MessageBox.Show("Are you want to add data again ?",
                    "Add Data", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes) { ID = 0; ResetInput(pnlMain); }
            }

        }
        protected virtual void  CheckUserAccess()
        {
            //btnAdd.Enabled = false;
            //btnDelete.Enabled = false;
            //btnEdit.Enabled = false;
            //btnReport.Enabled = false;
            //btnSave.Enabled = false;
            //if (UserProp.User_Group_ID != null)
            //{
            //    if (UserProp.User_Group_ID.ToUpper() != "ADMINISTRATOR")
            //    {
            //        V_USER_GROUP_PRIVILEGES v = DBEntities.V_USER_GROUP_PRIVILEGES.Where(x => x.Group_ID == UserProp.User_Group_ID && x.Module == ModuleName).FirstOrDefault();
            //        if (v != null)
            //        {
            //            btnAdd.Enabled = v.Allow_Add;
            //            btnDelete.Enabled = v.Allow_Delete;
            //            btnEdit.Enabled = v.Allow_Edit;
            //            btnReport.Enabled = v.Allow_Report;
            //            btnSave.Enabled = v.Allow_Add || v.Allow_Edit;
            //        }
            //    }
            //    else
            //    {
            //        btnAdd.Enabled = true;
            //        btnDelete.Enabled = true;
            //        btnEdit.Enabled = true;
            //        btnReport.Enabled = true;
            //        btnSave.Enabled = true;
            //    }
            //}
        }
        protected override void OnFormShown(object sender, EventArgs e)
        {
            base.OnFormShown(sender, e);
            CheckUserAccess();
            //bindSrc.DataSource = DBEntities;
            //Application.DoEvents();
            //OpenData();
        }
        public object ID { get; set; }
        public frmBaseList FormList { get; set; }
        public frmBaseEntry()
        {
            InitializeComponent();
        }

        private void frmBaseEntry_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'jOGANDBDataSet.UserGroups' table. You can move, or remove it, as needed.
            //this.userGroupsTableAdapter.Fill(this.jOGANDBDataSet.UserGroups);

        }
    }
}
