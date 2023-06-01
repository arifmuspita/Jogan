using DBProject.Models;
using Desktop.BaseForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilites;

namespace Desktop.Forms.Test
{
    public partial class frmListPONumber : frmBaseList
    {
        private bool FAllowCheckDevice;
        private string FNoise_Type_Parameter_Ref;
        private string FTest_Default_Mode;
        public frmListPONumber()
        {
            InitializeComponent();
            FAllowCheckDevice = true;
        }

        protected override void ReArrangeButton(int AHeight = 0, int AWidth = 0)
        {
            base.ReArrangeButton(40, 160);
        }

        protected override void CreateToolStripButton(bool CreateDefaultButton = true)
        {
            base.CreateToolStripButton(false);
            int[] arrIdx = { 13, 14, 15, 16, 8 };
            string[] arrText = { "Loading Lotbox Form", "Add", "Edit", "Delete", "Report" };
            for (int i = 0; i < 1; i++)
            {
                Image img = imageList.Images[arrIdx[i]];
                ToolStripButton btn = new ToolStripButton();
                btn.Alignment = ToolStripItemAlignment.Right;
                btn.CheckOnClick = true;
                btn.Checked = false;
                btn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                btn.Image = img;
                btn.Text = arrText[i];
                switch (i)
                {
                    case 0: btn.Click += new EventHandler(btnEntri_Click); break; 
                }
                tsMain.Items.Add(btn);
                tsMain.Items.Add(new ToolStripSeparator { Alignment = ToolStripItemAlignment.Right });
            }
        }
        protected override void btnEditClick(object sender, EventArgs e)
        {
        }
        protected override void OnFormShown(object sender, EventArgs e)
        {
            Commons.AppCollections.GridFormat[] gr = new Commons.AppCollections.GridFormat[6];
            gr[0].fieldName = "PO_Number";
            gr[0].formatField = "";
            gr[0].headerText = "PO_Number";
            gr[0].fieldNameFilter = "PO_Number";
            gr[0].indexForSearch = -1;
            gr[0].filterType = Commons.AppCollections.FilterType.ftString;
            gr[1].headerText = "PO Number";
            gr[0].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[0].colVisible = true;
            gr[0].colWidth = 120;

            gr[1].fieldName = "Device_ID";
            gr[1].fieldNameFilter = "Device_ID";
            gr[1].formatField = "";
            gr[1].indexForSearch = 0;
            gr[1].filterType = Commons.AppCollections.FilterType.ftString;
            gr[1].headerText = "Device ID";
            gr[1].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[1].colVisible = true;
            gr[1].colWidth = 100;

            gr[2].fieldName = "Device_Name";
            gr[2].fieldNameFilter = "Device_Name";
            gr[2].formatField = "";
            gr[2].indexForSearch = 1;
            gr[2].filterType = Commons.AppCollections.FilterType.ftString;
            gr[2].headerText = "Device Name";
            gr[2].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[2].colVisible = true;
            gr[2].colWidth = 150;

            gr[3].fieldName = "Quantity";
            gr[3].fieldNameFilter = "Quantity";
            gr[3].formatField = "";
            gr[3].indexForSearch = 1;
            gr[3].filterType = Commons.AppCollections.FilterType.ftString;
            gr[3].headerText = "Quantity";
            gr[3].textAlign = DataGridViewContentAlignment.MiddleRight;
            gr[3].colVisible = true;
            gr[3].colWidth = 60;

            gr[4].fieldName = "LotBox_ID";
            gr[4].fieldNameFilter = "LotBox_ID";
            gr[4].formatField = "";
            gr[4].indexForSearch = -1;
            gr[4].filterType = Commons.AppCollections.FilterType.ftString;
            gr[4].headerText = "LotBox ID";
            gr[4].textAlign = DataGridViewContentAlignment.MiddleCenter;
            gr[4].colVisible = true;
            gr[4].colWidth = 100;

            gr[5].fieldName = "Test_Mode_Default";
            gr[5].fieldNameFilter = "Test_Mode_Default";
            gr[5].formatField = "";
            gr[5].indexForSearch = 2;
            gr[5].filterType = Commons.AppCollections.FilterType.ftString;
            gr[5].headerText = "Test Mode Default";
            gr[5].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[5].colVisible = true;
            gr[5].colWidth = 100;
            GridFormat = gr;
            base.OnFormShown(sender, e); 
        }
        protected override void DoOpenData(DBProjectEntities model)
        {
            //IQueryable data = null;
            List<V_PONUMBER_DEVICE> data = model.Database.SqlQuery<V_PONUMBER_DEVICE>("select * from V_PONUMBER_DEVICE where status ='QUEUE' order by Created_date desc").ToList();
            dbgView.DataSource = data;
        }

