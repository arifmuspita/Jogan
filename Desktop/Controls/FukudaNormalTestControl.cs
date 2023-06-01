using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBProject.Models;
using Desktop.BaseControls;
using System.Data.Entity.Validation;
using Desktop.DesktopProperties;
using System.Data.SqlClient;
using Commons;

namespace Desktop.Controls
{
    //public delegate void EventHandler(object sender, EventArgs e);
    public partial class FukudaNormalTestControl : BaseControl
    {
        public override event EventMachineBook OnTransactionMachineBook;
       // [Browsable(false)]
        private bool MachineSignalOn1 { get; set; }
        // [Browsable(false)]
        private bool MachineSignalOn2 { get; set; }
        private string FAQLReference { get; set; }

        public string DeviceID { get { return txtDeviceID.Text; } set{ txtDeviceID.Text = value; } }
        public string LotBoxID { get { return txtLotBoxID.Text; } set { txtLotBoxID.Text = value; } }
        public string Quantity { get { return txtQuantity.Text; } set { txtQuantity.Text = value; } }
        [Browsable(false)]
        public string AQLReference { get { return FAQLReference; } set { SetAQLRefence(value); } }

        private void SetAQLRefence(string value)
        { 
            lblAQLRef.Visible = value==null ? false: value != "";
            lblAQLResult.Visible = value == null ? false : value != "";
            txtAQLRef.Visible = value == null ? false : value != "";
            txtAQLResult.Visible = value == null ? false : value != "";
            txtAQLRef.Text =  "";
            txtAQLResult.Text =   "";
            chkNoise.Checked = true; 
            chkNoise.Enabled = true;
            if (!DesignMode)
            {
                bool aqlresult = GetResultAQLTest(value);
                txtAQLRef.Text = aqlresult ? value : "";
                txtAQLResult.Text = aqlresult ? "100%" : "Not 100%";
                chkNoise.Checked = !aqlresult;
                chkNoise.Enabled = !aqlresult;
            }
        }

        [Browsable(false)]
         public int LotboxLaserPosition { get; set; }
        [Browsable(false)]
        public int LotboxLaserDowngradePosition { get; set; }

        public FukudaNormalTestControl()
        {
            InitializeComponent();
            MachineSignalOn1 = true;
            MachineSignalOn2 = true;
            TestMode = TestMode.tmNormal;
        }

        protected override void SetTransactionInput(T_TRANSACTION_INPUT Value)
        {
            base.SetTransactionInput(Value);
            if (Value != null)
            {
                txtPONumber.Text = Value.PO_Number;
                txtDeviceID.Text = Value.Device_ID;
                txtLotBoxID.Text = Value.LotBox_ID;
                txtQuantity.Text = Value.Quantity.ToString();
                if (!DesignMode)
                {
                    using (var db = new DBProjectEntities())
                    {
                        M_DEVICE dvc = db.M_DEVICES.Where(x => x.Device_ID == Value.Device_ID).FirstOrDefault();
                        if (dvc!=null) txtDeviceName.Text = dvc.Device_Name;
                    }
                }
            }
        }
        protected override string GetPONumber(int AIndex)
        {
            return txtPONumber.Text;
        }
        protected override void SetPONumber(int AIndex,string Value)
        {
            txtPONumber.Text = Value;
        }
        protected virtual bool CheckSignalMachineState()
        {
            if (!DesignMode)
            {
                TransactionMachineState ms = new TransactionMachineState();
                using (var db = new DBProjectEntities())
                {
                    var book2 = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == "SIGNAL").OrderBy(x => x.Machine_Number);
                    bool mSignal1 = false;
                    bool mSignal2 = false;
                    int roomNo = 0;
                    //check signal machines first 
                    foreach (var item in book2)
                    {
                        ms.Status = MachineState.msOn;
                        ms.Machine_ID = item.Machine_ID;
                        ms.Machine_Number = item.Machine_Number;
                        if (null != OnTransactionMachineBook) { OnTransactionMachineBook(this,   ms); }
                        if (roomNo == 0) { MachineSignalOn1 = ms.Status == MachineState.msOn; }
                        if (roomNo == 1) { MachineSignalOn2 = ms.Status == MachineState.msOn; }
                        roomNo++;
                    }
                }
            }
            return  MachineSignalOn1 || MachineSignalOn2;
        }

