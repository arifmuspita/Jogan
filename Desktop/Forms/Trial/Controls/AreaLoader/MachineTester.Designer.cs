namespace Desktop.Forms.Trial.Controls.AreaLoader
{
    partial class MachineTester
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
            this.lblMachineName = new System.Windows.Forms.Label();
            this.lblMachineCode = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblMaintanance = new System.Windows.Forms.Label();
            this.rbMtc = new System.Windows.Forms.RadioButton();
            this.lblOff = new System.Windows.Forms.Label();
            this.rbOff = new System.Windows.Forms.RadioButton();
            this.lblOn = new System.Windows.Forms.Label();
            this.rbOn = new System.Windows.Forms.RadioButton();
            this.pnlMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblMachineCode);
            this.pnlMain.Controls.Add(this.lblMachineName);
            this.pnlMain.Location = new System.Drawing.Point(0, 29);
            this.pnlMain.Size = new System.Drawing.Size(150, 92);
            this.pnlMain.Controls.SetChildIndex(this.lblStatus, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblJigID, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblPONumber, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblMachineName, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblMachineCode, 0);
            // 
            // lblJigID
            // 
            this.lblJigID.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblJigID.Location = new System.Drawing.Point(0, 50);
            // 
            // lblPONumber
            // 
            this.lblPONumber.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblPONumber.Location = new System.Drawing.Point(0, 30);
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStatus.Location = new System.Drawing.Point(0, 70);
            // 
            // lblMachineName
            // 
            this.lblMachineName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMachineName.Location = new System.Drawing.Point(0, 10);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.Size = new System.Drawing.Size(148, 20);
            this.lblMachineName.TabIndex = 10;
            this.lblMachineName.Text = "Machine Name";
            this.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMachineCode
            // 
            this.lblMachineCode.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblMachineCode.Location = new System.Drawing.Point(0, -10);
            this.lblMachineCode.Name = "lblMachineCode";
            this.lblMachineCode.Size = new System.Drawing.Size(148, 20);
            this.lblMachineCode.TabIndex = 9;
            this.lblMachineCode.Text = "Machine Code";
            this.lblMachineCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTop
            // 
            this.pnlTop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlTop.Controls.Add(this.lblMaintanance);
            this.pnlTop.Controls.Add(this.rbMtc);
            this.pnlTop.Controls.Add(this.lblOff);
            this.pnlTop.Controls.Add(this.rbOff);
            this.pnlTop.Controls.Add(this.lblOn);
            this.pnlTop.Controls.Add(this.rbOn);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(150, 29);
            this.pnlTop.TabIndex = 11;
            // 
            // lblMaintanance
            // 
            this.lblMaintanance.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblMaintanance.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaintanance.Location = new System.Drawing.Point(105, 0);
            this.lblMaintanance.Name = "lblMaintanance";
            this.lblMaintanance.Size = new System.Drawing.Size(40, 27);
            this.lblMaintanance.TabIndex = 5;
            this.lblMaintanance.Text = "Mtc";
            this.lblMaintanance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbMtc
            // 
            this.rbMtc.AutoSize = true;
            this.rbMtc.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbMtc.Enabled = false;
            this.rbMtc.Location = new System.Drawing.Point(88, 0);
            this.rbMtc.Name = "rbMtc";
            this.rbMtc.Size = new System.Drawing.Size(17, 27);
            this.rbMtc.TabIndex = 4;
            this.rbMtc.TabStop = true;
            this.rbMtc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbMtc.UseVisualStyleBackColor = true;
            // 
            // lblOff
            // 
            this.lblOff.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOff.Location = new System.Drawing.Point(61, 0);
            this.lblOff.Name = "lblOff";
            this.lblOff.Size = new System.Drawing.Size(27, 27);
            this.lblOff.TabIndex = 3;
            this.lblOff.Text = "Off";
            this.lblOff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbOff
            // 
            this.rbOff.AutoSize = true;
            this.rbOff.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbOff.Enabled = false;
            this.rbOff.Location = new System.Drawing.Point(44, 0);
            this.rbOff.Name = "rbOff";
            this.rbOff.Size = new System.Drawing.Size(17, 27);
            this.rbOff.TabIndex = 1;
            this.rbOff.TabStop = true;
            this.rbOff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rbOff.UseVisualStyleBackColor = true;
            // 
            // lblOn
            // 
            this.lblOn.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOn.Location = new System.Drawing.Point(17, 0);
            this.lblOn.Name = "lblOn";
            this.lblOn.Size = new System.Drawing.Size(27, 27);
            this.lblOn.TabIndex = 2;
            this.lblOn.Text = "On";
            this.lblOn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rbOn
            // 
            this.rbOn.AutoSize = true;
            this.rbOn.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbOn.Enabled = false;
            this.rbOn.Location = new System.Drawing.Point(0, 0);
            this.rbOn.Name = "rbOn";
            this.rbOn.Size = new System.Drawing.Size(17, 27);
            this.rbOn.TabIndex = 0;
            this.rbOn.TabStop = true;
            this.rbOn.UseVisualStyleBackColor = true;
            // 
            // MachineTester
            // 
            this.Controls.Add(this.pnlTop);
            this.Name = "MachineTester";
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.pnlMain.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblMachineName;
        protected System.Windows.Forms.Label lblMachineCode;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblOff;
        private System.Windows.Forms.Label lblOn;
        private System.Windows.Forms.RadioButton rbOff;
        private System.Windows.Forms.RadioButton rbOn;
        private System.Windows.Forms.Label lblMaintanance;
        private System.Windows.Forms.RadioButton rbMtc;
    }
}
