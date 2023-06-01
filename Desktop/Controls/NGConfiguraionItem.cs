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
    public partial class NGConfiguraionItem : UserControl
    {
        private bool FDontChangeRB;
        private bool FDontChangeCB;
        [Browsable(false)]
        public bool TellOwner { get; set; }
        public NGConfiguration Owner { get; set; }
        public string ID
        {
            get { return gbErrorCode.Text.Trim() ; }
        }

        private int FIndex;
        public int Index
        {
            get { return FIndex; }
            set { FIndex = value; gbErrorCode.Text = " Box " + value.ToString(); }
        }
        public string Value
        {
            get {
                string val = "";
                List<Control> c = gbErrorCode.Controls.OfType<RadioButton>().Cast<Control>().ToList();
                foreach (RadioButton item in c)
                {
                    RadioButton rb = (RadioButton)item;
                    if (rb.Checked)
                    {
                        val = (string)rb.Tag;
                    }
                }
                if (val == "")
                {
                    if (cmbErrorCode.SelectedIndex != 0) val = (string)cmbErrorCode.Items[cmbErrorCode.SelectedIndex];
                }
                return val;
            }
            set {
                string val = value;
                bool set = false;
                List<Control> c = gbErrorCode.Controls.OfType<RadioButton>().Cast<Control>().ToList();
                foreach (RadioButton item in c)
                {
                    FDontChangeRB = true;
                    RadioButton rb = (RadioButton)item;
                    rb.Checked = false;
                    if ((string)rb.Tag==val)
                    {
                        rb.Checked = true;
                        set = true;
                    }
                    FDontChangeRB = false;
                }
                if (!set) {
                    FDontChangeCB = true;
                    int idx =cmbErrorCode.Items.IndexOf(val);
                    if (idx != -1)
                    {
                        cmbErrorCode.SelectedIndex = idx;
                        set = true;
                    } else { cmbErrorCode.SelectedIndex = 0; }
                    FDontChangeCB = false;
                }
                if (set && TellOwner)
                {
                    if (Owner != null)
                    {
                        Owner.RemoveDuplicate(this,val);
                    }
                }
            }
        }
        private void RadioButtonCheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
                rb.ImageIndex = 1;
            else
                rb.ImageIndex = 0;
            if (FDontChangeRB) return;
            TellOwner = false;
            FDontChangeCB = true;
            cmbErrorCode.SelectedIndex = 0;
            FDontChangeCB = false;
            if (Owner != null) { TellOwner = true; Owner.RemoveDuplicate(this, (string)rb.Tag); TellOwner = false; }
        }

        private void ComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (FDontChangeCB) return;
            List<Control> c = gbErrorCode.Controls.OfType<RadioButton>().Cast<Control>().ToList();
            foreach (RadioButton item in c)
            {
                RadioButton rb = (RadioButton)item;
                TellOwner = false;
                FDontChangeRB = true;
                rb.Checked = false;
                FDontChangeRB = false;
            }
            if (Owner != null)
            { TellOwner = true; Owner.RemoveDuplicate(this, (string)cmbErrorCode.Items[cmbErrorCode.SelectedIndex]);
                TellOwner = false; }
        }

        private void FillComboErrorCode()
        {
            cmbErrorCode.Items.Clear();
            cmbErrorCode.Items.Add("-");
            for (int i = 13; i <= 30; i++) cmbErrorCode.Items.Add("E"+i.ToString());
            TellOwner = false;
            cmbErrorCode.SelectedIndex = 0;
        }
        public NGConfiguraionItem()
        {
            FDontChangeCB = false;
            FDontChangeRB = false;
            TellOwner = false;
            InitializeComponent();
            FillComboErrorCode();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
