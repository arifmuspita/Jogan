namespace Desktop.BaseControls
{
    partial class frmAuthCancelTest
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
            this.txtReason = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(390, 110);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtReason);
            this.groupBox2.Size = new System.Drawing.Size(390, 160);
            this.groupBox2.Text = " Reason ";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 326);
            this.pnlBottom.Size = new System.Drawing.Size(392, 54); 
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(392, 54);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(392, 272); 
            // 
            // txtReason
            // 
            this.txtReason.Location = new System.Drawing.Point(25, 26);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(347, 117);
            this.txtReason.TabIndex = 7;
            // 
            // frmAuthCancelTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(392, 380);
            this.Name = "frmAuthCancelTest";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtReason;
    }
}
