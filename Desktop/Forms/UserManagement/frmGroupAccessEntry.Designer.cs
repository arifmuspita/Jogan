namespace Desktop.Forms.UserManagement
{
    partial class frmGroupAccessEntry
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
            this.dbgGroupAccess = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkAllReport = new System.Windows.Forms.CheckBox();
            this.chkAllAdd = new System.Windows.Forms.CheckBox();
            this.chkAllDelete = new System.Windows.Forms.CheckBox();
            this.chkAllEdit = new System.Windows.Forms.CheckBox();
            this.chkAllRead = new System.Windows.Forms.CheckBox();
            this.chkAllMenu = new System.Windows.Forms.CheckBox();
            this.MenuName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllowRead = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowAdd = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowEdit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowDelete = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AllowReport = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MenuDetail = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.MenuID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalChild = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgGroupAccess)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.panel1);
            this.pnlMain.Controls.Add(this.dbgGroupAccess); 
            // 
            // dbgGroupAccess
            // 
            this.dbgGroupAccess.AllowUserToDeleteRows = false;
            this.dbgGroupAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbgGroupAccess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MenuName,
            this.AllowRead,
            this.AllowAdd,
            this.AllowEdit,
            this.AllowDelete,
            this.AllowReport,
            this.MenuDetail,
            this.MenuID,
            this.TotalChild,
            this.MenuCode});
            this.dbgGroupAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbgGroupAccess.Location = new System.Drawing.Point(0, 0);
            this.dbgGroupAccess.MultiSelect = false;
            this.dbgGroupAccess.Name = "dbgGroupAccess";
            this.dbgGroupAccess.ReadOnly = true;
            this.dbgGroupAccess.Size = new System.Drawing.Size(780, 484);
            this.dbgGroupAccess.TabIndex = 0;
            this.dbgGroupAccess.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgGroupAccess_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkAllReport);
            this.panel1.Controls.Add(this.chkAllAdd);
            this.panel1.Controls.Add(this.chkAllDelete);
            this.panel1.Controls.Add(this.chkAllEdit);
            this.panel1.Controls.Add(this.chkAllRead);
            this.panel1.Controls.Add(this.chkAllMenu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 445);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 39);
            this.panel1.TabIndex = 1;
            // 
            // chkAllReport
            // 
            this.chkAllReport.AutoSize = true;
            this.chkAllReport.Location = new System.Drawing.Point(434, 12);
            this.chkAllReport.Name = "chkAllReport";
            this.chkAllReport.Size = new System.Drawing.Size(92, 21);
            this.chkAllReport.TabIndex = 5;
            this.chkAllReport.Tag = "AllReport";
            this.chkAllReport.Text = "All Report";
            this.chkAllReport.UseVisualStyleBackColor = true;
            this.chkAllReport.Visible = false;
            this.chkAllReport.CheckedChanged += new System.EventHandler(this.chkAllMenu_CheckedChanged);
            // 
            // chkAllAdd
            // 
            this.chkAllAdd.AutoSize = true;
            this.chkAllAdd.Location = new System.Drawing.Point(188, 12);
            this.chkAllAdd.Name = "chkAllAdd";
            this.chkAllAdd.Size = new System.Drawing.Size(74, 21);
            this.chkAllAdd.TabIndex = 2;
            this.chkAllAdd.Tag = "AllAdd";
            this.chkAllAdd.Text = "All Add";
            this.chkAllAdd.UseVisualStyleBackColor = true;
            this.chkAllAdd.CheckedChanged += new System.EventHandler(this.chkAllMenu_CheckedChanged);
            // 
            // chkAllDelete
            // 
            this.chkAllDelete.AutoSize = true;
            this.chkAllDelete.Location = new System.Drawing.Point(347, 12);
            this.chkAllDelete.Name = "chkAllDelete";
            this.chkAllDelete.Size = new System.Drawing.Size(90, 21);
            this.chkAllDelete.TabIndex = 4;
            this.chkAllDelete.Tag = "AllDelete";
            this.chkAllDelete.Text = "All Delete";
            this.chkAllDelete.UseVisualStyleBackColor = true;
            this.chkAllDelete.CheckedChanged += new System.EventHandler(this.chkAllMenu_CheckedChanged);
            // 
            // chkAllEdit
            // 
            this.chkAllEdit.AutoSize = true;
            this.chkAllEdit.Location = new System.Drawing.Point(268, 12);
            this.chkAllEdit.Name = "chkAllEdit";
            this.chkAllEdit.Size = new System.Drawing.Size(73, 21);
            this.chkAllEdit.TabIndex = 3;
            this.chkAllEdit.Tag = "AllEdit";
            this.chkAllEdit.Text = "All Edit";
            this.chkAllEdit.UseVisualStyleBackColor = true;
            this.chkAllEdit.CheckedChanged += new System.EventHandler(this.chkAllMenu_CheckedChanged);
            // 
            // chkAllRead
            // 
            this.chkAllRead.AutoSize = true;
            this.chkAllRead.Location = new System.Drawing.Point(99, 12);
            this.chkAllRead.Name = "chkAllRead";
            this.chkAllRead.Size = new System.Drawing.Size(83, 21);
            this.chkAllRead.TabIndex = 1;
            this.chkAllRead.Tag = "AllRead";
            this.chkAllRead.Text = "All Read";
            this.chkAllRead.UseVisualStyleBackColor = true;
            this.chkAllRead.CheckedChanged += new System.EventHandler(this.chkAllMenu_CheckedChanged);
            // 
            // chkAllMenu
            // 
            this.chkAllMenu.AutoSize = true;
            this.chkAllMenu.Location = new System.Drawing.Point(9, 12);
            this.chkAllMenu.Name = "chkAllMenu";
            this.chkAllMenu.Size = new System.Drawing.Size(84, 21);
            this.chkAllMenu.TabIndex = 0;
            this.chkAllMenu.Tag = "AllMenu";
            this.chkAllMenu.Text = "All Menu";
            this.chkAllMenu.UseVisualStyleBackColor = true;
            this.chkAllMenu.CheckedChanged += new System.EventHandler(this.chkAllMenu_CheckedChanged);
            // 
            // MenuName
            // 
            this.MenuName.DataPropertyName = "Name";
            this.MenuName.HeaderText = "Name";
            this.MenuName.Name = "MenuName";
            this.MenuName.ReadOnly = true;
            this.MenuName.Width = 150;
            // 
            // AllowRead
            // 
            this.AllowRead.DataPropertyName = "AllowRead";
            this.AllowRead.HeaderText = "Read";
            this.AllowRead.Name = "AllowRead";
            this.AllowRead.ReadOnly = true;
            this.AllowRead.Width = 70;
            // 
            // AllowAdd
            // 
            this.AllowAdd.DataPropertyName = "AllowAdd";
            this.AllowAdd.HeaderText = "Add";
            this.AllowAdd.Name = "AllowAdd";
            this.AllowAdd.ReadOnly = true;
            this.AllowAdd.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.AllowAdd.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AllowAdd.Width = 70;
            // 
            // AllowEdit
            // 
            this.AllowEdit.DataPropertyName = "AllowEdit";
            this.AllowEdit.HeaderText = "Edit";
            this.AllowEdit.Name = "AllowEdit";
            this.AllowEdit.ReadOnly = true;
            this.AllowEdit.Width = 70;
            // 
            // AllowDelete
            // 
            this.AllowDelete.DataPropertyName = "AllowDelete";
            this.AllowDelete.HeaderText = "Delete";
            this.AllowDelete.Name = "AllowDelete";
            this.AllowDelete.ReadOnly = true;
            this.AllowDelete.Width = 70;
            // 
            // AllowReport
            // 
            this.AllowReport.DataPropertyName = "AllowReport";
            this.AllowReport.HeaderText = "Report";
            this.AllowReport.Name = "AllowReport";
            this.AllowReport.ReadOnly = true;
            this.AllowReport.Visible = false;
            this.AllowReport.Width = 70;
            // 
            // MenuDetail
            // 
            this.MenuDetail.DataPropertyName = "Detail";
            this.MenuDetail.HeaderText = "Detail";
            this.MenuDetail.Name = "MenuDetail";
            this.MenuDetail.ReadOnly = true;
            this.MenuDetail.Visible = false;
            // 
            // MenuID
            // 
            this.MenuID.DataPropertyName = "ID";
            this.MenuID.HeaderText = "ID";
            this.MenuID.Name = "MenuID";
            this.MenuID.ReadOnly = true;
            this.MenuID.Visible = false;
            // 
            // TotalChild
            // 
            this.TotalChild.DataPropertyName = "TotalChild";
            this.TotalChild.HeaderText = "TotalChild";
            this.TotalChild.Name = "TotalChild";
            this.TotalChild.ReadOnly = true;
            this.TotalChild.Visible = false;
            // 
            // MenuCode
            // 
            this.MenuCode.DataPropertyName = "Code";
            this.MenuCode.HeaderText = "Code";
            this.MenuCode.Name = "MenuCode";
            this.MenuCode.ReadOnly = true;
            this.MenuCode.Visible = false;
            // 
            // frmGroupAccessEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.ClientSize = new System.Drawing.Size(782, 582);
            this.Name = "frmGroupAccessEntry";
            ((System.ComponentModel.ISupportInitialize)(this.bindSrc)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dbgGroupAccess)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dbgGroupAccess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkAllReport;
        private System.Windows.Forms.CheckBox chkAllAdd;
        private System.Windows.Forms.CheckBox chkAllDelete;
        private System.Windows.Forms.CheckBox chkAllEdit;
        private System.Windows.Forms.CheckBox chkAllRead;
        private System.Windows.Forms.CheckBox chkAllMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowRead;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowAdd;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowEdit;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowDelete;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AllowReport;
        private System.Windows.Forms.DataGridViewCheckBoxColumn MenuDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalChild;
        private System.Windows.Forms.DataGridViewTextBoxColumn MenuCode;
    }
}
