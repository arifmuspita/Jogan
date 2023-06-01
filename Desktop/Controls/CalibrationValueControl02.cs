using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop.DesktopProperties;

namespace Desktop.Controls
{
    public partial class CalibrationValueControl02 : UserControl
    {
        public Dictionary<string, double> CalibrationValues { get;  }
        public Dictionary<string, double> GoldenSampleValues { get;   }
        private int FIndex;
        public int Index { get { return FIndex; } set { SetIndex(value); } }
        private void SetIndex(int value)
        {
            if (value < 1) value = 1;
            if (value > 64) value = 64;
            FIndex = value;
            gbCal.Text = " Socket " + value.ToString() + " ";
        }

        private TestReference FTestReference;//Noise,Signal,Resistance
        public TestReference TestReference { get { return FTestReference; } set { SetTestReference(value); } }
        private void ClearInput()
        { 
            foreach (KeyValuePair<string, double> kvp in CalibrationValues)
            {
                string nm = "lbl" + kvp.Key;
                Control c = gbCal.Controls[nm];
                if (c != null)
                {
                    gbCal.Controls.Remove(c);
                    c.Dispose();
                }
                nm = "txtCV" + kvp.Key;
                c = gbCal.Controls[nm];
                if (c != null)
                {
                    gbCal.Controls.Remove(c);
                    c.Dispose();
                }
                nm = "txtGS" + kvp.Key;
                c = gbCal.Controls[nm];
                if (c != null)
                {
                    gbCal.Controls.Remove(c);
                    c.Dispose();
                }
            }
        }
        private void CreateInput()
        {
            Height = 130;
            if (FTestReference == TestReference.Resistance) { Height = 85; }
            lblCV.Left = 85;
            lblGS.Left = 165;
            int y = 40;
            int x = 10;
            foreach (KeyValuePair<string, double> kvp in CalibrationValues)
            {
                new Label { Name = "lbl" + kvp.Key, Left = x, Top = y + 2, Text = kvp.Key, AutoSize = true, Parent = gbCal };
                new TextBox { Name = "txtCV" + kvp.Key, Left = lblCV.Left + 5, Top = y, Text = "", Width = 70, Parent = gbCal, ForeColor = lblCV.ForeColor };
                new TextBox { Name = "txtGS" + kvp.Key, Left = lblGS.Left + 5, Top = y, Text = "", Width = 70, Parent = gbCal, ForeColor = lblGS.ForeColor };
                y = y + 25;
            }
            //foreach (KeyValuePair<string, double> kvp in CalibrationValues)
            //{
            //   TextBox txt= (TextBox)gbCal.Controls["txtCV" + kvp.Key];
            //    txt.Text = txt.Left.ToString() + ", " + txt.Width.ToString();
            //}
        }
        private void SetTestReference(TestReference value)
        {
            SuspendLayout();
            FTestReference = value;
            ClearInput();
            CalibrationValues.Clear();
            GoldenSampleValues.Clear();
            switch (value)
            {
                case TestReference.Noise:
                    CalibrationValues.Add("Close", 0);
                    CalibrationValues.Add("Good", 0);
                    CalibrationValues.Add("Open", 0);
                    break;
                case TestReference.Resistance:
                    CalibrationValues.Add("Resistance", 0);
                    break;
                case TestReference.Signal:
                    CalibrationValues.Add("Offset", 0);
                    CalibrationValues.Add("Resp", 0);
                    CalibrationValues.Add("Match", 0);
                    break;
            }
            CreateInput();
            ResumeLayout();
        }

        public CalibrationValueControl02()
        {
            CalibrationValues = new Dictionary<string, double>();
            GoldenSampleValues = new Dictionary<string, double>();
            InitializeComponent();
            lblCV.Left = 85;
            lblGS.Left = 165;
            Index = 1;
            TestReference = TestReference.Noise;
        }
    }
}
