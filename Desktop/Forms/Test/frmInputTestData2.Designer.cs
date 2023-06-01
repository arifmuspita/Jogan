namespace Desktop.Forms.Test
{
    partial class frmInputTestData2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DBProject.Models.T_TRANSACTION_INPUT t_TRANSACTION_INPUT5 = new DBProject.Models.T_TRANSACTION_INPUT();
            DBProject.Models.T_TRANSACTION_LASER t_TRANSACTION_LASER5 = new DBProject.Models.T_TRANSACTION_LASER();
            DBProject.Models.T_TRANSACTION_INPUT t_TRANSACTION_INPUT1 = new DBProject.Models.T_TRANSACTION_INPUT();
            DBProject.Models.T_TRANSACTION_LASER t_TRANSACTION_LASER1 = new DBProject.Models.T_TRANSACTION_LASER();
            DBProject.Models.T_TRANSACTION_INPUT t_TRANSACTION_INPUT2 = new DBProject.Models.T_TRANSACTION_INPUT();
            DBProject.Models.T_TRANSACTION_LASER t_TRANSACTION_LASER2 = new DBProject.Models.T_TRANSACTION_LASER();
            DBProject.Models.T_TRANSACTION_INPUT t_TRANSACTION_INPUT3 = new DBProject.Models.T_TRANSACTION_INPUT();
            DBProject.Models.T_TRANSACTION_LASER t_TRANSACTION_LASER3 = new DBProject.Models.T_TRANSACTION_LASER();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabTestMode = new System.Windows.Forms.TabControl();
            this.tabPageNormal = new System.Windows.Forms.TabPage();
            this.tabControlNormalTest = new System.Windows.Forms.TabControl();
            this.tabPageNormalTestStation1 = new System.Windows.Forms.TabPage();
            this.fukudaNormalTestControl1 = new Desktop.Controls.FukudaNormalTestControl();
            this.tabPageNormalTestStation2 = new System.Windows.Forms.TabPage();
            this.fukudaNormalTestControl2 = new Desktop.Controls.FukudaNormalTestControl();
            this.tabPageNormalTestStation3 = new System.Windows.Forms.TabPage();
            this.fukudaNormalTestControl3 = new Desktop.Controls.FukudaNormalTestControl();
            this.tabPageNormalTestStation4 = new System.Windows.Forms.TabPage();
            this.fukudaNormalTestControl4 = new Desktop.Controls.FukudaNormalTestControl();
            this.tabPageAQL = new System.Windows.Forms.TabPage();
            this.tabControlAQLTest = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fukudaAQLTestControl1 = new Desktop.Controls.FukudaAQLTestControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.fukudaAQLTestControl2 = new Desktop.Controls.FukudaAQLTestControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.fukudaAQLTestControl3 = new Desktop.Controls.FukudaAQLTestControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.fukudaAQLTestControl4 = new Desktop.Controls.FukudaAQLTestControl();
            this.tabPageDowngrade = new System.Windows.Forms.TabPage();
            this.tabControlDowngradeTest = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.fukudaDowngradeTestControl1 = new Desktop.Controls.FukudaNormalTestControl();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.fukudaDowngradeTestControl2 = new Desktop.Controls.FukudaNormalTestControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.fukudaDowngradeTestControl3 = new Desktop.Controls.FukudaNormalTestControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.fukudaDowngradeTestControl4 = new Desktop.Controls.FukudaNormalTestControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtLotboxID = new System.Windows.Forms.TextBox();
            this.txtDeviceName = new Desktop.BaseComponents.PlaceholderTextBox();
            this.txtDeviceID = new Desktop.BaseComponents.PlaceholderTextBox();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabTestMode.SuspendLayout();
            this.tabPageNormal.SuspendLayout();
            this.tabControlNormalTest.SuspendLayout();
            this.tabPageNormalTestStation1.SuspendLayout();
            this.tabPageNormalTestStation2.SuspendLayout();
            this.tabPageNormalTestStation3.SuspendLayout();
            this.tabPageNormalTestStation4.SuspendLayout();
            this.tabPageAQL.SuspendLayout();
            this.tabControlAQLTest.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPageDowngrade.SuspendLayout();
            this.tabControlDowngradeTest.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout(); 
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 649); 
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Size = new System.Drawing.Size(782, 595); 
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabTestMode);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 534);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Test Mode ";
            // 
            // tabTestMode
            // 
            this.tabTestMode.Controls.Add(this.tabPageNormal);
            this.tabTestMode.Controls.Add(this.tabPageAQL);
            this.tabTestMode.Controls.Add(this.tabPageDowngrade);
            this.tabTestMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTestMode.Location = new System.Drawing.Point(3, 20);
            this.tabTestMode.Name = "tabTestMode";
            this.tabTestMode.SelectedIndex = 0;
            this.tabTestMode.Size = new System.Drawing.Size(774, 511);
            this.tabTestMode.TabIndex = 0;
            // 
            // tabPageNormal
            // 
            this.tabPageNormal.Controls.Add(this.tabControlNormalTest);
            this.tabPageNormal.Location = new System.Drawing.Point(4, 27);
            this.tabPageNormal.Name = "tabPageNormal";
            this.tabPageNormal.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNormal.Size = new System.Drawing.Size(766, 480);
            this.tabPageNormal.TabIndex = 0;
            this.tabPageNormal.Text = "Normal";
            this.tabPageNormal.UseVisualStyleBackColor = true;
            // 
            // tabControlNormalTest
            // 
            this.tabControlNormalTest.Controls.Add(this.tabPageNormalTestStation1);
            this.tabControlNormalTest.Controls.Add(this.tabPageNormalTestStation2);
            this.tabControlNormalTest.Controls.Add(this.tabPageNormalTestStation3);
            this.tabControlNormalTest.Controls.Add(this.tabPageNormalTestStation4);
            this.tabControlNormalTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlNormalTest.Location = new System.Drawing.Point(3, 3);
            this.tabControlNormalTest.Name = "tabControlNormalTest";
            this.tabControlNormalTest.SelectedIndex = 0;
            this.tabControlNormalTest.Size = new System.Drawing.Size(760, 474);
            this.tabControlNormalTest.TabIndex = 0;
            this.tabControlNormalTest.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlNormalTest_Selecting);
            // 
            // tabPageNormalTestStation1
            // 
            this.tabPageNormalTestStation1.Controls.Add(this.fukudaNormalTestControl1);
            this.tabPageNormalTestStation1.Location = new System.Drawing.Point(4, 27);
            this.tabPageNormalTestStation1.Name = "tabPageNormalTestStation1";
            this.tabPageNormalTestStation1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNormalTestStation1.Size = new System.Drawing.Size(752, 443);
            this.tabPageNormalTestStation1.TabIndex = 0;
            this.tabPageNormalTestStation1.Text = "Station 1";
            this.tabPageNormalTestStation1.UseVisualStyleBackColor = true;
            // 
            // fukudaNormalTestControl1
            // 
            this.fukudaNormalTestControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaNormalTestControl1.DeviceID = "";
            this.fukudaNormalTestControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaNormalTestControl1.FocusControl = null;
            this.fukudaNormalTestControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaNormalTestControl1.Location = new System.Drawing.Point(3, 3);
            this.fukudaNormalTestControl1.LotBoxID = "";
            this.fukudaNormalTestControl1.LotboxLaserPosition = 0;
            this.fukudaNormalTestControl1.LotboxPosition = 1;
            this.fukudaNormalTestControl1.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaNormalTestControl1.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaNormalTestControl1.Name = "fukudaNormalTestControl1";
            this.fukudaNormalTestControl1.PONumber = "";
            this.fukudaNormalTestControl1.Quantity = "";
            this.fukudaNormalTestControl1.Size = new System.Drawing.Size(746, 437);
            this.fukudaNormalTestControl1.TabIndex = 1;
            this.fukudaNormalTestControl1.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            this.fukudaNormalTestControl1.TransactionInput = null;
            this.fukudaNormalTestControl1.TransactionSorter = null;
            this.fukudaNormalTestControl1.UserID = null;
            // 
            // tabPageNormalTestStation2
            // 
            this.tabPageNormalTestStation2.Controls.Add(this.fukudaNormalTestControl2);
            this.tabPageNormalTestStation2.Location = new System.Drawing.Point(4, 27);
            this.tabPageNormalTestStation2.Name = "tabPageNormalTestStation2";
            this.tabPageNormalTestStation2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNormalTestStation2.Size = new System.Drawing.Size(752, 322);
            this.tabPageNormalTestStation2.TabIndex = 1;
            this.tabPageNormalTestStation2.Text = "Station 2";
            this.tabPageNormalTestStation2.UseVisualStyleBackColor = true;
            // 
            // fukudaNormalTestControl2
            // 
            this.fukudaNormalTestControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaNormalTestControl2.DeviceID = "";
            this.fukudaNormalTestControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaNormalTestControl2.FocusControl = null;
            this.fukudaNormalTestControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaNormalTestControl2.Location = new System.Drawing.Point(3, 3);
            this.fukudaNormalTestControl2.LotBoxID = "";
            this.fukudaNormalTestControl2.LotboxLaserPosition = 0;
            this.fukudaNormalTestControl2.LotboxPosition = 2;
            this.fukudaNormalTestControl2.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaNormalTestControl2.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaNormalTestControl2.Name = "fukudaNormalTestControl2";
            this.fukudaNormalTestControl2.PONumber = "";
            this.fukudaNormalTestControl2.Quantity = "";
            this.fukudaNormalTestControl2.Size = new System.Drawing.Size(746, 337);
            this.fukudaNormalTestControl2.TabIndex = 1;
            this.fukudaNormalTestControl2.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            this.fukudaNormalTestControl2.TransactionInput = null;
            this.fukudaNormalTestControl2.TransactionSorter = null;
            this.fukudaNormalTestControl2.UserID = null;
            // 
            // tabPageNormalTestStation3
            // 
            this.tabPageNormalTestStation3.Controls.Add(this.fukudaNormalTestControl3);
            this.tabPageNormalTestStation3.Location = new System.Drawing.Point(4, 27);
            this.tabPageNormalTestStation3.Name = "tabPageNormalTestStation3";
            this.tabPageNormalTestStation3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNormalTestStation3.Size = new System.Drawing.Size(752, 322);
            this.tabPageNormalTestStation3.TabIndex = 2;
            this.tabPageNormalTestStation3.Text = "Station 3";
            this.tabPageNormalTestStation3.UseVisualStyleBackColor = true;
            // 
            // fukudaNormalTestControl3
            // 
            this.fukudaNormalTestControl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaNormalTestControl3.DeviceID = "";
            this.fukudaNormalTestControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaNormalTestControl3.FocusControl = null;
            this.fukudaNormalTestControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaNormalTestControl3.Location = new System.Drawing.Point(3, 3);
            this.fukudaNormalTestControl3.LotBoxID = "";
            this.fukudaNormalTestControl3.LotboxLaserPosition = 0;
            this.fukudaNormalTestControl3.LotboxPosition = 3;
            this.fukudaNormalTestControl3.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaNormalTestControl3.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaNormalTestControl3.Name = "fukudaNormalTestControl3";
            this.fukudaNormalTestControl3.PONumber = "";
            this.fukudaNormalTestControl3.Quantity = "";
            this.fukudaNormalTestControl3.Size = new System.Drawing.Size(746, 337);
            this.fukudaNormalTestControl3.TabIndex = 1;
            this.fukudaNormalTestControl3.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            this.fukudaNormalTestControl3.TransactionInput = null;
            this.fukudaNormalTestControl3.TransactionSorter = null;
            this.fukudaNormalTestControl3.UserID = null;
            // 
            // tabPageNormalTestStation4
            // 
            this.tabPageNormalTestStation4.Controls.Add(this.fukudaNormalTestControl4);
            this.tabPageNormalTestStation4.Location = new System.Drawing.Point(4, 27);
            this.tabPageNormalTestStation4.Name = "tabPageNormalTestStation4";
            this.tabPageNormalTestStation4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNormalTestStation4.Size = new System.Drawing.Size(752, 322);
            this.tabPageNormalTestStation4.TabIndex = 3;
            this.tabPageNormalTestStation4.Text = "Station 4";
            this.tabPageNormalTestStation4.UseVisualStyleBackColor = true;
            // 
            // fukudaNormalTestControl4
            // 
            this.fukudaNormalTestControl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaNormalTestControl4.DeviceID = "";
            this.fukudaNormalTestControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaNormalTestControl4.FocusControl = null;
            this.fukudaNormalTestControl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaNormalTestControl4.Location = new System.Drawing.Point(3, 3);
            this.fukudaNormalTestControl4.LotBoxID = "";
            this.fukudaNormalTestControl4.LotboxLaserPosition = 0;
            this.fukudaNormalTestControl4.LotboxPosition = 4;
            this.fukudaNormalTestControl4.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaNormalTestControl4.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaNormalTestControl4.Name = "fukudaNormalTestControl4";
            this.fukudaNormalTestControl4.PONumber = "";
            this.fukudaNormalTestControl4.Quantity = "";
            this.fukudaNormalTestControl4.Size = new System.Drawing.Size(746, 337);
            this.fukudaNormalTestControl4.TabIndex = 1;
            this.fukudaNormalTestControl4.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            this.fukudaNormalTestControl4.TransactionInput = null;
            this.fukudaNormalTestControl4.TransactionSorter = null;
            this.fukudaNormalTestControl4.UserID = null;
            // 
            // tabPageAQL
            // 
            this.tabPageAQL.Controls.Add(this.tabControlAQLTest);
            this.tabPageAQL.Location = new System.Drawing.Point(4, 27);
            this.tabPageAQL.Name = "tabPageAQL";
            this.tabPageAQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAQL.Size = new System.Drawing.Size(766, 359);
            this.tabPageAQL.TabIndex = 1;
            this.tabPageAQL.Text = "AQL";
            this.tabPageAQL.UseVisualStyleBackColor = true;
            // 
            // tabControlAQLTest
            // 
            this.tabControlAQLTest.Controls.Add(this.tabPage1);
            this.tabControlAQLTest.Controls.Add(this.tabPage2);
            this.tabControlAQLTest.Controls.Add(this.tabPage3);
            this.tabControlAQLTest.Controls.Add(this.tabPage4);
            this.tabControlAQLTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAQLTest.Location = new System.Drawing.Point(3, 3);
            this.tabControlAQLTest.Name = "tabControlAQLTest";
            this.tabControlAQLTest.SelectedIndex = 0;
            this.tabControlAQLTest.Size = new System.Drawing.Size(760, 353);
            this.tabControlAQLTest.TabIndex = 1;
            this.tabControlAQLTest.SelectedIndexChanged += new System.EventHandler(this.tabControlAQLTest_SelectedIndexChanged);
            this.tabControlAQLTest.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlAQLTest_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.fukudaAQLTestControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(752, 322);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Station 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // fukudaAQLTestControl1
            // 
            this.fukudaAQLTestControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaAQLTestControl1.DeviceID = "";
            this.fukudaAQLTestControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaAQLTestControl1.FocusControl = null;
            this.fukudaAQLTestControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaAQLTestControl1.Location = new System.Drawing.Point(3, 3);
            this.fukudaAQLTestControl1.LotBoxID = "1";
            this.fukudaAQLTestControl1.LotboxLaserPosition = 0;
            this.fukudaAQLTestControl1.LotboxPosition = 0;
            this.fukudaAQLTestControl1.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaAQLTestControl1.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaAQLTestControl1.Name = "fukudaAQLTestControl1";
            this.fukudaAQLTestControl1.PONumber = "";
            this.fukudaAQLTestControl1.Quantity = "125";
            this.fukudaAQLTestControl1.Size = new System.Drawing.Size(746, 337);
            this.fukudaAQLTestControl1.TabIndex = 0;
            this.fukudaAQLTestControl1.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            t_TRANSACTION_INPUT5.AQL_Reference = "";
            t_TRANSACTION_INPUT5.Created_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT5.Device_ID = null;
            t_TRANSACTION_INPUT5.End_Test = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT5.LotBox_ID = null;
            t_TRANSACTION_INPUT5.LotBox_Position_Fukuda = 1;
            t_TRANSACTION_INPUT5.LotBox_Position_Laser = 1;
            t_TRANSACTION_INPUT5.Noise_Type_Parameter_Ref = "";
            t_TRANSACTION_INPUT5.PO_Number = null;
            t_TRANSACTION_INPUT5.Quantity = 0;
            t_TRANSACTION_INPUT5.Signal_Device_ID_Ref = "";
            t_TRANSACTION_INPUT5.Start_Test = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT5.Status = ""; 
            t_TRANSACTION_INPUT5.Updated_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT5.Updated_User = "system";
            t_TRANSACTION_INPUT5.User_ID = null;
            this.fukudaAQLTestControl1.TransactionInput = t_TRANSACTION_INPUT5;
            t_TRANSACTION_LASER5.Created_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_LASER5.Device_ID = null;
            t_TRANSACTION_LASER5.LotBox_ID = null;
            t_TRANSACTION_LASER5.LotBox_NG_ID = null;
            t_TRANSACTION_LASER5.LotBox_Position = 0;
            t_TRANSACTION_LASER5.PO_Number = null;
            t_TRANSACTION_LASER5.Quantity = 0; 
            t_TRANSACTION_LASER5.Updated_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_LASER5.Updated_User = "system";
            t_TRANSACTION_LASER5.User_ID = null;
            this.fukudaAQLTestControl1.TransactionSorter = t_TRANSACTION_LASER5;
            this.fukudaAQLTestControl1.UserID = null;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.fukudaAQLTestControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(752, 445);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Station 2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // fukudaAQLTestControl2
            // 
            this.fukudaAQLTestControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaAQLTestControl2.DeviceID = "";
            this.fukudaAQLTestControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaAQLTestControl2.FocusControl = null;
            this.fukudaAQLTestControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaAQLTestControl2.Location = new System.Drawing.Point(3, 3);
            this.fukudaAQLTestControl2.LotBoxID = "";
            this.fukudaAQLTestControl2.LotboxLaserPosition = 0;
            this.fukudaAQLTestControl2.LotboxPosition = 2;
            this.fukudaAQLTestControl2.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaAQLTestControl2.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaAQLTestControl2.Name = "fukudaAQLTestControl2";
            this.fukudaAQLTestControl2.PONumber = "";
            this.fukudaAQLTestControl2.Quantity = "125";
            this.fukudaAQLTestControl2.Size = new System.Drawing.Size(746, 439);
            this.fukudaAQLTestControl2.TabIndex = 1;
            this.fukudaAQLTestControl2.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            t_TRANSACTION_INPUT1.AQL_Reference = "";
            t_TRANSACTION_INPUT1.Created_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT1.Device_ID = null;
            t_TRANSACTION_INPUT1.End_Test = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT1.LotBox_ID = null;
            t_TRANSACTION_INPUT1.LotBox_Position_Fukuda = 1;
            t_TRANSACTION_INPUT1.LotBox_Position_Laser = 1;
            t_TRANSACTION_INPUT1.Noise_Type_Parameter_Ref = "";
            t_TRANSACTION_INPUT1.PO_Number = null;
            t_TRANSACTION_INPUT1.Quantity = 0;
            t_TRANSACTION_INPUT1.Signal_Device_ID_Ref = "";
            t_TRANSACTION_INPUT1.Start_Test = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT1.Status = ""; 
            t_TRANSACTION_INPUT1.Updated_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT1.Updated_User = "system";
            t_TRANSACTION_INPUT1.User_ID = null;
            this.fukudaAQLTestControl2.TransactionInput = t_TRANSACTION_INPUT1;
            t_TRANSACTION_LASER1.Created_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_LASER1.Device_ID = null;
            t_TRANSACTION_LASER1.LotBox_ID = null;
            t_TRANSACTION_LASER1.LotBox_NG_ID = null;
            t_TRANSACTION_LASER1.LotBox_Position = 0;
            t_TRANSACTION_LASER1.PO_Number = null;
            t_TRANSACTION_LASER1.Quantity = 0; 
            t_TRANSACTION_LASER1.Updated_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_LASER1.Updated_User = "system";
            t_TRANSACTION_LASER1.User_ID = null;
            this.fukudaAQLTestControl2.TransactionSorter = t_TRANSACTION_LASER1;
            this.fukudaAQLTestControl2.UserID = null;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.fukudaAQLTestControl3);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(752, 445);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Station 3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // fukudaAQLTestControl3
            // 
            this.fukudaAQLTestControl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaAQLTestControl3.DeviceID = "";
            this.fukudaAQLTestControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaAQLTestControl3.FocusControl = null;
            this.fukudaAQLTestControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaAQLTestControl3.Location = new System.Drawing.Point(3, 3);
            this.fukudaAQLTestControl3.LotBoxID = "";
            this.fukudaAQLTestControl3.LotboxLaserPosition = 0;
            this.fukudaAQLTestControl3.LotboxPosition = 3;
            this.fukudaAQLTestControl3.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaAQLTestControl3.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaAQLTestControl3.Name = "fukudaAQLTestControl3";
            this.fukudaAQLTestControl3.PONumber = "";
            this.fukudaAQLTestControl3.Quantity = "125";
            this.fukudaAQLTestControl3.Size = new System.Drawing.Size(746, 439);
            this.fukudaAQLTestControl3.TabIndex = 1;
            this.fukudaAQLTestControl3.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            t_TRANSACTION_INPUT2.AQL_Reference = "";
            t_TRANSACTION_INPUT2.Created_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT2.Device_ID = null;
            t_TRANSACTION_INPUT2.End_Test = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT2.LotBox_ID = null;
            t_TRANSACTION_INPUT2.LotBox_Position_Fukuda = 1;
            t_TRANSACTION_INPUT2.LotBox_Position_Laser = 1;
            t_TRANSACTION_INPUT2.Noise_Type_Parameter_Ref = "";
            t_TRANSACTION_INPUT2.PO_Number = null;
            t_TRANSACTION_INPUT2.Quantity = 0;
            t_TRANSACTION_INPUT2.Signal_Device_ID_Ref = "";
            t_TRANSACTION_INPUT2.Start_Test = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT2.Status = ""; 
            t_TRANSACTION_INPUT2.Updated_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT2.Updated_User = "system";
            t_TRANSACTION_INPUT2.User_ID = null;
            this.fukudaAQLTestControl3.TransactionInput = t_TRANSACTION_INPUT2;
            t_TRANSACTION_LASER2.Created_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_LASER2.Device_ID = null;
            t_TRANSACTION_LASER2.LotBox_ID = null;
            t_TRANSACTION_LASER2.LotBox_NG_ID = null;
            t_TRANSACTION_LASER2.LotBox_Position = 0;
            t_TRANSACTION_LASER2.PO_Number = null;
            t_TRANSACTION_LASER2.Quantity = 0; 
            t_TRANSACTION_LASER2.Updated_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_LASER2.Updated_User = "system";
            t_TRANSACTION_LASER2.User_ID = null;
            this.fukudaAQLTestControl3.TransactionSorter = t_TRANSACTION_LASER2;
            this.fukudaAQLTestControl3.UserID = null;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.fukudaAQLTestControl4);
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(752, 445);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Station 4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // fukudaAQLTestControl4
            // 
            this.fukudaAQLTestControl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaAQLTestControl4.DeviceID = "";
            this.fukudaAQLTestControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaAQLTestControl4.FocusControl = null;
            this.fukudaAQLTestControl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaAQLTestControl4.Location = new System.Drawing.Point(3, 3);
            this.fukudaAQLTestControl4.LotBoxID = "";
            this.fukudaAQLTestControl4.LotboxLaserPosition = 0;
            this.fukudaAQLTestControl4.LotboxPosition = 4;
            this.fukudaAQLTestControl4.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaAQLTestControl4.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaAQLTestControl4.Name = "fukudaAQLTestControl4";
            this.fukudaAQLTestControl4.PONumber = "";
            this.fukudaAQLTestControl4.Quantity = "125";
            this.fukudaAQLTestControl4.Size = new System.Drawing.Size(746, 439);
            this.fukudaAQLTestControl4.TabIndex = 1;
            this.fukudaAQLTestControl4.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            t_TRANSACTION_INPUT3.AQL_Reference = "";
            t_TRANSACTION_INPUT3.Created_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT3.Device_ID = null;
            t_TRANSACTION_INPUT3.End_Test = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT3.LotBox_ID = null;
            t_TRANSACTION_INPUT3.LotBox_Position_Fukuda = 1;
            t_TRANSACTION_INPUT3.LotBox_Position_Laser = 1;
            t_TRANSACTION_INPUT3.Noise_Type_Parameter_Ref = "";
            t_TRANSACTION_INPUT3.PO_Number = null;
            t_TRANSACTION_INPUT3.Quantity = 0;
            t_TRANSACTION_INPUT3.Signal_Device_ID_Ref = "";
            t_TRANSACTION_INPUT3.Start_Test = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT3.Status = ""; 
            t_TRANSACTION_INPUT3.Updated_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_INPUT3.Updated_User = "system";
            t_TRANSACTION_INPUT3.User_ID = null;
            this.fukudaAQLTestControl4.TransactionInput = t_TRANSACTION_INPUT3;
            t_TRANSACTION_LASER3.Created_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_LASER3.Device_ID = null;
            t_TRANSACTION_LASER3.LotBox_ID = null;
            t_TRANSACTION_LASER3.LotBox_NG_ID = null;
            t_TRANSACTION_LASER3.LotBox_Position = 0;
            t_TRANSACTION_LASER3.PO_Number = null;
            t_TRANSACTION_LASER3.Quantity = 0; 
            t_TRANSACTION_LASER3.Updated_Date = new System.DateTime(2017, 1, 13, 16, 36, 28, 64);
            t_TRANSACTION_LASER3.Updated_User = "system";
            t_TRANSACTION_LASER3.User_ID = null;
            this.fukudaAQLTestControl4.TransactionSorter = t_TRANSACTION_LASER3;
            this.fukudaAQLTestControl4.UserID = null;
            // 
            // tabPageDowngrade
            // 
            this.tabPageDowngrade.Controls.Add(this.tabControlDowngradeTest);
            this.tabPageDowngrade.Location = new System.Drawing.Point(4, 27);
            this.tabPageDowngrade.Name = "tabPageDowngrade";
            this.tabPageDowngrade.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDowngrade.Size = new System.Drawing.Size(766, 359);
            this.tabPageDowngrade.TabIndex = 2;
            this.tabPageDowngrade.Text = "Downgrade";
            this.tabPageDowngrade.UseVisualStyleBackColor = true;
            // 
            // tabControlDowngradeTest
            // 
            this.tabControlDowngradeTest.Controls.Add(this.tabPage5);
            this.tabControlDowngradeTest.Controls.Add(this.tabPage6);
            this.tabControlDowngradeTest.Controls.Add(this.tabPage7);
            this.tabControlDowngradeTest.Controls.Add(this.tabPage8);
            this.tabControlDowngradeTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDowngradeTest.Location = new System.Drawing.Point(3, 3);
            this.tabControlDowngradeTest.Name = "tabControlDowngradeTest";
            this.tabControlDowngradeTest.SelectedIndex = 0;
            this.tabControlDowngradeTest.Size = new System.Drawing.Size(760, 353);
            this.tabControlDowngradeTest.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.fukudaDowngradeTestControl1);
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(752, 322);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "Station 1";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // fukudaDowngradeTestControl1
            // 
            this.fukudaDowngradeTestControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaDowngradeTestControl1.DeviceID = "";
            this.fukudaDowngradeTestControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaDowngradeTestControl1.FocusControl = null;
            this.fukudaDowngradeTestControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaDowngradeTestControl1.Location = new System.Drawing.Point(3, 3);
            this.fukudaDowngradeTestControl1.LotBoxID = "";
            this.fukudaDowngradeTestControl1.LotboxLaserPosition = 0;
            this.fukudaDowngradeTestControl1.LotboxPosition = 1;
            this.fukudaDowngradeTestControl1.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaDowngradeTestControl1.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaDowngradeTestControl1.Name = "fukudaDowngradeTestControl1";
            this.fukudaDowngradeTestControl1.PONumber = "";
            this.fukudaDowngradeTestControl1.Quantity = "";
            this.fukudaDowngradeTestControl1.Size = new System.Drawing.Size(746, 337);
            this.fukudaDowngradeTestControl1.TabIndex = 1;
            this.fukudaDowngradeTestControl1.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            this.fukudaDowngradeTestControl1.TransactionInput = null;
            this.fukudaDowngradeTestControl1.TransactionSorter = null;
            this.fukudaDowngradeTestControl1.UserID = null;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.fukudaDowngradeTestControl2);
            this.tabPage6.Location = new System.Drawing.Point(4, 27);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(752, 445);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Station 2";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // fukudaDowngradeTestControl2
            // 
            this.fukudaDowngradeTestControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaDowngradeTestControl2.DeviceID = "";
            this.fukudaDowngradeTestControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaDowngradeTestControl2.FocusControl = null;
            this.fukudaDowngradeTestControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaDowngradeTestControl2.Location = new System.Drawing.Point(3, 3);
            this.fukudaDowngradeTestControl2.LotBoxID = "";
            this.fukudaDowngradeTestControl2.LotboxLaserPosition = 0;
            this.fukudaDowngradeTestControl2.LotboxPosition = 2;
            this.fukudaDowngradeTestControl2.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaDowngradeTestControl2.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaDowngradeTestControl2.Name = "fukudaDowngradeTestControl2";
            this.fukudaDowngradeTestControl2.PONumber = "";
            this.fukudaDowngradeTestControl2.Quantity = "";
            this.fukudaDowngradeTestControl2.Size = new System.Drawing.Size(746, 439);
            this.fukudaDowngradeTestControl2.TabIndex = 1;
            this.fukudaDowngradeTestControl2.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            this.fukudaDowngradeTestControl2.TransactionInput = null;
            this.fukudaDowngradeTestControl2.TransactionSorter = null;
            this.fukudaDowngradeTestControl2.UserID = null;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.fukudaDowngradeTestControl3);
            this.tabPage7.Location = new System.Drawing.Point(4, 27);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(752, 445);
            this.tabPage7.TabIndex = 2;
            this.tabPage7.Text = "Station 3";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // fukudaDowngradeTestControl3
            // 
            this.fukudaDowngradeTestControl3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaDowngradeTestControl3.DeviceID = "";
            this.fukudaDowngradeTestControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaDowngradeTestControl3.FocusControl = null;
            this.fukudaDowngradeTestControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaDowngradeTestControl3.Location = new System.Drawing.Point(3, 3);
            this.fukudaDowngradeTestControl3.LotBoxID = "";
            this.fukudaDowngradeTestControl3.LotboxLaserPosition = 0;
            this.fukudaDowngradeTestControl3.LotboxPosition = 3;
            this.fukudaDowngradeTestControl3.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaDowngradeTestControl3.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaDowngradeTestControl3.Name = "fukudaDowngradeTestControl3";
            this.fukudaDowngradeTestControl3.PONumber = "";
            this.fukudaDowngradeTestControl3.Quantity = "";
            this.fukudaDowngradeTestControl3.Size = new System.Drawing.Size(746, 439);
            this.fukudaDowngradeTestControl3.TabIndex = 1;
            this.fukudaDowngradeTestControl3.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            this.fukudaDowngradeTestControl3.TransactionInput = null;
            this.fukudaDowngradeTestControl3.TransactionSorter = null;
            this.fukudaDowngradeTestControl3.UserID = null;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.fukudaDowngradeTestControl4);
            this.tabPage8.Location = new System.Drawing.Point(4, 27);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(752, 445);
            this.tabPage8.TabIndex = 3;
            this.tabPage8.Text = "Station 4";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // fukudaDowngradeTestControl4
            // 
            this.fukudaDowngradeTestControl4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaDowngradeTestControl4.DeviceID = "";
            this.fukudaDowngradeTestControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaDowngradeTestControl4.FocusControl = null;
            this.fukudaDowngradeTestControl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaDowngradeTestControl4.Location = new System.Drawing.Point(3, 3);
            this.fukudaDowngradeTestControl4.LotBoxID = "";
            this.fukudaDowngradeTestControl4.LotboxLaserPosition = 0;
            this.fukudaDowngradeTestControl4.LotboxPosition = 4;
            this.fukudaDowngradeTestControl4.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaDowngradeTestControl4.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaDowngradeTestControl4.Name = "fukudaDowngradeTestControl4";
            this.fukudaDowngradeTestControl4.PONumber = "";
            this.fukudaDowngradeTestControl4.Quantity = "";
            this.fukudaDowngradeTestControl4.Size = new System.Drawing.Size(746, 439);
            this.fukudaDowngradeTestControl4.TabIndex = 1;
            this.fukudaDowngradeTestControl4.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            this.fukudaDowngradeTestControl4.TransactionInput = null;
            this.fukudaDowngradeTestControl4.TransactionSorter = null;
            this.fukudaDowngradeTestControl4.UserID = null;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtLotboxID);
            this.groupBox2.Controls.Add(this.txtDeviceName);
            this.groupBox2.Controls.Add(this.txtDeviceID);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 59);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " LotBox ID ";
            this.groupBox2.Visible = false;
            // 
            // txtLotboxID
            // 
            this.txtLotboxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotboxID.Location = new System.Drawing.Point(17, 23);
            this.txtLotboxID.Name = "txtLotboxID";
            this.txtLotboxID.Size = new System.Drawing.Size(290, 24);
            this.txtLotboxID.TabIndex = 2;
            this.txtLotboxID.TextChanged += new System.EventHandler(this.txtLotboxID_TextChanged);
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeviceName.Enabled = false;
            this.txtDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceName.Location = new System.Drawing.Point(512, 23);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.PlaceholderText = "Device Name ...";
            this.txtDeviceName.Size = new System.Drawing.Size(254, 24);
            this.txtDeviceName.TabIndex = 1;
            this.txtDeviceName.Visible = false;
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceID.Location = new System.Drawing.Point(326, 23);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.PlaceholderText = "Device ID ...";
            this.txtDeviceID.Size = new System.Drawing.Size(180, 24);
            this.txtDeviceID.TabIndex = 0;
            this.txtDeviceID.Visible = false;
            this.txtDeviceID.TextChanged += new System.EventHandler(this.txtDeviceID_TextChanged);
            // 
            // frmInputTestData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(782, 703);
            this.ControlBox = false;
            this.Name = "frmInputTestData";
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabTestMode.ResumeLayout(false);
            this.tabPageNormal.ResumeLayout(false);
            this.tabControlNormalTest.ResumeLayout(false);
            this.tabPageNormalTestStation1.ResumeLayout(false);
            this.tabPageNormalTestStation2.ResumeLayout(false);
            this.tabPageNormalTestStation3.ResumeLayout(false);
            this.tabPageNormalTestStation4.ResumeLayout(false);
            this.tabPageAQL.ResumeLayout(false);
            this.tabControlAQLTest.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPageDowngrade.ResumeLayout(false);
            this.tabControlDowngradeTest.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage6.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private BaseComponents.PlaceholderTextBox txtDeviceName;
        private BaseComponents.PlaceholderTextBox txtDeviceID;
        private System.Windows.Forms.TabControl tabTestMode;
        private System.Windows.Forms.TabPage tabPageNormal;
        private System.Windows.Forms.TabPage tabPageAQL;
        private System.Windows.Forms.TabPage tabPageDowngrade;
        private System.Windows.Forms.TabControl tabControlNormalTest;
        private System.Windows.Forms.TabPage tabPageNormalTestStation1;
        private Controls.FukudaNormalTestControl fukudaNormalTestControl1;
        private System.Windows.Forms.TabPage tabPageNormalTestStation2;
        private Controls.FukudaNormalTestControl fukudaNormalTestControl2;
        private System.Windows.Forms.TabPage tabPageNormalTestStation3;
        private Controls.FukudaNormalTestControl fukudaNormalTestControl3;
        private System.Windows.Forms.TabPage tabPageNormalTestStation4;
        private Controls.FukudaNormalTestControl fukudaNormalTestControl4;
        private System.Windows.Forms.TabControl tabControlAQLTest;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private Controls.FukudaAQLTestControl fukudaAQLTestControl1;
        private Controls.FukudaAQLTestControl fukudaAQLTestControl2;
        private Controls.FukudaAQLTestControl fukudaAQLTestControl3;
        private Controls.FukudaAQLTestControl fukudaAQLTestControl4;
        private System.Windows.Forms.TabControl tabControlDowngradeTest;
        private System.Windows.Forms.TabPage tabPage5;
        private Controls.FukudaNormalTestControl fukudaDowngradeTestControl1;
        private System.Windows.Forms.TabPage tabPage6;
        private Controls.FukudaNormalTestControl fukudaDowngradeTestControl2;
        private System.Windows.Forms.TabPage tabPage7;
        private Controls.FukudaNormalTestControl fukudaDowngradeTestControl3;
        private System.Windows.Forms.TabPage tabPage8;
        private Controls.FukudaNormalTestControl fukudaDowngradeTestControl4;
        private System.Windows.Forms.TextBox txtLotboxID;
        // private Controls.FukudaAQLTestControl aqlTestControl4;
    }
}
