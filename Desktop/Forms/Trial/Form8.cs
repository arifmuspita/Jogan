using DBProject.Models;
using Desktop.Forms.Trial.Controls.AreaLoader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;

namespace Desktop.Forms.Trial
{
    public partial class Form8 : Form
    {
        private int FAngle1;
        private int FAngle2;
        private int FFAngleCount;
        private int FJigCount;
        private List<Controls.AreaLoader.MachineTester> FListMachineTester;
        private List<Controls.AreaLoader.JigCarrier> FListJigCarrier;
        private List<Controls.AreaLoader.JigCarrier> FListJigCarrierOnRotary;
        private List<int> FListLeft;
        private int[] FMachineSequences = new int[3] { 0, 0, 0 };
        private JoganUtility JoganUtility;
        private bool FIsG8OnDuty;
        private int FMachineCount;
        private string FSource;
        private string FDestination;
        private JigCarrier FJigOnMove;
        private JigCarrier FJigToDispose;
        private string FJigEndPosition;
        private bool FIsExitRecursive;
        private bool FIsOneCycle;
        private int FJigEmptyOnRotary;

        public Form8()
        {
            InitializeComponent();
            FAngle1 = 0;
            FAngle2 = 90;
            FFAngleCount = 0;
            FListJigCarrier = new List<Controls.AreaLoader.JigCarrier>();
            FListJigCarrierOnRotary = new List<Controls.AreaLoader.JigCarrier>(); 
             FListMachineTester = new List<Controls.AreaLoader.MachineTester>();
            FListMachineTester.Add(Noise01);
            FListMachineTester.Add(Noise02);
            FListMachineTester.Add(Noise03);
            FListMachineTester.Add(Noise04);
            FListMachineTester.Add(Noise05);
            FListMachineTester.Add(Noise06);
            FListMachineTester.Add(Noise07);
            FListMachineTester.Add(Noise08);
            FListMachineTester.Add(Signal01);
            FListMachineTester.Add(Signal02);
            FListMachineTester.Add(Resistance01);
            FListMachineTester.Add(Resistance02);

            FListLeft = new List<int>();
            FListLeft.Add(0);
            FListLeft.Add(112);
            FListLeft.Add(225);
            FListLeft.Add(338);
            FListLeft.Add(450);
            FListLeft.Add(562);

            FJigCount = 1;

            string NetID = ConfigurationManager.AppSettings["TwinCatNetID"];
            JoganUtility = new JoganUtility(NetID);
            JoganUtility.NetID = NetID;
            //JoganUtility.AllowConnect = true;

            FIsG8OnDuty = false;
            FMachineCount = 0;
            //JoganUtility.AllowConnect = true;
            ResetBooking();
            FIsOneCycle = false;
        }

        private string CreateJigID()
        {
            string ret = "";
            if (FJigCount >= 1 && FJigCount <= 9) ret = "000";
            if (FJigCount >= 10 && FJigCount <= 99) ret = "00";
            if (FJigCount >= 100 && FJigCount <= 999) ret = "0";
            ret = ret + FJigCount.ToString();
            return ret;
        }
        private void CreateListBox(int X,int Y)
        {
            ListBox lb = new ListBox();
            lb.Left = X;
            lb.Top = Y;
            lb.Width = 0;// listBox1.Width;
            lb.Height = 0;// listBox1.Height;
            lb.Parent = this;
            lb.BringToFront();
        }

        private void MoveControl(Control AControl, int OriginX, int OriginY, int Radius, int Angle)
        {
            double angle = Math.PI * Angle / 180.0;
            int X = (int)(OriginX + Math.Cos(angle) * Radius);
            if (X < 0) X = X * -1;
            int Y = (int)(OriginY + Math.Sin(angle) * Radius);
            AControl.Left = X;
            AControl.Top = Y;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            FFAngleCount++;
            if (FFAngleCount == 90 / 5) { tmrRotary2.Enabled = false; }
            else
            {
                MoveControl(jigCarrier2, 20, 230, 230, FAngle1);
                MoveControl(jigCarrier3, 20, 230, 230, FAngle2);
                FAngle1 = FAngle1 - 5;
                FAngle2 = FAngle2 + 5;

                tmrRotary2.Enabled = false;
            }
            //if (FAngle <0 ) FAngle = 360; 
        } 

        private void pnlLeft_Paint(object sender, PaintEventArgs e)
        {
            int radius = 480;
            int dim = 116;
            int y = (pnlLeft.Height / 2) - (radius / 2);
            e.Graphics.DrawEllipse(Pens.Red, -1 * (radius / 2), y, radius, radius);

            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
                10, y + radius - (dim / 2), dim, dim);
            e.Graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
            rectangle = new System.Drawing.Rectangle(
                10, y - (dim / 2), dim, dim);
            e.Graphics.DrawRectangle(System.Drawing.Pens.Green, rectangle);
            rectangle = new System.Drawing.Rectangle(
                (radius/2) - (dim / 2), (pnlLeft.Height / 2)-(dim/2), dim, dim);
            e.Graphics.DrawRectangle(System.Drawing.Pens.Blue, rectangle);
            //jigCarrier1.Top = y - (dim / 2)  +2;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            CreateJigCarrier();
        }


