namespace Desktop.Forms.Test
{
    partial class frmListPONumber
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
            this.pnlFilter.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlDate
            // 
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDate.Location = new System.Drawing.Point(423, 0);
            this.pnlDate.Size = new System.Drawing.Size(199, 38);
            // 
            // dtpDate2
            // 
            this.dtpDate2.Checked = true;
            this.dtpDate2.Value = new System.DateTime(2017, 2, 7, 0, 0, 0, 0);
            // 
            // dtpDate1
            // 
            this.dtpDate1.Value = new System.DateTime(2017, 2, 7, 0, 0, 0, 0);
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(622, 0);
            // 
            // pnlString
            // 
            this.pnlString.Size = new System.Drawing.Size(199, 38);
            // 
            // txtText
            // 
            this.txtText.Size = new System.Drawing.Size(0, 24);
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(782, 53);
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(0, 53);
            this.pnlMain.Size = new System.Drawing.Size(782, 475);
            // 
            // frmListPONumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(782, 582);
            this.Name = "frmListPONumber";
            this.pnlDate.ResumeLayout(false);
            this.pnlBtn.ResumeLayout(false);
            this.pnlString.ResumeLayout(false);
            this.pnlString.PerformLayout();
            this.pnlFltrOpr.ResumeLayout(false);
            this.pnlFltrOpr.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Button btnSave2;
        protected System.Windows.Forms.TextBox txtQuantity;
        protected System.Windows.Forms.TextBox txtLotBoxID;
        protected System.Windows.Forms.TextBox txtDeviceName;
        protected System.Windows.Forms.TextBox txtDeviceID;
        protected System.Windows.Forms.TextBox txtPONumber;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button btnEntri;
        private System.Windows.Forms.CheckBox chkAQL;
        private System.Windows.Forms.GroupBox gbPONumberAQL;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePONumber1;
        private System.Windows.Forms.TabPage tabPagePONumber2;
        private System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.TextBox txtQuantity1;
        protected System.Windows.Forms.TextBox txtLotBoxID1;
        protected System.Windows.Forms.TextBox txtPONumber1;
        protected System.Windows.Forms.Label label8;
        protected System.Windows.Forms.Label label9;
        protected System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel5;
        protected System.Windows.Forms.TextBox txtQuantity2;
        protected System.Windows.Forms.TextBox txtLotBoxID2;
        protected System.Windows.Forms.TextBox txtPONumber2;
        protected System.Windows.Forms.Label label17;
        protected System.Windows.Forms.Label label18;
        protected System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabPagePONumber3;
        private System.Windows.Forms.Panel panel3;
        protected System.Windows.Forms.TextBox txtQuantity3;
        protected System.Windows.Forms.TextBox txtLotBoxID3;
        protected System.Windows.Forms.TextBox txtPONumber3;
        protected System.Windows.Forms.Label label11;
        protected System.Windows.Forms.Label label12;
        protected System.Windows.Forms.Label label13;
        private System.Windows.Forms.TabPage tabPagePONumber4;
        private System.Windows.Forms.Panel panel4;
        protected System.Windows.Forms.TextBox txtQuantity4;
        protected System.Windows.Forms.TextBox txtLotBoxID4;
        protected System.Windows.Forms.TextBox txtPONumber4;
        protected System.Windows.Forms.Label label14;
        protected System.Windows.Forms.Label label15;
        protected System.Windows.Forms.Label label16;
        private Utilites.BarcodeScannerTextBoxUtility barcodeScannerTextBoxUtility1;
    }
}
