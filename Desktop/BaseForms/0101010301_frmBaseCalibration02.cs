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
    public partial class frmBaseCalibration02 : Desktop.BaseForms.frmBaseTwinCAT
    {
        private TestReference FTestReference;
        public TestReference TestReference { get { return FTestReference; } set { SetTestReference(value); } }

        private void SetTestReference(TestReference value)
        {
            FTestReference = value;
            Application.DoEvents();
            calibrationControl.TestReference = value;
            if (!DesignMode)
            {
                switch (value)
                {
                    case TestReference.Noise: FillMachines("NOISE"); break;
                    case TestReference.Signal: FillMachines("SIGNAL"); break;
                    case TestReference.Resistance: FillMachines("RESISTANCE"); break;
                }
            }
        }

        private void FillMachines(string MachinesType)
        {
            cmbMachine.Items.Clear();
            using (var db = new DBProjectEntities())
            {
                List<M_MACHINE_TESTER> m = db.M_MACHINE_TESTERS.Where(x=>x.Machines_Type==MachinesType).OrderBy(x => x.Machine_ID).ToList();
                cmbMachine.DisplayMember = "Machine_Name";
                cmbMachine.ValueMember = "Machine_ID";
                cmbMachine.DataSource = m;
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
        protected override void OnFormLoad(object sender, EventArgs e)
        {
            base.OnFormLoad(sender, e); 
            CreateCheckCS();
        }
        public frmBaseCalibration02()
        {
            InitializeComponent();
            TestReference = TestReference.None;
        }
    }
}
