using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.BaseForms
{
    
    public partial class frmBase : Form
    {
        //private string FFormCaption;
        public string FormCaption
        {
            get { return ((ToolStripLabel)tsCaption.Items[0]).Text; }
            set
            {
                ((ToolStripLabel)tsCaption.Items[0]).Text = value;
            }
        }
        //HMI1 or HMI2, this property will tell us which HMI this application run
        //automatically will be set on OS detection (Win7 will be HMI1, WinServer2012 will be HMI2)
        [Browsable(false)]
        public string RunApplicationOn { get; set; } 
        public frmBase()
        {
            InitializeComponent();
        }

        protected virtual void ReArrangeButton(int AHeight = 0,int AWidth=0)
        {
            List<Control> c = pnlBottom.Controls.OfType<Button>().Cast<Control>().ToList();
            c = c.OrderBy(x => x.Visible).ThenBy(x=> x.TabIndex).ToList();
            Button btn = null;
            int cch = 0;
            int xx = 0;
            //MessageBox.Show("");
            for (int i = c.Count-1;i>=0;i--)
            {
                btn = (Button)c[i];
                if (btn.Visible)
                {
                    
                    btn.Anchor = AnchorStyles.Right;
                    if (AHeight != 0) btn.Height = AHeight; else btn.Height = 40;
                    if (AWidth != 0) btn.Width = AWidth; else btn.Width = 100; 
                    if (i == c.Count - 1)
                    {
                        xx = pnlBottom.Width - btn.Width - 20;
                    }
                    else
                    {
                        xx = xx - btn.Width - 5;
                    }
                    int yy = (pnlBottom.Height - btn.Height) / 2;
                    btn.Location = new System.Drawing.Point(xx, yy);
                }
                cch++;

            }
            c.Clear(); 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            OnCloseButtonClick(sender, e);
        }

        protected virtual void OnCloseButtonClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        protected virtual void OnFormShown(object sender, EventArgs e)
        {
            //ReArrangeButton();
            //MessageBox.Show(Width.ToString() + "\r\n" + Height.ToString());
        }
        protected virtual void OnFormClosed(object sender, FormClosedEventArgs e)
        {


        }

        private void frmBase_Shown(object sender, EventArgs e)
        {
            OnFormShown(sender, e);
        }

        private void frmBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnFormClosed(sender, e);
        }

        public void ShowForm(string FormName)
        {
            Form frm = Application.OpenForms.Cast<Form>().Where(x => x.Name == FormName).FirstOrDefault();
            if (frm != null)
            {
                frm.Show();
            }
        }
        protected virtual void OnFormLoad(object sender, EventArgs e)
        {
            
            if (!DesignMode)  Application.DoEvents();
        }
        private void frmBase_Load(object sender, EventArgs e)
        {
            OnFormLoad(sender, e);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            OnCloseButtonClick(sender, e);
        }
    }
}
