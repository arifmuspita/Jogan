using DBProject.Models;
using Desktop.BaseForms;
using Desktop.Controls.Info;
using Desktop.DesktopProperties;
using Desktop.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using TwinCAT.Ads;
using Desktop.Controls.Testing;
using Commons;
using Desktop.Forms.Test;

namespace Desktop
{
    public partial class frmMain : frmBaseTwinCAT
    {
        private JoganUtility JoganUtility;
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            JoganUtility.EndProcess = true;
            JoganUtility.Dispose();
        }
        private bool FWait;
        private async void Delay()
        {
            while (FWait)
            {
                await Task.Delay(10);
            }
        }
        public frmMain()
        {
            //RunApplicationOn = "HMI2";
            //string os = JCS.OSVersionInfo.Name;
            FWait = true;
            //if (os == "Windows 7") RunApplicationOn = "HMI1";
            InitializeComponent();
            // testingControl.FukudaTestingControlItem(0).StartBlinking = true;
            NetID = ConfigurationManager.AppSettings["TwinCatNetID"];
            JoganUtility = new JoganUtility(NetID);
            JoganUtility.NetID = NetID;
            JoganUtility.RunApplicationOn = Commons.Commons.GetEnumFromString<HMISide>(ConfigurationManager.AppSettings["HMISide"]); ;
            JoganUtility.JoganFunctionAs = Commons.Commons.GetEnumFromString<JoganFunctionAs>(ConfigurationManager.AppSettings["JoganFunctionAs"]);
            //JoganUtility.AllowConnect = true;

            JoganUtility.OnNewMessage += new EventMessage(OnNewMessage);
            JoganUtility.OnUnloadingStation += new EventUnloadingStation(OnUnloadingStation);
            JoganUtility.OnEventMachineTester += new EventMachineTester(OnEventMachineTester);
            JoganUtility.OnInfoMachineTester += new EventInfoMachineTester(OnInfoMachineTester);
            JoganUtility.OnBeforeStartMachineTester += new EventInfoMachineTester(OnBeforeStartMachineTester);
            JoganUtility.OnBeforeStopMachineTester += new EventInfoMachineTester(OnBeforeStopMachineTester);
            JoganUtility.OnAfterStopMachineTester += new EventInfoMachineTester(OnAfterStopMachineTester);
            JoganUtility.OnJoganUtilityPLCNotification += new TwinCAT.Ads.AdsNotificationEventHandler(JoganUtilityPLCNotification);
            //for (int i=1;i<=10;i++) JoganUtility.CreateDummyTestData("PO0000000006", i.ToString(), "T-002"); 
            //for (int i = 1; i <= 10; i++) JoganUtility.PrepareAvailableSocketData();
            //for (int i = 1; i <= 10; i++) JoganUtility.PrepareListTestResult("PO0000000006", i.ToString(), "T-002");
            //JoganUtility.PrepareAvailableSocketData();
            //JoganUtility.Start(StartThreadFor.FukudaSimulation);
            //JoganUtility.Start(StartThreadFor.MachineSimulation);
            FWait = false;

            using (var db = new DBProjectEntities())
            {
                db.Database.ExecuteSqlCommand(
                "delete from T_MACHINE_BOOKING; " +
                "DBCC CHECKIDENT ('T_MACHINE_BOOKING', RESEED, 0);" +
                "delete from T_BOOKING_STATION;" +
                "DBCC CHECKIDENT ('T_BOOKING_STATION', RESEED, 0);" +
                "update T_TRANSACTION_INPUT set LotBox_Position_Fukuda = 0, Status = 'Queue';"
                );
            }
            //ScanJogan();

        }

       

