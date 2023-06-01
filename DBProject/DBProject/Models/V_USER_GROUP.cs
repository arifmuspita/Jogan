using System;
using System.Collections.Generic;
using System.Linq;


namespace DBProject.Models
{
    public class V_USER_GROUP
    {
        public int ID { get; set; }
        public string Created_User { get; set; }
        public System.DateTime Created_Date { get; set; }
        public string User_ID { get; set; }
        public string Group_ID { get; set; }
        public string Group_Name { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string New_Password { get; set; }
        public bool Is_Active { get; set; }
    }
}