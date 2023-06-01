using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
    public enum FukudaHandlerStatus
    {
        fhsFree,
        fhsLoad,
        fhsReturn
    }
    public enum FukudaTransferPosition
    {
        ftpHandler,                         //position on fukuda handler
        ftpStraightener                     //position on straigthener
    }
    public enum FukudaTransferJigStatus
    {
        ftjsEmpty,                          //fukuda transfer doesn't carry jig
        ftjsJigEmpty,                       //fukuda transfer carry jig with empty device
        ftjsJigFull                         //fukuda transfer carry jig fill with device
    }
    public enum FukudaHandlerVacuumState
    {
        fhvsStandBy,                        //vacuum standby
        fhvsFull,                           //vacuum full jig (get jig to lotbox)
        thvsPush                            //vacuum fush jig (return jig to lotbox)
    }
    
    public enum TypeOfData { tpString, tpInt, tpBool, tpDouble, tpByte, tpObject }
    //public delegate void EventValueChangedHandler(TwinCat3Property sender);
    public delegate void EventSetReadyClick(object sender, out bool AllowClick);
    public delegate bool JoganWaitAction();
    public delegate void SimulationAction();
    public delegate void JoganUtilityAction();
    public delegate void JoganThreadWorking(Thread sender, string message = "");
    public class TwinCat3Property
    {
        public int DeviceNotificationHandle { get; set; }
        public string VariableName { get; set; }
        public object DataObject1 { get; set; }
        public object DataObject2 { get; set; }
        //public event EventValueChangedHandler OnValueChanged;
    }
    public class UtilityProperty
    {
    }
}