        private void RotateJig()
        {
            for (int i = 0; i <= FListJigCarrierOnRotary.Count - 1; i++)
            {
                JigCarrier jig = FListJigCarrierOnRotary[i];
                switch (jig.JigPosition)
                {
                    case JigPosition.Right:
                        jig.JigPosition = JigPosition.Up;
                        if (jig.IsTested)
                        {
                            jig.TimeInterval = 5;
                            jig.Start();
                        }
                        break;
                    case JigPosition.Up:
                        jig.IsTested = false;
                        jig.JigPosition = JigPosition.Left;
                        break;
                    case JigPosition.Left:
                        jig.JigPosition = JigPosition.Bottom;
                        jig.IsLoaded = false;
                        if (CheckBookingLoadingJigCarrierExist())
                        {
                            jig.TimeInterval = 5;
                            jig.Start();
                        }
                        break;
                    case JigPosition.Bottom:
                        jig.JigPosition = JigPosition.Right;
                       
                        break;
                }
                
            }
        }
        private void CreateJigCarrier()
        {
            JigStorage jst = GetJigStorage();
            jst.GetJig();
            JigCarrier jig = new JigCarrier();
            jig.Name = "JigCarrier" + FJigCount;
            jig.PONumber = "";
            jig.TimeInterval = 5;
            //jig.Left = 16;
            //jig.Top = 500;
            //jig.Height = 115;
            jig.Height = 120;
            jig.Width = 105;
            jig.StartPosition = "ROTARY2";
            
            jig.JigID = "JigID: "+ CreateJigID();
            //jig.OnProccessFinish += new EventOnProccessFinish(OnProccessFinish);
            jig.Parent = pnlJig;
            bool Wait = false;
            tmrRotary2.Enabled = false;
            WaitSynchronous(delegate () { Wait=!Wait; return Wait; }); tmrRotary2.Enabled = true;
            //tmrDelay.Enabled = false;
            //Thread.Sleep(1000);
            jig.JigPosition = JigPosition.Right;
            jig.Parent = pnlLeft;
            FJigCount++;
            FListJigCarrier.Insert(0, jig);
            FListJigCarrierOnRotary.Add(jig);
            //jig.Start();
        }

        private void ResetBooking()
        {
            using (var db = new DBProjectEntities())
            {
                  db.Database.ExecuteSqlCommand("update T_Booking_Station set Jig_ID = 'EMPTY', Status = 'LoadingJigCarrier'");
            }
        }

