namespace Desktop.Forms.Maintenance
{
    partial class frmMaintenance
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMaintenance));
            this.tcMaintenance = new System.Windows.Forms.TabControl();
            this.tbLoadingStation = new System.Windows.Forms.TabPage();
            this.tcInputArea = new System.Windows.Forms.TabControl();
            this.tpStation = new System.Windows.Forms.TabPage();
            this.gbLockStation = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnLockStation4 = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnLockStation3 = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnLockStation2 = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnLockStation1 = new System.Windows.Forms.Button();
            this.gbCheckLotbox = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.chkStation4 = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkStation3 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkStation2 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkStation1 = new System.Windows.Forms.CheckBox();
            this.tpUnload = new System.Windows.Forms.TabPage();
            this.gbReturn = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnDoneB = new System.Windows.Forms.Button();
            this.btnDoneA = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRTransportB = new System.Windows.Forms.CheckBox();
            this.chkRTransportA = new System.Windows.Forms.CheckBox();
            this.btnExecRTransport = new System.Windows.Forms.Button();
            this.gbUnload = new System.Windows.Forms.GroupBox();
            this.gbTransport = new System.Windows.Forms.GroupBox();
            this.chkUTransportB = new System.Windows.Forms.CheckBox();
            this.chkUTransportA = new System.Windows.Forms.CheckBox();
            this.btnExecUTransport = new System.Windows.Forms.Button();
            this.gbJig = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExecJigIndex = new System.Windows.Forms.Button();
            this.cmbJigIndex = new System.Windows.Forms.ComboBox();
            this.gbActiveStation = new System.Windows.Forms.GroupBox();
            this.btnExecActStation = new System.Windows.Forms.Button();
            this.cmbStation = new System.Windows.Forms.ComboBox();
            this.tpG6Rotary1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnlMessage = new System.Windows.Forms.Panel();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveMsg = new System.Windows.Forms.Button();
            this.btnClearMsg = new System.Windows.Forms.Button();
            this.lbMessage = new System.Windows.Forms.ListBox();
            this.pnlMain.SuspendLayout();
            this.tcMaintenance.SuspendLayout();
            this.tbLoadingStation.SuspendLayout();
            this.tcInputArea.SuspendLayout();
            this.tpStation.SuspendLayout();
            this.gbLockStation.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.gbCheckLotbox.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpUnload.SuspendLayout();
            this.gbReturn.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbUnload.SuspendLayout();
            this.gbTransport.SuspendLayout();
            this.gbJig.SuspendLayout();
            this.gbActiveStation.SuspendLayout();
            this.pnlMessage.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 698);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(3);
            this.pnlBottom.Size = new System.Drawing.Size(1182, 39);
            // 
            // pnlTop
            // 
            this.pnlTop.Margin = new System.Windows.Forms.Padding(3);
            this.pnlTop.Size = new System.Drawing.Size(1182, 39);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tcMaintenance);
            this.pnlMain.Controls.Add(this.pnlMessage);
            this.pnlMain.Location = new System.Drawing.Point(0, 39);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3);
            this.pnlMain.Size = new System.Drawing.Size(1182, 659);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "test 32x32.png");
            this.imageList.Images.SetKeyName(1, "input data 32x32.png");
            this.imageList.Images.SetKeyName(2, "switch 32x32.png");
            this.imageList.Images.SetKeyName(3, "calibration 32x32.png");
            this.imageList.Images.SetKeyName(4, "configuration 32x32.png");
            this.imageList.Images.SetKeyName(5, "signal2 32x32.png");
            this.imageList.Images.SetKeyName(6, "noise 32x32.png");
            this.imageList.Images.SetKeyName(7, "Resistance 32x32.png");
            this.imageList.Images.SetKeyName(8, "report 32x32.png");
            this.imageList.Images.SetKeyName(9, "box 32x32.png");
            this.imageList.Images.SetKeyName(10, "list 32x32.png");
            this.imageList.Images.SetKeyName(11, "ng 32x32.png");
            this.imageList.Images.SetKeyName(12, "close 32x32.png");
            this.imageList.Images.SetKeyName(13, "save 32x32.png");
            this.imageList.Images.SetKeyName(14, "add 32x32.png");
            this.imageList.Images.SetKeyName(15, "edit 32x32.png");
            this.imageList.Images.SetKeyName(16, "delete 32x32.png");
            this.imageList.Images.SetKeyName(17, "lock 32x32.png");
            this.imageList.Images.SetKeyName(18, "unlock2 32x32.png");
            this.imageList.Images.SetKeyName(19, "unlock 24x24.png");
            this.imageList.Images.SetKeyName(20, "lock 24x24.png");
            // 
            // tcMaintenance
            // 
            this.tcMaintenance.Controls.Add(this.tbLoadingStation);
            this.tcMaintenance.Controls.Add(this.tabPage2);
            this.tcMaintenance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMaintenance.Location = new System.Drawing.Point(0, 0);
            this.tcMaintenance.Margin = new System.Windows.Forms.Padding(2);
            this.tcMaintenance.Name = "tcMaintenance";
            this.tcMaintenance.SelectedIndex = 0;
            this.tcMaintenance.Size = new System.Drawing.Size(1178, 495);
            this.tcMaintenance.TabIndex = 0;
            // 
            // tbLoadingStation
            // 
            this.tbLoadingStation.Controls.Add(this.tcInputArea);
            this.tbLoadingStation.Location = new System.Drawing.Point(4, 25);
            this.tbLoadingStation.Margin = new System.Windows.Forms.Padding(2);
            this.tbLoadingStation.Name = "tbLoadingStation";
            this.tbLoadingStation.Padding = new System.Windows.Forms.Padding(2);
            this.tbLoadingStation.Size = new System.Drawing.Size(1170, 466);
            this.tbLoadingStation.TabIndex = 0;
            this.tbLoadingStation.Text = "Input Area";
            this.tbLoadingStation.UseVisualStyleBackColor = true;
            // 
            // tcInputArea
            // 
            this.tcInputArea.Controls.Add(this.tpStation);
            this.tcInputArea.Controls.Add(this.tpUnload);
            this.tcInputArea.Controls.Add(this.tpG6Rotary1);
            this.tcInputArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcInputArea.Location = new System.Drawing.Point(2, 2);
            this.tcInputArea.Name = "tcInputArea";
            this.tcInputArea.SelectedIndex = 0;
            this.tcInputArea.Size = new System.Drawing.Size(1166, 462);
            this.tcInputArea.TabIndex = 1;
            // 
            // tpStation
            // 
            this.tpStation.Controls.Add(this.gbLockStation);
            this.tpStation.Controls.Add(this.gbCheckLotbox);
            this.tpStation.Location = new System.Drawing.Point(4, 25);
            this.tpStation.Name = "tpStation";
            this.tpStation.Padding = new System.Windows.Forms.Padding(3);
            this.tpStation.Size = new System.Drawing.Size(1158, 433);
            this.tpStation.TabIndex = 0;
            this.tpStation.Text = "Station";
            this.tpStation.UseVisualStyleBackColor = true;
            // 
            // gbLockStation
            // 
            this.gbLockStation.Controls.Add(this.groupBox7);
            this.gbLockStation.Controls.Add(this.groupBox8);
            this.gbLockStation.Controls.Add(this.groupBox9);
            this.gbLockStation.Controls.Add(this.groupBox10);
            this.gbLockStation.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbLockStation.Location = new System.Drawing.Point(3, 63);
            this.gbLockStation.Margin = new System.Windows.Forms.Padding(2);
            this.gbLockStation.Name = "gbLockStation";
            this.gbLockStation.Padding = new System.Windows.Forms.Padding(2);
            this.gbLockStation.Size = new System.Drawing.Size(1152, 60);
            this.gbLockStation.TabIndex = 6;
            this.gbLockStation.TabStop = false;
            this.gbLockStation.Text = " Lock Station ";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnLockStation4);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(419, 18);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(731, 40);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = " Station 4 ";
            // 
            // btnLockStation4
            // 
            this.btnLockStation4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLockStation4.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnLockStation4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLockStation4.ImageIndex = 0;
            this.btnLockStation4.ImageList = this.imageList1;
            this.btnLockStation4.Location = new System.Drawing.Point(2, 18);
            this.btnLockStation4.Margin = new System.Windows.Forms.Padding(2);
            this.btnLockStation4.Name = "btnLockStation4";
            this.btnLockStation4.Size = new System.Drawing.Size(727, 20);
            this.btnLockStation4.TabIndex = 0;
            this.btnLockStation4.Tag = "4";
            this.btnLockStation4.Text = "Lock";
            this.btnLockStation4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLockStation4.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "lock 24x24.png");
            this.imageList1.Images.SetKeyName(1, "unlock 24x24.png");
            this.imageList1.Images.SetKeyName(2, "execute 24x24.png");
            this.imageList1.Images.SetKeyName(3, "checked2 24x24.png");
            this.imageList1.Images.SetKeyName(4, "unchecked2 24x24.png");
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnLockStation3);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox8.Location = new System.Drawing.Point(280, 18);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox8.Size = new System.Drawing.Size(139, 40);
            this.groupBox8.TabIndex = 2;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = " Station 3 ";
            // 
            // btnLockStation3
            // 
            this.btnLockStation3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLockStation3.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnLockStation3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLockStation3.ImageIndex = 0;
            this.btnLockStation3.ImageList = this.imageList1;
            this.btnLockStation3.Location = new System.Drawing.Point(2, 18);
            this.btnLockStation3.Margin = new System.Windows.Forms.Padding(2);
            this.btnLockStation3.Name = "btnLockStation3";
            this.btnLockStation3.Size = new System.Drawing.Size(135, 20);
            this.btnLockStation3.TabIndex = 1;
            this.btnLockStation3.Tag = "3";
            this.btnLockStation3.Text = "Lock";
            this.btnLockStation3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLockStation3.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnLockStation2);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox9.Location = new System.Drawing.Point(141, 18);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox9.Size = new System.Drawing.Size(139, 40);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = " Station 2 ";
            // 
            // btnLockStation2
            // 
            this.btnLockStation2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLockStation2.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnLockStation2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLockStation2.ImageIndex = 0;
            this.btnLockStation2.ImageList = this.imageList1;
            this.btnLockStation2.Location = new System.Drawing.Point(2, 18);
            this.btnLockStation2.Margin = new System.Windows.Forms.Padding(2);
            this.btnLockStation2.Name = "btnLockStation2";
            this.btnLockStation2.Size = new System.Drawing.Size(135, 20);
            this.btnLockStation2.TabIndex = 1;
            this.btnLockStation2.Tag = "2";
            this.btnLockStation2.Text = "Lock";
            this.btnLockStation2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLockStation2.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnLockStation1);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox10.Location = new System.Drawing.Point(2, 18);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox10.Size = new System.Drawing.Size(139, 40);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = " Station 1 ";
            // 
            // btnLockStation1
            // 
            this.btnLockStation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLockStation1.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnLockStation1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLockStation1.ImageIndex = 0;
            this.btnLockStation1.ImageList = this.imageList1;
            this.btnLockStation1.Location = new System.Drawing.Point(2, 18);
            this.btnLockStation1.Margin = new System.Windows.Forms.Padding(2);
            this.btnLockStation1.Name = "btnLockStation1";
            this.btnLockStation1.Size = new System.Drawing.Size(135, 20);
            this.btnLockStation1.TabIndex = 1;
            this.btnLockStation1.Tag = "1";
            this.btnLockStation1.Text = "Lock";
            this.btnLockStation1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLockStation1.UseVisualStyleBackColor = true;
            // 
            // gbCheckLotbox
            // 
            this.gbCheckLotbox.Controls.Add(this.groupBox5);
            this.gbCheckLotbox.Controls.Add(this.groupBox4);
            this.gbCheckLotbox.Controls.Add(this.groupBox3);
            this.gbCheckLotbox.Controls.Add(this.groupBox2);
            this.gbCheckLotbox.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbCheckLotbox.Location = new System.Drawing.Point(3, 3);
            this.gbCheckLotbox.Name = "gbCheckLotbox";
            this.gbCheckLotbox.Size = new System.Drawing.Size(1152, 60);
            this.gbCheckLotbox.TabIndex = 5;
            this.gbCheckLotbox.TabStop = false;
            this.gbCheckLotbox.Text = " Check Lotbox ";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkStation4);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(345, 19);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(804, 38);
            this.groupBox5.TabIndex = 7;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " Station 4 ";
            // 
            // chkStation4
            // 
            this.chkStation4.AutoCheck = false;
            this.chkStation4.AutoSize = true;
            this.chkStation4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkStation4.Location = new System.Drawing.Point(2, 18);
            this.chkStation4.Margin = new System.Windows.Forms.Padding(2);
            this.chkStation4.Name = "chkStation4";
            this.chkStation4.Size = new System.Drawing.Size(800, 18);
            this.chkStation4.TabIndex = 0;
            this.chkStation4.Text = "Empty";
            this.chkStation4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkStation3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(231, 19);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(114, 38);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " Station 3 ";
            // 
            // chkStation3
            // 
            this.chkStation3.AutoCheck = false;
            this.chkStation3.AutoSize = true;
            this.chkStation3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkStation3.Location = new System.Drawing.Point(2, 18);
            this.chkStation3.Margin = new System.Windows.Forms.Padding(2);
            this.chkStation3.Name = "chkStation3";
            this.chkStation3.Size = new System.Drawing.Size(110, 18);
            this.chkStation3.TabIndex = 0;
            this.chkStation3.Text = "Empty";
            this.chkStation3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkStation2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(117, 19);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(114, 38);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Station 2 ";
            // 
            // chkStation2
            // 
            this.chkStation2.AutoCheck = false;
            this.chkStation2.AutoSize = true;
            this.chkStation2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkStation2.Location = new System.Drawing.Point(2, 18);
            this.chkStation2.Margin = new System.Windows.Forms.Padding(2);
            this.chkStation2.Name = "chkStation2";
            this.chkStation2.Size = new System.Drawing.Size(110, 18);
            this.chkStation2.TabIndex = 0;
            this.chkStation2.Text = "Empty";
            this.chkStation2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkStation1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 19);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(114, 38);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Station 1 ";
            // 
            // chkStation1
            // 
            this.chkStation1.AutoCheck = false;
            this.chkStation1.AutoSize = true;
            this.chkStation1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkStation1.Location = new System.Drawing.Point(2, 18);
            this.chkStation1.Margin = new System.Windows.Forms.Padding(2);
            this.chkStation1.Name = "chkStation1";
            this.chkStation1.Size = new System.Drawing.Size(110, 18);
            this.chkStation1.TabIndex = 0;
            this.chkStation1.Text = "Empty";
            this.chkStation1.UseVisualStyleBackColor = true;
            // 
            // tpUnload
            // 
            this.tpUnload.Controls.Add(this.gbReturn);
            this.tpUnload.Controls.Add(this.gbUnload);
            this.tpUnload.Location = new System.Drawing.Point(4, 25);
            this.tpUnload.Name = "tpUnload";
            this.tpUnload.Padding = new System.Windows.Forms.Padding(3);
            this.tpUnload.Size = new System.Drawing.Size(1158, 433);
            this.tpUnload.TabIndex = 1;
            this.tpUnload.Text = "Unload Jig Fukuda";
            this.tpUnload.UseVisualStyleBackColor = true;
            // 
            // gbReturn
            // 
            this.gbReturn.Controls.Add(this.groupBox6);
            this.gbReturn.Controls.Add(this.groupBox1);
            this.gbReturn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbReturn.Location = new System.Drawing.Point(626, 3);
            this.gbReturn.Name = "gbReturn";
            this.gbReturn.Size = new System.Drawing.Size(529, 427);
            this.gbReturn.TabIndex = 1;
            this.gbReturn.TabStop = false;
            this.gbReturn.Text = " Return Procces ";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnDoneB);
            this.groupBox6.Controls.Add(this.btnDoneA);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 90);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(523, 71);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = " Pick Done ";
            // 
            // btnDoneB
            // 
            this.btnDoneB.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnDoneB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoneB.ImageIndex = 2;
            this.btnDoneB.ImageList = this.imageList1;
            this.btnDoneB.Location = new System.Drawing.Point(156, 22);
            this.btnDoneB.Name = "btnDoneB";
            this.btnDoneB.Size = new System.Drawing.Size(139, 34);
            this.btnDoneB.TabIndex = 4;
            this.btnDoneB.Text = "Pick Done B";
            this.btnDoneB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoneB.UseVisualStyleBackColor = true;
            this.btnDoneB.Click += new System.EventHandler(this.btnDoneB_Click);
            // 
            // btnDoneA
            // 
            this.btnDoneA.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnDoneA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoneA.ImageIndex = 2;
            this.btnDoneA.ImageList = this.imageList1;
            this.btnDoneA.Location = new System.Drawing.Point(10, 22);
            this.btnDoneA.Name = "btnDoneA";
            this.btnDoneA.Size = new System.Drawing.Size(140, 34);
            this.btnDoneA.TabIndex = 3;
            this.btnDoneA.Text = "Pick Done A";
            this.btnDoneA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoneA.UseVisualStyleBackColor = true;
            this.btnDoneA.Click += new System.EventHandler(this.btnDoneA_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRTransportB);
            this.groupBox1.Controls.Add(this.chkRTransportA);
            this.groupBox1.Controls.Add(this.btnExecRTransport);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(523, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Transport ";
            // 
            // chkRTransportB
            // 
            this.chkRTransportB.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRTransportB.Enabled = false;
            this.chkRTransportB.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.chkRTransportB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRTransportB.ImageIndex = 4;
            this.chkRTransportB.ImageList = this.imageList1;
            this.chkRTransportB.Location = new System.Drawing.Point(133, 23);
            this.chkRTransportB.Name = "chkRTransportB";
            this.chkRTransportB.Size = new System.Drawing.Size(117, 34);
            this.chkRTransportB.TabIndex = 6;
            this.chkRTransportB.Text = "Transport B";
            this.chkRTransportB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkRTransportB.UseVisualStyleBackColor = true;
            this.chkRTransportB.CheckedChanged += new System.EventHandler(this.chkTransportA_CheckedChanged);
            // 
            // chkRTransportA
            // 
            this.chkRTransportA.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRTransportA.Enabled = false;
            this.chkRTransportA.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.chkRTransportA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRTransportA.ImageIndex = 4;
            this.chkRTransportA.ImageList = this.imageList1;
            this.chkRTransportA.Location = new System.Drawing.Point(10, 23);
            this.chkRTransportA.Name = "chkRTransportA";
            this.chkRTransportA.Size = new System.Drawing.Size(117, 34);
            this.chkRTransportA.TabIndex = 5;
            this.chkRTransportA.Text = "Transport A";
            this.chkRTransportA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkRTransportA.UseVisualStyleBackColor = true;
            this.chkRTransportA.CheckedChanged += new System.EventHandler(this.chkTransportA_CheckedChanged);
            // 
            // btnExecRTransport
            // 
            this.btnExecRTransport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExecRTransport.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnExecRTransport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecRTransport.ImageIndex = 2;
            this.btnExecRTransport.ImageList = this.imageList1;
            this.btnExecRTransport.Location = new System.Drawing.Point(408, 23);
            this.btnExecRTransport.Name = "btnExecRTransport";
            this.btnExecRTransport.Size = new System.Drawing.Size(107, 34);
            this.btnExecRTransport.TabIndex = 3;
            this.btnExecRTransport.Text = "Execute";
            this.btnExecRTransport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExecRTransport.UseVisualStyleBackColor = true;
            this.btnExecRTransport.Click += new System.EventHandler(this.btnExecRTransport_Click);
            // 
            // gbUnload
            // 
            this.gbUnload.Controls.Add(this.gbTransport);
            this.gbUnload.Controls.Add(this.gbJig);
            this.gbUnload.Controls.Add(this.gbActiveStation);
            this.gbUnload.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbUnload.Location = new System.Drawing.Point(3, 3);
            this.gbUnload.Name = "gbUnload";
            this.gbUnload.Size = new System.Drawing.Size(623, 427);
            this.gbUnload.TabIndex = 0;
            this.gbUnload.TabStop = false;
            this.gbUnload.Text = " Unload Jig ";
            // 
            // gbTransport
            // 
            this.gbTransport.Controls.Add(this.chkUTransportB);
            this.gbTransport.Controls.Add(this.chkUTransportA);
            this.gbTransport.Controls.Add(this.btnExecUTransport);
            this.gbTransport.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTransport.Location = new System.Drawing.Point(3, 155);
            this.gbTransport.Name = "gbTransport";
            this.gbTransport.Size = new System.Drawing.Size(617, 71);
            this.gbTransport.TabIndex = 3;
            this.gbTransport.TabStop = false;
            this.gbTransport.Text = " Transport ";
            // 
            // chkUTransportB
            // 
            this.chkUTransportB.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUTransportB.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.chkUTransportB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUTransportB.ImageIndex = 4;
            this.chkUTransportB.ImageList = this.imageList1;
            this.chkUTransportB.Location = new System.Drawing.Point(133, 23);
            this.chkUTransportB.Name = "chkUTransportB";
            this.chkUTransportB.Size = new System.Drawing.Size(117, 34);
            this.chkUTransportB.TabIndex = 6;
            this.chkUTransportB.Text = "Transport B";
            this.chkUTransportB.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkUTransportB.UseVisualStyleBackColor = true;
            this.chkUTransportB.CheckedChanged += new System.EventHandler(this.chkTransportA_CheckedChanged);
            // 
            // chkUTransportA
            // 
            this.chkUTransportA.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkUTransportA.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.chkUTransportA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUTransportA.ImageIndex = 4;
            this.chkUTransportA.ImageList = this.imageList1;
            this.chkUTransportA.Location = new System.Drawing.Point(10, 23);
            this.chkUTransportA.Name = "chkUTransportA";
            this.chkUTransportA.Size = new System.Drawing.Size(117, 34);
            this.chkUTransportA.TabIndex = 5;
            this.chkUTransportA.Text = "Transport A";
            this.chkUTransportA.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkUTransportA.UseVisualStyleBackColor = true;
            this.chkUTransportA.CheckedChanged += new System.EventHandler(this.chkTransportA_CheckedChanged);
            // 
            // btnExecUTransport
            // 
            this.btnExecUTransport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExecUTransport.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnExecUTransport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecUTransport.ImageIndex = 2;
            this.btnExecUTransport.ImageList = this.imageList1;
            this.btnExecUTransport.Location = new System.Drawing.Point(502, 23);
            this.btnExecUTransport.Name = "btnExecUTransport";
            this.btnExecUTransport.Size = new System.Drawing.Size(107, 34);
            this.btnExecUTransport.TabIndex = 3;
            this.btnExecUTransport.Text = "Execute";
            this.btnExecUTransport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExecUTransport.UseVisualStyleBackColor = true;
            this.btnExecUTransport.Click += new System.EventHandler(this.btnExecUTransport_Click);
            // 
            // gbJig
            // 
            this.gbJig.Controls.Add(this.label1);
            this.gbJig.Controls.Add(this.btnExecJigIndex);
            this.gbJig.Controls.Add(this.cmbJigIndex);
            this.gbJig.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbJig.Location = new System.Drawing.Point(3, 80);
            this.gbJig.Name = "gbJig";
            this.gbJig.Size = new System.Drawing.Size(617, 75);
            this.gbJig.TabIndex = 2;
            this.gbJig.TabStop = false;
            this.gbJig.Text = " Jig Index ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "(Execute will also move to selected station)";
            // 
            // btnExecJigIndex
            // 
            this.btnExecJigIndex.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExecJigIndex.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnExecJigIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecJigIndex.ImageIndex = 2;
            this.btnExecJigIndex.ImageList = this.imageList1;
            this.btnExecJigIndex.Location = new System.Drawing.Point(502, 19);
            this.btnExecJigIndex.Name = "btnExecJigIndex";
            this.btnExecJigIndex.Size = new System.Drawing.Size(107, 34);
            this.btnExecJigIndex.TabIndex = 3;
            this.btnExecJigIndex.Text = "Execute";
            this.btnExecJigIndex.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExecJigIndex.UseVisualStyleBackColor = true;
            this.btnExecJigIndex.Click += new System.EventHandler(this.btnExecJigIndex_Click);
            // 
            // cmbJigIndex
            // 
            this.cmbJigIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbJigIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJigIndex.FormattingEnabled = true;
            this.cmbJigIndex.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cmbJigIndex.Location = new System.Drawing.Point(7, 23);
            this.cmbJigIndex.Name = "cmbJigIndex";
            this.cmbJigIndex.Size = new System.Drawing.Size(487, 24);
            this.cmbJigIndex.TabIndex = 2;
            // 
            // gbActiveStation
            // 
            this.gbActiveStation.Controls.Add(this.btnExecActStation);
            this.gbActiveStation.Controls.Add(this.cmbStation);
            this.gbActiveStation.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbActiveStation.Location = new System.Drawing.Point(3, 19);
            this.gbActiveStation.Name = "gbActiveStation";
            this.gbActiveStation.Size = new System.Drawing.Size(617, 61);
            this.gbActiveStation.TabIndex = 1;
            this.gbActiveStation.TabStop = false;
            this.gbActiveStation.Text = " Active Station";
            // 
            // btnExecActStation
            // 
            this.btnExecActStation.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnExecActStation.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnExecActStation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExecActStation.ImageIndex = 2;
            this.btnExecActStation.ImageList = this.imageList1;
            this.btnExecActStation.Location = new System.Drawing.Point(502, 19);
            this.btnExecActStation.Name = "btnExecActStation";
            this.btnExecActStation.Size = new System.Drawing.Size(107, 34);
            this.btnExecActStation.TabIndex = 1;
            this.btnExecActStation.Text = "Execute";
            this.btnExecActStation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExecActStation.UseVisualStyleBackColor = true;
            this.btnExecActStation.Click += new System.EventHandler(this.btnExecActStation_Click);
            // 
            // cmbStation
            // 
            this.cmbStation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStation.FormattingEnabled = true;
            this.cmbStation.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cmbStation.Location = new System.Drawing.Point(7, 23);
            this.cmbStation.Name = "cmbStation";
            this.cmbStation.Size = new System.Drawing.Size(487, 24);
            this.cmbStation.TabIndex = 0;
            // 
            // tpG6Rotary1
            // 
            this.tpG6Rotary1.Location = new System.Drawing.Point(4, 25);
            this.tpG6Rotary1.Name = "tpG6Rotary1";
            this.tpG6Rotary1.Padding = new System.Windows.Forms.Padding(3);
            this.tpG6Rotary1.Size = new System.Drawing.Size(1158, 433);
            this.tpG6Rotary1.TabIndex = 2;
            this.tpG6Rotary1.Text = "tabPage1";
            this.tpG6Rotary1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(770, 311);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pnlMessage
            // 
            this.pnlMessage.Controls.Add(this.groupBox11);
            this.pnlMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlMessage.Location = new System.Drawing.Point(0, 495);
            this.pnlMessage.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMessage.Name = "pnlMessage";
            this.pnlMessage.Size = new System.Drawing.Size(1178, 160);
            this.pnlMessage.TabIndex = 2;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.panel1);
            this.groupBox11.Controls.Add(this.lbMessage);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(0, 0);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox11.Size = new System.Drawing.Size(1178, 160);
            this.groupBox11.TabIndex = 0;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = " Messages ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveMsg);
            this.panel1.Controls.Add(this.btnClearMsg);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1174, 42);
            this.panel1.TabIndex = 1;
            // 
            // btnSaveMsg
            // 
            this.btnSaveMsg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveMsg.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnSaveMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveMsg.ImageList = this.imageList1;
            this.btnSaveMsg.Location = new System.Drawing.Point(946, 5);
            this.btnSaveMsg.Name = "btnSaveMsg";
            this.btnSaveMsg.Size = new System.Drawing.Size(107, 34);
            this.btnSaveMsg.TabIndex = 5;
            this.btnSaveMsg.Text = "Save";
            this.btnSaveMsg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveMsg.UseVisualStyleBackColor = true;
            // 
            // btnClearMsg
            // 
            this.btnClearMsg.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClearMsg.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnClearMsg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearMsg.ImageList = this.imageList1;
            this.btnClearMsg.Location = new System.Drawing.Point(1059, 5);
            this.btnClearMsg.Name = "btnClearMsg";
            this.btnClearMsg.Size = new System.Drawing.Size(107, 34);
            this.btnClearMsg.TabIndex = 4;
            this.btnClearMsg.Text = "Clear";
            this.btnClearMsg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClearMsg.UseVisualStyleBackColor = true;
            // 
            // lbMessage
            // 
            this.lbMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMessage.FormattingEnabled = true;
            this.lbMessage.ItemHeight = 16;
            this.lbMessage.Location = new System.Drawing.Point(2, 18);
            this.lbMessage.Margin = new System.Windows.Forms.Padding(2);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(1174, 140);
            this.lbMessage.TabIndex = 0;
            // 
            // frmMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1182, 737);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormCaption = "Maintenance";
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMaintenance";
            this.pnlMain.ResumeLayout(false);
            this.tcMaintenance.ResumeLayout(false);
            this.tbLoadingStation.ResumeLayout(false);
            this.tcInputArea.ResumeLayout(false);
            this.tpStation.ResumeLayout(false);
            this.gbLockStation.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.gbCheckLotbox.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpUnload.ResumeLayout(false);
            this.gbReturn.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbUnload.ResumeLayout(false);
            this.gbTransport.ResumeLayout(false);
            this.gbJig.ResumeLayout(false);
            this.gbJig.PerformLayout();
            this.gbActiveStation.ResumeLayout(false);
            this.pnlMessage.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMaintenance;
        private System.Windows.Forms.TabPage tbLoadingStation;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel pnlMessage;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.ListBox lbMessage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tcInputArea;
        private System.Windows.Forms.TabPage tpStation;
        private System.Windows.Forms.GroupBox gbLockStation;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnLockStation4;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnLockStation3;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnLockStation2;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Button btnLockStation1;
        private System.Windows.Forms.GroupBox gbCheckLotbox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox chkStation4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkStation3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkStation2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkStation1;
        private System.Windows.Forms.TabPage tpUnload;
        private System.Windows.Forms.GroupBox gbReturn;
        private System.Windows.Forms.GroupBox gbUnload;
        private System.Windows.Forms.GroupBox gbActiveStation;
        private System.Windows.Forms.Button btnExecActStation;
        private System.Windows.Forms.ComboBox cmbStation;
        private System.Windows.Forms.GroupBox gbJig;
        private System.Windows.Forms.Button btnExecJigIndex;
        private System.Windows.Forms.ComboBox cmbJigIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbTransport;
        private System.Windows.Forms.CheckBox chkUTransportB;
        private System.Windows.Forms.CheckBox chkUTransportA;
        private System.Windows.Forms.Button btnExecUTransport;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRTransportB;
        private System.Windows.Forms.CheckBox chkRTransportA;
        private System.Windows.Forms.Button btnExecRTransport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveMsg;
        private System.Windows.Forms.Button btnClearMsg;
        private System.Windows.Forms.TabPage tpG6Rotary1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnDoneA;
        private System.Windows.Forms.Button btnDoneB;
    }
}
