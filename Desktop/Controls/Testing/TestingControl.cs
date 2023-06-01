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
    public partial class TestingControl : Desktop.BaseControls.BaseTestingControl
    {
        private List<FukudaTestingControlClass> FRecordFukudaTesting;
        private List<FukudaTestingControl> FFukudaTestingControlItems;
        private List<MachineTesterControl> FMachineTesterControlItems;
        private List<LaserTestingControl> FLaserTestingControlItems;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            FFukudaTestingControlItems.Clear();
            FMachineTesterControlItems.Clear();
            FLaserTestingControlItems.Clear();
            base.Dispose(disposing);
        }

        //public FukudaTestingControl this[int index]
        //{
        //    get
        //    {
        //        // Following trick can reduce the range check by one
        //        if ((index > FFukudaTestingControlItems.Count) || (index<0))
        //        {
        //            MessageBox.Show("Index out of range (0-" + (FFukudaTestingControlItems.Count - 1).ToString()+")");
        //        } 
        //        return FFukudaTestingControlItems[index];
        //    } 
        //}
        public FukudaTestingControl FukudaTestingControlItem(int index)
        {
            if ((index > FFukudaTestingControlItems.Count) || (index < 0))
            {
                MessageBox.Show("Index out of range (0-" + (FFukudaTestingControlItems.Count - 1).ToString() + ")");
                return null;
            } else  return FFukudaTestingControlItems[index];
        }
        public FukudaTestingControl FukudaTestingControlItem(string ACode)
        {
            return FFukudaTestingControlItems.Where(x => x.Code == ACode).FirstOrDefault();
        }
        public MachineTesterControl MachineTesterControlItem(int index)
        {
            if ((index > FMachineTesterControlItems.Count) || (index < 0))
            {
                MessageBox.Show("Index out of range (0-" + (FMachineTesterControlItems.Count - 1).ToString() + ")");
                return null;
            }
            else return FMachineTesterControlItems[index];
        }
        public MachineTesterControl MachineTesterControlItem(string ACode)
        {
            return FMachineTesterControlItems.Where(x => x.Code == ACode).FirstOrDefault();
        }
        public LaserTestingControl LaserTestingControlItem(int index)
        {
            if ((index > FLaserTestingControlItems.Count) || (index < 0))
            {
                MessageBox.Show("Index out of range (0-" + (FMachineTesterControlItems.Count - 1).ToString() + ")");
                return null;
            }
            else return FLaserTestingControlItems[index];
        }
        public LaserTestingControl LaserTestingControlItem(string ACode)
        {
            return FLaserTestingControlItems.Where(x => x.Code == ACode).FirstOrDefault();
        }
        public TestingControl()
        {
            InitializeComponent();
            FRecordFukudaTesting = new List<FukudaTestingControlClass>();
            //fukudaTestingControl1.Height = 170;
            //fukudaTestingControl2.Height = 170;
            //fukudaTestingControl3.Height = 170;
            //fukudaTestingControl4.Height = 170;

            //laserTestingControl1.Size = new Size(250, 170);
            //laserTestingControl2.Size = new Size(250, 170);
            //laserTestingControl3.Size = new Size(250, 170);
            //laserTestingControl4.Size = new Size(250, 170);

            FFukudaTestingControlItems = new List<FukudaTestingControl>();
            FFukudaTestingControlItems.Add(fukudaTestingControl1);
            FFukudaTestingControlItems.Add(fukudaTestingControl2);
            FFukudaTestingControlItems.Add(fukudaTestingControl3);
            FFukudaTestingControlItems.Add(fukudaTestingControl4);

            FMachineTesterControlItems = new List<MachineTesterControl>();
            FMachineTesterControlItems.Add(machineTesterControl1);
            FMachineTesterControlItems.Add(machineTesterControl10);
            FMachineTesterControlItems.Add(machineTesterControl11);
            FMachineTesterControlItems.Add(machineTesterControl12);
            FMachineTesterControlItems.Add(machineTesterControl13);
            FMachineTesterControlItems.Add(machineTesterControl2);
            FMachineTesterControlItems.Add(machineTesterControl3);
            FMachineTesterControlItems.Add(machineTesterControl4);
            FMachineTesterControlItems.Add(machineTesterControl5);
            FMachineTesterControlItems.Add(machineTesterControl6);
            FMachineTesterControlItems.Add(machineTesterControl7);
            FMachineTesterControlItems.Add(machineTesterControl9);

            FLaserTestingControlItems = new List<LaserTestingControl>();
            FLaserTestingControlItems.Add(laserTestingControl1);
            FLaserTestingControlItems.Add(laserTestingControl2);
            FLaserTestingControlItems.Add(laserTestingControl3);
            FLaserTestingControlItems.Add(laserTestingControl4);
        }
        public void AddFukudaTestingRecord(FukudaTestingControlClass Value)
        {
            FRecordFukudaTesting.Add(Value);
        }
        public void RemoveFukudaTestingRecord(int ID)
        {
            FukudaTestingControlClass val = FRecordFukudaTesting.Where(x => x.ID == ID).FirstOrDefault();
            if (val != null)
            {
                FRecordFukudaTesting.Remove(val);
            }
        }
        public void RemoveFukudaTestingRecord(string Code)
        {
            FukudaTestingControlClass val = FRecordFukudaTesting.Where(x => x.Code == Code).FirstOrDefault();
            if (val != null)
            {
                FRecordFukudaTesting.Remove(val);
            }
        }
        public FukudaTestingControlClass SearchFukudaTestingRecord(int ID)
        {
            return  FRecordFukudaTesting.Where(x => x.ID == ID).FirstOrDefault(); 
        }
        public FukudaTestingControlClass SearchFukudaTestingRecord(string Code)
        {
            return  FRecordFukudaTesting.Where(x => x.Code == Code).FirstOrDefault(); 
        }
        public void ClearFukudaTestingRecord(string Code)
        {
            FRecordFukudaTesting.Clear();
        }
        private void fukudaTestingControl3_Load(object sender, EventArgs e)
        {

        }

        private void fukudaTestingControl1_ButtonFinishClick(object sender)
        {
            //
        }

        private void laserTestingControl1_ButtonFinishClick(object sender)
        {
            //
        }

        private void laserTestingControl1_ValueChanged(object sender, object value)
        {
            //
        }
    }
}