        #region Create Button Menus
        private void ButtonAccessClick(object sender, EventArgs e)
        {
            string module = (string)((ToolStripMenuItem)sender).Tag;
            try
            {
                Form form = OpenForm("frm" + module, null, new Size(800, 600), UserProp);
                frmBaseDB formDB = (form as frmBaseDB);
                // formDB.UserProp = UserProp; 
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                var fullErrorMessage = string.Join("<br/>", errorMessages);
                string msg = "The validation errors are: <br/>" + fullErrorMessage;

                MessageBox.Show(msg);
            }
            catch (Exception ee)
            {
                string msg = ee.Message;
                if (ee.InnerException != null)
                {
                    msg = msg + "\r\n" + ee.InnerException.Message;
                    if (ee.InnerException.InnerException != null)
                    {
                        msg = msg + "\r\n" + ee.InnerException.InnerException.Message;
                    }
                }
                MessageBox.Show(msg);
            }
        }
        private List<Button> MenuButtonsParent;
        private List<Button> MenuButtonsChild;
        private void ClearMenuButtons(string ParentModule, bool AllMenu = false)
        {
            if (ParentModule == "" || AllMenu)
            {
                for (int i = MenuButtonsParent.Count - 1; i >= 0; i--)
                {
                    Button btn = MenuButtonsParent[i];
                    pnlMenuTop.Controls.Remove(btn);
                    MenuButtonsParent.Remove(btn);
                    btn.Dispose();
                }
            }
            if (ParentModule != "" || AllMenu)
            {
                for (int i = MenuButtonsChild.Count - 1; i >= 0; i--)
                {
                    Button btn = MenuButtonsChild[i];
                    pnlMenuBottom.Controls.Remove(btn);
                    MenuButtonsChild.Remove(btn);
                    btn.Dispose();
                }
            }
        }
        private void CreateMenuButtons(string ParentModule)
        {
            ClearMenuButtons(ParentModule);
            using (var db = new DBProjectEntities())
            {
                if (UserProp.User_Group_ID.ToUpper() == "G-001")
                {
                    List<M_MENU> m = db.M_MENUS.Where(x => x.Module_Parent == ParentModule && x.Menu_For == "Desktop").OrderBy(x => x.Code).ToList();
                    foreach (var item in m)
                    {
                        Button btn = new Button();
                        btn.BackColor = Color.FromArgb(225, 225, 225);
                        btn.Text = item.Name;
                        btn.Tag = item.Module;
                        List<Button> CurrMenu;
                        if (ParentModule == "")
                        {
                            CurrMenu = MenuButtonsParent;
                            btn.Click += new EventHandler(ButtonAccessParentClick);
                            btn.Parent = pnlMenuTop;
                        }
                        else
                        {
                            CurrMenu = MenuButtonsChild;
                            btn.Click += new EventHandler(ButtonAccessChildClick);
                            btn.Parent = pnlMenuBottom;
                        }
                        btn.Width = 100;
                        btn.Height = btn.Parent.Height - 8;
                        btn.Top = (btn.Parent.Height - btn.Height) / 2;

                        if (CurrMenu.Count == 0)
                        {
                            btn.Left = 8;
                        }
                        else
                        {
                            btn.Left = CurrMenu[CurrMenu.Count - 1].Left + btn.Width + 8;
                        }
                        CurrMenu.Add(btn);
                    }
                }
            }
        }
        private void ButtonAccessParentClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tag = (string)btn.Tag;
            foreach (Button btn1 in MenuButtonsParent)
            {
                btn1.BackColor = Color.FromArgb(225, 225, 225);
            }
            btn.BackColor = Color.FromArgb(229, 241, 251);
            CreateMenuToolStripButton(tag);
        }
        private void ButtonAccessChildClick(object sender, EventArgs e)
        {
            string module = (string)((Button)sender).Tag;

            if (module == "Calibration" || module == "NoiseCalibration" || module == "SignalCalibration" || module == "ResistanceCalibration")
            {
                Form form = OpenForm("frm" + module, null, new Size(700, 740), UserProp);
            }
            else
            {
                Form form = OpenForm("frm" + module, null, new Size(0, 0), UserProp);
            }
            // frmBaseDB formDB = (form as frmBaseDB);
            //formDB.UserProp = UserProp;
        }
        #endregion
        #region Create ToolStrip Menus
        private void ClearMenuToolStripItem(string ParentModule, bool AllMenu = false)
        {
            if (ParentModule == "" || AllMenu)
            {
                for (int i = toolStripMain.Items.Count - 1; i >= 0; i--)
                {
                    if (i > 5)
                    {
                        ToolStripItem tsi = toolStripMain.Items[i];
                        toolStripMain.Items.RemoveAt(i);
                        tsi.Dispose();
                    }
                }
            }
            if (ParentModule != "" || AllMenu)
            {
                for (int i = toolStripChild.Items.Count - 1; i >= 0; i--)
                {
                    ToolStripItem tsi = toolStripChild.Items[i];
                    toolStripChild.Items.RemoveAt(i);
                    tsi.Dispose();
                }
            }
        }
        private void ToolStripButtonParentClick(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            string tag = (string)btn.Tag;
            for (int i = 6; i <= toolStripMain.Items.Count - 1; i++)
            {
                if (toolStripMain.Items[i] is ToolStripButton)
                {
                    ToolStripButton tsb = (ToolStripButton)toolStripMain.Items[i];
                    tsb.Checked = false;
                }
            }
            btn.Checked = true;
            CreateMenuToolStripButton(tag);
        }
        private void ToolStripButtonChildClick(object sender, EventArgs e)
        {
            ToolStripButton btn = (ToolStripButton)sender;
            for (int i = 0; i <= toolStripChild.Items.Count - 1; i++)
            {
                if (toolStripChild.Items[i] is ToolStripButton)
                {
                    ToolStripButton tsb = (ToolStripButton)toolStripChild.Items[i];
                    tsb.Checked = false;
                }
            }
            btn.Checked = true;
            string module = (string)((ToolStripButton)sender).Tag;

            if (module == "Calibration" || module == "NoiseCalibration" || module == "SignalCalibration" || module == "ResistanceCalibration")
            {
                Form form = OpenForm("frm" + module, null, new Size(700, 740), UserProp);
            }
            else
            {
                Form form = OpenForm("frm" + module, null, new Size(0, 0), UserProp);
            }
            // frmBaseDB formDB = (form as frmBaseDB);
            //formDB.UserProp = UserProp;
        }
        private void CreateMenuToolStripButton(string ParentModule)
        {
            ClearMenuToolStripItem(ParentModule);
            using (var db = new DBProjectEntities())
            {
                if (UserProp.User_Group_ID.ToUpper() == "G-001")
                {
                    List<M_MENU> m = db.M_MENUS.Where(x => x.Module_Parent == ParentModule && x.Menu_For == "Desktop" && x.Is_Active).OrderBy(x => x.Code).ToList();
                    foreach (var item in m)
                    {
                        Image img = null;
                        if (item.Image_Index != null) img = imageList.Images[(int)item.Image_Index];
                        ToolStripButton btn = new ToolStripButton();
                        btn.Alignment = ToolStripItemAlignment.Left;
                        btn.Checked = false; btn.CheckOnClick = true;
                        btn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                        btn.Image = img;
                        btn.Text = item.Name;
                        btn.Tag = item.Module;
                        if (ParentModule == "")
                        {
                            toolStripMain.Items.Add(btn);
                            toolStripMain.Items.Add(new ToolStripSeparator { Alignment = ToolStripItemAlignment.Left });
                            btn.Click += new EventHandler(ToolStripButtonParentClick);
                        }
                        else
                        {
                            toolStripChild.Items.Add(btn);
                            toolStripChild.Items.Add(new ToolStripSeparator { Alignment = ToolStripItemAlignment.Left });
                            btn.Click += new EventHandler(ToolStripButtonChildClick);
                        }
                    }
                }
            }
        }
        #endregion
        #region Login/Logout
        private void OpenLogin()
        {
            Form form = OpenForm("frmLogin");
            form.Width = 400;
            form.Height = 300;
            ((frmLogin)form).OnLogin += new LoginHandler(OnLogin);
            form.ShowDialog();
        }
        private void frmMain_Shown(object sender, EventArgs e)
        {
            OpenLogin();
        }
        private void OnLogin(object sender, UserProp AUserProp, LoginStatus ALoginStatus)
        {
            UserProp = AUserProp;

            JoganUtility.JoganUserID = "";
            if (ALoginStatus == LoginStatus.lsSucceed)
            {
                JoganUtility.JoganUserID = UserProp.User_ID;
                if (UserProp.User_Group_ID.ToUpper() == "G-001")
                {
                    //CreateMenuButtons("");
                    CreateMenuToolStripButton("");
                    using (var db = new DBProjectEntities())
                    {
                        M_MENU m = db.M_MENUS.Where(x => x.Menu_For == "Desktop" && x.Module_Parent == "").First();
                        //MenuButtonsParent[0].Focus();
                        //MenuButtonsParent[0].BackColor = Color.FromArgb(229, 241, 251);
                        //CreateMenuButtons(m.Module);
                        CreateMenuToolStripButton(m.Module);
                    }
                }
                else
                {

                }
                //for (int i = menuStrip.Items.Count - 1; i > 0; i--) menuStrip.Items.Remove(menuStrip.Items[i]);
                //using (var db = new DBProjectEntities())
                //{
                //    ToolStripMenuItem mnPrnt = null;
                //    ToolStripMenuItem mnChild= null;
                //    if (UserProp.User_Group_ID.ToUpper() == "G-001")
                //    {
                //        var mn = db.M_MENUS.Where(x => x.Menu_For == "Desktop" && x.Is_Active).OrderBy(x => x.Code);
                //        foreach (var item in mn)
                //        {
                //            if (item.Detail)
                //            {
                //                mnChild = new ToolStripMenuItem(item.Name);
                //                mnChild.Tag = item.Module;
                //                mnChild.Click += new EventHandler(ButtonAccessClick);
                //                mnPrnt.DropDownItems.Add(mnChild);
                //            }
                //            else
                //            {
                //                mnPrnt = new ToolStripMenuItem(item.Name);
                //                menuStrip.Items.Add(mnPrnt);
                //            }
                //        }
                //    }                    
                //}
                btnLogout.Enabled = true;
                btnLogin.Enabled = false;
            }
            FWait = false;
            JoganUtility.AllowConnect = true;
            //JoganUtility.PrepareAvailableSocketData();
            JoganUtility.WriteAnyToPLC("INPUT_VAR.I_LOTEND", TypeOfData.tpBool, true);
        }
        private void mnLogout_Click(object sender, EventArgs e)
        {
            AddLoginHistory(DBEntities, UserProp.User_ID, "LOGOUT");
            DBEntities.SaveChanges();
            UserProp = null;
            //for (int i = menuStrip.Items.Count - 1; i > 0; i--) menuStrip.Items.Remove(menuStrip.Items[i]);
            //OpenForm("frmLogin", this, new Size(800,600));
        }
        private void mnLogin_Click(object sender, EventArgs e)
        {
            // OpenForm("frmLogin", null, new Size(400, 300));
            //Form form = OpenForm("frmLogin");
            //form.MdiParent = this;
            //form.Width = 400;
            //form.Height = 300;
            //((JOGAN.Forms.frmLogin)form).OnLogin += new LoginHandler(OnLogin);
            //form.Show();
            //form.BringToFront();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpenLogin();
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            AddLoginHistory(DBEntities, UserProp.User_ID, "LOGOUT");
            DBEntities.SaveChanges();
            UserProp = null;
            btnLogout.Enabled = false;
            btnLogin.Enabled = true;
            ClearMenuButtons("", true);
            OpenLogin();
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            OpenLogin();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            AddLoginHistory(DBEntities, UserProp.User_ID, "LOGOUT");
            DBEntities.SaveChanges();
            UserProp = null;
            btnLogout.Enabled = false;
            btnLogin.Enabled = true;
            // ClearMenuButtons("", true);
            ClearMenuToolStripItem("", true);
            OpenLogin();
        }
        #endregion
        private void mnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            pnlMenuTop.Height = pnlBottom.Height / 2;
            MenuButtonsParent = new List<Button>();
            MenuButtonsChild = new List<Button>();

            CreateMessage();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CreateMessage()
        {
            testingControl.InfoTestingControl.AddItem(new InfoMessageItemControl { Caption = "Messages", Code = "Messages" }, false, 0);

            InfoMessageItemControl msg = (InfoMessageItemControl)testingControl.InfoTestingControl.InfoTestingControlItems[0];
            using (var db = new DBProjectEntities())
            {
                List<V_MESSAGE> el = db.Database.SqlQuery<V_MESSAGE>("select  * from V_MESSAGE tel where  convert(varchar(10), tel.created_date, 120) = '" + DateTime.Today.ToString("yyyy-MM-dd") + "'").ToList();
                foreach (var item in el)
                {
                    msg.Message = new InfoMassageControlClass
                    {
                        DateTime = DateTime.Now,
                        Message = item.Message_Name,
                        Impact = msg.ImpactFromString(item.Impact),
                        Sender = item.Hardware_ID
                    };
                }
            }
        }

        public void MoveWindowToProjector()
        {
            Rectangle rectMonitor;

            // Create New Process
            Process objProcess = new Process();

            //Get All the screens associated with this Monitor
            Screen[] screens = Screen.AllScreens;

            // Get Monitor Count
            int iMonitorCount = Screen.AllScreens.Length;

            // Get Parameters of Current Project
            string[] parametros = Environment.GetCommandLineArgs();
            // if (parametros.Length > 0)
            // {
            //objProcess.StartInfo.FileName = parametros[0];
            // objProcess.Start();
            //  }
            // Get Window Handle of this Form
            IntPtr hWnd = this.Handle;

            Thread.Sleep(1000);


            //if (IsProjectorMode)
            //{
            //    if (iMonitorCount > 1) // If monitor Count 2 or more
            //    {
            //        //Get the Dimension of the monitor
            //        rectMonitor = Screen.AllScreens[1].WorkingArea;
            //    }
            //    else
            //    {
            //        //Get the Dimension of the monitor
            //        rectMonitor = Screen.AllScreens[0].WorkingArea;
            //    }

            //}
            //else
            //{
            //    rectMonitor = Screen.AllScreens[0].WorkingArea;

            //}
            //if (hWnd != IntPtr.Zero)
            //{
            //    SetWindowPos(hWnd, 0,
            //        rectMonitor.Left, rectMonitor.Top, rectMonitor.Width,
            //        rectMonitor.Height, SWP_SHOWWINDOW);
            //}

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region Scan Running Processed
        private void ScanFukuda()
        {
            using (var db = new DBProjectEntities())
            {
                FukudaTestingControl ftc = null;
                List<V_PONUMBER_DEVICE> po = db.Database.SqlQuery<V_PONUMBER_DEVICE>("select * from V_PONUMBER_DEVICE where Status = 'STANDBY' ").ToList();
                foreach (var item in po)
                {
                    switch (item.LotBox_Position_Fukuda)
                    {
                        case 1: ftc = testingControl.FukudaTestingControlItem(0); break;
                        case 2: ftc = testingControl.FukudaTestingControlItem(1); break;
                        case 3: ftc = testingControl.FukudaTestingControlItem(2); break;
                        case 4: ftc = testingControl.FukudaTestingControlItem(3); break;
                    }
                    ftc.Code = item.PO_Number;
                    ftc.Value =
                        new FukudaTestingControlClass
                        {
                            DeviceID = item.Device_ID,
                            DeviceName = item.Device_Name,
                            LotboxID = item.LotBox_ID,
                            PONumber = item.PO_Number,
                            Quantity = item.Quantity,
                            Status = StatusTestingControl.Standby,
                            TestMode = item.Test_Mode_Default
                        };
                }
            }
        }
        private void ScanJogan()
        {
            ScanFukuda();
        }
        #endregion
        private void FukudaTestingItemControl(bool Value, string VariableName)
        {

            FukudaTestingControl ftc = null;
            int idx = 0;
            switch (VariableName)
            {
                case "INPUT_VAR.I_LOTBOX_DETECT_1": ftc = testingControl.FukudaTestingControlItem(0); idx = 0; break;
                case "INPUT_VAR.I_LOTBOX_DETECT_2": ftc = testingControl.FukudaTestingControlItem(1); idx = 1; break;
                case "INPUT_VAR.I_LOTBOX_DETECT_3": ftc = testingControl.FukudaTestingControlItem(2); idx = 2; break;
                case "INPUT_VAR.I_LOTBOX_DETECT_4": ftc = testingControl.FukudaTestingControlItem(3); idx = 3; break;
            }
            if (Value)
            {
                ftc.Value = null;
                ftc.Status = StatusTestingControl.Empty;
            }
            if (!Value)
            {
                ftc.Status = StatusTestingControl.Attached;
                if (String.IsNullOrEmpty(ftc.Code))
                {
                    //OpenForm("frmInputTestData", null, new Size(800, 650), UserProp,
                    // delegate (Form sender)
                    // {
                    //     ((frmInputTestData)sender).SelectedTab = idx;
                    // }
                    // );
                }
            }
        }
        private void LaserTestingItemControl(bool Value, string VariableName)
        {

            LaserTestingControl ftc = null;
            int idx = 0;
            switch (VariableName)
            {
                case "SORTER_VAR.I_LOTBOX_DETECT_1": ftc = testingControl.LaserTestingControlItem(0); idx = 0; break;
                case "SORTER_VAR.I_LOTBOX_DETECT_2": ftc = testingControl.LaserTestingControlItem(1); idx = 1; break;
                case "SORTER_VAR.I_LOTBOX_DETECT_3": ftc = testingControl.LaserTestingControlItem(2); idx = 2; break;
                case "SORTER_VAR.I_LOTBOX_DETECT_4": ftc = testingControl.LaserTestingControlItem(3); idx = 3; break;
            }
            if (Value)
            {
                ftc.Value = null;
                ftc.Status = StatusTestingControl.Empty;
            }
            if (!Value)
            {
                ftc.Status = StatusTestingControl.Attached;
            }
        }
        private void OnInfoMachineTester(object sender, JoganMachineTester e, bool GetInfo)
        {
            MachineTesterControl mtc = testingControl.MachineTesterControlItem(e.MachineCode);
            if (mtc != null)
            {
                if (GetInfo)
                {
                    MachineTestingControlClass val = (MachineTestingControlClass)mtc.Value;
                    e.JigID = val.JigID;
                    e.LineID = val.LineID;
                    e.MachineCode = val.Code;
                    e.MachineName = val.MachineName;
                    e.Status = val.Status;
                    e.TestDoneTime = val.TestDoneTime;
                    e.IsDoneTesting = val.IsDoneTesting;
                    e.IsByPassTest = val.IsByPassTest;
                } else
                {
                    mtc.Value = null;
                }
            }
        }

        private void OnBeforeStartMachineTester(object sender, JoganMachineTester e, bool GetInfo)
        {
            MachineTesterControl mtc = testingControl.MachineTesterControlItem(e.MachineCode);
            if (mtc != null)
            {
                mtc.MachineInterval = e.Interval;
                StatusTestingControl stc = StatusTestingControl.Testing;
                if (e.IsByPassTest) stc = StatusTestingControl.ByPassTest;
                mtc.Value = new MachineTestingControlClass
                {
                    Interval = e.Interval,
                    JigID = e.JigID,
                    Status = stc,
                    MachineName = e.MachineName,
                    IsByPassTest = e.IsByPassTest
                };
                if (!e.IsByPassTest) mtc.StartProgress();
            }
        }
        private void OnBeforeStopMachineTester(object sender, JoganMachineTester e, bool GetInfo)
        {
            MachineTesterControl mtc = testingControl.MachineTesterControlItem(e.MachineCode);
            if (mtc != null)
            {
                mtc.StartBlinking = false;
                mtc.Status = StatusTestingControl.Available;
                mtc.IsByPassTest = false;
                mtc.IsDoneTesting = true;
                //mtc.MachineInterval = 0;
            }
        }
        private void OnAfterStopMachineTester(object sender, JoganMachineTester e, bool GetInfo)
        {
            string jigid = "";
            T_TRANSACTION_INPUT tti = JoganUtility.GetTransactionInputInMachine(e.MachineCode, out jigid);
            if (tti != null)
            {
                JoganUtility.CreateDummyTestData(tti.PO_Number, jigid, e.MachineCode);
                JoganUtility.PrepareTestResult(tti.PO_Number, jigid );
            }
        }
        private void OnEventMachineTester(object sender, StatusTestingControl Status, JoganMachineTester e)
        {
            MachineTesterControl mtc = testingControl.MachineTesterControlItem(e.MachineCode);
            if (mtc != null)
            {
                mtc.MachineInterval = e.Interval;
                mtc.Value = new MachineTestingControlClass
                {
                    Interval = e.Interval,
                    JigID = e.JigID,
                    Status = StatusTestingControl.Testing,
                    MachineName = e.MachineName
                };
                //mtc.StartProgress();
            }
        }
        private void OnUnloadingStation(object sender, StatusTestingControl Status, JoganUnloadingStation e)
        {
            if (FWait) return;
            if (e.TransactionInput == null) return;
            //Delay();
            FukudaTestingControl ftc = null;
            int idx = 0;
            switch (e.TransactionInput.LotBox_Position_Fukuda)
            {
                case 1: ftc = testingControl.FukudaTestingControlItem(0); idx = 1; break;
                case 2: ftc = testingControl.FukudaTestingControlItem(1); idx = 2; break;
                case 3: ftc = testingControl.FukudaTestingControlItem(2); idx = 3; break;
                case 4: ftc = testingControl.FukudaTestingControlItem(3); idx = 4; break;
            }
            V_PONUMBER_DEVICE po = null;
            using (var db = new DBProjectEntities())
            {
                po = db.Database.SqlQuery<V_PONUMBER_DEVICE>("select * from V_PONUMBER_DEVICE where PO_Number = '" + e.TransactionInput.PO_Number + "' ").FirstOrDefault();
            }
            ftc.Code = po.PO_Number;
            ftc.Value = new FukudaTestingControlClass
            {
                DeviceID = po.Device_ID,
                DeviceName = po.Device_Name,
                LotboxID = po.LotBox_ID,
                PONumber = po.PO_Number,
                Quantity = po.Quantity,
                Status = Status,
                TestMode = po.Test_Mode_Default,
                JigIndex = e.CurrentTransaction == null ? 0 : e.CurrentTransaction.JIG_INDEX_LOAD
            };
            ftc.Status = Status;
            //if (Status == StatusTestingControl.Finish)
            //{
            //    //testingControl.FukudaTestingControlItem(3).StartBlinking = true;
            //    ftc.StartBlinking = true;
            //}
        }
        private void OnNewMessage(object sender, V_MESSAGE e)
        {
            //if (FWait) return;
            InfoMessageItemControl msg = (InfoMessageItemControl)testingControl.InfoTestingControl.SearchItemControl("Messages");
            if (msg != null)
            {
                if (e != null)
                {
                    msg.Message = new InfoMassageControlClass
                    {
                        DateTime = DateTime.Now,
                        Message = e.Message_Name,
                        Impact = msg.ImpactFromString(e.Impact),
                        Sender = e.Hardware_ID,
                        Status = "",
                    };
                }
            }
        }
        private void JoganUtilityPLCNotification(object sender, AdsNotificationEventArgs e)
        {
            if (FWait) return;
            TwinCat3Property prop = JoganUtility.TwinCat3PropertyList.Where(x => x.DeviceNotificationHandle == e.NotificationHandle).FirstOrDefault();
            if (prop != null)
            {
                if (prop.VariableName == "SORTER_VAR.I_LASER_SOCKET")
                {
                    T_JIG_SOCKET tjs = (T_JIG_SOCKET)JoganUtility.ReadAnyFromPLC(prop.VariableName, TypeOfData.tpObject, typeof(T_JIG_SOCKET));
                    LaserTestingControl ltc = null;
                    if (tjs.STATION_NUMBER != 0)
                    {
                        ltc = testingControl.LaserTestingControlItem(tjs.STATION_NUMBER - 1);
                        FukudaTestingControl ftc = testingControl.FukudaTestingControlItem(tjs.PO_NUMBER);
                        if (ltc.Value == null)
                        {
                            int maxjig = 0;
                            using (var db = new DBProjectEntities())
                            {
                                maxjig = db.T_BOOKING_STATIONS.Where(x => x.PO_Number == tjs.PO_NUMBER).Count();
                            }
                            Color clr = ftc == null ? Color.Black : ftc.BasicColor;
                            ltc.MaxJig = maxjig;
                            //ltc.AddJig(1);
                            ltc.Value = new LaserTestingControlClass
                            {
                                BasicColor = clr,
                                Code = tjs.PO_NUMBER,
                                PONumber = tjs.PO_NUMBER,
                                Status = StatusTestingControl.Booked
                            };
                        }
                        else
                        {
                            ltc.AddJig(1);
                        }
                    }
                    else
                    {
                        ltc = testingControl.LaserTestingControlItem(tjs.PO_NUMBER);
                        if (ltc != null)
                        {
                            LaserTestingControlClass val = (LaserTestingControlClass)ltc.Value;
                            for (int i = 1; i <= 4; i++)
                            {
                                if (tjs.LASER_DESTINATION[i] == 9) { val.QuantityGood++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 1) { val.QuantityNG1++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 2) { val.QuantityNG2++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 3) { val.QuantityNG3++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 4) { val.QuantityNG4++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 5) { val.QuantityNG5++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 6) { val.QuantityNG6++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 7) { val.QuantityNG7++; } else val.QuantityNGOther++;
                            }
                            ltc.Value = val;
                        }
                    }
                    //testingControl.LaserTestingControlItem
                }
                else
                {
                    bool val = false;
                    val = (bool)JoganUtility.ReadAnyFromPLC(prop.VariableName, TypeOfData.tpBool);
                    int idx1 = 0;
                    //TwinCat3Utility.BinaryReader.ReadBoolean();
                    switch (JoganUtility.RunApplicationOn)
                    {
                        case HMISide.HMI1:
                            switch (prop.VariableName)
                            {
                                case "INPUT_VAR.I_LOTBOX_DETECT_1": FukudaTestingItemControl(val, "INPUT_VAR.I_LOTBOX_DETECT_1"); idx1 = 0; break;
                                case "INPUT_VAR.I_LOTBOX_DETECT_2": FukudaTestingItemControl(val, "INPUT_VAR.I_LOTBOX_DETECT_2"); idx1 = 1; break;
                                case "INPUT_VAR.I_LOTBOX_DETECT_3": FukudaTestingItemControl(val, "INPUT_VAR.I_LOTBOX_DETECT_3"); idx1 = 2; break;
                                case "INPUT_VAR.I_LOTBOX_DETECT_4": FukudaTestingItemControl(val, "INPUT_VAR.I_LOTBOX_DETECT_4"); idx1 = 3; break;
                            }
                            if ((prop.VariableName == "INPUT_VAR.I_LOTBOX_DETECT_1" ||
                                prop.VariableName == "INPUT_VAR.I_LOTBOX_DETECT_2" ||
                                prop.VariableName == "INPUT_VAR.I_LOTBOX_DETECT_3" ||
                                prop.VariableName == "INPUT_VAR.I_LOTBOX_DETECT_4"
                                ) && !val)
                            {
                                //OpenForm("frmInputTestData", null, new Size(800, 650), UserProp,
                                // delegate (Form sender)
                                // {
                                //     ((frmInputTestData)sender).SelectedTab = idx;
                                // }
                                // );
                                OpenForm("frmInputTestData", null, new Size(800, 650), UserProp, delegate (Form sender1) { ((frmInputTestData)sender1).SelectedTab = idx1; });
                            }
                            break;
                        case HMISide.HMI2:

                            switch (prop.VariableName)
                            {
                                case "SORTER_VAR.I_LOTBOX_DETECT_1": LaserTestingItemControl(val, "SORTER_VAR.I_LOTBOX_DETECT_1"); idx1 = 0; break;
                                case "SORTER_VAR.I_LOTBOX_DETECT_2": LaserTestingItemControl(val, "SORTER_VAR.I_LOTBOX_DETECT_2"); idx1 = 1; break;
                                case "SORTER_VAR.I_LOTBOX_DETECT_3": LaserTestingItemControl(val, "SORTER_VAR.I_LOTBOX_DETECT_3"); idx1 = 2; break;
                                case "SORTER_VAR.I_LOTBOX_DETECT_4": LaserTestingItemControl(val, "SORTER_VAR.I_LOTBOX_DETECT_4"); idx1 = 3; break;
                            }
                            if ((prop.VariableName == "SORTER_VAR.I_LOTBOX_DETECT_1" ||
                               prop.VariableName == "SORTER_VAR.I_LOTBOX_DETECT_2" ||
                               prop.VariableName == "SORTER_VAR.I_LOTBOX_DETECT_3" ||
                               prop.VariableName == "INPUT_VAR.I_LOTBOX_DETECT_4"
                               ) && !val) OpenForm("frmSorterTestData", null, new Size(460, 252), UserProp, delegate (Form sender1) { ((frmSorterTestData)sender1).SelectedTab = idx1; });
                            break;
                    }
                }
            }
        }   

        private void testingControl_StatusChanged(object sender, StatusTestingControl e)
        {
            FukudaTestingControl ftc = (sender is FukudaTestingControl) ? (FukudaTestingControl)sender : null;
            MachineTesterControl mtc = (sender is MachineTesterControl) ? (MachineTesterControl)sender : null;
            LaserTestingControl ltc = (sender is LaserTestingControl) ? (LaserTestingControl)sender : null;
            if (ftc != null)
            {
                if (e != StatusTestingControl.Finish) JoganUtility.CreateMessage("Station " + ftc.Index.ToString() + " is now " + ftc.Status.ToString(), "Station " + ftc.Index.ToString(), "Normal");
                else
                {
                    ftc.StartBlinking = true;
                    JoganUtility.CreateMessage("Station " + ftc.Index.ToString() + " is now " + ftc.Status.ToString() + " unload jig. Please unattached lotbox from station", "Station " + ftc.Index.ToString(), "Normal");
                    string varon = "INPUT_VAR.O_LOTBOX_CLAMP_ON_" + ftc.Index.ToString();
                    string varoff = "INPUT_VAR.O_LOTBOX_CLAMP_OFF_" + ftc.Index.ToString();

                    //JoganUtility.WriteAnyToPLC(varon, TypeOfData.tpBool, false);
                    //JoganUtility.WriteAnyToPLC(varoff, TypeOfData.tpBool, true);
                }
            }
            if (mtc != null)
            {
                if (e != StatusTestingControl.TestDone) JoganUtility.CreateMessage("Machine " + mtc.Code + " is now " + mtc.Status.ToString(), "Machine " + mtc.Code, "Normal");
                else
                {
                    //mtc.StartBlinking = true;
                    JoganUtility.CreateMessage("Machine " + mtc.Code + " is now " + mtc.Status.ToString() + " testing", "Machine " + mtc.Code, "Normal");
                    //JoganUtility.StopMachineTester(mtc.Code);
                }
            }
            if (ltc != null)
            {
            }
        }
    }
}
