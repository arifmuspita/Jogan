namespace Desktop.BaseControls
{
    partial class BaseTestingItemControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
       

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseTestingItemControl));
            this.gbMainItem = new System.Windows.Forms.GroupBox();
            this.tmrBlinking = new System.Windows.Forms.Timer(this.components);
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsFinish = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.gbMainItem.SuspendLayout();
            this.tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMainItem
            // 
            this.gbMainItem.BackColor = System.Drawing.SystemColors.Control;
            this.gbMainItem.Controls.Add(this.tsMain);
            this.gbMainItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMainItem.Location = new System.Drawing.Point(0, 0);
            this.gbMainItem.Name = "gbMainItem";
            this.gbMainItem.Size = new System.Drawing.Size(185, 203);
            this.gbMainItem.TabIndex = 0;
            this.gbMainItem.TabStop = false;
            this.gbMainItem.Text = " ";
            // 
            // tmrBlinking
            // 
            this.tmrBlinking.Interval = 500;
            this.tmrBlinking.Tick += new System.EventHandler(this.tmrBlinking_Tick_1);
            // 
            // tsMain
            // 
            this.tsMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFinish,
            this.toolStripSeparator1});
            this.tsMain.Location = new System.Drawing.Point(3, 173);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(179, 27);
            this.tsMain.TabIndex = 0;
            this.tsMain.Visible = false;
            // 
            // tsFinish
            // 
            this.tsFinish.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsFinish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsFinish.Image = ((System.Drawing.Image)(resources.GetObject("tsFinish.Image")));
            this.tsFinish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFinish.Name = "tsFinish";
            this.tsFinish.Size = new System.Drawing.Size(50, 24);
            this.tsFinish.Text = "Finish";
            this.tsFinish.Click += new System.EventHandler(this.tsFinish_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // BaseTestingItemControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.gbMainItem);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BaseTestingItemControl";
            this.Size = new System.Drawing.Size(185, 203);
            this.Resize += new System.EventHandler(this.BaseTestingItemControl_Resize);
            this.gbMainItem.ResumeLayout(false);
            this.gbMainItem.PerformLayout();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox gbMainItem;
        protected System.Windows.Forms.Timer tmrBlinking;
        protected System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsFinish;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
