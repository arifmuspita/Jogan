namespace Desktop.Forms.Configuration
{
    partial class frmNGConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNGConfiguration));
            this.ngConfiguration1 = new Desktop.Controls.NGConfiguration();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout(); 
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 561);
            this.pnlBottom.Size = new System.Drawing.Size(909, 44); 
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(909, 54);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.ngConfiguration1);
            this.pnlMain.Location = new System.Drawing.Point(0, 54);
            this.pnlMain.Size = new System.Drawing.Size(909, 507); 
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "test 32x32.png");
            this.imageList.Images.SetKeyName(1, "input data 32x32.png");
            this.imageList.Images.SetKeyName(2, "switch 32x32.png");
            this.imageList.Images.SetKeyName(3, "calibration 32x32.png");
            this.imageList.Images.SetKeyName(4, "configuration 32x32.png");
            this.imageList.Images.SetKeyName(5, "signal2 32x32.png");
            this.imageList.Images.SetKeyName(6, "noise 32x32.png");
            this.imageList.Images.SetKeyName(7, "Resistance 32x32.png");
            this.imageList.Images.SetKeyName(8, "report 32x32.png");
            this.imageList.Images.SetKeyName(9, "box 32x32.png");
            this.imageList.Images.SetKeyName(10, "list 32x32.png");
            this.imageList.Images.SetKeyName(11, "ng 32x32.png");
            this.imageList.Images.SetKeyName(12, "close 32x32.png");
            this.imageList.Images.SetKeyName(13, "save 32x32.png");
            this.imageList.Images.SetKeyName(14, "add 32x32.png");
            this.imageList.Images.SetKeyName(15, "edit 32x32.png");
            this.imageList.Images.SetKeyName(16, "delete 32x32.png");
            // 
            // ngConfiguration1
            // 
            this.ngConfiguration1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ngConfiguration1.ItemsValue = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("ngConfiguration1.ItemsValue")));
            this.ngConfiguration1.Location = new System.Drawing.Point(0, 0);
            this.ngConfiguration1.Name = "ngConfiguration1";
            this.ngConfiguration1.Size = new System.Drawing.Size(905, 503);
            this.ngConfiguration1.TabIndex = 0;
            // 
            // frmNGConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(909, 605);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.FormCaption = "NG Configuration";
            this.Name = "frmNGConfiguration";
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.NGConfiguration ngConfiguration1;
    }
}
