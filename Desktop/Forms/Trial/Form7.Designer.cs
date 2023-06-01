namespace Desktop.Forms.Trial
{
    partial class Form7
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
            DBProject.Models.T_TRANSACTION_INPUT t_TRANSACTION_INPUT1 = new DBProject.Models.T_TRANSACTION_INPUT();
            DBProject.Models.T_TRANSACTION_LASER t_TRANSACTION_LASER1 = new DBProject.Models.T_TRANSACTION_LASER();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.checkBoxManual = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLotBoxID = new System.Windows.Forms.TextBox();
            this.fukudaNormalTestControl1 = new Desktop.Controls.FukudaNormalTestControl();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.checkBoxManual);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLotBoxID);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(796, 60);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Entry Lotbox ID : ";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(399, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 26);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // checkBoxManual
            // 
            this.checkBoxManual.AutoSize = true;
            this.checkBoxManual.Checked = true;
            this.checkBoxManual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxManual.Location = new System.Drawing.Point(280, 25);
            this.checkBoxManual.Name = "checkBoxManual";
            this.checkBoxManual.Size = new System.Drawing.Size(111, 21);
            this.checkBoxManual.TabIndex = 2;
            this.checkBoxManual.Text = "Manual Input";
            this.checkBoxManual.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 1;
            // 
            // txtLotBoxID
            // 
            this.txtLotBoxID.Location = new System.Drawing.Point(10, 23);
            this.txtLotBoxID.Name = "txtLotBoxID";
            this.txtLotBoxID.Size = new System.Drawing.Size(258, 22);
            this.txtLotBoxID.TabIndex = 0;
            this.txtLotBoxID.Text = "1";
            // 
            // fukudaNormalTestControl1
            // 
            this.fukudaNormalTestControl1.AQLReference = null;
            this.fukudaNormalTestControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fukudaNormalTestControl1.ButtonControlDisabled = Desktop.DesktopProperties.ButtonControlDisabled.bceNone;
            this.fukudaNormalTestControl1.DeviceID = "";
            this.fukudaNormalTestControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fukudaNormalTestControl1.FocusControl = null;
            this.fukudaNormalTestControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fukudaNormalTestControl1.Location = new System.Drawing.Point(0, 60);
            this.fukudaNormalTestControl1.LotBoxID = "";
            this.fukudaNormalTestControl1.LotboxLaserDowngradePosition = 0;
            this.fukudaNormalTestControl1.LotboxLaserPosition = 0;
            this.fukudaNormalTestControl1.LotboxPosition = 1;
            this.fukudaNormalTestControl1.Margin = new System.Windows.Forms.Padding(4);
            this.fukudaNormalTestControl1.MinimumSize = new System.Drawing.Size(225, 337);
            this.fukudaNormalTestControl1.Name = "fukudaNormalTestControl1";
            this.fukudaNormalTestControl1.PONumber = "";
            this.fukudaNormalTestControl1.Quantity = "0";
            this.fukudaNormalTestControl1.Size = new System.Drawing.Size(796, 386);
            this.fukudaNormalTestControl1.TabIndex = 0;
            this.fukudaNormalTestControl1.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            t_TRANSACTION_INPUT1.AQL_Reference = "";
            t_TRANSACTION_INPUT1.Created_Date = new System.DateTime(2017, 5, 9, 11, 30, 16, 612);
            t_TRANSACTION_INPUT1.Default_Test_Mode = null;
            t_TRANSACTION_INPUT1.Device_ID = null;
            t_TRANSACTION_INPUT1.End_Test = new System.DateTime(2017, 5, 9, 11, 30, 16, 612);
            t_TRANSACTION_INPUT1.LotBox_ID = null;
            t_TRANSACTION_INPUT1.LotBox_Position_Fukuda = 0;
            t_TRANSACTION_INPUT1.LotBox_Position_Laser = 0;
            t_TRANSACTION_INPUT1.LotBox_Position_Laser_Downgrade = 0;
            t_TRANSACTION_INPUT1.Noise_Type_Parameter_Ref = "";
            t_TRANSACTION_INPUT1.PO_Number = null;
            t_TRANSACTION_INPUT1.Quantity = 0;
            t_TRANSACTION_INPUT1.Signal_Device_ID_Ref = "";
            t_TRANSACTION_INPUT1.Start_Test = new System.DateTime(2017, 5, 9, 11, 30, 16, 612);
            t_TRANSACTION_INPUT1.Status = "";
            t_TRANSACTION_INPUT1.Updated_Date = new System.DateTime(2017, 5, 9, 11, 30, 16, 612);
            t_TRANSACTION_INPUT1.Updated_User = "system";
            t_TRANSACTION_INPUT1.User_ID = null;
            this.fukudaNormalTestControl1.TransactionInput = t_TRANSACTION_INPUT1;
            t_TRANSACTION_LASER1.Created_Date = new System.DateTime(2017, 5, 9, 11, 30, 16, 612);
            t_TRANSACTION_LASER1.Device_ID = null;
            t_TRANSACTION_LASER1.LotBox_ID = null;
            t_TRANSACTION_LASER1.LotBox_NG_ID = null;
            t_TRANSACTION_LASER1.LotBox_Position = 0;
            t_TRANSACTION_LASER1.PO_Number = null;
            t_TRANSACTION_LASER1.Quantity = 0;
            t_TRANSACTION_LASER1.Updated_Date = new System.DateTime(2017, 5, 9, 11, 30, 16, 612);
            t_TRANSACTION_LASER1.Updated_User = "system";
            t_TRANSACTION_LASER1.User_ID = null;
            this.fukudaNormalTestControl1.TransactionSorter = t_TRANSACTION_LASER1;
            this.fukudaNormalTestControl1.UserID = null;
            this.fukudaNormalTestControl1.OnTransactionMachineBook += new Commons.EventMachineBook(this.fukudaNormalTestControl1_OnTransactionMachineBook);
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 446);
            this.Controls.Add(this.fukudaNormalTestControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form7";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Desktop.Controls.FukudaNormalTestControl fukudaNormalTestControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox checkBoxManual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLotBoxID;
    }
}