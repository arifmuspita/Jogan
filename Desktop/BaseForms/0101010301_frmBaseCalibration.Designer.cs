namespace Desktop.BaseForms
{
    partial class frmBaseCalibration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseCalibration));
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.calibrationControl = new Desktop.Controls.CalibrationControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbCS = new System.Windows.Forms.GroupBox();
            this.pnlCS = new System.Windows.Forms.Panel();
            this.pnlA = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbMachine = new System.Windows.Forms.ComboBox();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbCS.SuspendLayout();
            this.pnlA.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout(); 
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 490);
            this.pnlBottom.Size = new System.Drawing.Size(994, 54); 
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(994, 54);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel2);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.pnlA);
            this.pnlMain.Size = new System.Drawing.Size(994, 436);
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
            this.imageList.Images.SetKeyName(17, "restart 32x32.png");
            this.imageList.Images.SetKeyName(18, "start 32x32.png");
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 374);
            this.panel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.calibrationControl);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(780, 374);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Calibration Values ";
            // 
            // calibrationControl
            // 
            this.calibrationControl.CalibrationValues = ((System.Collections.Generic.List<double>)(resources.GetObject("calibrationControl.CalibrationValues")));
            this.calibrationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calibrationControl.Location = new System.Drawing.Point(3, 20);
            this.calibrationControl.Name = "calibrationControl";
            this.calibrationControl.Size = new System.Drawing.Size(774, 351);
            this.calibrationControl.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbCS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(780, 58);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(210, 374);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // gbCS
            // 
            this.gbCS.Controls.Add(this.pnlCS);
            this.gbCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCS.Location = new System.Drawing.Point(0, 0);
            this.gbCS.Name = "gbCS";
            this.gbCS.Size = new System.Drawing.Size(210, 374);
            this.gbCS.TabIndex = 2;
            this.gbCS.TabStop = false;
            this.gbCS.Text = " Close Socket ";
            this.gbCS.Visible = false;
            // 
            // pnlCS
            // 
            this.pnlCS.AutoScroll = true;
            this.pnlCS.AutoSize = true;
            this.pnlCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCS.Location = new System.Drawing.Point(3, 20);
            this.pnlCS.Name = "pnlCS";
            this.pnlCS.Size = new System.Drawing.Size(204, 351);
            this.pnlCS.TabIndex = 0;
            // 
            // pnlA
            // 
            this.pnlA.Controls.Add(this.groupBox3);
            this.pnlA.Controls.Add(this.groupBox2);
            this.pnlA.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlA.Location = new System.Drawing.Point(0, 0);
            this.pnlA.Name = "pnlA";
            this.pnlA.Size = new System.Drawing.Size(990, 58);
            this.pnlA.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbType);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(210, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(210, 58);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Type ";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(13, 20);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(187, 26);
            this.cmbType.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbMachine);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 58);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Machine ";
            // 
            // cmbMachine
            // 
            this.cmbMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachine.FormattingEnabled = true;
            this.cmbMachine.Location = new System.Drawing.Point(13, 20);
            this.cmbMachine.Name = "cmbMachine";
            this.cmbMachine.Size = new System.Drawing.Size(187, 26);
            this.cmbMachine.TabIndex = 0;
            // 
            // frmBaseCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(994, 544);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MinimumSize = new System.Drawing.Size(800, 550);
            this.Name = "frmBaseCalibration";
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbCS.ResumeLayout(false);
            this.gbCS.PerformLayout();
            this.pnlA.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.CalibrationControl calibrationControl;
        private System.Windows.Forms.GroupBox gbCS;
        private System.Windows.Forms.Panel pnlCS;
        private System.Windows.Forms.Panel pnlA;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbMachine;
    }
}
