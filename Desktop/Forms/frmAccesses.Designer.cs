namespace Desktop.Forms
{
    partial class frmAccesses
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
            this.tabAccess = new System.Windows.Forms.TabControl();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.btnLogout = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnLogout);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9); 
            this.pnlBottom.Controls.SetChildIndex(this.btnLogout, 0); 
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabAccess);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9); 
            // 
            // tabAccess
            // 
            this.tabAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabAccess.Location = new System.Drawing.Point(0, 0);
            this.tabAccess.Margin = new System.Windows.Forms.Padding(4);
            this.tabAccess.Name = "tabAccess";
            this.tabAccess.SelectedIndex = 0;
            this.tabAccess.Size = new System.Drawing.Size(780, 472);
            this.tabAccess.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(782, 557);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(782, 582);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLogout.Location = new System.Drawing.Point(682, 8);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(80, 38);
            this.btnLogout.TabIndex = 0;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frmAccesses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(782, 582);
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmAccesses";
            this.Shown += new System.EventHandler(this.frmAccesses_Shown);
            this.Controls.SetChildIndex(this.toolStripContainer1, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabAccess;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Button btnLogout;
    }
}