        protected override void Transaction(DBProjectEntities model = null)
        {
            DateTime dt = DateTime.Now;
            T_TRANSACTION_INPUT inp = model.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == txtPONumber.Text).FirstOrDefault();
            if (inp == null)
            {
                inp = new T_TRANSACTION_INPUT
                {
                    AQL_Reference = " ",
                    Created_Date = dt,
                    Created_User = UserProp.User_ID,
                    Device_ID = txtDeviceID.Text,
                    End_Test = dt,
                    LotBox_ID = txtLotBoxID.Text,
                    LotBox_Position_Fukuda = 0,
                    LotBox_Position_Laser = 0,
                    Noise_Type_Parameter_Ref = FNoise_Type_Parameter_Ref,
                    PO_Number = txtPONumber.Text,
                    Quantity = Convert.ToInt32(txtQuantity.Text),
                    Signal_Device_ID_Ref = txtDeviceID.Text,
                    Start_Test = dt,
                    Status = "Queue",
                    Updated_Date = dt,
                    Updated_User = UserProp.User_ID,
                    User_ID = UserProp.User_ID,
                    Default_Test_Mode = FTest_Default_Mode
                };
                model.T_TRANSACTION_INPUTS.Add(inp);
            } else
            {
                inp.LotBox_ID = txtLotBoxID.Text;
                inp.Device_ID = txtDeviceID.Text;
                inp.Quantity = Convert.ToInt32(txtQuantity.Text);
                inp.Updated_Date = dt;
                inp.Updated_User = UserProp.User_ID;
                model.Entry(inp).CurrentValues.SetValues(inp);
            }

