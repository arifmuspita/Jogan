using Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.DesktopProperties
{
    //public enum StatusTestingControl
    //{
    //    On,
    //    Off,
    //    Start,
    //    Finish,
    //    Empty,
    //    Attached,
    //    Standby,
    //    Ready
    //}

    public delegate void EventStatusChanged(object sender, StatusTestingControl e);
    public delegate void EventButtonFinishClick(object sender);
    public delegate void EventValueChanged(object sender, object value);
    //public delegate void EventStatusChanged(object sender, StatusTestingControl e);
    public enum ButtonControlDisabled
    {
        bceNone,
        bceAll,
        bceCancel,
        bceSetReady,
    }
    
    
    public class ControlProperty
    {
        //public Label Label;
        public Control TextControl;
        public Color ForeColor;
    }
    //public enum MachineState
    //{
    //    msOn, msOff, msCalibration
    //}
    //public class TransactionMachineState
    //{
    //    public TransactionMachineState()
    //    {
    //        Machine_Type = "";
    //        Machine_ID = "";
    //        Status = MachineState.msOn;
    //        Machine_Number = 0;
    //    }
    //    public int Machine_Number { get; set; } 
    //    public string Machine_Type { get; set; }
    //    public string Machine_ID { get; set; }
    //    public MachineState Status { get; set; }
    //}
    //public delegate void EventMachineBook(object sender, TransactionMachineState e);
    public enum TestMode { tmAQL, tmNormal, tmDowngrade }
    public enum TestReference { None,Noise, Signal, Resistance }
    
    public class CalibrationValueType
    {
        public Dictionary<string,double> CalibrationValue { get; set; }
        public Dictionary<string,double> GoldenSampleValue { get; set; }
        public bool CloseSocket { get; set; }
    }

    public class BaseTestingControlClass
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public StatusTestingControl Status { get; set; }
        public Color BasicColor { get; set; }
    }

    public class FukudaTestingControlClass : BaseTestingControlClass
    {
        public string PONumber { get; set; }
        public string DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string LotboxID { get; set; }
        public string TestMode { get; set; }
        public int Quantity { get; set; }
        public int JigIndex { get; set; }
    }

    public class MachineTestingControlClass : BaseTestingControlClass
    {
        public string MachineName { get; set; }
        public string JigID { get; set; }
        public int Interval { get; set; }
        public bool IsDoneTesting { get; set; }
        public bool IsByPassTest { get; set; }
        public int LineID { get; set; }
        public DateTime TestDoneTime{ get; set; }
    }
    public class LaserTestingControlClass : BaseTestingControlClass
    {
        public string PONumber { get; set; }
        public int QuantityGood { get; set; }
        public int QuantityNG1 { get; set; }
        public int QuantityNG2 { get; set; }
        public int QuantityNG3 { get; set; }
        public int QuantityNG4 { get; set; }
        public int QuantityNG5 { get; set; }
        public int QuantityNG6 { get; set; }
        public int QuantityNG7 { get; set; }
        public int QuantityNGOther { get; set; }
    }

    public enum InfoMassageImpact { None,Low,Medium,High};
    public class InfoMassageControlClass
    {
        public DateTime DateTime { get; set; }
        public string Sender { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public InfoMassageImpact Impact { get; set; }
    }
    //public class DesktopProperties
    //{
    //}
}
