namespace Desktop.Forms.Test
{
    partial class frmSorterTestData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSorterTestData));
            DBProject.Models.T_TRANSACTION_INPUT t_TRANSACTION_INPUT1 = new DBProject.Models.T_TRANSACTION_INPUT();
            DBProject.Models.T_TRANSACTION_LASER t_TRANSACTION_LASER1 = new DBProject.Models.T_TRANSACTION_LASER();
            DBProject.Models.T_TRANSACTION_INPUT t_TRANSACTION_INPUT2 = new DBProject.Models.T_TRANSACTION_INPUT();
            DBProject.Models.T_TRANSACTION_LASER t_TRANSACTION_LASER2 = new DBProject.Models.T_TRANSACTION_LASER();
            DBProject.Models.T_TRANSACTION_INPUT t_TRANSACTION_INPUT3 = new DBProject.Models.T_TRANSACTION_INPUT();
            DBProject.Models.T_TRANSACTION_LASER t_TRANSACTION_LASER3 = new DBProject.Models.T_TRANSACTION_LASER();
            DBProject.Models.T_TRANSACTION_INPUT t_TRANSACTION_INPUT4 = new DBProject.Models.T_TRANSACTION_INPUT();
            DBProject.Models.T_TRANSACTION_LASER t_TRANSACTION_LASER4 = new DBProject.Models.T_TRANSACTION_LASER();
            this.tabNormalMode = new System.Windows.Forms.TabControl();
            this.tabNormanStation1 = new System.Windows.Forms.TabPage();
            this.sorterNormalTestControl1 = new Desktop.Controls.LaserNormalTestControl();
            this.tabNormanStation2 = new System.Windows.Forms.TabPage();
            this.sorterNormalTestControl2 = new Desktop.Controls.LaserNormalTestControl();
            this.tabNormanStation3 = new System.Windows.Forms.TabPage();
            this.sorterNormalTestControl3 = new Desktop.Controls.LaserNormalTestControl();
            this.tabNormanStation4 = new System.Windows.Forms.TabPage();
            this.sorterNormalTestControl4 = new Desktop.Controls.LaserNormalTestControl();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tabNormalMode.SuspendLayout();
            this.tabNormanStation1.SuspendLayout();
            this.tabNormanStation2.SuspendLayout();
            this.tabNormanStation3.SuspendLayout();
            this.tabNormanStation4.SuspendLayout();
            this.SuspendLayout(); 
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 310);
            this.pnlBottom.Size = new System.Drawing.Size(464, 44); 
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(464, 54);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabNormalMode);
            this.pnlMain.Location = new System.Drawing.Point(0, 54);
            this.pnlMain.Size = new System.Drawing.Size(464, 256); 
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.Images.SetKeyName(0, "test 32x32.png");
            this.imageList.Images.SetKeyName(1, "input data 32x32.png");
            this.imageList.Images.SetKeyName(2, "switch 32x32.png");
            this.imageList.Images.SetKeyName(3, "calibration 32x32.png");
            this.imageList.Images.SetKeyName(4, "configuration 32x32.png");
            this.imageList.Images.SetKeyName(5, "signal2 32x32.png");
            this.imageList.Images.SetKeyName(6, "noise 32x32.png");
            this.imageList.Images.SetKeyName(7, "Resistance 32x32.png");
            this.imageList.Images.SetKeyName(8, "report 32x32.png");
            this.imageList.Images.SetKeyName(9, "box 32x32.png");
            this.imageList.Images.SetKeyName(10, "list 32x32.png");
            this.imageList.Images.SetKeyName(11, "ng 32x32.png");
            this.imageList.Images.SetKeyName(12, "close 32x32.png");
            this.imageList.Images.SetKeyName(13, "save 32x32.png");
            this.imageList.Images.SetKeyName(14, "add 32x32.png");
            this.imageList.Images.SetKeyName(15, "edit 32x32.png");
            this.imageList.Images.SetKeyName(16, "delete 32x32.png");
            // 
            // tabNormalMode
            // 
            this.tabNormalMode.Controls.Add(this.tabNormanStation1);
            this.tabNormalMode.Controls.Add(this.tabNormanStation2);
            this.tabNormalMode.Controls.Add(this.tabNormanStation3);
            this.tabNormalMode.Controls.Add(this.tabNormanStation4);
            this.tabNormalMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabNormalMode.Location = new System.Drawing.Point(0, 0);
            this.tabNormalMode.Name = "tabNormalMode";
            this.tabNormalMode.SelectedIndex = 0;
            this.tabNormalMode.Size = new System.Drawing.Size(460, 252);
            this.tabNormalMode.TabIndex = 1;
            this.tabNormalMode.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabNormalMode_Selecting);
            // 
            // tabNormanStation1
            // 
            this.tabNormanStation1.Controls.Add(this.sorterNormalTestControl1);
            this.tabNormanStation1.Location = new System.Drawing.Point(4, 27);
            this.tabNormanStation1.Name = "tabNormanStation1";
            this.tabNormanStation1.Padding = new System.Windows.Forms.Padding(3);
            this.tabNormanStation1.Size = new System.Drawing.Size(452, 221);
            this.tabNormanStation1.TabIndex = 0;
            this.tabNormanStation1.Text = "Station 1";
            this.tabNormanStation1.UseVisualStyleBackColor = true;
            // 
            // sorterNormalTestControl1
            // 
            this.sorterNormalTestControl1.ButtonControlDisabled = Desktop.DesktopProperties.ButtonControlDisabled.bceNone;
            this.sorterNormalTestControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sorterNormalTestControl1.FAllowChange = true;
            this.sorterNormalTestControl1.FocusControl = null;
            this.sorterNormalTestControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sorterNormalTestControl1.Location = new System.Drawing.Point(3, 3);
            this.sorterNormalTestControl1.LotboxPosition = 1;
            this.sorterNormalTestControl1.Name = "sorterNormalTestControl1";
            this.sorterNormalTestControl1.PONumber = "";
            this.sorterNormalTestControl1.Size = new System.Drawing.Size(446, 215);
            this.sorterNormalTestControl1.TabIndex = 0;
            this.sorterNormalTestControl1.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            t_TRANSACTION_INPUT1.AQL_Reference = "";
            t_TRANSACTION_INPUT1.Created_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT1.Default_Test_Mode = null;
            t_TRANSACTION_INPUT1.Device_ID = null;
            t_TRANSACTION_INPUT1.End_Test = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT1.LotBox_ID = null;
            t_TRANSACTION_INPUT1.LotBox_Position_Fukuda = 0;
            t_TRANSACTION_INPUT1.LotBox_Position_Laser = 0;
            t_TRANSACTION_INPUT1.LotBox_Position_Laser_Downgrade = 0;
            t_TRANSACTION_INPUT1.Noise_Type_Parameter_Ref = "";
            t_TRANSACTION_INPUT1.PO_Number = null;
            t_TRANSACTION_INPUT1.Quantity = 0;
            t_TRANSACTION_INPUT1.Signal_Device_ID_Ref = "";
            t_TRANSACTION_INPUT1.Start_Test = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT1.Status = ""; 
            t_TRANSACTION_INPUT1.Updated_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT1.Updated_User = "system";
            t_TRANSACTION_INPUT1.User_ID = null;
            this.sorterNormalTestControl1.TransactionInput = t_TRANSACTION_INPUT1;
            t_TRANSACTION_LASER1.Created_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 911);
            t_TRANSACTION_LASER1.Device_ID = null;
            t_TRANSACTION_LASER1.LotBox_ID = null;
            t_TRANSACTION_LASER1.LotBox_NG_ID = null;
            t_TRANSACTION_LASER1.LotBox_Position = 0;
            t_TRANSACTION_LASER1.PO_Number = null;
            t_TRANSACTION_LASER1.Quantity = 0; 
            t_TRANSACTION_LASER1.Updated_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 911);
            t_TRANSACTION_LASER1.Updated_User = "system";
            t_TRANSACTION_LASER1.User_ID = null;
            this.sorterNormalTestControl1.TransactionSorter = t_TRANSACTION_LASER1;
            this.sorterNormalTestControl1.UserID = null;
            this.sorterNormalTestControl1.Validating += new System.ComponentModel.CancelEventHandler(this.sorterNormalTestControl1_Validating);
            // 
            // tabNormanStation2
            // 
            this.tabNormanStation2.Controls.Add(this.sorterNormalTestControl2);
            this.tabNormanStation2.Location = new System.Drawing.Point(4, 27);
            this.tabNormanStation2.Name = "tabNormanStation2";
            this.tabNormanStation2.Padding = new System.Windows.Forms.Padding(3);
            this.tabNormanStation2.Size = new System.Drawing.Size(770, 449);
            this.tabNormanStation2.TabIndex = 1;
            this.tabNormanStation2.Text = "Station 2";
            this.tabNormanStation2.UseVisualStyleBackColor = true;
            // 
            // sorterNormalTestControl2
            // 
            this.sorterNormalTestControl2.ButtonControlDisabled = Desktop.DesktopProperties.ButtonControlDisabled.bceNone;
            this.sorterNormalTestControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sorterNormalTestControl2.FAllowChange = true;
            this.sorterNormalTestControl2.FocusControl = null;
            this.sorterNormalTestControl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sorterNormalTestControl2.Location = new System.Drawing.Point(3, 3);
            this.sorterNormalTestControl2.LotboxPosition = 2;
            this.sorterNormalTestControl2.Name = "sorterNormalTestControl2";
            this.sorterNormalTestControl2.PONumber = "";
            this.sorterNormalTestControl2.Size = new System.Drawing.Size(764, 443);
            this.sorterNormalTestControl2.TabIndex = 1;
            this.sorterNormalTestControl2.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            t_TRANSACTION_INPUT2.AQL_Reference = "";
            t_TRANSACTION_INPUT2.Created_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT2.Default_Test_Mode = null;
            t_TRANSACTION_INPUT2.Device_ID = null;
            t_TRANSACTION_INPUT2.End_Test = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT2.LotBox_ID = null;
            t_TRANSACTION_INPUT2.LotBox_Position_Fukuda = 0;
            t_TRANSACTION_INPUT2.LotBox_Position_Laser = 0;
            t_TRANSACTION_INPUT2.LotBox_Position_Laser_Downgrade = 0;
            t_TRANSACTION_INPUT2.Noise_Type_Parameter_Ref = "";
            t_TRANSACTION_INPUT2.PO_Number = null;
            t_TRANSACTION_INPUT2.Quantity = 0;
            t_TRANSACTION_INPUT2.Signal_Device_ID_Ref = "";
            t_TRANSACTION_INPUT2.Start_Test = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT2.Status = ""; 
            t_TRANSACTION_INPUT2.Updated_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT2.Updated_User = "system";
            t_TRANSACTION_INPUT2.User_ID = null;
            this.sorterNormalTestControl2.TransactionInput = t_TRANSACTION_INPUT2;
            t_TRANSACTION_LASER2.Created_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 911);
            t_TRANSACTION_LASER2.Device_ID = null;
            t_TRANSACTION_LASER2.LotBox_ID = null;
            t_TRANSACTION_LASER2.LotBox_NG_ID = null;
            t_TRANSACTION_LASER2.LotBox_Position = 0;
            t_TRANSACTION_LASER2.PO_Number = null;
            t_TRANSACTION_LASER2.Quantity = 0; 
            t_TRANSACTION_LASER2.Updated_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 911);
            t_TRANSACTION_LASER2.Updated_User = "system";
            t_TRANSACTION_LASER2.User_ID = null;
            this.sorterNormalTestControl2.TransactionSorter = t_TRANSACTION_LASER2;
            this.sorterNormalTestControl2.UserID = null;
            // 
            // tabNormanStation3
            // 
            this.tabNormanStation3.Controls.Add(this.sorterNormalTestControl3);
            this.tabNormanStation3.Location = new System.Drawing.Point(4, 27);
            this.tabNormanStation3.Name = "tabNormanStation3";
            this.tabNormanStation3.Padding = new System.Windows.Forms.Padding(3);
            this.tabNormanStation3.Size = new System.Drawing.Size(770, 449);
            this.tabNormanStation3.TabIndex = 2;
            this.tabNormanStation3.Text = "Station 3";
            this.tabNormanStation3.UseVisualStyleBackColor = true;
            // 
            // sorterNormalTestControl3
            // 
            this.sorterNormalTestControl3.ButtonControlDisabled = Desktop.DesktopProperties.ButtonControlDisabled.bceNone;
            this.sorterNormalTestControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sorterNormalTestControl3.FAllowChange = true;
            this.sorterNormalTestControl3.FocusControl = null;
            this.sorterNormalTestControl3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sorterNormalTestControl3.Location = new System.Drawing.Point(3, 3);
            this.sorterNormalTestControl3.LotboxPosition = 3;
            this.sorterNormalTestControl3.Name = "sorterNormalTestControl3";
            this.sorterNormalTestControl3.PONumber = "";
            this.sorterNormalTestControl3.Size = new System.Drawing.Size(764, 443);
            this.sorterNormalTestControl3.TabIndex = 1;
            this.sorterNormalTestControl3.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            t_TRANSACTION_INPUT3.AQL_Reference = "";
            t_TRANSACTION_INPUT3.Created_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT3.Default_Test_Mode = null;
            t_TRANSACTION_INPUT3.Device_ID = null;
            t_TRANSACTION_INPUT3.End_Test = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT3.LotBox_ID = null;
            t_TRANSACTION_INPUT3.LotBox_Position_Fukuda = 0;
            t_TRANSACTION_INPUT3.LotBox_Position_Laser = 0;
            t_TRANSACTION_INPUT3.LotBox_Position_Laser_Downgrade = 0;
            t_TRANSACTION_INPUT3.Noise_Type_Parameter_Ref = "";
            t_TRANSACTION_INPUT3.PO_Number = null;
            t_TRANSACTION_INPUT3.Quantity = 0;
            t_TRANSACTION_INPUT3.Signal_Device_ID_Ref = "";
            t_TRANSACTION_INPUT3.Start_Test = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT3.Status = ""; 
            t_TRANSACTION_INPUT3.Updated_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT3.Updated_User = "system";
            t_TRANSACTION_INPUT3.User_ID = null;
            this.sorterNormalTestControl3.TransactionInput = t_TRANSACTION_INPUT3;
            t_TRANSACTION_LASER3.Created_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 911);
            t_TRANSACTION_LASER3.Device_ID = null;
            t_TRANSACTION_LASER3.LotBox_ID = null;
            t_TRANSACTION_LASER3.LotBox_NG_ID = null;
            t_TRANSACTION_LASER3.LotBox_Position = 0;
            t_TRANSACTION_LASER3.PO_Number = null;
            t_TRANSACTION_LASER3.Quantity = 0; 
            t_TRANSACTION_LASER3.Updated_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 911);
            t_TRANSACTION_LASER3.Updated_User = "system";
            t_TRANSACTION_LASER3.User_ID = null;
            this.sorterNormalTestControl3.TransactionSorter = t_TRANSACTION_LASER3;
            this.sorterNormalTestControl3.UserID = null;
            // 
            // tabNormanStation4
            // 
            this.tabNormanStation4.Controls.Add(this.sorterNormalTestControl4);
            this.tabNormanStation4.Location = new System.Drawing.Point(4, 27);
            this.tabNormanStation4.Name = "tabNormanStation4";
            this.tabNormanStation4.Padding = new System.Windows.Forms.Padding(3);
            this.tabNormanStation4.Size = new System.Drawing.Size(770, 449);
            this.tabNormanStation4.TabIndex = 3;
            this.tabNormanStation4.Text = "Station 4";
            this.tabNormanStation4.UseVisualStyleBackColor = true;
            // 
            // sorterNormalTestControl4
            // 
            this.sorterNormalTestControl4.ButtonControlDisabled = Desktop.DesktopProperties.ButtonControlDisabled.bceNone;
            this.sorterNormalTestControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sorterNormalTestControl4.FAllowChange = true;
            this.sorterNormalTestControl4.FocusControl = null;
            this.sorterNormalTestControl4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sorterNormalTestControl4.Location = new System.Drawing.Point(3, 3);
            this.sorterNormalTestControl4.LotboxPosition = 4;
            this.sorterNormalTestControl4.Name = "sorterNormalTestControl4";
            this.sorterNormalTestControl4.PONumber = "";
            this.sorterNormalTestControl4.Size = new System.Drawing.Size(764, 443);
            this.sorterNormalTestControl4.TabIndex = 1;
            this.sorterNormalTestControl4.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            t_TRANSACTION_INPUT4.AQL_Reference = "";
            t_TRANSACTION_INPUT4.Created_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT4.Default_Test_Mode = null;
            t_TRANSACTION_INPUT4.Device_ID = null;
            t_TRANSACTION_INPUT4.End_Test = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT4.LotBox_ID = null;
            t_TRANSACTION_INPUT4.LotBox_Position_Fukuda = 0;
            t_TRANSACTION_INPUT4.LotBox_Position_Laser = 0;
            t_TRANSACTION_INPUT4.LotBox_Position_Laser_Downgrade = 0;
            t_TRANSACTION_INPUT4.Noise_Type_Parameter_Ref = "";
            t_TRANSACTION_INPUT4.PO_Number = null;
            t_TRANSACTION_INPUT4.Quantity = 0;
            t_TRANSACTION_INPUT4.Signal_Device_ID_Ref = "";
            t_TRANSACTION_INPUT4.Start_Test = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT4.Status = ""; 
            t_TRANSACTION_INPUT4.Updated_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 910);
            t_TRANSACTION_INPUT4.Updated_User = "system";
            t_TRANSACTION_INPUT4.User_ID = null;
            this.sorterNormalTestControl4.TransactionInput = t_TRANSACTION_INPUT4;
            t_TRANSACTION_LASER4.Created_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 911);
            t_TRANSACTION_LASER4.Device_ID = null;
            t_TRANSACTION_LASER4.LotBox_ID = null;
            t_TRANSACTION_LASER4.LotBox_NG_ID = null;
            t_TRANSACTION_LASER4.LotBox_Position = 0;
            t_TRANSACTION_LASER4.PO_Number = null;
            t_TRANSACTION_LASER4.Quantity = 0; 
            t_TRANSACTION_LASER4.Updated_Date = new System.DateTime(2017, 1, 11, 11, 44, 51, 911);
            t_TRANSACTION_LASER4.Updated_User = "system";
            t_TRANSACTION_LASER4.User_ID = null;
            this.sorterNormalTestControl4.TransactionSorter = t_TRANSACTION_LASER4;
            this.sorterNormalTestControl4.UserID = null;
            // 
            // frmSorterTestData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(464, 354);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.FormCaption = "Sorter Input Form";
            this.Name = "frmSorterTestData";
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.tabNormalMode.ResumeLayout(false);
            this.tabNormanStation1.ResumeLayout(false);
            this.tabNormanStation2.ResumeLayout(false);
            this.tabNormanStation3.ResumeLayout(false);
            this.tabNormanStation4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabNormalMode;
        private System.Windows.Forms.TabPage tabNormanStation1;
        private Controls.LaserNormalTestControl sorterNormalTestControl1;
        private System.Windows.Forms.TabPage tabNormanStation2;
        private Controls.LaserNormalTestControl sorterNormalTestControl2;
        private System.Windows.Forms.TabPage tabNormanStation3;
        private Controls.LaserNormalTestControl sorterNormalTestControl3;
        private System.Windows.Forms.TabPage tabNormanStation4;
        protected Controls.LaserNormalTestControl sorterNormalTestControl4;
    }
}
