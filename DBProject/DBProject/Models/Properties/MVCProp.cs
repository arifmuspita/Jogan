using DBProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBProject.Models.Properties
{
    public class UserRightAccess
    {
        public bool Allow_Read { get; set; }
        public bool Allow_Add { get; set; }
        public bool Allow_Edit { get; set; }
        public bool Allow_Delete { get; set; }
        public bool Allow_Report { get; set; }
    }
    public class UserAccess2: UserRightAccess
    { 
        public int ID { get; set; }
        public int TotalChild { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Detail { get; set; }
    }
    public class GroupPriveleges
    {
        public string Group_ID { get; set; }
        public string Group_Name { get; set; }
        public List<SP_GROUP_PRIVILEGES> Menus { get; set; }
    }
    public class PostGroupPriveleges
    {
        public string Group_ID { get; set; }
        public string[] Menu_ID { get; set; }
        public string[] Allow_Read { get; set; }
        public string[] Allow_Add { get; set; }
        public string[] Allow_Edit { get; set; }
        public string[] Allow_Delete { get; set; }
        public string[] Allow_Report { get; set; }
    }
    public class MVCProp
    {
        private UserRightAccess FUserRightAccess;
        public MVCProp()
        {
            //CreateDataTable = false;
            //CreateFilter = false;
            ModuleName = "";
            DataObject = null;
            Method = "list";
            //DetailMasterDataCount = 0;
        }
        public string WebRoot { get; set; }
        //public int DetailMasterDataCount { get; set; }
        public bool CreateDataTable { get; set; }
        //public bool CreateFilter { get; set; }
        public object DataObject { get; set; }
        public string Method { get; set; }
        public string ModuleName { get; set; }

        public string SetWebUrl(string AUrl)
        {
            string url = "";
            if (WebRoot == "") { url = AUrl; } else { url = "/" + WebRoot + AUrl; }
            return url;
        }
        public UserRightAccess UserRightAccess
        {
            get
            {
                if (FUserRightAccess == null) { FUserRightAccess = new UserRightAccess { Allow_Add = false, Allow_Delete = false, Allow_Edit = false }; }
                return FUserRightAccess;
            }
        }
        public void GetUserRightAccess(string groupid)
        {
            FUserRightAccess = new UserRightAccess { Allow_Add = false, Allow_Delete = false, Allow_Edit = false };
            using (var mc = new DBProjectEntities())
            {
                V_USER_GROUP grp = mc.V_USER_GROUPS.Where(x => x.Group_ID == groupid).FirstOrDefault();
                if (grp != null)
                {
                    if (grp.Group_ID == "G-001")
                    {
                        FUserRightAccess.Allow_Add = true;
                        FUserRightAccess.Allow_Delete = true;
                        FUserRightAccess.Allow_Edit = true;
                    }
                    else
                    {
                        V_USER_GROUP_PRIVILEGES listm = mc.V_USER_GROUP_PRIVILEGES.Where(x => x.Group_ID == groupid && x.Module == ModuleName).FirstOrDefault();
                        if (listm != null)
                        {
                            FUserRightAccess.Allow_Add = listm.Allow_Add;
                            FUserRightAccess.Allow_Delete = listm.Allow_Delete;
                            FUserRightAccess.Allow_Edit = listm.Allow_Edit;
                        }
                    }
                }
            }
        }
    }

    //public class MVCProp2<T>:MVCProp
    //{
    //    public T Data { get; set; }
    //    public Object DataObject2
    //    {
    //        get
    //        {
    //            if (Data == null) { }
    //            return T;
    //        }
    //    }
    //}

}