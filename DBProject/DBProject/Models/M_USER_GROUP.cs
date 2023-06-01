using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace DBProject.Models
{
    public class M_USER_GROUP:BaseColumns
    {
        [Key]
        public string Group_ID { get; set; }
        [StringLength(500)]
        public string Group_Name { get; set; }
    }

    public class UserGroup2 
    {
        public Int32 ID { get; set; } 
        public string Created_User { get; set; } 
        public DateTime Created_Date { get; set; }
        public string Group_ID { get; set; } 
        public string Group_Name { get; set; }
    }

    public class UserGroup3 : UserGroup2
    {
        
        public string UserName { get; set; }
        public string BagdeNo { get; set; }
        public bool IsActive { get; set; }
    }
}