namespace Desktop.Forms.UserManagement
{
    partial class frmUserEntry
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBagdeNo = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbGroupID = new System.Windows.Forms.ComboBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.chkIsActive);
            this.pnlMain.Controls.Add(this.txtEmail);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.cmbGroupID);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Controls.Add(this.txtName);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.txtPassword);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.txtUserName);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.txtBagdeNo);
            this.pnlMain.Controls.Add(this.label1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bagde No";
            // 
            // txtBagdeNo
            // 
            this.txtBagdeNo.Location = new System.Drawing.Point(122, 16);
            this.txtBagdeNo.Name = "txtBagdeNo";
            this.txtBagdeNo.Size = new System.Drawing.Size(196, 22);
            this.txtBagdeNo.TabIndex = 0;
            this.txtBagdeNo.Tag = "BagdeNo";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(122, 51);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(230, 22);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Tag = "UserName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "User Name";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(122, 127);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(230, 22);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Tag = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(122, 88);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(294, 22);
            this.txtName.TabIndex = 2;
            this.txtName.Tag = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Group ID";
            // 
            // cmbGroupID
            // 
            this.cmbGroupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupID.FormattingEnabled = true;
            this.cmbGroupID.Location = new System.Drawing.Point(122, 238);
            this.cmbGroupID.Name = "cmbGroupID";
            this.cmbGroupID.Size = new System.Drawing.Size(210, 24);
            this.cmbGroupID.TabIndex = 6;
            this.cmbGroupID.Tag = "UserGroupID";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(122, 164);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(272, 22);
            this.txtEmail.TabIndex = 4;
            this.txtEmail.Tag = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Email";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Location = new System.Drawing.Point(122, 202);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(18, 17);
            this.chkIsActive.TabIndex = 5;
            this.chkIsActive.Tag = "IsActive";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 202);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Is Active";
            // 
            // frmUserEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(782, 582);
            this.Name = "frmUserEntry";
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBagdeNo;
        private System.Windows.Forms.ComboBox cmbGroupID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkIsActive;
    }
}
