namespace Desktop.BaseForms
{
    partial class frmBaseList
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
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.pnlDate = new System.Windows.Forms.Panel();
            this.dtpDate2 = new System.Windows.Forms.DateTimePicker();
            this.dtpDate1 = new System.Windows.Forms.DateTimePicker();
            this.pnlBtn = new System.Windows.Forms.Panel();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.pnlString = new System.Windows.Forms.Panel();
            this.txtText = new System.Windows.Forms.TextBox();
            this.pnlFltrOpr = new System.Windows.Forms.Panel();
            this.cmbOperand = new System.Windows.Forms.ComboBox();
            this.cmbFieldName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dbgView = new System.Windows.Forms.DataGridView();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.pnlString.SuspendLayout();
            this.pnlFltrOpr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgView)).BeginInit();
            this.SuspendLayout(); 
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 528);
            this.pnlBottom.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8); 
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dbgView);
            this.pnlMain.Controls.Add(this.pnlFilter);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFilter.Controls.Add(this.pnlDate);
            this.pnlFilter.Controls.Add(this.pnlBtn);
            this.pnlFilter.Controls.Add(this.pnlString);
            this.pnlFilter.Controls.Add(this.pnlFltrOpr);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(780, 40);
            this.pnlFilter.TabIndex = 0;
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.dtpDate2);
            this.pnlDate.Controls.Add(this.dtpDate1);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlDate.Location = new System.Drawing.Point(324, 0);
            this.pnlDate.Margin = new System.Windows.Forms.Padding(4);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(300, 38);
            this.pnlDate.TabIndex = 20;
            this.pnlDate.Visible = false;
            // 
            // dtpDate2
            // 
            this.dtpDate2.Checked = false;
            this.dtpDate2.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate2.Location = new System.Drawing.Point(192, 4);
            this.dtpDate2.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.ShowCheckBox = true;
            this.dtpDate2.Size = new System.Drawing.Size(176, 24);
            this.dtpDate2.TabIndex = 7;
            this.dtpDate2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDate1_KeyPress);
            // 
            // dtpDate1
            // 
            this.dtpDate1.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate1.Location = new System.Drawing.Point(4, 4);
            this.dtpDate1.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDate1.Name = "dtpDate1";
            this.dtpDate1.Size = new System.Drawing.Size(176, 24);
            this.dtpDate1.TabIndex = 6;
            this.dtpDate1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDate1_KeyPress);
            // 
            // pnlBtn
            // 
            this.pnlBtn.Controls.Add(this.btnReset);
            this.pnlBtn.Controls.Add(this.btnFilter);
            this.pnlBtn.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlBtn.Location = new System.Drawing.Point(624, 0);
            this.pnlBtn.Margin = new System.Windows.Forms.Padding(4);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Size = new System.Drawing.Size(154, 38);
            this.pnlBtn.TabIndex = 19;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(76, 4);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(72, 30);
            this.btnReset.TabIndex = 9;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(4, 4);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(72, 30);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // pnlString
            // 
            this.pnlString.Controls.Add(this.txtText);
            this.pnlString.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlString.Location = new System.Drawing.Point(423, 0);
            this.pnlString.Margin = new System.Windows.Forms.Padding(4);
            this.pnlString.Name = "pnlString";
            this.pnlString.Size = new System.Drawing.Size(355, 38);
            this.pnlString.TabIndex = 17;
            this.pnlString.Visible = false;
            // 
            // txtText
            // 
            this.txtText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtText.Location = new System.Drawing.Point(4, 4);
            this.txtText.Margin = new System.Windows.Forms.Padding(4);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(341, 24);
            this.txtText.TabIndex = 4;
            this.txtText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtText_KeyPress);
            // 
            // pnlFltrOpr
            // 
            this.pnlFltrOpr.Controls.Add(this.cmbOperand);
            this.pnlFltrOpr.Controls.Add(this.cmbFieldName);
            this.pnlFltrOpr.Controls.Add(this.label5);
            this.pnlFltrOpr.Controls.Add(this.label4);
            this.pnlFltrOpr.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlFltrOpr.Location = new System.Drawing.Point(0, 0);
            this.pnlFltrOpr.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFltrOpr.Name = "pnlFltrOpr";
            this.pnlFltrOpr.Size = new System.Drawing.Size(423, 38);
            this.pnlFltrOpr.TabIndex = 13;
            // 
            // cmbOperand
            // 
            this.cmbOperand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperand.FormattingEnabled = true;
            this.cmbOperand.Items.AddRange(new object[] {
            "Equal",
            "Begin With",
            "End With",
            "Contain"});
            this.cmbOperand.Location = new System.Drawing.Point(268, 4);
            this.cmbOperand.Margin = new System.Windows.Forms.Padding(4);
            this.cmbOperand.Name = "cmbOperand";
            this.cmbOperand.Size = new System.Drawing.Size(148, 26);
            this.cmbOperand.TabIndex = 13;
            // 
            // cmbFieldName
            // 
            this.cmbFieldName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFieldName.FormattingEnabled = true;
            this.cmbFieldName.Location = new System.Drawing.Point(54, 4);
            this.cmbFieldName.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFieldName.Name = "cmbFieldName";
            this.cmbFieldName.Size = new System.Drawing.Size(208, 26);
            this.cmbFieldName.TabIndex = 12;
            this.cmbFieldName.SelectedIndexChanged += new System.EventHandler(this.cmbFieldName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-56, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "Filter";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 18);
            this.label4.TabIndex = 14;
            this.label4.Text = "Filter";
            // 
            // dbgView
            // 
            this.dbgView.AllowUserToAddRows = false;
            this.dbgView.AllowUserToDeleteRows = false;
            this.dbgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dbgView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbgView.Location = new System.Drawing.Point(0, 40);
            this.dbgView.Margin = new System.Windows.Forms.Padding(4);
            this.dbgView.Name = "dbgView";
            this.dbgView.ReadOnly = true;
            this.dbgView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dbgView.Size = new System.Drawing.Size(780, 432);
            this.dbgView.TabIndex = 1;
            this.dbgView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dbgView_CellDoubleClick);
            // 
            // frmBaseList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(782, 582);
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "frmBaseList";
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlDate.ResumeLayout(false);
            this.pnlBtn.ResumeLayout(false);
            this.pnlString.ResumeLayout(false);
            this.pnlString.PerformLayout();
            this.pnlFltrOpr.ResumeLayout(false);
            this.pnlFltrOpr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dbgView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Panel pnlDate;
        protected System.Windows.Forms.DateTimePicker dtpDate2;
        protected System.Windows.Forms.DateTimePicker dtpDate1;
        protected System.Windows.Forms.Panel pnlBtn;
        protected System.Windows.Forms.Button btnReset;
        protected System.Windows.Forms.Button btnFilter;
        protected System.Windows.Forms.Panel pnlString;
        protected System.Windows.Forms.TextBox txtText;
        protected System.Windows.Forms.Panel pnlFltrOpr;
        protected System.Windows.Forms.ComboBox cmbOperand;
        protected System.Windows.Forms.ComboBox cmbFieldName;
        public System.Windows.Forms.DataGridView dbgView;
        protected System.Windows.Forms.Panel pnlFilter;
    }
}
