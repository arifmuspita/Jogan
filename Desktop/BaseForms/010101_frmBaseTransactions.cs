using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Desktop.BaseForms
{
    public partial class frmBaseTransactions : Desktop.BaseForms.frmBaseDB
    {
        public frmBaseTransactions()
        {
            InitializeComponent();
        }

        protected virtual void OnAfterSave() { }
        protected virtual void OnBeforeSave() { }
        protected virtual void AddData() { }
        protected virtual void EditData() { }
        protected virtual void DeleteData() { }
        protected virtual void Report() { }

        protected virtual void CreateToolStripButton(bool CreateDefaultButton=true)
        {
            for (int i = tsMain.Items.Count - 1; i >= 0; i--)
            {
                if (i >2)
                {
                    ToolStripItem tsi = tsMain.Items[i];
                    tsMain.Items.RemoveAt(i);
                    tsi.Dispose();
                }
            }
            if (CreateDefaultButton)
            {
                int[] arrIdx = { 13, 14, 15, 16, 8 };
                string[] arrText = { "Save", "Add", "Edit", "Delete", "Report" };
                for (int i = 0; i < 5; i++)
                {
                    Image img = imageList.Images[arrIdx[i]];
                    ToolStripButton btn = new ToolStripButton();
                    btn.Alignment = ToolStripItemAlignment.Right;
                    btn.CheckOnClick = true;
                    btn.Checked = false;
                    btn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                    btn.Image = img;
                    btn.Text = arrText[i];
                    switch (i)
                    {
                        case 0: btn.Click += new EventHandler(btnReport_Click); break;
                        case 1: btn.Click += new EventHandler(btnDelete_Click); break;
                        case 2: btn.Click += new EventHandler(btnEdit_Click); break;
                        case 3: btn.Click += new EventHandler(btnAdd_Click); break;
                        case 4: btn.Click += new EventHandler(btnSave_Click); break;
                    }
                    tsMain.Items.Add(btn);
                    tsMain.Items.Add(new ToolStripSeparator { Alignment = ToolStripItemAlignment.Right });
                }
            }
        }

        protected override void OnFormLoad(object sender, EventArgs e)
        {
            base.OnFormLoad(sender, e);
            CreateToolStripButton();
        }

        protected override void OnFormShown(object sender, EventArgs e)
        {
            base.OnFormShown(sender, e);
            
        }

        private void UnCheckOtherButton(object sender)
        {
            for (int i = tsMain.Items.Count - 1; i >= 0; i--)
            {
                if (tsMain.Items[i] is ToolStripButton)
                {
                    ToolStripButton tsb = (ToolStripButton)tsMain.Items[i];
                    tsb.Checked = false;
                }
            }
            ((ToolStripButton)sender).Checked = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            UnCheckOtherButton(sender);
            OnBeforeSave();
            if (SaveData()) { OnAfterSave(); }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UnCheckOtherButton(sender);
            AddData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UnCheckOtherButton(sender);
            EditData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            UnCheckOtherButton(sender);
            DeleteData();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            UnCheckOtherButton(sender);
            Report();
        }
        protected override void OnCloseButtonClick(object sender, EventArgs e)
        {
            UnCheckOtherButton(sender);
            Close();
        }
    }
}
