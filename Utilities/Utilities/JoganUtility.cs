using Commons;
using DBProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwinCAT.Ads;

namespace Utilities
{
    public enum StartThreadFor { All, Fukuda, DBCheckError, DBCheckStationReady, Rotary1, Rotary2, MachineTester, Laser,FukudaSimulation, MachineSimulation, LaserSimulation };
    //public enum StatusTestingControl {On,Off,Start,Finish,Empty,Attached,Standby,Ready};
    public enum JoganFunctionAs { AsControllerWatcher, AsWatcher };
    public enum HMISide { HMI1,HMI2};
    public enum InfoMassageImpact { None, Low, Medium, High };
    public delegate void EventMessage(object sender, V_MESSAGE e);
    public delegate void EventUnloadingStation(object sender, StatusTestingControl Status, JoganUnloadingStation e);
    public delegate void EventLoadingStation(object sender, StatusTestingControl Status, JoganLoadingStation e);
    public delegate void EventMachineTester(object sender, StatusTestingControl Status, JoganMachineTester e);
    public delegate void EventInfoMachineTester(object sender, JoganMachineTester e, bool GetInfo = true);
    //public delegate void EventInfoMachineTester(object sender, JoganMachineTester e);
    public delegate object GetObjectToSaveHistroy();
    public class Simulation
    {
        private System.Windows.Forms.Timer FTimerSimulation;
        public System.Windows.Forms.Timer TimerSimulation { get { return FTimerSimulation; } }
        private string FVariableSender;
        public string VariableSender { get { return FVariableSender; } set { FVariableSender = value; } }
        private int FInterval;
        private int FCounter;
        private void Timer_Tick(object sender, EventArgs e)
        {
            FCounter++;
            if (FCounter == FInterval)
            {
                FTimerSimulation.Enabled = false;
                if (OnTimeEllapse != null) OnTimeEllapse();
            }
        }
        public int Interval { get { return FInterval; } set { FInterval = value; FTimerSimulation.Interval = value; } }

