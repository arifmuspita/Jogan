using DBProject.Models;
using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.BaseForms
{
    public partial class frmBaseCalibration : Desktop.BaseForms.frmBaseTwinCAT
    {
        private TestReference FTestReference;
        public TestReference TestReference { get { return FTestReference; } set { SetTestReference(value); } }

        private void SetTestReference(TestReference value)
        {
            FTestReference = value;
            Application.DoEvents();
            //calibrationControl.TestReference = value;
            if (!DesignMode)
            {
                switch (value)
                {
                    case TestReference.Noise: FillMachines("NOISE"); FillTypes("NOISE"); break;
                    case TestReference.Signal: FillMachines("SIGNAL"); FillTypes("SIGNAL"); break;
                    case TestReference.Resistance: FillMachines("RESISTANCE"); FillTypes("RESISTANCE"); break;
                }
            }
        }

        private void FillMachines(string MachinesType)
        {
            cmbMachine.Items.Clear();
            using (var db = new DBProjectEntities())
            {
                List<M_MACHINE_TESTER> m = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == MachinesType).OrderBy(x => x.Machine_ID).ToList();
                cmbMachine.DisplayMember = "Machine_Name";
                cmbMachine.ValueMember = "Machine_ID";
                cmbMachine.DataSource = m;
            }
        }
        private void FillTypes(string MachinesType)
        {
            cmbType.Items.Clear();
            using (var db = new DBProjectEntities())
            {
                List<M_GOLDEN_SAMPLE> m = db.M_GOLDEN_SAMPLES.Where(x => x.Device_Test_Ref == MachinesType).OrderBy(x => x.Golden_Sample_Type).ToList();
                cmbType.DisplayMember = "Golden_Sample_Type";
                cmbType.ValueMember = "Golden_Sample_Type";
                cmbType.DataSource = m;
            }
        }
        private void CreateCheckCS()
        {
            int y = 16;
            for (int i = 1; i <= 64; i++)
            {
                new CheckBox
                {
                    Name = "chkSocket" + i.ToString(),
                    Text = "Socket " + i.ToString(),
                    AutoSize = false,
                    Width = 160,
                    Left = 8,
                    Top = y,
                    Parent = pnlCS,
                };
                y = y + 30;
            }
        }
        private void ResetCheckCS()
        {
            for (int i = 1; i <= 64; i++)
            {
                Control chk = pnlCS.Controls["chkSocket" + i.ToString()];
                if (chk != null)
                {
                    ((CheckBox)chk).Checked = false;
                }
            }
        }

        protected override void CreateToolStripButton(bool CreateDefaultButton = true)
        {
            base.CreateToolStripButton(false); int[] arrIdx = { 17,18 };
            string[] arrText = { "Restart", "Start", "Edit", "Delete", "Report" };
            for (int i = 0; i < 2; i++)
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
                    //case 0: btn.Click += new EventHandler(btnEntri_Click); break;
                }
                tsMain.Items.Add(btn);
                tsMain.Items.Add(new ToolStripSeparator { Alignment = ToolStripItemAlignment.Right });
            }
        }
        protected override void OnFormLoad(object sender, EventArgs e)
        {
            base.OnFormLoad(sender, e);
            CreateCheckCS();
        }

        protected override void OnFormShown(object sender, EventArgs e)
        {
            base.OnFormShown(sender, e); 
        }
        public frmBaseCalibration()
        {
            InitializeComponent();
            TestReference = TestReference.None;
        }
    }
}
