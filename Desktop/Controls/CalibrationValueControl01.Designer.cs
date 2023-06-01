namespace Desktop.Controls
{
    partial class CalibrationValueControl01
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbCal = new System.Windows.Forms.GroupBox();
            this.chkCS = new System.Windows.Forms.CheckBox();
            this.txtGSV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCal.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCal
            // 
            this.gbCal.Controls.Add(this.chkCS);
            this.gbCal.Controls.Add(this.txtGSV);
            this.gbCal.Controls.Add(this.label2);
            this.gbCal.Controls.Add(this.txtCV);
            this.gbCal.Controls.Add(this.label1);
            this.gbCal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCal.Location = new System.Drawing.Point(0, 0);
            this.gbCal.Name = "gbCal";
            this.gbCal.Size = new System.Drawing.Size(150, 100);
            this.gbCal.TabIndex = 0;
            this.gbCal.TabStop = false;
            this.gbCal.Text = " a ";
            // 
            // chkCS
            // 
            this.chkCS.AutoSize = true;
            this.chkCS.Location = new System.Drawing.Point(16, 70);
            this.chkCS.Name = "chkCS";
            this.chkCS.Size = new System.Drawing.Size(112, 21);
            this.chkCS.TabIndex = 9;
            this.chkCS.Text = "Close Socket";
            this.chkCS.UseVisualStyleBackColor = true;
            // 
            // txtGSV
            // 
            this.txtGSV.ForeColor = System.Drawing.Color.Blue;
            this.txtGSV.Location = new System.Drawing.Point(72, 42);
            this.txtGSV.Name = "txtGSV";
            this.txtGSV.Size = new System.Drawing.Size(50, 23);
            this.txtGSV.TabIndex = 8;
            this.txtGSV.Text = "1,22";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(72, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "GSV :";
            // 
            // txtCV
            // 
            this.txtCV.ForeColor = System.Drawing.Color.LimeGreen;
            this.txtCV.Location = new System.Drawing.Point(16, 42);
            this.txtCV.Name = "txtCV";
            this.txtCV.Size = new System.Drawing.Size(50, 23);
            this.txtCV.TabIndex = 6;
            this.txtCV.Text = "1,22";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "CV :";
            // 
            // CalibrationValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.gbCal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(150, 100);
            this.Name = "CalibrationValueControl";
            this.Size = new System.Drawing.Size(150, 100);
            this.gbCal.ResumeLayout(false);
            this.gbCal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCal;
        private System.Windows.Forms.CheckBox chkCS;
        private System.Windows.Forms.TextBox txtGSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCV;
        private System.Windows.Forms.Label label1;
    }
}
