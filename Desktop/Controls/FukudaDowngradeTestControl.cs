using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Desktop.DesktopProperties;

namespace Desktop.Controls
{
    public partial class FukudaDowngradeTestControl : Desktop.Controls.FukudaNormalTestControl
    {
        public FukudaDowngradeTestControl()
        {
            InitializeComponent();

            TestMode = TestMode.tmDowngrade;
        }
    }
}
