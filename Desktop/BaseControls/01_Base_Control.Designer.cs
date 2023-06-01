namespace Desktop.BaseControls
{
    partial class BaseControl
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
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSetReady = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.panelMessage = new Desktop.BaseComponents.PanelMessage();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnSetReady);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 398);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(325, 54);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(170, 7);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(140, 38);
            this.btnCancel.TabIndex = 37;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSetReady
            // 
            this.btnSetReady.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSetReady.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetReady.Location = new System.Drawing.Point(17, 7);
            this.btnSetReady.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetReady.Name = "btnSetReady";
            this.btnSetReady.Size = new System.Drawing.Size(140, 38);
            this.btnSetReady.TabIndex = 36;
            this.btnSetReady.Text = "Set Ready";
            this.btnSetReady.UseVisualStyleBackColor = true;
            this.btnSetReady.Click += new System.EventHandler(this.btnSetReady_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panelMessage);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(325, 398);
            this.pnlMain.TabIndex = 1;
            // 
            // panelMessage
            // 
            this.panelMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelMessage.Location = new System.Drawing.Point(0, 0);
            this.panelMessage.Message = "jljjljl";
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.Size = new System.Drawing.Size(325, 452);
            this.panelMessage.TabIndex = 2;
            this.panelMessage.Visible = false;
            // 
            // BaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlBottom);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(225, 338);
            this.Name = "BaseControl";
            this.Size = new System.Drawing.Size(325, 452);

            //this.TestMode
            //this.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            this.Load += new System.EventHandler(this.BaseControl_Load);
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ToolTip toolTip;
        protected System.Windows.Forms.Panel pnlBottom;
        protected System.Windows.Forms.Panel pnlMain;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnSetReady;
        protected BaseComponents.PanelMessage panelMessage;
    }
}
