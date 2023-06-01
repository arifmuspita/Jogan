using Commons;
using DBProject.Models;
using Desktop.Controls;
using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwinCAT.Ads;
using Utilities;

namespace Desktop.Forms.Test
{
    public partial class frmInputTestData : Desktop.BaseForms.frmBaseTwinCAT
    {
        private List<TabPage> ListTabPage;
        private bool AllowChangeSelecting { get; set; }
        private bool AllowChangeSelectingStation { get; set; }

        private int FSelectedTab;
        public int SelectedTab
        {
            get { return FSelectedTab; }
            set { SetSelectedTab(value); }
        }

        private void SetSelectedTab(int value)
        {
             if (value<0 || value > (tabControlStations.TabPages.Count-1))
            {
                MessageBox.Show("Index out range (0-"+ (tabControlStations.TabPages.Count - 1).ToString()+")");
            } else
            {
                
                AllowChangeSelectingStation = false; tabControlStations.SelectedIndex = value; AllowChangeSelectingStation = true;
            }
        }

        protected override void OnFormLoad(object sender, EventArgs e)
        {
            base.OnFormLoad(sender, e);
            //txtLotBoxID.Text = "LB0000000006";
            //tabControlNormalTest.SelectedIndex = 0;

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

            NetID = ConfigurationManager.AppSettings["TwinCatNetID"];
            //TwinCat3Utility.AllowConnect = true;
            //TwinCat3Utility.ConnectPLC(NetID);
            //TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_1", tabPageStation1);
            //TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_2", tabPageStation2);
            //TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_3", tabPageStation3);
            //TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_4", tabPageStation4);
            //TwinCat3Utility.TwinCat3Client.AdsNotification += new AdsNotificationEventHandler(OnNotification);
            //MessageBox.Show(Height.ToString() + "\r\n" + Width.ToString());
        }
        protected override void CreateToolStripButton(bool CreateDefaultButton = true)
        {
            base.CreateToolStripButton(false);
        }
        private void OnNotification(object sender, AdsNotificationEventArgs e)
        {
            TwinCat3Property prop = TwinCat3Utility.TwinCat3PropertyList.Where(x => x.DeviceNotificationHandle == e.NotificationHandle).FirstOrDefault();
            if (prop != null)
            {
                int idx = -1;
                bool val = false;
                val = TwinCat3Utility.BinaryReader.ReadBoolean();
                TabPage tp = (TabPage)prop.DataObject1;
                if (!val) {
                    AllowChangeSelectingStation = false; tabControlStations.SelectedTab = tp; AllowChangeSelectingStation = true;  }
            }
        }
        public frmInputTestData()
        {
            InitializeComponent();
            AllowChangeSelecting = true; AllowChangeSelectingStation = true;

            //FormBorderStyle fbs = FormBorderStyle.None;
            comboBox1.Items.Add("None");
            comboBox1.Items.Add("FixedSingle");
            comboBox1.Items.Add("Fixed3D");
            comboBox1.Items.Add("FixedDialog");
            comboBox1.Items.Add("Sizable");
            comboBox1.Items.Add("FixedToolWindow");
            comboBox1.Items.Add("SizableToolWindow"); 
        }

