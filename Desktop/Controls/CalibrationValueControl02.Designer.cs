namespace Desktop.Controls
{
    partial class CalibrationValueControl02
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
            this.lblGS = new System.Windows.Forms.Label();
            this.lblCV = new System.Windows.Forms.Label();
            this.gbCal.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCal
            // 
            this.gbCal.Controls.Add(this.lblGS);
            this.gbCal.Controls.Add(this.lblCV);
            this.gbCal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCal.Location = new System.Drawing.Point(0, 0);
            this.gbCal.Name = "gbCal";
            this.gbCal.Size = new System.Drawing.Size(275, 130);
            this.gbCal.TabIndex = 0;
            this.gbCal.TabStop = false;
            this.gbCal.Text = " a ";
            // 
            // lblGS
            // 
            this.lblGS.AutoSize = true;
            this.lblGS.ForeColor = System.Drawing.Color.Blue;
            this.lblGS.Location = new System.Drawing.Point(165, 20);
            this.lblGS.Name = "lblGS";
            this.lblGS.Size = new System.Drawing.Size(105, 17);
            this.lblGS.TabIndex = 11;
            this.lblGS.Text = "Golden Sample";
            // 
            // lblCV
            // 
            this.lblCV.AutoSize = true;
            this.lblCV.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblCV.Location = new System.Drawing.Point(85, 20);
            this.lblCV.Name = "lblCV";
            this.lblCV.Size = new System.Drawing.Size(75, 17);
            this.lblCV.TabIndex = 9;
            this.lblCV.Text = "Calibration";
            // 
            // CalibrationValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCal);
            this.Name = "CalibrationValueControl";
            this.Size = new System.Drawing.Size(275, 130);
            this.gbCal.ResumeLayout(false);
            this.gbCal.PerformLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCal;
        private System.Windows.Forms.Label lblGS;
        private System.Windows.Forms.Label lblCV;
    }
}
