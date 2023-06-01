using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Controls.Info
{
    public partial class InfoMessageItemControl : Desktop.BaseControls.BaseInfoTestingItemControl
    {
        //private InfoMassageControlClass FMessage;
        public InfoMassageControlClass Message
        {
            get { return GetMessage(); }
            set { SetMessage(value); }
        }  

        public InfoMassageImpact ImpactFromString(string Value)
        {
            InfoMassageImpact ret = InfoMassageImpact.None;
            switch (Value)
            {
                case "Low":ret = InfoMassageImpact.Low;break;
                case "Medium":ret = InfoMassageImpact.Medium; break;
                case "High":ret = InfoMassageImpact.High; break;
            }
            return ret;
        }
        private InfoMassageControlClass GetMessage()
        {
            InfoMassageControlClass ret = null;
            if (lvMessage.SelectedItems.Count > 0)
            {
                ListViewItem item = lvMessage.SelectedItems[0];
                // item.
                //ret = new InfoMassageControlClass
                //{
                //    DateTime = Convert.ToDateTime(item.Text),
                //    Message = item.SubItems[0].Text,
                //    Priorty = PriorityFromString(item.SubItems[2].Text)
                //}
                ret = (InfoMassageControlClass)item.Tag;
            }
            return ret;
        }

        public void SetMessageLV(InfoMassageControlClass value = null)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<InfoMassageControlClass>(SetMessageLV), new object[] { value });
                return;
            }

            ListViewItem item = new ListViewItem
            {
                Text = value.DateTime.ToString("yyyy/MM/dd hh:mm:ss"),
                Tag = value
            };
            item.SubItems.Add(value.Sender);
            item.SubItems.Add(value.Message);
            item.SubItems.Add(value.Impact.ToString());
            lvMessage.SuspendLayout();
            lvMessage.Items.Insert(0, item);
            lvMessage.ResumeLayout();
        }
        private void SetMessage(InfoMassageControlClass value)
        {
            if (value!=null){
                SetMessageLV(value);
                //ListViewItem item = new ListViewItem
                //{
                //    Text = value.DateTime.ToString("yyyy/MM/dd hh:mm:ss"),
                //    Tag = value
                //};
                //item.SubItems.Add(value.Sender);
                //item.SubItems.Add(value.Message);
                //item.SubItems.Add(value.Impact.ToString());
                //lvMessage.SuspendLayout();
                //lvMessage.Items.Insert(0, item);
                //lvMessage.ResumeLayout();
            }
        } 
        private void lvMessage_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex==3)
            {
                InfoMassageControlClass msg = (InfoMassageControlClass)e.Item.Tag;
                e.DrawDefault = false;
                e.DrawBackground();
                Image img = imgLV.Images[0];
                int space = 2;
                Rectangle rect = e.SubItem.Bounds;
                Point p = rect.Location;
                switch (msg.Impact)
                {
                    case InfoMassageImpact.Low:
                        e.Graphics.DrawImage(img, p);
                        break;
                    case InfoMassageImpact.Medium:
                        e.Graphics.DrawImage(img, p);
                        p.X = p.X + space + img.Width;
                        e.Graphics.DrawImage(img, p);
                        break;
                    case InfoMassageImpact.High:
                        e.Graphics.DrawImage(img, p);
                        p.X = p.X + space + img.Width;
                        e.Graphics.DrawImage(img, p);
                        p.X = p.X + space + img.Width;
                        e.Graphics.DrawImage(img, p);
                        break;
                }
                //e.graphics.drawimage(my.resources.image1, e.subitem.bounds.location);
                //e.graphics.drawstring(e.subitem.text, e.subitem.font, new solidbrush(e.subitem.forecolor), (e.subitem.bounds.location.x + my.resources.image1.width), e.subitem.bounds.location.y);
            }
            else
            {
                e.DrawDefault = true;
            }
        }
        private void lvMessage_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void lvMessage_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (lvMessage.SelectedItems.Count > 0)
            //{
            //    ListViewItem item = lvMessage.SelectedItems[0]; 
            //    FMessage = new InfoMassageControlClass
            //    {
            //        DateTime = Convert.ToDateTime(item.Text),
            //        Message=item.S
            //}
            //}
            //else
            //{
            //    EmpIDtextBox.Text = string.Empty;
            //    EmpNametextBox.Text = string.Empty;
            //}
        }
        public InfoMessageItemControl()
        {
            //FMessage = null;
            InitializeComponent();
        }

        private void lvMessage_Resize(object sender, EventArgs e)
        {
            lvMessage.Columns[2].Width = Width - 300 - 40;
        }
    }
}