        protected virtual bool CheckIsLaserStationReady()
        {
            bool ret = true;
            if (!DesignMode)
            {
                using (var db = new DBProjectEntities())
                {
                    SP_LASER_STATION ls1 = db.Database.SqlQuery<SP_LASER_STATION>("SP_LASER_STATION @ISDownGrade", new SqlParameter("ISDownGrade", false)).FirstOrDefault();
                    ret = ls1 != null;
                    if (ret) LotboxLaserPosition = ls1.LotBox_Position;
                    if (TestMode == TestMode.tmDowngrade)
                    {
                        SP_LASER_STATION ls2 = db.Database.SqlQuery<SP_LASER_STATION>("SP_LASER_STATION @ISDownGrade", new SqlParameter("ISDownGrade", true)).FirstOrDefault();
                        ret = ls2 != null;
                        if (ret) LotboxLaserDowngradePosition = ls2.LotBox_Position;
                    }
                }
            }
            return ret;
        }

        protected virtual bool GetResultAQLTest(string AQLCode)
        {
            bool ret = false;
            using (var db = new DBProjectEntities())
            {
                T_AQL_RESULT tar = db.Database.SqlQuery<T_AQL_RESULT>("select 0 as ID,PO_Number, Quantity, (select coalesce(sum(Qty_Pass),0) from T_SORTER_SUMMARY tss where tss.PO_Number=tti.PO_Number) as Qty_Pass " +
                    "from T_TRANSACTION_INPUT tti where PO_Number ='" + AQLCode + "'").FirstOrDefault();
                if (tar != null) ret = tar.Qty_Pass == tar.Quantity;
            }
            return ret;
        }
        protected virtual bool CheckPONumber()
        {
            bool ret = true;
            if (!DesignMode)
            {
                using (var db = new DBProjectEntities())
                {
                    TransactionInput = null;
                    TransactionInput = db.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == txtPONumber.Text).FirstOrDefault();
                    ret = TransactionInput != null;
                    if (!ret) { FocusControl = txtPONumber; panelMessage.Message = "PO Number not exist in list\r\nPlease entry it first on List PO Number form"; }
                    else
                    {
                        txtLotBoxID.Text = TransactionInput.LotBox_ID;
                        txtQuantity.Text = TransactionInput.Quantity.ToString();
                        if (TransactionInput.AQL_Reference != "")   GetResultAQLTest(TransactionInput.AQL_Reference); 
                    }
                }
            }
            return ret;
        }

        protected virtual bool CheckLotBox()
        {
            bool ret = true;
            if (!DesignMode)
            {
                using (var db = new DBProjectEntities())
                {
                    TransactionInput = null;
                    TransactionInput = db.T_TRANSACTION_INPUTS.Where(x => x.LotBox_ID == txtLotBoxID.Text).FirstOrDefault();
                    ret = TransactionInput != null;
                    if (!ret) { FocusControl = txtPONumber; panelMessage.Message = "PO Number not exist in list\r\nPlease entry it first on List PO Number form"; }
                    else
                    {
                        txtPONumber.Text = TransactionInput.PO_Number;
                        txtQuantity.Text = TransactionInput.Quantity.ToString();
                        if (TransactionInput.AQL_Reference != "") GetResultAQLTest(TransactionInput.AQL_Reference);
                    }
                }
            }
            return ret;
        }

        protected override bool ValidateForm(out Control ControlToFocus, Control ParentControl = null)
        {
            bool ret = base.ValidateForm(out ControlToFocus, ParentControl);
            if (TestMode != TestMode.tmAQL) { if (ret) ret = CheckPONumber(); }
            if (ret )
            {
                ret = chkNoise.Checked || chkSignal.Checked || chkResistance.Checked;
                if (!ret) panelMessage.Message = "None of testing mode selected (Noise and/or Signal and/or Resistance)";
            }
            if (ret) ret = CheckDevice(true);
            if (ret)
            {
                ret = CheckSignalMachineState();
                if (!ret) panelMessage.Message = "None of Signal Machines On\r\nPlease contact your supervisor";
            }
            //if (ret)
            //{
            //    ret = CheckIsLaserStationReady();
            //    if (!ret) panelMessage.Message = "Lotbox Laser not ready\r\nPlease contact your supervisor";
            //}
            return ret;
        }
        public M_MACHINE_TESTER GetMachine(string Code)
        {
            M_MACHINE_TESTER ret = null;
            using (var db = new DBProjectEntities())
            {
                ret = db.M_MACHINE_TESTERS.Where(x => x.Machine_ID == Code).FirstOrDefault();
            }
            return ret;
        }
        public M_MACHINE_TESTER GetMachine(string MachineType, int MachineNumber)
        {
            M_MACHINE_TESTER ret = null;
            using (var db = new DBProjectEntities())
            {
                ret = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == MachineType && x.Machine_Number == MachineNumber).FirstOrDefault();
            }
            return ret;
        }
        private void CreateListCloseSocket(DBProjectEntities model,string Machine_Type,int RoomNo,ref string ListCloseSocket, ref int TotalCloseSocket)
        {
             string sc = ListCloseSocket;
            int ttlCS = TotalCloseSocket;
            V_MACHINE_CLOSE_SOCKET cs = model.Database.SqlQuery<V_MACHINE_CLOSE_SOCKET>("select * from V_MACHINE_CLOSE_SOCKET where machine_id = (select machine_id from M_MACHINE_TESTER where Machines_Type = '" + Machine_Type  + "' and Machine_Number=" + RoomNo.ToString() + ")").FirstOrDefault();
            if (cs != null)
            {
                for (int i = 1; i <= 64; i++)
                {
                    int cs_ = (int)Commons.Commons.GetValueFromProperty(cs, "Socket_" + i.ToString());
                    if (cs_ == 1)
                    {
                        if (sc.IndexOf(i.ToString()) == -1) sc = i.ToString() + "," + sc;
                    }
                    ttlCS = ttlCS + cs_;
                }
                //if (sc != "") sc = sc.Substring(0, sc.Length - 1);
                if (sc != "")
                    if (sc[sc.Length-1]==',') sc = sc.Substring(0, sc.Length-1);
            }
            ListCloseSocket = sc;
            TotalCloseSocket = ttlCS;
        }
        private void CreateBooking(DBProjectEntities model)
        {
            if (!DesignMode)
            {
                List<V_BOOKING_ROOM_MACHINE> book = model.Database.SqlQuery<V_BOOKING_ROOM_MACHINE>("select * from V_BOOKING_ROOM_MACHINE order by id").ToList();//   V_BOOKING_ROOM_MACHINES.OrderBy(x => x.ID).ToList();
                TransactionMachineState ms = new TransactionMachineState();
                int ttlDev = Convert.ToInt32(txtQuantity.Text);//  TransactionInput.Quantity;
                int ttlCS = 0;
                int roomNo = 0;
                string sc = "";
                string[] Machine_Type = new string[3] { "NOISE", "SIGNAL", "RESISTANCE" };
                string[] Machine_Name = new string[3] { "Machine_Noise", "Machine_Signal", "Machine_Resistance" };
                string[] Machine_Room = new string[3] { "Noise_Room_Number", "Signal_Room_Number", "Resistance_Room_Number" };
                string[] Bypass_Room = new string[3] { "ByPassTestNoise", "ByPassTestSignal", "ByPassTestResistance" };
                int[] New_Machine_Number = new int[3] {0,0,0 };
                CheckBox[] Machine_CheckBox = new CheckBox[3] { chkNoise,chkSignal,chkResistance };

                //var book2 = model.M_MACHINE_TESTERS.Where(x => x.Machines_Type == "SIGNAL").OrderBy(x => x.Machine_Number);
                //bool mSignal1 = false;
                //bool mSignal2 = false;

                ////check signal machines first 
                //foreach (var item in book2)
                //{
                //    ms.Status = MachineState.msOn;
                //    ms.Machine_ID = item.Machine_ID;
                //    ms.Machine_Number = item.Machine_Number;
                //    if (null != OnTransactionMachineBook) { OnTransactionMachineBook(this, ms); }
                //    if (roomNo == 0) { mSignal1 = ms.Status == MachineState.msOn; }
                //    if (roomNo == 1) { mSignal2 = ms.Status == MachineState.msOn; }
                //    roomNo++;
                //}
                //bool mSignalAll = MachineSignalOn1 || MachineSignalOn2;
                // if (!mSignalAll) { panelMessage.Message = "None of Signal Machines On\r\nPlease contact your supervisor"; return; }

                if (!MachineSignalOn1) { book = book.Where(x => x.Line_Number == 2).ToList(); }
                else
                if (!MachineSignalOn2) { book = book.Where(x => x.Line_Number == 1).ToList(); }
                else { book = book.Where(x => x.Line_Number == 0).ToList(); }
                DateTime dt = DateTime.Now;
                roomNo = 0;
                do
                {
                    New_Machine_Number[0] = 0;
                    New_Machine_Number[1] = 0;
                    New_Machine_Number[2] = 0;
                    foreach (var item in book)
                    {
                        T_BOOKING_STATION bs = new T_BOOKING_STATION
                        {
                            Close_Socket_Numbers = "",
                            Created_Date = dt,
                            Created_User = UserID,
                            Device_ID = txtDeviceID.Text,
                            Device_Qty = 0,
                            Jig_ID = "EMPTY",
                            Noise_Room_Number = 0,
                            PO_Number = txtPONumber.Text,
                            Queue_ID = 0,
                            Resistance_Room_Number = 0,
                            Signal_Room_Number = 0,
                            Updated_Date = dt,
                            Updated_User = UserID,
                            ID = 0,
                            Status="Queue",
                            ByPassTestNoise=false,
                            ByPassTestSignal=false,
                            ByPassTestResistance = false,
                        };
                        ttlCS = 0; sc = "";
                        for (int j = 0; j <= 2; j++)
                        {
                            //Count total Close Socket
                            ms.Machine_Type = "";
                            ms.Status = MachineState.msOn;

                            //Noise Close Socket
                            ms.Machine_ID = (string)Commons.Commons.GetValueFromProperty(item, Machine_Name[j]);// item.Machine_Noise;
                            roomNo = (int)Commons.Commons.GetValueFromProperty(item, Machine_Room[j]);
                            if (New_Machine_Number[j] != 0) roomNo = New_Machine_Number[j];
                            ms.Machine_Number = roomNo;

                            if (null != OnTransactionMachineBook) { ms.Machine_Type = Machine_Type[j]; OnTransactionMachineBook(this, ms); ms.Machine_Type = ""; }
                            //V_MACHINE_CLOSE_SOCKET cs = db.V_MACHINE_CLOSE_SOCKETS.Where(x => x.Machine_ID == ms.Machine_ID).FirstOrDefault();
                            //var cs = model.Database.SqlQuery<V_MACHINE_CLOSE_SOCKET>("select * from V_MACHINE_CLOSE_SOCKET where machine_id = '" + ms.Machine_ID + "'").ToList();
                            //if (ms.Status == MachineState.msOn)
                            //if (j == 2)
                            //{
                            //    int aaa = 0;
                            //}
                            //V_MACHINE_CLOSE_SOCKET cs =  model.Database.SqlQuery<V_MACHINE_CLOSE_SOCKET>("select * from V_MACHINE_CLOSE_SOCKET where machine_id = '" + ms.Machine_ID + "'").FirstOrDefault();
                            if (ms.Status != MachineState.msOff)
                            {
                                //V_MACHINE_CLOSE_SOCKET cs = model.Database.SqlQuery<V_MACHINE_CLOSE_SOCKET>("select * from V_MACHINE_CLOSE_SOCKET where machine_id = (select machine_id from M_MACHINE_TESTER where Machines_Type = '" + Machine_Type[j] + "' and Machine_Number=" + roomNo.ToString() + ")").FirstOrDefault();
                                //if (cs != null)
                                //{
                                //    for (int i = 1; i <= 64; i++)
                                //    {
                                //        int cs_ = (int)Commons.Commons.GetValueFromProperty(cs, "Socket_" + i.ToString());
                                //        if (cs_ == 1)
                                //        {
                                //            if (sc.IndexOf(i.ToString()) == -1) sc = i.ToString() + "," + sc;
                                //        }
                                //        ttlCS = ttlCS + cs_;
                                //    }
                                //    if (sc != "") sc = sc.Substring(0, sc.Length - 1);
                                //}
                                CreateListCloseSocket(model, Machine_Type[j], roomNo, ref sc, ref ttlCS);
                                
                            }
                            //if (MachineSignalOn1 && MachineSignalOn2) //machine signal1 & signal2 on
                            //{
                            if (Machine_CheckBox[j].Checked && (ms.Status == MachineState.msOn))
                            {
                                Commons.Commons.SetValueOfProperty(bs, Machine_Room[j], roomNo);
                                if (New_Machine_Number[j] != 0)
                                {
                                    New_Machine_Number[j]++;
                                    roomNo = New_Machine_Number[j];
                                    if (MachineSignalOn1 && MachineSignalOn2)
                                        if (New_Machine_Number[j] > 8) New_Machine_Number[j] = 1;
                                    if (!MachineSignalOn1 && MachineSignalOn2)
                                        if (New_Machine_Number[j] > 8) New_Machine_Number[j] = 5;
                                    if (!MachineSignalOn1 && MachineSignalOn2)
                                        if (New_Machine_Number[j] > 4) New_Machine_Number[j] = 1;
                                }
                            }//,  bs.Noise_Room_Number = item.Noise_Room_Number;
                            if (Machine_CheckBox[j].Checked && (ms.Status == MachineState.msOff))
                            {
                                switch (j)
                                {
                                    case 0:
                                        //search noise machine that on condition
                                         New_Machine_Number[j] = roomNo + 1;
                                        //if (MachineSignalOn1 && MachineSignalOn2)
                                        //    if (New_Machine_Number[j] == 8) New_Machine_Number[j] = 1;
                                        //if (!MachineSignalOn1 && MachineSignalOn2)
                                        //    if (New_Machine_Number[j] == 8) New_Machine_Number[j] = 5;
                                        //if (!MachineSignalOn1 && MachineSignalOn2)
                                        //    if (New_Machine_Number[j] == 4) New_Machine_Number[j] = 1;

                                        int offno = 0;
                                        while (true) //(FListFukudaNotification.Count > 0)
                                        {
                                            ms.Machine_Type = "NOISE";
                                            ms.Machine_Number = New_Machine_Number[j];
                                            if (null != OnTransactionMachineBook) { OnTransactionMachineBook(this, ms); }
                                            if (ms.Status == MachineState.msOn)
                                            {
                                                New_Machine_Number[j] = ms.Machine_Number+1;
                                                if (MachineSignalOn1 && MachineSignalOn2)
                                                    if (New_Machine_Number[j] > 8) New_Machine_Number[j] = 1;
                                                if (!MachineSignalOn1 && MachineSignalOn2)
                                                    if (New_Machine_Number[j] > 8) New_Machine_Number[j] = 5;
                                                if (!MachineSignalOn1 && MachineSignalOn2)
                                                    if (New_Machine_Number[j] > 4) New_Machine_Number[j] = 1;
                                                Commons.Commons.SetValueOfProperty(bs, Machine_Room[j], ms.Machine_Number);
                                                CreateListCloseSocket(model, "NOISE", ms.Machine_Number, ref sc, ref ttlCS);
                                                break;
                                            }
                                            else
                                            {
                                                offno++;
                                                New_Machine_Number[j]++;
                                                if (New_Machine_Number[j] > 8) New_Machine_Number[j] = 1;
                                                if (offno > 8)
                                                {
                                                    //CreateMessage(); //create high impact message if all noise machine off
                                                    return;
                                                }
                                            }
                                        }
                                        break;
                                    case 1:
                                    case 2:
                                        ms.Machine_Type = "SIGNAL";
                                        if (j==2) ms.Machine_Type = "RESISTANCE";

                                        if (MachineSignalOn1 && MachineSignalOn2)
                                        {
                                            roomNo = roomNo == 1 ? 2 : 1;
                                            //New_Machine_Number[j] = roomNo + 1;
                                            //if (New_Machine_Number[j] > 2) New_Machine_Number[j] = 1;
                                            ms.Machine_Number = roomNo;// New_Machine_Number[j];
                                            if (null != OnTransactionMachineBook) { OnTransactionMachineBook(this, ms); }
                                            if (ms.Status == MachineState.msOff)
                                            { //CreateMessage(); //create high impact message if all signal machine off
                                                return;
                                            }
                                            else
                                            {
                                               // if (null != OnTransactionMachineBook) { OnTransactionMachineBook(this, ms); }
                                                Commons.Commons.SetValueOfProperty(bs, Machine_Room[j], roomNo );
                                            }
                                        } else
                                            
                                        {
                                            //CreateMessage(); //create high impact message if all signal machine off
                                            return;
                                        }
                                            break;
                                    //case 2:
                                    //    New_Machine_Number[j] = roomNo + 1;
                                    //    if (New_Machine_Number[j] > 2) New_Machine_Number[j] = 1;
                                    //    Commons.Commons.SetValueOfProperty(bs, Machine_Room[j], New_Machine_Number[j]);
                                    //    break;
                                }
                            }

                            //if (!Machine_CheckBox[j].Checked && (ms.Status == MachineState.msOn)) Commons.Commons.SetValueOfProperty(bs, Machine_Room[j], -1);//bs.Noise_Room_Number = 0;
                            if (!Machine_CheckBox[j].Checked && (ms.Status == MachineState.msOn))
                            {
                                Commons.Commons.SetValueOfProperty(bs, Machine_Room[j], roomNo);
                                Commons.Commons.SetValueOfProperty(bs, Bypass_Room[j], true);
                            }//bs.Noise_Room_Number = 0;
                            if (!Machine_CheckBox[j].Checked && (ms.Status == MachineState.msOff)) Commons.Commons.SetValueOfProperty(bs, Machine_Room[j], -2);//bs.Noise_Room_Number = -2;
                                                                                                                                                               //}

                            //if (cs.Count != 0)
                            //{
                            //    if (chkNoise.Checked && (ms.Status == MachineState.msOn))
                            //    {
                            //        for (int i = 1; i <= 64; i++)
                            //        {
                            //            int cs_ = (int)Commons.Commons.GetValueFromProperty(cs[0], "Socket_" + i.ToString());
                            //            if (cs_ == 1)
                            //            {
                            //                if (sc.IndexOf(i.ToString()) == -1) sc = i.ToString() + "," + sc;
                            //            }
                            //            ttlCS = ttlCS + cs_;
                            //        }
                            //    }
                            //    if (sc != "") sc = sc.Substring(0, sc.Length - 1);
                            //    if (chkNoise.Checked && (ms.Status == MachineState.msOn)) Commons.Commons.SetValueOfProperty(bs, Machine_Room[j], roomNo);//,  bs.Noise_Room_Number = item.Noise_Room_Number;
                            //    if (chkNoise.Checked && (ms.Status == MachineState.msOff))
                            //    {
                            //        Commons.Commons.SetValueOfProperty(bs, Machine_Room[j], -1);//bs.Noise_Room_Number = -1;
                            //                                                                    //search other available machine with same type

                            //    }
                            //    if (!chkNoise.Checked && (ms.Status == MachineState.msOn)) Commons.Commons.SetValueOfProperty(bs, Machine_Room[j], 0);//bs.Noise_Room_Number = 0;
                            //    if (!chkNoise.Checked && (ms.Status == MachineState.msOff)) Commons.Commons.SetValueOfProperty(bs, Machine_Room[j], -2);//bs.Noise_Room_Number = -2;
                            //}
                        }
                        bs.Close_Socket_Numbers = "None";
                        if (sc != "")
                        {
                            if (sc[sc.Length - 1] == ',') sc = sc.Substring(0, sc.Length - 1);
                            bs.Close_Socket_Numbers = sc;
                        }
                        // bs.Close_Socket_Numbers = sc;
                        bs.Device_Qty = 64 - ttlCS;
                        if (bs.Device_Qty > ttlDev) bs.Device_Qty= ttlDev;
                        bs.Queue_ID = item.ID;
                        //ttlDev = ttlDev - bs.Device_Qty;
                        if (ttlDev > 0)
                        {
                            model.T_BOOKING_STATIONS.Add(bs);

                        }
                        else { break; }
                        ttlDev = ttlDev - bs.Device_Qty;
                    }
                } while (ttlDev > 0);
            }
        }

        protected override void Transaction(DBProjectEntities model = null)
        {
            if (!DesignMode)
            {
                DateTime dt = DateTime.Now;
                V_LASER_STATION ls = model.Database.SqlQuery<V_LASER_STATION>("select * from V_LASER_STATION").FirstOrDefault();
                //if (ls != null)
                //{
                //    TransactionSorter.Created_User = UserID;
                //    TransactionSorter.Device_ID = txtDeviceID.Text;
                //    TransactionSorter.LotBox_ID = ls.LotBox_ID;
                //    TransactionSorter.LotBox_NG_ID = ls.LotBox_NG_ID;
                //    TransactionSorter.LotBox_Position = ls.LotBox_Position;
                //    TransactionSorter.PO_Number = txtPONumber.Text;
                //    TransactionSorter.Quantity = TransactionInput.Quantity;
                //    TransactionSorter.Updated_User = UserID;

                //    T_LASER_STATION ls2 = model.T_LASER_STATIONS.Where(x => x.ID == ls.ID).FirstOrDefault();
                //    ls2.Status = "BOOKED";
                //    model.Entry(ls2).CurrentValues.SetValues(ls2);
                //}
                T_TRANSACTION_INPUT inp = model.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == txtPONumber.Text).FirstOrDefault();
                if (inp != null)
                {
                    Commons.Commons.CopyProperties(TransactionInput, inp);
                    inp.LotBox_Position_Fukuda = LotboxPosition;
                    //if (ls!=null) inp.LotBox_Position_Laser = ls.LotBox_Position;
                    inp.LotBox_Position_Laser = 0;
                    inp.Status = "Ready";
                    inp.Updated_Date = dt;
                    // model.Entry(inp).CurrentValues.SetValues(inp);
                    //TransactionInput.ApplyNoiseTest = chkNoise.Checked;
                    //TransactionInput.ApplySignalTest = chkSignal.Checked;
                    //TransactionInput.ApplyResistanceTest = chkResistance.Checked;
                    model.Database.ExecuteSqlCommand(
                        "Update T_TRANSACTION_INPUT SET " +
                        "LotBox_Position_Fukuda = {0}, " +
                        "Status = {1}, " +
                        "Updated_Date = {2},  " +
                        "ApplyNoiseTest = {3}, " +
                        "ApplySignalTest = {4}, " +
                        "ApplyResistanceTest = {5} " +
                        "WHERE PO_Number = {6}", 
                        LotboxPosition, "Ready", dt,chkNoise.Checked,chkSignal.Checked,chkResistance.Checked, txtPONumber.Text
                        );
                }
                else
                {
                    string noise_type = TransactionInput.Noise_Type_Parameter_Ref;
                    TransactionInput = new T_TRANSACTION_INPUT();
                    TransactionInput.Created_User = UserID;
                    TransactionInput.Device_ID = txtDeviceID.Text;
                    TransactionInput.LotBox_ID = txtLotBoxID.Text;
                    TransactionInput.LotBox_Position_Fukuda = LotboxPosition;
                        TransactionInput.LotBox_Position_Laser = 0;
                    if (ls != null) TransactionInput.LotBox_Position_Laser = ls.LotBox_Position;
                    TransactionInput.PO_Number = txtPONumber.Text;
                    if (TransactionInput.Signal_Device_ID_Ref == "") TransactionInput.Signal_Device_ID_Ref = txtDeviceID.Text;
                    TransactionInput.Noise_Type_Parameter_Ref = noise_type;
                    TransactionInput.Start_Test = TransactionInput.Created_Date.Value;
                    TransactionInput.Status = "Ready";
                    TransactionInput.Updated_User = UserID;
                    TransactionInput.User_ID = UserID;
                    TransactionInput.Quantity = Convert.ToInt32(txtQuantity.Text);
                    TransactionInput.ApplyNoiseTest = chkNoise.Checked;
                    TransactionInput.ApplySignalTest = chkSignal.Checked;
                    TransactionInput.ApplyResistanceTest = chkResistance.Checked;
                    model.T_TRANSACTION_INPUTS.Add(TransactionInput);
                }
                CreateBooking(model);
            }
        }
        protected override bool SetReadyClick(object sender, EventArgs e)
        {
            bool ret = false;
            ret = SaveData(false, false, pnlMain);
            if (ret) { ButtonControlDisabled = ButtonControlDisabled.bceSetReady; }
            return ret;
        }

        private void panelMessage_OnCloseClick(object sender, EventArgs e)
        {
            if (FocusControl != null) { FocusControl.Focus(); pnlBottom.Visible = true; }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        protected override void CancelClick(object sender, EventArgs e)
        { 
            TransactionInput.PO_Number = txtPONumber.Text;
            base.CancelClick(sender, e);
        }

       private bool CheckDevice(bool All)
        {
            bool ret = true;
            if (!DesignMode)
            {
                using (var db = new DBProjectEntities())
                {
                    M_DEVICE dvc = db.M_DEVICES.Where(x => x.Device_ID == txtDeviceID.Text).FirstOrDefault();
                    if (dvc == null) { ret = false; FocusControl = txtDeviceID; panelMessage.Message = "Device : " + txtDeviceID.Text + " not found\r\n\r\nPlease contact your administrator"; }
                    else { txtDeviceName.Text = dvc.Device_Name; }
                    if (All)
                    {
                        int cch = db.M_NOISE_DEVICES.Where(x => x.Device_ID == txtDeviceID.Text).Count();
                        if (cch == 0) { ret = false; FocusControl = txtDeviceID; panelMessage.Message = "Noise paramater for device : " + txtDeviceID.Text + " not found\r\n\r\nPlease contact your administrator"; }
                        else
                        {
                            M_NOISE_DEVICE noise = db.M_NOISE_DEVICES.Where(x => x.Device_ID == txtDeviceID.Text).FirstOrDefault();
                            TransactionInput.Noise_Type_Parameter_Ref = noise.Test_Type_ID;
                        }
                        cch = db.M_SIGNAL_DEVICE_PARAMETERS.Where(x => x.Device_ID == txtDeviceID.Text).Count();
                        if (cch == 0) { ret = false; FocusControl = txtDeviceID; panelMessage.Message = "Signal paramater for device : " + txtDeviceID.Text + " not found\r\n\r\nPlease contact your administrator"; }
                    }
                }
            }
            return ret;
        }

        private void txtDeviceID_TextChanged(object sender, EventArgs e)
        {
            if (!DesignMode) CheckDevice(true);
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (txtPONumber.Text == "")
            {
                panelMessage.Message = "Please fill PO Number first";
                FocusControl = txtPONumber;
            }
            else
             if (txtDeviceID.Text == "")
            {
                panelMessage.Message = "Please fill Device ID first";
                FocusControl = txtDeviceID;
            }
            else
            {
                TransactionInput.Device_ID = txtDeviceID.Text;
                TransactionInput.PO_Number = txtPONumber.Text;
                frmAuthChangeParameters frm = new frmAuthChangeParameters(TransactionInput);
                frm.ShowDialog();
            }
        }      

        private void txtPONumber_Leave(object sender, EventArgs e)
        {
           // TestMode = TestMode.tmAQL;
            //if (!DesignMode) { if (TestMode!=TestMode.tmAQL) CheckPONumber(); }
        }

        private void txtLotBoxID_Leave(object sender, EventArgs e)
        {
            //if (!DesignMode) { CheckLotBox(); }
        }
    }
}



