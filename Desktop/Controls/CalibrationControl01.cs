using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Controls
{
    public partial class CalibrationControl01 : UserControl
    {
        private int FWidth;
        private int FHeight;
        private bool FOnLoading;
        private Dictionary<int, CalibrationValueControl01> FCalibrationValueControls;
        public Dictionary<int, CalibrationValueControl01> CalibrationValueControls { get; }
        private void ClearCalibrationValueControls()
        { 
            foreach (KeyValuePair<int, CalibrationValueControl01> kvp in FCalibrationValueControls)
            { 
                pnlCalibration.Controls.Remove(kvp.Value);
                kvp.Value.Dispose(); 
            } 
        }
        private void CreateCalibrationValueControls()
        {
            SuspendLayout();
            ClearCalibrationValueControls(); 
            int maxcol = Width / FWidth;
            int wr = 0;
            int h = 0;
            int w = 0;
            int x = 0;
            int y = 0;
            int y1 = 0; 
            for (int i = 1; i <= 64; i++)
            {
                CalibrationValueControl01 cvc = new CalibrationValueControl01(); 
                cvc.Index = i;
                cvc.CalibrationCellResult = null;
                cvc.Font= Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))); 
                wr = wr + cvc.Width;
                h = cvc.Height;
                w = cvc.Width;
                if ((wr / FWidth) > maxcol)
                {
                    y1++;
                    x = 0; wr = 0;

                    y = h * y1;
                    cvc.Parent = pnlCalibration;
                    cvc.Top = y;
                    cvc.Left = x;
                }
                else
                {

                    y = h * y1;
                    cvc.Parent = pnlCalibration;
                    cvc.Top = y;
                    cvc.Left = x;
                    x = x + w;
                } 
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
        private int FCount;
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //MessageBox.Show((FCount++).ToString());
           if (!FOnLoading) CreateCalibrationValueControls();
        }
        public void RecreateCalibrationValueControls()
        {
            CreateCalibrationValueControls();
        }
        public CalibrationControl01()
        {
            FCount = 0;
            CalibrationValueControl01 cvc = new CalibrationValueControl01();
            FWidth = cvc.Width;
            FHeight = cvc.Height;
            cvc.Dispose();
            FCalibrationValueControls = new Dictionary<int, Desktop.Controls.CalibrationValueControl01>();
            //FCalibrationValueControls.Clear();
            FOnLoading = true;
            InitializeComponent();
            //CreateCalibrationValueControls();
            FOnLoading = false;
            Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }
    }
}
