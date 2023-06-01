using DBProject.Models;
using Desktop.BaseForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads;
using Utilities;

namespace Desktop.Forms.Trial
{
    public partial class Form3 : frmBaseTwinCAT
    {
        private T_CURRENT_TRANSACTION FCurrentTransaction;
        //private JoganUtility FJoganUtility;
        private FukudaTransfer FukudaTransfer1;
        private FukudaTransfer FukudaTransfer2;
        private async void Delay(JoganWaitAction AStopDelayAction)
        {
            while (!AStopDelayAction())
            {
                await Task.Delay(50);
            }
        }

        private async void Delay(bool IsStop = false)
        {
            while (!IsStop)
            {
                await Task.Delay(50);
            }
        }

        private void PreparePLC(bool IsPrepare = true) 
        {
            if (!IsPrepare)
            {
                if (TwinCat3Utility != null)
                {
                    TwinCat3Utility.Dispose();
                    TwinCat3Utility = null;
                }
            }
            else
            {
                if (TwinCat3Utility == null)
                {
                    NetID = ConfigurationManager.AppSettings["TwinCatNetID"];
                    TwinCat3Utility = new TwinCat3Utility();
                    TwinCat3Utility.AllowConnect = true;
                    TwinCat3Utility.ConnectPLC(NetID);
                    //add plc variable
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTEND");
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOADING_DONE");
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_RETURN_DONE");
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_CURRENT_TRANSACTION");
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUNCTION_NAME");
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_A", chkLoadingTransportA);
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_A", chkLoadingTransportA);
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE", chkLoadingTransportA);
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_B", chkLoadingTransportB);
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_B", chkLoadingTransportB);
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE", chkLoadingTransportB);
                    //AddPLCVariable("INPUT_VAR.I_LOADING_DONE_A", FukudaTransfer1);
                    //AddPLCVariable("INPUT_VAR.I_RETURN_DONE_A", FukudaTransfer1);
                    //AddPLCVariable("INPUT_VAR.I_LOADING_DONE_B", FukudaTransfer2);
                    //AddPLCVariable("INPUT_VAR.I_RETURN_DONE_B", FukudaTransfer2);
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.JIG_FUKUDA_PRESENCE");

                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_1");
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_2");
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_3");
                    TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_4");

                    T_CURRENT_TRANSACTION ct = null;
                    ct = (T_CURRENT_TRANSACTION)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
                    ct.JIG_INDEX_LOAD = 0;
                    ct.JIG_INDEX_RETURN = 0;
                    ct.PO_NUMBER = "";
                    ct.QUANTITY_LOTEND = 0;
                    ct.QUANTITY_MAX = 0;
                    ct.STATION_NUMBER_LOAD = 0;
                    ct.STATION_NUMBER_RETURN = 0;
                    ct.TRANSPORT_INDEX = 0;
                    TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);

                    TwinCat3Utility.TwinCat3Client.AdsNotification += new AdsNotificationEventHandler(OnNotification);
                }
            }
        }

        protected override void OnFormLoad(object sender, EventArgs e)
        {
            base.OnFormLoad(sender, e);
            cmbLoadingStation.SelectedIndex = 0;
            FukudaTransfer1 = new FukudaTransfer(null);
            FukudaTransfer1.ID = 1;
            FukudaTransfer2 = new FukudaTransfer(null);
            FukudaTransfer2.ID = 2;
        }

