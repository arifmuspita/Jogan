using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Trial.Controls.AreaLoader
{
    public partial class JigOnStorage : UserControl
    {
        private int FIndex;
        public int Index { get { return FIndex; } set { FIndex = value; } }
         

        private bool FIsAvailable;
        public bool IsAvailable { get { return FIsAvailable; } set { SetIsAvailable(value); } }

        private void SetIsAvailable(bool value)
        {
            FIsAvailable = value;
            string sts = "Jig " + Index.ToString();
            sts = FIsAvailable ? sts + " Available" : sts + " Empty";
            lblStatus.Text = sts;
            pnlColor.BackColor = FIsAvailable ? Color.Lime : Color.Red;
        }
        public JigOnStorage()
        {
            InitializeComponent();
            Index = 1;
            IsAvailable = true;
        }
    }
}
