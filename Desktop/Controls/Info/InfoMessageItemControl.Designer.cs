namespace Desktop.Controls.Info
{
    partial class InfoMessageItemControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoMessageItemControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.imgLV = new System.Windows.Forms.ImageList(this.components);
            this.btnClear = new System.Windows.Forms.Button();
            this.lvMessage = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbMainItem.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMainItem
            // 
            this.gbMainItem.Controls.Add(this.lvMessage);
            this.gbMainItem.Controls.Add(this.panel1);
            this.gbMainItem.Size = new System.Drawing.Size(968, 203);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(962, 36);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ImageIndex = 2;
            this.btnSave.ImageList = this.imgLV;
            this.btnSave.Location = new System.Drawing.Point(794, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // imgLV
            // 
            this.imgLV.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgLV.ImageStream")));
            this.imgLV.TransparentColor = System.Drawing.Color.Transparent;
            this.imgLV.Images.SetKeyName(0, "Star Filled-16.png");
            this.imgLV.Images.SetKeyName(1, "Delete-16.png");
            this.imgLV.Images.SetKeyName(2, "Save-16.png");
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.ImageIndex = 1;
            this.btnClear.ImageList = this.imgLV;
            this.btnClear.Location = new System.Drawing.Point(875, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 26);
            this.btnClear.TabIndex = 0;
            this.btnClear.Text = "Clear";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // lvMessage
            // 
            this.lvMessage.AutoArrange = false;
            this.lvMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMessage.FullRowSelect = true;
            this.lvMessage.GridLines = true;
            this.lvMessage.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvMessage.Location = new System.Drawing.Point(3, 17);
            this.lvMessage.MultiSelect = false;
            this.lvMessage.Name = "lvMessage";
            this.lvMessage.OwnerDraw = true;
            this.lvMessage.Size = new System.Drawing.Size(962, 147);
            this.lvMessage.TabIndex = 1;
            this.lvMessage.UseCompatibleStateImageBehavior = false;
            this.lvMessage.View = System.Windows.Forms.View.Details;
            this.lvMessage.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lvMessage_DrawColumnHeader);
            this.lvMessage.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lvMessage_DrawSubItem);
            this.lvMessage.SelectedIndexChanged += new System.EventHandler(this.lvMessage_SelectedIndexChanged);
            this.lvMessage.Resize += new System.EventHandler(this.lvMessage_Resize);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date Time";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Sender";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Message";
            this.columnHeader3.Width = 400;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Priority";
            this.columnHeader4.Width = 100;
            // 
            // InfoMessageItemControl
            // 
            this.Name = "InfoMessageItemControl";
            this.Size = new System.Drawing.Size(968, 203);
            this.gbMainItem.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvMessage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ImageList imgLV;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
    }
}
