namespace Desktop.Forms.Trial.Controls.AreaLoader
{
    partial class JigCarrier
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
            this.lblEndPos = new System.Windows.Forms.Label();
            this.lblStartPos = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lblEndPos);
            this.pnlMain.Controls.Add(this.lblStartPos);
            this.pnlMain.Size = new System.Drawing.Size(150, 155);
            this.pnlMain.Controls.SetChildIndex(this.lblPONumber, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblJigID, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblStartPos, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblEndPos, 0);
            this.pnlMain.Controls.SetChildIndex(this.lblStatus, 0);
            // 
            // lblJigID
            // 
            this.lblJigID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJigID.Text = "";
            // 
            // lblPONumber
            // 
            this.lblPONumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(0, 80);
            this.lblStatus.Text = "";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 155);
            this.pnlBottom.Size = new System.Drawing.Size(150, 15);
            // 
            // pbMain
            // 
            this.pbMain.Size = new System.Drawing.Size(148, 13);
            // 
            // lblEndPos
            // 
            this.lblEndPos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblEndPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndPos.Location = new System.Drawing.Point(0, 60);
            this.lblEndPos.Name = "lblEndPos";
            this.lblEndPos.Size = new System.Drawing.Size(148, 20);
            this.lblEndPos.TabIndex = 8;
            this.lblEndPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStartPos
            // 
            this.lblStartPos.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblStartPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartPos.Location = new System.Drawing.Point(0, 40);
            this.lblStartPos.Name = "lblStartPos";
            this.lblStartPos.Size = new System.Drawing.Size(148, 20);
            this.lblStartPos.TabIndex = 7;
            this.lblStartPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // JigCarrier
            // 
            this.Name = "JigCarrier";
            this.Size = new System.Drawing.Size(150, 170);
            this.pnlMain.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label lblEndPos;
        protected System.Windows.Forms.Label lblStartPos;
    }
}
