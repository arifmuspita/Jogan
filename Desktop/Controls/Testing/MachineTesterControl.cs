using Commons;
using Desktop.BaseControls;
using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controls.Testing
{
    public partial class MachineTesterControl : Desktop.BaseControls.BaseTestingItemControl
    {
        private int FCount;
        private int FMachineInterval;
        public int MachineInterval
        {
            get { return FMachineInterval; }
            set { SetMachineInterval(value); }
        }
        private int FLineID;
        public int LineID { get { return FLineID; } set { FLineID = value; } }
        private bool FIsByPassTest;
        public   bool  IsByPassTest { get { return FIsByPassTest; } set { FIsByPassTest = value; } }
        private bool FIsDoneTesting;
        public bool IsDoneTesting { get { return GetIsDoneTesting(); } set { FIsDoneTesting = value; } }

        private bool GetIsDoneTesting()
        {
            return FIsDoneTesting || FIsByPassTest;
        }

        private DateTime FTestDoneTime;
        public DateTime TestDoneTime { get { return FTestDoneTime; } set { FTestDoneTime = value; } }
        //private string FMachineName;
        public string MachineName { get { return lblMachineName.Text; } set { lblMachineName.Text = value; } }
        //private string FJigID;
        public string JigID { get { return lblJigID.Text; } set { lblJigID.Text = value; } }
        private void SetMachineInterval2(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(SetMachineInterval2), new object[] { value });
                return;
            }
            FMachineInterval = value;
            if (value == 0)
            {
                tmrMachine.Enabled = false;
                pbProgress.Value = 0;
                lblProgress.Text = "0 %";
            }
            else
            {
                pbProgress.Maximum = value;
            }
        }
        private void SetMachineInterval(int value)
        {
            SetMachineInterval2(value);
            //   FMachineInterval = value;
            //if (value == 0)
            //{
            //    tmrMachine.Enabled = false;
            //    pbProgress.Value = 0;
            //    lblProgress.Text = "0 %";
            //} else
            //{
            //    pbProgress.Maximum = value;
            //}
        }

        protected override void SetIndex(int value)
        {
            base.SetIndex(value);
            gbMainItem.Text = " Machine " + value.ToString() + " ";
        }

        private void SetTimer(bool value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(SetTimer), new object[] { value });
                return;
            }
            FCount = 0;
            pbProgress.Value = 0;
            IsDoneTesting = false;
            Status = StatusTestingControl.Testing;
            tmrMachine.Enabled = value;
        }
        public void StartProgress()
        {
            if (FMachineInterval != 0)
            {
                SetTimer(true);
                //tmrMachine.Enabled = true;
            }
        }
        public MachineTesterControl()
        {
            InitializeComponent();
            FCount = 0;
            IsDoneTesting = true;
            Status = StatusTestingControl.Available;
        } 
        private void MachineTick(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<object, EventArgs>(MachineTick), new object[] { sender,e });
                return;
            }
            FCount++;
            pbProgress.Value = FCount;
            double prcnt = ((double)FCount / FMachineInterval) * 100;
            lblProgress.Text = prcnt.ToString("n2") + " %";
            if (FCount == FMachineInterval) {
                TestDoneTime = DateTime.Now;
                tmrMachine.Enabled = false;
                IsDoneTesting = true;
                Status = StatusTestingControl.TestDone;
                StartBlinking = true;
            }
        }
        private void tmrMachine_Tick(object sender, EventArgs e)
        {
            MachineTick(sender, e);
            //FCount++;
            //pbProgress.Value = FCount;
            //double prcnt = ((double)FCount / FMachineInterval) * 100;
            //lblProgress.Text = prcnt.ToString("n2") + " %";
            //if (FCount == FMachineInterval) tmrMachine.Enabled = false;
        }
        protected override object GetValue()
        {
            object val = base.GetValue();
            if (!(val is MachineTestingControlClass) || val==null) {
                return new MachineTestingControlClass
                {
                    Status = Status,
                    JigID = "",
                    IsDoneTesting = IsDoneTesting,
                };
            } else
            {
                ((MachineTestingControlClass)val).Code = Code;
                ((MachineTestingControlClass)val).JigID = JigID;
                ((MachineTestingControlClass)val).LineID = LineID;
                ((MachineTestingControlClass)val).MachineName = MachineName;
                ((MachineTestingControlClass)val).Status = Status;
                ((MachineTestingControlClass)val).TestDoneTime = TestDoneTime; 
                ((MachineTestingControlClass)val).IsByPassTest = IsByPassTest;
                ((MachineTestingControlClass)val).IsDoneTesting = IsDoneTesting;
                return val;
            }
            //return val;
        }
        private void SetValueControl(MachineTestingControlClass value = null)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<MachineTestingControlClass>(SetValueControl), new object[] { value });
                return;
            }
            Status = StatusTestingControl.Available;
            IsDoneTesting = true;
            JigID = "";
            StartBlinking = false;
            // IsDoneTesting.ToString();
            //lblMachineName.Text = "";
            //lblJigID.Text = "";
            //lblStatus.Text = "";
            //if (value==null) { Status = StatusTestingControl.Available; } else
            if (value is MachineTestingControlClass)
            {
                MachineTestingControlClass mtc = (MachineTestingControlClass)value;
                lblMachineName.Text = mtc.MachineName;
                lblJigID.Text = mtc.JigID;
                lblStatus.Text = mtc.Status.ToString();
                if (!(Status==StatusTestingControl.Testing || Status==StatusTestingControl.TestDone || Status==StatusTestingControl.ByPassTest)) StartProgress();
            }
        }
        protected override void SetValue(object value)
        {
            base.SetValue(value);
            SetValueControl((MachineTestingControlClass)value);
            //if (value is MachineTestingControlClass)
            //{
            //    MachineTestingControlClass mtc = (MachineTestingControlClass)value;
            //    lblMachineName.Text = mtc.MachineName;
            //    lblJigID.Text = mtc.JigID;
            //    lblStatus.Text = mtc.Status.ToString();
            //}
        }
        public void SetStatus2(StatusTestingControl value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<StatusTestingControl>(SetStatus2), new object[] { value });
                return;
            }
            lblStatus.Text = value.ToString();
        }
        protected override void SetStatus(StatusTestingControl value)
        {
            base.SetStatus(value);
            //lblStatus.Text = value.ToString() ;
            SetStatus2(value);
        }
        protected override void GetAllLabels(Control AParent, List<ControlProperty> AListLabels)
        {
            base.GetAllLabels(groupBox1, AListLabels);
            base.GetAllLabels(groupBox2, AListLabels);
            //List<Control> c = AParent.Controls.OfType<Label>().Cast<Control>().ToList();
            //foreach (Label item in c)
            //{
            //    Label txt = (Label)item;
            //    AListLabels.Add(new LabelProperty { Label = item, ForeColor = txt.ForeColor });
            //}
        }
    }
}
