using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Trial.Controls.AreaLoader
{
    public delegate void EventOnProccessFinish(object sender, bool IsFinish);
    public partial class BaseAreaLoader : UserControl
    {
        private bool FIsLoaded;
        public bool IsLoaded { get { return FIsLoaded; } set { FIsLoaded = value; } }
        private bool FIsStarted;
        public bool IsStarted { get { return FIsStarted; }   }
        private string FJigID;
        public string JigID { get { return FJigID; } set { FJigID = value; SetText(lblJigID, value); } }
        private string FPONumber;
        public string PONumber { get { return FPONumber; } set { FPONumber = value; SetText(lblPONumber, value); } }
        private string FStatus;
        public string Status { get { return FStatus; } set { FStatus = value; SetText(lblStatus, value); } } 
        private int FTimeInterval;
        public int TimeInterval { get { return FTimeInterval; } set { FTimeInterval = value; pbMain.Maximum = value; } }
        private DateTime FTestDoneTime;
        public DateTime TestDoneTime { get { return FTestDoneTime; } set { FTestDoneTime = value; } }
        private Timer FTimer;
        private int FCounter;
        private bool FSkipTest;
        public bool SkipTest { get { return FSkipTest; } set { FSkipTest = value; } }
      
        public event EventOnProccessFinish OnProccessFinish;

        protected virtual void SetText(Label ALabel,string AText)
        {
            ALabel.Text = AText;
        }

        protected virtual void ActiveTimer(bool IsActive)
        {
            if (OnProccessFinish != null) OnProccessFinish(this, !IsActive);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            FCounter++;
            if (FCounter <= pbMain.Maximum) pbMain.Value = FCounter;
            if (FCounter >= FTimeInterval) Stop();
        }
        public virtual void Start()
        {
            FIsStarted = true;
            FTimer.Enabled = !SkipTest;
            //ActiveTimer(true);
        }
        public virtual void Stop()
        {
            FCounter = 0;
            pbMain.Value = 0;
            FIsStarted = false;
            FTimer.Enabled = false;
            //ActiveTimer(false);
        }
        public BaseAreaLoader()
        {
            InitializeComponent();
            FCounter = 0;
            FTimer = new Timer();
            FTimer.Interval = 1000;
            FTimer.Enabled = false;
            FTimer.Tick += new EventHandler(TimerTick);
            SkipTest = false;
        } 
    }
}
