namespace Desktop.Forms.UserManagement
{
    partial class frmGroupAccessList
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
            this.pnlDate.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.pnlString.SuspendLayout();
            this.pnlFltrOpr.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDate
            // 
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDate.Location = new System.Drawing.Point(423, 0);
            this.pnlDate.Size = new System.Drawing.Size(299, 38);
            // 
            // dtpDate2
            // 
            this.dtpDate2.Checked = true;
            this.dtpDate2.Value = new System.DateTime(2017, 1, 2, 0, 0, 0, 0);
            // 
            // dtpDate1
            // 
            this.dtpDate1.Value = new System.DateTime(2017, 1, 2, 0, 0, 0, 0);
            // 
            // pnlString
            // 
            this.pnlString.Size = new System.Drawing.Size(299, 38);
            // 
            // txtText
            // 
            this.txtText.Size = new System.Drawing.Size(0, 24); 
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 601);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.pnlBottom.Size = new System.Drawing.Size(880, 54); 
            // 
            // frmGroupAccessList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(880, 655);
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "frmGroupAccessList";
            this.pnlDate.ResumeLayout(false);
            this.pnlBtn.ResumeLayout(false);
            this.pnlString.ResumeLayout(false);
            this.pnlString.PerformLayout();
            this.pnlFltrOpr.ResumeLayout(false);
            this.pnlFltrOpr.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}
