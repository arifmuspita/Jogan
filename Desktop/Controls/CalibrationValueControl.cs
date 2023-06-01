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
    public partial class CalibrationValueControl : UserControl
    {
        private int FIndex;
        public int Index { get { return FIndex; } set { SetIndex(value); } }
        private void SetIndex(int value)
        {
            if (value < 1) value = 1;
            if (value > 64) value = 64;
            TabIndex = value;
            FIndex = value;
            gbCalVal.Text = " Socket " + value.ToString() + " ";
        }

        private double FValue;
        public double Value { get { return FValue; } set { SetValue(value); } } 
        public bool CloseSocket { get { return chkCS.Checked; } }

        private void SetValue(double value)
        {
            FValue = value;
            txtValue.Text = value.ToString();
        }

        public CalibrationValueControl()
        {
            InitializeComponent();
        }

        private void chkCS_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCS.Checked)
                chkCS.ImageIndex = 1;
            else
                chkCS.ImageIndex = 0;
        }
    }
}