        public SimulationAction OnTimeEllapse;
        public void StartTimer(SimulationAction ASimulationAction)
        {
            FTimerSimulation.Enabled = true;
            if (ASimulationAction != null) OnTimeEllapse = ASimulationAction;
        }
        public Simulation(SimulationAction ASimulationAction)
        {
            FInterval = 90;
            FTimerSimulation = new System.Windows.Forms.Timer();
            FTimerSimulation.Interval = 1000;
            FTimerSimulation.Tick += new EventHandler(Timer_Tick);
            // if (ASimulationAction != null) OnTimeEllapse = ASimulationAction;
            FTimerSimulation.Enabled = true;
        }
    }
    public class JoganThreadProp
    {
        public bool IsStop { get; set; }
        public bool IsPaused { get; set; }
        public Thread CurrentThread { get; set; }
    }
    public class JoganJigCarrier
    {
        public string JigID { get; set; }
        public string PONumber { get; set; }
    }
    public class JoganMachinePosition
    {
        public string MachineType { get; set; }
        public int MachineLine { get; set; }
        public int MachineNumber { get; set; }
    }
    public class JoganC8Tester
    {
        public JoganMachinePosition Destination { get; set; }
        public JoganMachinePosition Source { get; set; } 
    }
    public class JoganMachineTester
    {
        public string MachineCode { get; set; }
        public string MachineName { get; set; }
        public string JigID { get; set; }
        public int Interval { get; set; } 
        public bool IsDoneTesting { get; set; }
        public bool IsByPassTest { get; set; }
        public int LineID { get; set; }
        public StatusTestingControl Status { get; set; }
        public DateTime TestDoneTime { get; set; }
        //public MachineTesterControl MachineControl { get; set; }
    }
    public class BufferCarrierItem
    {
        public string BufferFrom { get; set; }
        public string BufferTo { get; set; }
        public string JigID { get; set; }
    }
    public class BufferCarrier: IDisposable
    {
        public int BufferCount { get; set; }
        private List<BufferCarrierItem> FItems;
        public List<BufferCarrierItem> Items { get { return FItems; } }
        public void AddItem(BufferCarrierItem ABufferCarrierItem)
        {
            FItems.Add(ABufferCarrierItem);
        }
        public BufferCarrier(int ABufferCount)
        {
            BufferCount = ABufferCount;
        }
        public void ClearItems()
        {
            if (FItems == null) return;
            for (int i = FItems.Count - 1; i <= 0; i--)
            {
                FItems[i] = null;
            }
            FItems.Clear();
        }
        public bool IsBufferFree()
        {
            return FItems.Count == BufferCount;
        }
        public void RemoveItem(int index)
        {
            FItems[index] = null;
            FItems.RemoveAt(index);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~BufferCarrier() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            ClearItems();
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
    public class JoganUnloadingStation
    {
        public T_CURRENT_TRANSACTION CurrentTransaction;
        public T_TRANSACTION_INPUT TransactionInput;
    }
    public class JoganLoadingStation
    {
        public T_TRANSACTION_INPUT TransactionInput;
        public T_SORTER_SUMMARY SorterSummary;
    }
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public class T_CURRENT_TRANSACTION
    { 
        public byte STATION_NUMBER_LOAD;
        public byte STATION_NUMBER_RETURN;
        public byte CURRENT_DEVICE_COUNT;
        public byte QUANTITY_MAX;
        public byte QUANTITY_LOTEND;
        public byte JIG_INDEX_LOAD;
        public byte JIG_INDEX_RETURN;
        public byte JIG_INDEX_LOAD_NG;
        public byte JIG_INDEX_RETURN_NG;
        public byte TRANSPORT_INDEX;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string PO_NUMBER = "";
    }
    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public class T_JIG_SOCKET
    {
        public byte STATION_NUMBER;
        public byte CURRENT_DEVICE_COUNT;
        public byte MAX_DEVICE_COUNT;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] AVAILABLE_SOCKET = new byte[5];
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] LASER_DESTINATION = new byte[5];
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)]
        public string PO_NUMBER = "";
    }

    [StructLayout(LayoutKind.Sequential, Pack = 0)]
    public class T_MACHINE_POSITION
    {
        public byte DESTINATION_COORDINATE;
        public byte SUB_DESTINATION_COORDINATE;
        public byte SOURCE_COORDINATE; 
    }

    //public
    public class JoganTransfer
    {public int ID { get; set; }
        public bool DoneTransport { get; set; }
        public bool LotEndOnMe { get; set; }
        public int JigIndex { get; set; }
        public int StationNumber { get; set; }
        private JoganUtility FOwner;
        public JoganUtility Owner { get { return FOwner; } set { FOwner = value; } }
        public JoganTransfer(JoganUtility AOwner)
        {
            FOwner = AOwner;
        }

        //Fukuda transport flag
        //B (Back)              F (Front)               D (Done)    Byte
        //0                     0                       0           0                           //transport on the back with empty jig
        //1                     0                       0           4                           //Load condition : move jig from lotbox to transport
        //1                     0                       1           5                           //Load condition : move jig from lotbox to transport
        //0                     1                       1           3                           //Return condition : move jig from transport to lotbox
        private int FFlag;
        public int Flag { get { return GetFlag();  } set { SetFlag(value); } }

        public virtual void SetFlag(int value)
        {
            FFlag=value;
        }

        public virtual int GetFlag()
        {
            return FFlag;
        }
    }
    //public class FukudaHandler: Fukuda
    //{
    //    private FukudaHandlerStatus FFukudaHandlerStatus;
    //    public FukudaHandlerStatus FukudaHandlerStatus { get { return FFukudaHandlerStatus; } set { FFukudaHandlerStatus = value; } }
    //    public FukudaHandler(JoganUtility AOwner) :base(AOwner)
    //    {
             
    //    }

        
    //}
    public class FukudaTransfer : JoganTransfer
    { 
        public FukudaTransfer(JoganUtility AOwner) : base(AOwner)
        { 
        }
        
        public override int GetFlag()
        {
            string ids = "A";
            if (ID == 2) ids = "B";
            bool B = (bool)Owner.TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_" + ids, TypeOfData.tpBool);
            bool F = (bool)Owner.TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_" + ids, TypeOfData.tpBool);
            bool D = (bool)Owner.TwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_" + ids + "_PICK_DONE", TypeOfData.tpBool);
            int b = B ? 1 : 0; b = b << 2;
            int f = F ? 1 : 0; f = f << 1;
            int d = D ? 1 : 0;
            int flag = b + f + d;
            return flag;
        }

        public void SetFlag(bool B, bool F, bool D)
        {
            int b = B ? 1 : 0; b = b << 2;
            int f = F ? 1 : 0; f = f << 1;
            int d = D ? 1 : 0;
            int flag = b + f + d;
            if (flag == 3) if (Owner != null) Owner.PrepareUnloadingJigFukuda(this, false);
        } 
    }
    public class LaserTransfer : JoganTransfer
    {
        public LaserTransfer(JoganUtility AOwner) : base(AOwner)
        {
        }

        public override int GetFlag()
        {
            string ids = "A";
            if (ID == 2) ids = "B";
            bool B = (bool)Owner.TwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_LASER_TRANSFER_AT_BACK_" + ids, TypeOfData.tpBool);
            bool F = (bool)Owner.TwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_LASER_TRANSFER_AT_FRONT_" + ids, TypeOfData.tpBool);
            bool D = (bool)Owner.TwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_LASER_TRANSFER_" + ids + "_PICK_DONE", TypeOfData.tpBool);
            int b = B ? 1 : 0; b = b << 2;
            int f = F ? 1 : 0; f = f << 1;
            int d = D ? 1 : 0;
            int flag = b + f + d;
            return flag;
        }

        public void SetFlag(bool B, bool F, bool D)
        {
            int b = B ? 1 : 0; b = b << 2;
            int f = F ? 1 : 0; f = f << 1;
            int d = D ? 1 : 0;
            int flag = b + f + d;
            if (flag == 3) if (Owner != null) Owner.PrepareLoadingJigLaser(this, false);
        }
    }
    public class JoganUtility:IDisposable
    {
        public const int MAX_DEVICE_JIG_LOTBOX_INPUT= 80;
        public const int MAX_DEVICE_JIG_LOTBOX_LASER = 20;
        public event JoganThreadWorking OnJoganThreadWorking;
        private const int RECV_DATA_MAX = 10240;
        private const int WAIT_DELAY_TIME = 500;//in miliseconds
        private const int WAIT_THREAD_TIME = 1000;//in miliseconds
        private List<int> FListCloseSocket;
        private Dictionary<int,int> FListTestResult;

        private JoganUnloadingStation FUnloadingStation;
        private JoganUnloadingStation FOldUnloadingStation;
        private JoganLoadingStation FLoadingStation;
        private JoganLoadingStation FOldLoadingStation;

        private JoganFunctionAs FJoganFunctionAs;
        public JoganFunctionAs JoganFunctionAs
        {
            get { return FJoganFunctionAs; }
            set { SetJoganFunctionAs(value); }
        }

        private HMISide FRunApplicationOn;
        public HMISide RunApplicationOn
        {
            get { return FRunApplicationOn; }
            set { FRunApplicationOn=value; }
        }

        private void SetJoganFunctionAs(JoganFunctionAs value)
        {
            FJoganFunctionAs = value;
            //if (FJoganFunctionAs == JoganFunctionAs.AsControllerWatcher)
            //{
            //    Start();
            //} else
            //{
            //    Stop();
            //}
        }

        private int FCounterJigID = 0;
        private int FCounterDeviceJigInput = 0;
        private int FCounterDeviceJigOutput = 0;
        private int FCounterDeviceJigCarrier = 0;

        public string NetID { get; set; }
        private bool FAllowConnect;
        public bool AllowConnect { get { return FAllowConnect; } set { SetAllowConnect(value); } }
        private void SetAllowConnect(bool AValue)
        {
            FAllowConnect = AValue;
            if (AValue)
            {
                if (FTwinCat3Utility == null) FTwinCat3Utility = new TwinCat3Utility();
                FTwinCat3Utility.AllowConnect = AValue;
                PreparePLC();
                Start();
            }
            else
            {
                if (FTwinCat3Utility != null) FTwinCat3Utility.Dispose();
                Stop();
            }
        }
        private bool FEndProccess;
        private bool FPauseProccess; 
        //private bool FIsStationReady;
        private bool FIsLotEndFukuda;
        private bool FIsLotEndLaser; 
        private bool FI_LOADER_RS4_ENABLE;
        private bool FI_SORTER_RS4_ENABLE;
        private bool FIsExitRecursive;
        private int[] FMachineSequences = new int[3] { 0, 0, 0 };

        private bool FIsLotEndFukudaReturnDone;
        private T_TRANSACTION_INPUT FTransactionInput; 
        //private T_TRANSACTION_INPUT FTransactionLaser;
        public T_TRANSACTION_INPUT FTransactionInputNearLaser;
        private T_TRANSACTION_INPUT FTempTransactionInputNearLaser;
        private T_CURRENT_TRANSACTION FCurrentTransaction;
        private JoganThreadProp FJoganThreadProp;
        private bool FMessageIsSend;
        private bool FIsFirstTime;
        public bool EndProcess { get { return FEndProccess; } set { FEndProccess = value; } }
        public bool HaltProccess { get { return FPauseProccess; } set { FPauseProccess = value; } }
        private string FJoganUserID;
        public string JoganUserID { get { return FJoganUserID; } set { FJoganUserID = value; } }
        private TwinCat3Utility FTwinCat3Utility; 
        public TwinCat3Utility TwinCat3Utility { get { return FTwinCat3Utility; } }
        private Dictionary<StartThreadFor, JoganThreadProp> FThreads;

        private List<string> FListFukudaNotification;
        private List<string> FListLaserNotification;
        private List<string> FListMachineTesterNotification;
        private List<string> FListRotary1Notification;
        private List<string> FListRotary2Notification;
        private JoganC8Tester FJoganC8Tester;
        private BufferCarrier FBufferCarrier;
        private int FSorterCounter = 1;

        //private Simulation FSimulation;

        //this event was purposed to combine other notification then not belong to JoganUtility
        public event AdsNotificationEventHandler OnJoganUtilityPLCNotification;
        public event EventMessage OnNewMessage;  
        public event EventUnloadingStation OnUnloadingStation;
        public event EventLoadingStation OnLoadingStation; 
        public event EventMachineTester OnEventMachineTester;
        public event EventInfoMachineTester OnInfoMachineTester;
        public event EventInfoMachineTester OnAfterStartMachineTester;
        public event EventInfoMachineTester OnBeforeStartMachineTester;
        public event EventInfoMachineTester OnAfterStopMachineTester;
        public event EventInfoMachineTester OnBeforeStopMachineTester;
        public List<TwinCat3Property> TwinCat3PropertyList
        {
            get { return FTwinCat3Utility.TwinCat3PropertyList; }
        }

        //get data from 2d code scanner
        public virtual object ReadAnyFromPLC(string VariableName, TypeOfData TypeOfData, Type ComplexTypeData = null)
        {
            if (!FAllowConnect) return null;
            return FTwinCat3Utility.ReadAnyFromPLC(VariableName, TypeOfData, ComplexTypeData);
        }

        public virtual void WriteAnyToPLC(string VariableName, TypeOfData TypeOfData, object Value)
        {
            if (!FAllowConnect) return;
            FTwinCat3Utility.WriteAnyToPLC(VariableName, TypeOfData, Value);
        }
        public void AddPLCVariable(string AVariableName, object ADataObject1 = null, object ADataObject2 = null)
        {
            if (!FAllowConnect) return; 
            FTwinCat3Utility.AddPLCVariable(AVariableName, ADataObject1, ADataObject2);
        }
        public void ConnectPLC(string NetID)
        {
            if (!FAllowConnect) return; 
            FTwinCat3Utility.ConnectPLC(NetID);
        }

        private  void WaitAsynchronous(JoganThreadProp AJoganThreadProp,JoganWaitAction AJoganWaitAction)
        {
            AJoganThreadProp.IsPaused = true;
            while (AJoganWaitAction())
            {
                 Task.Delay(WAIT_DELAY_TIME);
            }
            AJoganThreadProp.IsPaused = false;
        }

        private  void WaitAsynchronous(JoganThreadProp AJoganThreadProp, JoganWaitAction AJoganWaitAction, JoganUtilityAction AJoganUtilityAction)
        {
             AJoganThreadProp.IsPaused = true;
            while (AJoganWaitAction())
            {
                 Task.Delay(WAIT_DELAY_TIME);
            }
             AJoganThreadProp.IsPaused = false;
            if (AJoganUtilityAction != null) AJoganUtilityAction();
        }

        private void WaitSynchronous(JoganWaitAction AJoganWaitAction)
        {
            //Thread th = new Thread()
            while (AJoganWaitAction())
            {
                Application.DoEvents();
                Thread.Sleep(WAIT_DELAY_TIME);
            }
        }
        private void WaitSynchronous(JoganWaitAction AJoganWaitAction, JoganUtilityAction AJoganUtilityAction)
        {
            //Thread th = new Thread()
            while (AJoganWaitAction())
            {
                Application.DoEvents();
                Thread.Sleep(WAIT_DELAY_TIME);
            }
            if (AJoganUtilityAction != null) AJoganUtilityAction();
        }
        private  void WaitAsynchronous(JoganWaitAction AJoganWaitAction, JoganUtilityAction AJoganUtilityAction)
        {
            //Thread th = new Thread()
            while (AJoganWaitAction())
            {
                 Task.Delay(WAIT_DELAY_TIME);
            }
            if (AJoganUtilityAction != null) AJoganUtilityAction();
        }

        private void CheckStationReady()
        {
            if (!FAllowConnect) return;
            using (var db = new DBProjectEntities())
            {
                //if (FIsLotEnd)
                //{
                //    //update status when all jigs on lotbox done unloaded
                //    FTransactionInput = db.T_TRANSACTION_INPUTS.Where(x => x.Status == "UNLOAD JIG").FirstOrDefault();

                //    if (FTransactionInput != null)
                //    {
                //        FTransactionInput.Status = "TESTING";
                //        FTransactionInput.Updated_Date = DateTime.Now;
                //        db.Entry(FTransactionInput).CurrentValues.SetValues(FTransactionInput);
                //        TrySaveChange(db);
                //        if (OnUnloadingStation != null)  OnUnloadingStation(this, StatusTestingControl.Finish, FTransactionInput);
                //        FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_ONE_OF_STATIONS_READY", TypeOfData.tpBool, false);
                //    }
                //}
                //FIsStationReady = false;
                // if (!FIsStationReady)
                {
                    //in case system halt or endprocess, if start again, let continue unfinished unload lotbox
                    //int oldindex = -1;
                    //FTransactionInput = db.T_TRANSACTION_INPUTS.Where(x => x.Status == "UNLOAD JIG").OrderBy(x => x.Updated_Date).FirstOrDefault();
                    ////if all finished before system halt or endprocess, let start next new lotbox
                    //if (FTransactionInput == null) FTransactionInput = db.T_TRANSACTION_INPUTS.Where(x => x.Status == "Ready").OrderBy(x => x.Updated_Date).FirstOrDefault();
                    //else {
                    //    T_CURRENT_TRANSACTION ct = null;
                    //    ct = (T_CURRENT_TRANSACTION)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
                    //    oldindex = ct.JIG_INDEX_LOAD;
                    //}
                    T_TRANSACTION_INPUT ti = db.T_TRANSACTION_INPUTS.Where(x => x.Status == "Ready").OrderBy(x => x.Updated_Date).FirstOrDefault();
                    if (ti != null)
                    {
                        //FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOTEND", TypeOfData.tpBool, false);
                        //FIsStationReady = true;
                        //FCurrentTransaction.PO_NUMBER = FTransactionInput.PO_Number;
                        //FCurrentTransaction.QUANTITY_MAX = (byte)FTransactionInput.Quantity;
                        //FCurrentTransaction.STATION_NUMBER_LOAD = (byte)FTransactionInput.LotBox_Position_Fukuda;
                        //FCurrentTransaction.JIG_INDEX_LOAD = (byte)(oldindex == -1 ? 1 : oldindex);
                        //FCurrentTransaction.JIG_INDEX_RETURN = 0;
                        //FCurrentTransaction.TRANSPORT_INDEX = 0;
                        //FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, FCurrentTransaction);

                        ti.Status = "Standby";
                        ti.Updated_Date = DateTime.Now;
                        db.Entry(ti).CurrentValues.SetValues(ti);
                        TrySaveChange(db);
                        Commons.Commons.CopyProperties(ti, FOldUnloadingStation.TransactionInput);
                        //FOldUnloadingStation.TransactionInput 
                        FOldUnloadingStation.CurrentTransaction = null;
                        //if (!FMessageIsSend)
                        {
                            if (OnUnloadingStation != null) OnUnloadingStation(this, StatusTestingControl.Standby, FOldUnloadingStation);
                            if (OnNewMessage != null) OnNewMessage(this, new V_MESSAGE
                            {
                                Message_Code = "",
                                Message_Name = "Lotbox on Fukuda Station " + ti.LotBox_Position_Fukuda.ToString() + " standby to unload",
                                Hardware_ID = "Fukuda Station " + ti.LotBox_Position_Fukuda.ToString(),
                                Impact = "Low",
                            });
                            //FMessageIsSend = true;
                        } 
                        ////
                        //Delay(delegate ()
                        //{
                        //    return
                        //    //(bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOADING_DONE_A", TypeOfData.tpBool) || 
                        //    //(bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOADING_DONE_B", TypeOfData.tpBool);
                        //    (FFukudaTransfer1.Flag == 4 || FFukudaTransfer1.Flag == 5) ||
                        //    (FFukudaTransfer2.Flag == 4 || FFukudaTransfer2.Flag == 5);
                        //});
                        //PrepareUnloadingJigFukuda();
                    }
                    int cch = db.T_TRANSACTION_INPUTS.Where(x => x.Status == "Standby").Count();
                    if (cch == 0 && FIsLotEndFukudaReturnDone)
                    {
                        if (FFukudaTransfer1.DoneTransport) FFukudaTransfer1.StationNumber = 0; 
                        if (FFukudaTransfer2.DoneTransport) FFukudaTransfer2.StationNumber = 0;
                        if (!FMessageIsSend)
                        {
                            if (OnNewMessage != null) OnNewMessage(this, new V_MESSAGE
                            {
                                Message_Code = "",
                                Message_Name = "Please attach lotbox to start unload",
                                Hardware_ID = "Station",
                                Impact = "Low",
                            });
                            FMessageIsSend = true;
                        }
                    }
                    if (cch!=0 && FIsLotEndFukuda && FIsFirstTime)
                    {
                        //FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOTEND", TypeOfData.tpBool, false);
                        //Delay(delegate ()
                        //{
                        //    return
                        //    //(bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOADING_DONE_A", TypeOfData.tpBool) || 
                        //    //(bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOADING_DONE_B", TypeOfData.tpBool);
                        //    (FFukudaTransfer1.Flag == 0 || FFukudaTransfer1.Flag == 4 || FFukudaTransfer1.Flag == 5) ||
                        //    (FFukudaTransfer2.Flag == 0 || FFukudaTransfer2.Flag == 4 || FFukudaTransfer2.Flag == 5);
                        //});
                        //FIsFirstTime = false;
                        //PrepareUnloadingJigFukuda(null, true);
                        WaitAsynchronous(FThreads[StartThreadFor.Fukuda],  delegate ()
                        {
                            return
                            //(bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOADING_DONE_A", TypeOfData.tpBool) || 
                            //(bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOADING_DONE_B", TypeOfData.tpBool);
                            !((FFukudaTransfer1.Flag == 0 || FFukudaTransfer1.Flag == 4 || FFukudaTransfer1.Flag == 5) ||
                            (FFukudaTransfer2.Flag == 0 || FFukudaTransfer2.Flag == 4 || FFukudaTransfer2.Flag == 5));
                        }, delegate() {
                            FIsFirstTime = false;
                            PrepareUnloadingJigFukuda(null, true);
                        });
                       
                    }
                }
            }
        }
        public JoganUtility()
        {
            AllowConnect = false;
            PrepareUtility();
        }
        public JoganUtility(string NetID)
        {
            AllowConnect = false;
            PrepareUtility();
            //FTwinCat3Utility = new TwinCat3Utility();
        }
        public T ReadHistory<T>(object AObject)
        { 
            using (var db = new DBProjectEntities())
            {
                T_JOGAN_HISTORY data = db.Database.SqlQuery<T_JOGAN_HISTORY>("select * from T_JOGAN_HISTORY where ID (select max(ID) from T_JOGAN_HISTORY where Object_Activity ='" + AObject.ToString()+ "')").FirstOrDefault();
                if (data!=null) return Commons.Commons.DeserializeIt<T>(data.Last_Activity, true);
            }
            return default(T);
        }
        public void SaveHistory(GetObjectToSaveHistroy AGetObjectToSaveHistroy)
        {
            if (AGetObjectToSaveHistroy == null) return;
            object obj = AGetObjectToSaveHistroy();
            if (obj == null) return;
            using (var db = new DBProjectEntities())
            {
                DateTime dt = DateTime.Now;
                T_JOGAN_HISTORY tjh = new T_JOGAN_HISTORY
                {
                    Created_Date = dt,
                    Created_User = JoganUserID,
                    ID = 0,
                    Last_Activity = Commons.Commons.SerializeIt(obj, true),
                    Object_Activity = obj.ToString(),
                    Updated_Date = dt,
                    Updated_User = JoganUserID
                };
                db.T_JOGAN_HISTORIES.Add(tjh);
                TrySaveChange(db);
            }
        }
        private void SetActiveTransport(int AIndex)
        {

        }
        private void StartThread(StartThreadFor AStartThreadFor)
        {
            //JoganThreadProp th = null;
            if (FThreads.ContainsKey(AStartThreadFor))
            {

                FJoganThreadProp = FThreads[AStartThreadFor];
                FJoganThreadProp.IsStop = false;
                switch (AStartThreadFor)
                {
                    case StartThreadFor.DBCheckError:
                        if ((FJoganThreadProp.CurrentThread == null))
                        {
                            FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForCheckError));
                        }
                        else { 
                            if (FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Running && FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Background)
                                FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForCheckError));
                        }
                        break;
                    case StartThreadFor.DBCheckStationReady:
                        if ((FJoganThreadProp.CurrentThread == null))
                        {
                            FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForStationReady));
                        }
                        else
                        {
                            if (FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Running && FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Background)
                                FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForStationReady));
                        }
                        break;
                    case StartThreadFor.Fukuda:
                        if ((FJoganThreadProp.CurrentThread == null))
                        {
                            FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForFukuda));
                        }
                        else
                        {
                            if (FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Running && FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Background)
                                FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForFukuda));
                        }
                        break;
                    case StartThreadFor.Rotary1:
                        if ((FJoganThreadProp.CurrentThread == null))
                        {
                            FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForRotary1));
                        }
                        else
                        {
                            if (FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Running && FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Background)
                                FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForRotary1));
                        }
                        break;
                    case StartThreadFor.Rotary2:
                        if ((FJoganThreadProp.CurrentThread == null))
                        {
                            FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForRotary2));
                        }
                        else
                        {
                            if (FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Running && FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Background)
                                FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForRotary2));
                        }
                        break;
                    case StartThreadFor.Laser:
                        if ((FJoganThreadProp.CurrentThread == null))
                        {
                            FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForLaser));
                        }
                        else
                        {
                            if (FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Running && FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Background)
                                FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForLaser));
                        }
                        break;
                    case StartThreadFor.MachineTester:
                        if ((FJoganThreadProp.CurrentThread == null))
                        {
                            FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForMachineTester));
                        }
                        else
                        {
                            if (FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Running && FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Background)
                                FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForMachineTester));
                        }
                        break;
                    case StartThreadFor.FukudaSimulation:
                        if ((FJoganThreadProp.CurrentThread == null))
                        {
                            FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForFukudaSimulation));
                        }
                        else
                        {
                            if (FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Running && FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Background)
                                FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForFukudaSimulation));
                        }
                        break;
                    case StartThreadFor.MachineSimulation:
                        if ((FJoganThreadProp.CurrentThread == null))
                        {
                            FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForMachineSimulation));
                        }
                        else
                        {
                            if (FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Running && FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Background)
                                FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForMachineSimulation));
                        }
                        break;
                    case StartThreadFor.LaserSimulation:
                        if ((FJoganThreadProp.CurrentThread == null))
                        {
                            FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForLaserSimulation));
                        }
                        else
                        {
                            if (FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Running && FJoganThreadProp.CurrentThread.ThreadState != ThreadState.Background)
                                FJoganThreadProp.CurrentThread = new Thread(new ThreadStart(ThreadForLaserSimulation));
                        }
                        break;
                }
                FJoganThreadProp.CurrentThread.IsBackground = true;
                FJoganThreadProp.CurrentThread.Name = AStartThreadFor.ToString();
                FJoganThreadProp.CurrentThread.Start();
            }
        }
        private void StopThread(StartThreadFor AStartThreadFor)
        {
            if (FThreads != null)
            {
                if (FThreads.ContainsKey(AStartThreadFor))
                {
                    JoganThreadProp th = FThreads[AStartThreadFor];
                    if (th != null)
                    {
                        th.IsStop = true;
                        if (th.CurrentThread != null)
                        {
                            th.CurrentThread.Interrupt();
                            th.CurrentThread.Join();
                        }
                    }
                }
            }
        }
        public void Start(StartThreadFor AStartThreadFor=StartThreadFor.All)
        {
            FEndProccess = false;
            FPauseProccess = false;
            if (FJoganFunctionAs == JoganFunctionAs.AsWatcher) return;
            if (AStartThreadFor == StartThreadFor.All)
            { 
                StartThread(StartThreadFor.DBCheckError);
                if (JoganFunctionAs == JoganFunctionAs.AsControllerWatcher)
                {
                    StartThread(StartThreadFor.DBCheckStationReady);
                    StartThread(StartThreadFor.Fukuda);
                    StartThread(StartThreadFor.Rotary1);
                    StartThread(StartThreadFor.Rotary2);
                    StartThread(StartThreadFor.MachineTester);
                    //StartThread(StartThreadFor.Laser);
                }
            }
            else { StartThread(AStartThreadFor); } 
        }
        public void Stop(StartThreadFor AStartThreadFor = StartThreadFor.All)
        {
            if (AStartThreadFor == StartThreadFor.All)
            { 
                StopThread(StartThreadFor.DBCheckError);
                if (JoganFunctionAs == JoganFunctionAs.AsControllerWatcher)
                {
                    StopThread(StartThreadFor.DBCheckStationReady);
                    StopThread(StartThreadFor.Fukuda);
                    StopThread(StartThreadFor.Rotary1);
                    StopThread(StartThreadFor.Rotary2);
                    StopThread(StartThreadFor.MachineTester);
                    //StopThread(StartThreadFor.Laser);
                }
            }
            else { StopThread(AStartThreadFor); }
        } 
        public void Pause(bool IsPause)
        {
            FPauseProccess = IsPause;
            FTwinCat3Utility.WriteAnyToPLC("FLAG_VAR.PAUSE_SYSTEM", TypeOfData.tpBool, IsPause);
            FThreads[StartThreadFor.DBCheckStationReady].IsPaused= IsPause;
            FThreads[StartThreadFor.Fukuda].IsPaused = IsPause;
            FThreads[StartThreadFor.Rotary1].IsPaused = IsPause;
            FThreads[StartThreadFor.Rotary2].IsPaused = IsPause;
            FThreads[StartThreadFor.MachineTester].IsPaused = IsPause;
            FThreads[StartThreadFor.Laser].IsPaused = IsPause;
        }
        private void PrepareUtility()
        {
            FFukudaTransfer1 = new FukudaTransfer(this);
            FFukudaTransfer1.DoneTransport = true;
            FFukudaTransfer1.ID = 1;
            FFukudaTransfer2 = new FukudaTransfer(this);
            FFukudaTransfer2.ID = 2;
            FFukudaTransfer2.DoneTransport = true;

            FLaserTransfer1 = new LaserTransfer(this);
            FLaserTransfer1.DoneTransport = true;
            FLaserTransfer1.ID = 1;
            FLaserTransfer2 = new LaserTransfer(this);
            FLaserTransfer2.ID = 2;
            FLaserTransfer2.DoneTransport = true;
            FLaserTransferNG = new LaserTransfer(this);
            FLaserTransferNG.ID = 3;
            FLaserTransferNG.DoneTransport = true;

            FTransactionInputNearLaser = new T_TRANSACTION_INPUT { LotBox_Position_Laser = 0 };

            //FIsStationReady = false;
            FIsLotEndFukuda = false;
            FIsLotEndLaser = false;
            FI_LOADER_RS4_ENABLE = false;
            FI_SORTER_RS4_ENABLE = false;
            FCurrentTransaction = new T_CURRENT_TRANSACTION();
            //FFukudaHandler = new FukudaHandler(this);
            FListFukudaNotification = new List<string>();
            FListLaserNotification = new List<string>();
            FListFukudaNotification = new List<string>();
            FListRotary1Notification = new List<string>();
            FListRotary2Notification = new List<string>();
            FListMachineTesterNotification = new List<string>();
            FListCloseSocket = new List<int>();
            FListTestResult = new Dictionary<int, int>();
            FUnloadingStation = new JoganUnloadingStation();
            FLoadingStation = new JoganLoadingStation();
            FOldUnloadingStation = new JoganUnloadingStation();
            FOldUnloadingStation.TransactionInput = new T_TRANSACTION_INPUT();
            FOldLoadingStation = new JoganLoadingStation();
            FThreads = new Dictionary<StartThreadFor, JoganThreadProp>();
            FMessageIsSend = false;
            FIsLotEndFukudaReturnDone = true; FIsFirstTime = true;
            FBufferCarrier = new BufferCarrier(2);
            //FSimulation = new Simulation(null);
            //foreach (StartThreadFor enum_ in Enum.GetValues(typeof(StartThreadFor)))
            //{
            //    JoganThreadProp tp = new JoganThreadProp { IsStop = false, CurrentThread = null };
            //    if (enum_!= StartThreadFor.All) FThreads.Add(enum_, tp);
            //}

            FThreads.Add(StartThreadFor.DBCheckError, new JoganThreadProp { IsStop = false, IsPaused=false,CurrentThread = null });
            FThreads.Add(StartThreadFor.DBCheckStationReady, new JoganThreadProp { IsStop = false, IsPaused = false, CurrentThread = null });
            FThreads.Add(StartThreadFor.Fukuda, new JoganThreadProp { IsStop = false, IsPaused = false, CurrentThread = null });
            FThreads.Add(StartThreadFor.Rotary1, new JoganThreadProp { IsStop = false, IsPaused = false, CurrentThread = null });
            FThreads.Add(StartThreadFor.Rotary2, new JoganThreadProp { IsStop = false, IsPaused = false, CurrentThread = null });
            FThreads.Add(StartThreadFor.Laser, new JoganThreadProp { IsStop = false, IsPaused = false, CurrentThread = null });
            FThreads.Add(StartThreadFor.FukudaSimulation, new JoganThreadProp { IsStop = false, IsPaused = false, CurrentThread = null });
            FThreads.Add(StartThreadFor.MachineSimulation, new JoganThreadProp { IsStop = false, IsPaused = false, CurrentThread = null });
            FThreads.Add(StartThreadFor.LaserSimulation, new JoganThreadProp { IsStop = false, IsPaused = false, CurrentThread = null });
            FThreads.Add(StartThreadFor.MachineTester, new JoganThreadProp { IsStop = false, IsPaused = false, CurrentThread = null });

            FJoganC8Tester = new JoganC8Tester();
            //FThreads.Add("FUKUDA", null);
            //FThreads.Add("DB_EROR", null);
            //FThreads.Add("DB_STATION_READY", null);
        } 
        private void PreparePLC()
        {
            if (!FAllowConnect) return;
            FTwinCat3Utility.ConnectPLC(NetID);

            AddPLCVariable("INPUT_VAR.I_LOTEND"); 
            AddPLCVariable("INPUT_VAR.I_CURRENT_TRANSACTION");
            AddPLCVariable("INPUT_VAR.I_FUNCTION_NAME");
            AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_A", FukudaTransfer1);
            AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_A", FukudaTransfer1);
            AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE", FukudaTransfer1);
            AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_B", FukudaTransfer2);
            AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_B", FukudaTransfer2);
            AddPLCVariable("INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE", FukudaTransfer2);
            AddPLCVariable("INPUT_VAR.I_LOADING_DONE_A", FukudaTransfer1);
            AddPLCVariable("INPUT_VAR.I_RETURN_DONE_A", FukudaTransfer1);
            AddPLCVariable("INPUT_VAR.I_LOADING_DONE_B", FukudaTransfer2);
            AddPLCVariable("INPUT_VAR.I_RETURN_DONE_B", FukudaTransfer2);
            //AddPLCVariable("INPUT_VAR.JIG_FUKUDA_PRESENCE", FukudaHandler);
            //AddPLCVariable("INPUT_VAR.I_ONE_OF_STATIONS_READY");

            AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_1");
            AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_2");
            AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_3");
            AddPLCVariable("INPUT_VAR.I_LOTBOX_DETECT_4");
            AddPLCVariable("INPUT_VAR.I_LOTBOX_CLAMP_ON_1");
            AddPLCVariable("INPUT_VAR.I_LOTBOX_CLAMP_ON_2");
            AddPLCVariable("INPUT_VAR.I_LOTBOX_CLAMP_ON_3");
            AddPLCVariable("INPUT_VAR.I_LOTBOX_CLAMP_ON_4");
            AddPLCVariable("INPUT_VAR.I_LOTBOX_CLAMP_OFF_1");
            AddPLCVariable("INPUT_VAR.I_LOTBOX_CLAMP_OFF_2");
            AddPLCVariable("INPUT_VAR.I_LOTBOX_CLAMP_OFF_3");
            AddPLCVariable("INPUT_VAR.I_LOTBOX_CLAMP_OFF_4");

            AddPLCVariable("SORTER_VAR.I_LASER_TRANSFER_AT_FRONT_A");
            AddPLCVariable("SORTER_VAR.I_LASER_TRANSFER_AT_BACK_A");
            AddPLCVariable("SORTER_VAR.I_LASER_TRANSFER_A_PICK_DONE");
            AddPLCVariable("SORTER_VAR.I_LASER_TRANSFER_AT_FRONT_B");
            AddPLCVariable("SORTER_VAR.I_LASER_TRANSFER_AT_BACK_B");
            AddPLCVariable("SORTER_VAR.I_LASER_TRANSFER_B_PICK_DONE");
            AddPLCVariable("SORTER_VAR.I_LOADING_DONE_A");
            AddPLCVariable("SORTER_VAR.I_RETURN_DONE_A");
            AddPLCVariable("SORTER_VAR.I_LOADING_DONE_B");
            AddPLCVariable("SORTER_VAR.I_RETURN_DONE_B");
            AddPLCVariable("SORTER_VAR.I_LOADING_DONE_NG");
            AddPLCVariable("SORTER_VAR.I_RETURN_DONE_NG"); 

            AddPLCVariable("SORTER_VAR.I_LOTBOX_DETECT_1");
            AddPLCVariable("SORTER_VAR.I_LOTBOX_DETECT_2");
            AddPLCVariable("SORTER_VAR.I_LOTBOX_DETECT_3");
            AddPLCVariable("SORTER_VAR.I_LOTBOX_DETECT_4");
            AddPLCVariable("SORTER_VAR.I_LOTBOX_CLAMP_ON_1");
            AddPLCVariable("SORTER_VAR.I_LOTBOX_CLAMP_ON_2");
            AddPLCVariable("SORTER_VAR.I_LOTBOX_CLAMP_ON_3");
            AddPLCVariable("SORTER_VAR.I_LOTBOX_CLAMP_ON_4");
            AddPLCVariable("SORTER_VAR.I_LOTBOX_CLAMP_OFF_1");
            AddPLCVariable("SORTER_VAR.I_LOTBOX_CLAMP_OFF_2");
            AddPLCVariable("SORTER_VAR.I_LOTBOX_CLAMP_OFF_3");
            AddPLCVariable("SORTER_VAR.I_LOTBOX_CLAMP_OFF_4");
            AddPLCVariable("SORTER_VAR.I_CURRENT_TRANSACTION");
            AddPLCVariable("SORTER_VAR.I_LASER_SOCKET"); 
            AddPLCVariable("SORTER_RS4_VAR.I_SORTER_RS4_ENABLE");
            AddPLCVariable("LOADER_RS4_VAR.I_LOADER_RS4_ENABLE");

            //Gripper G6
            AddPLCVariable("INPUT_G6_VAR.O_G6_GRIPPER_CLOSE_1");
            AddPLCVariable("INPUT_G6_VAR.O_G6_GRIPPER_CLOSE_2");
            AddPLCVariable("INPUT_G6_VAR.O_G6_GRIPPER_CLOSE_3");
            AddPLCVariable("INPUT_G6_VAR.O_G6_GRIPPER_CLOSE_4");

            //Gripper RS4-1
            AddPLCVariable("LOADER_RS4_VAR.O_LOADER_RS4_GRIPPER_CLOSE_1");
            AddPLCVariable("LOADER_RS4_VAR.O_LOADER_RS4_GRIPPER_CLOSE_2");
            AddPLCVariable("LOADER_RS4_VAR.O_LOADER_RS4_GRIPPER_CLOSE_3");
            AddPLCVariable("LOADER_RS4_VAR.O_LOADER_RS4_GRIPPER_CLOSE_4"); 
            AddPLCVariable("LOADER_RS4_VAR.I_LOADER_RS4_START_TAKEUP");
            AddPLCVariable("LOADER_RS4_VAR.I_LOADER_RS4_READY_PLACING");
            AddPLCVariable("LOADER_RS4_VAR.I_LOADER_RS4_START_PLACING");

            //Gripper RS4-2
            AddPLCVariable("SORTER_RS4_VAR.I_SORTER_RS4_START_TAKEUP");
            AddPLCVariable("SORTER_RS4_VAR.I_SORTER_RS4_READY_TAKEUP"); 
            AddPLCVariable("SORTER_RS4_VAR.I_SORTER_RS4_START_PLACING"); 

            //Tester C8:

            AddPLCVariable("TESTER_C8_VAR.I_C8_READY_SCAN");
            AddPLCVariable("TESTER_C8_VAR.I_C8_JIG_PRESENCE");  
            AddPLCVariable("LOADER_VAR.I_TESTER_JIG_PRESENCE_11"); 

            FTwinCat3Utility.TwinCat3Client.AdsNotification += new AdsNotificationEventHandler(OnNotification);

            T_CURRENT_TRANSACTION ct = null;
            ct = (T_CURRENT_TRANSACTION)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            ct.JIG_INDEX_LOAD = 0;
            ct.JIG_INDEX_RETURN = 0;
            ct.PO_NUMBER = "";
            ct.QUANTITY_LOTEND = 0;
            ct.QUANTITY_MAX = 0;
            ct.STATION_NUMBER_LOAD = 0;
            ct.STATION_NUMBER_RETURN = 0;
            ct.TRANSPORT_INDEX = 0;
            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);

            FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.I_MAX_DEVICE", TypeOfData.tpByte, (byte)MAX_DEVICE_JIG_LOTBOX_INPUT);
        }
        private int GetFukudaFlag(FukudaTransfer AFukudaTransfer)
        {
            return AFukudaTransfer.Flag;
        }
        private int GetLaserFlag(LaserTransfer ALaserTransfer)
        {
            return ALaserTransfer.Flag;
        }
        public void CreateMessage(string MessageName,string HardwareID,string Impact, bool MarkAsDelete=true,string MessageCode="9999", string Status="Read")
        {
            //if (JoganFunctionAs == JoganFunctionAs.AsControllerWatcher)
            //{
            //    using (var db = new DBProjectEntities())
            //    {
            //        DateTime dt = DateTime.Now;
            //        T_ERROR_LIST tel = new T_ERROR_LIST
            //        {
            //            Created_Date = dt,
            //            Created_User = JoganUserID,
            //            Hardware_ID = HardwareID,
            //            ID = 0,
            //            MarkAsDelete = MarkAsDelete,
            //            Message_Code = MessageCode,
            //            Status = Status,//Commons.Commons.GetEnumFromString<InfoMassageImpact>(Impact),
            //            Updated_Date = dt,
            //            Updated_User = JoganUserID,
            //            Description=MessageName,
            //        };
            //        db.T_ERROR_LISTS.Add(tel);
            //        TrySaveChange(db);
            //    }
            //}
            V_MESSAGE v =
            new V_MESSAGE
            {
                Message_Code = MessageCode,
                Message_Name = MessageName,
                Hardware_ID = HardwareID,
                Impact = Impact
            };
            if (OnNewMessage != null) OnNewMessage(this, v);
        }
        public void AllowExecutePLCFunction(string FuncName, bool IsAllow)
        {
            FTwinCat3Utility.WriteAnyToPLC("FLAG_VAR.ALLOW_EXECUTE_" + FuncName, TypeOfData.tpBool, IsAllow);
        } 
        public void ExecutePLCProgram(string FuncName)
        {
            if (!FAllowConnect) return;
            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUNCTION_NAME", TypeOfData.tpString, FuncName);
        }
        private void IncreaseCounter(string From,bool IncreaseNow)
        {
            if (IncreaseNow)
            {
                if (From.ToUpper() == "G6")
                {
                    FCounterDeviceJigInput++;
                     CreateMessage("Device picked = " + FCounterDeviceJigInput.ToString() + " of " + MAX_DEVICE_JIG_LOTBOX_INPUT.ToString(), "G6", "Low");
                    if (FCounterDeviceJigInput >= MAX_DEVICE_JIG_LOTBOX_INPUT)
                    {
                        FCounterDeviceJigInput = 0;
                        int fflag1 = GetFukudaFlag(FukudaTransfer1);
                        int fflag2 = GetFukudaFlag(FukudaTransfer2);
                        string varname = "INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE";
                        byte abc = (byte)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICKING", TypeOfData.tpByte);
                        //if (fflag1 == 2 && fflag2 != 2 && abc == 1) FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, false);
                        //if (fflag1 == 2 && fflag2 == 2 && abc == 1) FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, false);
                        if (fflag1 != 2 && fflag2 == 2 && abc == 2) { varname = "INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE"; }//FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, true); }
                        if (fflag1 == 2 && fflag2 == 2 && abc == 2) { varname = "INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE"; }//FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, true); }
                        //CreateMessage("fflag1 = " + fflag1.ToString() + ", fflag2 = " + fflag2.ToString(), "G6", "Low");

                        FTwinCat3Utility.WriteAnyToPLC(varname, TypeOfData.tpBool, true);
                        FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.START_POSITION", TypeOfData.tpByte, (byte)1);

                        //bool sel_a = (bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool);
                        //if (fflag1 != 2 && fflag2 != 2) FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.I_G6_ENABLE", TypeOfData.tpBool, false);

                        //if (fflag2!=2 && sel_a) FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.I_G6_ENABLE", TypeOfData.tpBool, false);
                        //FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.START_POSITION", TypeOfData.tpByte,(byte)1);
                        WaitSynchronous(delegate ()
                        {
                            return !(bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_G6_VAR.I_G6_START_TAKEUP", TypeOfData.tpBool);
                        }, delegate ()
                        {
                            //FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.I_G6_ENABLE", TypeOfData.tpBool, false);
                            if (varname == "INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE")
                            {
                                if (fflag2 != 2) FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.I_G6_ENABLE", TypeOfData.tpBool, false);
                            }
                            if (varname == "INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE")
                            {
                                if (fflag1 != 2) FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.I_G6_ENABLE", TypeOfData.tpBool, false);
                            }
                        }); 
                    }
                }
                else if (From.ToUpper() == "RS4-2")
                {
                    FCounterDeviceJigOutput++;
                    if (FCounterDeviceJigInput >= MAX_DEVICE_JIG_LOTBOX_LASER)
                    {
                        FCounterDeviceJigOutput = 0;
                        int fflag1 = GetLaserFlag(LaserTransfer1);
                        int fflag2 = GetLaserFlag(LaserTransfer2);
                        string varname = "LOADER_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE";
                        byte abc = (byte)FTwinCat3Utility.ReadAnyFromPLC("LOADER_VAR.I_FUKUDA_TRANSFER_A_PICKING", TypeOfData.tpByte);
                        if (fflag1 != 2 && fflag2 == 2 && abc == 2) { varname = "LOADER_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE"; }//FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, true); }
                        if (fflag1 == 2 && fflag2 == 2 && abc == 2) { varname = "LOADER_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE"; }//FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, true); }

                        FTwinCat3Utility.WriteAnyToPLC(varname, TypeOfData.tpBool, true);
                        //FTwinCat3Utility.WriteAnyToPLC("LOADER_VAR.START_POSITION", TypeOfData.tpByte, (byte)1);

                        WaitSynchronous(delegate ()
                        {
                            return !(bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_RS4_VAR.I_G6_START_TAKEUP", TypeOfData.tpBool);
                        }, delegate ()
                        {
                            //FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.I_G6_ENABLE", TypeOfData.tpBool, false);
                            if (varname == "LOADER_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE")
                            {
                                if (fflag2 != 2) FTwinCat3Utility.WriteAnyToPLC("LOADER_VAR.I_G6_ENABLE", TypeOfData.tpBool, false);
                            }
                            if (varname == "LOADER_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE")
                            {
                                if (fflag1 != 2) FTwinCat3Utility.WriteAnyToPLC("LOADER_VAR.I_G6_ENABLE", TypeOfData.tpBool, false);
                            }
                        });
                    }
                }
            }
        }
        #region Main Notification from PLC
        private void OnNotification(object sender, AdsNotificationEventArgs e)
        {
            if (!FAllowConnect) return;
            if (OnJoganUtilityPLCNotification != null) { OnJoganUtilityPLCNotification(sender, e); }
            if (FJoganFunctionAs == JoganFunctionAs.AsWatcher) return;
            TwinCat3Property prop = FTwinCat3Utility.TwinCat3PropertyList.Where(x => x.DeviceNotificationHandle == e.NotificationHandle).FirstOrDefault();
            if (prop.VariableName == "INPUT_VAR.I_CURRENT_TRANSACTION" || prop.VariableName == "SORTER_VAR.I_CURRENT_TRANSACTION" || prop.VariableName == "SORTER_VAR.I_LASER_SOCKET") return;
            bool val = false;
            val = (bool)FTwinCat3Utility.ReadAnyFromPLC(prop.VariableName, TypeOfData.tpBool);

            switch (prop.VariableName)
            {
                #region Fukuda Notif
                //one of stations ready ?
                case "INPUT_VAR.I_ONE_OF_STATIONS_READY":
                    if (val) FListFukudaNotification.Add("INPUT_VAR.I_ONE_OF_STATIONS_READY");
                    break;
                //is lot end ?
                case "INPUT_VAR.I_LOTEND":
                    FListFukudaNotification.Add("INPUT_VAR.I_LOTEND");
                    break;
                //fukuda transport A
                //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_A": 
                //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_A":  
                case "INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE":
                    if (val) FListFukudaNotification.Add(prop.VariableName);
                    break;
                //fukuda transport B
                //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_B":  
                //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_B":  
                case "INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE":
                    if (val) FListFukudaNotification.Add(prop.VariableName);
                    break;
                //loading done : flag when handler already done move jig to transport and send it to straightener
                case "INPUT_VAR.I_LOADING_DONE_A":
                    if (val) FListFukudaNotification.Add("INPUT_VAR.I_LOADING_DONE_A");
                    break;
                //return done : flag when handler already done move jig from transport to lotbox
                case "INPUT_VAR.I_RETURN_DONE_A":
                    if (val) FListFukudaNotification.Add("INPUT_VAR.I_RETURN_DONE_A");
                    break;
                //loading done : flag when handler already done move jig to transport and send it to straightener
                case "INPUT_VAR.I_LOADING_DONE_B":
                    if (val) FListFukudaNotification.Add("INPUT_VAR.I_LOADING_DONE_B");
                    break;
                //return done : flag when handler already done move jig from transport to lotbox
                case "INPUT_VAR.I_RETURN_DONE_B":
                    if (val) FListFukudaNotification.Add("INPUT_VAR.I_RETURN_DONE_B");
                    break;
                case "INPUT_VAR.JIG_FUKUDA_PRESENCE":
                    FListFukudaNotification.Add("INPUT_VAR.JIG_FUKUDA_PRESENCE");
                    break;
                case "INPUT_VAR.I_END_CYCLE_LOADING":
                    if (val) FListCloseSocket.Clear();
                    break;
                #endregion
                #region G6
                case "INPUT_G6_VAR.O_G6_GRIPPER_CLOSE_1":
                case "INPUT_G6_VAR.O_G6_GRIPPER_CLOSE_2":
                case "INPUT_G6_VAR.O_G6_GRIPPER_CLOSE_3":
                case "INPUT_G6_VAR.O_G6_GRIPPER_CLOSE_4":
                    IncreaseCounter("G6", val && ((bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_G6_VAR.I_G6_START_TAKEUP", TypeOfData.tpBool)));
                    break;
                #endregion
                #region Laser Notif 
                //is lot end ?
                case "SORTER_VAR.I_LOTEND":
                    FListLaserNotification.Add("SORTER_VAR.I_LOTEND");
                    break;
                //Laser transport A
                //case "SORTER_VAR.I_LASER_TRANSFER_AT_FRONT_A": 
                //case "SORTER_VAR.I_LASER_TRANSFER_AT_BACK_A":  
                case "SORTER_VAR.I_LASER_TRANSFER_A_PICK_DONE":
                    if (val) FListLaserNotification.Add(prop.VariableName);
                    break;
                //Laser transport B
                //case "SORTER_VAR.I_LASER_TRANSFER_AT_FRONT_B":  
                //case "SORTER_VAR.I_LASER_TRANSFER_AT_BACK_B":  
                case "SORTER_VAR.I_LASER_TRANSFER_B_PICK_DONE":
                    if (val) FListLaserNotification.Add(prop.VariableName);
                    break;
                //loading done : flag when handler already done move jig to transport and send it to straightener
                case "SORTER_VAR.I_LOADING_DONE_A":
                    if (val) FListLaserNotification.Add("SORTER_VAR.I_LOADING_DONE_A");
                    break;
                //return done : flag when handler already done move jig from transport to lotbox
                case "SORTER_VAR.I_RETURN_DONE_A":
                    if (val) FListLaserNotification.Add("SORTER_VAR.I_RETURN_DONE_A");
                    break;
                //return done : flag when handler already done move jig from transport to lotbox
                case "SORTER_VAR.I_RETURN_DONE_B":
                    if (val) FListLaserNotification.Add("SORTER_VAR.I_RETURN_DONE_B");
                    break;
                //loading done : flag when handler already done move jig to transport and send it to straightener
                case "SORTER_VAR.I_LOADING_DONE_B":
                    if (val) FListLaserNotification.Add("SORTER_VAR.I_LOADING_DONE_B");
                    break;
                //return done : flag when handler already done move jig from transport to lotbox
                case "SORTER_VAR.I_RETURN_DONE_NG":
                    if (val) FListLaserNotification.Add("SORTER_VAR.I_RETURN_DONE_NG");
                    break;
                //return done : flag when handler already done move jig from transport to lotbox
                case "SORTER_VAR.I_LOADING_DONE_NG":
                    if (val) FListLaserNotification.Add("SORTER_VAR.I_LOADING_DONE_NG");
                    break;
                case "SORTER_VAR.I_END_CYCLE_LOADING":
                    if (val) FListCloseSocket.Clear();
                    break;
                case "SORTER_VAR.I_END_CARRIER_LOADING":
                    //if (val) //PrepareListTestResult();
                    break;
                #endregion
                case "LOADER_RS4_VAR.I_LOADER_RS4_ENABLE":
                    if (val) FListRotary1Notification.Add(prop.VariableName);
                    break; 
                case "LOADER_RS4_VAR.I_LOADER_RS4_START_TAKEUP": 
                    if (val) FListRotary1Notification.Add(prop.VariableName); //PrepareAvailableSocketData();
                    break;
                case "LOADER_RS4_VAR.I_LOADER_RS4_START_PLACING":
                case "LOADER_RS4_VAR.I_LOADER_RS4_READY_PLACING":
                    if (val) FListRotary1Notification.Add(prop.VariableName); //PrepareAvailableSocketData();
                    break;

                #region C8 Tester 
                case "TESTER_C8_VAR.I_C8_READY_SCAN":
                    if (val) FListMachineTesterNotification.Add(prop.VariableName);
                    break;
                case "LOADER_VAR.I_TESTER_JIG_PRESENCE_11":
                //case "TESTER_C8_VAR.I_C8_JIG_PRESENCE":
                    //if (val) 
                    FListMachineTesterNotification.Add(prop.VariableName);
                    break;
                #endregion
                #region RS4-2
                case "SORTER_RS4_VAR.O_G6_GRIPPER_OPEN_1":
                case "SORTER_RS4_VAR.O_G6_GRIPPER_OPEN_2":
                case "SORTER_RS4_VAR.O_G6_GRIPPER_OPEN_3":
                case "SORTER_RS4_VAR.O_G6_GRIPPER_OPEN_4":
                    IncreaseCounter("RS4-2", val && ((bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_RS4_VAR.I_SORTER_RS4_START_PLACING", TypeOfData.tpBool)));
                    break;
                case "SORTER_RS4_VAR.I_SORTER_RS4_START_TAKEUP":
                    //if (val) FListLaserNotification.Add(prop.VariableName);
                    //break;
                case "SORTER_RS4_VAR.I_SORTER_RS4_READY_TAKEUP":
                //if (val) FListLaserNotification.Add(prop.VariableName);
                //break;
                case "SORTER_RS4_VAR.I_SORTER_RS4_ENABLE":
                case "SORTER_RS4_VAR.I_SORTER_RS4_START_PLACING":
                    if (val) FListLaserNotification.Add(prop.VariableName); //PrepareAvailableSocketData();
                    break;
                    #endregion
            } 
        }
        #endregion

        #region Fukuda Handler & Transport
        public void PrepareUnloadingJigFukuda(FukudaTransfer AFukudaTransfer, bool NewStation)
        {
            if (!FAllowConnect) return;
            //FThreads[StartThreadFor.Fukuda].IsPaused = true;
            int fflag1 = -1;
            int fflag2 = -1;
            T_CURRENT_TRANSACTION ct = null;
            ct = (T_CURRENT_TRANSACTION)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            //FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
            string varname = "";
            if (AFukudaTransfer == null)
            {
                if ((FukudaTransfer1.Flag == 0 || FukudaTransfer1.Flag == 4 || FukudaTransfer1.Flag == 5) ||
                    (FukudaTransfer2.Flag == 0 || FukudaTransfer2.Flag == 4 || FukudaTransfer2.Flag == 5))
                {
                    if (NewStation)
                    {
                        FMessageIsSend = false;
                        FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOTEND", TypeOfData.tpBool, false);
                        if (FTransactionInput != null)
                        {
                            Commons.Commons.CopyProperties(FTransactionInput, FOldUnloadingStation.TransactionInput);
                        }
                        using (var db = new DBProjectEntities())
                        {
                            FTransactionInput = db.T_TRANSACTION_INPUTS.Where(x => x.Status == "Standby").OrderBy(x => x.Updated_Date).FirstOrDefault();
                            FIsLotEndFukuda = false; FIsLotEndFukudaReturnDone = false;
                            FUnloadingStation.TransactionInput = FTransactionInput;
                            if (FTransactionInput == null) goto Skip;
                            FTransactionInput.Status = "Unloading";
                            FTransactionInput.Updated_Date = DateTime.Now;
                            db.Entry(FTransactionInput).CurrentValues.SetValues(FTransactionInput);
                            TrySaveChange(db);
                            ct.PO_NUMBER = FTransactionInput.PO_Number;
                            ct.QUANTITY_MAX = (byte)FTransactionInput.Quantity;
                            ct.STATION_NUMBER_LOAD = (byte)FTransactionInput.LotBox_Position_Fukuda;
                            ct.JIG_INDEX_LOAD = 8;
                            ct.JIG_INDEX_RETURN = 0;
                            ct.JIG_INDEX_LOAD_NG = 0;
                            ct.JIG_INDEX_RETURN_NG = 0;
                            ct.TRANSPORT_INDEX = 0;

                            FUnloadingStation.TransactionInput = FTransactionInput;

                            if (OnNewMessage != null) OnNewMessage(this, new V_MESSAGE
                            {
                                Message_Code = "",
                                Message_Name = "Lotbox on Fukuda Station " + FTransactionInput.LotBox_Position_Fukuda.ToString() + " now unloading",
                                Hardware_ID = "Fukuda Station " + FTransactionInput.LotBox_Position_Fukuda.ToString(),
                                Impact = "Low",
                            });
                            //FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, FCurrentTransaction);
                        }
                    }

                    Skip:
                    if (FTransactionInput == null)
                    {
                        fflag1 = GetFukudaFlag(FukudaTransfer1);
                        fflag2 = GetFukudaFlag(FukudaTransfer2);
                        if (fflag1 == 0 || fflag1 == 4 || fflag1 == 5)
                        {
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_ONDUTY_A", TypeOfData.tpBool, false);
                        }
                        else
                        if (fflag2 == 0 || fflag2 == 4 || fflag2 == 5)
                        {
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_ONDUTY_B", TypeOfData.tpBool, false);
                        }
                    }
                    if (!FIsLotEndFukuda && FTransactionInput != null)
                    {
                        ct.JIG_INDEX_LOAD++;
                        fflag1 = GetFukudaFlag(FukudaTransfer1);
                        fflag2 = GetFukudaFlag(FukudaTransfer2);
                        if (fflag1 == 0 || fflag1 == 4 || fflag1 == 5)
                        {
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_ONDUTY_A", TypeOfData.tpBool, true);
                            FFukudaTransfer1.LotEndOnMe = ct.JIG_INDEX_LOAD == 10;
                            FukudaTransfer1.DoneTransport = false;
                            ct.TRANSPORT_INDEX = 1;
                            FukudaTransfer1.StationNumber = ct.STATION_NUMBER_LOAD;
                            FukudaTransfer1.JigIndex = ct.JIG_INDEX_LOAD;
                            varname = "INPUT_VAR.I_LOADING_DONE_A";
                        }
                        else
                        if (fflag2 == 0 || fflag2 == 4 || fflag2 == 5)
                        {
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_ONDUTY_B", TypeOfData.tpBool, true);
                            FFukudaTransfer2.LotEndOnMe = ct.JIG_INDEX_LOAD == 10;
                            FukudaTransfer2.DoneTransport = false;
                            ct.TRANSPORT_INDEX = 2;
                            FukudaTransfer2.StationNumber = ct.STATION_NUMBER_LOAD;
                            FukudaTransfer2.JigIndex = ct.JIG_INDEX_LOAD;
                            varname = "INPUT_VAR.I_LOADING_DONE_B";
                        }
                        FUnloadingStation.CurrentTransaction = ct;
                        if (OnUnloadingStation != null) OnUnloadingStation(this, StatusTestingControl.Unloading, FUnloadingStation);

                        FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
                        AllowExecutePLCFunction("LOAD_FUKUDA", true);
                        //Commons.Commons.CopyProperties(ct, FTransactionInput);
                        //FTwinCat3Utility.WriteAnyToPLC(varname, TypeOfData.tpBool, false);
                        //Wait(delegate () { return (bool)FTwinCat3Utility.ReadAnyFromPLC(varname, TypeOfData.tpBool); });
                        //if (ct.JIG_INDEX_LOAD == 10)
                        //{
                        //    V_MESSAGE v =
                        //    new V_MESSAGE
                        //    {
                        //        Message_Code = "",
                        //        Message_Name = "Lotbox on Fukuda Station " + FUnloadingStation.TransactionInput.LotBox_Position_Fukuda.ToString() + " finishing unloading. Please wait until last jig returned",
                        //        Hardware_ID = "Lotbox",
                        //        Impact = "Low",
                        //    }; 
                        //    if (OnNewMessage != null) OnNewMessage(this, v); 
                        //    FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOTEND", TypeOfData.tpBool, true);
                        //}
                        WaitAsynchronous(FThreads[StartThreadFor.Fukuda],
                            delegate () { return !(bool)FTwinCat3Utility.ReadAnyFromPLC(varname, TypeOfData.tpBool); },
                            delegate ()
                            {
                                if (ct.JIG_INDEX_LOAD == 10)
                                {
                                    V_MESSAGE v =
                                    new V_MESSAGE
                                    {
                                        Message_Code = "",
                                        Message_Name = "Lotbox on Fukuda Station " + FUnloadingStation.TransactionInput.LotBox_Position_Fukuda.ToString() + " finishing unloading. Please wait until last jig return",
                                        Hardware_ID = "Fukuda Station " + FUnloadingStation.TransactionInput.LotBox_Position_Fukuda.ToString(),
                                        Impact = "Low",
                                    };
                                    if (OnNewMessage != null) OnNewMessage(this, v);
                                    FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOTEND", TypeOfData.tpBool, true);
                                }
                            });
                    }
                }
            }
            else
            {
                ct.JIG_INDEX_RETURN = (byte)AFukudaTransfer.JigIndex;
                ct.TRANSPORT_INDEX = (byte)AFukudaTransfer.ID;
                ct.STATION_NUMBER_RETURN = (byte)AFukudaTransfer.StationNumber;
                FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
                //reset flag
                switch (AFukudaTransfer.ID)
                {
                    case 1:
                        FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_ONDUTY_A", TypeOfData.tpBool, true);
                        FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE", TypeOfData.tpBool, false);
                        varname = "INPUT_VAR.I_RETURN_DONE_A";
                        break;
                    case 2:
                        FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_ONDUTY_B", TypeOfData.tpBool, true);
                        FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE", TypeOfData.tpBool, false);
                        varname = "INPUT_VAR.I_RETURN_DONE_B";
                        break;
                }
                AllowExecutePLCFunction("RETURN_FUKUDA", true);
                WaitAsynchronous(FThreads[StartThreadFor.Fukuda],
                    delegate () { return !(bool)FTwinCat3Utility.ReadAnyFromPLC(varname, TypeOfData.tpBool); });
            }
        }
        private void ThreadForFukuda()
        {
            int fflag = 0;
            string varname = "";
            bool done = false;
            while (true) //(FListFukudaNotification.Count > 0)
            {
                //break;
                //if (FEndProccess || FThreads[StartThreadFor.Fukuda].IsStop) break;
                //if (FPauseProccess) Wait(delegate () { return FPauseProccess; });
               // if (FThreads[StartThreadFor.Fukuda].IsPaused) goto Skip;

                WaitAsynchronous(FThreads[StartThreadFor.Fukuda], delegate () { return FPauseProccess; });
                if (FThreads[StartThreadFor.Fukuda].IsPaused) goto Skip;
                if (FListFukudaNotification.Count != 0)
                {
                    //Simulation sm = null;
                    string notif = FListFukudaNotification[0];
                    if (OnJoganThreadWorking != null) OnJoganThreadWorking(FThreads[StartThreadFor.Fukuda].CurrentThread, notif);
                    switch (notif)
                    {
                        case "INPUT_VAR.I_ONE_OF_STATIONS_READY":
                            break;
                        case "INPUT_VAR.I_LOTEND":
                            FIsLotEndFukuda = (bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOTEND", TypeOfData.tpBool); 
                            break;
                        //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_A":
                        //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_A":
                        case "INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE":
                            fflag = GetFukudaFlag(FFukudaTransfer2);
                            //FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE", TypeOfData.tpBool, false);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_RESET_COUNTER_PICK", TypeOfData.tpBool, false);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICKING", TypeOfData.tpByte, (byte)2);// fflag == 2 ? (byte)2 : (byte)0);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, true);
                            varname = "INPUT_VAR.I_FUKUDA_ONDUTY_B";// done ? "INPUT_VAR.I_RETURN_DONE_B" : "INPUT_VAR.I_LOADING_DONE_B";
                            WaitAsynchronous( 
                                delegate () { return (bool)FTwinCat3Utility.ReadAnyFromPLC(varname, TypeOfData.tpBool); },
                                delegate ()
                                {
                                    FFukudaTransfer1.SetFlag(
                                        (bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_A", TypeOfData.tpBool),
                                        (bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_A", TypeOfData.tpBool),
                                        (bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICK_DONE", TypeOfData.tpBool)
                                        );
                                });
                            break;
                        //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_B":
                        //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_B":
                        case "INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE":
                            fflag = GetFukudaFlag(FFukudaTransfer1);
                            //FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE", TypeOfData.tpBool, false);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_RESET_COUNTER_PICK", TypeOfData.tpBool, false);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICKING", TypeOfData.tpByte, (byte)1);// fflag == 2 ? (byte)1 : (byte)0);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, false);
                            varname = "INPUT_VAR.I_FUKUDA_ONDUTY_A";//done ? "INPUT_VAR.I_RETURN_DONE_A" : "INPUT_VAR.I_LOADING_DONE_A";
                            WaitAsynchronous( 
                                delegate () { return (bool)FTwinCat3Utility.ReadAnyFromPLC(varname, TypeOfData.tpBool); },
                                delegate ()
                                {
                                    FFukudaTransfer2.SetFlag(
                               (bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_B", TypeOfData.tpBool),
                               (bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_B", TypeOfData.tpBool),
                               (bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_B_PICK_DONE", TypeOfData.tpBool)
                               );
                                });

                            break;
                        case "INPUT_VAR.I_LOADING_DONE_A": 
                            //FTwinCat3Utility.WriteAnyToPLC("LOADER_RS4_VAR.I_LOADER_RS4_ENABLE", TypeOfData.tpBool, true);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.I_G6_ENABLE", TypeOfData.tpBool, true);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICKING", TypeOfData.tpByte, (byte)1);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_ONDUTY_A", TypeOfData.tpBool, false);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_RETURN_DONE_A", TypeOfData.tpBool, false);
                            fflag = GetFukudaFlag(FFukudaTransfer2);
                            if (fflag == 0 || fflag == 4 || fflag == 5) PrepareUnloadingJigFukuda(null, FIsLotEndFukuda);
                            break;
                        case "INPUT_VAR.I_RETURN_DONE_A":
                            FukudaTransfer1.DoneTransport = true;
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOADING_DONE_A", TypeOfData.tpBool, false);
                            if (FFukudaTransfer1.LotEndOnMe) {
                                FIsLotEndFukudaReturnDone = true;
                                FOldUnloadingStation.CurrentTransaction = new T_CURRENT_TRANSACTION { JIG_INDEX_LOAD = 10 };
                                if (OnUnloadingStation != null) OnUnloadingStation(this, StatusTestingControl.Finish, FOldUnloadingStation);
                            }
                            PrepareUnloadingJigFukuda(null, FIsLotEndFukuda);
                            break;
                        case "INPUT_VAR.I_LOADING_DONE_B":
                           // FTwinCat3Utility.WriteAnyToPLC("LOADER_RS4_VAR.I_LOADER_RS4_ENABLE", TypeOfData.tpBool, true);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.I_G6_ENABLE", TypeOfData.tpBool, true);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_FUKUDA_ONDUTY_B", TypeOfData.tpBool, false);
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_RETURN_DONE_B", TypeOfData.tpBool, false);
                            fflag = GetFukudaFlag(FFukudaTransfer1);
                            if (fflag == 4 || fflag == 5) PrepareUnloadingJigFukuda(null, FIsLotEndFukuda);
                            break;
                        case "INPUT_VAR.I_RETURN_DONE_B":
                            FukudaTransfer2.DoneTransport = true;
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOADING_DONE_B", TypeOfData.tpBool, false);
                            if (FFukudaTransfer2.LotEndOnMe) {
                                FIsLotEndFukudaReturnDone = true;
                                FOldUnloadingStation.CurrentTransaction = new T_CURRENT_TRANSACTION { JIG_INDEX_LOAD = 10 };
                                if (OnUnloadingStation != null) OnUnloadingStation(this, StatusTestingControl.Finish, FOldUnloadingStation);
                            }
                            PrepareUnloadingJigFukuda(null, FIsLotEndFukuda);
                            break;
                        case "INPUT_VAR.JIG_FUKUDA_PRESENCE":
                            bool presence = (bool)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.JIG_FUKUDA_PRESENCE", TypeOfData.tpBool);
                            if (!presence) PrepareUnloadingJigFukuda(null, FIsLotEndFukuda);
                            break;
                    }
                    FListFukudaNotification.RemoveAt(0);
                }

                Skip:
                Task.Delay(WAIT_THREAD_TIME*1);
            }
        }
        #endregion
        #region Fukuda Handler
        //private FukudaHandler FFukudaHandler;
        //public FukudaHandler FukudaHandler { get { return FFukudaHandler; } }
        #endregion

        #region Fukuda Transfer
        //**************************************//
        //Fukuda Transfer Transfer               //
        //**************************************//
        private FukudaTransfer FFukudaTransfer1;
        public FukudaTransfer FukudaTransfer1 { get { return FFukudaTransfer1; } }
        private FukudaTransfer FFukudaTransfer2;
        public FukudaTransfer FukudaTransfer2 { get { return FFukudaTransfer2; } }

        #endregion

        #region Laser Transfer
        //**************************************//
        //Fukuda Transfer Transfer               //
        //**************************************//
        private LaserTransfer FLaserTransfer1;
        public LaserTransfer LaserTransfer1 { get { return FLaserTransfer1; } }
        private LaserTransfer FLaserTransfer2;
        public LaserTransfer LaserTransfer2 { get { return FLaserTransfer2; } }
        private LaserTransfer FLaserTransferNG;
        public LaserTransfer LaserTransferNG { get { return FLaserTransferNG; } }

        #endregion

        #region Rotary1
        private  void ThreadForRotary1()
        {
            while (true) //(FListFukudaNotification.Count > 0)
            {
                //if (FEndProccess || FThreads[StartThreadFor.Rotary1].IsStop) break;
                //if (FPauseProccess) Wait(delegate () { return FPauseProccess; });
                //if (FThreads[StartThreadFor.Rotary1].IsPaused) goto Skip;
                WaitAsynchronous(FThreads[StartThreadFor.Rotary1], delegate () { return FPauseProccess; });
                if (FThreads[StartThreadFor.Rotary1].IsPaused) goto Skip;
                //proccesses here
                int fflag1 = GetFukudaFlag(FukudaTransfer1);
                int fflag2 = GetFukudaFlag(FukudaTransfer2);
                //byte abc = (byte)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_FUKUDA_TRANSFER_A_PICKING", TypeOfData.tpByte);
                //if (fflag1 == 2 && fflag2 != 2 && abc == 1) FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, false);
                //if (fflag1 == 2 && fflag2 == 2 && abc == 1) FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, false);
                //if (fflag1 != 2 && fflag2 == 2 && abc == 2) FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, true);
                //if (fflag1 == 2 && fflag2 == 2 && abc == 2) FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.O_G6_SELECT_FUKUDA_A", TypeOfData.tpBool, true);
                if (!(fflag1 == 2 || fflag2 == 2)) FTwinCat3Utility.WriteAnyToPLC("INPUT_G6_VAR.I_G6_ENABLE", TypeOfData.tpBool, false);
                // bool val = (bool) ReadAnyFromPLC(pro)
                if (FListRotary1Notification.Count != 0)
                {
                    //int fflag = 0;B
                    //string varname = "";s
                    string notif = FListRotary1Notification[0];
                    if (OnJoganThreadWorking != null) OnJoganThreadWorking(FThreads[StartThreadFor.Rotary1].CurrentThread, notif);
                    switch (notif)
                    {
                        case "LOADER_RS4_VAR.I_LOADER_RS4_START_TAKEUP":
                            //WriteAnyToPLC("LOADER_RS4_VAR.O_LOADER_RS4_CONTINUE", TypeOfData.tpBool, false);
                            if (!FI_LOADER_RS4_ENABLE) PrepareAvailableSocketData(); else FI_LOADER_RS4_ENABLE = false;
                            break;
                        case "LOADER_RS4_VAR.I_LOADER_RS4_READY_PLACING":
                            WriteAnyToPLC("LOADER_RS4_VAR.O_LOADER_RS4_CONTINUE", TypeOfData.tpBool, true);
                            break;
                        case   "LOADER_RS4_VAR.I_LOADER_RS4_START_PLACING":
                            WriteAnyToPLC("LOADER_RS4_VAR.O_LOADER_RS4_CONTINUE", TypeOfData.tpBool, false);
                            break;
                        case "LOADER_RS4_VAR.I_LOADER_RS4_ENABLE":
                            FI_LOADER_RS4_ENABLE = true;
                            PrepareAvailableSocketData();
                            break;
                    }
                    if (FListRotary1Notification.Count != 0) FListRotary1Notification.RemoveAt(0);
                }
                Skip:
                 Task.Delay(WAIT_THREAD_TIME);
            }
        }

        #endregion
        #region Rotary2
        private bool CheckIfRS4_2Finish()
        {
            return true;
        }
        private bool CheckBookingLoadingJigCarrierExist()
        {
            bool ret = false;
            using (var db = new DBProjectEntities())
            {
                int cch = db.T_BOOKING_STATIONS.Where(x => x.Status == "LoadingJigCarrier").Count();
                //txtLoadingJigCarrier.Text = cch.ToString();
                ret = cch > 0;
            }
            return ret;
        }
        private bool CheckIfLoadJigFinish() //jig on rs4-1
        {
            return (bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.I_LOADER_RS4_END_CARRIER", TypeOfData.tpBool);  
        }
        private bool CheckIfUnloadJigFinish() //jig on rs4-2
        { 
            return (bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_RS4_VAR.I_SORTER_RS4_END_CARRIER", TypeOfData.tpBool);
        }
        private  void ThreadForRotary2()
        {
            while (true) //(FListFukudaNotification.Count > 0)
            {
                //if (FEndProccess || FThreads[StartThreadFor.Rotary2].IsStop) break;
                //if (FPauseProccess) Wait(delegate () { return FPauseProccess; });
               // if (FThreads[StartThreadFor.Rotary2].IsPaused) goto Skip;
                WaitAsynchronous(FThreads[StartThreadFor.Rotary2], delegate () { return FPauseProccess; });
                if (FThreads[StartThreadFor.Rotary2].IsPaused) goto Skip;
                if (!CheckIfG8OnDuty())
                {
                    if (!CheckBookingLoadingJigCarrierExist())
                    {

                    }
                    else
                    {
                        if (CheckIfLoadJigFinish())
                        {
                            M_MACHINE_TESTER m = null;
                            bool finish = CheckIfUnloadJigFinish();
                            bool available = CheckIfMachineDestinationAvailable(out m);
                            if (finish && available)
                            {
                                //    WaitSynchronous(delegate ()
                                //    {

                                //        return !(bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.I_LOADER_RS4_START_TAKEUP", TypeOfData.tpBool);
                                //        //return !(bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.I_LOADER_RS4_READY_PLACING", TypeOfData.tpBool);
                                //    }, delegate ()
                                //    { 
                                FTwinCat3Utility.WriteAnyToPLC("INDEXING_2_VAR.O_ROTATION_START", TypeOfData.tpBool, true);
                                WaitSynchronous(
                                    delegate ()
                                    {
                                        //wait until rotary 2 finish rotate
                                        return !(bool)FTwinCat3Utility.ReadAnyFromPLC("INDEXING_2_VAR.I_INDEXING_2_ROTATION_DONE", TypeOfData.tpBool);
                                    },
                                    delegate ()
                                    {
                                        //reset load jig finish on rs4-1 to false
                                        FTwinCat3Utility.WriteAnyToPLC("LOADER_RS4_VAR.I_LOADER_RS4_END_CARRIER", TypeOfData.tpBool, false);
                                        if (FSorterCounter <= 1)
                                        {
                                            FTwinCat3Utility.WriteAnyToPLC("SORTER_RS4_VAR.I_SORTER_RS4_END_CARRIER", TypeOfData.tpBool, true);
                                            FSorterCounter++;
                                        }
                                        else
                                        {
                                            FTwinCat3Utility.WriteAnyToPLC("SORTER_RS4_VAR.I_SORTER_RS4_ENABLE", TypeOfData.tpBool, true);

                                            //reset unload jig finish on rs4-2 to false
                                            FTwinCat3Utility.WriteAnyToPLC("SORTER_RS4_VAR.I_SORTER_RS4_END_CARRIER", TypeOfData.tpBool, false);
                                            FSorterCounter = 3;
                                        }
                                        //FTwinCat3Utility.WriteAnyToPLC("", TypeOfData.tpBool, false);
                                        //get latest transaction input
                                        if (FTransactionInputNearLaser != null && FTempTransactionInputNearLaser != null)
                                        {
                                            if (FTransactionInputNearLaser.PO_Number != FTempTransactionInputNearLaser.PO_Number)
                                            {
                                                Commons.Commons.CopyProperties(FTempTransactionInputNearLaser, FTransactionInputNearLaser);
                                                //T_JIG_SOCKET tjs = FTwinCat3Utility.ReadAnyFromPLC()
                                                SendBackAllLaserTransport();
                                                //WaitSynchronous(delegate () { return LaserTransfer1.Flag == 2 || LaserTransfer2.Flag == 2 || LaserTransferNG.Flag == 2; });
                                                PrepareLoadingJigLaser(null, true);
                                            }
                                            else
                                            {

                                            }
                                        }
                                        CommandG8ToMoveJigFromTo(null, new JoganMachinePosition { MachineType = m.Machines_Type, MachineLine = m.Machine_Line_Number, MachineNumber = m.Machine_Number });
                                    });
                            }
                            //});
                        }
                    }
                }
                Skip:
                 Task.Delay(WAIT_THREAD_TIME);
            }

            //WaitAsynchronous(FThreads[StartThreadFor.Rotary2],
            //    delegate ()
            ////proccesses here
            //{
            //    return false;
            //    //return 
            //    //CheckIfRS4_2Finish() &&
            //    //(CheckIfTestingFinishExist() || CheckIfMachineDestinationAvailableFrom()) &&
            //    //!CheckIfG8OnDuty()
            //}  ,
            //    delegate () {
            //        //rotate rotary index 2
            //        WaitSynchronous(delegate () {
            //            return
            //            //wait until rotary 2 rotate 
            //            true;
            //        });
            //        //CommandG8ToMoveJigFromTo("ROTARY2", m.Machine_ID);
            //    });
            //await Task.Delay(WAIT_THREAD_TIME); 
        }

        #endregion
        #region Just for simulation
        private void ThreadForFukudaSimulation()
        {
            FUnloadingStation.TransactionInput = new T_TRANSACTION_INPUT
            {
                PO_Number = "PO0000000001",
                Device_ID = "00001",
                Status = "Unload",
                LotBox_ID = "1",
                Default_Test_Mode = "Low",
                Quantity = 700,
                LotBox_Position_Fukuda = 4
            };
            FUnloadingStation.CurrentTransaction = new T_CURRENT_TRANSACTION
            {
                JIG_INDEX_LOAD = 0,
                TRANSPORT_INDEX = 1,

            };
            int ttl = 1;
            while (true) //(FListFukudaNotification.Count > 0)
            {
                if (FEndProccess || FThreads[StartThreadFor.FukudaSimulation].IsStop) break;
                //if (FPauseProccess) Wait(delegate () { return FPauseProccess; });
                if (!FThreads[StartThreadFor.FukudaSimulation].IsPaused)
                {
                    WaitAsynchronous(FThreads[StartThreadFor.FukudaSimulation], delegate () { return FPauseProccess; });
                    FUnloadingStation.TransactionInput.PO_Number = "PO000000000" + ttl.ToString();
                    FUnloadingStation.TransactionInput.LotBox_Position_Fukuda = ttl;
                    FUnloadingStation.CurrentTransaction.JIG_INDEX_LOAD++;
                    StatusTestingControl stc = StatusTestingControl.Unloading;
                    if (FUnloadingStation.CurrentTransaction.JIG_INDEX_LOAD == 10)
                    {
                        stc = StatusTestingControl.Finish;
                        FUnloadingStation.CurrentTransaction.JIG_INDEX_LOAD = 0;
                        if (OnUnloadingStation != null) OnUnloadingStation(this, stc, FUnloadingStation);
                        //CreateMessage("", "Station " + ttl.ToString() + " finish unload jig","Station","Low");
                        ttl++;
                    }
                    else if (OnUnloadingStation != null) OnUnloadingStation(this, stc, FUnloadingStation);
                    if (ttl > 4) break;
                }
                Task.Delay(3000);
            }
        }
        private  void ThreadForMachineSimulation()
        {
            List<M_MACHINE_TESTER> m = null;
            using (var db = new DBProjectEntities())
            {
                m = db.M_MACHINE_TESTERS.OrderBy(x => x.Machines_Type).ThenBy(x => x.Machine_Number).ToList();
            }
            int ttl = 0;
            while (true) //(FListFukudaNotification.Count > 0)
            {
                if (FEndProccess || FThreads[StartThreadFor.MachineSimulation].IsStop) break;
                //if (FPauseProccess) Wait(delegate () { return FPauseProccess; });
                if (!FThreads[StartThreadFor.MachineSimulation].IsPaused)
                {
                    WaitAsynchronous(FThreads[StartThreadFor.MachineSimulation], delegate () { return FPauseProccess; }); M_MACHINE_TESTER mm = m[ttl];
                    JoganMachineTester mt = new JoganMachineTester
                    {
                        Interval = 0,
                        JigID = ttl.ToString(),
                        MachineName = mm.Machines_Type + " " + mm.Machine_Name,
                        MachineCode = mm.Machines_Type + "_" + mm.Machine_Number.ToString(),
                    };
                    if (mm.Machines_Type == "NOISE") mt.Interval = 180;
                    if (mm.Machines_Type == "RESISTANCE") mt.Interval = 30;
                    if (mm.Machines_Type == "SIGNAL") mt.Interval = 60;
                    //StatusTestingControl stc = StatusTestingControl.Unloading;
                    if (OnEventMachineTester != null) OnEventMachineTester(this, StatusTestingControl.Testing, mt);
                    ttl++;
                    if (ttl > m.Count - 1) break;
                }
                 Task.Delay(3000);
            }
        }
        private  void ThreadForLaserSimulation()
        {
            FLoadingStation.TransactionInput = new T_TRANSACTION_INPUT
            {
                PO_Number = "PO0000000001",
                Device_ID = "00001",
                Status = "Unload",
                LotBox_ID = "1",
                Default_Test_Mode = "Low",
                Quantity = 750,
                LotBox_Position_Fukuda = 4
            };
            FLoadingStation.SorterSummary = new T_SORTER_SUMMARY();
            int ttl = 1;
            while (true) //(FListFukudaNotification.Count > 0)
            {
                if (FEndProccess || FThreads[StartThreadFor.FukudaSimulation].IsStop) break;
                //if (FPauseProccess) Wait(delegate () { return FPauseProccess; });
                if (!FThreads[StartThreadFor.FukudaSimulation].IsPaused)
                {
                    WaitAsynchronous(FThreads[StartThreadFor.FukudaSimulation], delegate () { return FPauseProccess; });
                    FLoadingStation.TransactionInput.PO_Number = "PO000000000" + ttl.ToString();
                    FLoadingStation.TransactionInput.LotBox_Position_Laser = ttl;
                    StatusTestingControl stc = StatusTestingControl.Loading;
                    if (FUnloadingStation.CurrentTransaction.JIG_INDEX_LOAD == 10)
                    {
                        stc = StatusTestingControl.Finish;
                        FUnloadingStation.CurrentTransaction.JIG_INDEX_LOAD = 0;
                        if (OnUnloadingStation != null) OnUnloadingStation(this, stc, FUnloadingStation);
                        //CreateMessage("", "Station " + ttl.ToString() + " finish unload jig", "Station", "Low");
                        ttl++;
                    }
                    else if (OnLoadingStation != null) OnLoadingStation(this, stc, FLoadingStation);
                    if (ttl > 4) break;
                }
                 Task.Delay(3000);
            }
        }
        #endregion
        #region Check DB
        private void ThreadForCheckError()
        {
            while (true) //(FListFukudaNotification.Count > 0)
            {
                //if (FEndProccess || FThreads[StartThreadFor.DBCheckError].IsStop) break;
                //if (FPauseProccess) Wait(delegate () { return FPauseProccess; });
                //if (FThreads[StartThreadFor.DBCheckError].IsPaused) goto Skip;

                WaitAsynchronous(FThreads[StartThreadFor.DBCheckError], delegate () { return FPauseProccess; });
                if (FThreads[StartThreadFor.DBCheckError].IsPaused) goto Skip;
                using (var db = new DBProjectEntities())
                {
                    V_MESSAGE el = null;//
                    if (JoganFunctionAs == JoganFunctionAs.AsControllerWatcher)
                    {
                        el = db.Database.SqlQuery<V_MESSAGE>("select  * from V_MESSAGE tel where tel.status='Unread' and tel.MarkAsDelete=1 and tel.created_date = (select max(created_date) from t_error_list)").FirstOrDefault();
                        if (el != null)
                        {
                            {
                                T_ERROR_LIST el2 = db.T_ERROR_LISTS.Where(x => x.ID == el.ID).FirstOrDefault();
                                if (el2 != null)
                                {
                                    el2.Status = "Read";
                                    el2.Updated_Date = DateTime.Now;
                                    db.Entry(el2).CurrentValues.SetValues(el2);
                                    TrySaveChange(db);
                                }
                            }
                        }
                    }
                    else
                    {
                        el = db.Database.SqlQuery<V_MESSAGE>("select  * from V_MESSAGE tel where tel.status='Read' and  tel.created_date = (select max(created_date) from t_error_list)").FirstOrDefault();
                    }
                    if (el != null)
                    {
                        if (OnNewMessage != null) OnNewMessage(this, el);
                    } 
                }
                Skip:
                Task.Delay(WAIT_THREAD_TIME);
            }
        }

        private  void ThreadForStationReady()
        {
            while (true) //(FListFukudaNotification.Count > 0)
            {
                //if (FEndProccess || FThreads[StartThreadFor.DBCheckStationReady].IsStop) break;
                //if (FPauseProccess) Wait(delegate () { return FPauseProccess; });
                //if (FThreads[StartThreadFor.DBCheckStationReady].IsPaused) goto Skip;
                WaitAsynchronous(FThreads[StartThreadFor.DBCheckStationReady], delegate () { return FPauseProccess; });
                if (FThreads[StartThreadFor.DBCheckStationReady].IsPaused) goto Skip;
                //CheckStationReady();
                Skip:
                 Task.Delay(WAIT_THREAD_TIME);
            }
        }
        #endregion
        private void ExecuteOnDispose()
        {
           // Stop();
            FUnloadingStation = null;
            FOldLoadingStation = null;
            FOldUnloadingStation = null;
            FListCloseSocket.Clear();
            FListTestResult.Clear();
            FListFukudaNotification.Clear();
            FListMachineTesterNotification.Clear();
            FThreads.Clear();
            FBufferCarrier.ClearItems();
        }
        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~JoganUtility() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            ExecuteOnDispose();
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        #region Print Report
        private void SetErrorSummary(T_SORTER_SUMMARY Sorter, string ErrorCode)
        {
            using (var db = new DBProjectEntities())
            {
                DateTime maxdate = db.Database.SqlQuery<DateTime>("select max(created_date) from M_NG_CONFIG").FirstOrDefault();

                M_NG_CONFIG conf = db.M_NG_CONFIGS.Where(x => x.NG_Code == ErrorCode && x.Created_Date == maxdate).FirstOrDefault();
                if (conf == null)
                {
                    Sorter.Qty_NG_Other++;
                }
                else
                {
                    switch (ErrorCode)
                    {
                        case "E1": Sorter.Qty_NG1++; break;
                        case "E2": Sorter.Qty_NG2++; break;
                        case "E3": Sorter.Qty_NG3++; break;
                        case "E4": Sorter.Qty_NG4++; break;
                        case "E5": Sorter.Qty_NG5++; break;
                        case "E6": Sorter.Qty_NG6++; break;
                        case "E7": Sorter.Qty_NG7++; break;
                    }
                }
            }
        }
        private void TrySaveChange(DBProjectEntities context)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {


                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
        #endregion
        #region Machine Tester Handler
        public void RecreateBookingSystemFromErrorMachine(M_MACHINE_TESTER AMachine)
        {
            int machinenoreplace = 0;
            if (AMachine.Machines_Type=="RESISTANCE")
            {
                machinenoreplace = 1;
                if (AMachine.Machine_Number==1) { machinenoreplace = 2; }
            }
        }
        public void PrepareListTestResult(string PONumber = "", string JigID = "", string MachineCode = "")
        {
            //if (!FAllowConnect) return;
            //T_JIG_SOCKET ct = new T_JIG_SOCKET();
            T_JIG_SOCKET ct = null;
            ct = (T_JIG_SOCKET)FTwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_LASER_SOCKET", TypeOfData.tpObject, typeof(T_JIG_SOCKET));
            if (FListTestResult.Count == 0)
            {
                //for (int i = 0; i <= 63; i++) FListTestResult.Add(i, 0);
                using (var db = new DBProjectEntities())
                {
                    T_BOOKING_STATION tbs = db.Database.SqlQuery<T_BOOKING_STATION>("select * from T_BOOKING_STATION where id = (select max(id) from T_BOOKING_STATION where status='TestDone')").FirstOrDefault();//  db.T_BOOKING_STATIONS.Where(x => x.PO_Number == PONumber && x.Jig_ID == JigID && x.Status == "TestDone").FirstOrDefault();
                    ct.PO_NUMBER = tbs.PO_Number;
                    T_SORTER_RESULT tsr = db.T_SORTER_RESULTS.Where(x => x.PO_Number == tbs.PO_Number && x.Jig_ID == tbs.Jig_ID).FirstOrDefault();
                    V_MACHINE_CLOSE_SOCKET noise = db.Database.SqlQuery<V_MACHINE_CLOSE_SOCKET>("select * from V_MACHINE_CLOSE_SOCKET where machine_id = (select machine_id from M_MACHINE_TESTER where Machines_Type = 'NOISE' and Machine_Number=" + tbs.Noise_Room_Number.ToString() + ")").FirstOrDefault();
                    V_MACHINE_CLOSE_SOCKET signal = db.Database.SqlQuery<V_MACHINE_CLOSE_SOCKET>("select * from V_MACHINE_CLOSE_SOCKET where machine_id = (select machine_id from M_MACHINE_TESTER where Machines_Type = 'SIGNAL' and Machine_Number=" + tbs.Signal_Room_Number.ToString() + ")").FirstOrDefault();
                    V_MACHINE_CLOSE_SOCKET resistance = db.Database.SqlQuery<V_MACHINE_CLOSE_SOCKET>("select * from V_MACHINE_CLOSE_SOCKET where machine_id = (select machine_id from M_MACHINE_TESTER where Machines_Type = 'RESISTANCE' and Machine_Number=" + tbs.Resistance_Room_Number.ToString() + ")").FirstOrDefault();
                    string field = "";
                    for (int i = 1; i <= 64; i++)
                    {
                        field = "Socket_" + i.ToString();
                        int noise_cs = 0;
                        int signal_cs = 0;
                        int resistance_cs = 0;
                        if (noise != null) noise_cs = (int)Commons.Commons.GetValueFromProperty(noise, field);
                        if (signal != null) signal_cs = (int)Commons.Commons.GetValueFromProperty(signal, field);
                        if (resistance != null) resistance_cs = (int)Commons.Commons.GetValueFromProperty(resistance, field);
                        if (noise_cs == 0 && resistance_cs == 0 && signal_cs == 0)
                        {
                            string val = (string)Commons.Commons.GetValueFromProperty(tsr, field);
                            if (val != "NOD")
                            {
                                if (val == "PASS")
                                {
                                    FListTestResult.Add(i, 9);
                                }
                                else
                                {
                                    DateTime maxdate = db.Database.SqlQuery<DateTime>("select max(created_date) from M_NG_CONFIG").FirstOrDefault();
                                    M_NG_CONFIG conf = db.M_NG_CONFIGS.Where(x => x.NG_Code == val && x.Created_Date == maxdate).FirstOrDefault();
                                    if (conf == null)
                                    {
                                        FListTestResult.Add(i, 8);
                                    }
                                    else
                                    {
                                        FListTestResult.Add(i, conf.Box_Index);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            int cch = 1;
            ct.STATION_NUMBER = 0;
            ct.AVAILABLE_SOCKET[0] = 0;
            ct.AVAILABLE_SOCKET[1] = 0;
            ct.AVAILABLE_SOCKET[2] = 0;
            ct.AVAILABLE_SOCKET[3] = 0;
            ct.AVAILABLE_SOCKET[4] = 0;
            ct.LASER_DESTINATION[0] = 0;
            ct.LASER_DESTINATION[1] = 0;
            ct.LASER_DESTINATION[2] = 0;
            ct.LASER_DESTINATION[3] = 0;
            ct.LASER_DESTINATION[4] = 0;
            foreach (var item in FListTestResult.ToList())
            {
                ct.AVAILABLE_SOCKET[cch] = (byte)item.Key;// FListTestResult[item.Key];
                ct.LASER_DESTINATION[cch] = (byte)FListTestResult[item.Key];
                cch++;
                if (cch == 5)
                {
                    FListTestResult.Remove(item.Key);
                    //FTwinCat3Utility.WriteAnyToPLC("SORTER_RS4_VAR.I_SORTER_RS4_ENABLE", TypeOfData.tpBool, true);
                    //FTwinCat3Utility.WriteAnyToPLC("SORTER_RS4_VAR.O_SORTER_RS4_CONTINUE", TypeOfData.tpBool, true);

                    //WaitSynchronous(delegate ()
                    //{
                    //    return (bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_RS4_VAR.I_SORTER_RS4_START_PLACING", TypeOfData.tpBool);
                    //});
                    FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_SOCKET", TypeOfData.tpObject, ct);
                    break;
                }
                FListTestResult.Remove(item.Key);

                if (FListTestResult.Count == 0)
                {
                    FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_SOCKET", TypeOfData.tpObject, ct);
                    //FTwinCat3Utility.WriteAnyToPLC("SORTER_RS4_VAR.I_SORTER_RS4_ENABLE", TypeOfData.tpBool, true);
                    //FTwinCat3Utility.WriteAnyToPLC("SORTER_RS4_VAR.O_SORTER_RS4_CONTINUE", TypeOfData.tpBool, true);
                    WaitSynchronous(
                            //delegate () { return (bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.I_LOADER_RS4_READY_PLACING", TypeOfData.tpBool); ; },
                            delegate ()
                            {
                                return !(bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_RS4_VAR.I_SORTER_RS4_START_PLACING", TypeOfData.tpBool);
                            },
                delegate () { FTwinCat3Utility.WriteAnyToPLC("SORTER_RS4_VAR.I_SORTER_RS4_END_CARRIER", TypeOfData.tpBool, true); });
                    //});
                    ct = null;
                    break;
                }
            }
            //FListTestResult//
        }
        public void PrepareAvailableSocketData()
        {
            if (!FAllowConnect) return;
            T_JIG_SOCKET ct = null;
            ct = (T_JIG_SOCKET)FTwinCat3Utility.ReadAnyFromPLC("INPUT_VAR.I_LOADING_SOCKET", TypeOfData.tpObject, typeof(T_JIG_SOCKET));

            if (FListCloseSocket.Count == 0)
            {
                for (int i = 0; i <= 63; i++) FListCloseSocket.Add(i + 1);
                using (var db = new DBProjectEntities())
                {
                    T_BOOKING_STATION tbs = db.Database.SqlQuery<T_BOOKING_STATION>("select * from T_BOOKING_STATION where id = (select min(id) from T_BOOKING_STATION where jig_id='EMPTY' and status='Queue')").FirstOrDefault();
                    if (tbs != null)
                    {
                        T_BOOKING_STATION tbs2 = db.T_BOOKING_STATIONS.Where(x => x.ID == tbs.ID).FirstOrDefault();
                        tbs2.Status = "LoadingJigCarrier";
                        db.Entry(tbs2).CurrentValues.SetValues(tbs2);
                        TrySaveChange(db);

                        ct.MAX_DEVICE_COUNT = (byte)tbs.Device_Qty;
                        //FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOADING_SOCKET", TypeOfData.tpObject, ct);

                        if (tbs.Close_Socket_Numbers != "None")
                        {
                            string[] arr = tbs.Close_Socket_Numbers.Split(',');
                            foreach (var item in arr)
                            {
                                int id = Convert.ToInt32(item);
                                FListCloseSocket[id - 1] = -1 * id;
                            }
                        }
                    }
                }
            }
            //else
            // {
            //T_JIG_SOCKET tjs = new T_JIG_SOCKET();
            int cch = 1;
            ct.AVAILABLE_SOCKET[0] = 0;
            ct.AVAILABLE_SOCKET[1] = 0;
            ct.AVAILABLE_SOCKET[2] = 0;
            ct.AVAILABLE_SOCKET[3] = 0;
            ct.AVAILABLE_SOCKET[4] = 0;
            ct.LASER_DESTINATION[0] = 0;
            ct.LASER_DESTINATION[1] = 0;
            ct.LASER_DESTINATION[2] = 0;
            ct.LASER_DESTINATION[3] = 0;
            ct.LASER_DESTINATION[4] = 0;
            bool g1 = false;
            bool g2 = false;
            bool g3 = false;
            bool g4 = false;
            //if (FListCloseSocket.Count != 0)
            //{

            //    g1 = (bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.O_LOADER_RS4_GRIPPER_CLOSE_1", TypeOfData.tpBool);
            //    g2 = (bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.O_LOADER_RS4_GRIPPER_CLOSE_2", TypeOfData.tpBool);
            //    g3 = (bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.O_LOADER_RS4_GRIPPER_CLOSE_3", TypeOfData.tpBool);
            //    g4 = (bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.O_LOADER_RS4_GRIPPER_CLOSE_4", TypeOfData.tpBool);
            //    if (g1) { ct.AVAILABLE_SOCKET[1] = (byte)FListCloseSocket[0]; FListCloseSocket.RemoveAt(0); }
            //    if (g2) { ct.AVAILABLE_SOCKET[2] = (byte)FListCloseSocket[0]; FListCloseSocket.RemoveAt(0); }
            //    if (g3) { ct.AVAILABLE_SOCKET[3] = (byte)FListCloseSocket[0]; FListCloseSocket.RemoveAt(0); }
            //    if (g4) { ct.AVAILABLE_SOCKET[4] = (byte)FListCloseSocket[0]; FListCloseSocket.RemoveAt(0); }
            //}

            //if (g1 || g2 || g3 || g4)
            //{
            //    FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOADING_SOCKET", TypeOfData.tpObject, ct);
            //    ct = null;
            //    return;
            //}
            while (true)
            {
                if (FListCloseSocket[0] > 0)// && FListCloseSocket.Count == 0)
                {
                    ct.AVAILABLE_SOCKET[cch] = (byte)FListCloseSocket[0];
                    cch++;
                    if (cch >= 5)
                    {
                        FListCloseSocket.RemoveAt(0);
                        FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOADING_SOCKET", TypeOfData.tpObject, ct);
                        if (FListCloseSocket.Count == 0)
                        {
                            FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOADING_SOCKET", TypeOfData.tpObject, ct);

                            WaitSynchronous(
                                    //delegate () { return (bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.I_LOADER_RS4_READY_PLACING", TypeOfData.tpBool); ; },
                                    delegate ()
                                    {
                                        return !(bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.I_LOADER_RS4_START_TAKEUP", TypeOfData.tpBool);
                                    },
                        delegate ()
                        {
                            FTwinCat3Utility.WriteAnyToPLC("LOADER_RS4_VAR.I_LOADER_RS4_END_CARRIER", TypeOfData.tpBool, true);

                        }
                                    );
                            ct = null;
                        }
                            break;
                    }
                }
                FListCloseSocket.RemoveAt(0);
                if (FListCloseSocket.Count == 0)
                {
                    FTwinCat3Utility.WriteAnyToPLC("INPUT_VAR.I_LOADING_SOCKET", TypeOfData.tpObject, ct);

                    WaitSynchronous(
                            //delegate () { return (bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.I_LOADER_RS4_READY_PLACING", TypeOfData.tpBool); ; },
                            delegate ()
                            {
                                return !(bool)FTwinCat3Utility.ReadAnyFromPLC("LOADER_RS4_VAR.I_LOADER_RS4_START_TAKEUP", TypeOfData.tpBool);
                            },
                delegate ()
                    {
                        FTwinCat3Utility.WriteAnyToPLC("LOADER_RS4_VAR.I_LOADER_RS4_END_CARRIER", TypeOfData.tpBool, true);

                    }
                            );
                    ct = null;
                    break;
                }
            } 
            ct = null;
        }
        public string GetDataFrom2DCode(int PortCommand = 9024, int PortData = 9024)
        {
            string IP = ConfigurationManager.AppSettings["TwoDCodeIP"];
            string[] ips = IP.Split('.');
            byte[] ip = new byte[4];//{ 192, 168, 1, 254 };
            int cch = 0;
            foreach (string item in ips)
            {
                ip[cch] = (byte)(Convert.ToByte(item));
                cch++;
            }
            Byte[] recvBytes = new Byte[RECV_DATA_MAX];
            int recvSize = 0;
            IPAddress readerIpAddress = new IPAddress(ip);
            IPEndPoint readerCommandEndPoint = new IPEndPoint(readerIpAddress, PortCommand);
            IPEndPoint readerDataEndPoint = new IPEndPoint(readerIpAddress, PortData);
            //commandSocket = null;
            //dataSocket = null;
            Socket DataSocket = null;
            Socket CommandSocket = null;
            string ret = "";
            try
            {
                DataSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                DataSocket.Connect(readerDataEndPoint);
                DataSocket.ReceiveTimeout = 100;
                if (PortCommand == PortData)
                {
                    CommandSocket = DataSocket;
                }
                else
                {
                    CommandSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    CommandSocket.Connect(readerCommandEndPoint);
                }
                string lon = "LON\r";   // CR is terminator
                string loff = "LOFF\r";   // CR is terminator
                Byte[] command = ASCIIEncoding.ASCII.GetBytes(lon);

                CommandSocket.Send(command);

                try
                {
                    recvSize = DataSocket.Receive(recvBytes);
                    //loff command
                    command = ASCIIEncoding.ASCII.GetBytes(loff);
                    CommandSocket.Send(command);
                }
                catch (SocketException)
                {
                    //
                    // Catch the exception, if cannot receive any data.
                    //
                    recvSize = 0;
                }

                if (recvSize == 0)
                {
                    //MessageBox.Show("Reader has no data.");
                }
                else
                {
                    //
                    // Show the receive data after converting the receive data to Shift-JIS.
                    // Terminating null to handle as string.
                    //
                    recvBytes[recvSize] = 0;
                    ret = Encoding.GetEncoding("Shift_JIS").GetString(recvBytes);
                    //MessageBox.Show(ret);
                }
                DataSocket.Close();
                CommandSocket.Close();
                DataSocket = null;
                CommandSocket = null;
                return ret;
            }
            catch (Exception e)
            {
                DataSocket = null;
                CommandSocket = null;
                MessageBox.Show(e.Message);
                return ret;
            }
        }
        //private bool CheckIsLaserStationReady()
        //{
        //    bool ret = true;
        //    using (var db = new DBProjectEntities())
        //    {
        //        SP_LASER_STATION ls1 = db.Database.SqlQuery<SP_LASER_STATION>("SP_LASER_STATION @ISDownGrade", new SqlParameter("ISDownGrade", false)).FirstOrDefault();
        //        ret = ls1 != null;
        //        if (ret) LotboxLaserPosition = ls1.LotBox_Position;
        //        if (TestMode == TestMode.tmDowngrade)
        //        {
        //            SP_LASER_STATION ls2 = db.Database.SqlQuery<SP_LASER_STATION>("SP_LASER_STATION @ISDownGrade", new SqlParameter("ISDownGrade", true)).FirstOrDefault();
        //            ret = ls2 != null;
        //            if (ret) LotboxLaserDowngradePosition = ls2.LotBox_Position;
        //        }
        //    }
        //    return ret;
        //}
        private void RegisterMachineAndMachineControl()
        {

        }
        private string FTempJigID = "";
        private string CreateJigID()
        {
            string ret = "";
            Random rnd = new Random();
            int num = rnd.Next(1, 1000); //sum of error code each jig
            if (num >= 1 && num <= 9) ret = "000";
            if (num >= 10 && num <= 99) ret = "00";
            if (num >= 100 && num <= 999) ret = "0";
            ret = ret + num.ToString();
            return ret;
        }
        public void Scan2DCode(bool OnRotary2, out T_TRANSACTION_INPUT TransactionInput)
        {
            TransactionInput = null;
            //FCounterJigID++;
             
            string twodcode = GetDataFrom2DCode();
            if (twodcode == "")
            {
                if (FTempJigID == "") FTempJigID = CreateJigID();
            }
            else {
                twodcode = twodcode.Replace("\0", "");
                twodcode = twodcode.Replace("\r", "");
                FTempJigID = twodcode; }

            //twodcode = "0734";// CreateJigID(); 
            if (OnRotary2)
            {
                using (var db = new DBProjectEntities())
                {
                    T_BOOKING_STATION tbs = db.Database.SqlQuery<T_BOOKING_STATION>("select * from T_BOOKING_STATION where ID= (select max(id) from T_BOOKING_STATION where jig_id='" + FTempJigID + "' and Status='Testing')").FirstOrDefault();
                    T_BOOKING_STATION tbs2 = null;
                    DateTime dt = DateTime.Now;
                    // tbs2 = db.T_BOOKING_STATIONS.Where(x => x.ID == tbs.ID).FirstOrDefault();
                    if (tbs == null) //if new jig to be testing ...
                    {
                        tbs = db.Database.SqlQuery<T_BOOKING_STATION>("select * from T_BOOKING_STATION where ID= (select min(id) from T_BOOKING_STATION where jig_id='EMPTY' and Status='LoadingJigCarrier')").FirstOrDefault();
                        tbs2 = db.T_BOOKING_STATIONS.Where(x => x.ID == tbs.ID).FirstOrDefault();
                        tbs2.Updated_Date = DateTime.Now;
                        tbs2.Status = "Testing";
                        tbs2.Jig_ID = FTempJigID;

                        goto Skip;
                    }
                    else
                    {
                        tbs2 = db.T_BOOKING_STATIONS.Where(x => x.ID == tbs.ID).FirstOrDefault();
                        T_TRANSACTION_INPUT tti = db.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == tbs2.PO_Number).FirstOrDefault();
                        if (tti.LotBox_Position_Laser == 0)
                        {
                            T_LASER_STATION tls = db.Database.SqlQuery<T_LASER_STATION>("SELECT * FROM T_LASER_STATION " +
                                "WHERE ID = (SELECT MIN(ID)  FROM  T_LASER_STATION WHERE (Status = 'Ready' AND Is_Downgrade = 0)) ").FirstOrDefault();
                            if (tls == null)
                            {
                                CreateMessage("Please provide lotbox on Laser Station", "Laser Stattion", "High");
                                Pause(true);
                                WaitSynchronous(delegate ()
                                {
                                    tls = db.Database.SqlQuery<T_LASER_STATION>("SELECT * FROM T_LASER_STATION WHERE ID = (SELECT MIN(ID)  FROM  T_LASER_STATION WHERE(Status = 'Ready' AND Is_Downgrade = 0)) ").FirstOrDefault();
                                    return tls == null;
                                }, delegate ()
                                 {
                                     Pause(false);
                                 });
                            }
                            T_LASER_STATION tls2 = db.T_LASER_STATIONS.Where(x => x.ID == tls.ID).FirstOrDefault();
                            tls2.Status = "Booked";
                            tls2.Updated_Date = dt;
                            db.Entry(tls2).CurrentValues.SetValues(tls2);
                            T_TRANSACTION_LASER ttl = db.T_TRANSACTION_LASERS.Where(x => x.PO_Number == tti.PO_Number).FirstOrDefault();
                            if (ttl == null)
                            {
                                ttl = new T_TRANSACTION_LASER();
                                ttl.Created_Date = dt;
                                ttl.Created_User = JoganUserID;
                                ttl.Device_ID = tti.Device_ID;
                                ttl.LotBox_ID = tls.LotBox_ID;
                                ttl.LotBox_NG_ID = tls.LotBox_NG_ID;
                                ttl.LotBox_Position = tls.LotBox_Position;
                                ttl.PO_Number = tti.PO_Number;
                                ttl.Quantity = tti.Quantity;
                                ttl.Updated_Date = dt;
                                ttl.Updated_User = JoganUserID;
                                ttl.User_ID = JoganUserID;
                                db.T_TRANSACTION_LASERS.Add(ttl);
                            }
                            else
                            {
                                ttl.Device_ID = tti.Device_ID;
                                ttl.LotBox_ID = tls.LotBox_ID;
                                ttl.LotBox_NG_ID = tls.LotBox_NG_ID;
                                ttl.LotBox_Position = tls.LotBox_Position;
                                ttl.PO_Number = tti.PO_Number;
                                ttl.Quantity = tti.Quantity;
                                ttl.Updated_Date = dt;
                                ttl.Updated_User = JoganUserID;
                                db.Entry(ttl).CurrentValues.SetValues(ttl);
                            }
                            tti.LotBox_Position_Laser = tls.LotBox_Position;
                            tti.Updated_Date = dt;
                            db.Entry(tti).CurrentValues.SetValues(tti);
                        }
                        //FTempTransactionInputNearLaser = tti;
                        TransactionInput = tti;
                        FTempJigID = "";
                    }
                    tbs2.Status = "TestDone";
                    tbs2.Updated_Date = dt;
                    Skip:
                    db.Entry(tbs2).CurrentValues.SetValues(tbs2);
                    TrySaveChange(db);
                }
                FTwinCat3Utility.WriteAnyToPLC("TESTER_C8_VAR.O_G6_FINISH_SCANBARCODE", TypeOfData.tpBool, true);
            } else
            {

            }
        }
        public void CreateDummyTestData(string PONumber, string JigID, string MachineCode)
        {
            //List<string> ListError = new List<string>();
            //for (int i = 1; i <= 30; i++) ListError.Add("E" + i.ToString());
            using (var db = new DBProjectEntities())
            {
                 DateTime dt = DateTime.Now;
                M_MACHINE_CLOSE_SOCKET mmcs = db.M_MACHINE_CLOSE_SOCKETS.Where(x => x.Machine_ID == MachineCode).FirstOrDefault();
                List<string> CloseSockets = new List<string>();
                bool sc = false;
                string field = "";
                for (int i = 1; i <= 64; i++)
                {
                    field = "Socket_" + i.ToString();
                    sc =(bool)Commons.Commons.GetValueFromProperty(mmcs, field);
                    if (sc) CloseSockets.Add(i.ToString());
                }
                T_NOISE_TEST_DATA_STATUS data = new T_NOISE_TEST_DATA_STATUS
                {
                    Created_Date = dt,
                    ID=0,
                    Jig_ID=JigID,
                    Created_User="system",
                    Machine_ID=MachineCode,
                    PO_Number=PONumber,
                    Updated_Date=dt,
                    Updated_User="system"
                };
                Random rnd = new Random();
                int err = rnd.Next(1, 6); //sum of error code each jig
                Type type = data.GetType();
                PropertyInfo property = null;
                for (int i = 1; i <= err; i++)
                {
                    int socket = rnd.Next(1, 65);
                    int errnumber = rnd.Next(1, 11);
                    property = type.GetProperty("Socket_"+ socket.ToString());
                    property.SetValue(data, "E" + errnumber.ToString(), null);
                }
                for (int i = 1; i <= 64; i++)
                {
                    property = type.GetProperty("Socket_" + i.ToString());
                    string obj2 = (string)property.GetValue(data, null);
                    if (CloseSockets.IndexOf(i.ToString()) != -1)
                    {
                        property.SetValue(data, "NOD", null);
                    }
                    else
                    {
                        if (String.IsNullOrEmpty(obj2)) property.SetValue(data, "PASS", null);
                    }
                }
                db.T_NOISE_TEST_DATA_STATUSS.Add(data); 
                TrySaveChange(db);
            }
        }
        public void PrepareTestResult(string PONumber, string JigID)
        {
            using (var db = new DBProjectEntities())
            {
                //db.Database.ExecuteSqlCommand("delete from T_SORTER_SUMMARY where po_number = '" + PONumber + "'");
                //db.Database.ExecuteSqlCommand("delete from T_SORTER_RESULT where po_number = '" + PONumber + "'");
                DateTime dt = DateTime.Now;
                //List< SP_TESTING_STATUS> data = db.Database.SqlQuery<SP_TESTING_STATUS>("SP_TESTING_STATUS @PONumber", new SqlParameter("PONumber", PONumber)).ToList();
                string sql = "select distinct jig_id from v_testing_status where po_number ='" + PONumber + "'";
                if (JigID != "") { sql = sql + " and Jig_ID='" + JigID + "'"; }
                var jigs = db.Database.SqlQuery<string>(sql).ToList();
                T_SORTER_SUMMARY ss = new T_SORTER_SUMMARY
                {
                    Created_Date = dt,
                    Created_User = "",
                    ID = 0,
                    PO_Number = PONumber,
                    Jig_ID = JigID,
                    Qty_Downgrade = 0,
                    Qty_NG1 = 0,
                    Qty_NG2 = 0,
                    Qty_NG3 = 0,
                    Qty_NG4 = 0,
                    Qty_NG5 = 0,
                    Qty_NG6 = 0,
                    Qty_NG7 = 0,
                    Qty_NG_Other = 0,
                    Qty_Pass = 0,
                    Qty_Reject = 0
                };
                foreach (var item in jigs)
                {
                    V_TESTING_STATUS noise = db.Database.SqlQuery<V_TESTING_STATUS>("select * from v_testing_status where testtype='Noise' and po_number ='" + PONumber + "' and jig_id='" + item + "'").FirstOrDefault();
                    V_TESTING_STATUS resistance = null;// db.Database.SqlQuery<V_TESTING_STATUS>("select * from v_testing_status where testtype='Resistance' and po_number ='" + PONumber + "' and jig_id='" + item + "'").FirstOrDefault();
                    V_TESTING_STATUS signal = null;//db.Database.SqlQuery<V_TESTING_STATUS>("select * from v_testing_status where testtype='Signal' and po_number ='" + PONumber + "' and jig_id='" + item + "'").FirstOrDefault();
                    T_SORTER_RESULT sr = new T_SORTER_RESULT
                    {
                        Created_Date = dt,
                        Created_User = "",
                        Jig_ID = item,
                        Machine_ID = "",
                        ID = 0,
                        PO_Number = PONumber
                    };
                    string noise_val = "";
                    string resistance_val = "";
                    string signal_val = "";
                    string field = "";
                    for (int i = 1; i <= 64; i++)
                    {
                        field = "Socket_" + i.ToString();
                        if (noise != null) { sr.Machine_ID = noise.Machine_ID; noise_val = (string)Commons.Commons.GetValueFromProperty(noise, field); }
                        if (resistance != null) { sr.Machine_ID = resistance.Machine_ID; resistance_val = (string)Commons.Commons.GetValueFromProperty(resistance, field); }
                        if (signal != null) { sr.Machine_ID = signal.Machine_ID; signal_val = (string)Commons.Commons.GetValueFromProperty(signal, field); }

                        if (noise_val == "" && resistance_val == "" && signal_val == "")
                        {
                            Commons.Commons.SetValueOfProperty(sr, field, "NOD");
                            ss.Qty_NOD++;
                        }
                        else
                        //if (noise_val == "PASS" && resistance_val == "PASS" && signal_val == "PASS")
                        if (noise_val == "PASS")// && resistance_val == "PASS" && signal_val == "PASS")
                        {
                            Commons.Commons.SetValueOfProperty(sr, field, "PASS");
                            ss.Qty_Pass++;
                        }
                        else
                        if (noise_val != "PASS")
                        {
                            Commons.Commons.SetValueOfProperty(sr, field, noise_val);
                            SetErrorSummary(ss, noise_val);
                        }
                        //else
                        //if (resistance_val != "PASS")
                        //{
                        //    Commons.Commons.SetValueOfProperty(sr, field, resistance_val);
                        //    SetErrorSummary(ss, resistance_val);
                        //}
                        //else
                        //if (signal_val != "PASS")
                        //{
                        //    Commons.Commons.SetValueOfProperty(sr, field, signal_val);
                        //    SetErrorSummary(ss, signal_val);
                        //}
                    }

                    db.T_SORTER_RESULTS.Add(sr);
                }
                db.T_SORTER_SUMMARIES.Add(ss);
                //TrySaveChange(db);
                TrySaveChange(db);
            }
        }
        public int GetMaxJigCarrierToBeAvailable()
        {
            int ret = 0;
            /*
             if (MACHINE NOISE 11 ENABLE) ret++;
             .
             .
             .
             if (MACHINE NOISE 18 ENABLE) ret++;    
             if (MACHINE SIGNAL 21 ENABLE) ret++;             
             if (MACHINE SIGNAL 22 ENABLE) ret++;             
             if (MACHINE RESISTANCE 31 ENABLE) ret++;             
             if (MACHINE RESISTANCE 32 ENABLE) ret++;             
            */
            ret = 1;
            return ret + 3;//3 is total jig carrier on rotary2
        }
        public int GetJigCarrierCount()
        {
            int sumonrotary2 = 0;
            int sumonmachine = 0;
            /*
             if (JIG CARRIER ON ROTARY 2-1) sumonrotary2++
             if (JIG CARRIER ON ROTARY 2-2) sumonrotary2++
             if (JIG CARRIER ON ROTARY 2-3) sumonrotary2++
             if (JIG CARRIER ON ROTARY 2-4) sumonrotary2++
            */
            /*
             if (JIG PRESENCE ON MACHINE NOISE 11 && THIS MACHINE ENABLE) ret++;
             .
             .
             .
             if (JIG PRESENCE ON MACHINE NOISE 18 && THIS MACHINE ENABLE) ret++;             
             if (JIG PRESENCE ON MACHINE SIGNAL 21 && THIS MACHINE ENABLE) ret++;             
             if (JIG PRESENCE ON MACHINE SIGNAL 22 && THIS MACHINE ENABLE) ret++;             
             if (JIG PRESENCE ON MACHINE RESISTANCE 31 && THIS MACHINE ENABLE) ret++;             
             if (JIG PRESENCE ON MACHINE RESISTANCE 32 && THIS MACHINE ENABLE) ret++;             
            */
            int ret = sumonrotary2 + (sumonrotary2 == 4 ? sumonmachine - 1 : sumonmachine);
            return ret ;//3 is total jig carrier on rotary2
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
        public M_MACHINE_TESTER GetMachine(string MachineType,int MachineNumber)
        {
            M_MACHINE_TESTER ret = null;
            using (var db = new DBProjectEntities())
            {
                ret = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == MachineType && x.Machine_Number==MachineNumber).FirstOrDefault();
            }
            return ret;
        }
        public M_MACHINE_TESTER GetMachine(int MachineLine, int MachineNumber)
        {
            M_MACHINE_TESTER ret = null;
            using (var db = new DBProjectEntities())
            {
                ret = db.M_MACHINE_TESTERS.Where(x => x.Machine_Line_Number == MachineLine && x.Machine_Number == MachineNumber).FirstOrDefault();
            }
            return ret;
        }
        public M_MACHINE_TESTER GetMachineFromPLCNumber(int Number)
        { 
            int line = 0;
            int num = 0;
            switch (Number)
            {
                case 11:
                case 12:
                case 13:
                case 14:
                    line = 1;
                    num = Number - 10;
                    break;
                case 15:
                case 16:
                case 17:
                case 18:
                    line = 2;
                    num = Number - 10;
                    break;
                case 21:
                    line = 1;
                    num = Number - 20;
                    break;
                case 22:
                    line = 2;
                    num = Number - 20;
                    break;
                case 31:
                    line = 1;
                    num = Number - 30;
                    break;
                case 32:
                    line = 2;
                    num = Number - 30;
                    break;
            }
            return GetMachine(line, num);
        }
        public string GetMachineType(int Index)
        {
            string MachineType = "";
            if (Index == 0) MachineType = "NOISE";
            if (Index == 1) MachineType = "SIGNAL";
            if (Index == 2) MachineType = "RESISTANCE";
            return MachineType;
        }
        public int GetConversionMachineNumber(M_MACHINE_TESTER m)
        {
            int ret = 0;
            switch (m.Machines_Type.ToUpper())
            {
                case "NOISE":
                    ret = 10 + m.Machine_Number;
                    break;
                case "SIGNAL":
                    ret = 20 + m.Machine_Number;
                    break;
                case "RESISTANCE":
                    ret = 30 + m.Machine_Number;
                    break;
            }
            return ret;
        }
        public void JigCarrierToG8(string JigID)
        {
            DateTime dt = DateTime.Now;
            string machinetype = "";
            int machinenumber = 0;
            using (var db = new DBProjectEntities())
            {
                T_BOOKING_STATION tbs = db.T_BOOKING_STATIONS.Where(x => x.Jig_ID == JigID).SingleOrDefault();
                if (tbs == null)
                {
                    tbs = db.Database.SqlQuery<T_BOOKING_STATION>("select * from T_BOOKING_STATION where id = (select min(id) from T_BOOKING_STATION where jig_id='EMPTY')").FirstOrDefault();
                    tbs.Jig_ID = JigID;
                    db.Entry(tbs).CurrentValues.SetValues(tbs);

                    if (tbs.Noise_Room_Number>0) { machinetype = "NOISE";machinenumber = tbs.Noise_Room_Number; }
                    if (tbs.Resistance_Room_Number>0) { machinetype = "RESISTANCE";machinenumber = tbs.Resistance_Room_Number; }
                    if (tbs.Signal_Room_Number>0) { machinetype = "SIGNAL";machinenumber = tbs.Signal_Room_Number; }
                    M_MACHINE_TESTER mmt = GetMachine(machinetype, machinenumber);
                    if (mmt == null) return;
                    T_MACHINE_BOOKING tmb = new T_MACHINE_BOOKING
                    {
                        Booking_ID = tbs.ID,
                        Created_Date = dt,
                        Created_User = JoganUserID,
                        Machine_ID = mmt.Machine_ID,
                        ID=0
                    };
                    db.T_MACHINE_BOOKINGS.Add(tmb);
                    TrySaveChange(db);
                } else
                {

                }
            }
        }
        private bool CheckMachineAvailable(string MachineType,int MachineNumber)
        {
            return true;
        }

        /*
         	                    READY	PRESENCE	RESULT
empty machine	                0	    0	        1
on testing	                    0	    1	        0
not possible for this condition	1	    0	
done testing & jig presence	    1	    1	        1
 
         */
        private bool CheckMachineTestDone(M_MACHINE_TESTER AMachineTester)
        {
            bool ret = false;
            if (OnInfoMachineTester!=null) {
                JoganMachineTester mt = new JoganMachineTester
                {
                    MachineCode = AMachineTester.Machine_ID
                };
                OnInfoMachineTester(this, mt,true);
                ret = mt.IsDoneTesting;// mt.Status == StatusTestingControl.TestDone;
            }
            return ret;
        }
        private bool CheckMachineAvailable(M_MACHINE_TESTER AMachineTester)
        {
            bool ret = false;
            if (OnInfoMachineTester != null)
            {
                JoganMachineTester mt = new JoganMachineTester
                {
                    MachineCode = AMachineTester.Machine_ID
                };
                OnInfoMachineTester(this, mt,true);
                ret = mt.Status == StatusTestingControl.Available;
            }
            return ret;
        } 
        public void CommandG8ToMoveJigFromTo(JoganMachinePosition Source, JoganMachinePosition Destination)
        {
            string source = Source == null ? "ROTARY 2" : GetMachine(Source.MachineType, Source.MachineNumber).Machine_ID;
            string destination = Destination == null ? "ROTARY 2" : GetMachine(Destination.MachineType, Destination.MachineNumber).Machine_ID;
            T_MACHINE_POSITION tmp = (T_MACHINE_POSITION)FTwinCat3Utility.ReadAnyFromPLC("TESTER_C8_VAR.C8_MACHINE_POSITION", TypeOfData.tpObject, typeof(T_MACHINE_POSITION));
            if (Source == null) { tmp.SOURCE_COORDINATE = 0; } else
            {
                tmp.SOURCE_COORDINATE = (byte)(Source.MachineLine*10+Source.MachineNumber);
            }
            if (Destination == null) { tmp.DESTINATION_COORDINATE = 0; } else
            {
                tmp.DESTINATION_COORDINATE = (byte)(Destination.MachineLine * 10 + Destination.MachineNumber);
            }
            FJoganC8Tester.Source = Source;
            FJoganC8Tester.Destination = Destination;
            //send data to plc Source and Destination for G8
            FTwinCat3Utility.WriteAnyToPLC("TESTER_C8_VAR.C8_MACHINE_POSITION", TypeOfData.tpObject, tmp);
            //send data proc here
            CreateMessage( "Moving jig carrier from " + source + " to " + destination, "Robot G8", "Low");
            AllowExecutePLCFunction("C8", true);
            //WaitSynchronous(delegate ()
            //{//wait until G8 finish move jig carrier
            //    return  CheckIfG8OnDuty();
            //});
        }
        private void CommandG8ToMoveJigFromTo(string Source,string Destination)
        {
            //send data to plc Source and Destination for G8
            //send data proc here
            CreateMessage( "Moving jig carrier from " + Source + " to " + Destination,"Robot G8","Low");
            WaitSynchronous(delegate() { return 
                //wait until G8 finish move jig carrier
                true; });
        }
        private void PrepareGotoNextMachine(int StartIndex,int[] MachineSequences)
        {
            if (FIsExitRecursive) return; 
            int index = -1;
            string machinetype = "";
            int machinenum = 0;
            M_MACHINE_TESTER m1 = null;
            M_MACHINE_TESTER m2 = null;
            using (var db = new DBProjectEntities())
            {
                machinetype = GetMachineType(StartIndex);
                machinenum = MachineSequences[StartIndex];
                m1 = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == machinetype && x.Machine_Number == machinenum).FirstOrDefault();
                switch (StartIndex)
                {
                    //noise machine
                    case 0:
                        if (!CheckMachineTestDone(m1)) { FIsExitRecursive = true; return; } else
                        {
                            if (MachineSequences[1] < 1 && MachineSequences[2] < 1)
                            {
                                FIsExitRecursive = true;
                                //CommandG8ToMoveJigFromTo(m1.Machine_ID, "ROTARY2"); //just test noise
                                CommandG8ToMoveJigFromTo(new JoganMachinePosition { MachineType = m1.Machines_Type, MachineLine = m1.Machine_Line_Number, MachineNumber = m1.Machine_Number }, null); //just test noise
                            } else
                            {
                                index = 1;
                                if (index < 1) index = 2;
                                machinetype = GetMachineType(index);
                                machinenum = MachineSequences[index];
                                m2 = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == machinetype && x.Machine_Number == machinenum).FirstOrDefault();
                                if (!CheckMachineTestDone(m2)) { FIsExitRecursive = true; return; }
                                else
                                {
                                    if (CheckMachineAvailable(m2))
                                    {
                                        FIsExitRecursive = true;
                                        AddBookingMachine(m2, false);
                                        //CommandG8ToMoveJigFromTo(m1.Machine_ID, m2.Machine_ID); //just test noise
                                        CommandG8ToMoveJigFromTo(
                                            new JoganMachinePosition { MachineType = m1.Machines_Type, MachineLine = m1.Machine_Line_Number, MachineNumber = m1.Machine_Number },
                                            new JoganMachinePosition { MachineType = m2.Machines_Type, MachineLine = m2.Machine_Line_Number, MachineNumber = m2.Machine_Number }); //just test noise
                                    } else
                                    {
                                        PrepareGotoNextMachine(index, MachineSequences);
                                    }
                                }
                            }
                        }
                        break;
                    //signal machine
                    case 1:
                        if (!CheckMachineTestDone(m1)) { FIsExitRecursive = true; return; }
                        else
                        {
                            if (MachineSequences[2] < 1 )
                            {
                                FIsExitRecursive = true;
                                //CommandG8ToMoveJigFromTo(m1.Machine_ID, "ROTARY2"); //just test noise && signal
                                CommandG8ToMoveJigFromTo(new JoganMachinePosition { MachineType = m1.Machines_Type, MachineLine = m1.Machine_Line_Number, MachineNumber = m1.Machine_Number }, null); //just test noise
                            }
                            else
                            {
                                index = 2;
                                machinetype = GetMachineType(index);
                                machinenum = MachineSequences[index];  
                                m2 = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == machinetype && x.Machine_Number == machinenum).FirstOrDefault();
                                if (!CheckMachineTestDone(m2)) { FIsExitRecursive = true; return; }
                                else
                                {
                                    if (CheckMachineAvailable(m2))
                                    {
                                        FIsExitRecursive = true;
                                        AddBookingMachine(m2, false);
                                        //CommandG8ToMoveJigFromTo(m1.Machine_ID, m2.Machine_ID); //just test noise
                                        CommandG8ToMoveJigFromTo(
                                            new JoganMachinePosition { MachineType = m1.Machines_Type, MachineLine = m1.Machine_Line_Number, MachineNumber = m1.Machine_Number },
                                            new JoganMachinePosition { MachineType = m2.Machines_Type, MachineLine = m2.Machine_Line_Number, MachineNumber = m2.Machine_Number }); //just test noise
                                    }
                                    else
                                    {
                                        PrepareGotoNextMachine(index, MachineSequences);
                                    }
                                }
                            }
                        }
                        break;
                    //resistance machine
                    case 2:
                        if (!CheckMachineTestDone(m1))
                        {
                            FIsExitRecursive = true;
                            //CommandG8ToMoveJigFromTo(m1.Machine_ID, "ROTARY2"); //just test noise
                            CommandG8ToMoveJigFromTo(new JoganMachinePosition { MachineType = m1.Machines_Type, MachineLine = m1.Machine_Line_Number, MachineNumber = m1.Machine_Number }, null); //just test noise
                        }
                        break;
                } 
            }
        }
        private void AddBookingMachine(M_MACHINE_TESTER AMachine,bool IsFromRotary)
        {
            using (var db = new DBProjectEntities())
            {
                DateTime dt = DateTime.Now;
                T_BOOKING_STATION tbs = null;
                T_MACHINE_BOOKING tmb = new T_MACHINE_BOOKING
                {
                    Booking_ID = 0,
                    Created_Date = dt,
                    Created_User = JoganUserID,
                    Machine_ID=AMachine.Machine_ID,
                    Updated_Date=dt,
                    Updated_User=JoganUserID,
                    ID=0
                };
                if (IsFromRotary)
                {
                    tbs = db.Database.SqlQuery<T_BOOKING_STATION>("select * from T_BOOKING_STATION where ID= (select min(id) from T_BOOKING_STATION where jig_id='EMPTY' and Status='LoadingJigCarrier')").FirstOrDefault();
                    tmb.Booking_ID = tbs.ID;
                }
                else
                {
                    T_MACHINE_BOOKING tmb2 = db.Database.SqlQuery<T_MACHINE_BOOKING>("select * from T_MACHINE_BOOKING where ID= (select max(id) from T_MACHINE_BOOKING where Machine_ID='" + AMachine.Machine_ID + "')").FirstOrDefault();
                    //tbs = db.T_BOOKING_STATIONS.Where(x => x.ID == tmb2.Booking_ID).FirstOrDefault();
                    tmb.Booking_ID = tmb2.Booking_ID;
                }
                db.T_MACHINE_BOOKINGS.Add(tmb);
                TrySaveChange(db);
            }
        }
        public void StartMachineTester(string MachineType, int MachineNumber, int DelayTime = 0)//DelayTime in second
        {
            M_MACHINE_TESTER m = GetMachine(MachineType, MachineNumber);
            StartMachineTester(m, DelayTime);
        } 
        public void StartMachineTester(string MachineCode, int DelayTime = 0)//DelayTime in second
        {
            M_MACHINE_TESTER m = GetMachine(MachineCode);
            StartMachineTester(m, DelayTime);
        }
        private JoganMachineTester InitMachineTesterInfo(M_MACHINE_TESTER AMachine)
        {
            return new JoganMachineTester
            {
                MachineCode = AMachine.Machine_ID,
                MachineName = AMachine.Machine_Name,
                
            };
        }
        public void StartMachineTester(M_MACHINE_TESTER AMachine, int DelayTime = 0)//DelayTime in second
        { 
            JoganMachineTester mt = new JoganMachineTester
            {
                MachineCode = AMachine.Machine_ID
            };
            if (OnInfoMachineTester != null) OnInfoMachineTester(this, mt, true); //get machine info
            int interval = 5;
            string jigid = "";
            using (var db = new DBProjectEntities())
            {
                //proccess info machine
                //M_MACHINE_TESTER m = GetMachine(mt.MachineCode);
                //T_MACHINE_BOOKING tmb2 = db.Database.SqlQuery<T_MACHINE_BOOKING>("select * from T_MACHINE_BOOKING where ID= (select max(id) from T_MACHINE_BOOKING where Machine_ID='" + AMachine.Machine_ID + "')").FirstOrDefault();
                T_TRANSACTION_INPUT tti = GetTransactionInputInMachine(AMachine, out jigid);
                if (tti != null)
                {
                    if (AMachine.Machines_Type == "NOISE")
                    {
                        V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER mndp = db.Database.SqlQuery<V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER>("select * from V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER where Device_ID = '" + tti.Device_ID + "'").FirstOrDefault();//.V_NOISE_DEVICE_NOISE_DEVICE_PARAMETERS.Where(x => x.Device_ID == tti.Device_ID).FirstOrDefault();
                        interval = mndp.Soak_Time + mndp.Measurement_Duration;
                    }
                    else
                    {
                        M_SIGNAL_DEVICE_PARAMETER msdp = db.M_SIGNAL_DEVICE_PARAMETERS.Where(x => x.Device_ID == tti.Device_ID).FirstOrDefault();
                        interval = msdp.Measurement_Duration + msdp.First_Soak_Time + msdp.Second_Soak_Time; //msdp.Measurement_Duration_2 + 
                    }
                }
            }
            if (DelayTime != 0)
            {
                int tm = 0;
                WaitSynchronous(delegate () { tm++; return tm <= DelayTime; });
            }
            mt.JigID = jigid;
            mt.MachineCode = AMachine.Machine_ID;
            mt.Interval = interval;
            
            T_BOOKING_STATION tbs = null;
            using (var db = new DBProjectEntities())
            {
                T_MACHINE_BOOKING tmb = db.Database.SqlQuery<T_MACHINE_BOOKING>("select * from T_MACHINE_BOOKING where id = (select max(id) from T_MACHINE_BOOKING where Machine_ID='"+ AMachine .Machine_ID+ "')").FirstOrDefault();
                if (tmb!=null) tbs = db.T_BOOKING_STATIONS.Where(x => x.ID == tmb.Booking_ID).FirstOrDefault();
            }
            bool starttest = false;
            switch (AMachine.Machines_Type)
            {
                case "NOISE":
                    starttest = tbs == null ? true : !tbs.ByPassTestNoise; mt.IsByPassTest = tbs.ByPassTestNoise;
                    break;
                case "SIGNAL":
                    starttest = tbs == null ? true : !tbs.ByPassTestSignal; mt.IsByPassTest = tbs.ByPassTestSignal;
                    break;
                case "RESISTANCE":
                    starttest = tbs == null ? true : !tbs.ByPassTestResistance; mt.IsByPassTest = tbs.ByPassTestResistance;
                    break;
            }
            string varname = "LOADER_VAR.O_TESTER_START_" + GetConversionMachineNumber(AMachine).ToString();
            //send command to plc to start testing
            FTwinCat3Utility.WriteAnyToPLC(varname, TypeOfData.tpBool, starttest);
            //FTwinCat3Utility.WriteAnyToPLC(varname, TypeOfData.tpBool, false);
            
            if (OnBeforeStartMachineTester != null) OnBeforeStartMachineTester(this, mt);
            if (OnAfterStartMachineTester != null) OnAfterStartMachineTester(this, mt); 
        }
        public void StopMachineTester(M_MACHINE_TESTER AMachine)
        {
            JoganMachineTester mt = new JoganMachineTester
            {
                MachineCode = AMachine.Machine_ID
            };
            if (OnInfoMachineTester != null) OnInfoMachineTester(this, mt, false); //get machine info
            mt.MachineCode = AMachine.Machine_ID;
            if (OnBeforeStopMachineTester != null) OnBeforeStopMachineTester(this, mt);  

            //send command to plc to stop testing
            //FTwinCat3Utility.WriteAnyToPLC("", TypeOfData.tpBool, true);
            if (OnAfterStopMachineTester != null) OnAfterStopMachineTester(this, mt);
        }
        public void ClearMachineTester(string MachineCode)
        {
            M_MACHINE_TESTER m = GetMachine(MachineCode);
            JoganMachineTester mt = new JoganMachineTester
            {
                MachineCode = m.Machine_ID
            };
            if (OnInfoMachineTester != null) OnInfoMachineTester(this, mt, false); //get machine info
        }
        public void StopMachineTester(string MachineCode)
        {
            M_MACHINE_TESTER m = GetMachine(MachineCode);
            StopMachineTester(m);
        }
        public T_TRANSACTION_INPUT GetTransactionInputInMachine(string MachineCode, out string JigId)
        {
            M_MACHINE_TESTER m = GetMachine(MachineCode);
            return GetTransactionInputInMachine(m,out JigId);
        }
        public T_TRANSACTION_INPUT GetTransactionInputInMachine(M_MACHINE_TESTER AMachine, out string JigID)
        {
            JigID = "";
               T_TRANSACTION_INPUT ret = null;
            using (var db = new DBProjectEntities())
            {
                T_MACHINE_BOOKING tmb2 = db.Database.SqlQuery<T_MACHINE_BOOKING>("select * from T_MACHINE_BOOKING where ID= (select max(id) from T_MACHINE_BOOKING where Machine_ID='" + AMachine.Machine_ID + "')").FirstOrDefault();
                if (tmb2 != null)
                {
                    T_BOOKING_STATION tbs = db.T_BOOKING_STATIONS.Where(x => x.ID == tmb2.Booking_ID).FirstOrDefault();
                    JigID = tbs.Jig_ID;
                    ret = db.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == tbs.PO_Number).FirstOrDefault();
                }
            }
            return ret;
        }
        private bool CheckIfMachineDestinationAvailable(out M_MACHINE_TESTER MachineAvailable)
        {
            MachineAvailable = null;
            bool ret = false;
            using (var db = new DBProjectEntities())
            {
                T_BOOKING_STATION tbs = db.Database.SqlQuery<T_BOOKING_STATION>("select * from T_BOOKING_STATION where ID= (select min(id) from T_BOOKING_STATION where jig_id='EMPTY' and Status='LoadingJigCarrier')").FirstOrDefault();
                if (tbs != null)
                {
                    FIsExitRecursive = false;
                    M_MACHINE_TESTER m = null;
                    int noisenumber = tbs.Noise_Room_Number;
                    int signalnumber = tbs.Signal_Room_Number;
                    int resistancenumber = tbs.Resistance_Room_Number;
                    if (noisenumber > 0)
                    {
                        m = GetMachine("NOISE", noisenumber);
                    }
                    else if (noisenumber == -1)  //-1 mean on form, noise test was not checked and machine on
                    {
                        //get noise machine available from line
                    }
                    FMachineSequences[0] = noisenumber;
                    if (signalnumber == -1)
                    {
                        //signalnumber = 1;
                        //if Signal Machine 1 off then use signalnumber = 2;
                        //if Signal Machine 2 off then use signalnumber = 1;
                    }
                    FMachineSequences[1] = signalnumber;
                    if (resistancenumber == -1)
                    {
                        //resistancenumber = 1;
                        //if Resistance Machine 1 off then use resistancenumber = 2;
                        //if Resistance Machine 2 off then use resistancenumber = 1;
                    }
                    FMachineSequences[2] = resistancenumber;

                    if (m != null)
                    {
                        //from rotary 2
                        if (CheckMachineTestDone(m))
                        {
                            ret = CheckMachineAvailable(m);
                            if (!ret) {
                                FIsExitRecursive = false; PrepareGotoNextMachine(0, FMachineSequences);
                            } else
                            {
                                AddBookingMachine(m, true);
                                MachineAvailable = m;
                            }
                            //if (CheckMachineAvailable(m))
                            //{
                            //    CommandG8ToMoveJigFromTo("ROTARY2", m.Machine_ID);
                            //}
                            //else
                            //{
                            //    PrepareGotoNextMachine(0, FMachineSequences);
                            //}
                        }
                    }
                }
            }
            return ret;
        }
        private bool CheckIfG8OnDuty()
        {
            //return false;
            return (bool)FTwinCat3Utility.ReadAnyFromPLC("TESTER_C8_VAR.C8_ONDUTY", TypeOfData.tpBool);
        }
        private  void ThreadForMachineTester()
        {
            while (true) //(FListFukudaNotification.Count > 0)
            {
                if (FEndProccess || FThreads[StartThreadFor.MachineTester].IsStop) break;
                //if (FPauseProccess) Wait(delegate () { return FPauseProccess; });
                if (FThreads[StartThreadFor.MachineTester].IsPaused) goto Skip;
                WaitAsynchronous(FThreads[StartThreadFor.MachineTester], delegate () { return FPauseProccess; });
                if (FThreads[StartThreadFor.MachineTester].IsPaused) goto Skip; 
                if (FListMachineTesterNotification.Count != 0)
                {
                    //int fflag = 0;
                    //string varname = "";
                    string notif = FListMachineTesterNotification[0];
                    if (OnJoganThreadWorking != null) OnJoganThreadWorking(FThreads[StartThreadFor.MachineTester].CurrentThread, notif);
                    switch (notif)
                    {
                        case "TESTER_C8_VAR.I_C8_READY_SCAN":
                            //Pause(true);
                            //Scan2DCode(FJoganC8Tester.Source == null || FJoganC8Tester.Destination == null, out FTempTransactionInputNearLaser);
                            Scan2DCode(true, out FTempTransactionInputNearLaser);
                            //Pause(false);
                            break; 
                        //case "TESTER_C8_VAR.I_C8_JIG_PRESENCE":
                        case "LOADER_VAR.I_TESTER_JIG_PRESENCE_11":
                            bool val = (bool)FTwinCat3Utility.ReadAnyFromPLC(notif, TypeOfData.tpBool);
                            //Pause(true);
                            if (val) { StartMachineTester("NT-001",30); } else { StopMachineTester("NT-001"); }
                            //Pause(false);
                            break;
                    }
                    FListMachineTesterNotification.RemoveAt(0);
                }
                Skip:
                 Task.Delay(WAIT_THREAD_TIME);
            }
        }
        #endregion
        #region Laser
        public void SendBackAllLaserTransport()
        {
            if (LaserTransfer1.Flag == 2 || LaserTransfer1.Flag == 3)
            {
                FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_TRANSFER_A_PICK_DONE", TypeOfData.tpBool, true);
                WaitSynchronous(
                    delegate () { return (LaserTransfer1.Flag == 2 || LaserTransfer1.Flag == 3); },
                    delegate () { FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_A", TypeOfData.tpBool, true); }
                    );
            }
            if (LaserTransfer2.Flag == 2 || LaserTransfer2.Flag == 3)
            {
                FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_TRANSFER_B_PICK_DONE", TypeOfData.tpBool, true);
                WaitSynchronous(
                    delegate () { return (LaserTransfer2.Flag == 2 || LaserTransfer2.Flag == 3); },
                    delegate () { FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_B", TypeOfData.tpBool, true); }
                    );
            }
            if (LaserTransferNG.Flag == 2 || LaserTransferNG.Flag == 3)
            {
                FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_TRANSFER_C_PICK_DONE", TypeOfData.tpBool, true);
                WaitSynchronous(
                    delegate () { return (LaserTransferNG.Flag == 2 || LaserTransferNG.Flag == 3); },
                    delegate () { FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_NG", TypeOfData.tpBool, true); }
                    );
            }
            //if (LaserTransfer1.Flag == 2 || LaserTransfer1.Flag == 3) { FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_A", TypeOfData.tpBool, true); }
            //if (LaserTransfer2.Flag== 2 || LaserTransfer2.Flag == 3) { FTwinCat3UtilitSORTER_VAR.I_CURRENT_TRANSACTIONy.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_B", TypeOfData.tpBool, true); }
            //if (LaserTransferNG.Flag== 2 || LaserTransferNG.Flag == 3) { FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_NG", TypeOfData.tpBool, true); }
        }
        public void PrepareLoadingJigLaser(LaserTransfer ALaserTransfer, bool NewStation)
        {
            if (!FAllowConnect) return;
            //FThreads[StartThreadFor.LASER].IsPaused = true;
            int fflag1 = -1;
            int fflag2 = -1;
            int fflag3 = -1;
            T_CURRENT_TRANSACTION ct = null;
            ct = (T_CURRENT_TRANSACTION)FTwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, typeof(T_CURRENT_TRANSACTION));
            //FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
            string varname = "";
            if (ALaserTransfer == null)
            {
                if ((LaserTransfer1.Flag == 0 || LaserTransfer1.Flag == 4 || LaserTransfer1.Flag == 5) ||
                    (LaserTransfer2.Flag == 0 || LaserTransfer2.Flag == 4 || LaserTransfer2.Flag == 5))
                {
                    if (NewStation)
                    {
                        FMessageIsSend = false; FIsLotEndLaser = false;
                        FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LOTEND", TypeOfData.tpBool, false);
                        if (FTransactionInputNearLaser != null)
                        {
                            Commons.Commons.CopyProperties(FTransactionInputNearLaser, FOldUnloadingStation.TransactionInput);
                        }
                        using (var db = new DBProjectEntities())
                        {
                            if (FTransactionInputNearLaser == null) goto Skip;
                            FTransactionInputNearLaser.Status = "Loading";
                            FTransactionInputNearLaser.Updated_Date = DateTime.Now;
                            T_TRANSACTION_INPUT tti = db.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == FTransactionInputNearLaser.PO_Number).FirstOrDefault();
                            Commons.Commons.CopyProperties(FTransactionInputNearLaser, tti);
                            db.Entry(tti).CurrentValues.SetValues(tti);
                            TrySaveChange(db);
                            tti = null;
                            T_JIG_SOCKET tjs = (T_JIG_SOCKET)FTwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_LASER_SOCKET", TypeOfData.tpObject, typeof(T_JIG_SOCKET));
                            tjs.STATION_NUMBER = (byte)FTransactionInputNearLaser.LotBox_Position_Laser;
                            tjs.PO_NUMBER = FTransactionInputNearLaser.PO_Number;
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_SOCKET", TypeOfData.tpObject,tjs );

                            ct.PO_NUMBER = FTransactionInputNearLaser.PO_Number;
                            ct.QUANTITY_MAX = (byte)FTransactionInputNearLaser.Quantity;
                            ct.STATION_NUMBER_LOAD = (byte)FTransactionInputNearLaser.LotBox_Position_Laser;// (byte)FTransactionInput.LotBox_Position_LASER;
                            ct.JIG_INDEX_LOAD = 0;
                            ct.JIG_INDEX_RETURN = 0;
                            ct.JIG_INDEX_LOAD_NG = (byte)FTransactionInputNearLaser.LotBox_Position_Laser;
                            ct.JIG_INDEX_RETURN_NG = (byte)FTransactionInputNearLaser.LotBox_Position_Laser;
                            ct.TRANSPORT_INDEX = 0;

                            Commons.Commons.CopyProperties(FTransactionInputNearLaser, FLoadingStation.TransactionInput);
                            //FLoadingStation.TransactionInput = FTransactionInputNearLaser;

                            if (OnNewMessage != null) OnNewMessage(this, new V_MESSAGE
                            {
                                Message_Code = "",
                                Message_Name = "Lotbox on Laser Station ",// + FTransactionInput.LotBox_Position_LASER.ToString() + " now unloading",
                                Hardware_ID = "Laser Station ",// + FTransactionInput.LotBox_Position_LASER.ToString(),
                                Impact = "Low",
                            });
                            //FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, FCurrentTransaction);
                        }
                        fflag3 = GetLaserFlag(LaserTransferNG);
                        if (fflag3 == 0 || fflag3 == 4 || fflag3 == 5)
                        {
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_NG", TypeOfData.tpBool, true);
                            ct.JIG_INDEX_LOAD_NG = (byte)FTransactionInputNearLaser.LotBox_Position_Laser;
                            LaserTransferNG.DoneTransport = false;
                            ct.TRANSPORT_INDEX = 3;
                            LaserTransferNG.StationNumber = 5;// ct.STATION_NUMBER_LOAD;
                            LaserTransferNG.JigIndex = ct.JIG_INDEX_LOAD_NG;
                            varname = "SORTER_VAR.I_LOADING_DONE_NG";
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
                            AllowExecutePLCFunction("LOAD_NG", true);
                            WaitSynchronous(delegate () { return !(bool)FTwinCat3Utility.ReadAnyFromPLC(varname, TypeOfData.tpBool); });
                        }

                        PrepareListTestResult();
                    }

                    Skip:
                    SP_LASER_STATION ls1 = null;
                    //check if there is lotbox on laser station
                    using (var db = new DBProjectEntities())
                    {
                        ls1 = db.Database.SqlQuery<SP_LASER_STATION>("SP_LASER_STATION @ISDownGrade", new SqlParameter("ISDownGrade", false)).FirstOrDefault();
                    } 
                    if (ls1 == null)
                    {
                        fflag1 = GetLaserFlag(LaserTransfer1);
                        fflag2 = GetLaserFlag(LaserTransfer2);
                        fflag3 = GetLaserFlag(LaserTransferNG);
                        if (fflag1 == 0 || fflag1 == 4 || fflag1 == 5)
                        {
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_A", TypeOfData.tpBool, false);
                        }
                        else
                        if (fflag2 == 0 || fflag2 == 4 || fflag2 == 5)
                        {
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_B", TypeOfData.tpBool, false);
                        }
                        else
                        if (fflag3 == 0 || fflag3 == 4 || fflag3 == 5)
                        {
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_NG", TypeOfData.tpBool, false);
                        }

                    }
                    //if (!FIsLotEndLaser && FTransactionInputNearLaser != null)
                    if (ct.JIG_INDEX_LOAD<8 && FTransactionInputNearLaser != null)
                    {
                        ct.JIG_INDEX_LOAD++;
                        fflag1 = GetLaserFlag(LaserTransfer1);
                        fflag2 = GetLaserFlag(LaserTransfer2);
                        if (fflag1 == 0 || fflag1 == 4 || fflag1 == 5)
                        {
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_A", TypeOfData.tpBool, true);
                            FLaserTransfer1.LotEndOnMe = ct.JIG_INDEX_LOAD == 8;
                            LaserTransfer1.DoneTransport = false;
                            ct.TRANSPORT_INDEX = 1;
                            LaserTransfer1.StationNumber = ct.STATION_NUMBER_LOAD;
                            LaserTransfer1.JigIndex = ct.JIG_INDEX_LOAD;
                            varname = "SORTER_VAR.I_LOADING_DONE_A";
                        }
                        else
                        if (fflag2 == 0 || fflag2 == 4 || fflag2 == 5)
                        {
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_B", TypeOfData.tpBool, true);
                            FLaserTransfer2.LotEndOnMe = ct.JIG_INDEX_LOAD == 8;
                            LaserTransfer2.DoneTransport = false;
                            ct.TRANSPORT_INDEX = 2;
                            LaserTransfer2.StationNumber = ct.STATION_NUMBER_LOAD;
                            LaserTransfer2.JigIndex = ct.JIG_INDEX_LOAD;
                            varname = "SORTER_VAR.I_LOADING_DONE_B";
                        }
                        FLoadingStation.SorterSummary = null;
                        if (OnLoadingStation != null) OnLoadingStation(this, StatusTestingControl.Loading, FLoadingStation);

                        FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
                        AllowExecutePLCFunction("LOAD_LASER", true);
                        WaitSynchronous(
                            delegate () { return !(bool)FTwinCat3Utility.ReadAnyFromPLC(varname, TypeOfData.tpBool); },
                            delegate ()
                            {
                                if (ct.JIG_INDEX_LOAD == 8)
                                {
                                    V_MESSAGE v =
                                    new V_MESSAGE
                                    {
                                        Message_Code = "",
                                        Message_Name = "Lotbox on Station ",// + FUnloadingStation.TransactionInput.LotBox_Position_LASER.ToString() + " finishing unloading. Please wait until last jig return",
                                        Hardware_ID = "Station ",// + FUnloadingStation.TransactionInput.LotBox_Position_LASER.ToString(),
                                        Impact = "Low",
                                    };
                                    if (OnNewMessage != null) OnNewMessage(this, v);
                                    FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LOTEND", TypeOfData.tpBool, true);
                                }
                            });
                    }
                }
            }
            else
            {
                ct.JIG_INDEX_RETURN = (byte)ALaserTransfer.JigIndex;
                ct.TRANSPORT_INDEX = (byte)ALaserTransfer.ID;
                ct.STATION_NUMBER_RETURN = (byte)ALaserTransfer.StationNumber;
                string varname2 = "";
                //reset flag
                switch (ALaserTransfer.ID)
                {
                    case 1:
                        FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_A", TypeOfData.tpBool, true);
                        FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_TRANSFER_A_PICK_DONE", TypeOfData.tpBool, false);
                        varname = "SORTER_VAR.I_RETURN_DONE_A";
                        varname2 = "RETURN_LASER";
                        break;
                    case 2:
                        FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_B", TypeOfData.tpBool, true);
                        FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_TRANSFER_B_PICK_DONE", TypeOfData.tpBool, false);
                        varname = "SORTER_VAR.I_RETURN_DONE_B";
                        varname2 = "RETURN_LASER";
                        break;
                    case 3:
                        FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_NG", TypeOfData.tpBool, true);
                        FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_TRANSFER_C_PICK_DONE", TypeOfData.tpBool, false);
                        varname = "SORTER_VAR.I_RETURN_DONE_NG"; 
                        ct.JIG_INDEX_RETURN_NG = (byte)ALaserTransfer.JigIndex;
                        varname2 = "RETURN_NG";
                        break;
                }
                FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_CURRENT_TRANSACTION", TypeOfData.tpObject, ct);
                AllowExecutePLCFunction(varname2, true);
                WaitAsynchronous(FThreads[StartThreadFor.Laser],
                    delegate () { return !(bool)FTwinCat3Utility.ReadAnyFromPLC(varname, TypeOfData.tpBool); });
            }
        }
        private  void ThreadForLaser()
        {
            while (true) //(FListFukudaNotification.Count > 0)
            {
                //if (FEndProccess || FThreads[StartThreadFor.Laser].IsStop) break;
                //if (FPauseProccess) Wait(delegate () { return FPauseProccess; });
                //if (FThreads[StartThreadFor.Laser].IsPaused) goto Skip;
                WaitAsynchronous(FThreads[StartThreadFor.Laser], delegate () { return FPauseProccess; });
                if (FThreads[StartThreadFor.Laser].IsPaused) goto Skip;
                if (FListLaserNotification.Count != 0)
                {
                    int fflag = 0;
                    string varname = "";
                    string notif = FListLaserNotification[0];
                    if (OnJoganThreadWorking != null) OnJoganThreadWorking(FThreads[StartThreadFor.Laser].CurrentThread, notif);
                    switch (notif)
                    {
                        case "SORTER_RS4_VAR.I_SORTER_RS4_ENABLE":
                            FI_SORTER_RS4_ENABLE = true;
                            PrepareListTestResult();
                            break;
                        case "SORTER_RS4_VAR.I_SORTER_RS4_START_PLACING":
                            if (!FI_SORTER_RS4_ENABLE) PrepareListTestResult(); else FI_SORTER_RS4_ENABLE = false;
                            break;
                        case "SORTER_RS4_VAR.I_SORTER_RS4_START_TAKEUP":
                            // case "SORTER_RS4_VAR.I_SORTER_RS4_READY_TAKEUP":
                            //WaitSynchronous(delegate ()
                            //{
                            //    return (bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_RS4_VAR.I_SORTER_RS4_START_PLACING", TypeOfData.tpBool);
                            //},
                            //delegate () {
                            //    //FTwinCat3Utility.WriteAnyToPLC("SORTER_RS4_VAR.I_SORTER_RS4_ENABLE", TypeOfData.tpBool, true);
                            //    //FTwinCat3Utility.WriteAnyToPLC("SORTER_RS4_VAR.O_SORTER_RS4_CONTINUE", TypeOfData.tpBool, true);
                            //    PrepareListTestResult();
                            //}
                            //);
                           
                            break;
                        //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_A":
                        //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_A":
                        case "SORTER_VAR.I_LASER_TRANSFER_A_PICK_DONE":
                            fflag = GetLaserFlag(LaserTransfer2);
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_TRANSFER_A_PICKING", TypeOfData.tpByte, (byte)2);// fflag == 2 ? (byte)2 : (byte)0);
                            varname = "SORTER_VAR.I_LASER_ONDUTY_B";// done ? "INPUT_VAR.I_RETURN_DONE_B" : "INPUT_VAR.I_LOADING_DONE_B";
                            WaitAsynchronous(
                                delegate () { return (bool)FTwinCat3Utility.ReadAnyFromPLC(varname, TypeOfData.tpBool); },
                                delegate ()
                                {
                                    LaserTransfer1.SetFlag(
                                        (bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_LASER_TRANSFER_AT_BACK_A", TypeOfData.tpBool),
                                        (bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_LASER_TRANSFER_AT_FRONT_A", TypeOfData.tpBool),
                                        (bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_LASER_TRANSFER_A_PICK_DONE", TypeOfData.tpBool)
                                        );
                                });
                            break;
                        //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_FRONT_B":
                        //case "INPUT_VAR.I_FUKUDA_TRANSFER_AT_BACK_B":
                        case "SORTER_VAR.I_LASER_TRANSFER_B_PICK_DONE":
                            fflag = GetLaserFlag(LaserTransfer1);
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_TRANSFER_A_PICKING", TypeOfData.tpByte, (byte)1);// fflag == 2 ? (byte)1 : (byte)0);
                            varname = "SORTER_VAR.I_LASER_ONDUTY_A";//done ? "INPUT_VAR.I_RETURN_DONE_A" : "INPUT_VAR.I_LOADING_DONE_A";
                            WaitAsynchronous(
                                delegate () { return (bool)FTwinCat3Utility.ReadAnyFromPLC(varname, TypeOfData.tpBool); },
                                delegate ()
                                {
                                    LaserTransfer2.SetFlag(
                               (bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_LASER_TRANSFER_AT_BACK_B", TypeOfData.tpBool),
                               (bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_LASER_TRANSFER_AT_FRONT_B", TypeOfData.tpBool),
                               (bool)FTwinCat3Utility.ReadAnyFromPLC("SORTER_VAR.I_LASER_TRANSFER_B_PICK_DONE", TypeOfData.tpBool)
                               );
                                });

                            break;
                        case "SORTER_VAR.I_LOADING_DONE_A":
                            //WriteAnyToPLC("SORTER_RS4_VAR.I_SORTER_RS4_ENABLE", TypeOfData.tpBool, true);
                            WriteAnyToPLC("SORTER_RS4_VAR.O_SORTER_RS4_CONTINUE", TypeOfData.tpBool, true);
                            WriteAnyToPLC("SORTER_VAR.I_LASER_TRANSFER_A_PICKING", TypeOfData.tpByte, (byte)1);
                            WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_A", TypeOfData.tpBool, false);
                            WriteAnyToPLC("SORTER_VAR.I_RETURN_DONE_A", TypeOfData.tpBool, false);
                            fflag = GetLaserFlag(LaserTransfer2);
                            if (fflag == 0 || fflag == 4 || fflag == 5) PrepareLoadingJigLaser(null, false);
                            break;
                        case "SORTER_VAR.I_RETURN_DONE_A":
                            FukudaTransfer1.DoneTransport = true;
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LOADING_DONE_A", TypeOfData.tpBool, false);
                            if (FFukudaTransfer1.LotEndOnMe)
                            {
                                FIsLotEndFukudaReturnDone = true;
                                //FOldLoadingStation.CurrentTransaction = new T_CURRENT_TRANSACTION { JIG_INDEX_LOAD = 10 };
                                if (OnLoadingStation != null) OnLoadingStation(this, StatusTestingControl.Finish, FOldLoadingStation);
                            }
                            PrepareLoadingJigLaser(null, false);
                            break;
                        case "SORTER_VAR.I_LOADING_DONE_B":
                            //WriteAnyToPLC("SORTER_RS4_VAR.I_SORTER_RS4_ENABLE", TypeOfData.tpBool, true);
                            WriteAnyToPLC("SORTER_RS4_VAR.O_SORTER_RS4_CONTINUE", TypeOfData.tpBool, true);
                            WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_B", TypeOfData.tpBool, false);
                            WriteAnyToPLC("SORTER_VAR.I_RETURN_DONE_B", TypeOfData.tpBool, false);
                            fflag = GetLaserFlag(LaserTransfer1);
                            if (fflag == 4 || fflag == 5) PrepareLoadingJigLaser(null, false);
                            break;
                        case "SORTER_VAR.I_RETURN_DONE_B":
                            LaserTransfer2.DoneTransport = true;
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LOADING_DONE_B", TypeOfData.tpBool, false);
                            if (FFukudaTransfer2.LotEndOnMe)
                            {
                                FIsLotEndFukudaReturnDone = true;
                                //FOldUnloadingStation.CurrentTransaction = new T_CURRENT_TRANSACTION { JIG_INDEX_LOAD = 10 };
                                if (OnLoadingStation != null) OnLoadingStation(this, StatusTestingControl.Finish, FOldLoadingStation);
                            }
                            PrepareLoadingJigLaser(null, false);
                            break;
                        case "SORTER_VAR.I_LOADING_DONE_NG": 
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LASER_ONDUTY_NG", TypeOfData.tpBool, false);
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_RETURN_DONE_NG", TypeOfData.tpBool, false); 
                            break;
                        case "SORTER_VAR.I_RETURN_DONE_NG":
                            LaserTransfer1.DoneTransport = true;
                            FTwinCat3Utility.WriteAnyToPLC("SORTER_VAR.I_LOADING_DONE_NG", TypeOfData.tpBool, false); 
                            break;
                    }
                    FListLaserNotification.RemoveAt(0);
                }
                Skip:
                 Task.Delay(WAIT_THREAD_TIME);
            }
        }
        #endregion
    }
}


//TYPE TSimpleStruct :
//STRUCT
//        lrealVal: LREAL := 1.23;
//        dintVal1: DINT := 120000;
//END_STRUCT
//END_TYPE

//TYPE TComplexStruct :
//STRUCT
//        intVal : INT:=1200;
//        dintArr: ARRAY[0..3] OF DINT:= 1,2,3,4;
//        boolVal: BOOL := FALSE;
//        byteVal: BYTE:=10;
//        stringVal : STRING(5) := 'hallo';
//        simpleStruct1: TSimpleStruct;
//END_STRUCT
//END_TYPE

//PROGRAM MAIN
//VAR
//        (*primitive Types*)
//        Bool1:BOOL := FALSE;
//        int1:INT := 30000;
//        dint1:DINT:=125000;
//        usint1:USINT:=200;
//        real1:REAL:= 1.2;
//        lreal1:LREAL:=3.5;
        
//        (* string Types*)
//        str1:STRING := 'this is a test string';
//        str2:STRING(5) := 'hallo';
        
//        (* struct Types*)
//        complexStruct1 : TComplexStruct;
//END_VAR