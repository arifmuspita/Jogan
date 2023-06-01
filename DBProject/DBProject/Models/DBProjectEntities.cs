using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DBProject.Models
{
    public class DBProjectEntities: DbContext
    {
        public DBProjectEntities() 
            : base("DBProjectEntities")
        {
        }
        //Tables
        public virtual DbSet<M_MENU> M_MENUS { get; set; }
        public virtual DbSet<M_USER_GROUP> M_USER_GROUPS { get; set; }
        //public virtual DbSet<UserMenu> UserMenus { get; set; }
        public virtual DbSet<M_USER> M_USERS { get; set; }
        public virtual DbSet<M_USER_GROUP_PRIVILEGES> M_USER_GROUP_PRIVILEGESS { get; set; }
        public virtual DbSet<T_LOGIN_HISTORY> T_LOGIN_HISTORIES { get; set; }
        public virtual DbSet<T_USER_SESSION> T_USER_SESSIONS { get; set; }
        //public virtual DbSet<MasterBoxNG> BoxNGs { get; set; }
        public virtual DbSet<M_DEVICE> M_DEVICES { get; set; }
        public virtual DbSet<M_DEVICE_NG> M_DEVICE_NGS { get; set; }
        public virtual DbSet<M_NOISE_DEVICE> M_NOISE_DEVICES{ get; set; }
        //public virtual DbSet<M_NOISE_DEVICE_PARAMETER_TYPE> M_NOISE_DEVICE_PARAMETER_TYPES{ get; set; }
        public virtual DbSet<M_NOISE_DEVICE_PARAMETER> M_NOISE_DEVICE_PARAMETERS { get; set; }
        public virtual DbSet<M_SIGNAL_DEVICE_PARAMETER> M_SIGNAL_DEVICE_PARAMETERS{ get; set; }
        public virtual DbSet<M_JIG> M_JIGS{ get; set; }
        public virtual DbSet<M_JIG_CLOSE_SOCKET> M_JIG_CLOSE_SOCKETS { get; set; }
        public virtual DbSet<M_BOOKING_STATION> M_BOOKING_STATIONS { get; set; }
        //public virtual DbSet<MasterLotBox> LotBoxs { get; set; }
        public virtual DbSet<M_MACHINE_TESTER> M_MACHINE_TESTERS{ get; set; }
        public virtual DbSet<M_MACHINE_CLOSE_SOCKET> M_MACHINE_CLOSE_SOCKETS { get; set; }
        public virtual DbSet<M_MACHINE_TESTER_CALIBRATION_TYPE> M_MACHINE_TESTER_CALIBRATION_TYPES{ get; set; }
        public virtual DbSet<M_MACHINE_TESTER_CALIBRATION> M_MACHINE_TESTER_CALIBRATIONS { get; set; }
        public virtual DbSet<M_GOLDEN_SAMPLE> M_GOLDEN_SAMPLES { get; set; }
        public virtual DbSet<M_ERROR_LIST> M_ERROR_LISTS { get; set; }
        public virtual DbSet<M_NG_CONFIG> M_NG_CONFIGS { get; set; }
        
        public virtual DbSet<T_NOISE_TEST_DATA_MASTER> T_NOISE_TEST_DATA_MASTERS{ get; set; }
        public virtual DbSet<T_NOISE_TEST_DATA_DETAIL> T_NOISE_TEST_DATA_DETAILS{ get; set; }
        public virtual DbSet<T_NOISE_TEST_DATA_STATUS> T_NOISE_TEST_DATA_STATUSS{ get; set; }
        public virtual DbSet<T_TRANSACTION_INPUT> T_TRANSACTION_INPUTS{ get; set; }
        public virtual DbSet<T_TRANSACTION_LASER> T_TRANSACTION_LASERS{ get; set; }
        public virtual DbSet<T_TRANSACTION_CANCEL> T_TRANSACTION_CANCELS{ get; set; }
        public virtual DbSet<T_SIGNAL_TEST_DATA_MASTER> T_SIGNAL_TEST_DATA_MASTERS{ get; set; }
        public virtual DbSet<T_SIGNAL_TEST_DATA_DETAIL> T_SIGNAL_TEST_DATA_DETAILS{ get; set; } 
        public virtual DbSet<T_SIGNAL_TEST_DATA_STATUS> T_SIGNAL_TEST_DATA_STATUSS{ get; set; }
        public virtual DbSet<T_RESISTANCE_TEST_DATA_MASTER> T_RESISTANCE_TEST_DATA_MASTERS { get; set; }
        public virtual DbSet<T_RESISTANCE_TEST_DATA_DETAIL> T_RESISTANCE_TEST_DATA_DETAILS { get; set; }
        public virtual DbSet<T_RESISTANCE_TEST_DATA_STATUS> T_RESISTANCE_TEST_DATA_STATUSS { get; set; }
        public virtual DbSet<T_BOOKING_STATION> T_BOOKING_STATIONS { get; set; }
        public virtual DbSet<T_MACHINE_BOOKING> T_MACHINE_BOOKINGS { get; set; }
        public virtual DbSet<T_LASER_STATION> T_LASER_STATIONS { get; set; }
        public virtual DbSet<T_ERROR_LIST> T_ERROR_LISTS { get; set; }
        public virtual DbSet<T_SORTER_RESULT> T_SORTER_RESULTS { get; set; }
        public virtual DbSet<T_SORTER_SUMMARY> T_SORTER_SUMMARIES { get; set; }
        public virtual DbSet<T_JOGAN_HISTORY> T_JOGAN_HISTORIES { get; set; }
        

        //public virtual DbSet<MachineSignalCalibration> MachineSignalCalibrations { get; set; } 

        ////Views
        public virtual DbSet<V_USER_GROUP> V_USER_GROUPS { get; set; }
        //public virtual DbSet<V_UserUserMenu> V_UserUserMenus { get; set; }
        public virtual DbSet<V_USER_GROUP_PRIVILEGES> V_USER_GROUP_PRIVILEGES { get; set; }
        public virtual DbSet<V_USER_GROUP_PRIVILEGES_IS_SET> V_USER_GROUP_PRIVILEGES_IS_SETS { get; set; }
        public virtual DbSet<V_JIG_JIG_CLOSE_SOCKET> V_JIG_JIG_CLOSE_SOCKETS { get; set; }
        public virtual DbSet<V_MACHINE_MACHINE_CALIBRATION> V_MACHINE_MACHINE_CALIBRATIONS { get; set; }
        public virtual DbSet<V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER> V_NOISE_DEVICE_NOISE_DEVICE_PARAMETERS { get; set; }
        public virtual DbSet<V_DEVICE_DEVICE_SIGNAL_PARAMETER> V_DEVICE_DEVICE_SIGNAL_PARAMETERS { get; set; }
        public virtual DbSet<V_BOOKING_ROOM_MACHINE> V_BOOKING_ROOM_MACHINES { get; set; }
        public virtual DbSet<V_MACHINE_CLOSE_SOCKET> V_MACHINE_CLOSE_SOCKETS { get; set; }
        public virtual DbSet<V_LASER_STATION> V_LASER_STATIONS { get; set; }
        public virtual DbSet<V_PONUMBER_DEVICE> V_PONUMBER_DEVICES { get; set; }
        public virtual DbSet<V_PONUMBER_LOTBOX> V_PONUMBER_LOTBOXS { get; set; }
        public virtual DbSet<V_TESTING_STATUS> V_TESTING_STATUS { get; set; }
        public virtual DbSet<V_REPORT_SORTER_SUMMARY> V_REPORT_SORTER_SUMMARIES { get; set; }
        public virtual DbSet<V_MESSAGE> V_MESSAGES { get; set; }
        



        ////Stored Procedure
        public virtual DbSet<SP_GROUP_PRIVILEGES> SP_GROUP_PRIVILEGES { get; set; }
        public virtual DbSet<SP_LASER_STATION> SP_LASER_STATIONS { get; set; }
        public virtual DbSet<SP_TESTING_STATUS> SP_TESTING_STATUS { get; set; }
        
    }
}