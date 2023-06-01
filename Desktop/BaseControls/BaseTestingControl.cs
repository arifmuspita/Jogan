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
using Commons;

namespace Desktop.BaseControls
{
    public partial class BaseTestingControl : UserControl
    {
        public event EventStatusChanged StatusChanged;
        public BaseTestingControl()
        {
            InitializeComponent();
        }
        public void ExecStatusChanged(object sender, StatusTestingControl e)
        {
            if (StatusChanged != null) { StatusChanged(sender, e); }
        }
    }
}
