namespace Desktop.Forms.UserManagement
{
    partial class frmUserList
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
            this.pnlDate.Location = new System.Drawing.Point(376, 0);
            this.pnlDate.Size = new System.Drawing.Size(265, 34);
            // 
            // dtpDate2
            // 
            this.dtpDate2.Checked = true;
            this.dtpDate2.Value = new System.DateTime(2016, 12, 13, 0, 0, 0, 0);
            // 
            // dtpDate1
            // 
            this.dtpDate1.Value = new System.DateTime(2016, 12, 13, 0, 0, 0, 0);
            // 
            // pnlString
            // 
            this.pnlString.Size = new System.Drawing.Size(265, 34);
            // 
            // txtText
            // 
            this.txtText.Size = new System.Drawing.Size(0, 22);
            // 
            // cmbOperand
            // 
            this.cmbOperand.Size = new System.Drawing.Size(132, 24);
            // 
            // cmbFieldName
            // 
            this.cmbFieldName.Size = new System.Drawing.Size(185, 24);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 534);
            // 
            // frmUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(782, 582);
            this.Name = "frmUserList";
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
