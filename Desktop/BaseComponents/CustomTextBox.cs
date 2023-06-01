using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.BaseComponents
{
    public class CustomTextBox:TextBox
    {
        public CustomTextBox()
        {
            ////InitializeComponent();
            //SetStyle(ControlStyles.SupportsTransparentBackColor |
            //         ControlStyles.OptimizedDoubleBuffer |
            //         ControlStyles.AllPaintingInWmPaint |
            //         ControlStyles.ResizeRedraw  |
            //         ControlStyles.UserPaint
            //         ,true);
            //SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor =  Color.Transparent;
            ForeColor = Color.Black;
        }
    }
}
