using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms.Test
{
    public partial class frmSorterTestData : Desktop.BaseForms.frmBaseTwinCAT
    {
        private bool AllowChange { get; set;  }
        public frmSorterTestData()
        {
            InitializeComponent();
            AllowChange = true;
        }
        private int FSelectedTab;
        public int SelectedTab
        {
            get { return FSelectedTab; }
            set { SetSelectedTab(value); }
        }

        private void SetSelectedTab(int value)
        {
            if (value < 0 || value > (tabNormalMode.TabPages.Count - 1))
            {
                MessageBox.Show("Index out range (0-" + (tabNormalMode.TabPages.Count - 1).ToString() + ")");
            }
            else
            {

                AllowChange = false; tabNormalMode.SelectedIndex = value; AllowChange = true;
            }
        }

        private void sorterNormalTestControl1_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void tabNormalMode_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = AllowChange; 
        }

        protected override void CreateToolStripButton(bool CreateDefaultButton = true)
        {
            base.CreateToolStripButton(false);
        }
        protected override void OnFormShown(object sender, EventArgs e)
        {
            base.OnFormShown(sender, e);

            sorterNormalTestControl1.UserID = UserProp.User_ID;
            sorterNormalTestControl2.UserID = UserProp.User_ID;
            sorterNormalTestControl3.UserID = UserProp.User_ID;
            sorterNormalTestControl4.UserID = UserProp.User_ID;

            //sorterNormalTestControl1.DBEntities = DBEntities;
            //sorterNormalTestControl2.DBEntities = DBEntities;
            //sorterNormalTestControl3.DBEntities = DBEntities;
            //sorterNormalTestControl4.DBEntities = DBEntities;
        }
        }
}
