namespace Desktop.Controls
{
    partial class frmAuthChangeParameters
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
            this.panelMessage = new Desktop.BaseComponents.PanelMessage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtCurrDeviceName = new Desktop.BaseComponents.PlaceholderTextBox();
            this.txtCurrDeviceID = new Desktop.BaseComponents.PlaceholderTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnSearch1 = new System.Windows.Forms.Button();
            this.txtNoiseParam = new Desktop.BaseComponents.PlaceholderTextBox();
            this.txtDeviceName1 = new Desktop.BaseComponents.PlaceholderTextBox();
            this.txtDeviceID1 = new Desktop.BaseComponents.PlaceholderTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDeviceName2 = new Desktop.BaseComponents.PlaceholderTextBox();
            this.txtDeviceID2 = new Desktop.BaseComponents.PlaceholderTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(761, 110);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Size = new System.Drawing.Size(761, 251);
            this.groupBox2.Text = " Parameters ";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Enabled = false;
            this.btnSubmit.Location = new System.Drawing.Point(578, 12);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 417);
            this.pnlBottom.Size = new System.Drawing.Size(763, 54); 
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.panelMessage);
            this.pnlTop.Size = new System.Drawing.Size(763, 54); 
            this.pnlTop.Controls.SetChildIndex(this.panelMessage, 0);
            // 
            // pnlMain
            // 
            this.pnlMain.Size = new System.Drawing.Size(763, 363); 
            // 
            // panelMessage
            // 
            this.panelMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panelMessage.Location = new System.Drawing.Point(0, 0);
            this.panelMessage.Message = "";
            this.panelMessage.Name = "panelMessage";
            this.panelMessage.Size = new System.Drawing.Size(200, 100);
            this.panelMessage.TabIndex = 1;
            this.panelMessage.Visible = false;
            this.panelMessage.OnCloseClick += new System.EventHandler(this.panelMessage_OnCloseClick);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtCurrDeviceName);
            this.groupBox5.Controls.Add(this.txtCurrDeviceID);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(755, 94);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " Current Device ";
            // 
            // txtCurrDeviceName
            // 
            this.txtCurrDeviceName.Enabled = false;
            this.txtCurrDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrDeviceName.Location = new System.Drawing.Point(22, 55);
            this.txtCurrDeviceName.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrDeviceName.Name = "txtCurrDeviceName";
            this.txtCurrDeviceName.PlaceholderText = "Device Name ...";
            this.txtCurrDeviceName.ReadOnly = true;
            this.txtCurrDeviceName.Size = new System.Drawing.Size(332, 24);
            this.txtCurrDeviceName.TabIndex = 42;
            // 
            // txtCurrDeviceID
            // 
            this.txtCurrDeviceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrDeviceID.Location = new System.Drawing.Point(21, 24);
            this.txtCurrDeviceID.Margin = new System.Windows.Forms.Padding(4);
            this.txtCurrDeviceID.Name = "txtCurrDeviceID";
            this.txtCurrDeviceID.PlaceholderText = "Device ID ...";
            this.txtCurrDeviceID.ReadOnly = true;
            this.txtCurrDeviceID.Size = new System.Drawing.Size(207, 24);
            this.txtCurrDeviceID.TabIndex = 41;
            this.txtCurrDeviceID.Tag = "Device ID";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSearch1);
            this.groupBox3.Controls.Add(this.txtNoiseParam);
            this.groupBox3.Controls.Add(this.txtDeviceName1);
            this.groupBox3.Controls.Add(this.txtDeviceID1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(374, 134);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Noise Parameter ";
            // 
            // btnSearch1
            // 
            this.btnSearch1.Location = new System.Drawing.Point(235, 29);
            this.btnSearch1.Name = "btnSearch1";
            this.btnSearch1.Size = new System.Drawing.Size(75, 34);
            this.btnSearch1.TabIndex = 43;
            this.btnSearch1.Tag = "1";
            this.btnSearch1.Text = "Search";
            this.btnSearch1.UseVisualStyleBackColor = true;
            this.btnSearch1.Click += new System.EventHandler(this.btnSearch1_Click);
            // 
            // txtNoiseParam
            // 
            this.txtNoiseParam.Enabled = false;
            this.txtNoiseParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNoiseParam.Location = new System.Drawing.Point(22, 97);
            this.txtNoiseParam.Margin = new System.Windows.Forms.Padding(4);
            this.txtNoiseParam.Name = "txtNoiseParam";
            this.txtNoiseParam.PlaceholderText = "Noise Parameter ...";
            this.txtNoiseParam.ReadOnly = true;
            this.txtNoiseParam.Size = new System.Drawing.Size(332, 24);
            this.txtNoiseParam.TabIndex = 42;
            // 
            // txtDeviceName1
            // 
            this.txtDeviceName1.Enabled = false;
            this.txtDeviceName1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceName1.Location = new System.Drawing.Point(22, 65);
            this.txtDeviceName1.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeviceName1.Name = "txtDeviceName1";
            this.txtDeviceName1.PlaceholderText = "Device Name ...";
            this.txtDeviceName1.ReadOnly = true;
            this.txtDeviceName1.Size = new System.Drawing.Size(332, 24);
            this.txtDeviceName1.TabIndex = 40;
            // 
            // txtDeviceID1
            // 
            this.txtDeviceID1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceID1.Location = new System.Drawing.Point(21, 34);
            this.txtDeviceID1.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeviceID1.Name = "txtDeviceID1";
            this.txtDeviceID1.PlaceholderText = "Device ID ...";
            this.txtDeviceID1.ReadOnly = true;
            this.txtDeviceID1.Size = new System.Drawing.Size(207, 24);
            this.txtDeviceID1.TabIndex = 39;
            this.txtDeviceID1.Tag = "Device ID";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Controls.Add(this.txtDeviceName2);
            this.groupBox4.Controls.Add(this.txtDeviceID2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(377, 114);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(381, 134);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " Signal Parameter ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(239, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 34);
            this.button1.TabIndex = 46;
            this.button1.Tag = "2";
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSearch1_Click);
            // 
            // txtDeviceName2
            // 
            this.txtDeviceName2.Enabled = false;
            this.txtDeviceName2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceName2.Location = new System.Drawing.Point(26, 65);
            this.txtDeviceName2.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeviceName2.Name = "txtDeviceName2";
            this.txtDeviceName2.PlaceholderText = "Device Name ...";
            this.txtDeviceName2.ReadOnly = true;
            this.txtDeviceName2.Size = new System.Drawing.Size(332, 24);
            this.txtDeviceName2.TabIndex = 45;
            // 
            // txtDeviceID2
            // 
            this.txtDeviceID2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceID2.Location = new System.Drawing.Point(25, 34);
            this.txtDeviceID2.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeviceID2.Name = "txtDeviceID2";
            this.txtDeviceID2.PlaceholderText = "Device ID ...";
            this.txtDeviceID2.ReadOnly = true;
            this.txtDeviceID2.Size = new System.Drawing.Size(207, 24);
            this.txtDeviceID2.TabIndex = 44;
            this.txtDeviceID2.Tag = "Device ID";
            // 
            // frmAuthChangeParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.ClientSize = new System.Drawing.Size(763, 471);
            this.Name = "frmAuthChangeParameters";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private BaseComponents.PanelMessage panelMessage;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button1;
        private Desktop.BaseComponents.PlaceholderTextBox txtDeviceName2;
        private Desktop.BaseComponents.PlaceholderTextBox txtDeviceID2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSearch1;
        private Desktop.BaseComponents.PlaceholderTextBox txtNoiseParam;
        private Desktop.BaseComponents.PlaceholderTextBox txtDeviceName1;
        private Desktop.BaseComponents.PlaceholderTextBox txtDeviceID1;
        private System.Windows.Forms.GroupBox groupBox5;
        private Desktop.BaseComponents.PlaceholderTextBox txtCurrDeviceName;
        private Desktop.BaseComponents.PlaceholderTextBox txtCurrDeviceID;
    }
}
