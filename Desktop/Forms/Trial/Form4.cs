using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Trial
{
    public partial class Form4 : Form
    {
        private Thread[] FThread = new Thread[2];
        private bool FIsStop;
        private bool FIsWait;
        public delegate bool StopDelayAction();
        public delegate void JoganUtilityAction();
        public Form4()
        {
            InitializeComponent();
            FIsStop = false; FIsWait = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

             
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            FIsStop = false;
            FIsWait = false;
            FThread[0] = new Thread(new ThreadStart(ThreadForTest0));
            FThread[0].IsBackground = true;
            FThread[0].Start();

            FThread[1] = new Thread(new ThreadStart(ThreadForTest1));
            FThread[1].IsBackground = true;
            FThread[1].Start();
        }

        private void SetMessage(ListBox AListBox,   string AMessage)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<ListBox,string>(SetMessage), new object[] { AListBox,AMessage });
                return;
            }
            AListBox.Items.Insert(0, AMessage);
        }
        private async void Wait(ListBox AListBox, StopDelayAction AStopDelayAction)
        {
            FIsWait = true;
            while (AStopDelayAction())
            {
                SetMessage(AListBox, "Proccess paused");
                await Task.Delay(1000);
            }
            FIsWait = false; 
        }
        private void WaitSync(ListBox AListBox, StopDelayAction AStopDelayAction)
        {
            FIsWait = true;
            while (AStopDelayAction())
            {
                SetMessage(AListBox, "Proccess paused");
                Thread.Sleep(1000);
            }
            FIsWait = false;
        }
        private async void Wait(ListBox AListBox, StopDelayAction AStopDelayAction, JoganUtilityAction AJoganUtilityAction)
        {
            while (AStopDelayAction())
            {
                SetMessage(AListBox, "Proccess paused");
                await Task.Delay(1000);
            }
            if (AJoganUtilityAction != null) AJoganUtilityAction();
        }

        private async void ThreadForTest0()
        {
            while (true) //(FListFukudaNotification.Count > 0)
            {
                if (FIsStop) break;
                if (FIsWait) goto Skip;

                WaitSync(lbMsg1,delegate () { return chkHalt.Checked; });
                if (FIsWait) goto Skip;
                SetMessage(lbMsg1,"Proccess is running");
                Skip:
                await Task.Delay(1000);
            }
        }
        private async void ThreadForTest1()
        {
            while (true) //(FListFukudaNotification.Count > 0)
            {
                if (FIsStop) break;  
                //Wait(lbMsg2,delegate () { return chkHalt.Checked; });
                
                SetMessage(lbMsg2,"Proccess 2 is running"); 
                await Task.Delay(1000);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            FIsStop = true; 
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            FIsStop = true;
            chkHalt.Checked = false;
        }
    }
}
