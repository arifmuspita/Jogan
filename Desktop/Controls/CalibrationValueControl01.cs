using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop.Forms.Trial.Class;

namespace Desktop.Controls
{
    public partial class CalibrationValueControl01 : UserControl
    {
        private int FIndex;
        public int Index { get { return FIndex; } set { SetIndex(value); } }
        private void SetIndex(int value)
        {
            if (value < 1) value = 1;
            if (value > 64) value = 64;
            FIndex = value;
            gbCal.Text = " Socket " + value.ToString() + " ";
        }

        private CalibrationCellResult FCalibrationCellResult;
        public CalibrationCellResult CalibrationCellResult { get { return FCalibrationCellResult; }  set { SetFCalibrationCellResult(value); } }

        private void SetFCalibrationCellResult(CalibrationCellResult value)
        {
            FCalibrationCellResult = value;
            txtCV.Text = "";
            txtGSV.Text = "";
            chkCS.Checked = false;
            if (value != null)
            {
                txtCV.Text = value.CalibrationValue.ToString("N3");
                txtGSV.Text = value.GoldenSampleValue.ToString("N3");
                chkCS.Checked = value.CloseSocket;
            }
        }
        //public CalibrationValueControl(int AIndex, CalibrationCellResult ACalibrationCellResult)
        //{
        //    InitializeComponent();
        //    CalibrationCellResult = ACalibrationCellResult;
        //    Index = AIndex;
        //}
        public CalibrationValueControl01()
        {
            InitializeComponent();
            CalibrationCellResult = null;
            Index = 1;
        }
    }
}
