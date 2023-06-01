namespace Desktop.Controls
{
    partial class FukudaAQLTestControl
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
            this.label5 = new System.Windows.Forms.Label();
            this.txtPONumber1 = new System.Windows.Forms.TextBox();
            this.txtPONumber2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPONumber3 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPONumber4 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtPONumber
            // 
            this.txtPONumber.Enabled = false;
            this.txtPONumber.Leave += new System.EventHandler(this.txtPONumber_Leave);
            // 
            // label1
            // 
            this.label1.Size = new System.Drawing.Size(102, 18);
            this.label1.Text = "AQL Number :";
            // 
            // txtAQLResult
            // 
            this.txtAQLResult.Visible = false;
            // 
            // lblAQLResult
            // 
            this.lblAQLResult.Visible = false;
            // 
            // txtAQLRef
            // 
            this.txtAQLRef.Visible = false;
            // 
            // lblAQLRef
            // 
            this.lblAQLRef.Visible = false;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 322);
            this.pnlBottom.Size = new System.Drawing.Size(550, 49);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.txtPONumber4);
            this.pnlMain.Controls.Add(this.label8);
            this.pnlMain.Controls.Add(this.txtPONumber3);
            this.pnlMain.Controls.Add(this.label7);
            this.pnlMain.Controls.Add(this.txtPONumber2);
            this.pnlMain.Controls.Add(this.label6);
            this.pnlMain.Controls.Add(this.txtPONumber1);
            this.pnlMain.Controls.Add(this.label5);
            this.pnlMain.Size = new System.Drawing.Size(550, 322);
            this.pnlMain.Controls.SetChildIndex(this.lblAQLRef, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtAQLRef, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblAQLResult, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtAQLResult, 0);
            this.pnlMain.Controls.SetChildIndex(this.label1, 0);
            this.pnlMain.Controls.SetChildIndex(this.label2, 0);
            this.pnlMain.Controls.SetChildIndex(this.label3, 0);
            this.pnlMain.Controls.SetChildIndex(this.label4, 0);
            this.pnlMain.Controls.SetChildIndex(this.chkNoise, 0);
            this.pnlMain.Controls.SetChildIndex(this.chkResistance, 0);
            this.pnlMain.Controls.SetChildIndex(this.chkSignal, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtPONumber, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtDeviceID, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtDeviceName, 0);
            this.pnlMain.Controls.SetChildIndex(this.btnChange, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtLotBoxID, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtQuantity, 0);
            this.pnlMain.Controls.SetChildIndex(this.label5, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtPONumber1, 0);
            this.pnlMain.Controls.SetChildIndex(this.label6, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtPONumber2, 0);
            this.pnlMain.Controls.SetChildIndex(this.label7, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtPONumber3, 0);
            this.pnlMain.Controls.SetChildIndex(this.label8, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtPONumber4, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 41;
            this.label5.Text = "PO Number 1 :";
            // 
            // txtPONumber1
            // 
            this.txtPONumber1.Location = new System.Drawing.Point(331, 38);
            this.txtPONumber1.Name = "txtPONumber1";
            this.txtPONumber1.Size = new System.Drawing.Size(198, 23);
            this.txtPONumber1.TabIndex = 42;
            // 
            // txtPONumber2
            // 
            this.txtPONumber2.Location = new System.Drawing.Point(331, 84);
            this.txtPONumber2.Name = "txtPONumber2";
            this.txtPONumber2.Size = new System.Drawing.Size(198, 23);
            this.txtPONumber2.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(331, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 43;
            this.label6.Text = "PO Number 2 :";
            // 
            // txtPONumber3
            // 
            this.txtPONumber3.Location = new System.Drawing.Point(331, 130);
            this.txtPONumber3.Name = "txtPONumber3";
            this.txtPONumber3.Size = new System.Drawing.Size(198, 23);
            this.txtPONumber3.TabIndex = 46;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(331, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 17);
            this.label7.TabIndex = 45;
            this.label7.Text = "PO Number 3 :";
            // 
            // txtPONumber4
            // 
            this.txtPONumber4.Location = new System.Drawing.Point(331, 176);
            this.txtPONumber4.Name = "txtPONumber4";
            this.txtPONumber4.Size = new System.Drawing.Size(198, 23);
            this.txtPONumber4.TabIndex = 48;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(331, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 17);
            this.label8.TabIndex = 47;
            this.label8.Text = "PO Number 4 :";
            // 
            // FukudaAQLTestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.Name = "FukudaAQLTestControl";
            this.Size = new System.Drawing.Size(550, 371);
            this.TestMode = Desktop.DesktopProperties.TestMode.tmAQL;
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPONumber4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPONumber3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPONumber2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPONumber1;
    }
}