        private void UpdateStation()
        {
            using (var db = new DBProjectEntities())
            {
                T_TRANSACTION_INPUT tp = db.T_TRANSACTION_INPUTS.Where(x => x.Status == "READY").OrderBy(x => x.Updated_Date).FirstOrDefault();
                if (tp != null)
                {
                    tp.Status = "UNLOAD JIG";
                    tp.LotBox_Position_Fukuda = cmbLoadingStation.SelectedIndex + 1;
                    tp.Updated_Date = DateTime.Now;
                    db.Entry(tp).CurrentValues.SetValues(tp);
                    db.SaveChanges();
                }
            }
        }
        private void OnNotification(object sender, AdsNotificationEventArgs e)
        {
            TwinCat3Property prop = TwinCat3Utility.TwinCat3PropertyList.Where(x => x.DeviceNotificationHandle == e.NotificationHandle).FirstOrDefault();
            if (prop != null)
            {
                
               object obj = TwinCat3Utility.ReadAnyFromPLC(prop.VariableName, TypeOfData.tpBool);
                bool bl = false;
                int stt = -1;
                if (obj is bool)
                {
                    bl = (bool)obj;
                }
                if (bl) lbNotifVar.Items.Insert(0, prop.VariableName + ", value : " +bl.ToString());
                CheckBox cb = null; 
                switch (prop.VariableName)
                {
                    case "INPUT_VAR.I_LOTBOX_DETECT_1":
                        stt = (((bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOTBOX_DETECT_1", TypeOfData.tpBool)) ? 1 : 0);
                        cmbLoadingStation.SelectedIndex = stt - 1;
                        //UpdateStation();
                        break;
                    case "INPUT_VAR.I_LOTBOX_DETECT_2":
                        stt = (((bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOTBOX_DETECT_2", TypeOfData.tpBool)) ? 2 : 0);
                        cmbLoadingStation.SelectedIndex = stt - 1;
                        //UpdateStation();
                        break;
                    case "INPUT_VAR.I_LOTBOX_DETECT_3":
                        stt = (((bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOTBOX_DETECT_3", TypeOfData.tpBool)) ? 3 : 0);
                        cmbLoadingStation.SelectedIndex = stt - 1;
                        //UpdateStation();
                        break;
                    case "INPUT_VAR.I_LOTBOX_DETECT_4":
                        stt = (((bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOTBOX_DETECT_4", TypeOfData.tpBool)) ? 4 : 0);
                        cmbLoadingStation.SelectedIndex = stt - 1;
                        //UpdateStation();
                        break;
                    //loading done : flag when handler already done move jig to transport and send it to straightener
                    case "INPUT_VAR.I_LOADING_DONE_A":
                        chkLoadingTransportA.Enabled = false;
                        chkReturnTransportA.Enabled = true;
                        break;
                    case "INPUT_VAR.I_LOADING_DONE_B":
                        chkLoadingTransportB.Enabled = false;
                        chkReturnTransportB.Enabled = true;
                        break;
                    //return done : flag when handler already done move jig from transport to lotbox
                    case "INPUT_VAR.I_RETURN_DONE_A":
                        chkLoadingTransportA.Enabled = true;
                        chkReturnTransportA.Enabled = false;
                        break;
                    //return done : flag when handler already done move jig from transport to lotbox
                    case "INPUT_VAR.I_RETURN_DONE_B":
                        chkLoadingTransportB.Enabled = true;
                        chkReturnTransportB.Enabled = false;
                        break;
                    case "INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE":
                        FukudaTransfer1.SetFlag(
                            (bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_A", TypeOfData.tpBool),
                            (bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_A", TypeOfData.tpBool),
                            (bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE", TypeOfData.tpBool)
                            );
                        break;
                    case "INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE":
                        FukudaTransfer2.SetFlag(
                           (bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_B", TypeOfData.tpBool),
                           (bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_B", TypeOfData.tpBool),
                           (bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE", TypeOfData.tpBool)
                           );
                        break;
                }
            }
        }
        public void ExecutePLCFunction(string FuncName)
        {
            TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUNCTION_NAME", TypeOfData.tpString, FuncName);
        }
        public void AllowExecutePLCFunction(string FuncName,bool IsAllow)
        {
            TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_ALLOW_EXEC_"+FuncName, TypeOfData.tpBool, IsAllow);
        }
        private void SetFukudaTransfer(T_CURRENT_TRANSACTION ACurrTrans)
        {
            if (ACurrTrans == null) return;
            FukudaTransfer ft = null;
            switch (ACurrTrans.TRANSPORT_INDEX)
            {
                case 1: ft = FukudaTransfer1; break;
                case 2: ft = FukudaTransfer2; break;
            }
            if (ft != null)
            {
                ft.JigIndex = ACurrTrans.JIG_INDEX_LOAD;
                ft.StationNumber = ACurrTrans.STATION_NUMBER_LOAD;
            }
        }
        private void btnExecLoadingStation_Click(object sender, EventArgs e)
        {
            PreparePLC();
            T_CURRENT_TRANSACTION ct = (T_CURRENT_TRANSACTION)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            ct.PO_NUMBER = "PO Number " + (cmbLoadingStation.SelectedIndex + 1).ToString();
            ct.STATION_NUMBER_LOAD = (byte)(cmbLoadingStation.SelectedIndex + 1);
            //ct.STATION_NUMBER_RETURN =   1;
            //ct.QUANTITY_MAX = 1;
            //ct.QUANTITY_LOTEND = 1;
            ct.JIG_INDEX_LOAD = 0;
            ct.JIG_INDEX_RETURN = 0;
            ct.TRANSPORT_INDEX = 0;
            SetFukudaTransfer(ct);
            TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
            AllowExecutePLCFunction("LOAD_FUKUDA", true);
            //ExecutePLCFunction("LOAD_FUKUDA");
            //Delay(delegate () { return (bool)TwinCat3Utility.ReadAnyFromPLC(varname, TypeOfData.tpBool); }); 
        } 
        private void btnExecLoadingJF_Click(object sender, EventArgs e)
        {
            PreparePLC();
            int idx = 0;
            List<Control> c = pnlRB.Controls.OfType<RadioButton>().Cast<Control>().ToList();
            foreach (RadioButton item in c)
            {
                if (item.Checked) idx = Int32.Parse((string)item.Tag);
            }
            T_CURRENT_TRANSACTION ct = (T_CURRENT_TRANSACTION)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            ct.PO_NUMBER = "PO Number " + (cmbLoadingStation.SelectedIndex + 1).ToString();

            ct.STATION_NUMBER_LOAD = (byte)(cmbLoadingStation.SelectedIndex + 1);
            if (!chkMoveToStation1.Checked) ct.STATION_NUMBER_LOAD = 0;
            ct.JIG_INDEX_LOAD = (byte)idx;
            ct.TRANSPORT_INDEX = 0;

            SetFukudaTransfer(ct);
            TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
            AllowExecutePLCFunction("LOAD_FUKUDA",true);
        }

        private void btnExecTransport_Click(object sender, EventArgs e)
        {
            PreparePLC();
            int idx = 0;
            List<Control> c = pnlRB.Controls.OfType<RadioButton>().Cast<Control>().ToList();
            foreach (RadioButton item in c)
            {
                if (item.Checked) idx = Int32.Parse((string)item.Tag);
            }
            T_CURRENT_TRANSACTION ct = (T_CURRENT_TRANSACTION)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            ct.PO_NUMBER = "PO Number " + (cmbLoadingStation.SelectedIndex + 1).ToString();

            ct.STATION_NUMBER_LOAD = (byte)(cmbLoadingStation.SelectedIndex + 1);

            if (!chkMoveToStation2.Checked) ct.STATION_NUMBER_LOAD = 0;
            ct.JIG_INDEX_LOAD = (byte)idx;
            if (!chkMoveJF.Checked) ct.JIG_INDEX_LOAD = 0;
            if (chkLoadingTransportA.Checked && chkLoadingTransportA.Enabled) idx = 1;
            else
            if (chkLoadingTransportB.Checked && chkLoadingTransportB.Enabled) idx = 2;
            ct.TRANSPORT_INDEX =(byte)idx;

            SetFukudaTransfer(ct);
            TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
            AllowExecutePLCFunction("LOAD_FUKUDA",true);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            rbJFLoading1.Checked = false;
            rbJFLoading2.Checked = false;
            rbJFLoading3.Checked = false;
            rbJFLoading4.Checked = false;
            rbJFLoading5.Checked = false;
            rbJFLoading6.Checked = false;
            rbJFLoading7.Checked = false;
            rbJFLoading8.Checked = false;
            rbJFLoading9.Checked = false;
            rbJFLoading10.Checked = false;
        }

        private void btnTestStart_Click(object sender, EventArgs e)
        {
            PreparePLC(false);
            //FJoganUtility.Start();
        }

        private void btnHalt_Click(object sender, EventArgs e)
        {
            PreparePLC(false);
            //FJoganUtility.HaltProccess = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            PreparePLC(false);
            //FJoganUtility.Stop();
        }
        private void WriteCurrentProcess(string message)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(WriteCurrentProcess), new object[] { message });
                return;
            }
            lbCurrProcess.Items.Insert(0, "============================================================");
            lbCurrProcess.Items.Insert(0, message);
            //string msg = "============================================================";
        }
        private void EventThreadWorking(Thread sender, string message = "")
        {
            if (sender == null) return;
            WriteCurrentProcess(message);
        }
        public Form3()
        {
            InitializeComponent();
            NetID = ConfigurationManager.AppSettings["TwinCatNetID"];
            //FJoganUtility = new JoganUtility();
            //FJoganUtility.NetID = NetID;
            //FJoganUtility.OnThreadWorking += new EventThreadWorking(EventThreadWorking);
            //timer1.Enabled = true;
            notifyIcon1.ShowBalloonTip(100, "Grab Status", "Location-22222"  + Environment.NewLine + "New Records-ddddd" + Environment.NewLine + "Old Records-dddddddd", ToolTipIcon.Info);
        }
        Color currentColor = Color.Green;


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (timer1.Enabled && e.Index == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(currentColor), e.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);
            }
            Rectangle paddedBounds = e.Bounds;
            paddedBounds.Inflate(-2, -2);
            e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, this.Font, SystemBrushes.HighlightText, paddedBounds);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (currentColor == Color.Yellow)
                currentColor = Color.Green;
            else
                currentColor = Color.Yellow;
            tabControl1.SuspendLayout();
            tabControl1.Refresh();
            tabControl1.ResumeLayout();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FukudaTransfer ft = null;
            if (chkReturnTransportA.Enabled & chkReturnTransportA.Checked) ft = FukudaTransfer1;
            if (chkReturnTransportB.Enabled & chkReturnTransportB.Checked) ft = FukudaTransfer2;
            if (ft==null) { MessageBox.Show("None of Fukuda Transfer Ready");return; }
            T_CURRENT_TRANSACTION ct = (T_CURRENT_TRANSACTION)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
           
            ct.STATION_NUMBER_RETURN = (byte)(ft.StationNumber);
            ct.JIG_INDEX_RETURN = (byte)(ft.JigIndex);

            RadioButton rb = (RadioButton)pnlJFReturn.Controls["rbJFReturn" + ft.JigIndex.ToString()];
            if (rb != null) rb.Checked = true;
            cmbReturnStation.SelectedIndex = ft.StationNumber - 1;
            DialogResult dr = MessageBox.Show("Are you want to return Jig ?");
            if (dr == DialogResult.Yes)
            {
                TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
                AllowExecutePLCFunction("RETURN_FUKUDA", true);
            }
        }
    }
}
