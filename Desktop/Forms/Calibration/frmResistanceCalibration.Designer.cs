﻿namespace Desktop.Forms.Calibration
{
    partial class frmResistanceCalibration
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
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout(); 
            // 
            // frmResistanceCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(944, 544);
            this.Name = "frmResistanceCalibration";
            this.TestReference = Desktop.DesktopProperties.TestReference.Resistance;
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}