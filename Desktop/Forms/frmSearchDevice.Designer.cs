namespace Desktop.Forms
{
    partial class frmSearchDevice
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
            this.btnSelect = new System.Windows.Forms.Button();
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
            this.pnlDate.Size = new System.Drawing.Size(201, 38);
            // 
            // dtpDate2
            // 
            this.dtpDate2.Checked = true;
            this.dtpDate2.Value = new System.DateTime(2017, 1, 5, 0, 0, 0, 0);
            // 
            // dtpDate1
            // 
            this.dtpDate1.Value = new System.DateTime(2017, 1, 5, 0, 0, 0, 0);
            // 
            // pnlString
            // 
            this.pnlString.Size = new System.Drawing.Size(201, 38);
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.txtText.Size = new System.Drawing.Size(189, 24); 
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnSelect); 
            this.pnlBottom.Controls.SetChildIndex(this.btnSelect, 0);   
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSelect.Location = new System.Drawing.Point(172, 12);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(80, 30);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmSearchDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(782, 582);
            this.Name = "frmSearchDevice";
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

        private System.Windows.Forms.Button btnSelect;
    }
}
