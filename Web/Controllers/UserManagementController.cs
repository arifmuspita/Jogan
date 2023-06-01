using DBProject.Models;
using DBProject.Models;
using DBProject.Models.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UserManagementController : BaseController
    {
        // GET: UserManagement


        public ActionResult UserGroup(string method, string id1)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "UserGroup";
            MVCProp.GetUserRightAccess(GroupID);
            if (method == null)
            {
                MVCProp.Method = "list";

                act = View(MVCProp);
            }
            else
            {
                switch (method)
                {
                    case "add":
                    case "edit":
                        act = Transactions(new M_USER_GROUP(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = ""; }
                                //int id_ = Convert.ToInt32(id1);
                                M_USER_GROUP p = model.M_USER_GROUPS.Where(x => x.Group_ID == id1).FirstOrDefault();
                                if (p == null) { p = new M_USER_GROUP(); }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        act = Transactions(new M_USER_GROUP { Group_ID =  id1 },
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                //void process here
                                return View(MVCProp);
                            }, false
                            );
                        break;
                }
            }
            return act;
        }

        [HttpPost]
        public ActionResult UserGroup(M_USER_GROUP p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            if (p != null)
            {
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        M_USER_GROUP p2 = model.M_USER_GROUPS.Where(x => x.Group_ID == p.Group_ID).FirstOrDefault();
                        if (p2 == null)
                        {
                            model.M_USER_GROUPS.Add(new M_USER_GROUP
                            {
                                Group_ID = p.Group_ID,
                                Group_Name = p.Group_Name,
                                Created_User = UserID,
                            });
                            var mn = model.M_MENUS.OrderBy(x => x.Code);
                            foreach(var item in mn)
                            {
                                model.M_USER_GROUP_PRIVILEGESS.Add(
                                    new M_USER_GROUP_PRIVILEGES { Allow_Add=true,Allow_Delete=true,Allow_Edit=true,Allow_Export=true,Allow_Read=true,Allow_Report=true,Code="",Created_Date=DateTime.Now,Created_User=UserID,Group_ID=p.Group_ID,ID=0,Is_Active=true,Menu_ID=item.ID,Name="",Updated_Date=DateTime.Now,Updated_User=""} 
                                    );
                            }

                        }
                        else
                        {
                            p2.Group_ID = p.Group_ID;
                            p2.Group_Name = p.Group_Name;
                            p2.Updated_User = UserID;
                            model.Entry(p2).CurrentValues.SetValues(p2);
                        }

                        model.SaveChanges();
                        return RedirectToAction("UserGroup");
                    }, false
                );
            }
            return act;
        }

        public ActionResult Users(string method, string id1)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "Users";
            MVCProp.GetUserRightAccess(GroupID);
            if (method == null)
            {
                MVCProp.Method = "list";
                act = View(MVCProp);
            }
            else
            {
                switch (method)
                {
                    case "add":
                    case "edit":
                        act = Transactions(new V_USER_GROUP(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                               // int id_ = Convert.ToInt32(id1);
                                V_USER_GROUP p = model.V_USER_GROUPS.Where(x => x.User_ID == id1).FirstOrDefault();
                                if (p == null) { p = new V_USER_GROUP(); }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        act = Transactions(new V_USER_GROUP { User_ID = id1 },
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                //void process here
                                return View(MVCProp);
                            }, false
                            );
                        break;
                }
            }
            return act;
        }

        [HttpPost]
        public ActionResult Users(M_USER p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            if (p != null)
            {
                string salt = "";
                string passwd = "";// Commons.Commons.EncryptPWDTK(p.Password, "", out salt);
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {

                        M_USER p2 = model.M_USERS.Where(x => x.User_ID == p.User_ID).FirstOrDefault();
                        if (p2 == null)
                        {
                            passwd = Commons.Commons.EncryptMD5(p.Password);// EncryptPWDTK(p.Password, "", out salt);
                            model.M_USERS.Add(new M_USER
                            {
                                Name = p.Name,
                                Password = passwd,
                                Group_ID = p.Group_ID,
                                User_ID = p.User_ID,
                                Created_User = UserID
                            });
                        }
                        else
                        {
                            p2.Name = p.Name;
                            p2.Group_ID = p.Group_ID;
                            p2.Updated_User = UserID;
                            model.Entry(p2).CurrentValues.SetValues(p2);
                        }
                        model.SaveChanges();
                        return RedirectToAction("Users");
                    }, false
                );
            }
            return act;
        }

        public ActionResult ChangeProfile()
        {
            ActionResult act = null;
            MVCProp.ModuleName = "ChangeProfile";
            MVCProp.GetUserRightAccess(UserID);
            using (var db = new  DBProjectEntities())
            {
                V_USER_GROUP p = db.V_USER_GROUPS.Where(x => x.User_ID == UserID).FirstOrDefault();
                if (p == null) { p = new V_USER_GROUP(); }
                MVCProp.DataObject = p;
                MVCProp.Method = "edit";
                MVCProp.CreateDataTable = false;
                return View(MVCProp);
            }
        }
        [HttpPost]
        public ActionResult ChangeProfile(V_USER_GROUP p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            string salt = "";
            string passwd = "";// Commons.Commons.EncryptPWDTK(p.Password, "", out salt);
            string msg = "";
            V_USER_GROUP p22 = null;
            Message message1 = new Message();
            if (p != null)
            {
                using (var db = new  DBProjectEntities())
                {
                    p22 = db.V_USER_GROUPS.Where(x => x.User_ID == UserID).FirstOrDefault();
                    passwd = Commons.Commons.EncryptMD5(p.Password); //.EncryptPWDTK(p.Password, p.Salt, out salt);
                    if (p22 == null)
                    {
                        msg = "Your session end. Please Login again";
                        message1.MessageText = msg;
                        TempData["Message"] = message1;
                        return RedirectToAction("CreateMessage", "Home");
                    }
                    else if (p22.Password != passwd)
                    {
                        msg = "Your password is invalid. Change data failed.";
                        message1.MessageText = msg;
                        TempData["Message"] = message1;
                        return RedirectToAction("CreateMessage", "Home");
                    }
                }


                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        M_USER p2 = model.M_USERS.Where(x => x.User_ID == UserID).FirstOrDefault();
                        //p2.BagdeNo = p.BagdeNo; 
                        p2.Name = p.Name;
                        if (p.New_Password != null)
                        {
                            passwd = Commons.Commons.EncryptMD5(p.New_Password); //.EncryptPWDTK(p.NewPassword, p.Salt, out salt);
                            p2.Password = passwd;
                        }
                        //p2.Salt = salt;
                        //p2.UserName = p.UserName;
                        //p2.M_USER_GROUPID = p.M_USER_GROUPID;
                        p2.Updated_User = UserID;
                        model.Entry(p2).CurrentValues.SetValues(p2);

                        model.SaveChanges();
                        return RedirectToAction("Index", "Home");
                    }, false
                );
            }
            return act;
        }

        public ActionResult GroupPriveleges()
        {
            ActionResult act = null;
            MVCProp.ModuleName = "GroupPriveleges";
            MVCProp.GetUserRightAccess(GroupID);
            MVCProp.Method = "list";
            return View(MVCProp);
        }


        public ActionResult GroupPrivelegesDetail(string method, string id1)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "GroupPrivelegesDetail";
            //int userid = Convert.ToInt32(id1);
            MVCProp.GetUserRightAccess(id1);
            MVCProp.Method = "list";
            using (var db = new DBProjectEntities())
            {
                GroupPriveleges acc = new GroupPriveleges { Group_ID = id1, Group_Name = GetGroupName(id1) }; 
                var mn = db.Database.SqlQuery<SP_GROUP_PRIVILEGES>("SP_GROUP_PRIVILEGES @GroupID", new SqlParameter("GroupID", id1)).ToList();

                acc.Group_ID = id1;
                acc.Menus = mn;
                MVCProp.DataObject = acc;
            }

            return View(MVCProp);
        }

        [HttpPost]
        public ActionResult GroupPrivelegesDetail(PostGroupPriveleges p)
        {
            ActionResult act = null;
            if (p != null)
            {
               // string salt = "";
                //string passwd = "";// Commons.Commons.EncryptPWDTK(p.Password, "", out salt);
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        model.Database.ExecuteSqlCommand("delete from M_USER_GROUP_PRIVILEGES where Group_ID='" + p.Group_ID+"'");
                        int cch = 0;
                        foreach(string item in p.Allow_Read)
                        {
                            if (item != "0")
                            {
                                M_USER_GROUP_PRIVILEGES um = new M_USER_GROUP_PRIVILEGES
                                {
                                    Allow_Add = p.Allow_Add[cch] != "0",
                                    Allow_Delete = p.Allow_Delete[cch] != "0",
                                    Allow_Edit = p.Allow_Edit[cch] != "0",
                                    Allow_Read = true, 
                                    Created_User=UserID,
                                    Is_Active=true,
                                    Menu_ID = Convert.ToInt32(p.Menu_ID[cch]), 
                                    Updated_User= UserID,
                                    Group_ID =  p.Group_ID
                                };
                                model.M_USER_GROUP_PRIVILEGESS.Add(um);
                            }
                            cch++;
                        }
                        model.SaveChanges(); 
                        return RedirectToAction("GroupPriveleges");
                    }, false
                );
            }
            return act;
        }

    }
}