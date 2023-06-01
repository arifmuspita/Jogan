namespace Desktop.Forms.Trial.Controls.AreaLoader
{
    partial class BaseAreaLoader
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblJigID = new System.Windows.Forms.Label();
            this.lblPONumber = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pbMain = new System.Windows.Forms.ProgressBar();
            this.pnlMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.lblStatus);
            this.pnlMain.Controls.Add(this.lblJigID);
            this.pnlMain.Controls.Add(this.lblPONumber);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(150, 121);
            this.pnlMain.TabIndex = 0;
            // 
            // lblStatus
            // 
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStatus.Location = new System.Drawing.Point(0, 40);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(148, 20);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblJigID
            // 
            this.lblJigID.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblJigID.Location = new System.Drawing.Point(0, 20);
            this.lblJigID.Name = "lblJigID";
            this.lblJigID.Size = new System.Drawing.Size(148, 20);
            this.lblJigID.TabIndex = 1;
            this.lblJigID.Text = "Jig ID";
            this.lblJigID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPONumber
            // 
            this.lblPONumber.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPONumber.Location = new System.Drawing.Point(0, 0);
            this.lblPONumber.Name = "lblPONumber";
            this.lblPONumber.Size = new System.Drawing.Size(148, 20);
            this.lblPONumber.TabIndex = 0;
            this.lblPONumber.Text = "PO Number";
            this.lblPONumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBottom.Controls.Add(this.pbMain);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 121);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(150, 29);
            this.pnlBottom.TabIndex = 5;
            // 
            // pbMain
            // 
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.Location = new System.Drawing.Point(0, 0);
            this.pbMain.Name = "pbMain";
            this.pbMain.Size = new System.Drawing.Size(148, 27);
            this.pbMain.TabIndex = 0;
            // 
            // BaseAreaLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Name = "BaseAreaLoader";
            this.pnlMain.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel pnlMain;
        protected System.Windows.Forms.Label lblJigID;
        protected System.Windows.Forms.Label lblPONumber;
        protected System.Windows.Forms.Label lblStatus;
        protected System.Windows.Forms.Panel pnlBottom;
        protected System.Windows.Forms.ProgressBar pbMain;
    }
}
