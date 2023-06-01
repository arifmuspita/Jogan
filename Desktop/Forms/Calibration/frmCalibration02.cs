using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms.Calibration
{
    public partial class frmCalibration02 : Desktop.BaseForms.frmBaseTwinCAT
    {
        private string[] MachineType = new string[] { "NOISE", "SIGNAL", "RESISTANCE" };
        public frmCalibration02()
        {
            InitializeComponent();
        }
        private void FillMachines()
        {
            ComboBox cmb = null;
            foreach (string item in MachineType)
            {
                switch (item)
                {
                    case "NOISE": cmb = cmbNoiseMachine; break;
                    case "SIGNAL": cmb = cmbSignalMachine; break;
                    case "RESISTANCE": cmb = cmbResistanceMachine; break;
                }
                cmb.Items.Clear();
                using (var db = new DBProjectEntities())
                {
                    List<M_MACHINE_TESTER> m = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == item).OrderBy(x => x.Machine_ID).ToList();
                    cmb.DisplayMember = "Machine_Name";
                    cmb.ValueMember = "Machine_ID";
                    cmb.DataSource = m;
                }
            }
        }
        private void CreateCheckCS()
        {
            Panel pnl = null;
            foreach (string item in MachineType)
            {
                switch (item)
                {
                    case "NOISE": pnl = pnlNoiseCS; break; 
                    case "SIGNAL": pnl = pnlSignalCS; break; 
                    case "RESISTANCE": pnl = pnlResistanceCS; break;
                }
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
                        Parent = pnl,
                    };
                    y = y + 30;
                }
            }
        }
        private void ResetCheckCS()
        {
            Panel pnl = null;
            foreach (string item in MachineType)
            {
                switch (item)
                {
                    case "NOISE": pnl = pnlNoiseCS; break;
                    case "SIGNAL": pnl = pnlSignalCS; break;
                    case "RESISTANCE": pnl = pnlResistanceCS; break;
                }
                for (int i = 1; i <= 64; i++)
                {
                    Control chk = pnl.Controls["chkSocket" + i.ToString()];
                    if (chk != null)
                    {
                        ((CheckBox)chk).Checked = false;
                    }
                }
            }
        }
        private void tcCalibration_SelectedIndexChanged(object sender, EventArgs e)
        {
            Application.DoEvents();
        }
        protected override void OnFormLoad(object sender, EventArgs e)
        {
            base.OnFormLoad(sender, e);
            if (!DesignMode) FillMachines();
            CreateCheckCS();
        }
    }
}
