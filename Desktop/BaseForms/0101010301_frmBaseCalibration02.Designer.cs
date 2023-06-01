namespace Desktop.BaseForms
{
    partial class frmBaseCalibration02
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
            this.btnStart = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbCS = new System.Windows.Forms.GroupBox();
            this.pnlCS = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbMachine = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.calibrationControl = new Desktop.Controls.CalibrationControl02();
            this.btnRestart = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cbCS.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout(); 
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnRestart);
            this.pnlBottom.Controls.Add(this.btnStart);
            this.pnlBottom.Location = new System.Drawing.Point(0, 499);
            this.pnlBottom.Size = new System.Drawing.Size(1194, 54); 
            this.pnlBottom.Controls.SetChildIndex(this.btnStart, 0);
            this.pnlBottom.Controls.SetChildIndex(this.btnRestart, 0); 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(1194, 54);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Size = new System.Drawing.Size(1194, 445); 
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnStart.Location = new System.Drawing.Point(669, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 30);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbCS);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(961, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 441);
            this.panel1.TabIndex = 0;
            // 
            // cbCS
            // 
            this.cbCS.Controls.Add(this.pnlCS);
            this.cbCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCS.Location = new System.Drawing.Point(0, 64);
            this.cbCS.Name = "cbCS";
            this.cbCS.Size = new System.Drawing.Size(229, 377);
            this.cbCS.TabIndex = 1;
            this.cbCS.TabStop = false;
            this.cbCS.Text = " Close Socket ";
            // 
            // pnlCS
            // 
            this.pnlCS.AutoScroll = true;
            this.pnlCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCS.Location = new System.Drawing.Point(3, 20);
            this.pnlCS.Name = "pnlCS";
            this.pnlCS.Size = new System.Drawing.Size(223, 354);
            this.pnlCS.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbMachine);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 64);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Machine ";
            // 
            // cmbMachine
            // 
            this.cmbMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachine.FormattingEnabled = true;
            this.cmbMachine.Location = new System.Drawing.Point(11, 23);
            this.cmbMachine.Name = "cmbMachine";
            this.cmbMachine.Size = new System.Drawing.Size(208, 26);
            this.cmbMachine.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(961, 441);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.calibrationControl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(961, 441);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Calibration ";
            // 
            // calibrationControl
            // 
            this.calibrationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrationControl.Location = new System.Drawing.Point(3, 20);
            this.calibrationControl.Name = "calibrationControl";
            this.calibrationControl.Size = new System.Drawing.Size(955, 418);
            this.calibrationControl.TabIndex = 0;
            this.calibrationControl.TestReference = Desktop.DesktopProperties.TestReference.None;
            // 
            // btnRestart
            // 
            this.btnRestart.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRestart.Enabled = false;
            this.btnRestart.Location = new System.Drawing.Point(499, 12);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(80, 30);
            this.btnRestart.TabIndex = 0;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            // 
            // frmBaseCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1194, 553);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmBaseCalibration";
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.cbCS.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox cbCS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlCS;
        protected Controls.CalibrationControl02 calibrationControl;
        protected System.Windows.Forms.ComboBox cmbMachine;
        private System.Windows.Forms.Button btnRestart;
    }
}