            if (chkAQL.Checked)
            {
                for (int i = 1; i <= 4; i++)
                {
                    TextBox txtp = null;
                    TextBox txtl = null;
                    TextBox txtq = null;
                    switch (i)
                    {
                        case 1: txtp = txtPONumber1; txtl = txtLotBoxID1; txtp = txtQuantity1; break;
                        case 2: txtp = txtPONumber2; txtl = txtLotBoxID2; txtp = txtQuantity2; break;
                        case 3: txtp = txtPONumber3; txtl = txtLotBoxID3; txtp = txtQuantity3; break;
                        case 4: txtp = txtPONumber4; txtl = txtLotBoxID4; txtp = txtQuantity4; break;
                    }
                    inp = model.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == txtp.Text).FirstOrDefault();
                    if (inp != null)
                    {
                        inp.AQL_Reference = txtPONumber.Text;
                        inp.LotBox_ID = txtl.Text;
                        inp.Quantity = Int32.Parse(txtq.Text) ;
                        inp.Updated_Date = dt;
                        inp.Updated_User = UserProp.User_ID;
                        model.Entry(inp).CurrentValues.SetValues(inp);
                    }
                    else
                    {
                        inp = new T_TRANSACTION_INPUT
                        {
                            AQL_Reference = txtPONumber.Text,
                            Created_Date = dt,
                            Created_User = UserProp.User_ID,
                            Device_ID = txtDeviceID.Text,
                            End_Test = dt,
                            LotBox_Position_Fukuda = 0,
                            LotBox_Position_Laser = 0,
                            Noise_Type_Parameter_Ref = FNoise_Type_Parameter_Ref,
                            PO_Number = txtp.Text,
                            LotBox_ID = txtl.Text,
                            Quantity = Int32.Parse(txtq.Text), 
                            Signal_Device_ID_Ref = txtDeviceID.Text,
                            Start_Test = dt,
                            Status = "Queue",
                            Updated_Date = dt,
                            Updated_User = UserProp.User_ID,
                            User_ID = UserProp.User_ID,
                            Default_Test_Mode= FTest_Default_Mode
                        };
                        model.T_TRANSACTION_INPUTS.Add(inp);
                    }
                }
            }
        }
        protected override bool ValidateForm()
        {
            bool ret = true;
            if (txtPONumber.Text == "") { ret = false; toolTip.Show("Pleace entry PO Number first", txtPONumber); }
            if (txtDeviceID.Text == "") { ret = false; toolTip.Show("Pleace entry Device ID first", txtDeviceID); }
            if (txtLotBoxID.Text == "") { ret = false; toolTip.Show("Pleace entry Lotbox ID first", txtLotBoxID); }
            if (txtQuantity.Text == "") { ret = false; toolTip.Show("Pleace entry Quantity first", txtQuantity); }
            if (chkAQL.Checked)
            {
                if (txtPONumber1.Text == "" || txtQuantity1.Text == "" || txtLotBoxID1.Text == "")
                {
                    tabControl1.SelectedTab = tabPageAQL1;
                    if (txtPONumber1.Text == "") { ret = false; toolTip.Show("Pleace entry PO Number 1 first", txtPONumber1); }
                    else
                    if (txtLotBoxID1.Text == "") { ret = false; toolTip.Show("Pleace entry LotBoxID 1 first", txtLotBoxID1); }
                    else
                    if (txtQuantity1.Text == "") { ret = false; toolTip.Show("Pleace entry Quantity 1 first", txtQuantity1); }
                }
                else
                if (txtPONumber2.Text == "" || txtQuantity2.Text == "" || txtLotBoxID2.Text == "")
                {
                    tabControl1.SelectedTab = tabPageAQL2;
                    if (txtPONumber2.Text == "") { ret = false; toolTip.Show("Pleace entry PO Number 2 first", txtPONumber2); }
                    else
                    if (txtLotBoxID2.Text == "") { ret = false; toolTip.Show("Pleace entry LotBoxID 2 first", txtLotBoxID2); }
                    else
                    if (txtQuantity2.Text == "") { ret = false; toolTip.Show("Pleace entry Quantity 2 first", txtQuantity2); }
                }
                else
                if (txtPONumber3.Text == "" || txtQuantity3.Text == "" || txtLotBoxID3.Text == "")
                {
                    tabControl1.SelectedTab = tabPageAQL3;
                    if (txtPONumber3.Text == "") { ret = false; toolTip.Show("Pleace entry PO Number 3 first", txtPONumber3); }
                    else
                    if (txtLotBoxID3.Text == "") { ret = false; toolTip.Show("Pleace entry LotBoxID 3 first", txtLotBoxID3); }
                    else
                    if (txtQuantity3.Text == "") { ret = false; toolTip.Show("Pleace entry Quantity 3 first", txtQuantity3); }
                }
                else
                if (txtPONumber4.Text == "" || txtQuantity4.Text == "" || txtLotBoxID4.Text == "")
                {
                    tabControl1.SelectedTab = tabPageAQL4;
                    if (txtPONumber4.Text == "") { ret = false; toolTip.Show("Pleace entry PO Number 4 first", txtPONumber4); }
                    else
                    if (txtLotBoxID4.Text == "") { ret = false; toolTip.Show("Pleace entry LotBoxID 4 first", txtLotBoxID4); }
                    else
                    if (txtQuantity4.Text == "") { ret = false; toolTip.Show("Pleace entry Quantity 4 first", txtQuantity4); }
                }
            }
            return ret;
        }
        protected override void ResetInput(Control ParentControl)
        {
            base.ResetInput(ParentControl);
            base.ResetInput(tabPageAQL1);
            base.ResetInput(tabPageAQL2);
            base.ResetInput(tabPageAQL3);
            base.ResetInput(tabPageAQL4);
            //txtPONumber1.Text = "";
            //txtPONumber2.Text = "";
            //txtPONumber3.Text = "";
            //txtPONumber4.Text = "";
        }
        private void btnSave2_Click(object sender, EventArgs e)
        {
            if (SaveData(false, true))
            {
                DoOpenData(DBEntities);
                FAllowCheckDevice = false;
                ResetInput(panel2);
                FAllowCheckDevice = true;
                BeginInvoke(new SettingFocus(SetFocus), txtPONumber);
                chkAQL.Checked = false;
                // txtPONumber.Focus();
            }
        }
        private bool CheckDevice(bool All)
        {
            string msg="";
            bool ret = true;
            M_DEVICE dvc = DBEntities.M_DEVICES.Where(x => x.Device_ID == txtDeviceID.Text).FirstOrDefault();
            if (dvc == null) { ret = false;  msg = "Device : " + txtDeviceID.Text + " not found\r\n\r\nPlease contact your administrator"; }
            else { txtDeviceName.Text = dvc.Device_Name; FTest_Default_Mode = dvc.Test_Mode_Default; }
            if (All)
            {
                int cch = DBEntities.M_NOISE_DEVICES.Where(x => x.Device_ID == txtDeviceID.Text).Count();
                if (cch == 0) { ret = false;   msg = "Noise paramater for device : " + txtDeviceID.Text + " not found\r\n\r\nPlease contact your administrator"; }
                else
                {
                    M_NOISE_DEVICE noise = DBEntities.M_NOISE_DEVICES.Where(x => x.Device_ID == txtDeviceID.Text).FirstOrDefault();
                    FNoise_Type_Parameter_Ref = noise.Test_Type_ID;
                }
                cch = DBEntities.M_SIGNAL_DEVICE_PARAMETERS.Where(x => x.Device_ID == txtDeviceID.Text).Count();
                if (cch == 0) { ret = false;   msg = "Signal paramater for device : " + txtDeviceID.Text + " not found\r\n\r\nPlease contact your administrator"; }
            }
            if (!ret) MessageBox.Show(msg);
            return ret;
        }
        private void btnEntri_Click(object sender, EventArgs e)
        {
            OpenForm("frmInputTestData", null, new Size(800, 650), UserProp);
            using (var db = new DBProjectEntities())
            {
                DoOpenData(db);
            }
        }
        public string  GenerateAQLCode(int Station)
        {
            string code = "";
            if (!DesignMode)
            {
                using (var db = new DBProjectEntities())
                {
                    int cch = db.T_TRANSACTION_INPUTS.Where(x => x.PO_Number.Contains("AQL")).Count();
                    cch = cch + Station;
                    code = "AQL" + string.Concat(Enumerable.Repeat("0", 10 - (cch.ToString()).Length)) + cch.ToString(); 
                }
            }
            return code;
        } 
        private bool CheckPONumber()
        {
            bool ret = true;
            using (var db = new DBProjectEntities())
            {
                T_TRANSACTION_INPUT dvc = db.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == txtPONumber.Text).FirstOrDefault();
                if (dvc != null)
                {
                    DialogResult dr = MessageBox.Show("PO Number " + dvc.PO_Number + " already exist.\r\nAre you want edit it ?","Warning",MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        txtLotBoxID.Text = dvc.LotBox_ID;
                        txtDeviceID.Text = dvc.Device_ID;
                        txtQuantity.Text = dvc.Quantity.ToString();
                        txtDeviceName.Text = ((db.M_DEVICES.Where(x => x.Device_ID == dvc.Device_ID).FirstOrDefault()).Device_Name);
                    } else
                    {
                        ret = false;
                        txtPONumber.Text = "";
                        BeginInvoke(new SettingFocus(SetFocus), txtPONumber); 
                    }
                }
                else
                {

                }
            }
            return ret;
        }
        private void txtPONumber_Leave_1(object sender, EventArgs e)
        {
            if (chkManual.Checked) CheckPONumber();
        }
        delegate void SettingFocus(TextBox Value);
        private void SetFocus(TextBox Value)
        {
            Value.Focus();
        }
        private void barcodeScannerTextBoxUtility1_OnTimerAfterTick(object sender, TextBox ATextBox)
        {
            BarcodeScannerTextBoxUtility b = (BarcodeScannerTextBoxUtility)sender;
            string tag = (string)b.Tag;
            SettingFocus sf = new SettingFocus(SetFocus);
            switch (tag)
            {
                case "1":
                    if (CheckPONumber()) BeginInvoke(sf, txtLotBoxID);
                    //txtLotBoxID.Select();
                    //txtLotBoxID.Focus();
                    break;
                case "2":
                    BeginInvoke(sf, txtDeviceID);
                    //txtDeviceID.Select();
                    //txtDeviceID.Focus();
                    break;
                case "3":
                    if (FAllowCheckDevice) CheckDevice(true);
                    BeginInvoke(sf, txtQuantity);
                    //txtQuantity.Select();
                    //txtQuantity.Focus();
                    break;
                case "4":
                    if (!chkAQL.Checked) { btnSave2_Click(null, null); }
                    break;
            }
        }

        private void barcodeScannerTextBoxUtility1_OnTimerBeforeTick(object sender, ref bool AllowTextChange, TextBox ATextBox)
        {
            AllowTextChange = !chkManual.Checked;
        }

        private void chkAQL_CheckedChanged_1(object sender, EventArgs e)
        {
            bool chk = chkAQL.Checked;
            label7.Text = chk ? "AQL Number :" : "PO Number :";
            txtPONumber.Enabled = !chk;
            txtPONumber.Text = chk ? GenerateAQLCode(1) : "";
            txtQuantity.Enabled = !chk;
            txtQuantity.Text = chk ? "125" : "";
            gbPONumberAQL.Visible = chk;
            if (chk) txtDeviceID.Focus(); else txtPONumber.Focus();
        }

        private void txtDeviceID_Leave(object sender, EventArgs e)
        {
            if (chkManual.Checked)
            {
                if (FAllowCheckDevice) CheckDevice(true);
            }
        }
    }
}
