namespace Desktop.Forms.Trial
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.barcodeScannerTextBoxUtility1 = new Utilites.BarcodeScannerTextBoxUtility();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTransport = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJigIndex = new System.Windows.Forms.TextBox();
            this.lblStation = new System.Windows.Forms.Label();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.chkCalled = new System.Windows.Forms.CheckBox();
            this.cbFuncName = new System.Windows.Forms.ComboBox();
            this.txtMemo = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lotboxFukuda4 = new Desktop.Forms.Trial.Controls.LotboxFukuda();
            this.lotboxFukuda3 = new Desktop.Forms.Trial.Controls.LotboxFukuda();
            this.lotboxFukuda2 = new Desktop.Forms.Trial.Controls.LotboxFukuda();
            this.lotboxFukuda1 = new Desktop.Forms.Trial.Controls.LotboxFukuda();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout(); 
            // 
            // pnlBottom
            // 
            this.pnlBottom.Location = new System.Drawing.Point(0, 498);
            this.pnlBottom.Size = new System.Drawing.Size(1134, 54); 
            // 
            // pnlTop
            // 
            this.pnlTop.Size = new System.Drawing.Size(1134, 54);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tabControl1);
            this.pnlMain.Size = new System.Drawing.Size(1134, 444);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(447, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // barcodeScannerTextBoxUtility1
            // 
            this.barcodeScannerTextBoxUtility1.Interval = 1000;
            this.barcodeScannerTextBoxUtility1.TextBox = null;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1130, 440);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtBarcode);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtTransport);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtJigIndex);
            this.tabPage1.Controls.Add(this.lblStation);
            this.tabPage1.Controls.Add(this.txtStation);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.chkCalled);
            this.tabPage1.Controls.Add(this.cbFuncName);
            this.tabPage1.Controls.Add(this.txtMemo);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1122, 409);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtBarcode
            // 
            this.txtBarcode.Location = new System.Drawing.Point(746, 37);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(261, 24);
            this.txtBarcode.TabIndex = 25;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(504, 187);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 33);
            this.button4.TabIndex = 24;
            this.button4.Text = "Set";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 18);
            this.label2.TabIndex = 23;
            this.label2.Text = "Transport";
            // 
            // txtTransport
            // 
            this.txtTransport.Location = new System.Drawing.Point(610, 157);
            this.txtTransport.Name = "txtTransport";
            this.txtTransport.Size = new System.Drawing.Size(100, 24);
            this.txtTransport.TabIndex = 22;
            this.txtTransport.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 21;
            this.label1.Text = "Jig Index";
            // 
            // txtJigIndex
            // 
            this.txtJigIndex.Location = new System.Drawing.Point(504, 157);
            this.txtJigIndex.Name = "txtJigIndex";
            this.txtJigIndex.Size = new System.Drawing.Size(100, 24);
            this.txtJigIndex.TabIndex = 20;
            this.txtJigIndex.Text = "1";
            // 
            // lblStation
            // 
            this.lblStation.AutoSize = true;
            this.lblStation.Location = new System.Drawing.Point(398, 136);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(54, 18);
            this.lblStation.TabIndex = 19;
            this.lblStation.Text = "Station";
            // 
            // txtStation
            // 
            this.txtStation.Location = new System.Drawing.Point(398, 157);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(100, 24);
            this.txtStation.TabIndex = 18;
            this.txtStation.Text = "1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(398, 187);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 33);
            this.button3.TabIndex = 17;
            this.button3.Text = "Set";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // chkCalled
            // 
            this.chkCalled.AutoSize = true;
            this.chkCalled.Location = new System.Drawing.Point(398, 89);
            this.chkCalled.Name = "chkCalled";
            this.chkCalled.Size = new System.Drawing.Size(104, 22);
            this.chkCalled.TabIndex = 16;
            this.chkCalled.Text = "checkBox1";
            this.chkCalled.UseVisualStyleBackColor = true;
            // 
            // cbFuncName
            // 
            this.cbFuncName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFuncName.FormattingEnabled = true;
            this.cbFuncName.Items.AddRange(new object[] {
            "Function_A",
            "Function_B",
            "Function_C"});
            this.cbFuncName.Location = new System.Drawing.Point(398, 57);
            this.cbFuncName.Name = "cbFuncName";
            this.cbFuncName.Size = new System.Drawing.Size(252, 26);
            this.cbFuncName.TabIndex = 15;
            // 
            // txtMemo
            // 
            this.txtMemo.Location = new System.Drawing.Point(6, 11);
            this.txtMemo.Multiline = true;
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMemo.Size = new System.Drawing.Size(386, 256);
            this.txtMemo.TabIndex = 14;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(398, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 13;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(770, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lotboxFukuda4);
            this.groupBox1.Controls.Add(this.lotboxFukuda3);
            this.groupBox1.Controls.Add(this.lotboxFukuda2);
            this.groupBox1.Controls.Add(this.lotboxFukuda1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 372);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Stations ";
            // 
            // lotboxFukuda4
            // 
            this.lotboxFukuda4.BackColor = System.Drawing.SystemColors.Control;
            this.lotboxFukuda4.Dock = System.Windows.Forms.DockStyle.Left;
            this.lotboxFukuda4.JigAvalailabe = null;
            this.lotboxFukuda4.Location = new System.Drawing.Point(566, 20);
            this.lotboxFukuda4.LotBoxState = Desktop.Forms.Trial.Controls.LotBoxState.Netral;
            this.lotboxFukuda4.Name = "lotboxFukuda4";
            this.lotboxFukuda4.Size = new System.Drawing.Size(210, 349);
            this.lotboxFukuda4.Station = 4;
            this.lotboxFukuda4.TabIndex = 4;
            // 
            // lotboxFukuda3
            // 
            this.lotboxFukuda3.BackColor = System.Drawing.SystemColors.Control;
            this.lotboxFukuda3.Dock = System.Windows.Forms.DockStyle.Left;
            this.lotboxFukuda3.JigAvalailabe = null;
            this.lotboxFukuda3.Location = new System.Drawing.Point(356, 20);
            this.lotboxFukuda3.LotBoxState = Desktop.Forms.Trial.Controls.LotBoxState.Netral;
            this.lotboxFukuda3.Name = "lotboxFukuda3";
            this.lotboxFukuda3.Size = new System.Drawing.Size(210, 349);
            this.lotboxFukuda3.Station = 3;
            this.lotboxFukuda3.TabIndex = 3;
            // 
            // lotboxFukuda2
            // 
            this.lotboxFukuda2.BackColor = System.Drawing.SystemColors.Control;
            this.lotboxFukuda2.Dock = System.Windows.Forms.DockStyle.Left;
            this.lotboxFukuda2.JigAvalailabe = null;
            this.lotboxFukuda2.Location = new System.Drawing.Point(169, 20);
            this.lotboxFukuda2.LotBoxState = Desktop.Forms.Trial.Controls.LotBoxState.Netral;
            this.lotboxFukuda2.Name = "lotboxFukuda2";
            this.lotboxFukuda2.Size = new System.Drawing.Size(187, 349);
            this.lotboxFukuda2.Station = 2;
            this.lotboxFukuda2.TabIndex = 2;
            // 
            // lotboxFukuda1
            // 
            this.lotboxFukuda1.BackColor = System.Drawing.SystemColors.Control;
            this.lotboxFukuda1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lotboxFukuda1.JigAvalailabe = null;
            this.lotboxFukuda1.Location = new System.Drawing.Point(3, 20);
            this.lotboxFukuda1.LotBoxState = Desktop.Forms.Trial.Controls.LotBoxState.Netral;
            this.lotboxFukuda1.Name = "lotboxFukuda1";
            this.lotboxFukuda1.Size = new System.Drawing.Size(166, 349);
            this.lotboxFukuda1.Station = 1;
            this.lotboxFukuda1.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1122, 409);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 370);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 34);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "label4";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 552);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.pnlBottom, 0);
            this.Controls.SetChildIndex(this.pnlTop, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private Utilites.BarcodeScannerTextBoxUtility barcodeScannerTextBoxUtility1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTransport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJigIndex;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.TextBox txtStation;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox chkCalled;
        private System.Windows.Forms.ComboBox cbFuncName;
        private System.Windows.Forms.TextBox txtMemo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.LotboxFukuda lotboxFukuda1;
        private Controls.LotboxFukuda lotboxFukuda4;
        private Controls.LotboxFukuda lotboxFukuda3;
        private Controls.LotboxFukuda lotboxFukuda2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}