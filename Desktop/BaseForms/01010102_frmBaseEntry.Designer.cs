namespace Desktop.BaseForms
{
    partial class frmBaseEntry
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
            this.components = new System.ComponentModel.Container();
            this.bindSrc = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc)).BeginInit();
            this.SuspendLayout(); 
            // 
            // bindSrc
            // 
            this.bindSrc.AllowNew = true;
            // 
            // frmBaseEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(782, 582);
            this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.Name = "frmBaseEntry";
            this.Load += new System.EventHandler(this.frmBaseEntry_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.BindingSource bindSrc;
        protected System.Windows.Forms.ToolTip toolTip;
    }
}
