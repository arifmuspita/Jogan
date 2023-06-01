using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controls.Testing
{
    public partial class LaserTestingControl : Desktop.BaseControls.BaseTestingItemControl
    {
        private int FMaxJig;
        private int FCounter;
        private int FDeviceCount;
        public  int DeviceCount { get { return FDeviceCount; } set { FDeviceCount = value; } }
        public int MaxJig
        {
            get { return FMaxJig; }
            set { SetMaxJig(value); }
        }
        private void SetMaxJig2(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(SetMaxJig2), new object[] { value });
                return;
            }
            if (FMaxJig == 0) { lblMaxJig.Text = ""; }
            else
            {
                lblMaxJig.Text =   "(0 of " + FMaxJig.ToString() + " Jigs)";
            }
        }
        private void SetMaxJig(int value)
        {
            FMaxJig = value;
            SetMaxJig2(value);
        }

        protected override void SetBasicColor(Color value)
        {
            base.SetBasicColor(value); 
            lblPONumber.ForeColor = value;
            lblGood.ForeColor = value;
            lblNG1.ForeColor = value;
            lblNG2.ForeColor = value;
            lblNG3.ForeColor = value;
            lblNG4.ForeColor = value;
            lblNG5.ForeColor = value;
            lblNG6.ForeColor = value;
            lblNG7.ForeColor = value;
            lblNGOther.ForeColor = value;
            lblStatus.ForeColor = value;
        }
        private void SetValue2(LaserTestingControlClass value = null)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<LaserTestingControlClass>(SetValue2), new object[] { value });
                return;
            }
            lblGood.Text = "0";
            lblNG1.Text = "0";
            lblNG2.Text = "0";
            lblNG3.Text = "0";
            lblNG4.Text = "0";
            lblNG5.Text = "0";
            lblNG6.Text = "0";
            lblNG7.Text = "0";
            lblNGOther.Text = "0";
            lblPONumber.Text = "-";
            lblStatus.Text = "-";
            if (value != null)
            {
                LaserTestingControlClass lcc = (LaserTestingControlClass)Value;
                lcc.PONumber = value.PONumber;
                lcc.QuantityGood = lcc.QuantityGood + value.QuantityGood;
                lcc.QuantityNG1 = lcc.QuantityNG1 + value.QuantityNG1;
                lcc.QuantityNG2 = lcc.QuantityNG2 + value.QuantityNG2;
                lcc.QuantityNG3 = lcc.QuantityNG3 + value.QuantityNG3;
                lcc.QuantityNG4 = lcc.QuantityNG4 + value.QuantityNG4;
                lcc.QuantityNG5 = lcc.QuantityNG5 + value.QuantityNG5;
                lcc.QuantityNG6 = lcc.QuantityNG6 + value.QuantityNG6;
                lcc.QuantityNG7 = lcc.QuantityNG1 + value.QuantityNG7;
                lcc.QuantityNGOther = lcc.QuantityNGOther + value.QuantityNGOther;

                lblGood.Text = lcc.QuantityGood.ToString();
                lblNG1.Text = lcc.QuantityNG1.ToString();
                lblNG2.Text = lcc.QuantityNG2.ToString();
                lblNG3.Text = lcc.QuantityNG3.ToString();
                lblNG4.Text = lcc.QuantityNG4.ToString();
                lblNG5.Text = lcc.QuantityNG5.ToString();
                lblNG6.Text = lcc.QuantityNG6.ToString();
                lblNG7.Text = lcc.QuantityNG7.ToString();
                lblNGOther.Text = lcc.QuantityNGOther.ToString();
                lblPONumber.Text = lcc.PONumber;
                lblStatus.Text = value.Status.ToString();
                //FCounter++;

                //if (FMaxJig == 0) { lblMaxJig.Text = ""; }
                //else
                //{
                //    lblMaxJig.Text = "("+FCounter.ToString() + " of " + FMaxJig.ToString() + " Jigs)";
                //}

                //if (value.Status == Commons.StatusTestingControl.Finish) StartBlinking = true;
            }
        }
        protected override void SetValue(object value)
        {
            base.SetValue(value);
            SetValue2((LaserTestingControlClass)value);
        }
        public void AddJig(int Num)
        {
            FCounter = FCounter + Num;
            if (FMaxJig == 0) { lblMaxJig.Text = ""; }
            else
            {
                lblMaxJig.Text = "(" + FCounter.ToString() + " of " + FMaxJig.ToString() + " Jigs)";
            }
        }
        public LaserTestingControl()
        {
            FDeviceCount = 0;
            InitializeComponent(); Value = new LaserTestingControlClass();
            FCounter = 0;
        }
    }
}
