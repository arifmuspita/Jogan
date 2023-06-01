namespace Desktop.Forms.Trial
{
    partial class Form8
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
            this.tmrRotary2 = new System.Windows.Forms.Timer(this.components);
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.jigCarrier3 = new Desktop.Forms.Trial.Controls.AreaLoader.JigCarrier();
            this.jigCarrier2 = new Desktop.Forms.Trial.Controls.AreaLoader.JigCarrier();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtQueue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrJig = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJigNeedCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlG8 = new System.Windows.Forms.Panel();
            this.pnlLine2 = new System.Windows.Forms.Panel();
            this.Resistance02 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.Signal02 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.Noise08 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.Noise07 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.Noise06 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.Noise05 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.pnlLine1 = new System.Windows.Forms.Panel();
            this.Resistance01 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.Signal01 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.Noise04 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.Noise03 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.Noise02 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.Noise01 = new Desktop.Forms.Trial.Controls.AreaLoader.MachineTester();
            this.tmrG8 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.pnlRak2 = new System.Windows.Forms.Panel();
            this.jigStorage2 = new Desktop.Forms.Trial.Controls.AreaLoader.JigStorage();
            this.pnlJig = new System.Windows.Forms.Panel();
            this.pnlRak1 = new System.Windows.Forms.Panel();
            this.jigStorage1 = new Desktop.Forms.Trial.Controls.AreaLoader.JigStorage();
            this.tmrDelay = new System.Windows.Forms.Timer(this.components);
            this.pnlLeft.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlLine2.SuspendLayout();
            this.pnlLine1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlRak2.SuspendLayout();
            this.pnlRak1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrRotary2
            // 
            this.tmrRotary2.Interval = 1000;
            this.tmrRotary2.Tick += new System.EventHandler(this.tmrRotary2_Tick);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLeft.Controls.Add(this.jigCarrier3);
            this.pnlLeft.Controls.Add(this.jigCarrier2);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(440, 793);
            this.pnlLeft.TabIndex = 1;
            this.pnlLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlLeft_Paint);
            // 
            // jigCarrier3
            // 
            this.jigCarrier3.EndPosition = null;
            this.jigCarrier3.IsLoaded = false;
            this.jigCarrier3.IsTested = false;
            this.jigCarrier3.JigID = "Jig ID 3";
            this.jigCarrier3.JigPosition = Desktop.Forms.Trial.Controls.AreaLoader.JigPosition.Up;
            this.jigCarrier3.Location = new System.Drawing.Point(20, 28);
            this.jigCarrier3.Name = "jigCarrier3";
            this.jigCarrier3.PONumber = "3";
            this.jigCarrier3.Size = new System.Drawing.Size(140, 140);
            this.jigCarrier3.SkipTest = false;
            this.jigCarrier3.SkipTestNoise = false;
            this.jigCarrier3.SkipTestResistance = false;
            this.jigCarrier3.SkipTestSignal = false;
            this.jigCarrier3.StartPosition = null;
            this.jigCarrier3.Status = "5";
            this.jigCarrier3.TabIndex = 2;
            this.jigCarrier3.TestDoneTime = new System.DateTime(((long)(0)));
            this.jigCarrier3.TimeInterval = 0;
            this.jigCarrier3.Visible = false;
            // 
            // jigCarrier2
            // 
            this.jigCarrier2.EndPosition = null;
            this.jigCarrier2.IsLoaded = false;
            this.jigCarrier2.IsTested = false;
            this.jigCarrier2.JigID = "Jig ID 2";
            this.jigCarrier2.JigPosition = Desktop.Forms.Trial.Controls.AreaLoader.JigPosition.Up;
            this.jigCarrier2.Location = new System.Drawing.Point(252, 321);
            this.jigCarrier2.Name = "jigCarrier2";
            this.jigCarrier2.PONumber = "3";
            this.jigCarrier2.Size = new System.Drawing.Size(140, 140);
            this.jigCarrier2.SkipTest = false;
            this.jigCarrier2.SkipTestNoise = false;
            this.jigCarrier2.SkipTestResistance = false;
            this.jigCarrier2.SkipTestSignal = false;
            this.jigCarrier2.StartPosition = null;
            this.jigCarrier2.Status = "5";
            this.jigCarrier2.TabIndex = 1;
            this.jigCarrier2.TestDoneTime = new System.DateTime(((long)(0)));
            this.jigCarrier2.TimeInterval = 0;
            this.jigCarrier2.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 793);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1782, 60);
            this.panel1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1322, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 29);
            this.button4.TabIndex = 10;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnStart);
            this.panel4.Controls.Add(this.txtQueue);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtCurrJig);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.txtJigNeedCount);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(941, 58);
            this.panel4.TabIndex = 9;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(469, 29);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtQueue
            // 
            this.txtQueue.Location = new System.Drawing.Point(469, 6);
            this.txtQueue.Name = "txtQueue";
            this.txtQueue.Size = new System.Drawing.Size(100, 22);
            this.txtQueue.TabIndex = 5;
            this.txtQueue.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Queue remaining";
            // 
            // txtCurrJig
            // 
            this.txtCurrJig.Location = new System.Drawing.Point(240, 30);
            this.txtCurrJig.Name = "txtCurrJig";
            this.txtCurrJig.Size = new System.Drawing.Size(100, 22);
            this.txtCurrJig.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Jigs on proccess";
            // 
            // txtJigNeedCount
            // 
            this.txtJigNeedCount.Location = new System.Drawing.Point(240, 5);
            this.txtJigNeedCount.Name = "txtJigNeedCount";
            this.txtJigNeedCount.Size = new System.Drawing.Size(100, 22);
            this.txtJigNeedCount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Jigs needed for available machine";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1241, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1160, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1347, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "queue remaining";
            this.label1.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1160, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.pnlG8);
            this.panel2.Controls.Add(this.pnlLine2);
            this.panel2.Controls.Add(this.pnlLine1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(640, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1142, 793);
            this.panel2.TabIndex = 3;
            // 
            // pnlG8
            // 
            this.pnlG8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlG8.Location = new System.Drawing.Point(0, 310);
            this.pnlG8.Name = "pnlG8";
            this.pnlG8.Size = new System.Drawing.Size(1140, 171);
            this.pnlG8.TabIndex = 2;
            // 
            // pnlLine2
            // 
            this.pnlLine2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLine2.Controls.Add(this.Resistance02);
            this.pnlLine2.Controls.Add(this.Signal02);
            this.pnlLine2.Controls.Add(this.Noise08);
            this.pnlLine2.Controls.Add(this.Noise07);
            this.pnlLine2.Controls.Add(this.Noise06);
            this.pnlLine2.Controls.Add(this.Noise05);
            this.pnlLine2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlLine2.Location = new System.Drawing.Point(0, 481);
            this.pnlLine2.Name = "pnlLine2";
            this.pnlLine2.Size = new System.Drawing.Size(1140, 310);
            this.pnlLine2.TabIndex = 1;
            // 
            // Resistance02
            // 
            this.Resistance02.Dock = System.Windows.Forms.DockStyle.Left;
            this.Resistance02.DockingControlInside = System.Windows.Forms.DockStyle.Top;
            this.Resistance02.IsDoneTesting = true;
            this.Resistance02.IsLoaded = false;
            this.Resistance02.JigCarrier = null;
            this.Resistance02.JigID = "";
            this.Resistance02.LineID = 2;
            this.Resistance02.Location = new System.Drawing.Point(750, 0);
            this.Resistance02.MachineCode = "T-005";
            this.Resistance02.MachineName = "Machine Resistance 8";
            this.Resistance02.MachineState = Commons.MachineState.msOn;
            this.Resistance02.MachineType = "XRESISTANCE";
            this.Resistance02.Name = "Resistance02";
            this.Resistance02.PONumber = "";
            this.Resistance02.Size = new System.Drawing.Size(150, 308);
            this.Resistance02.SkipTest = false;
            this.Resistance02.Status = "Available";
            this.Resistance02.TabIndex = 6;
            this.Resistance02.TestDoneTime = new System.DateTime(((long)(0)));
            this.Resistance02.TimeInterval = 15;
            // 
            // Signal02
            // 
            this.Signal02.Dock = System.Windows.Forms.DockStyle.Left;
            this.Signal02.DockingControlInside = System.Windows.Forms.DockStyle.Top;
            this.Signal02.IsDoneTesting = true;
            this.Signal02.IsLoaded = false;
            this.Signal02.JigCarrier = null;
            this.Signal02.JigID = "";
            this.Signal02.LineID = 2;
            this.Signal02.Location = new System.Drawing.Point(600, 0);
            this.Signal02.MachineCode = "T-003";
            this.Signal02.MachineName = "Machine Signal 2";
            this.Signal02.MachineState = Commons.MachineState.msOn;
            this.Signal02.MachineType = "SIGNAL";
            this.Signal02.Name = "Signal02";
            this.Signal02.PONumber = "";
            this.Signal02.Size = new System.Drawing.Size(150, 308);
            this.Signal02.SkipTest = false;
            this.Signal02.Status = "Available";
            this.Signal02.TabIndex = 5;
            this.Signal02.TestDoneTime = new System.DateTime(((long)(0)));
            this.Signal02.TimeInterval = 20;
            // 
            // Noise08
            // 
            this.Noise08.Dock = System.Windows.Forms.DockStyle.Left;
            this.Noise08.DockingControlInside = System.Windows.Forms.DockStyle.Top;
            this.Noise08.IsDoneTesting = true;
            this.Noise08.IsLoaded = false;
            this.Noise08.JigCarrier = null;
            this.Noise08.JigID = "";
            this.Noise08.LineID = 2;
            this.Noise08.Location = new System.Drawing.Point(450, 0);
            this.Noise08.MachineCode = "T-012";
            this.Noise08.MachineName = "Machine Noise 8";
            this.Noise08.MachineState = Commons.MachineState.msOn;
            this.Noise08.MachineType = "NOISE";
            this.Noise08.Name = "Noise08";
            this.Noise08.PONumber = "";
            this.Noise08.Size = new System.Drawing.Size(150, 308);
            this.Noise08.SkipTest = false;
            this.Noise08.Status = "Available";
            this.Noise08.TabIndex = 4;
            this.Noise08.TestDoneTime = new System.DateTime(((long)(0)));
            this.Noise08.TimeInterval = 60;
            // 
            // Noise07
            // 
            this.Noise07.Dock = System.Windows.Forms.DockStyle.Left;
            this.Noise07.DockingControlInside = System.Windows.Forms.DockStyle.Top;
            this.Noise07.IsDoneTesting = true;
            this.Noise07.IsLoaded = false;
            this.Noise07.JigCarrier = null;
            this.Noise07.JigID = "";
            this.Noise07.LineID = 2;
            this.Noise07.Location = new System.Drawing.Point(300, 0);
            this.Noise07.MachineCode = "T-011";
            this.Noise07.MachineName = "Machine Noise 7";
            this.Noise07.MachineState = Commons.MachineState.msOn;
            this.Noise07.MachineType = "NOISE";
            this.Noise07.Name = "Noise07";
            this.Noise07.PONumber = "";
            this.Noise07.Size = new System.Drawing.Size(150, 308);
            this.Noise07.SkipTest = false;
            this.Noise07.Status = "Available";
            this.Noise07.TabIndex = 3;
            this.Noise07.TestDoneTime = new System.DateTime(((long)(0)));
            this.Noise07.TimeInterval = 30;
            // 
            // Noise06
            // 
            this.Noise06.Dock = System.Windows.Forms.DockStyle.Left;
            this.Noise06.DockingControlInside = System.Windows.Forms.DockStyle.Top;
            this.Noise06.IsDoneTesting = true;
            this.Noise06.IsLoaded = false;
            this.Noise06.JigCarrier = null;
            this.Noise06.JigID = "";
            this.Noise06.LineID = 2;
            this.Noise06.Location = new System.Drawing.Point(150, 0);
            this.Noise06.MachineCode = "T-010";
            this.Noise06.MachineName = "Machine Noise 6";
            this.Noise06.MachineState = Commons.MachineState.msOn;
            this.Noise06.MachineType = "NOISE";
            this.Noise06.Name = "Noise06";
            this.Noise06.PONumber = "";
            this.Noise06.Size = new System.Drawing.Size(150, 308);
            this.Noise06.SkipTest = false;
            this.Noise06.Status = "Available";
            this.Noise06.TabIndex = 2;
            this.Noise06.TestDoneTime = new System.DateTime(((long)(0)));
            this.Noise06.TimeInterval = 30;
            // 
            // Noise05
            // 
            this.Noise05.Dock = System.Windows.Forms.DockStyle.Left;
            this.Noise05.DockingControlInside = System.Windows.Forms.DockStyle.Top;
            this.Noise05.IsDoneTesting = true;
            this.Noise05.IsLoaded = false;
            this.Noise05.JigCarrier = null;
            this.Noise05.JigID = "";
            this.Noise05.LineID = 2;
            this.Noise05.Location = new System.Drawing.Point(0, 0);
            this.Noise05.MachineCode = "T-009";
            this.Noise05.MachineName = "Machine Noise 5";
            this.Noise05.MachineState = Commons.MachineState.msOn;
            this.Noise05.MachineType = "NOISE";
            this.Noise05.Name = "Noise05";
            this.Noise05.PONumber = "";
            this.Noise05.Size = new System.Drawing.Size(150, 308);
            this.Noise05.SkipTest = false;
            this.Noise05.Status = "Available";
            this.Noise05.TabIndex = 1;
            this.Noise05.TestDoneTime = new System.DateTime(((long)(0)));
            this.Noise05.TimeInterval = 30;
            // 
            // pnlLine1
            // 
            this.pnlLine1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLine1.Controls.Add(this.Resistance01);
            this.pnlLine1.Controls.Add(this.Signal01);
            this.pnlLine1.Controls.Add(this.Noise04);
            this.pnlLine1.Controls.Add(this.Noise03);
            this.pnlLine1.Controls.Add(this.Noise02);
            this.pnlLine1.Controls.Add(this.Noise01);
            this.pnlLine1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLine1.Location = new System.Drawing.Point(0, 0);
            this.pnlLine1.Name = "pnlLine1";
            this.pnlLine1.Size = new System.Drawing.Size(1140, 310);
            this.pnlLine1.TabIndex = 0;
            // 
            // Resistance01
            // 
            this.Resistance01.Dock = System.Windows.Forms.DockStyle.Left;
            this.Resistance01.DockingControlInside = System.Windows.Forms.DockStyle.Bottom;
            this.Resistance01.IsDoneTesting = true;
            this.Resistance01.IsLoaded = false;
            this.Resistance01.JigCarrier = null;
            this.Resistance01.JigID = null;
            this.Resistance01.LineID = 1;
            this.Resistance01.Location = new System.Drawing.Point(750, 0);
            this.Resistance01.MachineCode = "T-004";
            this.Resistance01.MachineName = "Machine Resistance 1";
            this.Resistance01.MachineState = Commons.MachineState.msOn;
            this.Resistance01.MachineType = "XRESISTANCE";
            this.Resistance01.Name = "Resistance01";
            this.Resistance01.PONumber = null;
            this.Resistance01.Size = new System.Drawing.Size(150, 308);
            this.Resistance01.SkipTest = false;
            this.Resistance01.Status = "Available";
            this.Resistance01.TabIndex = 5;
            this.Resistance01.TestDoneTime = new System.DateTime(((long)(0)));
            this.Resistance01.TimeInterval = 5;
            // 
            // Signal01
            // 
            this.Signal01.Dock = System.Windows.Forms.DockStyle.Left;
            this.Signal01.DockingControlInside = System.Windows.Forms.DockStyle.Bottom;
            this.Signal01.IsDoneTesting = true;
            this.Signal01.IsLoaded = false;
            this.Signal01.JigCarrier = null;
            this.Signal01.JigID = null;
            this.Signal01.LineID = 1;
            this.Signal01.Location = new System.Drawing.Point(600, 0);
            this.Signal01.MachineCode = "T-001";
            this.Signal01.MachineName = "Machine Signal 1";
            this.Signal01.MachineState = Commons.MachineState.msOn;
            this.Signal01.MachineType = "SIGNAL";
            this.Signal01.Name = "Signal01";
            this.Signal01.PONumber = null;
            this.Signal01.Size = new System.Drawing.Size(150, 308);
            this.Signal01.SkipTest = false;
            this.Signal01.Status = "Available";
            this.Signal01.TabIndex = 4;
            this.Signal01.TestDoneTime = new System.DateTime(((long)(0)));
            this.Signal01.TimeInterval = 10;
            // 
            // Noise04
            // 
            this.Noise04.Dock = System.Windows.Forms.DockStyle.Left;
            this.Noise04.DockingControlInside = System.Windows.Forms.DockStyle.Bottom;
            this.Noise04.IsDoneTesting = true;
            this.Noise04.IsLoaded = false;
            this.Noise04.JigCarrier = null;
            this.Noise04.JigID = null;
            this.Noise04.LineID = 1;
            this.Noise04.Location = new System.Drawing.Point(450, 0);
            this.Noise04.MachineCode = "T-008";
            this.Noise04.MachineName = "Machine Noise 4";
            this.Noise04.MachineState = Commons.MachineState.msOn;
            this.Noise04.MachineType = "NOISE";
            this.Noise04.Name = "Noise04";
            this.Noise04.PONumber = null;
            this.Noise04.Size = new System.Drawing.Size(150, 308);
            this.Noise04.SkipTest = false;
            this.Noise04.Status = "Available";
            this.Noise04.TabIndex = 3;
            this.Noise04.TestDoneTime = new System.DateTime(((long)(0)));
            this.Noise04.TimeInterval = 15;
            // 
            // Noise03
            // 
            this.Noise03.Dock = System.Windows.Forms.DockStyle.Left;
            this.Noise03.DockingControlInside = System.Windows.Forms.DockStyle.Bottom;
            this.Noise03.IsDoneTesting = true;
            this.Noise03.IsLoaded = false;
            this.Noise03.JigCarrier = null;
            this.Noise03.JigID = null;
            this.Noise03.LineID = 1;
            this.Noise03.Location = new System.Drawing.Point(300, 0);
            this.Noise03.MachineCode = "T-007";
            this.Noise03.MachineName = "Machine Noise 3";
            this.Noise03.MachineState = Commons.MachineState.msOn;
            this.Noise03.MachineType = "NOISE";
            this.Noise03.Name = "Noise03";
            this.Noise03.PONumber = null;
            this.Noise03.Size = new System.Drawing.Size(150, 308);
            this.Noise03.SkipTest = false;
            this.Noise03.Status = "Available";
            this.Noise03.TabIndex = 2;
            this.Noise03.TestDoneTime = new System.DateTime(((long)(0)));
            this.Noise03.TimeInterval = 15;
            // 
            // Noise02
            // 
            this.Noise02.Dock = System.Windows.Forms.DockStyle.Left;
            this.Noise02.DockingControlInside = System.Windows.Forms.DockStyle.Bottom;
            this.Noise02.IsDoneTesting = true;
            this.Noise02.IsLoaded = false;
            this.Noise02.JigCarrier = null;
            this.Noise02.JigID = null;
            this.Noise02.LineID = 1;
            this.Noise02.Location = new System.Drawing.Point(150, 0);
            this.Noise02.MachineCode = "T-006";
            this.Noise02.MachineName = "Machine Noise 2";
            this.Noise02.MachineState = Commons.MachineState.msOn;
            this.Noise02.MachineType = "NOISE";
            this.Noise02.Name = "Noise02";
            this.Noise02.PONumber = null;
            this.Noise02.Size = new System.Drawing.Size(150, 308);
            this.Noise02.SkipTest = false;
            this.Noise02.Status = "Available";
            this.Noise02.TabIndex = 1;
            this.Noise02.TestDoneTime = new System.DateTime(((long)(0)));
            this.Noise02.TimeInterval = 15;
            // 
            // Noise01
            // 
            this.Noise01.Dock = System.Windows.Forms.DockStyle.Left;
            this.Noise01.DockingControlInside = System.Windows.Forms.DockStyle.Bottom;
            this.Noise01.IsDoneTesting = true;
            this.Noise01.IsLoaded = false;
            this.Noise01.JigCarrier = null;
            this.Noise01.JigID = "";
            this.Noise01.LineID = 1;
            this.Noise01.Location = new System.Drawing.Point(0, 0);
            this.Noise01.MachineCode = "T-002";
            this.Noise01.MachineName = "Machine Noise 1";
            this.Noise01.MachineState = Commons.MachineState.msOn;
            this.Noise01.MachineType = "NOISE";
            this.Noise01.Name = "Noise01";
            this.Noise01.PONumber = "";
            this.Noise01.Size = new System.Drawing.Size(150, 308);
            this.Noise01.SkipTest = false;
            this.Noise01.Status = "Available";
            this.Noise01.TabIndex = 0;
            this.Noise01.TestDoneTime = new System.DateTime(((long)(0)));
            this.Noise01.TimeInterval = 15;
            // 
            // tmrG8
            // 
            this.tmrG8.Interval = 1000;
            this.tmrG8.Tick += new System.EventHandler(this.tmrG8_Tick);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.pnlRak2);
            this.panel3.Controls.Add(this.pnlJig);
            this.panel3.Controls.Add(this.pnlRak1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(440, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 793);
            this.panel3.TabIndex = 4;
            // 
            // pnlRak2
            // 
            this.pnlRak2.Controls.Add(this.jigStorage2);
            this.pnlRak2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRak2.Location = new System.Drawing.Point(0, 481);
            this.pnlRak2.Name = "pnlRak2";
            this.pnlRak2.Size = new System.Drawing.Size(198, 310);
            this.pnlRak2.TabIndex = 2;
            // 
            // jigStorage2
            // 
            this.jigStorage2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jigStorage2.JigCount = 10;
            this.jigStorage2.Location = new System.Drawing.Point(0, 0);
            this.jigStorage2.Name = "jigStorage2";
            this.jigStorage2.Size = new System.Drawing.Size(198, 310);
            this.jigStorage2.TabIndex = 1;
            // 
            // pnlJig
            // 
            this.pnlJig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlJig.Location = new System.Drawing.Point(0, 310);
            this.pnlJig.Name = "pnlJig";
            this.pnlJig.Size = new System.Drawing.Size(198, 171);
            this.pnlJig.TabIndex = 1;
            // 
            // pnlRak1
            // 
            this.pnlRak1.Controls.Add(this.jigStorage1);
            this.pnlRak1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRak1.Location = new System.Drawing.Point(0, 0);
            this.pnlRak1.Name = "pnlRak1";
            this.pnlRak1.Size = new System.Drawing.Size(198, 310);
            this.pnlRak1.TabIndex = 0;
            // 
            // jigStorage1
            // 
            this.jigStorage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jigStorage1.JigCount = 10;
            this.jigStorage1.Location = new System.Drawing.Point(0, 0);
            this.jigStorage1.Name = "jigStorage1";
            this.jigStorage1.Size = new System.Drawing.Size(198, 310);
            this.jigStorage1.TabIndex = 0;
            // 
            // tmrDelay
            // 
            this.tmrDelay.Interval = 1000;
            this.tmrDelay.Tick += new System.EventHandler(this.tmrDelay_Tick);
            // 
            // Form8
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 853);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.panel1);
            this.Name = "Form8";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Area Loader Simulation";
            this.Load += new System.EventHandler(this.Form8_Load);
            this.pnlLeft.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pnlLine2.ResumeLayout(false);
            this.pnlLine1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.pnlRak2.ResumeLayout(false);
            this.pnlRak1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer tmrRotary2;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pnlLine1;
        private System.Windows.Forms.Panel pnlLine2;
        private System.Windows.Forms.Panel pnlG8;
        private Controls.AreaLoader.JigCarrier jigCarrier3;
        private Controls.AreaLoader.JigCarrier jigCarrier2;
        private Controls.AreaLoader.MachineTester Noise01;
        private Controls.AreaLoader.MachineTester Noise04;
        private Controls.AreaLoader.MachineTester Noise03;
        private Controls.AreaLoader.MachineTester Noise02;
        private Controls.AreaLoader.MachineTester Signal01;
        private Controls.AreaLoader.MachineTester Resistance01;
        private Controls.AreaLoader.MachineTester Noise05;
        private Controls.AreaLoader.MachineTester Noise08;
        private Controls.AreaLoader.MachineTester Noise07;
        private Controls.AreaLoader.MachineTester Noise06;
        private Controls.AreaLoader.MachineTester Resistance02;
        private Controls.AreaLoader.MachineTester Signal02;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer tmrG8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel pnlRak2;
        private System.Windows.Forms.Panel pnlJig;
        private System.Windows.Forms.Panel pnlRak1;
        private Controls.AreaLoader.JigStorage jigStorage1;
        private Controls.AreaLoader.JigStorage jigStorage2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtJigNeedCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCurrJig;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQueue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer tmrDelay;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button button4;
    }
}