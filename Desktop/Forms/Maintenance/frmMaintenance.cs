using Commons;
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

namespace Desktop.Forms.Maintenance
{
    public partial class frmMaintenance : Desktop.BaseForms.frmBaseTwinCAT
    {
        private bool FInit;
        private bool[] FLocked = { false, false, false, false, false };
        private T_CURRENT_TRANSACTION FCurrentTransaction;
        //private JoganUtility FJoganUtility;
        private FukudaTransfer FukudaTransfer1;
        private FukudaTransfer FukudaTransfer2;

        private void ReArrangeControl<T>(Control AParent, int AChildCount=2)
        {
            if (AChildCount < 2) return;
            List<Control> c = AParent.Controls.OfType<T>().Cast<Control>().ToList();
            int newwidth = AParent.Width / AChildCount;
            foreach (Control item in c)
            {
                if (item.Dock != DockStyle.Fill)
                {
                    item.Width = newwidth;
                }
            }
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
        protected override void CreateToolStripButton(bool CreateDefaultButton = true)
        {
            base.CreateToolStripButton(false);
        }
        public frmMaintenance()
        {
            FInit = true;
            InitializeComponent();

            //ReArrangeControl<GroupBox>(gbLotboxStation, 2);
            ReArrangeControl<GroupBox>(gbCheckLotbox, 4);
            ReArrangeControl<GroupBox>(gbLockStation, 4);
            ReArrangeControl<GroupBox>(tpUnload, 2);
            ReArrangeControl<GroupBox>(gbUnload, 2);
            cmbStation.SelectedIndex = 3;
            cmbJigIndex.SelectedIndex = 0;

            FukudaTransfer1 = new FukudaTransfer(null);
            FukudaTransfer1.ID = 1;
            FukudaTransfer2 = new FukudaTransfer(null);
            FukudaTransfer2.ID = 2;

            NetID = ConfigurationManager.AppSettings["TwinCatNetID"];
            TwinCat3Utility.AllowConnect = true;
            TwinCat3Utility.ConnectPLC(NetID);
            //detect lotbox attached
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_1", chkStation1,1);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_2", chkStation2,2);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_3", chkStation3,3);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_4", chkStation4,4);
            //lock unlock lotbox
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.O_LOTBOX_CLAMP_ON_1",btnLockStation1,1);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.O_LOTBOX_CLAMP_ON_2", btnLockStation2,2);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.O_LOTBOX_CLAMP_ON_3", btnLockStation3, 3);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.O_LOTBOX_CLAMP_ON_4", btnLockStation4, 4);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.O_LOTBOX_CLAMP_OFF_1");
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.O_LOTBOX_CLAMP_OFF_2");
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.O_LOTBOX_CLAMP_OFF_3");
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.O_LOTBOX_CLAMP_OFF_4");

            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOTEND");
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOADING_DONE_A");
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_LOADING_DONE_B");
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_RETURN_DONE_A");
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_RETURN_DONE_B");
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_CURRENT_TRANSACTION");
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUNCTION_NAME");
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_A", chkUTransportA);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_A", chkUTransportA);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE", chkUTransportA);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_B", chkUTransportB);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_B", chkUTransportB);
            TwinCat3Utility.AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE", chkUTransportB);

            T_CURRENT_TRANSACTION ct = null;
            ct = (T_CURRENT_TRANSACTION)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            if (ct != null)
            {
                ct.JIG_INDEX_LOAD = 0;
                ct.JIG_INDEX_RETURN = 0;
                ct.PO_NUMBER = "";
                ct.QUANTITY_LOTEND = 0;
                ct.QUANTITY_MAX = 0;
                ct.STATION_NUMBER_LOAD = 0;
                ct.STATION_NUMBER_RETURN = 0;
                ct.TRANSPORT_INDEX = 0;
                TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
            }

            TwinCat3Utility.TwinCat3Client.AdsNotification += new AdsNotificationEventHandler(OnNotification);
        }
        public void AllowExecutePLCFunction(string FuncName, bool IsAllow)
        {
            TwinCat3Utility.WriteAnyToPLC("FLAG_VAR.ALLOW_EXECUTE_" + FuncName, TypeOfData.tpBool, IsAllow);
        }
        private int GetFlagTransport(string ATransportIndex)
        {
            int ret = 0;
            bool F = (bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_" + ATransportIndex, TypeOfData.tpBool);
            bool B = (bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_" + ATransportIndex, TypeOfData.tpBool);
            bool D = (bool)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_" + ATransportIndex + "_PICK_DONE", TypeOfData.tpBool);
            int b = B ? 1 : 0; b = b << 2;
            int f = F ? 1 : 0; f = f << 1;
            int d = D ? 1 : 0;
            ret = b + f + d;
            return ret;
        }
        private void OnNotification(object sender, AdsNotificationEventArgs e)
        {
            TwinCat3Property prop = TwinCat3Utility.TwinCat3PropertyList.Where(x => x.DeviceNotificationHandle == e.NotificationHandle).FirstOrDefault();
            if (prop != null)
            {
                string idx = "";
                string msg = "";
                //bool val = false;
                //val = TwinCat3Utility.BinaryReader.ReadBoolean();
                object val = TwinCat3Utility.ReadAnyFromPLC(prop.VariableName, TypeOfData.tpBool);
                CheckBox chk = null;
                switch (prop.VariableName)
                {
                    case "INPUT_VAR.I_LOTBOX_DETECT_1":
                    case "INPUT_VAR.I_LOTBOX_DETECT_2":
                    case "INPUT_VAR.I_LOTBOX_DETECT_3":
                    case "INPUT_VAR.I_LOTBOX_DETECT_4":
                        chk = (CheckBox)prop.DataObject1;
                        chk.Checked = !((bool)val);
                        chk.Text = (bool)val ? StatusTestingControl.Empty.ToString() : StatusTestingControl.Attached.ToString();
                        msg = "Lotbox on Station " + ((int)prop.DataObject2).ToString() + " " + ((bool)val ? StatusTestingControl.Empty.ToString() : StatusTestingControl.Attached.ToString());
                        lbMessage.Items.Insert(0, msg);
                        break;
                    case "INPUT_VAR.O_LOTBOX_CLAMP_ON_1":
                    case "INPUT_VAR.O_LOTBOX_CLAMP_ON_2":
                    case "INPUT_VAR.O_LOTBOX_CLAMP_ON_3":
                    case "INPUT_VAR.O_LOTBOX_CLAMP_ON_4":
                        int idx_ = (int)prop.DataObject2;
                        FLocked[idx_] = (bool)val;
                        //int idx_ = Convert.ToInt32(idx);
                        Button btn = (Button)prop.DataObject1;
                        string varoff = "INPUT_VAR.O_LOTBOX_CLAMP_OFF_" + idx_.ToString();
                        object val2 = TwinCat3Utility.ReadAnyFromPLC(varoff, TypeOfData.tpBool);
                        //if (FInit)
                        {
                            btn.Text = (bool)val && !(bool)val2 ? "UnLock" : "Lock";
                            btn.ImageIndex = (bool)val && !(bool)val2 ? 1 : 0;
                        }
                        msg = "Lotbox on Station " + idx_.ToString();
                        if ((bool)val && !(bool)val2)
                        {
                            msg = msg + " Locked";
                        }
                        else { msg = msg + " UnLocked"; }
                        lbMessage.Items.Insert(0, msg);
                        break;
                    case "INPUT_VAR.I_LOTEND":
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, prop.VariableName);
                        break;
                    case "INPUT_VAR.I_LOADING_DONE_A":
                        if ((bool)val) chkRTransportA.Enabled = !chkRTransportA.Enabled;
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, prop.VariableName);
                        break;
                    case "INPUT_VAR.I_LOADING_DONE_B":
                        if ((bool)val) chkRTransportB.Enabled = !chkRTransportB.Enabled;
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, prop.VariableName);
                        break;
                    case "INPUT_VAR.I_RETURN_DONE_A":
                        if ((bool)val) chkUTransportA.Enabled = !chkUTransportA.Enabled;
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, prop.VariableName);
                        break;
                    case "INPUT_VAR.I_RETURN_DONE_B":
                        if ((bool)val)                        chkUTransportB.Enabled = !chkUTransportB.Enabled;
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, prop.VariableName);
                        break;
                    case "INPUT_VAR.I_CURRENT_TRANSACTION":
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, prop.VariableName);
                        break;
                    case "INPUT_VAR.I_FUNCTION_NAME":
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, prop.VariableName);
                        break;
                    case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_A":
                        //if (GetFlagTransport("A") != 0)
                        //{
                        //    //chkUTransportA.Checked = true;
                        //    //chkUTransportA.Enabled = true;
                        //    //chkUTransportA.Checked = true;
                        //    //chkUTransportA.Enabled = false;
                        ////}
                        ////else
                        ////{
                        //    chkUTransportA.Checked = true;
                        //    chkUTransportA.Enabled = false;
                        //    chkUTransportB.Checked = true;
                        //    chkUTransportB.Enabled = false;
                        //    chkRTransportA.Checked = false;
                        //    chkRTransportA.Enabled = true;
                        //    AllowExecutePLCFunction("LOAD_FUKUDA", false);
                        //}
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, msg);
                        break;
                    case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_A":
                        //if (GetFlagTransport("A") != 0)
                        //{
                        //    chkUTransportA.Checked = true;
                        //    chkUTransportA.Enabled = false;
                        //    //chkUTransportB.Checked = true;
                        //    //chkUTransportB.Enabled = true;
                        //    chkRTransportA.Checked = false;
                        //    chkRTransportA.Enabled = false;
                        //    AllowExecutePLCFunction("RETURN_FUKUDA", false);
                        //}
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, msg);
                        break;
                    case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_B":
                        //if (GetFlagTransport("B") != 0)
                        //{
                        //    //chkUTransportA.Checked = true;
                        //    //chkUTransportA.Enabled = true;
                        //    ////chkUTransportA.Checked = true;
                        //   // chkUTransportA.Enabled = false;
                        ////}
                        ////else
                        ////{
                        //    chkUTransportA.Checked = true;
                        //    chkUTransportA.Enabled = false;
                        //    chkUTransportB.Checked = true;
                        //    chkUTransportB.Enabled = false;
                        //    chkRTransportB.Checked = false;
                        //    chkRTransportB.Enabled = true;
                        //    AllowExecutePLCFunction("LOAD_FUKUDA", false);
                        //}
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, msg);
                        break;
                    case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_B":
                        //if (GetFlagTransport("B") != 0)
                        //{
                        //    chkUTransportB.Checked = true;
                        //    chkUTransportB.Enabled = false;
                        //    //chkUTransportB.Checked = true;
                        //    //chkUTransportB.Enabled = true;
                        //    chkRTransportB.Checked = false;
                        //    chkRTransportB.Enabled = false;
                        //    AllowExecutePLCFunction("RETURN_FUKUDA", false);
                        //}
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, msg);
                        break;
                    case "INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE":
                        if ((bool)val) Return(1);
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, msg);
                        break;
                    case "INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE":
                        if ((bool)val) Return(2);
                        msg = prop.VariableName + " : " + val.ToString();
                        lbMessage.Items.Insert(0, msg);
                        break;
                }
            }
        }

        private void btnLockStation1_Click(object sender, EventArgs e)
        {
            FInit = false;
            Button btn = (Button)sender;
            string idx = (string)btn.Tag;
            int idx_ = Convert.ToInt32(idx);
            FLocked[idx_] = !FLocked[idx_];
            string varon = "INPUT_VAR.O_LOTBOX_CLAMP_ON_" + idx;
            string varoff = "INPUT_VAR.O_LOTBOX_CLAMP_OFF_" + idx;
            TwinCat3Utility.WriteAnyToPLC(varon, TypeOfData.tpBool, FLocked[idx_]);
            TwinCat3Utility.WriteAnyToPLC(varoff, TypeOfData.tpBool, !FLocked[idx_]);
            //btn.Text = FLocked[idx_] ? "UnLock" : "Lock";
            //btn.ImageIndex = FLocked[idx_] ? 18 : 17; 
        }

        private void chkTransportA_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            //chk.Enabled = false;
            chk.ImageIndex = chk.Checked ? 3 : 4;
        }

        private void btnExecActStation_Click(object sender, EventArgs e)
        {
            T_CURRENT_TRANSACTION ct = (T_CURRENT_TRANSACTION)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            ct.PO_NUMBER = "PO Number " + (cmbStation.SelectedIndex + 1).ToString();
            ct.STATION_NUMBER_LOAD = (byte)(cmbStation.SelectedIndex + 1);
            //ct.STATION_NUMBER_RETURN =   1;
            //ct.QUANTITY_MAX = 1;
            //ct.QUANTITY_LOTEND = 1;
            ct.JIG_INDEX_LOAD = 0;
            ct.JIG_INDEX_RETURN = 0;
            ct.TRANSPORT_INDEX = 0;
            SetFukudaTransfer(ct);
            TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
            AllowExecutePLCFunction("LOAD_FUKUDA", true);
        }

        private void btnExecJigIndex_Click(object sender, EventArgs e)
        {
            T_CURRENT_TRANSACTION ct = (T_CURRENT_TRANSACTION)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            ct.PO_NUMBER = "PO Number " + (cmbStation.SelectedIndex + 1).ToString();

            ct.STATION_NUMBER_LOAD = (byte)(cmbStation.SelectedIndex + 1);
           // if (!chkMoveToStation1.Checked) ct.STATION_NUMBER_LOAD = 0;
            ct.JIG_INDEX_LOAD = (byte)(cmbJigIndex.SelectedIndex+1);
            ct.TRANSPORT_INDEX = 0;

            SetFukudaTransfer(ct);
            TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
            AllowExecutePLCFunction("LOAD_FUKUDA", true);
        }

        private void btnExecUTransport_Click(object sender, EventArgs e)
        {
            int idx = 0;
           
            T_CURRENT_TRANSACTION ct = (T_CURRENT_TRANSACTION)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            ct.PO_NUMBER = "PO Number " + (cmbStation.SelectedIndex + 1).ToString();

            ct.STATION_NUMBER_LOAD = (byte)(cmbStation.SelectedIndex + 1);
            ct.JIG_INDEX_LOAD = (byte)(cmbJigIndex.SelectedIndex + 1);

            if (chkUTransportA.Checked && chkUTransportA.Enabled) { idx = 1; chkUTransportA.Enabled = false; }
            else
            if (chkUTransportB.Checked && chkUTransportB.Enabled) { idx = 2; chkUTransportB.Enabled = false; }
            ct.TRANSPORT_INDEX = (byte)idx;

            SetFukudaTransfer(ct);
            TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
            AllowExecutePLCFunction("LOAD_FUKUDA", true);
            //AllowExecutePLCFunction("LOAD_FUKUDA", false);
        }

        private void btnExecRTransport_Click(object sender, EventArgs e)
        {
            FukudaTransfer ft = null;
            if (chkRTransportA.Enabled & chkRTransportA.Checked) { ft = FukudaTransfer1;chkRTransportA.Enabled = false; }
            if (chkRTransportB.Enabled & chkRTransportB.Checked) { ft = FukudaTransfer2; chkRTransportB.Enabled = false; }
            if (ft == null) { MessageBox.Show("None of Fukuda Transfer Ready"); return; }
            T_CURRENT_TRANSACTION ct = (T_CURRENT_TRANSACTION)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            ct.TRANSPORT_INDEX = (byte)ft.ID;
            ct.STATION_NUMBER_RETURN = 4;// (byte)(ft.StationNumber);
            ct.JIG_INDEX_RETURN = 2;// (byte)(ft.JigIndex);

            //RadioButton rb = (RadioButton)pnlJFReturn.Controls["rbJFReturn" + ft.JigIndex.ToString()];
           // if (rb != null) rb.Checked = true;
            //cmbReturnStation.SelectedIndex = ft.StationNumber - 1;
            DialogResult dr = MessageBox.Show("Are you want to return Jig ?");
            if (dr == DialogResult.OK)
            {
                TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
                AllowExecutePLCFunction("RETURN_FUKUDA", true);
                //AllowExecutePLCFunction("RETURN_FUKUDA", false);
            }
        }

        private void Return(int AIndex)
        {
            FukudaTransfer ft = null;
            string str = "";// "I_FUKUDA_TRANSFER_B_PICK_DONE";
            if (AIndex == 1) { ft = FukudaTransfer1; str =   "I_FUKUDA_TRANSFER_A_PICK_DONE";}
                if (AIndex == 2) { ft = FukudaTransfer2; str = "I_FUKUDA_TRANSFER_B_PICK_DONE";
        }
            if (ft == null) { MessageBox.Show("None of Fukuda Transfer Ready"); return; }
            T_CURRENT_TRANSACTION ct = (T_CURRENT_TRANSACTION)TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            ct.TRANSPORT_INDEX = (byte)ft.ID;
            ct.STATION_NUMBER_RETURN = 4;// (byte)(ft.StationNumber);
            ct.JIG_INDEX_RETURN =   (byte)(ft.JigIndex);
            TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
            AllowExecutePLCFunction("RETURN_FUKUDA", true);
            TwinCat3Utility.WriteAnyToPLC(str, TypeOfData.tpBool,false);
        }

        private void btnDoneB_Click(object sender, EventArgs e)
        {
            TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE", TypeOfData.tpBool, true);
        }

        private void btnDoneA_Click(object sender, EventArgs e)
        {
            TwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE", TypeOfData.tpBool, true);
        }
    }
}
