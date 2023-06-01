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
    public partial class CalibrationControl02 : UserControl
    {
        private int FWidth;
        private int FHeight;
        private bool FOnLoading;
        private Dictionary<int, CalibrationValueControl02> FCalibrationValueControls;
        public Dictionary<int, CalibrationValueControl02> CalibrationValueControls { get; }
        private TestReference FTestReference;//Noise,Signal,Resistance
        public TestReference TestReference { get { return FTestReference; } set { SetTestReference(value); } }

        private void SetTestReference(TestReference value)
        {
            FTestReference = value;
            foreach (KeyValuePair<int, CalibrationValueControl02> kvp in FCalibrationValueControls)
            {
                kvp.Value.TestReference = value;
            }
        }

        private void ClearCalibrationValueControls()
        {
            foreach (KeyValuePair<int, CalibrationValueControl02> kvp in FCalibrationValueControls)
            {
                pnlCalibration.Controls.Remove(kvp.Value);
                kvp.Value.Dispose();
            }
        }
        private void CreateCalibrationValueControls()
        {
            SuspendLayout();
            ClearCalibrationValueControls();
            CalibrationValueControl02 cvc = new CalibrationValueControl02();
            cvc.TestReference = TestReference;
            FWidth = cvc.Width;
            FHeight = cvc.Height;
            cvc.Dispose();
            int maxcol = Width / FWidth;
            int wr = 0;
            int h = 0;
            int w = 0;
            int x = 0;
            int y = 0;
            int y1 = 0;
            int a = 0;
            for (int i = 1; i <= 64; i++)
            {
                if (i >= 62)
                {
                    a = h;
                }
                cvc = new CalibrationValueControl02();
                cvc.TestReference = this.TestReference;
                cvc.Index = i; 
               // cvc.Font = Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                wr = wr + cvc.Width;
                h = cvc.Height;
                w = cvc.Width;
                if (x+2 > (maxcol * FWidth))
                {
                    y1++; x = 0; 
                }
                y = h * y1; 
                
                cvc.Left = x;
                cvc.Top = y+2;
                cvc.Parent = pnlCalibration;
                x = x + w+2;
                //if ((wr / FWidth) > maxcol)
                //{
                //    y1++;
                //    x = 0; wr = 0;

                //    y = h * y1;
                //    cvc.Parent = pnlCalibration;
                //    cvc.Top = y;
                //    cvc.Left = x;
                //}
                //else
                //{
                //    y = h * y1;
                //    cvc.Parent = pnlCalibration;
                //    cvc.Top = y;
                //    cvc.Left = x;
                //    x = x + w;
                //}
                //if (i == 63) MessageBox.Show("i = " + i.ToString() + "\r\nx = "+x.ToString() + "\r\ny = "+y.ToString());
                //if (i == 64) MessageBox.Show("i = " + i.ToString() + "\r\nx = " + x.ToString() + "\r\ny = " + y.ToString());
                try
                {
                    if (FCalibrationValueControls.ContainsKey(i)) { FCalibrationValueControls[i] = cvc; } else { FCalibrationValueControls.Add(i, cvc); }
                }
                catch (Exception e)
                {

                }
            }
            ResumeLayout();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CreateCalibrationValueControls();
             //pnlCalibration.VerticalScroll.Value = pnlCalibration.VerticalScroll.Maximum;
        }
        public CalibrationValueControl02 GetCalibrationValueControl(int AIndex)
        {
            CalibrationValueControl02 ret = null;
            if (AIndex < 0 || AIndex > 63)
            {
                MessageBox.Show("Index out of range (0-63)");
            }
            else ret = FCalibrationValueControls[AIndex];
            return ret;
        }
        public CalibrationControl02()
        {
            FCalibrationValueControls = new Dictionary<int, CalibrationValueControl02>();
            InitializeComponent();
            TestReference = TestReference.None;
        }
    }
}
