using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class frmAccesses : Desktop.BaseForms.frmBaseDB
    {
        //this.button1.Click += new System.EventHandler(this.button1_Click);
        
        private void ButtonAccessClick(object sender, EventArgs e)
        {
            string module = (string)((Button)sender).Tag;
            try
            {
                Form form = OpenForm("frm" + module);
                if (form == null) { form= OpenForm("frm" + module + "List"); }
                BaseForms.frmBaseDB formDB = (form as BaseForms.frmBaseDB);
                //formDB.SetUserData(UserID, UserName, UserGroupID, BagdeNo,module);
                formDB.SetUserData(UserProp);
                formDB.ShowDialog();
                //MessageBox.Show("frm" + module);
            }

            catch (DbEntityValidationException ex)
            { 
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage); 
                var fullErrorMessage = string.Join("<br/>", errorMessages); 
                string msg = "The validation errors are: <br/>" + fullErrorMessage;

                MessageBox.Show(msg);
            }
            catch (Exception ee)
            {
                string msg = ee.Message;
                if (ee.InnerException != null)
                {
                    msg = msg + "\r\n"+ ee.InnerException.Message;
                    if (ee.InnerException.InnerException != null)
                    {
                        msg = msg + "\r\n" + ee.InnerException.InnerException.Message;
                    }
                }
                MessageBox.Show(msg);
            }
        }
        private void CreateAccess()
        {
            using (var db = new DBProjectEntities())
            {
                TabPage tp = null;
                TableLayoutPanel panel = null;
                int cch = 0;
                tabAccess.TabPages.Clear();
                if (UserProp.User_Group_ID.ToUpper()=="G-001")
                {
                    var mn = db.M_MENUS.Where(x=>x.Menu_For=="Desktop" && x.Is_Active).OrderBy(x => x.Code);
                    foreach(var item in mn)
                    {
                        if (!item.Detail)
                        {
                            tp = new TabPage(item.Name);
                            tp.Parent = tabAccess;
                            panel = new TableLayoutPanel();
                            panel.Parent = tp;
                            panel.Dock = DockStyle.Fill;
                            panel.ColumnCount = 4;
                            //panel.CellBorderStyle = TableLayoutPanelCellBorderStyle.InsetDouble;
                            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                            panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
                            panel.RowCount = 4;
                            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                            panel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
                            cch = 0;
                        } else
                        {
                            Button btn = new Button() { Text = item.Name, Dock = DockStyle.Fill, Tag = item.Module, };
                            btn.Click += new EventHandler(ButtonAccessClick);
                            panel.Controls.Add(btn, cch, 0);
                            cch++; 
                        }
                    }
                }
            }
        }

        private void frmAccesses_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            CreateAccess();
        }

        public frmAccesses(string userid,string username, string usergroup, string bagdeno)
        {
            UserProp.User_Group_ID = usergroup;
            UserProp.User_Group_Name = "";
            UserProp.User_ID = userid; 
            InitializeComponent();
        }
        public frmAccesses()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AddLoginHistory(DBEntities, UserProp.User_ID, "LOGOUT");
            DBEntities.SaveChanges();
            //UserID = "";
            //UserName = "";
            //UserGroupID = "";
            UserProp = null;
            ShowForm("frmLogin");
            Close();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
