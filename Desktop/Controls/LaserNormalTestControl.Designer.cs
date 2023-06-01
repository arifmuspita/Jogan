namespace Desktop.Controls
{
    partial class LaserNormalTestControl
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
            this.label4 = new System.Windows.Forms.Label();
            this.txtLotBoxID = new Desktop.BaseComponents.PlaceholderTextBox();
            this.txtLotBoxNGID = new Desktop.BaseComponents.PlaceholderTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDowngrade = new System.Windows.Forms.CheckBox();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 154);
            this.pnlBottom.Size = new System.Drawing.Size(288, 54);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.chkDowngrade);
            this.pnlMain.Controls.Add(this.txtLotBoxNGID);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Controls.Add(this.txtLotBoxID);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Size = new System.Drawing.Size(288, 154);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(150, 7);
            this.btnCancel.Size = new System.Drawing.Size(120, 38);
            this.btnCancel.Visible = false;
            // 
            // btnSetReady
            // 
            this.btnSetReady.Size = new System.Drawing.Size(120, 38);
            // 
            // panelMessage
            // 
            this.panelMessage.Size = new System.Drawing.Size(233, 124);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 49;
            this.label4.Text = "LotBox ID :";
            // 
            // txtLotBoxID
            // 
            this.txtLotBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotBoxID.Location = new System.Drawing.Point(17, 37);
            this.txtLotBoxID.Margin = new System.Windows.Forms.Padding(4);
            this.txtLotBoxID.Name = "txtLotBoxID";
            this.txtLotBoxID.PlaceholderText = "Lotbox ID ...";
            this.txtLotBoxID.Size = new System.Drawing.Size(253, 24);
            this.txtLotBoxID.TabIndex = 3;
            this.txtLotBoxID.Tag = "Lotbox ID";
            // 
            // txtLotBoxNGID
            // 
            this.txtLotBoxNGID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotBoxNGID.Location = new System.Drawing.Point(17, 87);
            this.txtLotBoxNGID.Margin = new System.Windows.Forms.Padding(4);
            this.txtLotBoxNGID.Name = "txtLotBoxNGID";
            this.txtLotBoxNGID.PlaceholderText = "Lotbox NG ID ...";
            this.txtLotBoxNGID.Size = new System.Drawing.Size(253, 24);
            this.txtLotBoxNGID.TabIndex = 50;
            this.txtLotBoxNGID.Tag = "Lotbox ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 18);
            this.label1.TabIndex = 51;
            this.label1.Text = "LotBox NG ID :";
            // 
            // chkDowngrade
            // 
            this.chkDowngrade.AutoSize = true;
            this.chkDowngrade.Location = new System.Drawing.Point(19, 120);
            this.chkDowngrade.Name = "chkDowngrade";
            this.chkDowngrade.Size = new System.Drawing.Size(102, 21);
            this.chkDowngrade.TabIndex = 52;
            this.chkDowngrade.Text = "Downgrade";
            this.chkDowngrade.UseVisualStyleBackColor = true;
            this.chkDowngrade.Visible = false;
            this.chkDowngrade.CheckedChanged += new System.EventHandler(this.chkDowngrade_CheckedChanged);
            // 
            // LaserNormalTestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.MinimumSize = new System.Drawing.Size(0, 0);
            this.Name = "LaserNormalTestControl";
            this.Size = new System.Drawing.Size(288, 208);
            this.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        protected BaseComponents.PlaceholderTextBox txtLotBoxID;
        protected System.Windows.Forms.Label label4;
        protected BaseComponents.PlaceholderTextBox txtLotBoxNGID;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkDowngrade;
    }
}
