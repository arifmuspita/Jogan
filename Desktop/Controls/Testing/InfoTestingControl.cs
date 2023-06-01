using Desktop.BaseControls;
using Desktop.Controls.Info;
using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controls.Testing
{
    public partial class InfoTestingControl : Desktop.BaseControls.BaseTestingItemControl
    {
        

        private List<BaseInfoTestingItemControl> FInfoTestingControlItems;
        [Browsable(false)]
        public List<BaseInfoTestingItemControl> InfoTestingControlItems
        { get
            {
                return FInfoTestingControlItems;
            } 
        }
        private void ToolStripButtonClick(object sender, EventArgs e)
        {
            if (FInfoTestingControlItems.Count > 1)
            {
                ToolStripButton tsb = null;
                for (int i = 0; i <= toolStrip.Items.Count - 1; i++)
                {
                    if (toolStrip.Items[i] is ToolStripButton)
                    {
                        tsb = (ToolStripButton)toolStrip.Items[i];
                        tsb.Checked = false;
                    }
                }
                tsb = (ToolStripButton)sender;
                tsb.Checked = true;
                for (int i = 0; i <= FInfoTestingControlItems.Count - 1; i++)
                {
                    FInfoTestingControlItems[i].Visible = false;
                }
                ((BaseInfoTestingItemControl)tsb.Tag).Visible = true;
                gbMainItem.Text = " " + tsb.Text + " ";
            }
        }
        protected override void SetIndex(int value)
        {
            base.SetIndex(value);
            gbMainItem.Text = "";
        }

        public BaseInfoTestingItemControl SearchItemControl(string ACode)
        {
            BaseInfoTestingItemControl ret;
            ret = FInfoTestingControlItems.Where(x => x.Code == ACode).FirstOrDefault();
            return ret;
        }
        public void AddItem(BaseInfoTestingItemControl Item, bool IsSeperator,int ImageIndex=-1)
        {
          
            if (!IsSeperator)
            {
                Item.Owner = this;
                Item.Dock = DockStyle.Fill;
                Item.Parent = pnlInfo;
                Image img = null;
                if (ImageIndex != -1) { img = imgList.Images[ImageIndex]; }
                ToolStripButton tsb = new ToolStripButton(Item.Caption, img);
                tsb.Text = Item.Caption;
                tsb.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                tsb.CheckOnClick = true;
                tsb.Tag = Item;
                tsb.Click += new EventHandler(ToolStripButtonClick);
                toolStrip.Items.Add(tsb);
                FInfoTestingControlItems.Add(Item);
                gbMainItem.Text = " " + Item.Caption + " ";
            } else
            {
                ToolStripSeparator tss = new ToolStripSeparator(); toolStrip.Items.Add(tss);
            }
            if (toolStrip.Items.Count>0  && (toolStrip.Items[0] is ToolStripButton))
            {
                ((ToolStripButton)toolStrip.Items[0]).Checked = true;
            }
        }
        public void SetActiveItem(int Index)
        {
            if (Index<0 || Index > FInfoTestingControlItems.Count - 1)
            {
                MessageBox.Show("Index out of range (0-" + (FInfoTestingControlItems.Count - 1).ToString() + ")");
                return;
            }
            BaseInfoTestingItemControl b = FInfoTestingControlItems[Index];
            ToolStripButton tsb = null;
            for (int i = 0; i <= toolStrip.Items.Count - 1; i++)
            {
                if (toolStrip.Items[i].Tag==b)
                {
                    tsb = (ToolStripButton)toolStrip.Items[i];
                    break;
                }
            }
            ToolStripButtonClick(tsb, null);
        }
        public InfoTestingControl()
        {
            FInfoTestingControlItems = new List<BaseInfoTestingItemControl>();
            
           // toolStrip.Items.Clear();
            InitializeComponent();
            toolStrip.Items.Clear();
            //AddItem(InfoMessageItemControl, false, 0);
            //AddItem(InfoMessageItemControl, false, 0);
        }
       
        private void pnlInfo_ControlAdded(object sender, ControlEventArgs e)
        {
           // if (sender is BaseInfoTestingItemControl)   AddItem((BaseInfoTestingItemControl)sender, false);
        }
    }
}