        private void OnProccessFinish(object sender, bool IsFinish)
        {
            if (IsFinish)
            {
                //JigCarrier jig = (JigCarrier)sender;
                //jig.Left = 189;
                //jig.Top = 261; 
            }
        }
        private void WaitSynchronous(JoganWaitAction AJoganWaitAction)
        {
            //Thread th = new Thread()
            while (AJoganWaitAction())
            {
               Application.DoEvents();
                Thread.Sleep(1000);
            }
        }
        private bool CheckMachineTestDone(M_MACHINE_TESTER m)
        {
            bool ret = false;
            Controls.AreaLoader.MachineTester mt = FListMachineTester.Where(x => x.MachineCode == m.Machine_ID).FirstOrDefault();
            if (mt != null)
            {
                ret = mt.IsDoneTesting;
                if (ret) mt.TestDoneTime = DateTime.Now;
            }
            return ret;
        }
        private bool CheckMachineAvailable(M_MACHINE_TESTER m)
        {
            bool ret = false;
            Controls.AreaLoader.MachineTester mt = FListMachineTester.Where(x => x.MachineCode == m.Machine_ID).FirstOrDefault();
            if (mt != null)
            {
                ret = !mt.IsLoaded;
            }
            return ret;
        }
        private void CommandG8ToMoveJigFromTo(JigCarrier AJigCarrier, string Source, string Destination)
        {
            FIsG8OnDuty = true;
            FSource = Source;
            FDestination = Destination;
            //send data to plc Source and Destination for G8
            //send data proc here
            if (Source== "ROTARY2" && Destination!= "ROTARY2")
            {
                AJigCarrier.Left = 0;
                AJigCarrier.Top = (pnlG8.Height - AJigCarrier.Height) / 2;
                //FMachineCount = 0;
                AJigCarrier.Parent = pnlG8;
                
            }
            if (Source != "ROTARY2" && Destination == "ROTARY2")
            {
                //FMachineCount = 6;
                AJigCarrier.Visible = true;
            }
            if (Source != "ROTARY2" && Destination != "ROTARY2")
            {
                //AJigCarrier.JigPosition = JigPosition.Middle;
                AJigCarrier.Visible = true;
            }
           tmrG8.Enabled = true;
            WaitSynchronous(delegate ()
            {
                return
                //wait until G8 finish move jig carrier
                FIsG8OnDuty;
            });
        } 
        private bool CheckJigCarrierFinish(JigPosition AJigPosition )
        {
            bool ret = true;
            JigCarrier jc = FListJigCarrierOnRotary.Where(x => x.JigPosition == AJigPosition).FirstOrDefault();
            if (jc != null)
            {
                switch (AJigPosition)
                {
                    case JigPosition.Up: ret = !jc.IsLoaded;break;
                    //case JigPosition.Bottom: ret = !jc.IsLoaded;break;
                }
            }
                //ret = !jc.IsLoaded;
            //JigCarrier jc = FListJigCarrier.Where(x => x.JigPosition == AJigPosition).FirstOrDefault();
            //if (jc != null)
            //{
            //    switch (AJigPosition)
            //    {
            //        case JigPosition.Middle:
            //            jc.Left = 15;
            //            jc.Top = 23;
            //            jc.TimeInterval = 15;
            //            jc.JigPosition = JigPosition.Up;
            //            jc.Start();
            //            break;
            //        case JigPosition.Up:
            //            ret = !jc.IsLoaded;
            //            if (ret )
            //            {
            //                FJigToDispose = jc;
            //                //pnlLeft.Controls.Remove(jc);
            //                //FListJigCarrier.Remove(jc);
            //                //jc.Dispose();
            //            }
            //            break;
            //    }
            //}
            return ret;
        }
        private bool CheckIfMachineDestinationAvailable(JigCarrier AJigCarrier, T_BOOKING_STATION ARef=null)
        {
            bool ret = true;
            using (var db = new DBProjectEntities())
            {
                T_BOOKING_STATION tbs = ARef;
                if (tbs == null)
                    tbs= db.Database.SqlQuery<T_BOOKING_STATION>("select * from T_BOOKING_STATION where ID= (select min(id) from T_BOOKING_STATION where jig_id='EMPTY' and Status='LoadingJigCarrier')").FirstOrDefault();
                if (tbs != null)
                { 
                    M_MACHINE_TESTER m = null;
                    int noisenumber = tbs.Noise_Room_Number;
                    int signalnumber = tbs.Signal_Room_Number;
                    int resistancenumber = tbs.Resistance_Room_Number;
                    if (noisenumber > 0)
                    {
                        m = JoganUtility.GetMachine("NOISE", noisenumber);
                    }
                    else if (noisenumber == -1)  //-1 mean on the form, noise test was not checked and machine on
                    {
                        //get noise machine available from line
                        //m = JoganUtility.GetMachine("SIGNAL", signalnumber);
                        //if (!CheckMachineAvailable(m))
                        //{
                        //    AJigCarrier.SkipTestNoise = true;
                        //    Controls.AreaLoader.MachineTester mt01 = FListMachineTester.Where(x => !x.JigCarrier.SkipTestNoise && x.MachineType == "NOISE").OrderBy(x => x.LineID).FirstOrDefault();
                        //    //Controls.AreaLoader.MachineTester mt01 = newlist.Where(x => x.JigCarrier != null).FirstOrDefault();
                        //}
                    }
                    AJigCarrier.EndPosition = m.Machine_ID;
                    AJigCarrier.PONumber = tbs.PO_Number;
                    FMachineSequences[0] = noisenumber;
                    if (signalnumber == -1)
                    {
                        signalnumber = -1;
                        //if Signal Machine 1 off then use signalnumber = 2;
                        //if Signal Machine 2 off then use signalnumber = 1;
                    }
                    FMachineSequences[1] = signalnumber;
                    if (resistancenumber == -1)
                    {
                        resistancenumber = -1;
                        //if Resistance Machine 1 off then use resistancenumber = 2;
                        //if Resistance Machine 2 off then use resistancenumber = 1;
                    }
                    FMachineSequences[2] = resistancenumber;

                    if (m != null)
                    {
                        ret = CheckMachineTestDone(m);
                        //from rotary 2
                        if (ret)
                        {
                            ret = CheckMachineAvailable(m);
                            if (ret)
                            {

                                AJigCarrier.Status = "";

                                //CommandG8ToMoveJigFromTo(AJigCarrier, "ROTARY2", m.Machine_ID);
                            } else
                            {
                                AJigCarrier.Status = "Waiting " + m.Machine_ID + " available...";
                                FIsExitRecursive = false;
                                PrepareGotoNextMachine(AJigCarrier, 0, FMachineSequences);
                                FIsExitRecursive = false;
                            }
                            //if (!ret) PrepareGotoNextMachine(0, FMachineSequences);
                            //if (CheckMachineAvailable(m))
                            //{
                            //    AJigCarrier.Left = 189;
                            //    AJigCarrier.Top = 261;
                            //    CheckJigCarrierFinish(JigPosition.Up);
                            //    if (CheckJigCarrierFinish(JigPosition.Up))
                            //    {

                            //    }
                            //    //if (CheckJigCarrierFinish())
                            //    //CommandG8ToMoveJigFromTo(AJigCarrier,"ROTARY2", m.Machine_ID);
                            //}
                            //else
                            //{
                            //    //PrepareGotoNextMachine(0, FMachineSequences);
                            //}
                        } else { AJigCarrier.Status = "Waiting " + m.Machine_ID + " available..."; }
                    }
                } else
                {
                    //AJigCarrier.EndPosition = "";
                }
            }
            return ret;
        }
        private void PrepareGotoNextMachine(JigCarrier AJigCarrier,int StartIndex, int[] MachineSequences)
        {
            if (FIsExitRecursive) return;
            int index = -1;
            M_MACHINE_TESTER m1 = null;
            M_MACHINE_TESTER m2 = null;
            string MachineType = JoganUtility.GetMachineType(StartIndex);
            int MachineNumber = MachineSequences[StartIndex];
            Controls.AreaLoader.MachineTester mt01 = null;
            using (var db = new DBProjectEntities())
            {
                m1 = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == MachineType && x.Machine_Number == MachineNumber).FirstOrDefault();
                switch (StartIndex)
                {
                    //noise machine
                    case 0:
                        if (!CheckMachineTestDone(m1)) {
                            mt01 = GetMachineTester(m1.Machine_ID);
                            mt01.Status = "Waiting " + m1.Machine_ID + "...";
                            FIsExitRecursive = true; return;
                        }
                        else
                        {
                            if (MachineSequences[1] < 1 && MachineSequences[2] < 1)
                            {
                                FIsExitRecursive = true;
                                mt01 = GetMachineTester(m1.Machine_ID);
                                JigCarrier jig = mt01.JigCarrier;
                                mt01.JigCarrier = null;
                                jig.StartPosition = m1.Machine_ID;
                                jig.EndPosition = "ROTARY2";
                                FJigOnMove = jig;
                                jig.IsTested = true;
                                jig.TestDoneTime = DateTime.Now;
                                CommandG8ToMoveJigFromTo(jig, m1.Machine_ID, "ROTARY2"); //just test noise
                            }
                            else
                            {
                                index = 1;
                                //if (index < 1) index = 2;
                                if (MachineSequences[index] < 1) index = 2;
                                MachineType = JoganUtility.GetMachineType(index);
                                MachineNumber = MachineSequences[index];
                                m2 = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == MachineType && x.Machine_Number == MachineNumber).FirstOrDefault();
                                if (!CheckMachineTestDone(m2)) {
                                    if (MachineSequences[index-1] > 0)
                                    {
                                        MachineType = JoganUtility.GetMachineType(index - 1);
                                        MachineNumber = MachineSequences[index - 1];
                                        m1 = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == MachineType && x.Machine_Number == MachineNumber).FirstOrDefault();
                                        mt01 = GetMachineTester(m1.Machine_ID);
                                        mt01.Status = "Waiting " + m2.Machine_ID + "...";
                                    }
                                    FIsExitRecursive = true; return;
                                }
                                else
                                {
                                    if (CheckMachineAvailable(m2))
                                    {
                                        FIsExitRecursive = true;
                                        mt01 = GetMachineTester(m1.Machine_ID);
                                        JigCarrier jig = mt01.JigCarrier;
                                        mt01.JigCarrier = null;
                                        jig.StartPosition = m1.Machine_ID;
                                        jig.EndPosition = m2.Machine_ID;
                                        FJigOnMove = jig;
                                        jig.IsTested = true;
                                        jig.TestDoneTime = DateTime.Now;
                                        CommandG8ToMoveJigFromTo(jig, m1.Machine_ID, m2.Machine_ID); //just test noise
                                    }
                                    else
                                    {
                                        PrepareGotoNextMachine(AJigCarrier, index, MachineSequences);
                                    }
                                }
                            }
                        }
                        break;
                    //signal machine
                    case 1:
                        if (!CheckMachineTestDone(m1))
                        {
                            if (MachineSequences[0] > 0)
                            {
                                MachineType = JoganUtility.GetMachineType(0);
                                MachineNumber = MachineSequences[0];
                                m1 = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == MachineType && x.Machine_Number == MachineNumber).FirstOrDefault();
                                mt01 = GetMachineTester(m1.Machine_ID);
                                mt01.Status = "Waiting " + m1.Machine_ID + "...";
                            }
                            FIsExitRecursive = true; return;
                        }
                        else
                        {
                            if (MachineSequences[2] < 1)
                            {
                                FIsExitRecursive = true;
                                Controls.AreaLoader.MachineTester mt = GetMachineTester(m1.Machine_ID);
                                JigCarrier jig = mt.JigCarrier;
                                mt.JigCarrier = null;
                                jig.StartPosition = m1.Machine_ID;
                                jig.EndPosition = "ROTARY2";
                                FJigOnMove = jig;
                                jig.IsTested = true;
                                jig.TestDoneTime = DateTime.Now;
                                CommandG8ToMoveJigFromTo(jig, m1.Machine_ID, "ROTARY2"); //just test noise && signal
                            }
                            else
                            {
                                index = 2;
                                MachineType = JoganUtility.GetMachineType(index);
                                MachineNumber = MachineSequences[index];
                                m2 = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == MachineType && x.Machine_Number == MachineNumber).FirstOrDefault();
                                if (!CheckMachineTestDone(m2))
                                {
                                    if (MachineSequences[1] > 0)
                                    {
                                        MachineType = JoganUtility.GetMachineType(1);
                                        MachineNumber = MachineSequences[1];
                                        m1 = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == MachineType && x.Machine_Number == MachineNumber).FirstOrDefault();
                                        mt01 = GetMachineTester(m1.Machine_ID);
                                        mt01.Status = "Waiting " + m2.Machine_ID + "...";
                                    }
                                    FIsExitRecursive = true; return;
                                }
                                else
                                {
                                    if (CheckMachineAvailable(m2))
                                    {
                                        FIsExitRecursive = true;
                                        Controls.AreaLoader.MachineTester mt = GetMachineTester(m1.Machine_ID);
                                        JigCarrier jig = mt.JigCarrier;
                                        mt.JigCarrier = null;
                                        jig.StartPosition = m1.Machine_ID;
                                        jig.EndPosition = m2.Machine_ID;
                                        FJigOnMove = jig;
                                        CommandG8ToMoveJigFromTo(jig, m1.Machine_ID, m2.Machine_ID); //just test noise
                                    }
                                    else
                                    {
                                        PrepareGotoNextMachine(AJigCarrier, index, MachineSequences);
                                    }
                                }
                            }
                        }
                        break;
                    //resistance machine
                    case 2:
                        if (CheckMachineTestDone(m1))
                        {
                            FIsExitRecursive = true;
                            FIsExitRecursive = true;
                            Controls.AreaLoader.MachineTester mt = GetMachineTester(m1.Machine_ID);
                            JigCarrier jig = mt.JigCarrier;
                            mt.JigCarrier = null;
                            jig.StartPosition = m1.Machine_ID;
                            jig.EndPosition = "ROTARY2";
                            FJigOnMove = jig;
                            jig.IsTested = true;
                            jig.TestDoneTime = DateTime.Now;
                            CommandG8ToMoveJigFromTo(jig, m1.Machine_ID, "ROTARY2"); //just test noise
                        } else
                        {
                            if (MachineSequences[1] > 0)
                            {
                                MachineType = JoganUtility.GetMachineType(1);
                                MachineNumber = MachineSequences[1];
                                m1 = db.M_MACHINE_TESTERS.Where(x => x.Machines_Type == MachineType && x.Machine_Number == MachineNumber).FirstOrDefault();
                                mt01 = GetMachineTester(m1.Machine_ID);
                                mt01.Status = "Waiting " + m1.Machine_ID + "...";
                            }
                        }
                        break;
                }
            }
        }
        private Trial.Controls.AreaLoader.MachineTester GetMachineTester(string ACode)
        {
            Trial.Controls.AreaLoader.MachineTester ret = FListMachineTester.Where(x => x.MachineCode == ACode).FirstOrDefault();
            
            return ret;
        }
        private int GetMachineTesterPosition(string ACode)
        {
            int ret = 0;
            Trial.Controls.AreaLoader.MachineTester mt = GetMachineTester(ACode);
            if (mt != null)
            {
                ret = mt.Left;
            }
            return ret;
        }
        private JigCarrier GetJigCarrier(string AEndPosition)
        {
            return FListJigCarrier.Where(x => x.EndPosition == AEndPosition).FirstOrDefault();
        }
        private bool CheckBookingLoadingJigCarrierExist()
        {
            bool ret = false;
            using (var db = new DBProjectEntities())
            {
                int cch = db.T_BOOKING_STATIONS.Where(x => x.Status == "LoadingJigCarrier").Count();
                txtQueue.Text = cch.ToString();
                ret = cch > 0;
            }
            return ret;
        }
        private void MoveJigWhenLoadingJigCarrierEnd()
        {
            var newlist = FListMachineTester.Where(x => x.JigCarrier != null && x.MachineState == Commons.MachineState.msOn && x.IsDoneTesting).OrderBy(x => x.LineID).ThenBy(x => x.MachineType).ThenBy(x => x.TestDoneTime).ToList();
            //Controls.AreaLoader.MachineTester mt01 = newlist.Where(x => x.JigCarrier!=null && x.IsDoneTesting && x.MachineType == "NOISE").OrderBy(x => x.LineID).ThenBy(x=>x.TestDoneTime).FirstOrDefault();
            Controls.AreaLoader.MachineTester mt01 = newlist.Where(x => x.JigCarrier != null).FirstOrDefault();
            M_MACHINE_TESTER m = null;
            T_BOOKING_STATION tbs = null;
            int noisenum = -99;
            int signalnum = -99;
            int resistancenum = -99;
            //M_BOOKING_STATION mbs = null;
            if (mt01 != null)
            {
                using (var db = new DBProjectEntities())
                {
                    tbs = db.T_BOOKING_STATIONS.Where(x => x.Jig_ID == mt01.JigID && x.Status == "Testing").FirstOrDefault();
                    noisenum = tbs.Noise_Room_Number;
                    signalnum = tbs.Signal_Room_Number;
                    resistancenum = tbs.Resistance_Room_Number;
                }
                m = JoganUtility.GetMachine(mt01.MachineCode);
                switch (mt01.MachineType)
                {
                    case "NOISE":
                        switch (mt01.LineID)
                        {
                            case 0:
                                if (m.Machine_Number >= 1 && m.Machine_Number <= 4) PrepareGotoNextMachine(mt01.JigCarrier, 0, new int[3] { noisenum < 1 ? noisenum : m.Machine_Number, signalnum < 1 ? signalnum : 1, resistancenum < 1 ? resistancenum : 1 });
                                if (m.Machine_Number >= 5 && m.Machine_Number <= 8) PrepareGotoNextMachine(mt01.JigCarrier, 0, new int[3] { noisenum < 1 ? noisenum : m.Machine_Number, signalnum < 1 ? signalnum : 1, resistancenum < 1 ? resistancenum : 1 });
                                break;
                            case 1:
                                //signalnum=signalnum < 1 ? -1 : signalnum;
                                PrepareGotoNextMachine(mt01.JigCarrier, 0, new int[3] { noisenum < 1 ? noisenum : m.Machine_Number, signalnum, resistancenum   });
                                break;
                            case 2:
                                PrepareGotoNextMachine(mt01.JigCarrier, 0, new int[3] { noisenum < 1 ? noisenum : m.Machine_Number, signalnum , resistancenum });
                                break;
                        }
                        break;
                    case "SIGNAL":
                        switch (mt01.LineID)
                        {
                            case 0:
                                if (m.Machine_Number == 1) PrepareGotoNextMachine(mt01.JigCarrier, 1, new int[3] { -1, m.Machine_Number, resistancenum });// < 1 ? resistancenum : 1 });
                                if (m.Machine_Number == 2) PrepareGotoNextMachine(mt01.JigCarrier, 1, new int[3] { -1, m.Machine_Number, resistancenum });//< 1 ? resistancenum : 2 });
                                break;
                            case 1:
                                PrepareGotoNextMachine(mt01.JigCarrier, 1, new int[3] { -1, m.Machine_Number, resistancenum });//< 1 ? resistancenum : 1 });
                                break;
                            case 2:
                                PrepareGotoNextMachine(mt01.JigCarrier, 1, new int[3] { -1, m.Machine_Number, resistancenum });// < 1 ? resistancenum : 2 });
                                break;
                        }
                        break;
                    case "XRESISTANCE":
                        switch (mt01.LineID)
                        {
                            case 0:
                                if (m.Machine_Number == 1) PrepareGotoNextMachine(mt01.JigCarrier, 2, new int[3] { -1, -1, resistancenum });//< 1 ? resistancenum : 1 });
                                if (m.Machine_Number == 2) PrepareGotoNextMachine(mt01.JigCarrier, 2, new int[3] { -1, -1, resistancenum });//< 1 ? resistancenum : 2 });
                                break;
                            case 1:
                                PrepareGotoNextMachine(mt01.JigCarrier, 2, new int[3] { -1, -1, resistancenum });// < 1 ? resistancenum : 1 });
                                break;
                            case 2:
                                PrepareGotoNextMachine(mt01.JigCarrier, 2, new int[3] { -1, -1, resistancenum });// < 1 ? resistancenum : 2 });
                                break;
                        }
                        break;
                }
            }
        }
        private JigStorage GetJigStorage()
        {
            JigStorage jst = null;
            if (!jigStorage1.IsStorageEmpty()) { jst = jigStorage1; } else 
            if (!jigStorage2.IsStorageEmpty()) jst = jigStorage2;
            return jst;
        }
        private int GetJigsNeeded()
        {
            int cch = 0;
            if ( CheckBookingLoadingJigCarrierExist()) {
                cch = FListMachineTester.Where(x => x.MachineState == Commons.MachineState.msOn).Count() + 3;
            } else
            {
                cch = FListMachineTester.Where(x => x.JigCarrier != null).Count() + 3; 
            }
            return cch;
        }
        private void MoveJigToStorage()
        {
            JigStorage js = null;
            if (!jigStorage1.IsStorageFull()) { js = jigStorage1; }
            else
                                    if (!jigStorage2.IsStorageFull()) { js = jigStorage2; }
            JigCarrier jc = FListJigCarrierOnRotary[0];
            if (jc != null)
            {
                FListJigCarrierOnRotary.RemoveAt(0);
                FListJigCarrier.Remove(jc);
                //jc.Parent = pnlJig;
                //pnlLeft.Controls.Remove(jc);
                tmrRotary2.Enabled = false;
               
                jc.Parent = pnlJig;
                js.SetJig();
                bool Wait = false;
                tmrRotary2.Enabled = false;
                WaitSynchronous(delegate () { Wait = !Wait; return Wait; }); tmrRotary2.Enabled = true;
                pnlJig.Controls.Remove(jc);
            }
        }
        private void MoveJigFromStorage()
        {
            JigStorage js = null;
            if (!jigStorage1.IsStorageFull()) { js = jigStorage1; }
            else
                                    if (!jigStorage2.IsStorageFull()) { js = jigStorage2; }
            JigCarrier jc = FListJigCarrierOnRotary[0];
            if (jc != null)
            {
                FListJigCarrierOnRotary.RemoveAt(0);
                FListJigCarrier.Remove(jc);
                jc.Parent = pnlJig;
                //pnlLeft.Controls.Remove(jc);
                FWait = true;
                tmrRotary2.Enabled = false;
                WaitSynchronous(delegate () { tmrDelay.Enabled = true; return FWait; });
                tmrRotary2.Enabled = true;
                js.SetJig();
                pnlJig.Controls.Remove(jc);
            }
        }
        private void tmrRotary2_Tick(object sender, EventArgs e)
        {
            txtJigNeedCount.Text = GetJigsNeeded().ToString();
            txtCurrJig.Text = FListJigCarrier.Count.ToString();
            JigCarrier jig = null;
            bool finish = false;
            //bool finish2 = false;
            bool available = false;
            if (!FIsG8OnDuty)
            {
                if (!CheckBookingLoadingJigCarrierExist())
                {
                    if (FListJigCarrierOnRotary.Count > 0)
                    {
                        jig = FListJigCarrierOnRotary[0];
                        if (jig.IsLoaded)
                        {
                            T_BOOKING_STATION tbs = null;
                            using (var db = new DBProjectEntities())
                            {
                                tbs = db.Database.SqlQuery<T_BOOKING_STATION>("select * from T_BOOKING_STATION where ID= (select max(id) from T_BOOKING_STATION where  Status='Testing')").FirstOrDefault();
                            }
                            finish = CheckJigCarrierFinish(JigPosition.Up);
                            available = CheckIfMachineDestinationAvailable(jig, tbs);
                            //tmrRotary2.Enabled = false;
                            if (finish && available)
                            {
                                RotateJig();
                                FJigOnMove = FListJigCarrierOnRotary[0];
                                FJigEndPosition = FJigOnMove.EndPosition;
                                //Thread.Sleep(1000);
                                tmrRotary2.Enabled = false;
                                bool Wait = false;
                                WaitSynchronous(delegate () { Wait = !Wait; return Wait; }); tmrRotary2.Enabled = true;
                                CommandG8ToMoveJigFromTo(FJigOnMove, "ROTARY2", FJigOnMove.EndPosition);
                            }
                        }
                        else
                        {
                            finish = CheckJigCarrierFinish(JigPosition.Up);
                            if (finish)
                            {
                                //    if (FIsExitRecursive)
                                //    {
                                //        RotateJig();
                                //        MoveJigToStorage();
                                //    }
                                //    else
                                //    {
                                int cchm = FListMachineTester.Where(x => x.JigCarrier != null).Count();
                                if (cchm > 0)
                                {
                                    FIsExitRecursive = false;
                                    MoveJigWhenLoadingJigCarrierEnd();
                                    WaitSynchronous(delegate () { return !FIsExitRecursive; });
                                    if (FListJigCarrierOnRotary.Count == 4)
                                    {
                                        RotateJig();
                                        bool Wait = false; tmrRotary2.Enabled = false;
                                        WaitSynchronous(delegate () { Wait = !Wait; return Wait; }); tmrRotary2.Enabled = true;
                                        MoveJigToStorage();
                                    }

                                } else
                                if (FListJigCarrierOnRotary.Count == 4)
                                {
                                    RotateJig();
                                    bool Wait = false; tmrRotary2.Enabled = false;
                                    WaitSynchronous(delegate () { Wait = !Wait; return Wait; }); tmrRotary2.Enabled = true;
                                    MoveJigToStorage();
                                }
                                else
                                {
                                    RotateJig();
                                    bool Wait = false; tmrRotary2.Enabled = false;
                                    WaitSynchronous(delegate () { Wait = !Wait; return Wait; }); tmrRotary2.Enabled = true;
                                    MoveJigToStorage();
                                }
                                //}
                            }
                        }
                    }
                }
                else
                {
                    FJigEmptyOnRotary = 0;
                    if (FListJigCarrierOnRotary.Count < 4 && !FIsOneCycle)
                    {
                        RotateJig();
                        bool Wait = false; tmrRotary2.Enabled = false;
                        WaitSynchronous(delegate () { Wait = !Wait; return Wait; }); tmrRotary2.Enabled = true;
                        CreateJigCarrier();

                        return;
                    }
                    FIsOneCycle = true;
                    //if (FListJigCarrier.Count == 0) CreateJigCarrier();
                    jig = FListJigCarrierOnRotary[0];
                    if (jig.IsLoaded)
                    {
                        finish = CheckJigCarrierFinish(JigPosition.Up);
                        available = CheckIfMachineDestinationAvailable(jig);
                        //tmrRotary2.Enabled = false;
                        if (finish && available)
                        {
                            FJigOnMove = FListJigCarrierOnRotary[0];
                            using (var db = new DBProjectEntities())
                            {
                                T_BOOKING_STATION tbs = db.Database.SqlQuery<T_BOOKING_STATION>("select * from T_BOOKING_STATION where ID= (select min(id) from T_BOOKING_STATION where jig_id='EMPTY' and Status='LoadingJigCarrier')").FirstOrDefault();
                                if (tbs != null)
                                {
                                    T_BOOKING_STATION tbs2 = db.T_BOOKING_STATIONS.Where(x => x.ID == tbs.ID).FirstOrDefault();
                                    tbs2.Jig_ID = FJigOnMove.JigID;
                                    tbs2.Status = "Testing";
                                    db.Entry(tbs2).CurrentValues.SetValues(tbs2);
                                    db.SaveChanges();
                                }
                            }
                            if (FListJigCarrier.Count != GetJigsNeeded() && FListJigCarrierOnRotary.Count == 3)
                            {
                                CreateJigCarrier();
                                bool Wait2 = false; tmrRotary2.Enabled = false;
                                WaitSynchronous(delegate () { Wait2 = !Wait2; return Wait2; }); tmrRotary2.Enabled = true;
                            }
                            RotateJig();

                            FJigEndPosition = FJigOnMove.EndPosition;
                            //if (CheckBookingLoadingJigCarrierExist()) CreateJigCarrier();
                            //Thread.Sleep(1000);
                            tmrRotary2.Enabled = false;
                            bool Wait = false;
                            WaitSynchronous(delegate () { Wait = !Wait; return Wait; }); tmrRotary2.Enabled = true;
                            CommandG8ToMoveJigFromTo(FJigOnMove, "ROTARY2", FJigOnMove.EndPosition);
                        }
                    }
                } 
            }
        }
         

        private void Form8_Load(object sender, EventArgs e)
        {
            //CreateJigCarrier();
             //tmrRotary2.Enabled = true;
        }

        private void tmrG8_Tick(object sender, EventArgs e)
        {
            if (FSource == "ROTARY2" && FDestination != "ROTARY2")
            {
                FListJigCarrierOnRotary.Remove(FJigOnMove);
                FJigOnMove = GetJigCarrier(FJigEndPosition);//  FListJigCarrier[FListJigCarrier.Count-1];
                if (FJigOnMove.Left != GetMachineTesterPosition(FJigOnMove.EndPosition))
                {
                    FJigOnMove.Left = GetMachineTesterPosition(FJigOnMove.EndPosition);
                } else
                {
                    FJigOnMove.Visible = false;
                    Trial.Controls.AreaLoader.MachineTester mt = GetMachineTester(FJigOnMove.EndPosition);
                    if (mt != null)
                    {
                        mt.JigCarrier = FJigOnMove;
                    }
                    FIsG8OnDuty = false;
                    tmrG8.Enabled = false;
                }
            }
            if (FSource != "ROTARY2" && FDestination == "ROTARY2")
            {
                FJigOnMove.StartPosition = "ROTARY2";
                FJigOnMove.EndPosition = "";
                FListJigCarrierOnRotary.Add(FJigOnMove);
                FJigOnMove.JigPosition = JigPosition.Right;
                //FJigOnMove.Left = 189;
                //FJigOnMove.Top = 261;
                FJigOnMove.Parent = pnlLeft;
                FJigOnMove.Visible = true;
                FIsG8OnDuty = false;
                tmrG8.Enabled = false;
            }
            if (FSource != "ROTARY2" && FDestination != "ROTARY2")
            {
                if (FJigOnMove.Left != GetMachineTesterPosition(FJigOnMove.EndPosition))
                {
                    FJigOnMove.Left = GetMachineTesterPosition(FJigOnMove.EndPosition);
                }
                else
                {
                    FJigOnMove.Visible = false;
                    Trial.Controls.AreaLoader.MachineTester mt = GetMachineTester(FJigOnMove.EndPosition);
                    if (mt != null)
                    {
                        mt.JigCarrier = FJigOnMove;
                    }
                    FIsG8OnDuty = false;
                    tmrG8.Enabled = false;
                }
            }
        }
        private int FCount = 0;
        private T_TRANSACTION_INPUT FT_TRANSACTION_INPUT = new T_TRANSACTION_INPUT();
        private bool IsFirstTime = true;
        private void button2_Click(object sender, EventArgs e)
        {
            //string NetID = ConfigurationManager.AppSettings["TwinCatNetID"];
            //JoganUtility = new JoganUtility(NetID);

            //JoganUtility.PrepareAvailableSocketData();
            //T_TRANSACTION_INPUT tti = new T_TRANSACTION_INPUT();
            //JoganUtility.JoganUserID = "a";
            //JoganUtility.Scan2DCode(true,out tti);
            //JoganUtility.WriteAnyToPLC("INDEXING_2_VAR.O_ROTATION_START", TypeOfData.tpBool, true);

            if (IsFirstTime)
            {
                JoganUtility.AllowConnect = true;
                using (var db = new DBProjectEntities())
                {
                    db.Database.ExecuteSqlCommand("delete from T_NOISE_TEST_DATA_STATUS");
                    db.Database.ExecuteSqlCommand("delete from  T_SORTER_RESULT");
                    JoganUtility.FTransactionInputNearLaser = db.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == "PO0000000001").FirstOrDefault();
                    JoganUtility.FTransactionInputNearLaser.LotBox_Position_Laser = 1;
                }

                FCount++;
                JoganUtility.CreateDummyTestData("PO0000000001", FCount.ToString(), "NT-001");
                JoganUtility.PrepareTestResult("PO0000000001", FCount.ToString());
                JoganUtility.Stop();
                JoganUtility.Start(StartThreadFor.Laser);
                //IsFirstTime = false;
                
            }            
            //JoganUtility.PrepareListTestResult("PO0000000001", FCount.ToString(), "T-002");
            if (IsFirstTime)
            {
                
                JoganUtility.PrepareLoadingJigLaser(null, true);
                
            }
            IsFirstTime = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            M_MACHINE_TESTER m = JoganUtility.GetMachine("NT-001");
            JoganUtility.CommandG8ToMoveJigFromTo(null, new JoganMachinePosition { MachineType = m.Machines_Type, MachineLine = m.Machine_Line_Number, MachineNumber = m.Machine_Number });
        }
        private bool FWait;

        private void tmrDelay_Tick(object sender, EventArgs e)
        {
            FWait = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ResetBooking();
            tmrRotary2.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            M_MACHINE_TESTER m = JoganUtility.GetMachine("NT-001");
            JoganUtility.CommandG8ToMoveJigFromTo(new JoganMachinePosition { MachineType = m.Machines_Type, MachineLine = m.Machine_Line_Number, MachineNumber = m.Machine_Number },null);
        }
    }
}
