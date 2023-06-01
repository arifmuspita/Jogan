namespace Desktop.Controls
{
    partial class CalibrationControl01
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
            this.pnlCalibration = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlCalibration
            // 
            this.pnlCalibration.AutoScroll = true;
            this.pnlCalibration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCalibration.Location = new System.Drawing.Point(0, 0);
            this.pnlCalibration.Name = "pnlCalibration";
            this.pnlCalibration.Size = new System.Drawing.Size(530, 300);
            this.pnlCalibration.TabIndex = 0;
            // 
            // CalibrationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlCalibration);
            this.Name = "CalibrationControl";
            this.Size = new System.Drawing.Size(530, 300);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlCalibration;
    }
}