////Signal Close Socket
//ms.Machine_ID = item.Machine_Signal;
//if (null != OnTransactionMachineBook) { OnTransactionMachineBook(this, ms); }
//cs = db.V_MACHINE_CLOSE_SOCKETS.Where(x => x.Machine_ID == item.Machine_Signal).FirstOrDefault();
//if (cs != null)
//{
//    if (chkSignal.Checked && (ms.Status == MachineState.msOn))
//    {
//        for (int i = 1; i <= 64; i++)
//        {
//            ttlCS = ttlCS + (int)Commons.Commons.GetValueFromProperty(cs, "Socket_" + i.ToString());
//        }
//    }
//    if (chkNoise.Checked && (ms.Status == MachineState.msOn)) bs.Signal_Room_Number = item.Signal_Room_Number;
//    if (chkNoise.Checked && (ms.Status == MachineState.msOff)) bs.Signal_Room_Number = -1;
//    if (!chkNoise.Checked && (ms.Status == MachineState.msOn)) bs.Signal_Room_Number = 0;
//    if (!chkNoise.Checked && (ms.Status == MachineState.msOff)) bs.Signal_Room_Number = -2;
//}

////Resistance Close Socket
//ms.Machine_ID = item.Machine_Resistance;
//if (null != OnTransactionMachineBook) { OnTransactionMachineBook(this, ms); }
//cs = db.V_MACHINE_CLOSE_SOCKETS.Where(x => x.Machine_ID == item.Machine_Resistance).FirstOrDefault();
//if (cs != null)
//{
//    if (chkSignal.Checked && (ms.Status == MachineState.msOn))
//    {
//        for (int i = 1; i <= 64; i++)
//        {
//            ttlCS = ttlCS + (int)Commons.Commons.GetValueFromProperty(cs, "Socket_" + i.ToString());
//        }
//    }
//    if (chkNoise.Checked && (ms.Status == MachineState.msOn)) bs.Resistance_Room_Number = item.Resistance_Room_Number;
//    if (chkNoise.Checked && (ms.Status == MachineState.msOff)) bs.Resistance_Room_Number = -1;
//    if (!chkNoise.Checked && (ms.Status == MachineState.msOn)) bs.Resistance_Room_Number = 0;
//    if (!chkNoise.Checked && (ms.Status == MachineState.msOff)) bs.Resistance_Room_Number = -2;
//}