namespace Desktop.Forms.Calibration
{
    partial class frmCalibration02
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
            this.tcCalibration = new System.Windows.Forms.TabControl();
            this.tpNoiseCalibration = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ccNoise = new Desktop.Controls.CalibrationControl02();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbCS = new System.Windows.Forms.GroupBox();
            this.pnlNoiseCS = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbNoiseMachine = new System.Windows.Forms.ComboBox();
            this.pnlBottomNoise = new System.Windows.Forms.Panel();
            this.btnSaveNoise = new System.Windows.Forms.Button();
            this.btnRestartNoise = new System.Windows.Forms.Button();
            this.btnStartNoise = new System.Windows.Forms.Button();
            this.tpSignalCalibration = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ccSignal = new Desktop.Controls.CalibrationControl02();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pnlSignalCS = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmbSignalMachine = new System.Windows.Forms.ComboBox();
            this.pnlBottomSignal = new System.Windows.Forms.Panel();
            this.btnSaveSignal = new System.Windows.Forms.Button();
            this.btnRestartSignal = new System.Windows.Forms.Button();
            this.btnStartSignal = new System.Windows.Forms.Button();
            this.tpResistanceCalibration = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.ccResistance = new Desktop.Controls.CalibrationControl02();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pnlResistanceCS = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbResistanceMachine = new System.Windows.Forms.ComboBox();
            this.pnlBottomResistance = new System.Windows.Forms.Panel();
            this.btnSaveResistance = new System.Windows.Forms.Button();
            this.btnRestartResistance = new System.Windows.Forms.Button();
            this.btnStartResistance = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tcCalibration.SuspendLayout();
            this.tpNoiseCalibration.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cbCS.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlBottomNoise.SuspendLayout();
            this.tpSignalCalibration.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlBottomSignal.SuspendLayout();
            this.tpResistanceCalibration.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.pnlBottomResistance.SuspendLayout();
            this.SuspendLayout(); 
            // 
            // pnlBottom
            // 
            this.pnlBottom.Size = new System.Drawing.Size(794, 54); 
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(794, 54);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tcCalibration);
            this.pnlMain.Size = new System.Drawing.Size(794, 474); 
            // 
            // tcCalibration
            // 
            this.tcCalibration.Controls.Add(this.tpNoiseCalibration);
            this.tcCalibration.Controls.Add(this.tpSignalCalibration);
            this.tcCalibration.Controls.Add(this.tpResistanceCalibration);
            this.tcCalibration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCalibration.Location = new System.Drawing.Point(0, 0);
            this.tcCalibration.Name = "tcCalibration";
            this.tcCalibration.SelectedIndex = 0;
            this.tcCalibration.Size = new System.Drawing.Size(790, 470);
            this.tcCalibration.TabIndex = 0;
            this.tcCalibration.SelectedIndexChanged += new System.EventHandler(this.tcCalibration_SelectedIndexChanged);
            // 
            // tpNoiseCalibration
            // 
            this.tpNoiseCalibration.Controls.Add(this.panel2);
            this.tpNoiseCalibration.Controls.Add(this.panel1);
            this.tpNoiseCalibration.Controls.Add(this.pnlBottomNoise);
            this.tpNoiseCalibration.Location = new System.Drawing.Point(4, 27);
            this.tpNoiseCalibration.Name = "tpNoiseCalibration";
            this.tpNoiseCalibration.Padding = new System.Windows.Forms.Padding(3);
            this.tpNoiseCalibration.Size = new System.Drawing.Size(782, 439);
            this.tpNoiseCalibration.TabIndex = 0;
            this.tpNoiseCalibration.Text = "Noise Calibration";
            this.tpNoiseCalibration.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ccNoise);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(576, 389);
            this.panel2.TabIndex = 1;
            // 
            // ccNoise
            // 
            this.ccNoise.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccNoise.Location = new System.Drawing.Point(0, 0);
            this.ccNoise.Name = "ccNoise";
            this.ccNoise.Size = new System.Drawing.Size(576, 389);
            this.ccNoise.TabIndex = 0;
            this.ccNoise.TestReference = Desktop.DesktopProperties.TestReference.Noise;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbCS);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(579, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 389);
            this.panel1.TabIndex = 0;
            // 
            // cbCS
            // 
            this.cbCS.Controls.Add(this.pnlNoiseCS);
            this.cbCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbCS.Location = new System.Drawing.Point(0, 64);
            this.cbCS.Name = "cbCS";
            this.cbCS.Size = new System.Drawing.Size(200, 325);
            this.cbCS.TabIndex = 3;
            this.cbCS.TabStop = false;
            this.cbCS.Text = " Close Socket ";
            // 
            // pnlNoiseCS
            // 
            this.pnlNoiseCS.AutoScroll = true;
            this.pnlNoiseCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoiseCS.Location = new System.Drawing.Point(3, 20);
            this.pnlNoiseCS.Name = "pnlNoiseCS";
            this.pnlNoiseCS.Size = new System.Drawing.Size(194, 302);
            this.pnlNoiseCS.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbNoiseMachine);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 64);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Machine ";
            // 
            // cmbNoiseMachine
            // 
            this.cmbNoiseMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNoiseMachine.FormattingEnabled = true;
            this.cmbNoiseMachine.Location = new System.Drawing.Point(11, 23);
            this.cmbNoiseMachine.Name = "cmbNoiseMachine";
            this.cmbNoiseMachine.Size = new System.Drawing.Size(183, 26);
            this.cmbNoiseMachine.TabIndex = 0;
            // 
            // pnlBottomNoise
            // 
            this.pnlBottomNoise.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottomNoise.Controls.Add(this.btnSaveNoise);
            this.pnlBottomNoise.Controls.Add(this.btnRestartNoise);
            this.pnlBottomNoise.Controls.Add(this.btnStartNoise);
            this.pnlBottomNoise.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomNoise.Location = new System.Drawing.Point(3, 392);
            this.pnlBottomNoise.Name = "pnlBottomNoise";
            this.pnlBottomNoise.Size = new System.Drawing.Size(776, 44);
            this.pnlBottomNoise.TabIndex = 0;
            // 
            // btnSaveNoise
            // 
            this.btnSaveNoise.Location = new System.Drawing.Point(175, 6);
            this.btnSaveNoise.Name = "btnSaveNoise";
            this.btnSaveNoise.Size = new System.Drawing.Size(80, 30);
            this.btnSaveNoise.TabIndex = 4;
            this.btnSaveNoise.Text = "Save";
            this.btnSaveNoise.UseVisualStyleBackColor = true;
            // 
            // btnRestartNoise
            // 
            this.btnRestartNoise.Enabled = false;
            this.btnRestartNoise.Location = new System.Drawing.Point(3, 5);
            this.btnRestartNoise.Name = "btnRestartNoise";
            this.btnRestartNoise.Size = new System.Drawing.Size(80, 30);
            this.btnRestartNoise.TabIndex = 2;
            this.btnRestartNoise.Text = "Restart";
            this.btnRestartNoise.UseVisualStyleBackColor = true;
            // 
            // btnStartNoise
            // 
            this.btnStartNoise.Location = new System.Drawing.Point(89, 6);
            this.btnStartNoise.Name = "btnStartNoise";
            this.btnStartNoise.Size = new System.Drawing.Size(80, 30);
            this.btnStartNoise.TabIndex = 3;
            this.btnStartNoise.Text = "Start";
            this.btnStartNoise.UseVisualStyleBackColor = true;
            // 
            // tpSignalCalibration
            // 
            this.tpSignalCalibration.Controls.Add(this.panel3);
            this.tpSignalCalibration.Controls.Add(this.panel4);
            this.tpSignalCalibration.Controls.Add(this.pnlBottomSignal);
            this.tpSignalCalibration.Location = new System.Drawing.Point(4, 27);
            this.tpSignalCalibration.Name = "tpSignalCalibration";
            this.tpSignalCalibration.Padding = new System.Windows.Forms.Padding(3);
            this.tpSignalCalibration.Size = new System.Drawing.Size(782, 439);
            this.tpSignalCalibration.TabIndex = 1;
            this.tpSignalCalibration.Text = "Signal Calibration";
            this.tpSignalCalibration.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ccSignal);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(576, 389);
            this.panel3.TabIndex = 3;
            // 
            // ccSignal
            // 
            this.ccSignal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccSignal.Location = new System.Drawing.Point(0, 0);
            this.ccSignal.Name = "ccSignal";
            this.ccSignal.Size = new System.Drawing.Size(576, 389);
            this.ccSignal.TabIndex = 1;
            this.ccSignal.TestReference = Desktop.DesktopProperties.TestReference.Signal;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(579, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(200, 389);
            this.panel4.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pnlSignalCS);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 325);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Close Socket ";
            // 
            // pnlSignalCS
            // 
            this.pnlSignalCS.AutoScroll = true;
            this.pnlSignalCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSignalCS.Location = new System.Drawing.Point(3, 20);
            this.pnlSignalCS.Name = "pnlSignalCS";
            this.pnlSignalCS.Size = new System.Drawing.Size(194, 302);
            this.pnlSignalCS.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmbSignalMachine);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 64);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Machine ";
            // 
            // cmbSignalMachine
            // 
            this.cmbSignalMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSignalMachine.FormattingEnabled = true;
            this.cmbSignalMachine.Location = new System.Drawing.Point(11, 23);
            this.cmbSignalMachine.Name = "cmbSignalMachine";
            this.cmbSignalMachine.Size = new System.Drawing.Size(183, 26);
            this.cmbSignalMachine.TabIndex = 0;
            // 
            // pnlBottomSignal
            // 
            this.pnlBottomSignal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottomSignal.Controls.Add(this.btnSaveSignal);
            this.pnlBottomSignal.Controls.Add(this.btnRestartSignal);
            this.pnlBottomSignal.Controls.Add(this.btnStartSignal);
            this.pnlBottomSignal.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomSignal.Location = new System.Drawing.Point(3, 392);
            this.pnlBottomSignal.Name = "pnlBottomSignal";
            this.pnlBottomSignal.Size = new System.Drawing.Size(776, 44);
            this.pnlBottomSignal.TabIndex = 1;
            // 
            // btnSaveSignal
            // 
            this.btnSaveSignal.Location = new System.Drawing.Point(175, 6);
            this.btnSaveSignal.Name = "btnSaveSignal";
            this.btnSaveSignal.Size = new System.Drawing.Size(80, 30);
            this.btnSaveSignal.TabIndex = 4;
            this.btnSaveSignal.Text = "Save";
            this.btnSaveSignal.UseVisualStyleBackColor = true;
            // 
            // btnRestartSignal
            // 
            this.btnRestartSignal.Enabled = false;
            this.btnRestartSignal.Location = new System.Drawing.Point(3, 5);
            this.btnRestartSignal.Name = "btnRestartSignal";
            this.btnRestartSignal.Size = new System.Drawing.Size(80, 30);
            this.btnRestartSignal.TabIndex = 2;
            this.btnRestartSignal.Text = "Restart";
            this.btnRestartSignal.UseVisualStyleBackColor = true;
            // 
            // btnStartSignal
            // 
            this.btnStartSignal.Location = new System.Drawing.Point(89, 6);
            this.btnStartSignal.Name = "btnStartSignal";
            this.btnStartSignal.Size = new System.Drawing.Size(80, 30);
            this.btnStartSignal.TabIndex = 3;
            this.btnStartSignal.Text = "Start";
            this.btnStartSignal.UseVisualStyleBackColor = true;
            // 
            // tpResistanceCalibration
            // 
            this.tpResistanceCalibration.Controls.Add(this.panel5);
            this.tpResistanceCalibration.Controls.Add(this.panel6);
            this.tpResistanceCalibration.Controls.Add(this.pnlBottomResistance);
            this.tpResistanceCalibration.Location = new System.Drawing.Point(4, 27);
            this.tpResistanceCalibration.Name = "tpResistanceCalibration";
            this.tpResistanceCalibration.Padding = new System.Windows.Forms.Padding(3);
            this.tpResistanceCalibration.Size = new System.Drawing.Size(782, 439);
            this.tpResistanceCalibration.TabIndex = 2;
            this.tpResistanceCalibration.Text = "Resistance Calibration";
            this.tpResistanceCalibration.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.ccResistance);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(576, 389);
            this.panel5.TabIndex = 3;
            // 
            // ccResistance
            // 
            this.ccResistance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ccResistance.Location = new System.Drawing.Point(0, 0);
            this.ccResistance.Name = "ccResistance";
            this.ccResistance.Size = new System.Drawing.Size(576, 389);
            this.ccResistance.TabIndex = 1;
            this.ccResistance.TestReference = Desktop.DesktopProperties.TestReference.Resistance;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.groupBox4);
            this.panel6.Controls.Add(this.groupBox5);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(579, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(200, 389);
            this.panel6.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pnlResistanceCS);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 325);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " Close Socket ";
            // 
            // pnlResistanceCS
            // 
            this.pnlResistanceCS.AutoScroll = true;
            this.pnlResistanceCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResistanceCS.Location = new System.Drawing.Point(3, 20);
            this.pnlResistanceCS.Name = "pnlResistanceCS";
            this.pnlResistanceCS.Size = new System.Drawing.Size(194, 302);
            this.pnlResistanceCS.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbResistanceMachine);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(200, 64);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " Machine ";
            // 
            // cmbResistanceMachine
            // 
            this.cmbResistanceMachine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResistanceMachine.FormattingEnabled = true;
            this.cmbResistanceMachine.Location = new System.Drawing.Point(11, 23);
            this.cmbResistanceMachine.Name = "cmbResistanceMachine";
            this.cmbResistanceMachine.Size = new System.Drawing.Size(183, 26);
            this.cmbResistanceMachine.TabIndex = 0;
            // 
            // pnlBottomResistance
            // 
            this.pnlBottomResistance.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBottomResistance.Controls.Add(this.btnSaveResistance);
            this.pnlBottomResistance.Controls.Add(this.btnRestartResistance);
            this.pnlBottomResistance.Controls.Add(this.btnStartResistance);
            this.pnlBottomResistance.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottomResistance.Location = new System.Drawing.Point(3, 392);
            this.pnlBottomResistance.Name = "pnlBottomResistance";
            this.pnlBottomResistance.Size = new System.Drawing.Size(776, 44);
            this.pnlBottomResistance.TabIndex = 1;
            // 
            // btnSaveResistance
            // 
            this.btnSaveResistance.Location = new System.Drawing.Point(175, 6);
            this.btnSaveResistance.Name = "btnSaveResistance";
            this.btnSaveResistance.Size = new System.Drawing.Size(80, 30);
            this.btnSaveResistance.TabIndex = 4;
            this.btnSaveResistance.Text = "Save";
            this.btnSaveResistance.UseVisualStyleBackColor = true;
            // 
            // btnRestartResistance
            // 
            this.btnRestartResistance.Enabled = false;
            this.btnRestartResistance.Location = new System.Drawing.Point(3, 5);
            this.btnRestartResistance.Name = "btnRestartResistance";
            this.btnRestartResistance.Size = new System.Drawing.Size(80, 30);
            this.btnRestartResistance.TabIndex = 2;
            this.btnRestartResistance.Text = "Restart";
            this.btnRestartResistance.UseVisualStyleBackColor = true;
            // 
            // btnStartResistance
            // 
            this.btnStartResistance.Location = new System.Drawing.Point(89, 6);
            this.btnStartResistance.Name = "btnStartResistance";
            this.btnStartResistance.Size = new System.Drawing.Size(80, 30);
            this.btnStartResistance.TabIndex = 3;
            this.btnStartResistance.Text = "Start";
            this.btnStartResistance.UseVisualStyleBackColor = true;
            // 
            // frmCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(794, 582);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmCalibration";
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.tcCalibration.ResumeLayout(false);
            this.tpNoiseCalibration.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.cbCS.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pnlBottomNoise.ResumeLayout(false);
            this.tpSignalCalibration.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.pnlBottomSignal.ResumeLayout(false);
            this.tpResistanceCalibration.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.pnlBottomResistance.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tcCalibration;
        private System.Windows.Forms.TabPage tpNoiseCalibration;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tpSignalCalibration;
        private System.Windows.Forms.TabPage tpResistanceCalibration;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private Controls.CalibrationControl02 ccNoise;
        private System.Windows.Forms.GroupBox cbCS;
        private System.Windows.Forms.Panel pnlNoiseCS;
        private System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.ComboBox cmbNoiseMachine;
        private Controls.CalibrationControl02 ccSignal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlSignalCS;
        private System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.ComboBox cmbSignalMachine;
        private Controls.CalibrationControl02 ccResistance;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel pnlResistanceCS;
        private System.Windows.Forms.GroupBox groupBox5;
        protected System.Windows.Forms.ComboBox cmbResistanceMachine;
        private System.Windows.Forms.Panel pnlBottomNoise;
        private System.Windows.Forms.Button btnSaveNoise;
        private System.Windows.Forms.Button btnRestartNoise;
        private System.Windows.Forms.Button btnStartNoise;
        private System.Windows.Forms.Panel pnlBottomSignal;
        private System.Windows.Forms.Button btnSaveSignal;
        private System.Windows.Forms.Button btnRestartSignal;
        private System.Windows.Forms.Button btnStartSignal;
        private System.Windows.Forms.Panel pnlBottomResistance;
        private System.Windows.Forms.Button btnSaveResistance;
        private System.Windows.Forms.Button btnRestartResistance;
        private System.Windows.Forms.Button btnStartResistance;
    }
}
