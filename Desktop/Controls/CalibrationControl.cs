using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Desktop.Controls
{
    public partial class CalibrationControl : UserControl
    {
        private int FWidth;
        private int FHeight;
        private List<bool> FCloseSockets;
        public List<bool> CloseSockets { get { return GetCloseSockets(); } }

        private List<bool> GetCloseSockets()
        {
            for (int i = 0; i <= FCalibrationValueControls.Count - 1; i++)
            {
                FCloseSockets[i]  = FCalibrationValueControls[i].CloseSocket;
            }
            return FCloseSockets;
        }

        private List<double> FCalibrationValues;
        public List<double>  CalibrationValues { get { return FCalibrationValues; } set { SetCalibrationValues(value); } }

        private void SetCalibrationValues(List<double> value)
        {
            if (value==null) { FCalibrationValues.Clear(); ClearValueOnControls(); } else
            {
                FCalibrationValues = value;
                for (int i = 0; i <= FCalibrationValues.Count - 1; i++)
                {
                    if (FCalibrationValueControls.Count-1>=i) FCalibrationValueControls[i].Value = FCalibrationValues[i];
                }
            }
        }

        private void ClearValueOnControls()
        {
            for (int i = 0; i <= FCalibrationValueControls.Count - 1; i++)
            {
                FCalibrationValueControls[i].Value = 0;
            }
        }
        
        private void ClearCalibrationValueControls()
        {
            foreach (CalibrationValueControl kvp in FCalibrationValueControls)
            {
                pnlCal.Controls.Remove(kvp);
                kvp.Dispose();
            }
        }
        private List<CalibrationValueControl> FCalibrationValueControls;
        public List<CalibrationValueControl> CalibrationValueControls { get { return FCalibrationValueControls; } }
        private void CreateCalibrationValueControls()
        {
            SuspendLayout();
            ClearCalibrationValueControls();
            CalibrationValueControl cvc = new CalibrationValueControl(); 
            FWidth = cvc.Width;
            FHeight = cvc.Height;
            cvc.Dispose();
            int maxcol = Width / FWidth;
            //MessageBox.Show(
            //    "W = " + Width.ToString() + "\r\n" +
            //    "FWidth = " + FWidth.ToString() + "\r\n" +
            //    "max = " + maxcol.ToString()
            //    );
            int h = 0;
            int w = 0;
            int x = 0;
            int y = 0;
            int y1 = 0;
            int a = 0;
            for (int i = 1; i <= 64; i++)
            { 
                cvc = new CalibrationValueControl();
                cvc.Value = 0;
                cvc.Index = i; 
                h = cvc.Height;
                w = cvc.Width;
                if (x + 2 > (maxcol * FWidth))
                {
                    y1++; x = 0;
                }
                y = h * y1;

                cvc.Left = x;
                cvc.Top = y + 2;
                cvc.Parent = pnlCal;
                x = x + w + 2;
                FCalibrationValueControls.Add(cvc);
            }
            ResumeLayout();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CreateCalibrationValueControls();
            //pnlCalibration.VerticalScroll.Value = pnlCalibration.VerticalScroll.Maximum;
        }
        public void UpdateValueControl(int AIndex, double Value)
        {
            if (AIndex < 0 || AIndex > 63) { MessageBox.Show("Index out of range (0-63)"); return; }
            FCalibrationValues[AIndex] = Value;
            if (FCalibrationValueControls.Count - 1 >= AIndex) FCalibrationValueControls[AIndex].Value = Value;
        }
        public CalibrationControl()
        {
            FCalibrationValueControls = new List<CalibrationValueControl>();
            FCalibrationValues = new List<double>(); 
            FCloseSockets = new List<bool>();
            for(int i = 1; i <= 64; i++)
            {
                FCalibrationValues.Add(0);
                FCloseSockets.Add(false);
            }
            InitializeComponent();
           // CreateCalibrationValueControls();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                ClearCalibrationValueControls();
                FCalibrationValueControls.Clear();
                FCalibrationValues.Clear();
                FCloseSockets.Clear();
                components.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
