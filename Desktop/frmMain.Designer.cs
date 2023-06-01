namespace Desktop
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.pnlMenuBottom = new System.Windows.Forms.Panel();
            this.pnlMenuTop = new System.Windows.Forms.Panel();
            this.pnlExit = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asControllerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asWatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testingControl = new Desktop.Controls.Testing.TestingControl();
            this.pnlBottom2 = new System.Windows.Forms.Panel();
            this.toolStripChild = new System.Windows.Forms.ToolStrip();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlExit.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlBottom2.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.pnlMenu);
            this.pnlBottom.Controls.Add(this.pnlExit);
            this.pnlBottom.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pnlBottom.Location = new System.Drawing.Point(0, 808);
            this.pnlBottom.Size = new System.Drawing.Size(1914, 157);
            this.pnlBottom.Visible = false;
            this.pnlBottom.Controls.SetChildIndex(this.pnlExit, 0);
            this.pnlBottom.Controls.SetChildIndex(this.pnlMenu, 0);
            // 
            // pnlTop
            // 
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.None;
            this.pnlTop.Location = new System.Drawing.Point(0, 32);
            this.pnlTop.Size = new System.Drawing.Size(0, 0);
            this.pnlTop.Visible = false;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.testingControl);
            this.pnlMain.Controls.Add(this.menuStrip1);
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Size = new System.Drawing.Size(1914, 808);
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
            // 
            // pnlMenu
            // 
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Controls.Add(this.pnlMenuBottom);
            this.pnlMenu.Controls.Add(this.pnlMenuTop);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(1757, 157);
            this.pnlMenu.TabIndex = 7;
            // 
            // pnlMenuBottom
            // 
            this.pnlMenuBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenuBottom.Location = new System.Drawing.Point(0, 68);
            this.pnlMenuBottom.Name = "pnlMenuBottom";
            this.pnlMenuBottom.Size = new System.Drawing.Size(1755, 87);
            this.pnlMenuBottom.TabIndex = 1;
            // 
            // pnlMenuTop
            // 
            this.pnlMenuTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMenuTop.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuTop.Name = "pnlMenuTop";
            this.pnlMenuTop.Size = new System.Drawing.Size(1755, 68);
            this.pnlMenuTop.TabIndex = 0;
            // 
            // pnlExit
            // 
            this.pnlExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlExit.Controls.Add(this.btnExit);
            this.pnlExit.Controls.Add(this.btnLogout);
            this.pnlExit.Controls.Add(this.btnLogin);
            this.pnlExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlExit.Location = new System.Drawing.Point(1757, 0);
            this.pnlExit.Name = "pnlExit";
            this.pnlExit.Size = new System.Drawing.Size(157, 157);
            this.pnlExit.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 2;
            this.btnExit.Location = new System.Drawing.Point(16, 106);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(127, 43);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Enabled = false;
            this.btnLogout.Location = new System.Drawing.Point(16, 56);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(127, 43);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(16, 11);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(127, 43);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1910, 28);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asControllerToolStripMenuItem,
            this.asWatcherToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // asControllerToolStripMenuItem
            // 
            this.asControllerToolStripMenuItem.Name = "asControllerToolStripMenuItem";
            this.asControllerToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.asControllerToolStripMenuItem.Text = "As Controller";
            // 
            // asWatcherToolStripMenuItem
            // 
            this.asWatcherToolStripMenuItem.Name = "asWatcherToolStripMenuItem";
            this.asWatcherToolStripMenuItem.Size = new System.Drawing.Size(170, 26);
            this.asWatcherToolStripMenuItem.Text = "As Watcher";
            // 
            // testingControl
            // 
            this.testingControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testingControl.Location = new System.Drawing.Point(0, 28);
            this.testingControl.Name = "testingControl";
            this.testingControl.Size = new System.Drawing.Size(1910, 776);
            this.testingControl.TabIndex = 8;
            this.testingControl.StatusChanged += new Desktop.DesktopProperties.EventStatusChanged(this.testingControl_StatusChanged);
            // 
            // pnlBottom2
            // 
            this.pnlBottom2.Controls.Add(this.toolStripChild);
            this.pnlBottom2.Controls.Add(this.toolStripMain);
            this.pnlBottom2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom2.Location = new System.Drawing.Point(0, 965);
            this.pnlBottom2.Name = "pnlBottom2";
            this.pnlBottom2.Size = new System.Drawing.Size(1914, 80);
            this.pnlBottom2.TabIndex = 9;
            // 
            // toolStripChild
            // 
            this.toolStripChild.AutoSize = false;
            this.toolStripChild.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripChild.Location = new System.Drawing.Point(0, 40);
            this.toolStripChild.Name = "toolStripChild";
            this.toolStripChild.Size = new System.Drawing.Size(1914, 40);
            this.toolStripChild.TabIndex = 1;
            this.toolStripChild.Text = "toolStrip1";
            // 
            // toolStripMain
            // 
            this.toolStripMain.AutoSize = false;
            this.toolStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator4,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripSeparator3});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1914, 40);
            this.toolStripMain.TabIndex = 0;
            this.toolStripMain.Text = "toolStrip1";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.CheckOnClick = true;
            this.toolStripButton1.Image = global::Desktop.Properties.Resources.exit_32x32;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(57, 37);
            this.toolStripButton1.Text = "Exit";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton2.CheckOnClick = true;
            this.toolStripButton2.Image = global::Desktop.Properties.Resources.logout_32x32_1_;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(80, 37);
            this.toolStripButton2.Text = "Logout";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton3.CheckOnClick = true;
            this.toolStripButton3.Image = global::Desktop.Properties.Resources.login_32x32;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(70, 37);
            this.toolStripButton3.Text = "Login";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 40);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1914, 1045);
            this.Controls.Add(this.pnlBottom2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "JOGAN Desktop Application";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.Controls.SetChildIndex(this.pnlBottom2, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlMenu.ResumeLayout(false);
            this.pnlExit.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlBottom2.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlMenuBottom;
        private System.Windows.Forms.Panel pnlMenuTop;
        private System.Windows.Forms.Panel pnlExit;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asControllerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asWatcherToolStripMenuItem;
        private Controls.Testing.TestingControl testingControl;
        private System.Windows.Forms.Panel pnlBottom2;
        private System.Windows.Forms.ToolStrip toolStripChild;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}