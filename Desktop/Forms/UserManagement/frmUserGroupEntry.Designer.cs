namespace Desktop.Forms.UserManagement
{
    partial class frmUserGroupEntry
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
            DBProject.Models.DBProjectEntities dbProjectEntities1 = new DBProject.Models.DBProjectEntities();
            this.label1 = new System.Windows.Forms.Label();
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindSrc
            // 
            this.bindSrc.DataSource = dbProjectEntities1;
            this.bindSrc.Position = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.txtGroupName);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.txtGroupID);
            this.pnlMain.Controls.Add(this.label1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Group ID";
            // 
            // txtGroupID
            // 
            this.txtGroupID.Location = new System.Drawing.Point(117, 13);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.Size = new System.Drawing.Size(265, 22);
            this.txtGroupID.TabIndex = 1;
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(117, 54);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(265, 22);
            this.txtGroupName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Group Name";
            // 
            // frmUserGroupEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(782, 582);
            this.Name = "frmUserGroupEntry";
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.Label label1;
    }
}
