namespace DBProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBProject : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.M_BOOKING_STATION",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Noise_Room_Number = c.Int(nullable: false),
                    Signal_Room_Number = c.Int(nullable: false),
                    Resistance_Room_Number = c.Int(nullable: false),
                    Line_Number = c.Int(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.M_DEVICE_NG",
                c => new
                {
                    Device_NG_ID = c.String(nullable: false, maxLength: 128),
                    Device_NG_Type = c.String(nullable: false, maxLength: 200),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.Device_NG_ID);

            CreateTable(
                "dbo.M_DEVICE",
                c => new
                {
                    Device_ID = c.String(nullable: false, maxLength: 128),
                    Device_Name = c.String(nullable: false, maxLength: 250),
                    Device_Status = c.String(nullable: false, maxLength: 200),
                    Test_Mode_Default = c.String(nullable: false, maxLength: 200),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.Device_ID);

            CreateTable(
                "dbo.M_ERROR_LIST",
                c => new
                {
                    Error_Code = c.String(nullable: false, maxLength: 50),
                    Error_Name = c.String(nullable: false, maxLength: 250),
                    Impact = c.String(nullable: false, maxLength: 250),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.Error_Code);

            CreateTable(
                "dbo.M_GOLDEN_SAMPLE",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Device_Test_Ref = c.String(),
                    Golden_Sample_Type = c.String(),
                    Socket_1 = c.Double(nullable: false),
                    Socket_2 = c.Double(nullable: false),
                    Socket_3 = c.Double(nullable: false),
                    Socket_4 = c.Double(nullable: false),
                    Socket_5 = c.Double(nullable: false),
                    Socket_6 = c.Double(nullable: false),
                    Socket_7 = c.Double(nullable: false),
                    Socket_8 = c.Double(nullable: false),
                    Socket_9 = c.Double(nullable: false),
                    Socket_10 = c.Double(nullable: false),
                    Socket_11 = c.Double(nullable: false),
                    Socket_12 = c.Double(nullable: false),
                    Socket_13 = c.Double(nullable: false),
                    Socket_14 = c.Double(nullable: false),
                    Socket_15 = c.Double(nullable: false),
                    Socket_16 = c.Double(nullable: false),
                    Socket_17 = c.Double(nullable: false),
                    Socket_18 = c.Double(nullable: false),
                    Socket_19 = c.Double(nullable: false),
                    Socket_20 = c.Double(nullable: false),
                    Socket_21 = c.Double(nullable: false),
                    Socket_22 = c.Double(nullable: false),
                    Socket_23 = c.Double(nullable: false),
                    Socket_24 = c.Double(nullable: false),
                    Socket_25 = c.Double(nullable: false),
                    Socket_26 = c.Double(nullable: false),
                    Socket_27 = c.Double(nullable: false),
                    Socket_28 = c.Double(nullable: false),
                    Socket_29 = c.Double(nullable: false),
                    Socket_30 = c.Double(nullable: false),
                    Socket_31 = c.Double(nullable: false),
                    Socket_32 = c.Double(nullable: false),
                    Socket_33 = c.Double(nullable: false),
                    Socket_34 = c.Double(nullable: false),
                    Socket_35 = c.Double(nullable: false),
                    Socket_36 = c.Double(nullable: false),
                    Socket_37 = c.Double(nullable: false),
                    Socket_38 = c.Double(nullable: false),
                    Socket_39 = c.Double(nullable: false),
                    Socket_40 = c.Double(nullable: false),
                    Socket_41 = c.Double(nullable: false),
                    Socket_42 = c.Double(nullable: false),
                    Socket_43 = c.Double(nullable: false),
                    Socket_44 = c.Double(nullable: false),
                    Socket_45 = c.Double(nullable: false),
                    Socket_46 = c.Double(nullable: false),
                    Socket_47 = c.Double(nullable: false),
                    Socket_48 = c.Double(nullable: false),
                    Socket_49 = c.Double(nullable: false),
                    Socket_50 = c.Double(nullable: false),
                    Socket_51 = c.Double(nullable: false),
                    Socket_52 = c.Double(nullable: false),
                    Socket_53 = c.Double(nullable: false),
                    Socket_54 = c.Double(nullable: false),
                    Socket_55 = c.Double(nullable: false),
                    Socket_56 = c.Double(nullable: false),
                    Socket_57 = c.Double(nullable: false),
                    Socket_58 = c.Double(nullable: false),
                    Socket_59 = c.Double(nullable: false),
                    Socket_60 = c.Double(nullable: false),
                    Socket_61 = c.Double(nullable: false),
                    Socket_62 = c.Double(nullable: false),
                    Socket_63 = c.Double(nullable: false),
                    Socket_64 = c.Double(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.M_JIG_CLOSE_SOCKET",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Jig_ID = c.String(maxLength: 128),
                    Socket_1 = c.Boolean(nullable: false),
                    Socket_2 = c.Boolean(nullable: false),
                    Socket_3 = c.Boolean(nullable: false),
                    Socket_4 = c.Boolean(nullable: false),
                    Socket_5 = c.Boolean(nullable: false),
                    Socket_6 = c.Boolean(nullable: false),
                    Socket_7 = c.Boolean(nullable: false),
                    Socket_8 = c.Boolean(nullable: false),
                    Socket_9 = c.Boolean(nullable: false),
                    Socket_10 = c.Boolean(nullable: false),
                    Socket_11 = c.Boolean(nullable: false),
                    Socket_12 = c.Boolean(nullable: false),
                    Socket_13 = c.Boolean(nullable: false),
                    Socket_14 = c.Boolean(nullable: false),
                    Socket_15 = c.Boolean(nullable: false),
                    Socket_16 = c.Boolean(nullable: false),
                    Socket_17 = c.Boolean(nullable: false),
                    Socket_18 = c.Boolean(nullable: false),
                    Socket_19 = c.Boolean(nullable: false),
                    Socket_20 = c.Boolean(nullable: false),
                    Socket_21 = c.Boolean(nullable: false),
                    Socket_22 = c.Boolean(nullable: false),
                    Socket_23 = c.Boolean(nullable: false),
                    Socket_24 = c.Boolean(nullable: false),
                    Socket_25 = c.Boolean(nullable: false),
                    Socket_26 = c.Boolean(nullable: false),
                    Socket_27 = c.Boolean(nullable: false),
                    Socket_28 = c.Boolean(nullable: false),
                    Socket_29 = c.Boolean(nullable: false),
                    Socket_30 = c.Boolean(nullable: false),
                    Socket_31 = c.Boolean(nullable: false),
                    Socket_32 = c.Boolean(nullable: false),
                    Socket_33 = c.Boolean(nullable: false),
                    Socket_34 = c.Boolean(nullable: false),
                    Socket_35 = c.Boolean(nullable: false),
                    Socket_36 = c.Boolean(nullable: false),
                    Socket_37 = c.Boolean(nullable: false),
                    Socket_38 = c.Boolean(nullable: false),
                    Socket_39 = c.Boolean(nullable: false),
                    Socket_40 = c.Boolean(nullable: false),
                    Socket_41 = c.Boolean(nullable: false),
                    Socket_42 = c.Boolean(nullable: false),
                    Socket_43 = c.Boolean(nullable: false),
                    Socket_44 = c.Boolean(nullable: false),
                    Socket_45 = c.Boolean(nullable: false),
                    Socket_46 = c.Boolean(nullable: false),
                    Socket_47 = c.Boolean(nullable: false),
                    Socket_48 = c.Boolean(nullable: false),
                    Socket_49 = c.Boolean(nullable: false),
                    Socket_50 = c.Boolean(nullable: false),
                    Socket_51 = c.Boolean(nullable: false),
                    Socket_52 = c.Boolean(nullable: false),
                    Socket_53 = c.Boolean(nullable: false),
                    Socket_54 = c.Boolean(nullable: false),
                    Socket_55 = c.Boolean(nullable: false),
                    Socket_56 = c.Boolean(nullable: false),
                    Socket_57 = c.Boolean(nullable: false),
                    Socket_58 = c.Boolean(nullable: false),
                    Socket_59 = c.Boolean(nullable: false),
                    Socket_60 = c.Boolean(nullable: false),
                    Socket_61 = c.Boolean(nullable: false),
                    Socket_62 = c.Boolean(nullable: false),
                    Socket_63 = c.Boolean(nullable: false),
                    Socket_64 = c.Boolean(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_JIG", t => t.Jig_ID)
                .Index(t => t.Jig_ID);

            CreateTable(
                "dbo.M_JIG",
                c => new
                {
                    Jig_ID = c.String(nullable: false, maxLength: 128),
                    Jig_Carrier_Name = c.String(nullable: false, maxLength: 250),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.Jig_ID);

            CreateTable(
                "dbo.M_MACHINE_CLOSE_SOCKET",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Machine_ID = c.String(maxLength: 128),
                    Socket_1 = c.Boolean(nullable: false),
                    Socket_2 = c.Boolean(nullable: false),
                    Socket_3 = c.Boolean(nullable: false),
                    Socket_4 = c.Boolean(nullable: false),
                    Socket_5 = c.Boolean(nullable: false),
                    Socket_6 = c.Boolean(nullable: false),
                    Socket_7 = c.Boolean(nullable: false),
                    Socket_8 = c.Boolean(nullable: false),
                    Socket_9 = c.Boolean(nullable: false),
                    Socket_10 = c.Boolean(nullable: false),
                    Socket_11 = c.Boolean(nullable: false),
                    Socket_12 = c.Boolean(nullable: false),
                    Socket_13 = c.Boolean(nullable: false),
                    Socket_14 = c.Boolean(nullable: false),
                    Socket_15 = c.Boolean(nullable: false),
                    Socket_16 = c.Boolean(nullable: false),
                    Socket_17 = c.Boolean(nullable: false),
                    Socket_18 = c.Boolean(nullable: false),
                    Socket_19 = c.Boolean(nullable: false),
                    Socket_20 = c.Boolean(nullable: false),
                    Socket_21 = c.Boolean(nullable: false),
                    Socket_22 = c.Boolean(nullable: false),
                    Socket_23 = c.Boolean(nullable: false),
                    Socket_24 = c.Boolean(nullable: false),
                    Socket_25 = c.Boolean(nullable: false),
                    Socket_26 = c.Boolean(nullable: false),
                    Socket_27 = c.Boolean(nullable: false),
                    Socket_28 = c.Boolean(nullable: false),
                    Socket_29 = c.Boolean(nullable: false),
                    Socket_30 = c.Boolean(nullable: false),
                    Socket_31 = c.Boolean(nullable: false),
                    Socket_32 = c.Boolean(nullable: false),
                    Socket_33 = c.Boolean(nullable: false),
                    Socket_34 = c.Boolean(nullable: false),
                    Socket_35 = c.Boolean(nullable: false),
                    Socket_36 = c.Boolean(nullable: false),
                    Socket_37 = c.Boolean(nullable: false),
                    Socket_38 = c.Boolean(nullable: false),
                    Socket_39 = c.Boolean(nullable: false),
                    Socket_40 = c.Boolean(nullable: false),
                    Socket_41 = c.Boolean(nullable: false),
                    Socket_42 = c.Boolean(nullable: false),
                    Socket_43 = c.Boolean(nullable: false),
                    Socket_44 = c.Boolean(nullable: false),
                    Socket_45 = c.Boolean(nullable: false),
                    Socket_46 = c.Boolean(nullable: false),
                    Socket_47 = c.Boolean(nullable: false),
                    Socket_48 = c.Boolean(nullable: false),
                    Socket_49 = c.Boolean(nullable: false),
                    Socket_50 = c.Boolean(nullable: false),
                    Socket_51 = c.Boolean(nullable: false),
                    Socket_52 = c.Boolean(nullable: false),
                    Socket_53 = c.Boolean(nullable: false),
                    Socket_54 = c.Boolean(nullable: false),
                    Socket_55 = c.Boolean(nullable: false),
                    Socket_56 = c.Boolean(nullable: false),
                    Socket_57 = c.Boolean(nullable: false),
                    Socket_58 = c.Boolean(nullable: false),
                    Socket_59 = c.Boolean(nullable: false),
                    Socket_60 = c.Boolean(nullable: false),
                    Socket_61 = c.Boolean(nullable: false),
                    Socket_62 = c.Boolean(nullable: false),
                    Socket_63 = c.Boolean(nullable: false),
                    Socket_64 = c.Boolean(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_MACHINE_TESTER", t => t.Machine_ID)
                .Index(t => t.Machine_ID);

            CreateTable(
                "dbo.M_MACHINE_TESTER",
                c => new
                {
                    Machine_ID = c.String(nullable: false, maxLength: 128),
                    Machine_Name = c.String(nullable: false, maxLength: 250),
                    Machines_Type = c.String(nullable: false, maxLength: 150),
                    Machine_Number = c.Int(nullable: false),
                    Machine_Line_Number = c.Int(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.Machine_ID);

            CreateTable(
                "dbo.M_MACHINE_TESTER_CALIBRATION_TYPE",
                c => new
                {
                    Calibration_Type = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.Calibration_Type);

            CreateTable(
                "dbo.M_MACHINE_TESTER_CALIBRATION",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Machine_ID = c.String(nullable: false, maxLength: 128),
                    Calibration_Type = c.String(nullable: false, maxLength: 128),
                    Socket_1 = c.Double(nullable: false),
                    Socket_2 = c.Double(nullable: false),
                    Socket_3 = c.Double(nullable: false),
                    Socket_4 = c.Double(nullable: false),
                    Socket_5 = c.Double(nullable: false),
                    Socket_6 = c.Double(nullable: false),
                    Socket_7 = c.Double(nullable: false),
                    Socket_8 = c.Double(nullable: false),
                    Socket_9 = c.Double(nullable: false),
                    Socket_10 = c.Double(nullable: false),
                    Socket_11 = c.Double(nullable: false),
                    Socket_12 = c.Double(nullable: false),
                    Socket_13 = c.Double(nullable: false),
                    Socket_14 = c.Double(nullable: false),
                    Socket_15 = c.Double(nullable: false),
                    Socket_16 = c.Double(nullable: false),
                    Socket_17 = c.Double(nullable: false),
                    Socket_18 = c.Double(nullable: false),
                    Socket_19 = c.Double(nullable: false),
                    Socket_20 = c.Double(nullable: false),
                    Socket_21 = c.Double(nullable: false),
                    Socket_22 = c.Double(nullable: false),
                    Socket_23 = c.Double(nullable: false),
                    Socket_24 = c.Double(nullable: false),
                    Socket_25 = c.Double(nullable: false),
                    Socket_26 = c.Double(nullable: false),
                    Socket_27 = c.Double(nullable: false),
                    Socket_28 = c.Double(nullable: false),
                    Socket_29 = c.Double(nullable: false),
                    Socket_30 = c.Double(nullable: false),
                    Socket_31 = c.Double(nullable: false),
                    Socket_32 = c.Double(nullable: false),
                    Socket_33 = c.Double(nullable: false),
                    Socket_34 = c.Double(nullable: false),
                    Socket_35 = c.Double(nullable: false),
                    Socket_36 = c.Double(nullable: false),
                    Socket_37 = c.Double(nullable: false),
                    Socket_38 = c.Double(nullable: false),
                    Socket_39 = c.Double(nullable: false),
                    Socket_40 = c.Double(nullable: false),
                    Socket_41 = c.Double(nullable: false),
                    Socket_42 = c.Double(nullable: false),
                    Socket_43 = c.Double(nullable: false),
                    Socket_44 = c.Double(nullable: false),
                    Socket_45 = c.Double(nullable: false),
                    Socket_46 = c.Double(nullable: false),
                    Socket_47 = c.Double(nullable: false),
                    Socket_48 = c.Double(nullable: false),
                    Socket_49 = c.Double(nullable: false),
                    Socket_50 = c.Double(nullable: false),
                    Socket_51 = c.Double(nullable: false),
                    Socket_52 = c.Double(nullable: false),
                    Socket_53 = c.Double(nullable: false),
                    Socket_54 = c.Double(nullable: false),
                    Socket_55 = c.Double(nullable: false),
                    Socket_56 = c.Double(nullable: false),
                    Socket_57 = c.Double(nullable: false),
                    Socket_58 = c.Double(nullable: false),
                    Socket_59 = c.Double(nullable: false),
                    Socket_60 = c.Double(nullable: false),
                    Socket_61 = c.Double(nullable: false),
                    Socket_62 = c.Double(nullable: false),
                    Socket_63 = c.Double(nullable: false),
                    Socket_64 = c.Double(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_MACHINE_TESTER", t => t.Machine_ID)
                .ForeignKey("dbo.M_MACHINE_TESTER_CALIBRATION_TYPE", t => t.Calibration_Type)
                .Index(t => t.Machine_ID)
                .Index(t => t.Calibration_Type);

            CreateTable(
                "dbo.M_MENU",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Parent_ID = c.Int(),
                    Detail = c.Boolean(nullable: false),
                    Module = c.String(nullable: false, maxLength: 100),
                    Module_Parent = c.String(maxLength: 100),
                    Menu_For = c.String(nullable: false, maxLength: 100),
                    Image_Index = c.Int(),
                    Code = c.String(maxLength: 100),
                    Name = c.String(maxLength: 250),
                    Is_Active = c.Boolean(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.M_NG_CONFIG",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Box_ID = c.String(maxLength: 25),
                    NG_Code = c.String(maxLength: 25),
                    Date_String = c.String(maxLength: 50),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.M_NOISE_DEVICE_PARAMETER",
                c => new
                {
                    Test_Type_ID = c.String(nullable: false, maxLength: 128),
                    Test_Type_Name = c.String(nullable: false),
                    Noise_Limit = c.Int(nullable: false),
                    Soak_Time = c.Int(nullable: false),
                    Measurement_Duration = c.Int(nullable: false),
                    Lauda_Setting = c.Int(nullable: false),
                    BB_Temperature_HL = c.Int(nullable: false),
                    BB_Temperature_LL = c.Int(nullable: false),
                    Upper_Temp_Tolerance = c.Int(nullable: false),
                    Lower_Temp_Tolearance = c.Int(nullable: false),
                    Sample_Rate = c.Int(nullable: false),
                    No_DUT_Offset = c.Double(nullable: false),
                    Offset_HLimit = c.Double(nullable: false),
                    Offset_LLimit = c.Double(nullable: false),
                    Cut_Off_Freq = c.Double(nullable: false),
                    Moving_Window = c.Boolean(nullable: false),
                    Correlation_Factor = c.Double(nullable: false),
                    Testing_Voltage = c.Int(nullable: false),
                    Lauda_Setting1 = c.Int(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.Test_Type_ID);

            CreateTable(
                "dbo.M_NOISE_DEVICE",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Test_Type_ID = c.String(maxLength: 128),
                    Device_ID = c.String(maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_NOISE_DEVICE_PARAMETER", t => t.Test_Type_ID)
                .ForeignKey("dbo.M_DEVICE", t => t.Device_ID)
                .Index(t => t.Test_Type_ID)
                .Index(t => t.Device_ID);

            CreateTable(
                "dbo.M_SIGNAL_DEVICE_PARAMETER",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Device_ID = c.String(nullable: false, maxLength: 128),
                    No_DUT_Offset = c.Double(nullable: false),
                    Offset_Min = c.Double(nullable: false),
                    Offset_Max = c.Double(nullable: false),
                    Offset_HLimit = c.Double(nullable: false),
                    Offset_Grp_Min = c.Double(nullable: false),
                    Offset_Grp_Max = c.Double(nullable: false),
                    No_Response = c.Double(nullable: false),
                    Response_Min = c.Double(nullable: false),
                    Response_Max = c.Double(nullable: false),
                    Response_Grp_Min = c.Double(nullable: false),
                    Response_Grp_Max = c.Double(nullable: false),
                    Match_Correlation_Factor = c.Double(nullable: false),
                    Match_Signal_Max = c.Double(nullable: false),
                    Resistance_Min = c.Double(nullable: false),
                    First_Soak_Time = c.Int(nullable: false),
                    Second_Soak_Time = c.Int(nullable: false),
                    Lauda_Setting = c.Int(nullable: false),
                    BB_Setting = c.Int(nullable: false),
                    BB_Temperature_HL = c.Int(nullable: false),
                    BB_Temperature_LL = c.Int(nullable: false),
                    Sample_Rate = c.Int(nullable: false),
                    High_Cutof_Frequency = c.Double(nullable: false),
                    Low_Cutof_Frequency = c.Double(nullable: false),
                    Measurement_Duration = c.Int(nullable: false),
                    Measurement_Duration_2 = c.Double(nullable: false),
                    Temperature_Coe = c.Double(nullable: false),
                    Testing_Voltage = c.Double(nullable: false),
                    Resistance = c.Double(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_DEVICE", t => t.Device_ID)
                .Index(t => t.Device_ID);

            CreateTable(
                "dbo.M_USER_GROUP_PRIVILEGES",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Group_ID = c.String(nullable: false, maxLength: 128),
                    Menu_ID = c.Int(nullable: false),
                    Allow_Read = c.Boolean(nullable: false),
                    Allow_Add = c.Boolean(nullable: false),
                    Allow_Delete = c.Boolean(nullable: false),
                    Allow_Edit = c.Boolean(nullable: false),
                    Allow_Export = c.Boolean(nullable: false),
                    Allow_Report = c.Boolean(nullable: false),
                    Code = c.String(maxLength: 100),
                    Name = c.String(maxLength: 250),
                    Is_Active = c.Boolean(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_MENU", t => t.Menu_ID)
                .ForeignKey("dbo.M_USER_GROUP", t => t.Group_ID)
                .Index(t => t.Group_ID)
                .Index(t => t.Menu_ID);

            CreateTable(
                "dbo.M_USER_GROUP",
                c => new
                {
                    Group_ID = c.String(nullable: false, maxLength: 128),
                    Group_Name = c.String(maxLength: 500),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.Group_ID);

            CreateTable(
                "dbo.M_USER",
                c => new
                {
                    User_ID = c.String(nullable: false, maxLength: 128),
                    Group_ID = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 250),
                    Password = c.String(nullable: false, maxLength: 250),
                    Is_Active = c.Boolean(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.User_ID)
                .ForeignKey("dbo.M_USER_GROUP", t => t.Group_ID)
                .Index(t => t.Group_ID);

            //CreateTable(
            //    "dbo.SP_GROUP_PRIVILEGES",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Code = c.String(),
            //            Name = c.String(),
            //            Detail = c.Boolean(nullable: false),
            //            Total_Child = c.Int(nullable: false),
            //            Allow_Read = c.Boolean(nullable: false),
            //            Allow_Add = c.Boolean(nullable: false),
            //            Allow_Edit = c.Boolean(nullable: false),
            //            Allow_Delete = c.Boolean(nullable: false),
            //            Allow_Report = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.SP_LASER_STATION",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            LotBox_ID = c.String(),
            //            LotBox_NG_ID = c.String(),
            //            Status = c.String(),
            //            Created_User = c.String(),
            //            LotBox_Position = c.Int(nullable: false),
            //            Created_Date = c.DateTime(nullable: false),
            //            Updated_User = c.String(),
            //            Updated_Date = c.DateTime(nullable: false),
            //            Is_Downgrade = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.SP_TESTING_STATUS",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            TestType = c.String(),
            //            PO_Number = c.String(),
            //            Machine_ID = c.String(),
            //            Jig_ID = c.String(),
            //            Socket_1 = c.String(),
            //            Socket_2 = c.String(),
            //            Socket_3 = c.String(),
            //            Socket_4 = c.String(),
            //            Socket_5 = c.String(),
            //            Socket_6 = c.String(),
            //            Socket_7 = c.String(),
            //            Socket_8 = c.String(),
            //            Socket_9 = c.String(),
            //            Socket_10 = c.String(),
            //            Socket_11 = c.String(),
            //            Socket_12 = c.String(),
            //            Socket_13 = c.String(),
            //            Socket_14 = c.String(),
            //            Socket_15 = c.String(),
            //            Socket_16 = c.String(),
            //            Socket_17 = c.String(),
            //            Socket_18 = c.String(),
            //            Socket_19 = c.String(),
            //            Socket_20 = c.String(),
            //            Socket_21 = c.String(),
            //            Socket_22 = c.String(),
            //            Socket_23 = c.String(),
            //            Socket_24 = c.String(),
            //            Socket_25 = c.String(),
            //            Socket_26 = c.String(),
            //            Socket_27 = c.String(),
            //            Socket_28 = c.String(),
            //            Socket_29 = c.String(),
            //            Socket_30 = c.String(),
            //            Socket_31 = c.String(),
            //            Socket_32 = c.String(),
            //            Socket_33 = c.String(),
            //            Socket_34 = c.String(),
            //            Socket_35 = c.String(),
            //            Socket_36 = c.String(),
            //            Socket_37 = c.String(),
            //            Socket_38 = c.String(),
            //            Socket_39 = c.String(),
            //            Socket_40 = c.String(),
            //            Socket_41 = c.String(),
            //            Socket_42 = c.String(),
            //            Socket_43 = c.String(),
            //            Socket_44 = c.String(),
            //            Socket_45 = c.String(),
            //            Socket_46 = c.String(),
            //            Socket_47 = c.String(),
            //            Socket_48 = c.String(),
            //            Socket_49 = c.String(),
            //            Socket_50 = c.String(),
            //            Socket_51 = c.String(),
            //            Socket_52 = c.String(),
            //            Socket_53 = c.String(),
            //            Socket_54 = c.String(),
            //            Socket_55 = c.String(),
            //            Socket_56 = c.String(),
            //            Socket_57 = c.String(),
            //            Socket_58 = c.String(),
            //            Socket_59 = c.String(),
            //            Socket_60 = c.String(),
            //            Socket_61 = c.String(),
            //            Socket_62 = c.String(),
            //            Socket_63 = c.String(),
            //            Socket_64 = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.T_BOOKING_STATION",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Queue_ID = c.Int(nullable: false),
                    Noise_Room_Number = c.Int(nullable: false),
                    Signal_Room_Number = c.Int(nullable: false),
                    Resistance_Room_Number = c.Int(nullable: false),
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Device_ID = c.String(nullable: false, maxLength: 128),
                    Jig_ID = c.String(nullable: false),
                    Close_Socket_Numbers = c.String(nullable: false),
                    Device_Qty = c.Int(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_BOOKING_STATION", t => t.Queue_ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .ForeignKey("dbo.M_DEVICE", t => t.Device_ID)
                .Index(t => t.Queue_ID)
                .Index(t => t.PO_Number)
                .Index(t => t.Device_ID);

            CreateTable(
                "dbo.T_TRANSACTION_INPUT",
                c => new
                {
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    AQL_Reference = c.String(maxLength: 100),
                    LotBox_Position_Fukuda = c.Int(nullable: false),
                    LotBox_Position_Laser = c.Int(nullable: false),
                    LotBox_Position_Laser_Downgrade = c.Int(nullable: false),
                    Noise_Type_Parameter_Ref = c.String(maxLength: 100),
                    Signal_Device_ID_Ref = c.String(maxLength: 100),
                    Status = c.String(maxLength: 100),
                    LotBox_ID = c.String(maxLength: 100),
                    Start_Test = c.DateTime(nullable: false),
                    End_Test = c.DateTime(nullable: false),
                    Quantity = c.Int(nullable: false),
                    Default_Test_Mode = c.String(nullable: false),
                    Device_ID = c.String(nullable: false, maxLength: 128),
                    User_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.PO_Number)
                .ForeignKey("dbo.M_DEVICE", t => t.Device_ID)
                .ForeignKey("dbo.M_USER", t => t.User_ID)
                .Index(t => t.Device_ID)
                .Index(t => t.User_ID);

            CreateTable(
                "dbo.T_ERROR_LIST",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Error_Code = c.String(maxLength: 50),
                    Hardware_ID = c.String(maxLength: 50),
                    Status = c.String(maxLength: 50),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_ERROR_LIST", t => t.Error_Code)
                .Index(t => t.Error_Code);

            CreateTable(
                "dbo.T_LASER_STATION",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    LotBox_ID = c.String(),
                    LotBox_NG_ID = c.String(),
                    Status = c.String(),
                    LotBox_Position = c.Int(nullable: false),
                    Is_Downgrade = c.Boolean(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.T_LOGIN_HISTORY",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    User_ID = c.String(nullable: false, maxLength: 128),
                    Login_Date = c.DateTime(nullable: false),
                    Description = c.String(),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_USER", t => t.User_ID)
                .Index(t => t.User_ID);

            CreateTable(
                "dbo.T_MACHINE_BOOKING",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Machine_ID = c.String(nullable: false, maxLength: 128),
                    Booking_ID = c.Int(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                    B_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_MACHINE_TESTER", t => t.Machine_ID)
                .ForeignKey("dbo.T_BOOKING_STATION", t => t.B_ID)
                .Index(t => t.Machine_ID)
                .Index(t => t.B_ID);

            CreateTable(
                "dbo.T_NOISE_TEST_DATA_DETAIL",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Socket_1 = c.Double(nullable: false),
                    Socket_2 = c.Double(nullable: false),
                    Socket_3 = c.Double(nullable: false),
                    Socket_4 = c.Double(nullable: false),
                    Socket_5 = c.Double(nullable: false),
                    Socket_6 = c.Double(nullable: false),
                    Socket_7 = c.Double(nullable: false),
                    Socket_8 = c.Double(nullable: false),
                    Socket_9 = c.Double(nullable: false),
                    Socket_10 = c.Double(nullable: false),
                    Socket_11 = c.Double(nullable: false),
                    Socket_12 = c.Double(nullable: false),
                    Socket_13 = c.Double(nullable: false),
                    Socket_14 = c.Double(nullable: false),
                    Socket_15 = c.Double(nullable: false),
                    Socket_16 = c.Double(nullable: false),
                    Socket_17 = c.Double(nullable: false),
                    Socket_18 = c.Double(nullable: false),
                    Socket_19 = c.Double(nullable: false),
                    Socket_20 = c.Double(nullable: false),
                    Socket_21 = c.Double(nullable: false),
                    Socket_22 = c.Double(nullable: false),
                    Socket_23 = c.Double(nullable: false),
                    Socket_24 = c.Double(nullable: false),
                    Socket_25 = c.Double(nullable: false),
                    Socket_26 = c.Double(nullable: false),
                    Socket_27 = c.Double(nullable: false),
                    Socket_28 = c.Double(nullable: false),
                    Socket_29 = c.Double(nullable: false),
                    Socket_30 = c.Double(nullable: false),
                    Socket_31 = c.Double(nullable: false),
                    Socket_32 = c.Double(nullable: false),
                    Socket_33 = c.Double(nullable: false),
                    Socket_34 = c.Double(nullable: false),
                    Socket_35 = c.Double(nullable: false),
                    Socket_36 = c.Double(nullable: false),
                    Socket_37 = c.Double(nullable: false),
                    Socket_38 = c.Double(nullable: false),
                    Socket_39 = c.Double(nullable: false),
                    Socket_40 = c.Double(nullable: false),
                    Socket_41 = c.Double(nullable: false),
                    Socket_42 = c.Double(nullable: false),
                    Socket_43 = c.Double(nullable: false),
                    Socket_44 = c.Double(nullable: false),
                    Socket_45 = c.Double(nullable: false),
                    Socket_46 = c.Double(nullable: false),
                    Socket_47 = c.Double(nullable: false),
                    Socket_48 = c.Double(nullable: false),
                    Socket_49 = c.Double(nullable: false),
                    Socket_50 = c.Double(nullable: false),
                    Socket_51 = c.Double(nullable: false),
                    Socket_52 = c.Double(nullable: false),
                    Socket_53 = c.Double(nullable: false),
                    Socket_54 = c.Double(nullable: false),
                    Socket_55 = c.Double(nullable: false),
                    Socket_56 = c.Double(nullable: false),
                    Socket_57 = c.Double(nullable: false),
                    Socket_58 = c.Double(nullable: false),
                    Socket_59 = c.Double(nullable: false),
                    Socket_60 = c.Double(nullable: false),
                    Socket_61 = c.Double(nullable: false),
                    Socket_62 = c.Double(nullable: false),
                    Socket_63 = c.Double(nullable: false),
                    Socket_64 = c.Double(nullable: false),
                    Type_Test = c.String(nullable: false, maxLength: 200),
                    Start_Test = c.DateTime(nullable: false),
                    End_Test = c.DateTime(nullable: false),
                    BB_Temperature = c.Int(nullable: false),
                    Temperature = c.Double(nullable: false),
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Jig_ID = c.String(nullable: false, maxLength: 128),
                    Machine_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .ForeignKey("dbo.M_JIG", t => t.Jig_ID)
                .ForeignKey("dbo.M_MACHINE_TESTER", t => t.Machine_ID)
                .Index(t => t.PO_Number)
                .Index(t => t.Jig_ID)
                .Index(t => t.Machine_ID);

            CreateTable(
                "dbo.T_NOISE_TEST_DATA_MASTER",
                c => new
                {
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Type_Test = c.String(nullable: false, maxLength: 250),
                    Device_ID = c.String(nullable: false, maxLength: 128),
                    User_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.PO_Number)
                .ForeignKey("dbo.M_DEVICE", t => t.Device_ID)
                .ForeignKey("dbo.M_USER", t => t.User_ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .Index(t => t.PO_Number)
                .Index(t => t.Device_ID)
                .Index(t => t.User_ID);

            CreateTable(
                "dbo.T_NOISE_TEST_DATA_STATUS",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Socket_1 = c.String(nullable: false, maxLength: 100),
                    Socket_2 = c.String(nullable: false, maxLength: 100),
                    Socket_3 = c.String(nullable: false, maxLength: 100),
                    Socket_4 = c.String(nullable: false, maxLength: 100),
                    Socket_5 = c.String(nullable: false, maxLength: 100),
                    Socket_6 = c.String(nullable: false, maxLength: 100),
                    Socket_7 = c.String(nullable: false, maxLength: 100),
                    Socket_8 = c.String(nullable: false, maxLength: 100),
                    Socket_9 = c.String(nullable: false, maxLength: 100),
                    Socket_10 = c.String(nullable: false, maxLength: 100),
                    Socket_11 = c.String(nullable: false, maxLength: 100),
                    Socket_12 = c.String(nullable: false, maxLength: 100),
                    Socket_13 = c.String(nullable: false, maxLength: 100),
                    Socket_14 = c.String(nullable: false, maxLength: 100),
                    Socket_15 = c.String(nullable: false, maxLength: 100),
                    Socket_16 = c.String(nullable: false, maxLength: 100),
                    Socket_17 = c.String(nullable: false, maxLength: 100),
                    Socket_18 = c.String(nullable: false, maxLength: 100),
                    Socket_19 = c.String(nullable: false, maxLength: 100),
                    Socket_20 = c.String(nullable: false, maxLength: 100),
                    Socket_21 = c.String(nullable: false, maxLength: 100),
                    Socket_22 = c.String(nullable: false, maxLength: 100),
                    Socket_23 = c.String(nullable: false, maxLength: 100),
                    Socket_24 = c.String(nullable: false, maxLength: 100),
                    Socket_25 = c.String(nullable: false, maxLength: 100),
                    Socket_26 = c.String(nullable: false, maxLength: 100),
                    Socket_27 = c.String(nullable: false, maxLength: 100),
                    Socket_28 = c.String(nullable: false, maxLength: 100),
                    Socket_29 = c.String(nullable: false, maxLength: 100),
                    Socket_30 = c.String(nullable: false, maxLength: 100),
                    Socket_31 = c.String(nullable: false, maxLength: 100),
                    Socket_32 = c.String(nullable: false, maxLength: 100),
                    Socket_33 = c.String(nullable: false, maxLength: 100),
                    Socket_34 = c.String(nullable: false, maxLength: 100),
                    Socket_35 = c.String(nullable: false, maxLength: 100),
                    Socket_36 = c.String(nullable: false, maxLength: 100),
                    Socket_37 = c.String(nullable: false, maxLength: 100),
                    Socket_38 = c.String(nullable: false, maxLength: 100),
                    Socket_39 = c.String(nullable: false, maxLength: 100),
                    Socket_40 = c.String(nullable: false, maxLength: 100),
                    Socket_41 = c.String(nullable: false, maxLength: 100),
                    Socket_42 = c.String(nullable: false, maxLength: 100),
                    Socket_43 = c.String(nullable: false, maxLength: 100),
                    Socket_44 = c.String(nullable: false, maxLength: 100),
                    Socket_45 = c.String(nullable: false, maxLength: 100),
                    Socket_46 = c.String(nullable: false, maxLength: 100),
                    Socket_47 = c.String(nullable: false, maxLength: 100),
                    Socket_48 = c.String(nullable: false, maxLength: 100),
                    Socket_49 = c.String(nullable: false, maxLength: 100),
                    Socket_50 = c.String(nullable: false, maxLength: 100),
                    Socket_51 = c.String(nullable: false, maxLength: 100),
                    Socket_52 = c.String(nullable: false, maxLength: 100),
                    Socket_53 = c.String(nullable: false, maxLength: 100),
                    Socket_54 = c.String(nullable: false, maxLength: 100),
                    Socket_55 = c.String(nullable: false, maxLength: 100),
                    Socket_56 = c.String(nullable: false, maxLength: 100),
                    Socket_57 = c.String(nullable: false, maxLength: 100),
                    Socket_58 = c.String(nullable: false, maxLength: 100),
                    Socket_59 = c.String(nullable: false, maxLength: 100),
                    Socket_60 = c.String(nullable: false, maxLength: 100),
                    Socket_61 = c.String(nullable: false, maxLength: 100),
                    Socket_62 = c.String(nullable: false, maxLength: 100),
                    Socket_63 = c.String(nullable: false, maxLength: 100),
                    Socket_64 = c.String(nullable: false, maxLength: 100),
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Jig_ID = c.String(nullable: false, maxLength: 128),
                    Machine_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .ForeignKey("dbo.M_JIG", t => t.Jig_ID)
                .ForeignKey("dbo.M_MACHINE_TESTER", t => t.Machine_ID)
                .Index(t => t.PO_Number)
                .Index(t => t.Jig_ID)
                .Index(t => t.Machine_ID);

            CreateTable(
                "dbo.T_RESISTANCE_TEST_DATA_DETAIL",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Cooling_Plate_Temperature = c.Double(nullable: false),
                    Socket_1 = c.Double(nullable: false),
                    Socket_2 = c.Double(nullable: false),
                    Socket_3 = c.Double(nullable: false),
                    Socket_4 = c.Double(nullable: false),
                    Socket_5 = c.Double(nullable: false),
                    Socket_6 = c.Double(nullable: false),
                    Socket_7 = c.Double(nullable: false),
                    Socket_8 = c.Double(nullable: false),
                    Socket_9 = c.Double(nullable: false),
                    Socket_10 = c.Double(nullable: false),
                    Socket_11 = c.Double(nullable: false),
                    Socket_12 = c.Double(nullable: false),
                    Socket_13 = c.Double(nullable: false),
                    Socket_14 = c.Double(nullable: false),
                    Socket_15 = c.Double(nullable: false),
                    Socket_16 = c.Double(nullable: false),
                    Socket_17 = c.Double(nullable: false),
                    Socket_18 = c.Double(nullable: false),
                    Socket_19 = c.Double(nullable: false),
                    Socket_20 = c.Double(nullable: false),
                    Socket_21 = c.Double(nullable: false),
                    Socket_22 = c.Double(nullable: false),
                    Socket_23 = c.Double(nullable: false),
                    Socket_24 = c.Double(nullable: false),
                    Socket_25 = c.Double(nullable: false),
                    Socket_26 = c.Double(nullable: false),
                    Socket_27 = c.Double(nullable: false),
                    Socket_28 = c.Double(nullable: false),
                    Socket_29 = c.Double(nullable: false),
                    Socket_30 = c.Double(nullable: false),
                    Socket_31 = c.Double(nullable: false),
                    Socket_32 = c.Double(nullable: false),
                    Socket_33 = c.Double(nullable: false),
                    Socket_34 = c.Double(nullable: false),
                    Socket_35 = c.Double(nullable: false),
                    Socket_36 = c.Double(nullable: false),
                    Socket_37 = c.Double(nullable: false),
                    Socket_38 = c.Double(nullable: false),
                    Socket_39 = c.Double(nullable: false),
                    Socket_40 = c.Double(nullable: false),
                    Socket_41 = c.Double(nullable: false),
                    Socket_42 = c.Double(nullable: false),
                    Socket_43 = c.Double(nullable: false),
                    Socket_44 = c.Double(nullable: false),
                    Socket_45 = c.Double(nullable: false),
                    Socket_46 = c.Double(nullable: false),
                    Socket_47 = c.Double(nullable: false),
                    Socket_48 = c.Double(nullable: false),
                    Socket_49 = c.Double(nullable: false),
                    Socket_50 = c.Double(nullable: false),
                    Socket_51 = c.Double(nullable: false),
                    Socket_52 = c.Double(nullable: false),
                    Socket_53 = c.Double(nullable: false),
                    Socket_54 = c.Double(nullable: false),
                    Socket_55 = c.Double(nullable: false),
                    Socket_56 = c.Double(nullable: false),
                    Socket_57 = c.Double(nullable: false),
                    Socket_58 = c.Double(nullable: false),
                    Socket_59 = c.Double(nullable: false),
                    Socket_60 = c.Double(nullable: false),
                    Socket_61 = c.Double(nullable: false),
                    Socket_62 = c.Double(nullable: false),
                    Socket_63 = c.Double(nullable: false),
                    Socket_64 = c.Double(nullable: false),
                    Type_Test = c.String(nullable: false, maxLength: 200),
                    Start_Test = c.DateTime(nullable: false),
                    End_Test = c.DateTime(nullable: false),
                    BB_Temperature = c.Int(nullable: false),
                    Temperature = c.Double(nullable: false),
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Jig_ID = c.String(nullable: false, maxLength: 128),
                    Machine_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .ForeignKey("dbo.M_JIG", t => t.Jig_ID)
                .ForeignKey("dbo.M_MACHINE_TESTER", t => t.Machine_ID)
                .Index(t => t.PO_Number)
                .Index(t => t.Jig_ID)
                .Index(t => t.Machine_ID);

            CreateTable(
                "dbo.T_RESISTANCE_TEST_DATA_MASTER",
                c => new
                {
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Device_ID = c.String(nullable: false, maxLength: 128),
                    User_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.PO_Number)
                .ForeignKey("dbo.M_DEVICE", t => t.Device_ID)
                .ForeignKey("dbo.M_USER", t => t.User_ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .Index(t => t.PO_Number)
                .Index(t => t.Device_ID)
                .Index(t => t.User_ID);

            CreateTable(
                "dbo.T_RESISTANCE_TEST_DATA_STATUS",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Socket_1 = c.String(nullable: false, maxLength: 100),
                    Socket_2 = c.String(nullable: false, maxLength: 100),
                    Socket_3 = c.String(nullable: false, maxLength: 100),
                    Socket_4 = c.String(nullable: false, maxLength: 100),
                    Socket_5 = c.String(nullable: false, maxLength: 100),
                    Socket_6 = c.String(nullable: false, maxLength: 100),
                    Socket_7 = c.String(nullable: false, maxLength: 100),
                    Socket_8 = c.String(nullable: false, maxLength: 100),
                    Socket_9 = c.String(nullable: false, maxLength: 100),
                    Socket_10 = c.String(nullable: false, maxLength: 100),
                    Socket_11 = c.String(nullable: false, maxLength: 100),
                    Socket_12 = c.String(nullable: false, maxLength: 100),
                    Socket_13 = c.String(nullable: false, maxLength: 100),
                    Socket_14 = c.String(nullable: false, maxLength: 100),
                    Socket_15 = c.String(nullable: false, maxLength: 100),
                    Socket_16 = c.String(nullable: false, maxLength: 100),
                    Socket_17 = c.String(nullable: false, maxLength: 100),
                    Socket_18 = c.String(nullable: false, maxLength: 100),
                    Socket_19 = c.String(nullable: false, maxLength: 100),
                    Socket_20 = c.String(nullable: false, maxLength: 100),
                    Socket_21 = c.String(nullable: false, maxLength: 100),
                    Socket_22 = c.String(nullable: false, maxLength: 100),
                    Socket_23 = c.String(nullable: false, maxLength: 100),
                    Socket_24 = c.String(nullable: false, maxLength: 100),
                    Socket_25 = c.String(nullable: false, maxLength: 100),
                    Socket_26 = c.String(nullable: false, maxLength: 100),
                    Socket_27 = c.String(nullable: false, maxLength: 100),
                    Socket_28 = c.String(nullable: false, maxLength: 100),
                    Socket_29 = c.String(nullable: false, maxLength: 100),
                    Socket_30 = c.String(nullable: false, maxLength: 100),
                    Socket_31 = c.String(nullable: false, maxLength: 100),
                    Socket_32 = c.String(nullable: false, maxLength: 100),
                    Socket_33 = c.String(nullable: false, maxLength: 100),
                    Socket_34 = c.String(nullable: false, maxLength: 100),
                    Socket_35 = c.String(nullable: false, maxLength: 100),
                    Socket_36 = c.String(nullable: false, maxLength: 100),
                    Socket_37 = c.String(nullable: false, maxLength: 100),
                    Socket_38 = c.String(nullable: false, maxLength: 100),
                    Socket_39 = c.String(nullable: false, maxLength: 100),
                    Socket_40 = c.String(nullable: false, maxLength: 100),
                    Socket_41 = c.String(nullable: false, maxLength: 100),
                    Socket_42 = c.String(nullable: false, maxLength: 100),
                    Socket_43 = c.String(nullable: false, maxLength: 100),
                    Socket_44 = c.String(nullable: false, maxLength: 100),
                    Socket_45 = c.String(nullable: false, maxLength: 100),
                    Socket_46 = c.String(nullable: false, maxLength: 100),
                    Socket_47 = c.String(nullable: false, maxLength: 100),
                    Socket_48 = c.String(nullable: false, maxLength: 100),
                    Socket_49 = c.String(nullable: false, maxLength: 100),
                    Socket_50 = c.String(nullable: false, maxLength: 100),
                    Socket_51 = c.String(nullable: false, maxLength: 100),
                    Socket_52 = c.String(nullable: false, maxLength: 100),
                    Socket_53 = c.String(nullable: false, maxLength: 100),
                    Socket_54 = c.String(nullable: false, maxLength: 100),
                    Socket_55 = c.String(nullable: false, maxLength: 100),
                    Socket_56 = c.String(nullable: false, maxLength: 100),
                    Socket_57 = c.String(nullable: false, maxLength: 100),
                    Socket_58 = c.String(nullable: false, maxLength: 100),
                    Socket_59 = c.String(nullable: false, maxLength: 100),
                    Socket_60 = c.String(nullable: false, maxLength: 100),
                    Socket_61 = c.String(nullable: false, maxLength: 100),
                    Socket_62 = c.String(nullable: false, maxLength: 100),
                    Socket_63 = c.String(nullable: false, maxLength: 100),
                    Socket_64 = c.String(nullable: false, maxLength: 100),
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Jig_ID = c.String(nullable: false, maxLength: 128),
                    Machine_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .ForeignKey("dbo.M_JIG", t => t.Jig_ID)
                .ForeignKey("dbo.M_MACHINE_TESTER", t => t.Machine_ID)
                .Index(t => t.PO_Number)
                .Index(t => t.Jig_ID)
                .Index(t => t.Machine_ID);

            CreateTable(
                "dbo.T_SIGNAL_TEST_DATA_DETAIL",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Cooling_Plate_Temperature = c.Double(nullable: false),
                    Socket_1 = c.Double(nullable: false),
                    Socket_2 = c.Double(nullable: false),
                    Socket_3 = c.Double(nullable: false),
                    Socket_4 = c.Double(nullable: false),
                    Socket_5 = c.Double(nullable: false),
                    Socket_6 = c.Double(nullable: false),
                    Socket_7 = c.Double(nullable: false),
                    Socket_8 = c.Double(nullable: false),
                    Socket_9 = c.Double(nullable: false),
                    Socket_10 = c.Double(nullable: false),
                    Socket_11 = c.Double(nullable: false),
                    Socket_12 = c.Double(nullable: false),
                    Socket_13 = c.Double(nullable: false),
                    Socket_14 = c.Double(nullable: false),
                    Socket_15 = c.Double(nullable: false),
                    Socket_16 = c.Double(nullable: false),
                    Socket_17 = c.Double(nullable: false),
                    Socket_18 = c.Double(nullable: false),
                    Socket_19 = c.Double(nullable: false),
                    Socket_20 = c.Double(nullable: false),
                    Socket_21 = c.Double(nullable: false),
                    Socket_22 = c.Double(nullable: false),
                    Socket_23 = c.Double(nullable: false),
                    Socket_24 = c.Double(nullable: false),
                    Socket_25 = c.Double(nullable: false),
                    Socket_26 = c.Double(nullable: false),
                    Socket_27 = c.Double(nullable: false),
                    Socket_28 = c.Double(nullable: false),
                    Socket_29 = c.Double(nullable: false),
                    Socket_30 = c.Double(nullable: false),
                    Socket_31 = c.Double(nullable: false),
                    Socket_32 = c.Double(nullable: false),
                    Socket_33 = c.Double(nullable: false),
                    Socket_34 = c.Double(nullable: false),
                    Socket_35 = c.Double(nullable: false),
                    Socket_36 = c.Double(nullable: false),
                    Socket_37 = c.Double(nullable: false),
                    Socket_38 = c.Double(nullable: false),
                    Socket_39 = c.Double(nullable: false),
                    Socket_40 = c.Double(nullable: false),
                    Socket_41 = c.Double(nullable: false),
                    Socket_42 = c.Double(nullable: false),
                    Socket_43 = c.Double(nullable: false),
                    Socket_44 = c.Double(nullable: false),
                    Socket_45 = c.Double(nullable: false),
                    Socket_46 = c.Double(nullable: false),
                    Socket_47 = c.Double(nullable: false),
                    Socket_48 = c.Double(nullable: false),
                    Socket_49 = c.Double(nullable: false),
                    Socket_50 = c.Double(nullable: false),
                    Socket_51 = c.Double(nullable: false),
                    Socket_52 = c.Double(nullable: false),
                    Socket_53 = c.Double(nullable: false),
                    Socket_54 = c.Double(nullable: false),
                    Socket_55 = c.Double(nullable: false),
                    Socket_56 = c.Double(nullable: false),
                    Socket_57 = c.Double(nullable: false),
                    Socket_58 = c.Double(nullable: false),
                    Socket_59 = c.Double(nullable: false),
                    Socket_60 = c.Double(nullable: false),
                    Socket_61 = c.Double(nullable: false),
                    Socket_62 = c.Double(nullable: false),
                    Socket_63 = c.Double(nullable: false),
                    Socket_64 = c.Double(nullable: false),
                    Type_Test = c.String(nullable: false, maxLength: 200),
                    Start_Test = c.DateTime(nullable: false),
                    End_Test = c.DateTime(nullable: false),
                    BB_Temperature = c.Int(nullable: false),
                    Temperature = c.Double(nullable: false),
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Jig_ID = c.String(nullable: false, maxLength: 128),
                    Machine_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .ForeignKey("dbo.M_JIG", t => t.Jig_ID)
                .ForeignKey("dbo.M_MACHINE_TESTER", t => t.Machine_ID)
                .Index(t => t.PO_Number)
                .Index(t => t.Jig_ID)
                .Index(t => t.Machine_ID);

            CreateTable(
                "dbo.T_SIGNAL_TEST_DATA_MASTER",
                c => new
                {
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Device_ID = c.String(nullable: false, maxLength: 128),
                    User_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.PO_Number)
                .ForeignKey("dbo.M_DEVICE", t => t.Device_ID)
                .ForeignKey("dbo.M_USER", t => t.User_ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .Index(t => t.PO_Number)
                .Index(t => t.Device_ID)
                .Index(t => t.User_ID);

            CreateTable(
                "dbo.T_SIGNAL_TEST_DATA_STATUS",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Socket_1 = c.String(nullable: false, maxLength: 100),
                    Socket_2 = c.String(nullable: false, maxLength: 100),
                    Socket_3 = c.String(nullable: false, maxLength: 100),
                    Socket_4 = c.String(nullable: false, maxLength: 100),
                    Socket_5 = c.String(nullable: false, maxLength: 100),
                    Socket_6 = c.String(nullable: false, maxLength: 100),
                    Socket_7 = c.String(nullable: false, maxLength: 100),
                    Socket_8 = c.String(nullable: false, maxLength: 100),
                    Socket_9 = c.String(nullable: false, maxLength: 100),
                    Socket_10 = c.String(nullable: false, maxLength: 100),
                    Socket_11 = c.String(nullable: false, maxLength: 100),
                    Socket_12 = c.String(nullable: false, maxLength: 100),
                    Socket_13 = c.String(nullable: false, maxLength: 100),
                    Socket_14 = c.String(nullable: false, maxLength: 100),
                    Socket_15 = c.String(nullable: false, maxLength: 100),
                    Socket_16 = c.String(nullable: false, maxLength: 100),
                    Socket_17 = c.String(nullable: false, maxLength: 100),
                    Socket_18 = c.String(nullable: false, maxLength: 100),
                    Socket_19 = c.String(nullable: false, maxLength: 100),
                    Socket_20 = c.String(nullable: false, maxLength: 100),
                    Socket_21 = c.String(nullable: false, maxLength: 100),
                    Socket_22 = c.String(nullable: false, maxLength: 100),
                    Socket_23 = c.String(nullable: false, maxLength: 100),
                    Socket_24 = c.String(nullable: false, maxLength: 100),
                    Socket_25 = c.String(nullable: false, maxLength: 100),
                    Socket_26 = c.String(nullable: false, maxLength: 100),
                    Socket_27 = c.String(nullable: false, maxLength: 100),
                    Socket_28 = c.String(nullable: false, maxLength: 100),
                    Socket_29 = c.String(nullable: false, maxLength: 100),
                    Socket_30 = c.String(nullable: false, maxLength: 100),
                    Socket_31 = c.String(nullable: false, maxLength: 100),
                    Socket_32 = c.String(nullable: false, maxLength: 100),
                    Socket_33 = c.String(nullable: false, maxLength: 100),
                    Socket_34 = c.String(nullable: false, maxLength: 100),
                    Socket_35 = c.String(nullable: false, maxLength: 100),
                    Socket_36 = c.String(nullable: false, maxLength: 100),
                    Socket_37 = c.String(nullable: false, maxLength: 100),
                    Socket_38 = c.String(nullable: false, maxLength: 100),
                    Socket_39 = c.String(nullable: false, maxLength: 100),
                    Socket_40 = c.String(nullable: false, maxLength: 100),
                    Socket_41 = c.String(nullable: false, maxLength: 100),
                    Socket_42 = c.String(nullable: false, maxLength: 100),
                    Socket_43 = c.String(nullable: false, maxLength: 100),
                    Socket_44 = c.String(nullable: false, maxLength: 100),
                    Socket_45 = c.String(nullable: false, maxLength: 100),
                    Socket_46 = c.String(nullable: false, maxLength: 100),
                    Socket_47 = c.String(nullable: false, maxLength: 100),
                    Socket_48 = c.String(nullable: false, maxLength: 100),
                    Socket_49 = c.String(nullable: false, maxLength: 100),
                    Socket_50 = c.String(nullable: false, maxLength: 100),
                    Socket_51 = c.String(nullable: false, maxLength: 100),
                    Socket_52 = c.String(nullable: false, maxLength: 100),
                    Socket_53 = c.String(nullable: false, maxLength: 100),
                    Socket_54 = c.String(nullable: false, maxLength: 100),
                    Socket_55 = c.String(nullable: false, maxLength: 100),
                    Socket_56 = c.String(nullable: false, maxLength: 100),
                    Socket_57 = c.String(nullable: false, maxLength: 100),
                    Socket_58 = c.String(nullable: false, maxLength: 100),
                    Socket_59 = c.String(nullable: false, maxLength: 100),
                    Socket_60 = c.String(nullable: false, maxLength: 100),
                    Socket_61 = c.String(nullable: false, maxLength: 100),
                    Socket_62 = c.String(nullable: false, maxLength: 100),
                    Socket_63 = c.String(nullable: false, maxLength: 100),
                    Socket_64 = c.String(nullable: false, maxLength: 100),
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Jig_ID = c.String(nullable: false, maxLength: 128),
                    Machine_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .ForeignKey("dbo.M_JIG", t => t.Jig_ID)
                .ForeignKey("dbo.M_MACHINE_TESTER", t => t.Machine_ID)
                .Index(t => t.PO_Number)
                .Index(t => t.Jig_ID)
                .Index(t => t.Machine_ID);

            CreateTable(
                "dbo.T_SORTER_RESULT",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Socket_1 = c.String(nullable: false, maxLength: 100),
                    Socket_2 = c.String(nullable: false, maxLength: 100),
                    Socket_3 = c.String(nullable: false, maxLength: 100),
                    Socket_4 = c.String(nullable: false, maxLength: 100),
                    Socket_5 = c.String(nullable: false, maxLength: 100),
                    Socket_6 = c.String(nullable: false, maxLength: 100),
                    Socket_7 = c.String(nullable: false, maxLength: 100),
                    Socket_8 = c.String(nullable: false, maxLength: 100),
                    Socket_9 = c.String(nullable: false, maxLength: 100),
                    Socket_10 = c.String(nullable: false, maxLength: 100),
                    Socket_11 = c.String(nullable: false, maxLength: 100),
                    Socket_12 = c.String(nullable: false, maxLength: 100),
                    Socket_13 = c.String(nullable: false, maxLength: 100),
                    Socket_14 = c.String(nullable: false, maxLength: 100),
                    Socket_15 = c.String(nullable: false, maxLength: 100),
                    Socket_16 = c.String(nullable: false, maxLength: 100),
                    Socket_17 = c.String(nullable: false, maxLength: 100),
                    Socket_18 = c.String(nullable: false, maxLength: 100),
                    Socket_19 = c.String(nullable: false, maxLength: 100),
                    Socket_20 = c.String(nullable: false, maxLength: 100),
                    Socket_21 = c.String(nullable: false, maxLength: 100),
                    Socket_22 = c.String(nullable: false, maxLength: 100),
                    Socket_23 = c.String(nullable: false, maxLength: 100),
                    Socket_24 = c.String(nullable: false, maxLength: 100),
                    Socket_25 = c.String(nullable: false, maxLength: 100),
                    Socket_26 = c.String(nullable: false, maxLength: 100),
                    Socket_27 = c.String(nullable: false, maxLength: 100),
                    Socket_28 = c.String(nullable: false, maxLength: 100),
                    Socket_29 = c.String(nullable: false, maxLength: 100),
                    Socket_30 = c.String(nullable: false, maxLength: 100),
                    Socket_31 = c.String(nullable: false, maxLength: 100),
                    Socket_32 = c.String(nullable: false, maxLength: 100),
                    Socket_33 = c.String(nullable: false, maxLength: 100),
                    Socket_34 = c.String(nullable: false, maxLength: 100),
                    Socket_35 = c.String(nullable: false, maxLength: 100),
                    Socket_36 = c.String(nullable: false, maxLength: 100),
                    Socket_37 = c.String(nullable: false, maxLength: 100),
                    Socket_38 = c.String(nullable: false, maxLength: 100),
                    Socket_39 = c.String(nullable: false, maxLength: 100),
                    Socket_40 = c.String(nullable: false, maxLength: 100),
                    Socket_41 = c.String(nullable: false, maxLength: 100),
                    Socket_42 = c.String(nullable: false, maxLength: 100),
                    Socket_43 = c.String(nullable: false, maxLength: 100),
                    Socket_44 = c.String(nullable: false, maxLength: 100),
                    Socket_45 = c.String(nullable: false, maxLength: 100),
                    Socket_46 = c.String(nullable: false, maxLength: 100),
                    Socket_47 = c.String(nullable: false, maxLength: 100),
                    Socket_48 = c.String(nullable: false, maxLength: 100),
                    Socket_49 = c.String(nullable: false, maxLength: 100),
                    Socket_50 = c.String(nullable: false, maxLength: 100),
                    Socket_51 = c.String(nullable: false, maxLength: 100),
                    Socket_52 = c.String(nullable: false, maxLength: 100),
                    Socket_53 = c.String(nullable: false, maxLength: 100),
                    Socket_54 = c.String(nullable: false, maxLength: 100),
                    Socket_55 = c.String(nullable: false, maxLength: 100),
                    Socket_56 = c.String(nullable: false, maxLength: 100),
                    Socket_57 = c.String(nullable: false, maxLength: 100),
                    Socket_58 = c.String(nullable: false, maxLength: 100),
                    Socket_59 = c.String(nullable: false, maxLength: 100),
                    Socket_60 = c.String(nullable: false, maxLength: 100),
                    Socket_61 = c.String(nullable: false, maxLength: 100),
                    Socket_62 = c.String(nullable: false, maxLength: 100),
                    Socket_63 = c.String(nullable: false, maxLength: 100),
                    Socket_64 = c.String(nullable: false, maxLength: 100),
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Jig_ID = c.String(nullable: false, maxLength: 128),
                    Machine_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_JIG", t => t.Jig_ID)
                .ForeignKey("dbo.M_MACHINE_TESTER", t => t.Machine_ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .Index(t => t.PO_Number)
                .Index(t => t.Jig_ID)
                .Index(t => t.Machine_ID);

            CreateTable(
                "dbo.T_SORTER_SUMMARY",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    PO_Number = c.String(maxLength: 50),
                    Qty_Pass = c.Int(nullable: false),
                    Qty_Downgrade = c.Int(nullable: false),
                    Qty_Reject = c.Int(nullable: false),
                    Qty_NG1 = c.Int(nullable: false),
                    Qty_NG2 = c.Int(nullable: false),
                    Qty_NG3 = c.Int(nullable: false),
                    Qty_NG4 = c.Int(nullable: false),
                    Qty_NG5 = c.Int(nullable: false),
                    Qty_NG6 = c.Int(nullable: false),
                    Qty_NG7 = c.Int(nullable: false),
                    Qty_NG_Other = c.Int(nullable: false),
                    Qty_NOD = c.Int(nullable: false),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .Index(t => t.PO_Number);

            CreateTable(
                "dbo.T_TRANSACTION_CANCEL",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    Superior_User_ID = c.String(nullable: false),
                    User_ID = c.String(nullable: false, maxLength: 128),
                    Reason = c.String(),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_USER", t => t.User_ID)
                .ForeignKey("dbo.T_TRANSACTION_INPUT", t => t.PO_Number)
                .Index(t => t.PO_Number)
                .Index(t => t.User_ID);

            CreateTable(
                "dbo.T_TRANSACTION_LASER",
                c => new
                {
                    PO_Number = c.String(nullable: false, maxLength: 50),
                    LotBox_Position = c.Int(nullable: false),
                    Quantity = c.Int(nullable: false),
                    LotBox_ID = c.String(maxLength: 100),
                    LotBox_NG_ID = c.String(maxLength: 100),
                    Device_ID = c.String(nullable: false, maxLength: 128),
                    User_ID = c.String(nullable: false, maxLength: 128),
                    Created_User = c.String(maxLength: 200),
                    Created_Date = c.DateTime(),
                    Updated_User = c.String(maxLength: 200),
                    Updated_Date = c.DateTime(),
                })
                .PrimaryKey(t => t.PO_Number)
                .ForeignKey("dbo.M_DEVICE", t => t.Device_ID)
                .ForeignKey("dbo.M_USER", t => t.User_ID)
                .Index(t => t.Device_ID)
                .Index(t => t.User_ID);

            CreateTable(
                "dbo.T_USER_SESSION",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    User_ID = c.String(nullable: false, maxLength: 128),
                    Session_ID = c.String(nullable: false, maxLength: 500),
                    Session_Token = c.String(nullable: false, maxLength: 500),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.M_USER", t => t.User_ID)
                .Index(t => t.User_ID);

            //CreateTable(
            //    "dbo.V_BOOKING_ROOM_MACHINE",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Line_Number = c.Int(nullable: false),
            //            Noise_Room_Number = c.Int(nullable: false),
            //            Machine_Noise = c.String(),
            //            Signal_Room_Number = c.Int(nullable: false),
            //            Machine_Signal = c.String(),
            //            Resistance_Room_Number = c.Int(nullable: false),
            //            Machine_Resistance = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_DEVICE_DEVICE_SIGNAL_PARAMETER",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Device_Name = c.String(),
            //            Device_ID = c.String(),
            //            No_DUT_Offset = c.Double(nullable: false),
            //            Offset_Min = c.Double(nullable: false),
            //            Offset_Max = c.Double(nullable: false),
            //            Offset_HLimit = c.Double(nullable: false),
            //            Offset_Grp_Min = c.Double(nullable: false),
            //            Offset_Grp_Max = c.Double(nullable: false),
            //            No_Response = c.Double(nullable: false),
            //            Response_Min = c.Double(nullable: false),
            //            Response_Max = c.Double(nullable: false),
            //            Response_Grp_Min = c.Double(nullable: false),
            //            Response_Grp_Max = c.Double(nullable: false),
            //            Match_Correlation_Factor = c.Double(nullable: false),
            //            Match_Signal_Max = c.Double(),
            //            Resistance_Min = c.Double(nullable: false),
            //            First_Soak_Time = c.Int(nullable: false),
            //            Second_Soak_Time = c.Int(nullable: false),
            //            Lauda_Setting = c.Int(nullable: false),
            //            BB_Setting = c.Int(nullable: false),
            //            BB_Temperature_HL = c.Int(nullable: false),
            //            BB_Temperature_LL = c.Int(nullable: false),
            //            Sample_Rate = c.Int(nullable: false),
            //            High_Cutof_Frequency = c.Double(nullable: false),
            //            Low_Cutof_Frequency = c.Double(nullable: false),
            //            Measurement_Duration = c.Int(nullable: false),
            //            Measurement_Duration_2 = c.Double(nullable: false),
            //            Temperature_Coe = c.Double(nullable: false),
            //            Testing_Voltage = c.Double(nullable: false),
            //            Resistance = c.Double(nullable: false),
            //            Created_User = c.String(),
            //            Created_Date = c.DateTime(nullable: false),
            //            Updated_User = c.String(),
            //            Updated_Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_ERROR_LIST",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Error_Code = c.String(),
            //            Hardware_ID = c.String(),
            //            Status = c.String(),
            //            Created_Date = c.DateTime(),
            //            Error_Name = c.String(),
            //            Impact = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_JIG_JIG_CLOSE_SOCKET",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Jig_ID = c.String(),
            //            Jig_Carrier_Name = c.String(),
            //            Created_User = c.String(),
            //            Created_Date = c.DateTime(nullable: false),
            //            Updated_User = c.String(),
            //            Updated_Date = c.DateTime(nullable: false),
            //            Socket_1 = c.Boolean(nullable: false),
            //            Socket_2 = c.Boolean(nullable: false),
            //            Socket_3 = c.Boolean(nullable: false),
            //            Socket_4 = c.Boolean(nullable: false),
            //            Socket_5 = c.Boolean(nullable: false),
            //            Socket_6 = c.Boolean(nullable: false),
            //            Socket_7 = c.Boolean(nullable: false),
            //            Socket_8 = c.Boolean(nullable: false),
            //            Socket_9 = c.Boolean(nullable: false),
            //            Socket_10 = c.Boolean(nullable: false),
            //            Socket_11 = c.Boolean(nullable: false),
            //            Socket_12 = c.Boolean(nullable: false),
            //            Socket_13 = c.Boolean(nullable: false),
            //            Socket_14 = c.Boolean(nullable: false),
            //            Socket_15 = c.Boolean(nullable: false),
            //            Socket_16 = c.Boolean(nullable: false),
            //            Socket_17 = c.Boolean(nullable: false),
            //            Socket_18 = c.Boolean(nullable: false),
            //            Socket_19 = c.Boolean(nullable: false),
            //            Socket_20 = c.Boolean(nullable: false),
            //            Socket_21 = c.Boolean(nullable: false),
            //            Socket_22 = c.Boolean(nullable: false),
            //            Socket_23 = c.Boolean(nullable: false),
            //            Socket_24 = c.Boolean(nullable: false),
            //            Socket_25 = c.Boolean(nullable: false),
            //            Socket_26 = c.Boolean(nullable: false),
            //            Socket_27 = c.Boolean(nullable: false),
            //            Socket_28 = c.Boolean(nullable: false),
            //            Socket_29 = c.Boolean(nullable: false),
            //            Socket_30 = c.Boolean(nullable: false),
            //            Socket_31 = c.Boolean(nullable: false),
            //            Socket_32 = c.Boolean(nullable: false),
            //            Socket_33 = c.Boolean(nullable: false),
            //            Socket_34 = c.Boolean(nullable: false),
            //            Socket_35 = c.Boolean(nullable: false),
            //            Socket_36 = c.Boolean(nullable: false),
            //            Socket_37 = c.Boolean(nullable: false),
            //            Socket_38 = c.Boolean(nullable: false),
            //            Socket_39 = c.Boolean(nullable: false),
            //            Socket_40 = c.Boolean(nullable: false),
            //            Socket_41 = c.Boolean(nullable: false),
            //            Socket_42 = c.Boolean(nullable: false),
            //            Socket_43 = c.Boolean(nullable: false),
            //            Socket_44 = c.Boolean(nullable: false),
            //            Socket_45 = c.Boolean(nullable: false),
            //            Socket_46 = c.Boolean(nullable: false),
            //            Socket_47 = c.Boolean(nullable: false),
            //            Socket_48 = c.Boolean(nullable: false),
            //            Socket_49 = c.Boolean(nullable: false),
            //            Socket_50 = c.Boolean(nullable: false),
            //            Socket_51 = c.Boolean(nullable: false),
            //            Socket_52 = c.Boolean(nullable: false),
            //            Socket_53 = c.Boolean(nullable: false),
            //            Socket_54 = c.Boolean(nullable: false),
            //            Socket_55 = c.Boolean(nullable: false),
            //            Socket_56 = c.Boolean(nullable: false),
            //            Socket_57 = c.Boolean(nullable: false),
            //            Socket_58 = c.Boolean(nullable: false),
            //            Socket_59 = c.Boolean(nullable: false),
            //            Socket_60 = c.Boolean(nullable: false),
            //            Socket_61 = c.Boolean(nullable: false),
            //            Socket_62 = c.Boolean(nullable: false),
            //            Socket_63 = c.Boolean(nullable: false),
            //            Socket_64 = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_LASER_STATION",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            LotBox_ID = c.String(),
            //            LotBox_NG_ID = c.String(),
            //            Status = c.String(),
            //            Created_User = c.String(),
            //            Created_Date = c.DateTime(nullable: false),
            //            Updated_User = c.String(),
            //            Updated_Date = c.DateTime(nullable: false),
            //            LotBox_Position = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_MACHINE_CLOSE_SOCKET",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Machine_ID = c.String(),
            //            Socket_1 = c.Int(nullable: false),
            //            Socket_2 = c.Int(nullable: false),
            //            Socket_3 = c.Int(nullable: false),
            //            Socket_4 = c.Int(nullable: false),
            //            Socket_5 = c.Int(nullable: false),
            //            Socket_6 = c.Int(nullable: false),
            //            Socket_7 = c.Int(nullable: false),
            //            Socket_8 = c.Int(nullable: false),
            //            Socket_9 = c.Int(nullable: false),
            //            Socket_10 = c.Int(nullable: false),
            //            Socket_11 = c.Int(nullable: false),
            //            Socket_12 = c.Int(nullable: false),
            //            Socket_13 = c.Int(nullable: false),
            //            Socket_14 = c.Int(nullable: false),
            //            Socket_15 = c.Int(nullable: false),
            //            Socket_16 = c.Int(nullable: false),
            //            Socket_17 = c.Int(nullable: false),
            //            Socket_18 = c.Int(nullable: false),
            //            Socket_19 = c.Int(nullable: false),
            //            Socket_20 = c.Int(nullable: false),
            //            Socket_21 = c.Int(nullable: false),
            //            Socket_22 = c.Int(nullable: false),
            //            Socket_23 = c.Int(nullable: false),
            //            Socket_24 = c.Int(nullable: false),
            //            Socket_25 = c.Int(nullable: false),
            //            Socket_26 = c.Int(nullable: false),
            //            Socket_27 = c.Int(nullable: false),
            //            Socket_28 = c.Int(nullable: false),
            //            Socket_29 = c.Int(nullable: false),
            //            Socket_30 = c.Int(nullable: false),
            //            Socket_31 = c.Int(nullable: false),
            //            Socket_32 = c.Int(nullable: false),
            //            Socket_33 = c.Int(nullable: false),
            //            Socket_34 = c.Int(nullable: false),
            //            Socket_35 = c.Int(nullable: false),
            //            Socket_36 = c.Int(nullable: false),
            //            Socket_37 = c.Int(nullable: false),
            //            Socket_38 = c.Int(nullable: false),
            //            Socket_39 = c.Int(nullable: false),
            //            Socket_40 = c.Int(nullable: false),
            //            Socket_41 = c.Int(nullable: false),
            //            Socket_42 = c.Int(nullable: false),
            //            Socket_43 = c.Int(nullable: false),
            //            Socket_44 = c.Int(nullable: false),
            //            Socket_45 = c.Int(nullable: false),
            //            Socket_46 = c.Int(nullable: false),
            //            Socket_47 = c.Int(nullable: false),
            //            Socket_48 = c.Int(nullable: false),
            //            Socket_49 = c.Int(nullable: false),
            //            Socket_50 = c.Int(nullable: false),
            //            Socket_51 = c.Int(nullable: false),
            //            Socket_52 = c.Int(nullable: false),
            //            Socket_53 = c.Int(nullable: false),
            //            Socket_54 = c.Int(nullable: false),
            //            Socket_55 = c.Int(nullable: false),
            //            Socket_56 = c.Int(nullable: false),
            //            Socket_57 = c.Int(nullable: false),
            //            Socket_58 = c.Int(nullable: false),
            //            Socket_59 = c.Int(nullable: false),
            //            Socket_60 = c.Int(nullable: false),
            //            Socket_61 = c.Int(nullable: false),
            //            Socket_62 = c.Int(nullable: false),
            //            Socket_63 = c.Int(nullable: false),
            //            Socket_64 = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_MACHINE_MACHINE_CALIBRATION",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Machine_ID = c.String(),
            //            Machine_Name = c.String(),
            //            Calibration_Type = c.String(),
            //            Calibration_Type2 = c.String(),
            //            Socket_1 = c.Double(nullable: false),
            //            Socket_2 = c.Double(nullable: false),
            //            Socket_3 = c.Double(nullable: false),
            //            Socket_4 = c.Double(nullable: false),
            //            Socket_5 = c.Double(nullable: false),
            //            Socket_6 = c.Double(nullable: false),
            //            Socket_7 = c.Double(nullable: false),
            //            Socket_8 = c.Double(nullable: false),
            //            Socket_9 = c.Double(nullable: false),
            //            Socket_10 = c.Double(nullable: false),
            //            Socket_11 = c.Double(nullable: false),
            //            Socket_12 = c.Double(nullable: false),
            //            Socket_13 = c.Double(nullable: false),
            //            Socket_14 = c.Double(nullable: false),
            //            Socket_15 = c.Double(nullable: false),
            //            Socket_16 = c.Double(nullable: false),
            //            Socket_17 = c.Double(nullable: false),
            //            Socket_18 = c.Double(nullable: false),
            //            Socket_19 = c.Double(nullable: false),
            //            Socket_20 = c.Double(nullable: false),
            //            Socket_21 = c.Double(nullable: false),
            //            Socket_22 = c.Double(nullable: false),
            //            Socket_23 = c.Double(nullable: false),
            //            Socket_24 = c.Double(nullable: false),
            //            Socket_25 = c.Double(nullable: false),
            //            Socket_26 = c.Double(nullable: false),
            //            Socket_27 = c.Double(nullable: false),
            //            Socket_28 = c.Double(nullable: false),
            //            Socket_29 = c.Double(nullable: false),
            //            Socket_30 = c.Double(nullable: false),
            //            Socket_31 = c.Double(nullable: false),
            //            Socket_32 = c.Double(nullable: false),
            //            Socket_33 = c.Double(nullable: false),
            //            Socket_34 = c.Double(nullable: false),
            //            Socket_35 = c.Double(nullable: false),
            //            Socket_36 = c.Double(nullable: false),
            //            Socket_37 = c.Double(nullable: false),
            //            Socket_38 = c.Double(nullable: false),
            //            Socket_39 = c.Double(nullable: false),
            //            Socket_40 = c.Double(nullable: false),
            //            Socket_41 = c.Double(nullable: false),
            //            Socket_42 = c.Double(nullable: false),
            //            Socket_43 = c.Double(nullable: false),
            //            Socket_44 = c.Double(nullable: false),
            //            Socket_45 = c.Double(nullable: false),
            //            Socket_46 = c.Double(nullable: false),
            //            Socket_47 = c.Double(nullable: false),
            //            Socket_48 = c.Double(nullable: false),
            //            Socket_49 = c.Double(nullable: false),
            //            Socket_50 = c.Double(nullable: false),
            //            Socket_51 = c.Double(nullable: false),
            //            Socket_52 = c.Double(nullable: false),
            //            Socket_53 = c.Double(nullable: false),
            //            Socket_54 = c.Double(nullable: false),
            //            Socket_55 = c.Double(nullable: false),
            //            Socket_56 = c.Double(nullable: false),
            //            Socket_57 = c.Double(nullable: false),
            //            Socket_58 = c.Double(nullable: false),
            //            Socket_59 = c.Double(nullable: false),
            //            Socket_60 = c.Double(nullable: false),
            //            Socket_61 = c.Double(nullable: false),
            //            Socket_62 = c.Double(nullable: false),
            //            Socket_63 = c.Double(nullable: false),
            //            Socket_64 = c.Double(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Device_ID = c.String(),
            //            Device_Name = c.String(),
            //            Test_Type_ID = c.String(),
            //            Test_Type_Name = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_PONUMBER_DEVICE",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            PO_Number = c.String(),
            //            AQL_Reference = c.String(),
            //            Noise_Type_Parameter_Ref = c.String(),
            //            Signal_Device_ID_Ref = c.String(),
            //            Status = c.String(),
            //            Device_ID = c.String(),
            //            User_ID = c.String(),
            //            Start_Test = c.DateTime(nullable: false),
            //            End_Test = c.DateTime(nullable: false),
            //            Created_Date = c.DateTime(nullable: false),
            //            Quantity = c.Int(nullable: false),
            //            LotBox_Position_Fukuda = c.Int(nullable: false),
            //            LotBox_Position_Laser = c.Int(nullable: false),
            //            LotBox_ID = c.String(),
            //            Device_Name = c.String(),
            //            Device_Status = c.String(),
            //            Test_Mode_Default = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_PONUMBER_LOTBOX",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            PO_Number = c.String(),
            //            AQL_Reference = c.String(),
            //            Noise_Type_Parameter_Ref = c.String(),
            //            Signal_Device_ID_Ref = c.String(),
            //            Status = c.String(),
            //            Device_ID = c.String(),
            //            User_ID = c.String(),
            //            Created_User = c.String(),
            //            Created_Date = c.DateTime(nullable: false),
            //            Updated_User = c.String(),
            //            Updated_Date = c.DateTime(nullable: false),
            //            Start_Test = c.DateTime(nullable: false),
            //            End_Test = c.DateTime(nullable: false),
            //            Quantity = c.Int(nullable: false),
            //            LotBox_Position_Fukuda = c.Int(nullable: false),
            //            LotBox_ID = c.String(),
            //            LotBox_Position_Laser = c.Int(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_REPORT_SORTER_SUMMARY",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            PO_Number = c.String(),
            //            PO_Number_Barcode = c.Binary(),
            //            Qty_Pass = c.Int(nullable: false),
            //            Qty_Downgrade = c.Int(nullable: false),
            //            Qty_Reject = c.Int(nullable: false),
            //            Qty_NG1 = c.Int(nullable: false),
            //            Qty_NG2 = c.Int(nullable: false),
            //            Qty_NG3 = c.Int(nullable: false),
            //            Qty_NG4 = c.Int(nullable: false),
            //            Qty_NG5 = c.Int(nullable: false),
            //            Qty_NG6 = c.Int(nullable: false),
            //            Qty_NG7 = c.Int(nullable: false),
            //            Qty_NG_Other = c.Int(nullable: false),
            //            Qty_NOD = c.Int(nullable: false),
            //            Quantity = c.Int(nullable: false),
            //            LotBox_ID = c.String(),
            //            LotBox_Laser = c.String(),
            //            LotBox_NG_ID = c.String(),
            //            Device_ID = c.String(),
            //            Device_ID_Barcode = c.Binary(),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_TESTING_STATUS",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            TestType = c.String(),
            //            PO_Number = c.String(),
            //            Machine_ID = c.String(),
            //            Jig_ID = c.String(),
            //            Socket_1 = c.String(),
            //            Socket_2 = c.String(),
            //            Socket_3 = c.String(),
            //            Socket_4 = c.String(),
            //            Socket_5 = c.String(),
            //            Socket_6 = c.String(),
            //            Socket_7 = c.String(),
            //            Socket_8 = c.String(),
            //            Socket_9 = c.String(),
            //            Socket_10 = c.String(),
            //            Socket_11 = c.String(),
            //            Socket_12 = c.String(),
            //            Socket_13 = c.String(),
            //            Socket_14 = c.String(),
            //            Socket_15 = c.String(),
            //            Socket_16 = c.String(),
            //            Socket_17 = c.String(),
            //            Socket_18 = c.String(),
            //            Socket_19 = c.String(),
            //            Socket_20 = c.String(),
            //            Socket_21 = c.String(),
            //            Socket_22 = c.String(),
            //            Socket_23 = c.String(),
            //            Socket_24 = c.String(),
            //            Socket_25 = c.String(),
            //            Socket_26 = c.String(),
            //            Socket_27 = c.String(),
            //            Socket_28 = c.String(),
            //            Socket_29 = c.String(),
            //            Socket_30 = c.String(),
            //            Socket_31 = c.String(),
            //            Socket_32 = c.String(),
            //            Socket_33 = c.String(),
            //            Socket_34 = c.String(),
            //            Socket_35 = c.String(),
            //            Socket_36 = c.String(),
            //            Socket_37 = c.String(),
            //            Socket_38 = c.String(),
            //            Socket_39 = c.String(),
            //            Socket_40 = c.String(),
            //            Socket_41 = c.String(),
            //            Socket_42 = c.String(),
            //            Socket_43 = c.String(),
            //            Socket_44 = c.String(),
            //            Socket_45 = c.String(),
            //            Socket_46 = c.String(),
            //            Socket_47 = c.String(),
            //            Socket_48 = c.String(),
            //            Socket_49 = c.String(),
            //            Socket_50 = c.String(),
            //            Socket_51 = c.String(),
            //            Socket_52 = c.String(),
            //            Socket_53 = c.String(),
            //            Socket_54 = c.String(),
            //            Socket_55 = c.String(),
            //            Socket_56 = c.String(),
            //            Socket_57 = c.String(),
            //            Socket_58 = c.String(),
            //            Socket_59 = c.String(),
            //            Socket_60 = c.String(),
            //            Socket_61 = c.String(),
            //            Socket_62 = c.String(),
            //            Socket_63 = c.String(),
            //            Socket_64 = c.String(),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_USER_GROUP_PRIVILEGES",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Group_ID = c.String(),
            //            Group_Name = c.String(),
            //            Allow_Report = c.Boolean(nullable: false),
            //            Allow_Read = c.Boolean(nullable: false),
            //            Allow_Add = c.Boolean(nullable: false),
            //            Allow_Delete = c.Boolean(nullable: false),
            //            Allow_Edit = c.Boolean(nullable: false),
            //            Allow_Export = c.Boolean(nullable: false),
            //            Parent_ID = c.Int(),
            //            Detail = c.Boolean(nullable: false),
            //            Module = c.String(),
            //            Module_Parent = c.String(),
            //            Code = c.String(),
            //            Name = c.String(),
            //            Menu_For = c.String(),
            //            Is_Active = c.Boolean(nullable: false),
            //            Created_User = c.String(),
            //            Created_Date = c.DateTime(nullable: false),
            //            Updated_User = c.String(),
            //            Updated_Date = c.DateTime(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_USER_GROUP_PRIVILEGES_IS_SET",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Group_ID = c.String(),
            //            Group_Name = c.String(),
            //            Is_Set = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);

            //CreateTable(
            //    "dbo.V_USER_GROUP",
            //    c => new
            //        {
            //            ID = c.Int(nullable: false, identity: true),
            //            Created_User = c.String(),
            //            Created_Date = c.DateTime(nullable: false),
            //            User_ID = c.String(),
            //            Group_ID = c.String(),
            //            Group_Name = c.String(),
            //            Name = c.String(),
            //            Password = c.String(),
            //            New_Password = c.String(),
            //            Is_Active = c.Boolean(nullable: false),
            //        })
            //    .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.T_USER_SESSION", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_TRANSACTION_LASER", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_TRANSACTION_LASER", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.T_TRANSACTION_CANCEL", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_TRANSACTION_CANCEL", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_SORTER_SUMMARY", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_SORTER_RESULT", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_SORTER_RESULT", "Machine_ID", "dbo.M_MACHINE_TESTER");
            DropForeignKey("dbo.T_SORTER_RESULT", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_STATUS", "Machine_ID", "dbo.M_MACHINE_TESTER");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_STATUS", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_STATUS", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_MASTER", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_MASTER", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_MASTER", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_DETAIL", "Machine_ID", "dbo.M_MACHINE_TESTER");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_DETAIL", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_SIGNAL_TEST_DATA_DETAIL", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_STATUS", "Machine_ID", "dbo.M_MACHINE_TESTER");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_STATUS", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_STATUS", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_MASTER", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_MASTER", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_MASTER", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_DETAIL", "Machine_ID", "dbo.M_MACHINE_TESTER");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_DETAIL", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_RESISTANCE_TEST_DATA_DETAIL", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_STATUS", "Machine_ID", "dbo.M_MACHINE_TESTER");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_STATUS", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_STATUS", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_MASTER", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_MASTER", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_MASTER", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_DETAIL", "Machine_ID", "dbo.M_MACHINE_TESTER");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_DETAIL", "Jig_ID", "dbo.M_JIG");
            DropForeignKey("dbo.T_NOISE_TEST_DATA_DETAIL", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_MACHINE_BOOKING", "B_ID", "dbo.T_BOOKING_STATION");
            DropForeignKey("dbo.T_MACHINE_BOOKING", "Machine_ID", "dbo.M_MACHINE_TESTER");
            DropForeignKey("dbo.T_LOGIN_HISTORY", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_ERROR_LIST", "Error_Code", "dbo.M_ERROR_LIST");
            DropForeignKey("dbo.T_BOOKING_STATION", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.T_BOOKING_STATION", "PO_Number", "dbo.T_TRANSACTION_INPUT");
            DropForeignKey("dbo.T_TRANSACTION_INPUT", "User_ID", "dbo.M_USER");
            DropForeignKey("dbo.T_TRANSACTION_INPUT", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.T_BOOKING_STATION", "Queue_ID", "dbo.M_BOOKING_STATION");
            DropForeignKey("dbo.M_USER", "Group_ID", "dbo.M_USER_GROUP");
            DropForeignKey("dbo.M_USER_GROUP_PRIVILEGES", "Group_ID", "dbo.M_USER_GROUP");
            DropForeignKey("dbo.M_USER_GROUP_PRIVILEGES", "Menu_ID", "dbo.M_MENU");
            DropForeignKey("dbo.M_SIGNAL_DEVICE_PARAMETER", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.M_NOISE_DEVICE", "Device_ID", "dbo.M_DEVICE");
            DropForeignKey("dbo.M_NOISE_DEVICE", "Test_Type_ID", "dbo.M_NOISE_DEVICE_PARAMETER");
            DropForeignKey("dbo.M_MACHINE_TESTER_CALIBRATION", "Calibration_Type", "dbo.M_MACHINE_TESTER_CALIBRATION_TYPE");
            DropForeignKey("dbo.M_MACHINE_TESTER_CALIBRATION", "Machine_ID", "dbo.M_MACHINE_TESTER");
            DropForeignKey("dbo.M_MACHINE_CLOSE_SOCKET", "Machine_ID", "dbo.M_MACHINE_TESTER");
            DropForeignKey("dbo.M_JIG_CLOSE_SOCKET", "Jig_ID", "dbo.M_JIG");
            DropIndex("dbo.T_USER_SESSION", new[] { "User_ID" });
            DropIndex("dbo.T_TRANSACTION_LASER", new[] { "User_ID" });
            DropIndex("dbo.T_TRANSACTION_LASER", new[] { "Device_ID" });
            DropIndex("dbo.T_TRANSACTION_CANCEL", new[] { "User_ID" });
            DropIndex("dbo.T_TRANSACTION_CANCEL", new[] { "PO_Number" });
            DropIndex("dbo.T_SORTER_SUMMARY", new[] { "PO_Number" });
            DropIndex("dbo.T_SORTER_RESULT", new[] { "Machine_ID" });
            DropIndex("dbo.T_SORTER_RESULT", new[] { "Jig_ID" });
            DropIndex("dbo.T_SORTER_RESULT", new[] { "PO_Number" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_STATUS", new[] { "Machine_ID" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_STATUS", new[] { "Jig_ID" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_STATUS", new[] { "PO_Number" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_MASTER", new[] { "User_ID" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_MASTER", new[] { "Device_ID" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_MASTER", new[] { "PO_Number" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_DETAIL", new[] { "Machine_ID" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_DETAIL", new[] { "Jig_ID" });
            DropIndex("dbo.T_SIGNAL_TEST_DATA_DETAIL", new[] { "PO_Number" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_STATUS", new[] { "Machine_ID" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_STATUS", new[] { "Jig_ID" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_STATUS", new[] { "PO_Number" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_MASTER", new[] { "User_ID" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_MASTER", new[] { "Device_ID" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_MASTER", new[] { "PO_Number" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_DETAIL", new[] { "Machine_ID" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_DETAIL", new[] { "Jig_ID" });
            DropIndex("dbo.T_RESISTANCE_TEST_DATA_DETAIL", new[] { "PO_Number" });
            DropIndex("dbo.T_NOISE_TEST_DATA_STATUS", new[] { "Machine_ID" });
            DropIndex("dbo.T_NOISE_TEST_DATA_STATUS", new[] { "Jig_ID" });
            DropIndex("dbo.T_NOISE_TEST_DATA_STATUS", new[] { "PO_Number" });
            DropIndex("dbo.T_NOISE_TEST_DATA_MASTER", new[] { "User_ID" });
            DropIndex("dbo.T_NOISE_TEST_DATA_MASTER", new[] { "Device_ID" });
            DropIndex("dbo.T_NOISE_TEST_DATA_MASTER", new[] { "PO_Number" });
            DropIndex("dbo.T_NOISE_TEST_DATA_DETAIL", new[] { "Machine_ID" });
            DropIndex("dbo.T_NOISE_TEST_DATA_DETAIL", new[] { "Jig_ID" });
            DropIndex("dbo.T_NOISE_TEST_DATA_DETAIL", new[] { "PO_Number" });
            DropIndex("dbo.T_MACHINE_BOOKING", new[] { "B_ID" });
            DropIndex("dbo.T_MACHINE_BOOKING", new[] { "Machine_ID" });
            DropIndex("dbo.T_LOGIN_HISTORY", new[] { "User_ID" });
            DropIndex("dbo.T_ERROR_LIST", new[] { "Error_Code" });
            DropIndex("dbo.T_TRANSACTION_INPUT", new[] { "User_ID" });
            DropIndex("dbo.T_TRANSACTION_INPUT", new[] { "Device_ID" });
            DropIndex("dbo.T_BOOKING_STATION", new[] { "Device_ID" });
            DropIndex("dbo.T_BOOKING_STATION", new[] { "PO_Number" });
            DropIndex("dbo.T_BOOKING_STATION", new[] { "Queue_ID" });
            DropIndex("dbo.M_USER", new[] { "Group_ID" });
            DropIndex("dbo.M_USER_GROUP_PRIVILEGES", new[] { "Menu_ID" });
            DropIndex("dbo.M_USER_GROUP_PRIVILEGES", new[] { "Group_ID" });
            DropIndex("dbo.M_SIGNAL_DEVICE_PARAMETER", new[] { "Device_ID" });
            DropIndex("dbo.M_NOISE_DEVICE", new[] { "Device_ID" });
            DropIndex("dbo.M_NOISE_DEVICE", new[] { "Test_Type_ID" });
            DropIndex("dbo.M_MACHINE_TESTER_CALIBRATION", new[] { "Calibration_Type" });
            DropIndex("dbo.M_MACHINE_TESTER_CALIBRATION", new[] { "Machine_ID" });
            DropIndex("dbo.M_MACHINE_CLOSE_SOCKET", new[] { "Machine_ID" });
            DropIndex("dbo.M_JIG_CLOSE_SOCKET", new[] { "Jig_ID" });
            //DropTable("dbo.V_USER_GROUP");
            //DropTable("dbo.V_USER_GROUP_PRIVILEGES_IS_SET");
            //DropTable("dbo.V_USER_GROUP_PRIVILEGES");
            //DropTable("dbo.V_TESTING_STATUS");
            //DropTable("dbo.V_REPORT_SORTER_SUMMARY");
            //DropTable("dbo.V_PONUMBER_LOTBOX");
            //DropTable("dbo.V_PONUMBER_DEVICE");
            //DropTable("dbo.V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER");
            //DropTable("dbo.V_MACHINE_MACHINE_CALIBRATION");
            //DropTable("dbo.V_MACHINE_CLOSE_SOCKET");
            //DropTable("dbo.V_LASER_STATION");
            //DropTable("dbo.V_JIG_JIG_CLOSE_SOCKET");
            //DropTable("dbo.V_ERROR_LIST");
            //DropTable("dbo.V_DEVICE_DEVICE_SIGNAL_PARAMETER");
            //DropTable("dbo.V_BOOKING_ROOM_MACHINE");
            DropTable("dbo.T_USER_SESSION");
            DropTable("dbo.T_TRANSACTION_LASER");
            DropTable("dbo.T_TRANSACTION_CANCEL");
            DropTable("dbo.T_SORTER_SUMMARY");
            DropTable("dbo.T_SORTER_RESULT");
            DropTable("dbo.T_SIGNAL_TEST_DATA_STATUS");
            DropTable("dbo.T_SIGNAL_TEST_DATA_MASTER");
            DropTable("dbo.T_SIGNAL_TEST_DATA_DETAIL");
            DropTable("dbo.T_RESISTANCE_TEST_DATA_STATUS");
            DropTable("dbo.T_RESISTANCE_TEST_DATA_MASTER");
            DropTable("dbo.T_RESISTANCE_TEST_DATA_DETAIL");
            DropTable("dbo.T_NOISE_TEST_DATA_STATUS");
            DropTable("dbo.T_NOISE_TEST_DATA_MASTER");
            DropTable("dbo.T_NOISE_TEST_DATA_DETAIL");
            DropTable("dbo.T_MACHINE_BOOKING");
            DropTable("dbo.T_LOGIN_HISTORY");
            DropTable("dbo.T_LASER_STATION");
            DropTable("dbo.T_ERROR_LIST");
            DropTable("dbo.T_TRANSACTION_INPUT");
            DropTable("dbo.T_BOOKING_STATION");
            //DropTable("dbo.SP_TESTING_STATUS");
            //DropTable("dbo.SP_LASER_STATION");
            //DropTable("dbo.SP_GROUP_PRIVILEGES");
            DropTable("dbo.M_USER");
            DropTable("dbo.M_USER_GROUP");
            DropTable("dbo.M_USER_GROUP_PRIVILEGES");
            DropTable("dbo.M_SIGNAL_DEVICE_PARAMETER");
            DropTable("dbo.M_NOISE_DEVICE");
            DropTable("dbo.M_NOISE_DEVICE_PARAMETER");
            DropTable("dbo.M_NG_CONFIG");
            DropTable("dbo.M_MENU");
            DropTable("dbo.M_MACHINE_TESTER_CALIBRATION");
            DropTable("dbo.M_MACHINE_TESTER_CALIBRATION_TYPE");
            DropTable("dbo.M_MACHINE_TESTER");
            DropTable("dbo.M_MACHINE_CLOSE_SOCKET");
            DropTable("dbo.M_JIG");
            DropTable("dbo.M_JIG_CLOSE_SOCKET");
            DropTable("dbo.M_GOLDEN_SAMPLE");
            DropTable("dbo.M_ERROR_LIST");
            DropTable("dbo.M_DEVICE");
            DropTable("dbo.M_DEVICE_NG");
            DropTable("dbo.M_BOOKING_STATION");
        }
    }
}
