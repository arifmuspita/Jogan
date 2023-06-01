using Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms.Trial.Controls.AreaLoader
{
    
    public partial class MachineTester : Desktop.Forms.Trial.Controls.AreaLoader.BaseAreaLoader
    {
        private bool FIsDoneTesting;
        public bool IsDoneTesting { get { return FIsDoneTesting; } set { FIsDoneTesting = value; } }
        private int FLineID;
        public int LineID { get { return FLineID; } set { FLineID = value; } }
        private string FMachineType;
        public string MachineType { get { return FMachineType; } set { FMachineType = value;  } }
        private string FMachineCode;
        public string MachineCode { get { return FMachineCode; } set { FMachineCode = value; SetText(lblMachineCode, value); } }
        private string FMachineName;
        public string MachineName { get { return FMachineName; } set { FMachineName = value; SetText(lblMachineName, value); } }
        private JigCarrier FJigCarrier;
        public JigCarrier JigCarrier { get { return FJigCarrier; } set { SetJigCarrier(value); } }
        private DockStyle FDockingControlInside;
        public DockStyle DockingControlInside { get { return FDockingControlInside; } set { SetDockingControlInside(value); } }
        private void SetDockingControlInside(DockStyle value)
        {
           switch (value)
            {
                case DockStyle.Top:
                    FDockingControlInside = value;
                    pnlBottom.Dock = DockStyle.Top;
                    pnlTop.Dock = DockStyle.Bottom;
                    lblStatus.Dock = DockStyle.Top;
                    lblJigID.Dock = DockStyle.Top;
                    lblPONumber.Dock = DockStyle.Top;
                    lblMachineCode.Dock = DockStyle.Top;
                    lblMachineName.Dock = DockStyle.Top;
                    
                    //lblStatus.SendToBack();
                    //lblJigID.SendToBack();
                    //lblPONumber.SendToBack();
                    //lblMachineName.SendToBack();
                    //lblMachineCode.SendToBack();
                    break;
                case DockStyle.Bottom:
                    FDockingControlInside = value;
                    pnlBottom.Dock = DockStyle.Bottom;
                    pnlTop.Dock = DockStyle.Top;

                    lblStatus.Dock = DockStyle.Bottom;
                    lblMachineCode.Dock = DockStyle.Bottom;
                    lblMachineName.Dock = DockStyle.Bottom;
                    lblPONumber.Dock = DockStyle.Bottom;
                    lblJigID.Dock = DockStyle.Bottom;

                    //lblStatus.BringToFront();
                    //lblJigID.BringToFront();
                    //lblPONumber.BringToFront();
                    //lblMachineName.BringToFront();
                    //lblMachineCode.BringToFront();
                    break;
            }
        }
       // private bool FMachineOn;
        //public bool MachineOn { get { return GetMachineOn(); } set { SetMachineOn(value); } }

        //private bool GetMachineOn()
        //{
        //    return rbOn.Checked;
        //}
        public MachineState MachineState { get { return GetMachineState(); } set { SetMachineState(value); } }
        private MachineState GetMachineState()
        {
            MachineState ms = MachineState.msOn;
            if (rbMtc.Checked) ms = MachineState.msMaintanance;
            if (rbOff.Checked) ms = MachineState.msOff;
            if (rbOn.Checked) ms = MachineState.msOn;
            return ms;
        }
        private void SetMachineState(MachineState value)
        {
            lblOn.ForeColor = Color.Black;
            lblOff.ForeColor = Color.Black;
            lblMaintanance.ForeColor = Color.Black;
            rbMtc.Checked = value == MachineState.msMaintanance;
            rbOff.Checked = value == MachineState.msOff;
            rbOn.Checked = value == MachineState.msOn;
            if (rbMtc.Checked) lblMaintanance.ForeColor = Color.Red;
            if (rbOff.Checked) lblOff.ForeColor = Color.Red;
            if (rbOn.Checked) lblOn.ForeColor = Color.Red;
        } 
        private void SetMachineOn(bool value)
        {
            lblOn.ForeColor = Color.Black;
            lblOff.ForeColor = Color.Black;
            if (value) { rbOn.Checked = true; lblOn.ForeColor = Color.Red; } else { rbOff.Checked = true; lblOff.ForeColor = Color.Red; }
        }

        private void SetJigCarrier(JigCarrier value)
        {
            FJigCarrier = value;
            
            if (value == null)
            {
                PONumber = "";
                JigID = "";
                Status = "Available";
                IsLoaded = false;
            } else
            {
                PONumber = value.PONumber ;
                JigID = value.JigID;
                Status = "Loaded";
                IsLoaded = true;
                SkipTest = false;
                if (MachineType == "NOISE" && value.SkipTestNoise) SkipTest = true;
                if (MachineType == "SIGNAL" && value.SkipTestSignal) SkipTest = true;
                if (MachineType == "RESISTANCE" && value.SkipTestResistance) SkipTest = true;

                Start();
            }
        }

        protected override void SetText(Label ALabel, string AText)
        {
            base.SetText(ALabel, AText);
        }
        protected override void ActiveTimer(bool IsActive)
        { 
            //FIsDoneTesting = !IsActive;
            //if (IsActive) { Status = "Testing ..."; }
            //else
            //    if (FIsDoneTesting)
            //{
            //    Status = "Test done";
            //}
            //base.ActiveTimer(IsActive);
        }
        public override void Start()
        {
            base.Start();
            Status = "Testing...";
            IsDoneTesting = SkipTest;
        }
        public override void Stop()
        {
            base.Stop(); 
            Status = "Testing finish";
            IsDoneTesting = true;
        }
        public MachineTester()
        {
            InitializeComponent();
            DockingControlInside = DockStyle.Bottom;
            IsDoneTesting = true;
            Status = "Available";
            MachineState = MachineState.msOn;
        }
    }
}
