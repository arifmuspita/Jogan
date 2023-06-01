using DBProject.Models;
using Desktop.Controls.Info;
using Desktop.Controls.Testing;
using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities;
using TwinCAT.Ads;
using Commons;

namespace Desktop.Forms.Trial
{
    public partial class Form6 : Form
    {
        private JoganUtility JoganUtility;
        public Form6()
        {
            InitializeComponent();
            string NetID = ConfigurationManager.AppSettings["TwinCatNetID"];
            JoganUtility = new JoganUtility(NetID);
            JoganUtility.NetID = NetID;
            JoganUtility.OnJoganUtilityPLCNotification += new TwinCAT.Ads.AdsNotificationEventHandler(JoganUtilityPLCNotification);
        }

        private void JoganUtilityPLCNotification(object sender, AdsNotificationEventArgs e)
        {
            TwinCat3Property prop = JoganUtility.TwinCat3PropertyList.Where(x => x.DeviceNotificationHandle == e.NotificationHandle).FirstOrDefault();
            if (prop != null)
            {
                if (prop.VariableName == "SORTER_VAR.I_LASER_SOCKET")
                {
                    T_JIG_SOCKET tjs = (T_JIG_SOCKET)JoganUtility.ReadAnyFromPLC(prop.VariableName, TypeOfData.tpObject, typeof(T_JIG_SOCKET));
                    LaserTestingControl ltc = null;
                    if (tjs.STATION_NUMBER != 0)
                    {
                        ltc = testingControl.LaserTestingControlItem(tjs.STATION_NUMBER - 1);
                        FukudaTestingControl ftc = testingControl.FukudaTestingControlItem(tjs.PO_NUMBER);
                        if (ltc.Value == null)
                        {
                            int maxjig = 0;
                            using (var db = new DBProjectEntities())
                            {
                                maxjig = db.T_BOOKING_STATIONS.Where(x => x.PO_Number == tjs.PO_NUMBER).Count();
                            }
                            Color clr = ftc == null ? Color.Black : ftc.BasicColor;
                            ltc.Code = tjs.PO_NUMBER;
                            ltc.MaxJig = maxjig;
                            //ltc.AddJig(1);
                            ltc.Value = new LaserTestingControlClass
                            {
                                BasicColor = clr,
                                Code = tjs.PO_NUMBER,
                                PONumber = tjs.PO_NUMBER,
                                Status = StatusTestingControl.Booked
                            };
                        }
                        else
                        {
                            ltc.AddJig(1);
                        }
                    }
                    else
                    {
                        ltc = testingControl.LaserTestingControlItem(tjs.PO_NUMBER);
                        if (ltc != null)
                        {
                            LaserTestingControlClass val = (LaserTestingControlClass)ltc.Value;
                            for (int i = 1; i <= 4; i++)
                            {
                                if (tjs.LASER_DESTINATION[i] == 9) { val.QuantityGood++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 1) { val.QuantityNG1++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 2) { val.QuantityNG2++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 3) { val.QuantityNG3++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 4) { val.QuantityNG4++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 5) { val.QuantityNG5++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 6) { val.QuantityNG6++; }
                                else
                                if (tjs.LASER_DESTINATION[i] == 7) { val.QuantityNG7++; } else val.QuantityNGOther++;
                            }
                            ltc.Value = val;
                        }
                    }
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //MachineTesterControl mtc = testingControl.MachineTesterControlItem(0);
            //mtc.Value = null;
            //mtc.MachineInterval = 360;
            //mtc.StartProgress();
            //testingControl.InfoTestingControl.AddItem(new InfoMessageItemControl { Caption = "Messages"},false,0);

            //InfoMessageItemControl msg = (InfoMessageItemControl)testingControl.InfoTestingControl.InfoTestingControlItems[0];
            //msg.Message = new InfoMassageControlClass
            //{
            //    DateTime = DateTime.Now,
            //    Message = "Low priority",
            //    Impact = DesktopProperties.InfoMassageImpact.Low,
            //    Sender = "Laptop1"
            //};
            //msg.Message = new InfoMassageControlClass
            //{
            //    DateTime = DateTime.Now,
            //    Message = "Medium priority",
            //    Impact = DesktopProperties.InfoMassageImpact.Medium,
            //    Sender = "Laptop1"
            //};
            //msg.Message = new InfoMassageControlClass
            //{
            //    DateTime = DateTime.Now,
            //    Message = "High priority",
            //    Impact = DesktopProperties.InfoMassageImpact.High,
            //    Sender = "Laptop1"
            //};
        }
        private int FCount = 0;
        private T_TRANSACTION_INPUT FT_TRANSACTION_INPUT = new T_TRANSACTION_INPUT();
        private bool IsFirstTime = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if(IsFirstTime)
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
                JoganUtility.CreateDummyTestData("PO0000000001", FCount.ToString(), "T-002");
                JoganUtility.PrepareTestResult("PO0000000001", FCount.ToString());
                JoganUtility.Stop();
                JoganUtility.Start(StartThreadFor.Rotary1);
                //IsFirstTime = false;

            }
            //JoganUtility.PrepareListTestResult("PO0000000001", FCount.ToString(), "T-002");
            if (IsFirstTime)
            {

                 //JoganUtility.PrepareLoadingJigLaser(null, true);

            }
            //JoganUtility.WriteAnyToPLC("SORTER_RS4_VAR.I_SORTER_RS4_ENABLE", TypeOfData.tpBool, true);
            //JoganUtility.WriteAnyToPLC("SORTER_RS4_VAR.O_SORTER_RS4_CONTINUE", TypeOfData.tpBool, true);
            //JoganUtility.PrepareListTestResult();I_LOADER_RS4_ENABLE
            JoganUtility.WriteAnyToPLC("LOADER_RS4_VAR.I_LOADER_RS4_ENABLE", TypeOfData.tpBool, true);
            JoganUtility.WriteAnyToPLC("INPUT_G6_VAR.I_G6_ENABLE", TypeOfData.tpBool, true);
            //JoganUtility.WriteAnyToPLC("INPUT_G6_VAR.GO_ROBOT", TypeOfData.tpBool, true);
            JoganUtility.PrepareAvailableSocketData();
            IsFirstTime = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!JoganUtility.AllowConnect) JoganUtility.AllowConnect = true;
            T_JIG_SOCKET tjs = (T_JIG_SOCKET)JoganUtility.ReadAnyFromPLC("SORTER_VAR.I_LASER_SOCKET", TypeOfData.tpObject, typeof(T_JIG_SOCKET));
            tjs.STATION_NUMBER = (byte)2;
            tjs.PO_NUMBER = "PO0000000001";
            JoganUtility.WriteAnyToPLC("SORTER_VAR.I_LASER_SOCKET", TypeOfData.tpObject, tjs);
            //JoganUtility.SendBackAllLaserTransport();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!JoganUtility.AllowConnect) JoganUtility.AllowConnect = true;
            JoganUtility.WriteAnyToPLC("SORTER_RS4_VAR.I_SORTER_RS4_ENABLE", TypeOfData.tpBool, true);
            JoganUtility.PrepareListTestResult();
        }
    }
}
