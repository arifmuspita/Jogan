using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.BaseComponents
{
    public class PanelMessage:Panel
    {
        private Button FButton;
        //private Control FParentControl;
        private Panel FPanel;
        private Label FTextBox;
        //private string FMassage;
        public event EventHandler OnCloseClick;
        private void ButtonClick(object sender, EventArgs e)
        {
            this.Visible = false;
            if (OnCloseClick != null) { OnCloseClick(sender, e); }
        }
        public PanelMessage()
        {
            //FMainPanel = new Panel();
            this.BackColor = System.Drawing.Color.FromArgb(50, 255, 192, 255);
            //this.Dock = DockStyle.Fill;
            //this.Parent = ParentControl;
            this.Visible = false;


            FTextBox = new Label();
            //FTextBox.BackColor = System.Drawing.Color.FromArgb( 255, 192, 255);
            FTextBox.Dock = DockStyle.Fill;
            FTextBox.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //FTextBox.Multiline = true;
            //FTextBox.ReadOnly = true;
            //FTextBox.ScrollBars = ScrollBars.Vertical;
            
            FTextBox.Parent = this;


            FPanel = new Panel();
            FPanel.BackColor = System.Drawing.Color.FromArgb(50, 255, 192, 255);
            FPanel.Dock = DockStyle.Bottom;
            FPanel.Parent = this;
            FPanel.Height = 40;

            FButton = new Button();
            //FButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //| System.Windows.Forms.AnchorStyles.Left)
            //| System.Windows.Forms.AnchorStyles.Right)));
            FButton.Height = 30;
            FButton.Width = 60;
            int x = (FPanel.Width - FButton.Width) / 2;
            int y = (FPanel.Height - FButton.Height) / 2;
            FButton.Location = new System.Drawing.Point(x, y);
            FButton.Parent = FPanel;
            FButton.Text = "Close";
            FButton.Click += new System.EventHandler(ButtonClick);
        }

       // [Browsable(false)]
        public string Message
        {
            get { return FTextBox.Text; }
            set {
                FTextBox.Text = value;
               // FTextBox.Text = FTextBox.Text + "\r\n" + Parent.Name;
                //FTextBox.ForeColor = Color.Red;
                if (Parent != null)
                {
                    this.Height = Parent.Height;
                    this.Width = Parent.Width;
                }
                this.Location = new System.Drawing.Point(0,0);
                this.Visible = true;
                this.BringToFront();
            }
        }

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            int x = (FPanel.Width - FButton.Width) / 2;
            int y = (FPanel.Height - FButton.Height) / 2;
            FButton.Location = new System.Drawing.Point(x, y);
        }

        //public Control ParentControl
        //{
        //    get { return FParentControl; }
        //    set { FParentControl = value; }
        //}
    }
}
