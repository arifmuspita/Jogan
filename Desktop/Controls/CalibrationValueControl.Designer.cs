namespace Desktop.Controls
{
    partial class CalibrationValueControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalibrationValueControl));
            this.gbCalVal = new System.Windows.Forms.GroupBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.chkCS = new System.Windows.Forms.CheckBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gbCalVal.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCalVal
            // 
            this.gbCalVal.Controls.Add(this.chkCS);
            this.gbCalVal.Controls.Add(this.txtValue);
            this.gbCalVal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCalVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbCalVal.Location = new System.Drawing.Point(0, 0);
            this.gbCalVal.Name = "gbCalVal";
            this.gbCalVal.Size = new System.Drawing.Size(80, 70);
            this.gbCalVal.TabIndex = 0;
            this.gbCalVal.TabStop = false;
            this.gbCalVal.Text = " Socket 64 ";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.BackColor = System.Drawing.Color.White;
            this.txtValue.Location = new System.Drawing.Point(6, 20);
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Size = new System.Drawing.Size(68, 21);
            this.txtValue.TabIndex = 0;
            // 
            // chkCS
            // 
            this.chkCS.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkCS.FlatAppearance.BorderSize = 0;
            this.chkCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkCS.ImageIndex = 0;
            this.chkCS.ImageList = this.imageList1;
            this.chkCS.Location = new System.Drawing.Point(6, 42);
            this.chkCS.Name = "chkCS";
            this.chkCS.Size = new System.Drawing.Size(68, 25);
            this.chkCS.TabIndex = 1;
            this.chkCS.Text = "Close";
            this.chkCS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chkCS.UseVisualStyleBackColor = true;
            this.chkCS.CheckedChanged += new System.EventHandler(this.chkCS_CheckedChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Unchecked Checkbox-16.png");
            this.imageList1.Images.SetKeyName(1, "Checked Checkbox-16-2.png");
            // 
            // CalibrationValueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbCalVal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CalibrationValueControl";
            this.Size = new System.Drawing.Size(80, 70);
            this.gbCalVal.ResumeLayout(false);
            this.gbCalVal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCalVal;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.CheckBox chkCS;
        private System.Windows.Forms.ImageList imageList1;
    }
}
