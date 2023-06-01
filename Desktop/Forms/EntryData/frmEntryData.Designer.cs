namespace Desktop.Forms.EntryData
{
    partial class frmEntryData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEntryData));
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 750);
            this.pnlBottom.Size = new System.Drawing.Size(1494, 44); 
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(1494, 54);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.webBrowser);
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Location = new System.Drawing.Point(0, 54);
            this.pnlMain.Size = new System.Drawing.Size(1494, 696); 
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
            this.imageList.Images.SetKeyName(13, "delete 32x32.png");
            this.imageList.Images.SetKeyName(14, "edit 32x32.png");
            this.imageList.Images.SetKeyName(15, "save 32x32.png");
            this.imageList.Images.SetKeyName(16, "add 32x32.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 652);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1490, 40);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(603, 7);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(262, 26);
            this.progressBar1.TabIndex = 0;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(22, 22);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(1490, 652);
            this.webBrowser.TabIndex = 1;
            this.webBrowser.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.webBrowser_ProgressChanged);
            // 
            // frmEntryData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(1494, 794);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.FormCaption = "Entry Data";
            this.Name = "frmEntryData";
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
