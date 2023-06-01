using DBProject.Models;
using Desktop.Controls;
using Desktop.DesktopProperties;
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
    public partial class frmInputTestData2 : Desktop.BaseForms.frmBaseTwinCAT
    {
        private List<TabPage> ListTabPage;
        private bool AllowChangeNormal { get; set; }
        private bool AllowChangeAQL { get; set; }
        protected override void OnFormShown(object sender, EventArgs e)
        {
            base.OnFormShown(sender, e); 
            tabControlNormalTest.SelectedIndex = 0;

            fukudaNormalTestControl1.UserID = UserProp.User_ID;
            fukudaNormalTestControl2.UserID = UserProp.User_ID;
            fukudaNormalTestControl3.UserID = UserProp.User_ID;
            fukudaNormalTestControl4.UserID = UserProp.User_ID;

            fukudaAQLTestControl1.UserID = UserProp.User_ID;
            fukudaAQLTestControl2.UserID = UserProp.User_ID;
            fukudaAQLTestControl3.UserID = UserProp.User_ID;
            fukudaAQLTestControl4.UserID = UserProp.User_ID;

            fukudaDowngradeTestControl1.UserID = UserProp.User_ID;
            fukudaDowngradeTestControl2.UserID = UserProp.User_ID;
            fukudaDowngradeTestControl3.UserID = UserProp.User_ID;
            fukudaDowngradeTestControl4.UserID = UserProp.User_ID; 
        }
        public frmInputTestData2()
        {
            InitializeComponent();
            AllowChangeNormal = true;
            AllowChangeAQL = true;
            ListTabPage = new List<TabPage>();
            ListTabPage.Add(tabPageNormal);
            ListTabPage.Add(tabPageDowngrade);
            ListTabPage.Add(tabPageAQL);
        }

        private void tabControlAQLTest_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = tabControlAQLTest.SelectedIndex;
            FukudaAQLTestControl aql = null;
            switch (idx)
            {
                case 0: aql = fukudaAQLTestControl1; break;
                case 1: aql = fukudaAQLTestControl2; break;
                case 2: aql = fukudaAQLTestControl3; break;
                case 3: aql = fukudaAQLTestControl4; break;
            }
            aql.GenerateAQLCode(idx + 1);
        }

        //private void tabAQL_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        private void tabControlNormalTest_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = AllowChangeNormal;
        }

        private void tabControlAQLTest_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = AllowChangeAQL;
        } 

        private void txtDeviceID_TextChanged(object sender, EventArgs e)
        {
            using (var db = new DBProjectEntities())
            {
                tabTestMode.SuspendLayout();
                tabTestMode.TabPages.Remove(tabPageNormal);
                tabTestMode.TabPages.Remove(tabPageAQL);
                tabTestMode.TabPages.Remove(tabPageDowngrade);

                tabTestMode.TabPages.Insert(0, tabPageDowngrade);
                tabTestMode.TabPages.Insert(0, tabPageAQL);
                tabTestMode.TabPages.Insert(0, tabPageNormal);
                M_DEVICE dvc = db.M_DEVICES.Where(x => x.Device_ID == txtDeviceID.Text).FirstOrDefault();
                if (dvc == null)
                {
                    MessageBox.Show("Device " + txtDeviceID.Text + " not found\r\nPleace contact your administrator");
                }
                else
                {
                    int idx = tabControlAQLTest.SelectedIndex;
                    FukudaNormalTestControl aql1 = null;
                    FukudaAQLTestControl aql2 = null;


                    if (dvc.Test_Mode_Default == "Normal")
                    {
                        tabTestMode.TabPages.Remove(tabPageAQL);
                        tabTestMode.TabPages.Remove(tabPageDowngrade);

                        switch (idx)
                        {
                            case 0: aql1 = fukudaNormalTestControl1; break;
                            case 1: aql1 = fukudaNormalTestControl2; break;
                            case 2: aql1 = fukudaNormalTestControl3; break;
                            case 3: aql1 = fukudaNormalTestControl4; break;
                        }
                        aql1.DeviceID = txtDeviceID.Text;
                    }
                    if (dvc.Test_Mode_Default == "AQL")
                    {
                        tabTestMode.TabPages.Remove(tabPageDowngrade);
                        tabTestMode.TabPages.Remove(tabPageNormal);

                        switch (idx)
                        {
                            case 0: aql2 = fukudaAQLTestControl1; break;
                            case 1: aql2 = fukudaAQLTestControl2; break;
                            case 2: aql2 = fukudaAQLTestControl3; break;
                            case 3: aql2 = fukudaAQLTestControl4; break;
                        }
                        aql2.DeviceID = txtDeviceID.Text;
                    }
                    if (dvc.Test_Mode_Default == "Downgrade")
                    {
                        tabTestMode.TabPages.Remove(tabPageNormal);
                        tabTestMode.TabPages.Remove(tabPageAQL);
                    }
                    txtDeviceName.Text = dvc.Device_Name;
                }
                tabTestMode.ResumeLayout();
            }
        }

        private void txtLotboxID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