        private void SearchPONumber()
        {
            using (var db = new DBProjectEntities())
            {
                T_TRANSACTION_INPUT inp = db.T_TRANSACTION_INPUTS.Where(x => x.LotBox_ID == txtLotBoxID.Text && x.Status == "QUEUE").FirstOrDefault();
                if (inp == null)
                {
                    MessageBox.Show("PO Number for this LotBox ID : " + txtLotBoxID.Text + " not found");
                }
                else
                {

                    TabControl tc = null;
                    FukudaNormalTestControl fntc = null;
                    FukudaAQLTestControl fatc = null;
                    FukudaDowngradeTestControl fdtc = null;
                    switch (tabControlStations.SelectedIndex)
                    {
                        case 0:
                            tc = tabControlStation1;
                            fntc = fukudaNormalTestControl1;
                            fatc = fukudaAQLTestControl1;
                            fdtc = fukudaDowngradeTestControl1;
                            break;
                        case 1:
                            tc = tabControlStation2;
                            fntc = fukudaNormalTestControl2;
                            fatc = fukudaAQLTestControl2;
                            fdtc = fukudaDowngradeTestControl2;
                            break;
                        case 2:
                            tc = tabControlStation3;
                            fntc = fukudaNormalTestControl3;
                            fatc = fukudaAQLTestControl3;
                            fdtc = fukudaDowngradeTestControl3;
                            break;
                        case 3:
                            tc = tabControlStation4;
                            fntc = fukudaNormalTestControl4;
                            fatc = fukudaAQLTestControl4;
                            fdtc = fukudaDowngradeTestControl4;
                            break;
                    }


                    M_DEVICE dvc = db.M_DEVICES.Where(x => x.Device_ID == inp.Device_ID).FirstOrDefault();
                    int idx = -1;
                    switch (dvc.Test_Mode_Default)
                    {
                        case "Normal":
                            idx = 0;
                            fntc.TransactionInput = inp;
                            fntc.DeviceID = inp.Device_ID;
                            fntc.PONumber = inp.PO_Number;
                            fntc.LotBoxID = inp.LotBox_ID;
                            fntc.Quantity = inp.Quantity.ToString();
                            fntc.AQLReference = inp.AQL_Reference;
                            break;
                        case "AQL":
                            idx = 1;
                            fatc.TransactionInput = inp;
                            fatc.DeviceID = inp.Device_ID;
                            fatc.PONumber = inp.PO_Number;
                            fatc.LotBoxID = inp.LotBox_ID;
                            fatc.Quantity = inp.Quantity.ToString();
                            fatc.AQLReference = "";

                            int cch = 1;
                            List<T_TRANSACTION_INPUT> inps = db.T_TRANSACTION_INPUTS.Where(x => x.AQL_Reference == inp.PO_Number).ToList();
                            foreach (var item in inps)
                            {
                                switch (cch)
                                {
                                    case 1: fatc.PONumber1 = item.PO_Number; break;
                                    case 2: fatc.PONumber2 = item.PO_Number; break;
                                    case 3: fatc.PONumber3 = item.PO_Number; break;
                                    case 4: fatc.PONumber4 = item.PO_Number; break;
                                }
                                cch++;
                            }
                            break;
                        case "Downgrade":
                            idx = 2;
                            fdtc.TransactionInput = inp;
                            fdtc.DeviceID = inp.Device_ID;
                            fdtc.PONumber = inp.PO_Number;
                            fdtc.LotBoxID = inp.LotBox_ID;
                            fdtc.Quantity = inp.Quantity.ToString();
                            fdtc.AQLReference = "";
                            break;
                    }  
                    AllowChangeSelecting = false;
                    tc.SelectedIndex = idx;
                    AllowChangeSelecting = true;
                }
            }
        }

        
        //private void txtLotBoxID_TextChanged(object sender, EventArgs e)
        //{
        //    if (!checkBoxManual.Checked) { SearchPONumber(); }
        //}

        private void tabControlStation1_SelectedIndexChanged(object sender, EventArgs e)
        {

        } 

        private void tabControlStations_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = AllowChangeSelectingStation;
        }        

        private void tabControlStation1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = AllowChangeSelecting;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = checkBoxManual.Checked;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPONumber();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormBorderStyle = (FormBorderStyle)comboBox1.SelectedIndex;
        }

        private void barcodeScannerTextBoxUtility1_OnTimerAfterTick(object sender, EventArgs e, TextBox ATextBox)
        {
            if (!checkBoxManual.Checked) { SearchPONumber(); }
        }

        private void fukudaNormalTestControl1_OnAfterSetReadyClick(object sender, EventArgs e)
        {
            
            FukudaNormalTestControl f = (FukudaNormalTestControl)sender;
            string varon = "INPUT_VAR.O_LOTBOX_CLAMP_ON_" + f.LotboxPosition.ToString();
            string varoff = "INPUT_VAR.O_LOTBOX_CLAMP_OFF_" + f.LotboxPosition.ToString();
            NetID = ConfigurationManager.AppSettings["TwinCatNetID"];
            TwinCat3Utility.AllowConnect = true;
            TwinCat3Utility.ConnectPLC(NetID);
            TwinCat3Utility.WriteAnyToPLC(varon, TypeOfData.tpBool, true);
            TwinCat3Utility.WriteAnyToPLC(varoff, TypeOfData.tpBool, false);
            Close();
            Application.DoEvents();
        }

        private void fukudaNormalTestControl2_OnAfterSetReadyClick(object sender, EventArgs e)
        {
            fukudaNormalTestControl1_OnAfterSetReadyClick(sender, e);
        }

        private void fukudaNormalTestControl3_OnAfterSetReadyClick(object sender, EventArgs e)
        {
            fukudaNormalTestControl1_OnAfterSetReadyClick(sender, e);
        }

        private void fukudaNormalTestControl4_OnAfterSetReadyClick(object sender, EventArgs e)
        {
            fukudaNormalTestControl1_OnAfterSetReadyClick(sender, e);
        }

        private void fukudaNormalTestControl1_OnTransactionMachineBook(object sender, TransactionMachineState e)
        {
            //
        }
    }
}
