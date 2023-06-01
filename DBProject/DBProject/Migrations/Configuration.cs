namespace DBProject.Migrations
{
    using Models;
    //using DBProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;

    internal sealed class Configuration : DbMigrationsConfiguration<DBProjectEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }


        private void TrySaveChange(DBProjectEntities context)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {


                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }

        protected override void Seed(DBProjectEntities context)
        {
//            var group = new List<M_USER_GROUP>
//                        {
//            //Administrator   Administrator
//            //G-002   Engineer
//            //G-003   Maintenance
//            //G-004   QA
//            //G-005   Production
//            //G-006   Operator

//                            new M_USER_GROUP{Group_ID = "G-001",Group_Name ="Administrator"},
//                            new M_USER_GROUP{Group_ID = "G-002",Group_Name ="Engineer"},
//                            new M_USER_GROUP{Group_ID = "G-003",Group_Name ="Maintenance"},
//                            new M_USER_GROUP{Group_ID = "G-004",Group_Name ="QA"},
//                            new M_USER_GROUP{Group_ID = "G-005",Group_Name ="Production"},
//                            new M_USER_GROUP{Group_ID = "G-006",Group_Name ="Operator"},
//                        };
//            group.ForEach(s => context.M_USER_GROUPS.Add(s));
//            //context.SaveChanges();
//            TrySaveChange(context);

//            //string salt = "";
//            //string pass = Commons.Commons.EncryptPWDTK("svc", "", out salt);

//            //B57395 Suprihatin  123 Administrator   B57395
//            //B57396  Suendro 123 G-002   B57395
//            //B57397 Junaidi 123 G-003   B57395
//            //B57398 Rofiah  321 G-004   B57395
//            //B57399 Boby    432 G-005   B57395
//            //B57400 Arjuna  123 G-006   B57395
//            string pass = "";
//            EncryptDecryptCollections mc = new EncryptDecryptCollections();

//            pass = mc.EncryptMD5("jogan");


//            var user = new List<M_USER>
//                         {
//                           new M_USER {User_ID="B57395", Group_ID = "G-001",Name = "Suprihatin",Password = pass,Is_Active=true},
//                           new M_USER {User_ID="B57396", Group_ID = "G-002",Name = "Suendro",Password = pass,Is_Active=true},
//                           new M_USER {User_ID="B57397", Group_ID = "G-003",Name = "Junaidi",Password = pass,Is_Active=true},
//                           new M_USER {User_ID="B57398", Group_ID = "G-004",Name = "Rofiah",Password = pass,Is_Active=true},
//                           new M_USER {User_ID="B57399", Group_ID = "G-005",Name = "Boby",Password = pass,Is_Active=true},
//                           new M_USER {User_ID="B57400", Group_ID = "G-006",Name = "Arjuna",Password = pass,Is_Active=true},
//                         };
//            user.ForEach(s => context.M_USERS.Add(s));
//            //context.SaveChanges();
//            TrySaveChange(context);

//            using (var db = new DBProjectEntities())
//            {
//                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TR_MENU]')) DROP TRIGGER[dbo].[TR_MENU]");
//                db.Database.ExecuteSqlCommand(
//                    "CREATE TRIGGER [dbo].[TR_MENU] " +
//                    "   ON[dbo].[M_MENU] " +
//                    "   AFTER   INSERT " +
//                    "AS " +
//                    "BEGIN " +
//                    "    SET NOCOUNT ON; " +
//                    "    declare @code varchar(50) " +
//                    "    select @code = Code from inserted " +
//                    "    declare @detail bit " +
//                    "    select @detail = Detail from inserted " +
//                    "    declare @prntcode varchar(50) " +
//                    "    set @prntcode = LEFT(@code, 2) " +
//                    "    declare @idprnt int " +
//                    "    declare @id int " +
//                    "    select @id = id from inserted " +
//                    "    set @idprnt = 0 " +
//                    "    if exists(select * from m_menu where code = @prntcode) select @idprnt = id from m_menu where code = @prntcode " +
//                    "    if @idprnt <> 0 and @detail = 1 " +
//                    "        update m_menu set parent_id = @idprnt where id = @id and detail = 1 " +
//                    "    DECLARE @group_id varchar(50) " +
//                    "    DECLARE group_ids CURSOR LOCAL FOR select group_id from m_user_group " +
//                    "    OPEN group_ids " +
//                    "    FETCH NEXT FROM group_ids into @group_id " +
//                    "    WHILE @@FETCH_STATUS = 0 " +
//                    "    BEGIN " +
//                    "        insert into M_USER_GROUP_PRIVILEGES(group_id, menu_id, Allow_Add, Allow_Delete, Allow_Edit, Allow_Export, Allow_Read, Allow_Report, Code, Name, Created_Date, Created_User, Updated_Date, Updated_User, Is_Active) " +
//                    "        values(@group_id, @id, 1, 1, 1, 1, 1, 1, '', '', GETDATE(), '', GETDATE(), '', 1) " +
//                    "        FETCH NEXT FROM group_ids into @group_id " +
//                    "    END " +
//                    "    CLOSE group_ids " +
//                    "    DEALLOCATE group_ids " +
//                    "END");
//            }
//                var menu = new List<M_MENU>
//                         {
//new M_MENU{Code="02",Detail=false,Module="UserManagement",Name="User Management",Module_Parent="",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="02.01",Detail=true,Module="UserGroup",Name="User Group",Module_Parent="UserManagement",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="02.02",Detail=true,Module="Users",Name="User",Module_Parent="UserManagement",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="02.03",Detail=true,Module="GroupPriveleges",Name="Group Priveleges",Module_Parent="UserManagement",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="02.04",Detail=true,Module="ChangeProfile",Name="Change Profile",Module_Parent="UserManagement",Is_Active=false,Menu_For="Web"},
//new M_MENU{Code="03",Detail=false,Module="DataMaster",Name="Data Master",Module_Parent="",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="03.01",Detail=true,Module="Device",Name="Device",Module_Parent="DataMaster",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="03.02",Detail=true,Module="Jig",Name="Jig",Module_Parent="DataMaster",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="03.04",Detail=true,Module="Machine",Name="Machine",Module_Parent="DataMaster",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="03.05",Detail=true,Module="MachineCalibrationType",Name="Machine Calibration Type",Module_Parent="DataMaster",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="03.06",Detail=true,Module="MachineCalibration",Name="Machine Calibration",Module_Parent="DataMaster",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="03.07",Detail=true,Module="NoiseDeviceParameter",Name="Noise Device Parameter",Module_Parent="DataMaster",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="03.08",Detail=true,Module="NoiseDevice",Name="Noise Device",Module_Parent="DataMaster",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="03.09",Detail=true,Module="SignalDeviceParameter",Name="Signal Device Parameter",Module_Parent="DataMaster",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="03.10",Detail=true,Module="GoldenSample",Name="Golden Sample",Module_Parent="DataMaster",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="04",Detail=false,Module="Test",Name="Test",Module_Parent="",Is_Active=true,Menu_For="Desktop"},
//new M_MENU{Code="04.01",Detail=true,Module="InputTest2",Name="Lotbox Fukuda",Module_Parent="TesterMaster",Is_Active=true,Menu_For="Desktop"},
//new M_MENU{Code="04.02",Detail=true,Module="SorterTest",Name="Sorter Test",Module_Parent="TesterMaster",Is_Active=true,Menu_For="Desktop"},
//new M_MENU{Code="05",Detail=false,Module="EntryData",Name="Entry Data",Module_Parent="",Is_Active=true,Menu_For="Desktop"},
//new M_MENU{Code="05.01",Detail=true,Module="EntryData",Name="Entry Data",Module_Parent="EntryData",Is_Active=true,Menu_For="Desktop"},
//new M_MENU{Code="06",Detail=false,Module="Report",Name="Report",Module_Parent="",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="06.01",Detail=true,Module="Report",Name="Report",Module_Parent="Report",Is_Active=true,Menu_For="Web"},
//new M_MENU{Code="99",Detail=false,Module="TurnOnOff",Name="Turn On / Off",Module_Parent="",Is_Active=true,Menu_For="Desktop"},
//new M_MENU{Code="99.01",Detail=true,Module="TurnOnOff",Name="Turn On / Off",Module_Parent="TurnOnOff",Is_Active=true,Menu_For="Desktop"},

//            };
//            menu.ForEach(s => context.M_MENUS.Add(s));
//            TrySaveChange(context);
            using (var db = new DBProjectEntities())
            {
                //StringBuilder sb = new StringBuilder();
                //var mn = db.M_MENUS.Where(x => x.Detail == false).OrderBy(x => x.Code).ToList();
                //foreach (var f in mn)
                //{

                //    sb.AppendFormat("UPDATE M_MENU SET Parent_ID = {0} where code like '{1}%' and detail=1", f.ID, f.Code);
                //    sb.AppendLine();
                //    db.Database.ExecuteSqlCommand("UPDATE M_MENU SET Parent_ID = {0} where code like '{1}%' and detail=1", f.ID, f.Code );
                //}
                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_USER_GROUP_PRIVILEGES]')) DROP VIEW [dbo].[V_USER_GROUP_PRIVILEGES]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW[dbo].[V_USER_GROUP_PRIVILEGES] AS " +
                    "SELECT m.ID , ug.Group_ID, ug.Group_Name, ga.Allow_Report, ga.Allow_Read, ga.Allow_Add, ga.Allow_Delete, " +
                    "ga.Allow_Edit, ga.Allow_Export, m.Parent_ID, m.Detail, m.Module, m.Module_Parent, m.Code, m.Name, m.Is_Active, ga.Created_User, ga.Created_Date, ga.Updated_User, ga.Updated_Date, m.Menu_For " +
                    "FROM dbo.M_USER_GROUP AS ug " +
                    "INNER JOIN dbo.M_USER_GROUP_PRIVILEGES AS ga ON ug.Group_ID = ga.Group_ID " +
                    "INNER JOIN dbo.M_MENU AS m ON ga.Menu_ID = m.ID");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_USER_GROUP]')) DROP VIEW [dbo].[V_USER_GROUP]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW [dbo].[V_USER_GROUP] AS " +
                    "SELECT 0 as ID, u.Created_User, u.Created_Date, u.User_ID, ug.Group_ID, ug.Group_Name, u.Name,  " +
                    "u.Password, ' ' AS New_Password, u.Is_Active " +
                    "FROM dbo.M_USER AS u " +
                    "INNER JOIN dbo.M_USER_GROUP AS ug ON u.Group_ID = ug.Group_ID");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_GROUP_PRIVILEGES]') AND type in (N'P', N'PC')) DROP PROCEDURE[dbo].[SP_GROUP_PRIVILEGES]");
                db.Database.ExecuteSqlCommand(
                    "CREATE PROCEDURE[dbo].[SP_GROUP_PRIVILEGES] " +
                    "@Group_ID varchar(50) = '' " +
                    "AS " +
                    "BEGIN " +
                    "SET NOCOUNT ON; " +
                    "select m.ID, m.Code, m.Name, m.Detail, " +
                    "coalesce((select count(*) from V_USER_GROUP_PRIVILEGES v where left(v.code, len(m.code)) = m.code and v.detail = 1 and v.Group_ID = @Group_ID), 0) as Total_Child,   " +
                    "cast(coalesce((select allow_read from V_USER_GROUP_PRIVILEGES v where v.id = m.id and v.Group_ID = @Group_ID), 0) as bit) as Allow_Read,  " +
                    "cast(coalesce((select allow_add from V_USER_GROUP_PRIVILEGES v where v.id = m.id and v.Group_ID = @Group_ID), 0) as bit)  as Allow_Add,  " +
                    "cast(coalesce((select allow_edit from V_USER_GROUP_PRIVILEGES v where v.id = m.id and v.Group_ID = @Group_ID), 0) as bit)  as Allow_Edit,  " +
                    "cast(coalesce((select allow_delete from V_USER_GROUP_PRIVILEGES v where v.id = m.id and v.Group_ID = @Group_ID), 0) as bit)  as Allow_Delete,  " +
                    "cast(coalesce((select allow_report from V_USER_GROUP_PRIVILEGES v where v.id = m.id and v.Group_ID = @Group_ID), 0) as bit)  as Allow_Report " +
                    "from M_MENU m order by code " +
                    "END ");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_USER_GROUP_PRIVILEGES_IS_SET]')) DROP VIEW [dbo].[V_USER_GROUP_PRIVILEGES_IS_SET]");
                db.Database.ExecuteSqlCommand("CREATE VIEW [dbo].[V_USER_GROUP_PRIVILEGES_IS_SET] AS select 0 as ID,Group_ID,Group_Name, cast((case (select count(*) from V_USER_GROUP_PRIVILEGES v where v.Group_ID = ug.Group_ID) when 0 then 0 else 1 end) as bit) as Is_Set from M_USER_GROUP ug");

                //db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.triggers WHERE object_id = OBJECT_ID(N'[dbo].[TR_MENU]')) DROP TRIGGER[dbo].[TR_MENU]");
                //db.Database.ExecuteSqlCommand(
                //    "CREATE TRIGGER [dbo].[TR_MENU] " +
                //    "   ON[dbo].[M_MENU] " +
                //    "   AFTER   INSERT " +
                //    "AS " +
                //    "BEGIN " +
                //    "    SET NOCOUNT ON; " +
                //    "    declare @code varchar(50) " +
                //    "    select @code = Code from inserted " +
                //    "    declare @detail bit " +
                //    "    select @detail = Detail from inserted " +
                //    "    declare @prntcode varchar(50) " +
                //    "    set @prntcode = LEFT(@code, 2) " +
                //    "    declare @idprnt int " +
                //    "    declare @id int " +
                //    "    select @id = id from inserted " +
                //    "    set @idprnt = 0 " +
                //    "    if exists(select * from m_menu where code = @prntcode) select @idprnt = id from m_menu where code = @prntcode " +
                //    "    if @idprnt <> 0 and @detail = 1 " +
                //    "        update m_menu set parent_id = @idprnt where id = @id and detail = 1 " +
                //    "    DECLARE @group_id varchar(50) " +
                //    "    DECLARE group_ids CURSOR LOCAL FOR select group_id from m_user_group " +
                //    "    OPEN group_ids " +
                //    "    FETCH NEXT FROM group_ids into @group_id " +
                //    "    WHILE @@FETCH_STATUS = 0 " +
                //    "    BEGIN " +
                //    "        insert into M_USER_GROUP_PRIVILEGES(group_id, menu_id, Allow_Add, Allow_Delete, Allow_Edit, Allow_Export, Allow_Read, Allow_Report, Code, Name, Created_Date, Created_User, Updated_Date, Updated_User, Is_Active) " +
                //    "        values(@group_id, @id, 1, 1, 1, 1, 1, 1, '', '', GETDATE(), '', GETDATE(), '', 1) " +
                //    "        FETCH NEXT FROM group_ids into @group_id " +
                //    "    END " +
                //    "    CLOSE group_ids " +
                //    "    DEALLOCATE group_ids " +
                //    "END");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_JIG_JIG_CLOSE_SOCKET]')) DROP VIEW [dbo].[V_JIG_JIG_CLOSE_SOCKET]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW[dbo].[V_JIG_JIG_CLOSE_SOCKET] AS " +
                    "SELECT 0 AS ID, j.Jig_ID, j.Jig_Carrier_Name, j.Created_User, j.Created_Date, j.Updated_User, j.Updated_Date, jcs.Socket_1, jcs.Socket_2, jcs.Socket_3, jcs.Socket_4, jcs.Socket_5, jcs.Socket_6, jcs.Socket_7, jcs.Socket_8,  " +
                    "jcs.Socket_9, jcs.Socket_10, jcs.Socket_11, jcs.Socket_12, jcs.Socket_13, jcs.Socket_14, jcs.Socket_15, jcs.Socket_16, jcs.Socket_17, jcs.Socket_18, jcs.Socket_19, jcs.Socket_20, jcs.Socket_21, jcs.Socket_22, " +
                    "jcs.Socket_23, jcs.Socket_24, jcs.Socket_25, jcs.Socket_26, jcs.Socket_27, jcs.Socket_28, jcs.Socket_29, jcs.Socket_30, jcs.Socket_31, jcs.Socket_32, jcs.Socket_33, jcs.Socket_34, jcs.Socket_35, jcs.Socket_36, " +
                    "jcs.Socket_37, jcs.Socket_38, jcs.Socket_39, jcs.Socket_40, jcs.Socket_41, jcs.Socket_42, jcs.Socket_43, jcs.Socket_44, jcs.Socket_45, jcs.Socket_46, jcs.Socket_47, jcs.Socket_48, jcs.Socket_49, jcs.Socket_50, " +
                    "jcs.Socket_51, jcs.Socket_52, jcs.Socket_53, jcs.Socket_54, jcs.Socket_55, jcs.Socket_56, jcs.Socket_57, jcs.Socket_58, jcs.Socket_59, jcs.Socket_60, jcs.Socket_61, jcs.Socket_62, jcs.Socket_63, jcs.Socket_64 " +
                    "FROM     dbo.M_JIG AS j INNER JOIN " +
                    "dbo.M_JIG_CLOSE_SOCKET AS jcs ON j.Jig_ID = jcs.Jig_ID");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_MACHINE_MACHINE_CALIBRATION]')) DROP VIEW [dbo].[V_MACHINE_MACHINE_CALIBRATION]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW[dbo].[V_MACHINE_MACHINE_CALIBRATION] AS " +
                    "SELECT 0 AS ID, m.Machine_ID, m.Machine_Name, mc.Calibration_Type, mc.Socket_1, mc.Socket_2, mc.Socket_3, mc.Socket_4, mc.Socket_5, mc.Socket_6, mc.Socket_7, mc.Socket_8, mc.Socket_9, mc.Socket_10, mc.Socket_11, " +
                    "mc.Socket_12, mc.Socket_13, mc.Socket_14, mc.Socket_15, mc.Socket_16, mc.Socket_17, mc.Socket_18, mc.Socket_19, mc.Socket_20, mc.Socket_21, mc.Socket_22, mc.Socket_23, mc.Socket_24, mc.Socket_25, " +
                    "mc.Socket_26, mc.Socket_27, mc.Socket_28, mc.Socket_29, mc.Socket_30, mc.Socket_31, mc.Socket_32, mc.Socket_33, mc.Socket_34, mc.Socket_35, mc.Socket_36, mc.Socket_37, mc.Socket_38, mc.Socket_39, " +
                    "mc.Socket_40, mc.Socket_41, mc.Socket_42, mc.Socket_43, mc.Socket_44, mc.Socket_45, mc.Socket_46, mc.Socket_47, mc.Socket_48, mc.Socket_49, mc.Socket_50, mc.Socket_51, mc.Socket_52, mc.Socket_53, " +
                    "mc.Socket_54, mc.Socket_55, mc.Socket_56, mc.Socket_57, mc.Socket_58, mc.Socket_59, mc.Socket_60, mc.Socket_61, mc.Socket_62, mc.Socket_63, mc.Socket_64,'' as Calibration_Type2 " +
                    "FROM     dbo.M_MACHINE_TESTER AS m INNER JOIN " +
                    "dbo.M_MACHINE_TESTER_CALIBRATION AS mc ON m.Machine_ID = mc.Machine_ID");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER]')) DROP VIEW [dbo].[V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW[dbo].[V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER] AS " +
                    "SELECT 0 AS ID, d.Device_ID, d.Device_Name, nd.Test_Type_ID, ndp.Test_Type_Name,ndp.Soak_Time, ndp.Measurement_Duration " +
                    "FROM     dbo.M_DEVICE AS d INNER JOIN " +
                    "dbo.M_NOISE_DEVICE AS nd ON d.Device_ID = nd.Device_ID INNER JOIN " +
                    "dbo.M_NOISE_DEVICE_PARAMETER AS ndp ON nd.Test_Type_ID = ndp.Test_Type_ID");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_DEVICE_DEVICE_SIGNAL_PARAMETER]')) DROP VIEW [dbo].[V_DEVICE_DEVICE_SIGNAL_PARAMETER]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW[dbo].[V_DEVICE_DEVICE_SIGNAL_PARAMETER] AS " +
                    "SELECT d.Device_Name, sdp.* FROM     dbo.M_DEVICE AS d INNER JOIN dbo.M_SIGNAL_DEVICE_PARAMETER AS sdp ON d.Device_ID = sdp.Device_ID");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_BOOKING_ROOM_MACHINE]')) DROP VIEW [dbo].[V_BOOKING_ROOM_MACHINE]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW[dbo].[V_BOOKING_ROOM_MACHINE] AS " +
                    "SELECT ID, Noise_Room_Number, " +
                    "(SELECT Machine_ID  FROM      dbo.M_MACHINE_TESTER AS m  WHERE(Machine_Number = b.Noise_Room_Number) AND(Machines_Type = 'NOISE')) AS Machine_Noise, Signal_Room_Number, " +
                    " (SELECT Machine_ID FROM      dbo.M_MACHINE_TESTER AS m  WHERE(Machine_Number = b.Signal_Room_Number) AND(Machines_Type = 'SIGNAL')) AS Machine_Signal, Resistance_Room_Number, " +
                    "(SELECT Machine_ID FROM      dbo.M_MACHINE_TESTER AS m WHERE(Machine_Number = b.Resistance_Room_Number) AND(Machines_Type = 'RESISTANCE')) AS Machine_Resistance, Line_Number " +
                    "FROM dbo.M_BOOKING_STATION AS b");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_MACHINE_CLOSE_SOCKET]')) DROP VIEW [dbo].[V_MACHINE_CLOSE_SOCKET]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW[dbo].[V_MACHINE_CLOSE_SOCKET] AS " +
                    "SELECT 0 AS ID, m.Machine_ID, SUM(CAST(cs.Socket_1 AS int)) AS Socket_1, SUM(CAST(cs.Socket_2 AS int)) AS Socket_2, SUM(CAST(cs.Socket_3 AS int)) AS Socket_3, SUM(CAST(cs.Socket_4 AS int)) AS Socket_4,  " +
                    "SUM(CAST(cs.Socket_5 AS int)) AS Socket_5, SUM(CAST(cs.Socket_6 AS int)) AS Socket_6, SUM(CAST(cs.Socket_7 AS int)) AS Socket_7, SUM(CAST(cs.Socket_8 AS int)) AS Socket_8, SUM(CAST(cs.Socket_9 AS int)) " +
                    "AS Socket_9, SUM(CAST(cs.Socket_10 AS int)) AS Socket_10, SUM(CAST(cs.Socket_11 AS int)) AS Socket_11, SUM(CAST(cs.Socket_12 AS int)) AS Socket_12, SUM(CAST(cs.Socket_13 AS int)) AS Socket_13, " +
                    "SUM(CAST(cs.Socket_14 AS int)) AS Socket_14, SUM(CAST(cs.Socket_15 AS int)) AS Socket_15, SUM(CAST(cs.Socket_16 AS int)) AS Socket_16, SUM(CAST(cs.Socket_17 AS int)) AS Socket_17, " +
                    "SUM(CAST(cs.Socket_18 AS int)) AS Socket_18, SUM(CAST(cs.Socket_19 AS int)) AS Socket_19, SUM(CAST(cs.Socket_20 AS int)) AS Socket_20, SUM(CAST(cs.Socket_21 AS int)) AS Socket_21, " +
                    "SUM(CAST(cs.Socket_22 AS int)) AS Socket_22, SUM(CAST(cs.Socket_23 AS int)) AS Socket_23, SUM(CAST(cs.Socket_24 AS int)) AS Socket_24, SUM(CAST(cs.Socket_25 AS int)) AS Socket_25, " +
                    "SUM(CAST(cs.Socket_26 AS int)) AS Socket_26, SUM(CAST(cs.Socket_27 AS int)) AS Socket_27, SUM(CAST(cs.Socket_28 AS int)) AS Socket_28, SUM(CAST(cs.Socket_29 AS int)) AS Socket_29, " +
                    "SUM(CAST(cs.Socket_30 AS int)) AS Socket_30, SUM(CAST(cs.Socket_31 AS int)) AS Socket_31, SUM(CAST(cs.Socket_32 AS int)) AS Socket_32, SUM(CAST(cs.Socket_33 AS int)) AS Socket_33, " +
                    "SUM(CAST(cs.Socket_34 AS int)) AS Socket_34, SUM(CAST(cs.Socket_35 AS int)) AS Socket_35, SUM(CAST(cs.Socket_36 AS int)) AS Socket_36, SUM(CAST(cs.Socket_37 AS int)) AS Socket_37, " +
                    "SUM(CAST(cs.Socket_38 AS int)) AS Socket_38, SUM(CAST(cs.Socket_39 AS int)) AS Socket_39, SUM(CAST(cs.Socket_40 AS int)) AS Socket_40, SUM(CAST(cs.Socket_41 AS int)) AS Socket_41, " +
                    "SUM(CAST(cs.Socket_42 AS int)) AS Socket_42, SUM(CAST(cs.Socket_43 AS int)) AS Socket_43, SUM(CAST(cs.Socket_44 AS int)) AS Socket_44, SUM(CAST(cs.Socket_45 AS int)) AS Socket_45, " +
                    "SUM(CAST(cs.Socket_46 AS int)) AS Socket_46, SUM(CAST(cs.Socket_47 AS int)) AS Socket_47, SUM(CAST(cs.Socket_48 AS int)) AS Socket_48, SUM(CAST(cs.Socket_49 AS int)) AS Socket_49, " +
                    "SUM(CAST(cs.Socket_50 AS int)) AS Socket_50, SUM(CAST(cs.Socket_51 AS int)) AS Socket_51, SUM(CAST(cs.Socket_52 AS int)) AS Socket_52, SUM(CAST(cs.Socket_53 AS int)) AS Socket_53, " +
                    "SUM(CAST(cs.Socket_54 AS int)) AS Socket_54, SUM(CAST(cs.Socket_55 AS int)) AS Socket_55, SUM(CAST(cs.Socket_56 AS int)) AS Socket_56, SUM(CAST(cs.Socket_57 AS int)) AS Socket_57, " +
                    "SUM(CAST(cs.Socket_58 AS int)) AS Socket_58, SUM(CAST(cs.Socket_59 AS int)) AS Socket_59, SUM(CAST(cs.Socket_60 AS int)) AS Socket_60, SUM(CAST(cs.Socket_61 AS int)) AS Socket_61, " +
                    "SUM(CAST(cs.Socket_62 AS int)) AS Socket_62, SUM(CAST(cs.Socket_63 AS int)) AS Socket_63, SUM(CAST(cs.Socket_64 AS int)) AS Socket_64 " +
                    "FROM     dbo.M_MACHINE_CLOSE_SOCKET AS cs INNER JOIN " +
                    "dbo.M_MACHINE_TESTER AS m ON m.Machine_ID = cs.Machine_ID " +
                    "GROUP BY m.Machine_ID");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_PONUMBER_DEVICE]')) DROP VIEW [dbo].[V_PONUMBER_DEVICE]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW [dbo].[V_PONUMBER_DEVICE] AS " +
                    "SELECT 0 AS ID, t.PO_Number, t.AQL_Reference, t.Noise_Type_Parameter_Ref, t.Signal_Device_ID_Ref, t.Status, t.Device_ID, t.User_ID, t.Start_Test, t.End_Test, t.Quantity, t.LotBox_Position_Fukuda, t.LotBox_Position_Laser, " +
                    "t.LotBox_ID, d.Device_Name, d.Device_Status, d.Test_Mode_Default, t.Created_Date " +
                    "FROM     dbo.T_TRANSACTION_INPUT AS t INNER JOIN dbo.M_DEVICE AS d ON t.Device_ID = d.Device_ID");

                //throw new Exception(sb.ToString());
                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_LASER_STATION]')) DROP VIEW [dbo].[V_LASER_STATION]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW[dbo].[V_LASER_STATION] AS " +
                    "SELECT ID, LotBox_ID, LotBox_NG_ID, Status, Created_User, LotBox_Position,Created_Date, Updated_User, Updated_Date " +
                    "FROM     dbo.T_LASER_STATION " +
                    "WHERE(ID = (SELECT MIN(ID)  FROM      dbo.T_LASER_STATION WHERE(Status = 'READY')))");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_PONUMBER_LOTBOX]')) DROP VIEW [dbo].[V_PONUMBER_LOTBOX]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW[dbo].[V_PONUMBER_LOTBOX] AS " +
                    "SELECT 0 AS ID, PO_Number, AQL_Reference, Noise_Type_Parameter_Ref, Signal_Device_ID_Ref, Status, Device_ID, User_ID, Created_User, Created_Date, Updated_User, Updated_Date, Start_Test, End_Test, Quantity,  " +
                    "LotBox_Position_Fukuda, LotBox_ID, LotBox_Position_Laser " +
                    "FROM     dbo.T_TRANSACTION_INPUT AS inp " +
                    "WHERE(Status = 'QUEUE') AND(Created_Date = " +
                    "(SELECT MAX(Created_Date) FROM      dbo.T_TRANSACTION_INPUT))");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_LASER_STATION]') AND type in (N'P', N'PC')) DROP PROCEDURE[dbo].[SP_LASER_STATION]");
                db.Database.ExecuteSqlCommand(
                    "CREATE PROCEDURE [dbo].[SP_LASER_STATION] " +
                    "@ISDownGrade as bit = false " +
                    "AS " +
                    "BEGIN " +
                    "  SET NOCOUNT ON; " +
                    "  SELECT ID, LotBox_ID, LotBox_NG_ID, Status, Created_User, LotBox_Position, Created_Date, Updated_User, Updated_Date, Is_Downgrade " +
                    "  FROM T_LASER_STATION " +
                    "  WHERE(ID = (SELECT MIN(ID)  FROM  T_LASER_STATION WHERE(Status = 'READY' AND Is_Downgrade = @ISDownGrade))) " +
                    "END ");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_TESTING_STATUS]')) DROP VIEW [dbo].[V_TESTING_STATUS]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW[dbo].[V_TESTING_STATUS] AS " +
                    "SELECT TOP (100) PERCENT 0 as ID, TestType, PO_Number, Machine_ID, Jig_ID, Socket_1, Socket_2, Socket_3, Socket_4, Socket_5, Socket_6, Socket_7, Socket_8, Socket_9, Socket_10, Socket_11, Socket_12, Socket_13, Socket_14,  " +
                    "Socket_15, Socket_16, Socket_17, Socket_18, Socket_19, Socket_20, Socket_21, Socket_22, Socket_23, Socket_24, Socket_25, Socket_26, Socket_27, Socket_28, Socket_29, Socket_30, Socket_31, Socket_32, Socket_33, " +
                    "Socket_34, Socket_35, Socket_36, Socket_37, Socket_38, Socket_39, Socket_40, Socket_41, Socket_42, Socket_43, Socket_44, Socket_45, Socket_46, Socket_47, Socket_48, Socket_49, Socket_50, Socket_51, Socket_52, " +
                    "Socket_53, Socket_54, Socket_55, Socket_56, Socket_57, Socket_58, Socket_59, Socket_60, Socket_61, Socket_62, Socket_63, Socket_64 " +
                    "FROM( " +
                    "SELECT 'Noise' AS TestType, PO_Number, Machine_ID, Jig_ID, Socket_1, Socket_2, Socket_3, Socket_4, Socket_5, Socket_6, Socket_7, Socket_8, Socket_9, Socket_10, Socket_11, Socket_12, Socket_13, Socket_14, " +
                    "Socket_15, Socket_16, Socket_17, Socket_18, Socket_19, Socket_20, Socket_21, Socket_22, Socket_23, Socket_24, Socket_25, Socket_26, Socket_27, Socket_28, Socket_29, Socket_30, Socket_31, Socket_32, " +
                    "Socket_33, Socket_34, Socket_35, Socket_36, Socket_37, Socket_38, Socket_39, Socket_40, Socket_41, Socket_42, Socket_43, Socket_44, Socket_45, Socket_46, Socket_47, Socket_48, Socket_49, Socket_50, " +
                    "Socket_51, Socket_52, Socket_53, Socket_54, Socket_55, Socket_56, Socket_57, Socket_58, Socket_59, Socket_60, Socket_61, Socket_62, Socket_63, Socket_64 " +
                    "FROM      dbo.T_NOISE_TEST_DATA_STATUS " +
                    "UNION ALL " +
                    "SELECT 'Resistance' AS TestType, PO_Number, Machine_ID, Jig_ID, Socket_1, Socket_2, Socket_3, Socket_4, Socket_5, Socket_6, Socket_7, Socket_8, Socket_9, Socket_10, Socket_11, Socket_12, Socket_13, Socket_14, " +
                    "Socket_15, Socket_16, Socket_17, Socket_18, Socket_19, Socket_20, Socket_21, Socket_22, Socket_23, Socket_24, Socket_25, Socket_26, Socket_27, Socket_28, Socket_29, Socket_30, Socket_31, Socket_32, " +
                    "Socket_33, Socket_34, Socket_35, Socket_36, Socket_37, Socket_38, Socket_39, Socket_40, Socket_41, Socket_42, Socket_43, Socket_44, Socket_45, Socket_46, Socket_47, Socket_48, Socket_49, Socket_50, " +
                    "Socket_51, Socket_52, Socket_53, Socket_54, Socket_55, Socket_56, Socket_57, Socket_58, Socket_59, Socket_60, Socket_61, Socket_62, Socket_63, Socket_64 " +
                    "FROM     dbo.T_RESISTANCE_TEST_DATA_STATUS " +
                    "UNION ALL " +
                    "SELECT 'Signal' AS TestType, PO_Number, Machine_ID, Jig_ID, Socket_1, Socket_2, Socket_3, Socket_4, Socket_5, Socket_6, Socket_7, Socket_8, Socket_9, Socket_10, Socket_11, Socket_12, Socket_13, Socket_14, " +
                    "Socket_15, Socket_16, Socket_17, Socket_18, Socket_19, Socket_20, Socket_21, Socket_22, Socket_23, Socket_24, Socket_25, Socket_26, Socket_27, Socket_28, Socket_29, Socket_30, Socket_31, Socket_32, " +
                    "Socket_33, Socket_34, Socket_35, Socket_36, Socket_37, Socket_38, Socket_39, Socket_40, Socket_41, Socket_42, Socket_43, Socket_44, Socket_45, Socket_46, Socket_47, Socket_48, Socket_49, Socket_50, " +
                    "Socket_51, Socket_52, Socket_53, Socket_54, Socket_55, Socket_56, Socket_57, Socket_58, Socket_59, Socket_60, Socket_61, Socket_62, Socket_63, Socket_64 " +
                    "FROM     dbo.T_SIGNAL_TEST_DATA_STATUS "+
                    "UNION ALL " +
                    "SELECT 'XResult' AS TestType, PO_Number, Machine_ID, Jig_ID, Socket_1, Socket_2, Socket_3, Socket_4, Socket_5, Socket_6, Socket_7, Socket_8, Socket_9, Socket_10, Socket_11, Socket_12, Socket_13, Socket_14, " +
                    "Socket_15, Socket_16, Socket_17, Socket_18, Socket_19, Socket_20, Socket_21, Socket_22, Socket_23, Socket_24, Socket_25, Socket_26, Socket_27, Socket_28, Socket_29, Socket_30, Socket_31, Socket_32, " +
                    "Socket_33, Socket_34, Socket_35, Socket_36, Socket_37, Socket_38, Socket_39, Socket_40, Socket_41, Socket_42, Socket_43, Socket_44, Socket_45, Socket_46, Socket_47, Socket_48, Socket_49, Socket_50, " +
                    "Socket_51, Socket_52, Socket_53, Socket_54, Socket_55, Socket_56, Socket_57, Socket_58, Socket_59, Socket_60, Socket_61, Socket_62, Socket_63, Socket_64 " +
                    "FROM     dbo.T_SORTER_RESULT) AS x " +
                    "ORDER BY PO_Number, Jig_ID, TestType");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SP_TESTING_STATUS]') AND type in (N'P', N'PC')) DROP PROCEDURE[dbo].[SP_TESTING_STATUS]");
                db.Database.ExecuteSqlCommand(
                    "CREATE PROCEDURE [dbo].[SP_TESTING_STATUS] " +
                    "@PONumber as varchar(50) = null " +
                    "AS " +
                    "BEGIN " +
                    "SET NOCOUNT ON; " + 
                    "select 0 as ID, * from( " +
                    "SELECT 'Noise' as TestType, PO_Number, Machine_ID, Jig_ID, Socket_1, Socket_2, Socket_3, Socket_4, Socket_5, Socket_6, Socket_7, Socket_8, Socket_9, Socket_10, Socket_11, Socket_12, Socket_13, Socket_14, Socket_15, Socket_16, Socket_17, " +
                    "Socket_18, Socket_19, Socket_20, Socket_21, Socket_22, Socket_23, Socket_24, Socket_25, Socket_26, Socket_27, Socket_28, Socket_29, Socket_30, Socket_31, Socket_32, Socket_33, Socket_34, Socket_35, Socket_36, " +
                    "Socket_37, Socket_38, Socket_39, Socket_40, Socket_41, Socket_42, Socket_43, Socket_44, Socket_45, Socket_46, Socket_47, Socket_48, Socket_49, Socket_50, Socket_51, Socket_52, Socket_53, Socket_54, Socket_55, " +
                    "Socket_56, Socket_57, Socket_58, Socket_59, Socket_60, Socket_61, Socket_62, Socket_63, Socket_64 " +
                    "FROM     T_NOISE_TEST_DATA_STATUS " +
                    "where PO_Number = @PONumber " +
                    "Union all " +
                    "SELECT 'Resistance' as TestType, PO_Number, Machine_ID, Jig_ID, Socket_1, Socket_2, Socket_3, Socket_4, Socket_5, Socket_6, Socket_7, Socket_8, Socket_9, Socket_10, Socket_11, Socket_12, Socket_13, Socket_14, Socket_15, Socket_16, Socket_17, " +
                    "Socket_18, Socket_19, Socket_20, Socket_21, Socket_22, Socket_23, Socket_24, Socket_25, Socket_26, Socket_27, Socket_28, Socket_29, Socket_30, Socket_31, Socket_32, Socket_33, Socket_34, Socket_35, Socket_36, " +
                    "Socket_37, Socket_38, Socket_39, Socket_40, Socket_41, Socket_42, Socket_43, Socket_44, Socket_45, Socket_46, Socket_47, Socket_48, Socket_49, Socket_50, Socket_51, Socket_52, Socket_53, Socket_54, Socket_55, " +
                    "Socket_56, Socket_57, Socket_58, Socket_59, Socket_60, Socket_61, Socket_62, Socket_63, Socket_64 " +
                    "FROM     T_RESISTANCE_TEST_DATA_STATUS " +
                    "where PO_Number = @PONumber " +
                    "Union all " +
                    "SELECT 'Signal' as TestType, PO_Number, Machine_ID, Jig_ID, Socket_1, Socket_2, Socket_3, Socket_4, Socket_5, Socket_6, Socket_7, Socket_8, Socket_9, Socket_10, Socket_11, Socket_12, Socket_13, Socket_14, Socket_15, Socket_16, Socket_17, " +
                    "Socket_18, Socket_19, Socket_20, Socket_21, Socket_22, Socket_23, Socket_24, Socket_25, Socket_26, Socket_27, Socket_28, Socket_29, Socket_30, Socket_31, Socket_32, Socket_33, Socket_34, Socket_35, Socket_36, " +
                    "Socket_37, Socket_38, Socket_39, Socket_40, Socket_41, Socket_42, Socket_43, Socket_44, Socket_45, Socket_46, Socket_47, Socket_48, Socket_49, Socket_50, Socket_51, Socket_52, Socket_53, Socket_54, Socket_55, " +
                    "Socket_56, Socket_57, Socket_58, Socket_59, Socket_60, Socket_61, Socket_62, Socket_63, Socket_64 " +
                    "FROM      T_SIGNAL_TEST_DATA_STATUS " +
                    "where PO_Number = @PONumber " +
                    "Union all " +
                    "SELECT 'XResult' as TestType, PO_Number, Machine_ID, Jig_ID, Socket_1, Socket_2, Socket_3, Socket_4, Socket_5, Socket_6, Socket_7, Socket_8, Socket_9, Socket_10, Socket_11, Socket_12, Socket_13, Socket_14, Socket_15, Socket_16, Socket_17, " +
                    "Socket_18, Socket_19, Socket_20, Socket_21, Socket_22, Socket_23, Socket_24, Socket_25, Socket_26, Socket_27, Socket_28, Socket_29, Socket_30, Socket_31, Socket_32, Socket_33, Socket_34, Socket_35, Socket_36, " +
                    "Socket_37, Socket_38, Socket_39, Socket_40, Socket_41, Socket_42, Socket_43, Socket_44, Socket_45, Socket_46, Socket_47, Socket_48, Socket_49, Socket_50, Socket_51, Socket_52, Socket_53, Socket_54, Socket_55, " +
                    "Socket_56, Socket_57, Socket_58, Socket_59, Socket_60, Socket_61, Socket_62, Socket_63, Socket_64 " +
                    "FROM      T_SORTER_RESULT " +
                    "where PO_Number = @PONumber " +
                    ") x order by Jig_ID, TestType " +
                    "END");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_REPORT_SORTER_SUMMARY]')) DROP VIEW [dbo].[V_REPORT_SORTER_SUMMARY]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW [dbo].[V_REPORT_SORTER_SUMMARY] " +
                    "AS " +
                    "SELECT 0 AS ID, ss.PO_Number,  CAST('0x0' AS varbinary(MAX)) AS PO_Number_Barcode, ss.Qty_Pass, ss.Qty_Downgrade, ss.Qty_Reject, ss.Qty_NG1, ss.Qty_NG2, ss.Qty_NG3, ss.Qty_NG4, ss.Qty_NG5, ss.Qty_NG6, ss.Qty_NG7, ss.Qty_NG_Other,ss.Qty_NOD, ti.Quantity, ti.LotBox_ID, " +
                    "tl.LotBox_ID AS LotBox_Laser, tl.LotBox_NG_ID, ti.Device_ID, CAST('0x0' AS varbinary(MAX)) AS Device_ID_Barcode " +
                    "FROM     dbo.T_TRANSACTION_INPUT AS ti INNER JOIN " +
                    "dbo.T_SORTER_SUMMARY AS ss ON ss.PO_Number = ti.PO_Number INNER JOIN " +
                    "dbo.T_TRANSACTION_LASER AS tl ON tl.PO_Number = ti.PO_Number");

                db.Database.ExecuteSqlCommand("IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[V_MESSAGE]')) DROP VIEW [dbo].[V_MESSAGE]");
                db.Database.ExecuteSqlCommand(
                    "CREATE VIEW [dbo].[V_MESSAGE] " +
                    "AS " +
                    "SELECT tel.ID, tel.MarkAsDelete,tel.Message_Code, tel.Hardware_ID, tel.Status, tel.Created_Date, tel.Description, mel.Message_Name, mel.Impact FROM     dbo.T_ERROR_LIST AS tel INNER JOIN dbo.M_ERROR_LIST AS mel ON mel.Message_Code = tel.Message_Code");
            }
        }
    }
}
