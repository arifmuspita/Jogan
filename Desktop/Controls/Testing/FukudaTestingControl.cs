using Commons;
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
    public partial class FukudaTestingControl : Desktop.BaseControls.BaseTestingItemControl
    {
        protected override void SetBasicColor(Color value)
        {
            base.SetBasicColor(value);
            lblPONumber.ForeColor = value;
            lblDeviceID.ForeColor = value;
            lblDeviceName.ForeColor = value;
            lblQuantity.ForeColor = value;
            lblLotboxID.ForeColor = value;
            lblTestMode.ForeColor = value;
            lblJigIndex.ForeColor = value;
            lblStatus.ForeColor = value;
        }

        public void SetValue2(FukudaTestingControlClass value = null)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<FukudaTestingControlClass>(SetValue2), new object[] { value });
                return;
            }

            lblDeviceID.Text = "-";
            lblDeviceName.Text = "-";
            lblJigIndex.Text = "-";
            lblLotboxID.Text = "-";
            lblPONumber.Text = "-";
            lblQuantity.Text = "-";
            lblStatus.Text = "-";
            lblTestMode.Text = "-";
            //if (value is FukudaTestingControlClass)
            //{
            //FukudaTestingControlClass ftc = (FukudaTestingControlClass)value;


            if (value != null)
            {
                lblDeviceID.Text = value.DeviceID;
                lblDeviceName.Text = value.DeviceName;
                lblJigIndex.Text = value.JigIndex.ToString();
                lblLotboxID.Text = value.LotboxID;
                lblPONumber.Text = value.PONumber;
                lblQuantity.Text = value.Quantity.ToString();
                //lblStatus.Text = value.Status.ToString();
                //Status = value.Status;
                lblTestMode.Text = value.TestMode;
                value.BasicColor = BasicColor;
                if (Owner != null) ((TestingControl)Owner).AddFukudaTestingRecord(value);
            }
            //}
        }
        protected override void SetValue(object value)
        {
            base.SetValue(value);
            SetValue2((FukudaTestingControlClass)value);
            //lblDeviceID.Text = "-";
            //lblDeviceName.Text = "-";
            //lblJigIndex.Text = "-";
            //lblLotboxID.Text = "-";
            //lblPONumber.Text = "-";
            //lblQuantity.Text = "-";
            ////lblStatus.Text = "-";
            //lblTestMode.Text = "-";
            //if (value is FukudaTestingControlClass)
            //{
            //    FukudaTestingControlClass ftc = (FukudaTestingControlClass)value;


            //    if (value != null)
            //    {
            //        lblDeviceID.Text = ftc.DeviceID;
            //        lblDeviceName.Text = ftc.DeviceName;
            //        lblJigIndex.Text = "+";
            //        lblLotboxID.Text = ftc.LotboxID;
            //        lblPONumber.Text = ftc.PONumber;
            //        lblQuantity.Text = ftc.Quantity.ToString();
            //        lblStatus.Text = ftc.Status.ToString();
            //        lblTestMode.Text = ftc.TestMode;
            //    }
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
        public FukudaTestingControl()
        {
            InitializeComponent();
        }
    }
}
