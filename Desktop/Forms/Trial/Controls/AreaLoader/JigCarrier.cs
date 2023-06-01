using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms.Trial.Controls.AreaLoader
{
    public enum JigPosition {Left,Right, Up,Middle,Bottom};
    public partial class JigCarrier : Desktop.Forms.Trial.Controls.AreaLoader.BaseAreaLoader
    {
        private string FEndPosition;
        public string EndPosition { get { return FEndPosition; } set { FEndPosition = value; SetText(lblEndPos, value); } }
        private string FStartPosition;
        public string StartPosition { get { return FStartPosition; } set { FStartPosition = value; SetText(lblStartPos, value); } }
        private bool FIsTested;
        public bool IsTested { get { return FIsTested; } set { FIsTested = value; } }
        private JigPosition FJigPosition;
        public JigPosition  JigPosition { get { return FJigPosition; } set { SetJigPosition(value); } }

        private void SetJigPosition(JigPosition value)
        {
            FJigPosition = value;
            switch (value)
            {
                case JigPosition.Right:
                    Left = 189;
                    Top = 261;
                    break;
                case JigPosition.Up:
                    Left = 15;
                    Top = 23;
                    break;
                case JigPosition.Left:
                    Left = 15;
                    Top = 261;
                    break;
                case JigPosition.Bottom:
                    Left = 16;
                    Top = 500;
                    break;
            }
        }

        private bool FSkipTestNoise;
        public bool SkipTestNoise { get { return FSkipTestNoise; } set { FSkipTestNoise = value; } }
        private bool FSkipTestSignal;
        public bool SkipTestSignal { get { return FSkipTestSignal; } set { FSkipTestSignal = value; } }
        private bool FSkipTestResistance;
        public bool  SkipTestResistance { get { return FSkipTestResistance; } set { FSkipTestResistance = value; } }

        protected override void SetText(Label ALabel, string AText)
        {
            base.SetText(ALabel, AText);
        }
        protected override void ActiveTimer(bool IsActive)
        {
            if (!IsTested) { Status = IsActive ? "Placing devices ..." : ""; IsLoaded = true; } 
            else { Status = IsActive ? "Picking devices ..." : ""; IsLoaded = false; }
            pnlBottom.Visible = IsActive;
            base.ActiveTimer(IsActive);
        }
        public override void Start()
        {
            pnlBottom.Visible = true;
            base.Start(); 
            if (!IsTested) { IsLoaded = false; Status = "Placing devices..."; } else { IsLoaded = true; Status = "Picking devices...";  }
        }
        public override void Stop()
        {
            base.Stop();
            Status = "";
            pnlBottom.Visible = false;
            if (!IsTested) { IsLoaded = true; } else { IsLoaded = false; }
        }
        public JigCarrier()
        {
            InitializeComponent();
            IsTested = false;
            IsLoaded = false;
        }
    }
}
