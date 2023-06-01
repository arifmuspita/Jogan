using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads;
using Utilites;
using Utilities;

namespace Desktop.Forms.Trial
{
    public partial class Form1 : Desktop.BaseForms.frmBaseTwinCAT
    {
        private BarcodeScannerTextBoxUtility BarcodeScannerTextBoxUtility;
        private JoganUtility FJoganUtility;
        private void EventButton1(object sender, EventArgs e)
        {
            MessageBox.Show("EventButton1");
        }
        private void EventButton2(object sender, EventArgs e)
        {
            MessageBox.Show("EventButton2");
        }
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(EventButton1);
            button1.Click += new EventHandler(EventButton2);
            BarcodeScannerTextBoxUtility = new BarcodeScannerTextBoxUtility(txtBarcode);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //TwinCat3Utility.WriteAnyToPLC("CallFunction.I_Counter", TypeOfData.tpInt, 0);
            TwinCat3Utility.WriteAnyToPLC("A.I_FuncName", TypeOfData.tpString, cbFuncName.Items[cbFuncName.SelectedIndex]);
        }
        protected override void OnFormShown(object sender, EventArgs e)
        {
            base.OnFormShown(sender, e);
            cbFuncName.SelectedIndex = 0;
            //TwinCat3Utility.ConnectPLC();

            //TwinCat3Utility.AddPLCVariable("A.O_FuncName"); 
            //TwinCat3Utility.AddPLCVariable("A.I_FuncName");
            //TwinCat3Utility.AddPLCVariable("A.O_IsCalled");
            //TwinCat3Utility.TwinCat3Client.AdsNotification += new AdsNotificationEventHandler(OnNotification);
            //FJoganUtility.TwinCat3Utility = TwinCat3Utility;
            //FJoganUtility.ConnectPLC(NetID);
            //FJoganUtility.AddPLCVariable("A.O_FuncName");
            //FJoganUtility.AddPLCVariable("A.I_FuncName");
            //FJoganUtility.AddPLCVariable("A.O_IsCalled");
            //FJoganUtility.AddPLCVariable("A.O_IsLotEnd");
            //FJoganUtility.OnJoganUtilityPLCNotification += new AdsNotificationEventHandler(OnNotification);
        }
        protected override void OnFormLoad(object sender, EventArgs e)
        {
            base.OnFormLoad(sender, e);
            NetID = "172.18.128.227.1.1";
            FJoganUtility = new JoganUtility(NetID);
            FJoganUtility.NetID = NetID;
            FJoganUtility.AllowConnect = false;
        }
        protected override void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            base.OnFormClosed(sender, e);
            FJoganUtility.Dispose();
        }
        private void OnNotification(object sender, AdsNotificationEventArgs e)
        {
            TwinCat3Property prop = TwinCat3Utility.TwinCat3PropertyList.Where(x => x.DeviceNotificationHandle == e.NotificationHandle).FirstOrDefault();
            if (prop != null)
            {
                if (prop.VariableName == "A.O_FuncName")
                {
                    string val = "";
                    val = (string)TwinCat3Utility.ReadAnyFromPLC(prop.VariableName, TypeOfData.tpString);
                    txtMemo.Text = val.ToString();
                }
                if (prop.VariableName == "A.O_IsCalled")
                {
                    bool chk = (bool)TwinCat3Utility.ReadAnyFromPLC(prop.VariableName, TypeOfData.tpBool);
                    chkCalled.Checked = chk;
                }
                if (prop.VariableName == "A.O_IsLotEnd")
                {
                    bool chk = (bool)TwinCat3Utility.ReadAnyFromPLC(prop.VariableName, TypeOfData.tpBool);
                    //FJoganUtility.IsLotEnd = chk;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            T_CURRENT_TRANSACTION ct = null;
            ct = (T_CURRENT_TRANSACTION)FJoganUtility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));

            ct.JIG_INDEX_LOAD++;
            ct.STATION_NUMBER_LOAD = (byte)Int32.Parse(txtStation.Text);
            ct.TRANSPORT_INDEX = (byte)Int32.Parse(txtTransport.Text);
            FJoganUtility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
            FJoganUtility.ExecutePLCProgram("LOAD_FUKUDA");
            //FJoganUtility.LoadLotbox(ct.STATION_NUMBER, ct.JIG_INDEX, ct.TRANSPORT_INDEX);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void barcodeScannerTextBoxUtility1_OnTimerBeforeTick(object sender, EventArgs e)
        {

        }

        private void barcodeScannerTextBoxUtility1_OnTimerAfterTick(object sender, EventArgs e, TextBox ATextBox)
        {
            if (ATextBox != null) MessageBox.Show(ATextBox.Text);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
            lotboxFukuda1.JigAvalailabe = new List<bool> { true, true, false, true, true, true, true, false, true, true }; ;
            lotboxFukuda2.JigAvalailabe = new List<bool> { true, true, false, true, true, true, true, false, true, true };
            lotboxFukuda3.JigAvalailabe = new List<bool> { true, true };
            lotboxFukuda4.JigAvalailabe = new List<bool> { true, true, true, true, false, true, true, true, true, false };
            lotboxFukuda1.LotBoxState = Trial.Controls.LotBoxState.Ready;
            lotboxFukuda2.LotBoxState = Trial.Controls.LotBoxState.Ready;
            lotboxFukuda3.LotBoxState = Trial.Controls.LotBoxState.Ready;
            lotboxFukuda4.LotBoxState = Trial.Controls.LotBoxState.Ready;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtBarcode.Text.Trim().Length == 1)
        //        {
        //            tmrDelay.Enabled = true;
        //            tmrDelay.Start();
        //            tmrDelay.Tick += new EventHandler(tmrDelay_Tick);
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //void tmrDelay_Tick(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        tmrDelay.Stop();
        //        string strCurrentString = txtBarcode.Text.Trim().ToString();
        //        if (strCurrentString != "")
        //        {
        //            //txtBarcode.Text = "";
        //        }
        //        txtBarcode.Focus();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
