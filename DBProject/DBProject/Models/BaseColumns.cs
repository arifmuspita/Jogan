using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DBProject.Models
{
    public class BaseColumns
    {
        public BaseColumns()
        {
            Created_Date = DateTime.Now;
            Updated_Date = DateTime.Now;
            Created_User = "system";
            Updated_User = "system";
           // ID = 0;
            //Commons.Commons.SetDefaultValue(this);
            Created_User = "system";
            Updated_User = "system";
        }
        //[Key]
        //public Int32 ID { get; set; }
        [StringLength(200),  DefaultValue("system")]
        public string Created_User { get; set; }
        [ DefaultValue("GETDATE()")]
        public Nullable<DateTime> Created_Date { get; set; }
        [StringLength(200), DefaultValue("")]
        public string Updated_User { get; set; }
        [ DefaultValue("GETDATE()")]
        public Nullable<DateTime> Updated_Date { get; set; }  

    }

    public class BaseColumns2 : BaseColumns
    {
        public BaseColumns2()
        {
             
            Is_Active = true;
        }
        [StringLength(100)]
        public string Code { get; set; }
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        public bool Is_Active { get; set; }
    }

    public class T_BASE_TRANSACTION_0 : BaseColumns
    {
        [Required]
        public string Device_ID { get; set; }
        [Required]
        public string User_ID { get; set; }
        //    [ForeignKey("Device_ID")]
        //    public virtual M_DEVICE T_BASE_TRANSACTION_M_DEVICES { get; set; }
        //    [ForeignKey("User_ID")]
        //    public virtual M_USER T_BASE_TRANSACTION_M_USER { get; set; }
    }

    public class T_BASE_TRANSACTION: T_BASE_TRANSACTION_0
    {
        [Key, StringLength(50)]
        public string PO_Number { get; set; }
        //[Required]
        //public DateTime Start_Test { get; set; }
        //[Required]
        //public DateTime End_Test { get; set; }

    }
    public class T_BASE_MASTER : T_BASE_TRANSACTION
    {
        //[Key]
        //public Int32 ID { get; set; }
       // [Required,StringLength(50)]
        //public string PO_Number { get; set; }
       
    }

    public class BaseCloseSocket : BaseColumns
    {
        [Required]
        public bool Socket_1 { get; set; }
        [Required]
        public bool Socket_2 { get; set; }
        [Required]
        public bool Socket_3 { get; set; }
        [Required]
        public bool Socket_4 { get; set; }
        [Required]
        public bool Socket_5 { get; set; }
        [Required]
        public bool Socket_6 { get; set; }
        [Required]
        public bool Socket_7 { get; set; }
        [Required]
        public bool Socket_8 { get; set; }
        [Required]
        public bool Socket_9 { get; set; }
        [Required]
        public bool Socket_10 { get; set; }
        [Required]
        public bool Socket_11 { get; set; }
        [Required]
        public bool Socket_12 { get; set; }
        [Required]
        public bool Socket_13 { get; set; }
        [Required]
        public bool Socket_14 { get; set; }
        [Required]
        public bool Socket_15 { get; set; }
        [Required]
        public bool Socket_16 { get; set; }
        [Required]
        public bool Socket_17 { get; set; }
        [Required]
        public bool Socket_18 { get; set; }
        [Required]
        public bool Socket_19 { get; set; }
        [Required]
        public bool Socket_20 { get; set; }
        [Required]
        public bool Socket_21 { get; set; }
        [Required]
        public bool Socket_22 { get; set; }
        [Required]
        public bool Socket_23 { get; set; }
        [Required]
        public bool Socket_24 { get; set; }
        [Required]
        public bool Socket_25 { get; set; }
        [Required]
        public bool Socket_26 { get; set; }
        [Required]
        public bool Socket_27 { get; set; }
        [Required]
        public bool Socket_28 { get; set; }
        [Required]
        public bool Socket_29 { get; set; }
        [Required]
        public bool Socket_30 { get; set; }
        [Required]
        public bool Socket_31 { get; set; }
        [Required]
        public bool Socket_32 { get; set; }
        [Required]
        public bool Socket_33 { get; set; }
        [Required]
        public bool Socket_34 { get; set; }
        [Required]
        public bool Socket_35 { get; set; }
        [Required]
        public bool Socket_36 { get; set; }
        [Required]
        public bool Socket_37 { get; set; }
        [Required]
        public bool Socket_38 { get; set; }
        [Required]
        public bool Socket_39 { get; set; }
        [Required]
        public bool Socket_40 { get; set; }
        [Required]
        public bool Socket_41 { get; set; }
        [Required]
        public bool Socket_42 { get; set; }
        [Required]
        public bool Socket_43 { get; set; }
        [Required]
        public bool Socket_44 { get; set; }
        [Required]
        public bool Socket_45 { get; set; }
        [Required]
        public bool Socket_46 { get; set; }
        [Required]
        public bool Socket_47 { get; set; }
        [Required]
        public bool Socket_48 { get; set; }
        [Required]
        public bool Socket_49 { get; set; }
        [Required]
        public bool Socket_50 { get; set; }
        [Required]
        public bool Socket_51 { get; set; }
        [Required]
        public bool Socket_52 { get; set; }
        [Required]
        public bool Socket_53 { get; set; }
        [Required]
        public bool Socket_54 { get; set; }
        [Required]
        public bool Socket_55 { get; set; }
        [Required]
        public bool Socket_56 { get; set; }
        [Required]
        public bool Socket_57 { get; set; }
        [Required]
        public bool Socket_58 { get; set; }
        [Required]
        public bool Socket_59 { get; set; }
        [Required]
        public bool Socket_60 { get; set; }
        [Required]
        public bool Socket_61 { get; set; }
        [Required]
        public bool Socket_62 { get; set; }
        [Required]
        public bool Socket_63 { get; set; }
        [Required]
        public bool Socket_64 { get; set; }
    }
    public class BaseSocket:BaseColumns
    {
        [Required]
        public double Socket_1 { get; set; }
        [Required]
        public double Socket_2 { get; set; }
        [Required]
        public double Socket_3 { get; set; }
        [Required]
        public double Socket_4 { get; set; }
        [Required]
        public double Socket_5 { get; set; }
        [Required]
        public double Socket_6 { get; set; }
        [Required]
        public double Socket_7 { get; set; }
        [Required]
        public double Socket_8 { get; set; }
        [Required]
        public double Socket_9 { get; set; } 
        [Required]
        public double Socket_10 { get; set; }
        [Required]
        public double Socket_11 { get; set; }
        [Required]
        public double Socket_12 { get; set; }
        [Required]
        public double Socket_13 { get; set; }
        [Required]
        public double Socket_14 { get; set; }
        [Required]
        public double Socket_15 { get; set; }
        [Required]
        public double Socket_16 { get; set; }
        [Required]
        public double Socket_17 { get; set; }
        [Required]
        public double Socket_18 { get; set; }
        [Required]
        public double Socket_19 { get; set; }
        [Required]
        public double Socket_20 { get; set; }
        [Required]
        public double Socket_21 { get; set; }
        [Required]
        public double Socket_22 { get; set; }
        [Required]
        public double Socket_23 { get; set; }
        [Required]
        public double Socket_24 { get; set; }
        [Required]
        public double Socket_25 { get; set; }
        [Required]
        public double Socket_26 { get; set; }
        [Required]
        public double Socket_27 { get; set; }
        [Required]
        public double Socket_28 { get; set; }
        [Required]
        public double Socket_29 { get; set; }
        [Required]
        public double Socket_30 { get; set; }
        [Required]
        public double Socket_31 { get; set; }
        [Required]
        public double Socket_32 { get; set; }
        [Required]
        public double Socket_33 { get; set; }
        [Required]
        public double Socket_34 { get; set; }
        [Required]
        public double Socket_35 { get; set; }
        [Required]
        public double Socket_36 { get; set; }
        [Required]
        public double Socket_37 { get; set; }
        [Required]
        public double Socket_38 { get; set; }
        [Required]
        public double Socket_39 { get; set; }
        [Required]
        public double Socket_40 { get; set; }
        [Required]
        public double Socket_41 { get; set; }
        [Required]
        public double Socket_42 { get; set; }
        [Required]
        public double Socket_43 { get; set; }
        [Required]
        public double Socket_44 { get; set; }
        [Required]
        public double Socket_45 { get; set; }
        [Required]
        public double Socket_46 { get; set; }
        [Required]
        public double Socket_47 { get; set; }
        [Required]
        public double Socket_48 { get; set; }
        [Required]
        public double Socket_49 { get; set; }
        [Required]
        public double Socket_50 { get; set; }
        [Required]
        public double Socket_51 { get; set; }
        [Required]
        public double Socket_52 { get; set; }
        [Required]
        public double Socket_53 { get; set; }
        [Required]
        public double Socket_54 { get; set; }
        [Required]
        public double Socket_55 { get; set; }
        [Required]
        public double Socket_56 { get; set; }
        [Required]
        public double Socket_57 { get; set; }
        [Required]
        public double Socket_58 { get; set; }
        [Required]
        public double Socket_59 { get; set; }
        [Required]
        public double Socket_60 { get; set; }
        [Required]
        public double Socket_61 { get; set; }
        [Required]
        public double Socket_62 { get; set; }
        [Required]
        public double Socket_63 { get; set; }
        [Required]
        public double Socket_64 { get; set; }
    }

    public class BaseStatus_Socket : BaseColumns
    {
        [Required, StringLength(50)]
        public string Status_Socket_1 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_2 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_3 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_4 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_5 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_6 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_7 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_8 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_9 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_10 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_11 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_12 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_13 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_14 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_15 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_16 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_17 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_18 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_19 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_20 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_21 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_22 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_23 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_24 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_25 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_26 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_27 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_28 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_29 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_30 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_31 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_32 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_33 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_34 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_35 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_36 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_37 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_38 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_39 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_40 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_41 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_42 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_43 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_44 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_45 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_46 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_47 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_48 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_49 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_50 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_51 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_52 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_53 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_54 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_55 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_56 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_57 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_58 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_59 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_60 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_61 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_62 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_63 { get; set; }
        [Required, StringLength(50)]
        public string Status_Socket_64 { get; set; }
    }

    public class T_TEST_STATUS_DETAIL: BaseColumns
    {
        [Key]
        public Int32 ID { get; set; }
        [Required]
        public string PO_Number { get; set; }
        [Required]
        public string Jig_ID { get; set; }
        [Required]
        public string Machine_ID { get; set; }
        //public virtual M_JIG T_TEST_STATUS_DETAIL_M_JIG { get; set; }
        public virtual M_MACHINE_TESTER T_TEST_STATUS_DETAIL_M_MACHINE_TESTER { get; set; }
    }

    //public class T_TEST_STATUS_SOCKET: T_TEST_STATUS_DETAIL
    //{

    //}
    public class T_BASE_TEST_STATUS : T_TEST_STATUS_DETAIL
    {
        [Required, StringLength(100)]
        public string Socket_1 { get; set; }
        [Required, StringLength(100)]
        public string Socket_2 { get; set; }
        [Required, StringLength(100)]
        public string Socket_3 { get; set; }
        [Required, StringLength(100)]
        public string Socket_4 { get; set; }
        [Required, StringLength(100)]
        public string Socket_5 { get; set; }
        [Required, StringLength(100)]
        public string Socket_6 { get; set; }
        [Required, StringLength(100)]
        public string Socket_7 { get; set; }
        [Required, StringLength(100)]
        public string Socket_8 { get; set; }
        [Required, StringLength(100)]
        public string Socket_9 { get; set; }
        [Required, StringLength(100)]
        public string Socket_10 { get; set; }
        [Required, StringLength(100)]
        public string Socket_11 { get; set; }
        [Required, StringLength(100)]
        public string Socket_12 { get; set; }
        [Required, StringLength(100)]
        public string Socket_13 { get; set; }
        [Required, StringLength(100)]
        public string Socket_14 { get; set; }
        [Required, StringLength(100)]
        public string Socket_15 { get; set; }
        [Required, StringLength(100)]
        public string Socket_16 { get; set; }
        [Required, StringLength(100)]
        public string Socket_17 { get; set; }
        [Required, StringLength(100)]
        public string Socket_18 { get; set; }
        [Required, StringLength(100)]
        public string Socket_19 { get; set; }
        [Required, StringLength(100)]
        public string Socket_20 { get; set; }
        [Required, StringLength(100)]
        public string Socket_21 { get; set; }
        [Required, StringLength(100)]
        public string Socket_22 { get; set; }
        [Required, StringLength(100)]
        public string Socket_23 { get; set; }
        [Required, StringLength(100)]
        public string Socket_24 { get; set; }
        [Required, StringLength(100)]
        public string Socket_25 { get; set; }
        [Required, StringLength(100)]
        public string Socket_26 { get; set; }
        [Required, StringLength(100)]
        public string Socket_27 { get; set; }
        [Required, StringLength(100)]
        public string Socket_28 { get; set; }
        [Required, StringLength(100)]
        public string Socket_29 { get; set; }
        [Required, StringLength(100)]
        public string Socket_30 { get; set; }
        [Required, StringLength(100)]
        public string Socket_31 { get; set; }
        [Required, StringLength(100)]
        public string Socket_32 { get; set; }
        [Required, StringLength(100)]
        public string Socket_33 { get; set; }
        [Required, StringLength(100)]
        public string Socket_34 { get; set; }
        [Required, StringLength(100)]
        public string Socket_35 { get; set; }
        [Required, StringLength(100)]
        public string Socket_36 { get; set; }
        [Required, StringLength(100)]
        public string Socket_37 { get; set; }
        [Required, StringLength(100)]
        public string Socket_38 { get; set; }
        [Required, StringLength(100)]
        public string Socket_39 { get; set; }
        [Required, StringLength(100)]
        public string Socket_40 { get; set; }
        [Required, StringLength(100)]
        public string Socket_41 { get; set; }
        [Required, StringLength(100)]
        public string Socket_42 { get; set; }
        [Required, StringLength(100)]
        public string Socket_43 { get; set; }
        [Required, StringLength(100)]
        public string Socket_44 { get; set; }
        [Required, StringLength(100)]
        public string Socket_45 { get; set; }
        [Required, StringLength(100)]
        public string Socket_46 { get; set; }
        [Required, StringLength(100)]
        public string Socket_47 { get; set; }
        [Required, StringLength(100)]
        public string Socket_48 { get; set; }
        [Required, StringLength(100)]
        public string Socket_49 { get; set; }
        [Required, StringLength(100)]
        public string Socket_50 { get; set; }
        [Required, StringLength(100)]
        public string Socket_51 { get; set; }
        [Required, StringLength(100)]
        public string Socket_52 { get; set; }
        [Required, StringLength(100)]
        public string Socket_53 { get; set; }
        [Required, StringLength(100)]
        public string Socket_54 { get; set; }
        [Required, StringLength(100)]
        public string Socket_55 { get; set; }
        [Required, StringLength(100)]
        public string Socket_56 { get; set; }
        [Required, StringLength(100)]
        public string Socket_57 { get; set; }
        [Required, StringLength(100)]
        public string Socket_58 { get; set; }
        [Required, StringLength(100)]
        public string Socket_59 { get; set; }
        [Required, StringLength(100)]
        public string Socket_60 { get; set; }
        [Required, StringLength(100)]
        public string Socket_61 { get; set; }
        [Required, StringLength(100)]
        public string Socket_62 { get; set; }
        [Required, StringLength(100)]
        public string Socket_63 { get; set; }
        [Required, StringLength(100)]
        public string Socket_64 { get; set; }
    }

    
    public class T_TEST_DETAIL: T_TEST_STATUS_DETAIL
    {
       
        [Required, StringLength(200)]
        public string Type_Test { get; set; }
        //public string Type_Test_Data { get; set; }
        [Required]
        public DateTime Start_Test { get; set; }
        [Required]
        public DateTime End_Test { get; set; }
        [Required]
        public int BB_Temperature { get; set; }
       // [Required]
        public double Temperature { get; set; }
        //[Required]
        //public double Cooling_Plate_Temperature { get; set; }

        //public virtual M_JIG T_TEST_DETAIL_M_JIG { get; set; }
        //public virtual M_MACHINE_TESTER T_TEST_DETAIL_M_MACHINE_TESTER { get; set; }

    }

    public class T_BASE_TEST_DETAIL : T_TEST_DETAIL
    {
        [Required]
        public double Socket_1 { get; set; }
        [Required]
        public double Socket_2 { get; set; }
        [Required]
        public double Socket_3 { get; set; }
        [Required]
        public double Socket_4 { get; set; }
        [Required]
        public double Socket_5 { get; set; }
        [Required]
        public double Socket_6 { get; set; }
        [Required]
        public double Socket_7 { get; set; }
        [Required]
        public double Socket_8 { get; set; }
        [Required]
        public double Socket_9 { get; set; }
        [Required]
        public double Socket_10 { get; set; }
        [Required]
        public double Socket_11 { get; set; }
        [Required]
        public double Socket_12 { get; set; }
        [Required]
        public double Socket_13 { get; set; }
        [Required]
        public double Socket_14 { get; set; }
        [Required]
        public double Socket_15 { get; set; }
        [Required]
        public double Socket_16 { get; set; }
        [Required]
        public double Socket_17 { get; set; }
        [Required]
        public double Socket_18 { get; set; }
        [Required]
        public double Socket_19 { get; set; }
        [Required]
        public double Socket_20 { get; set; }
        [Required]
        public double Socket_21 { get; set; }
        [Required]
        public double Socket_22 { get; set; }
        [Required]
        public double Socket_23 { get; set; }
        [Required]
        public double Socket_24 { get; set; }
        [Required]
        public double Socket_25 { get; set; }
        [Required]
        public double Socket_26 { get; set; }
        [Required]
        public double Socket_27 { get; set; }
        [Required]
        public double Socket_28 { get; set; }
        [Required]
        public double Socket_29 { get; set; }
        [Required]
        public double Socket_30 { get; set; }
        [Required]
        public double Socket_31 { get; set; }
        [Required]
        public double Socket_32 { get; set; }
        [Required]
        public double Socket_33 { get; set; }
        [Required]
        public double Socket_34 { get; set; }
        [Required]
        public double Socket_35 { get; set; }
        [Required]
        public double Socket_36 { get; set; }
        [Required]
        public double Socket_37 { get; set; }
        [Required]
        public double Socket_38 { get; set; }
        [Required]
        public double Socket_39 { get; set; }
        [Required]
        public double Socket_40 { get; set; }
        [Required]
        public double Socket_41 { get; set; }
        [Required]
        public double Socket_42 { get; set; }
        [Required]
        public double Socket_43 { get; set; }
        [Required]
        public double Socket_44 { get; set; }
        [Required]
        public double Socket_45 { get; set; }
        [Required]
        public double Socket_46 { get; set; }
        [Required]
        public double Socket_47 { get; set; }
        [Required]
        public double Socket_48 { get; set; }
        [Required]
        public double Socket_49 { get; set; }
        [Required]
        public double Socket_50 { get; set; }
        [Required]
        public double Socket_51 { get; set; }
        [Required]
        public double Socket_52 { get; set; }
        [Required]
        public double Socket_53 { get; set; }
        [Required]
        public double Socket_54 { get; set; }
        [Required]
        public double Socket_55 { get; set; }
        [Required]
        public double Socket_56 { get; set; }
        [Required]
        public double Socket_57 { get; set; }
        [Required]
        public double Socket_58 { get; set; }
        [Required]
        public double Socket_59 { get; set; }
        [Required]
        public double Socket_60 { get; set; }
        [Required]
        public double Socket_61 { get; set; }
        [Required]
        public double Socket_62 { get; set; }
        [Required]
        public double Socket_63 { get; set; }
        [Required]
        public double Socket_64 { get; set; }
    }

}