namespace Desktop.Forms
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPasswd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBadgeNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.gbLogin.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 238);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.pnlBottom.Size = new System.Drawing.Size(382, 44);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(382, 54);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gbLogin);
            this.pnlMain.Location = new System.Drawing.Point(0, 54);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.pnlMain.Size = new System.Drawing.Size(382, 184);
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
            this.imageList.Images.SetKeyName(13, "delete 32x32.png");
            this.imageList.Images.SetKeyName(14, "edit 32x32.png");
            this.imageList.Images.SetKeyName(15, "save 32x32.png");
            this.imageList.Images.SetKeyName(16, "add 32x32.png");
            this.imageList.Images.SetKeyName(17, "login 32x32.png");
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.panel2);
            this.gbLogin.Controls.Add(this.panel1);
            this.gbLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLogin.Location = new System.Drawing.Point(0, 0);
            this.gbLogin.Margin = new System.Windows.Forms.Padding(4);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Padding = new System.Windows.Forms.Padding(4);
            this.gbLogin.Size = new System.Drawing.Size(378, 180);
            this.gbLogin.TabIndex = 1;
            this.gbLogin.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnLogin);
            this.panel2.Controls.Add(this.txtPasswd);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtBadgeNo);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(57, 21);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 155);
            this.panel2.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogin.ImageIndex = 17;
            this.btnLogin.ImageList = this.imageList;
            this.btnLogin.Location = new System.Drawing.Point(133, 91);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(106, 34);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPasswd
            // 
            this.txtPasswd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswd.Location = new System.Drawing.Point(133, 59);
            this.txtPasswd.Margin = new System.Windows.Forms.Padding(4);
            this.txtPasswd.Name = "txtPasswd";
            this.txtPasswd.PasswordChar = '*';
            this.txtPasswd.Size = new System.Drawing.Size(170, 24);
            this.txtPasswd.TabIndex = 1;
            this.txtPasswd.Text = "jogan";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = " : ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Password";
            // 
            // txtBadgeNo
            // 
            this.txtBadgeNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBadgeNo.Location = new System.Drawing.Point(133, 27);
            this.txtBadgeNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtBadgeNo.Name = "txtBadgeNo";
            this.txtBadgeNo.Size = new System.Drawing.Size(170, 24);
            this.txtBadgeNo.TabIndex = 0;
            this.txtBadgeNo.Text = "a";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = " : ";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "User ID";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(4, 21);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(53, 155);
            this.panel1.TabIndex = 0;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(382, 282);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.FormCaption = "Login";
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmLogin";
            this.Resize += new System.EventHandler(this.frmLogin_Resize);
            this.pnlMain.ResumeLayout(false);
            this.gbLogin.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPasswd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBadgeNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLogin;
    }
}
