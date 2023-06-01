using Desktop.BaseForms;
using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwinCAT.Ads;
using Utilities;

namespace Desktop.Forms.TurnOnOff
{
    public partial class frmTurnOnOff : Desktop.BaseForms.frmBaseTwinCAT
    {
        private string[] GroupBoxName = { "gbSMC", "gbCKD", "gbRobot", "gbPLCTester", "gbPCTester" };
        private bool FChecked;
        private List<Control> ControlList = new List<Control>();
        private bool GetControllerChecked()
        {
            bool ret = false; ControlList.Clear();
            GetAllControls(this);
            foreach (Control c in ControlList)
            {
                if (c is CheckBox)
                {
                    ret = ret || ((CheckBox)c).Checked;
                }
            }
            return ret;
        }
        private void GetAllControls(Control container)
        {
            foreach (Control c in container.Controls)
            {
                GetAllControls(c);
                ControlList.Add(c);
            }
        }
        private void ResetGUI(RadioButton RadioButtonOption)
        {
            ControlList.Clear();
            GetAllControls(this);
            
            //List<Control> c1 = Controls.OfType<GroupBox>().Cast<Control>().ToList();

            foreach (string nm in GroupBoxName)
            {
                object gb = ControlList.Find(x => x.Name == nm);
                if (gb != null)
                {
                    GroupBox gb2 = (GroupBox)gb;
                    List<Control> c2 = gb2.Controls.OfType<CheckBox>().Cast<Control>().ToList();
                    foreach (CheckBox item in c2)
                    {
                        CheckBox ck = (CheckBox)item;
                        ck.Checked = RadioButtonOption == rbAuto;
                        //ck.Enabled = !(RadioButtonOption == rbAuto);
                        //txt.CheckedChanged += new System.EventHandler(CheckedBoxChanged);
                    }
                }
            }
        }

        protected override void CreateToolStripButton(bool CreateDefaultButton = true)
        {
            base.CreateToolStripButton(false);
        }
        protected override void OnFormLoad(object sender, EventArgs e)
        {
            base.OnFormLoad(sender, e);

            NetID = ConfigurationManager.AppSettings["TwinCatNetID"];
            // string urlbase = ConfigurationManager.AppSettings["GVLRoots"];
            //string[] arryGVLRoots = urlbase.Split(',');
            //TwinCat3Utility.ExtractPLCSymbols(arryGVLRoots);// new string[] { "SMC", "CKD", "Robot","PLCTester","PCTester" });
            TwinCat3Utility.ConnectPLC(NetID);
            //add plc variable
            TwinCat3Utility.AddPLCVariable("POWER_CONTROL.O_PWR_CTRL_INDEXING_1", lblCKDOnOf1, chkCKDOnOf1);
            //TwinCat3Utility.AddPLCVariable("POWER_CONTROL.O_PWR_CTRL_INDEXING_2", lblSMCOnOf2, chkCKDOnOf2);
            //TwinCat3Utility.AddPLCVariable("POWER_CONTROL.O_PWR_CTRL_PC_1", lblPCTesterNoise1, chkPCTesterNoise1);
            TwinCat3Utility.AddPLCVariable("POWER_CONTROL.O_PWR_CTRL_ROBOT_G6", lblG6OnOf, chkG6OnOf);

            TwinCat3Utility.AddPLCVariable("INDEXING_1_VAR.I_INDEXING_1_HOME", lblCKDOnOf1, chkCKDOnOf1);
            TwinCat3Utility.AddPLCVariable("G6.I_G6_HOME", lblG6OnOf, chkG6OnOf);

            FChecked = false;
            TwinCat3Utility.TwinCat3Client.AdsNotification += new AdsNotificationEventHandler(OnNotification);
        }

        //private void OnPLCValueChanged(TwinCat3Property sender)
        //{

        //}

        private void OnNotification(object sender, AdsNotificationEventArgs e)
        {
            TwinCat3Property prop = TwinCat3Utility.TwinCat3PropertyList.Where(x => x.DeviceNotificationHandle == e.NotificationHandle).FirstOrDefault();
            if (prop != null)
            {
                bool val = false;
                //string nm = ((TwinCat3Property)e.UserData).VariableName;
                //TwinCat3Property prop = (TwinCat3Property)e.UserData;
                //nm = nm.Substring(nm.IndexOf(".") + 1);
                //Label lbl = (Label)Controls.Find("lbl" + nm, true).FirstOrDefault();
                Label lbl = (Label)prop.DataObject1;
                val = TwinCat3Utility.BinaryReader.ReadBoolean();
                int idx = prop.VariableName.IndexOf("HOME");
                if (idx != -1)
                {
                    if (lbl != null)
                    {
                        lbl.Text = val ? "On" : "Off";
                        lbl.ForeColor = val ? Color.Lime : Color.Red;
                    }

                    chkCKDOnOf1.Checked = val;
                    CheckBox chk = (CheckBox)prop.DataObject2;// Controls.Find("chk" + nm, true).FirstOrDefault();
                    if (chk != null)
                    {
                        chk.Checked = val;
                    }
                    FChecked = FChecked || val;

                    if (!FChecked)
                    {
                        btnOn.Enabled = true;
                        btnOff.Enabled = false;
                    }
                    else
                    {
                        btnOn.Enabled = true;
                        btnOff.Enabled = true;
                    }
                }
                //Label lbl =
                //strValue = BinaryReader.ReadBoolean().ToString();
            }
        } 
        public frmTurnOnOff()
        {
            InitializeComponent();
            btnOn.Width = 124;
            btnOff.Width = 124;
        }

        private void rbAuto_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            ResetGUI(rb);
            //btnOn.Enabled = (rb == rbAuto) || (rb == rbManual && GetControllerChecked());
            //btnOn.Enabled = (rb == rbAuto) || (rb == rbManual && GetControllerChecked());
            
        }

        private void CheckedBoxChanged(object sender, EventArgs e)
        {
           // btnOn.Enabled = (rbManual.Checked && GetControllerChecked());
        }

        private void btnOnOff_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tag1 = (string)btn.Tag;
            string tag2 = "";
            foreach (string nm in GroupBoxName)
            {
                GroupBox gb = (GroupBox)Controls.Find(nm,true).FirstOrDefault();
                if (gb != null)
                {
                    GroupBox gb2 = (GroupBox)gb;
                    List<Control> c2 = gb2.Controls.OfType<CheckBox>().Cast<Control>().ToList();
                    foreach (CheckBox item in c2)
                    {
                        
                        CheckBox ck = (CheckBox)item;
                        if (ck.Checked)
                        {
                            tag2 = (string)ck.Tag;
                            bool valread = (bool)TwinCat3Utility.ReadAnyFromPLC(tag2, TypeOfData.tpBool);
                            if (valread == null) valread = false;
                            bool boolwrite = false;
                            //switch on
                            if (tag1 == "1")
                            {
                                boolwrite = ck.Checked && !valread;
                                if (boolwrite) TwinCat3Utility.WriteAnyToPLC(tag2, TypeOfData.tpBool, true);
                            }
                            //switch off
                            if (tag1 == "2")
                            {
                                boolwrite = ck.Checked && valread;
                                if (boolwrite) TwinCat3Utility.WriteAnyToPLC(tag2, TypeOfData.tpBool, false);
                            }
                        }
                    }
                }
            }
        }

        private void btnShutdown_Click(object sender, EventArgs e)
        {
            //
        }

        private void frmTurnOnOff_Activated(object sender, EventArgs e)
        {
           
        }
    }
}
