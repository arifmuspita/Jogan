namespace Desktop.Controls
{
    partial class FukudaNormalTestControl
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
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtLotBoxID = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.txtDeviceID = new System.Windows.Forms.TextBox();
            this.txtPONumber = new System.Windows.Forms.TextBox();
            this.chkSignal = new System.Windows.Forms.CheckBox();
            this.chkResistance = new System.Windows.Forms.CheckBox();
            this.chkNoise = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAQLRef = new System.Windows.Forms.TextBox();
            this.lblAQLRef = new System.Windows.Forms.Label();
            this.txtAQLResult = new System.Windows.Forms.TextBox();
            this.lblAQLResult = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 324);
            this.pnlBottom.Size = new System.Drawing.Size(517, 49);
            this.pnlBottom.TabIndex = 9;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.txtAQLResult);
            this.pnlMain.Controls.Add(this.lblAQLResult);
            this.pnlMain.Controls.Add(this.txtAQLRef);
            this.pnlMain.Controls.Add(this.lblAQLRef);
            this.pnlMain.Controls.Add(this.txtQuantity);
            this.pnlMain.Controls.Add(this.txtLotBoxID);
            this.pnlMain.Controls.Add(this.btnChange);
            this.pnlMain.Controls.Add(this.txtDeviceName);
            this.pnlMain.Controls.Add(this.txtDeviceID);
            this.pnlMain.Controls.Add(this.txtPONumber);
            this.pnlMain.Controls.Add(this.chkSignal);
            this.pnlMain.Controls.Add(this.chkResistance);
            this.pnlMain.Controls.Add(this.chkNoise);
            this.pnlMain.Controls.Add(this.label4);
            this.pnlMain.Controls.Add(this.label3);
            this.pnlMain.Controls.Add(this.label2);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Size = new System.Drawing.Size(517, 324);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(153, 6);
            this.btnCancel.Size = new System.Drawing.Size(124, 34);
            this.btnCancel.TabIndex = 11;
            // 
            // btnSetReady
            // 
            this.btnSetReady.Location = new System.Drawing.Point(15, 6);
            this.btnSetReady.Size = new System.Drawing.Size(124, 34);
            this.btnSetReady.TabIndex = 10;
            // 
            // panelMessage
            // 
            this.panelMessage.OnCloseClick += new System.EventHandler(this.panelMessage_OnCloseClick);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(16, 249);
            this.txtQuantity.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuantity.MaxLength = 3;
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Size = new System.Drawing.Size(81, 24);
            this.txtQuantity.TabIndex = 5;
            this.txtQuantity.Tag = "Quantity";
            this.txtQuantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantity_KeyPress);
            // 
            // txtLotBoxID
            // 
            this.txtLotBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotBoxID.Location = new System.Drawing.Point(15, 202);
            this.txtLotBoxID.Margin = new System.Windows.Forms.Padding(4);
            this.txtLotBoxID.Name = "txtLotBoxID";
            this.txtLotBoxID.ReadOnly = true;
            this.txtLotBoxID.Size = new System.Drawing.Size(198, 24);
            this.txtLotBoxID.TabIndex = 4;
            this.txtLotBoxID.Tag = "Lotbox ID";
            this.txtLotBoxID.Leave += new System.EventHandler(this.txtLotBoxID_Leave);
            // 
            // btnChange
            // 
            this.btnChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChange.Location = new System.Drawing.Point(15, 146);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(207, 31);
            this.btnChange.TabIndex = 3;
            this.btnChange.Text = "Change Device Parameter";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceName.Location = new System.Drawing.Point(16, 115);
            this.txtDeviceName.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.ReadOnly = true;
            this.txtDeviceName.Size = new System.Drawing.Size(290, 24);
            this.txtDeviceName.TabIndex = 2;
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceID.Location = new System.Drawing.Point(15, 84);
            this.txtDeviceID.Margin = new System.Windows.Forms.Padding(4);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.ReadOnly = true;
            this.txtDeviceID.Size = new System.Drawing.Size(207, 24);
            this.txtDeviceID.TabIndex = 1;
            this.txtDeviceID.Tag = "Device ID";
            this.txtDeviceID.TextChanged += new System.EventHandler(this.txtDeviceID_TextChanged);
            // 
            // txtPONumber
            // 
            this.txtPONumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPONumber.Location = new System.Drawing.Point(15, 34);
            this.txtPONumber.Margin = new System.Windows.Forms.Padding(4);
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.ReadOnly = true;
            this.txtPONumber.Size = new System.Drawing.Size(207, 24);
            this.txtPONumber.TabIndex = 0;
            this.txtPONumber.Tag = "PO Number";
            this.txtPONumber.Leave += new System.EventHandler(this.txtPONumber_Leave);
            // 
            // chkSignal
            // 
            this.chkSignal.AutoSize = true;
            this.chkSignal.Checked = true;
            this.chkSignal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSignal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSignal.Location = new System.Drawing.Point(90, 283);
            this.chkSignal.Margin = new System.Windows.Forms.Padding(4);
            this.chkSignal.Name = "chkSignal";
            this.chkSignal.Size = new System.Drawing.Size(70, 22);
            this.chkSignal.TabIndex = 7;
            this.chkSignal.Text = "Signal";
            this.chkSignal.UseVisualStyleBackColor = true;
            // 
            // chkResistance
            // 
            this.chkResistance.AutoSize = true;
            this.chkResistance.Checked = true;
            this.chkResistance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkResistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkResistance.Location = new System.Drawing.Point(173, 283);
            this.chkResistance.Margin = new System.Windows.Forms.Padding(4);
            this.chkResistance.Name = "chkResistance";
            this.chkResistance.Size = new System.Drawing.Size(104, 22);
            this.chkResistance.TabIndex = 8;
            this.chkResistance.Text = "Resistance";
            this.chkResistance.UseVisualStyleBackColor = true;
            // 
            // chkNoise
            // 
            this.chkNoise.AutoSize = true;
            this.chkNoise.Checked = true;
            this.chkNoise.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoise.Location = new System.Drawing.Point(16, 283);
            this.chkNoise.Margin = new System.Windows.Forms.Padding(4);
            this.chkNoise.Name = "chkNoise";
            this.chkNoise.Size = new System.Drawing.Size(69, 22);
            this.chkNoise.TabIndex = 6;
            this.chkNoise.Text = "Noise";
            this.chkNoise.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 40;
            this.label4.Text = "LotBox ID :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 229);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 39;
            this.label3.Text = "Quantity :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 38;
            this.label2.Text = "Device ID :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 37;
            this.label1.Text = "PO Number :";
            // 
            // txtAQLRef
            // 
            this.txtAQLRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAQLRef.Location = new System.Drawing.Point(230, 34);
            this.txtAQLRef.Margin = new System.Windows.Forms.Padding(4);
            this.txtAQLRef.Name = "txtAQLRef";
            this.txtAQLRef.ReadOnly = true;
            this.txtAQLRef.Size = new System.Drawing.Size(171, 24);
            this.txtAQLRef.TabIndex = 41;
            this.txtAQLRef.Tag = "PO Number";
            this.txtAQLRef.Visible = false;
            // 
            // lblAQLRef
            // 
            this.lblAQLRef.AutoSize = true;
            this.lblAQLRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAQLRef.Location = new System.Drawing.Point(227, 12);
            this.lblAQLRef.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAQLRef.Name = "lblAQLRef";
            this.lblAQLRef.Size = new System.Drawing.Size(117, 18);
            this.lblAQLRef.TabIndex = 42;
            this.lblAQLRef.Text = "AQL Reference :";
            this.lblAQLRef.Visible = false;
            // 
            // txtAQLResult
            // 
            this.txtAQLResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAQLResult.Location = new System.Drawing.Point(409, 34);
            this.txtAQLResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtAQLResult.Name = "txtAQLResult";
            this.txtAQLResult.ReadOnly = true;
            this.txtAQLResult.Size = new System.Drawing.Size(88, 24);
            this.txtAQLResult.TabIndex = 43;
            this.txtAQLResult.Tag = "PO Number";
            this.txtAQLResult.Visible = false;
            // 
            // lblAQLResult
            // 
            this.lblAQLResult.AutoSize = true;
            this.lblAQLResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAQLResult.Location = new System.Drawing.Point(406, 12);
            this.lblAQLResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAQLResult.Name = "lblAQLResult";
            this.lblAQLResult.Size = new System.Drawing.Size(91, 18);
            this.lblAQLResult.TabIndex = 44;
            this.lblAQLResult.Text = "AQL Result :";
            this.lblAQLResult.Visible = false;
            // 
            // FukudaNormalTestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(225, 337);
            this.Name = "FukudaNormalTestControl";
            this.Size = new System.Drawing.Size(517, 373);
            this.TestMode = Desktop.DesktopProperties.TestMode.tmNormal;
            this.pnlBottom.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TextBox txtQuantity;
        protected System.Windows.Forms.TextBox txtLotBoxID;
        protected System.Windows.Forms.Button btnChange;
        protected System.Windows.Forms.TextBox txtDeviceID;
        protected System.Windows.Forms.TextBox txtPONumber;
        protected System.Windows.Forms.CheckBox chkSignal;
        protected System.Windows.Forms.CheckBox chkResistance;
        protected System.Windows.Forms.CheckBox chkNoise;
        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.TextBox txtDeviceName;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox txtAQLResult;
        protected System.Windows.Forms.Label lblAQLResult;
        protected System.Windows.Forms.TextBox txtAQLRef;
        protected System.Windows.Forms.Label lblAQLRef;
    }
}
