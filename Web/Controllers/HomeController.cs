using DBProject.Models;
using DBProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Home()
        {
            MVCProp.ModuleName = "Home";
            //ViewBag.Page = "dashboard";
            //ViewBag.CreateFilter = false;
            return View(MVCProp);
        }
        // GET: Home
        public ActionResult Index()
        {
            // ViewBag.CreateFilter = false;
            string session = Commons.Commons.GetSessions("web_session");
            if (session == "")
            {
                return RedirectToAction("Login");
            }
            else
            {
                //ViewBag.Page = "dashboard";
                MVCProp.ModuleName = "index";
                return View(MVCProp);
            }
        }

        public ActionResult Login()
        {
            //ViewBag.Page = "login";
            //ViewBag.Message = TempData["Message"];
            //ViewBag.CreateFilter = false;
            MVCProp.ModuleName = "login";
            MVCProp.DataObject = TempData["Message"];
            return View(MVCProp);
        }

        public ActionResult GetUserMenu()
        {

            List<M_MENU> list =new List<M_MENU>();
            string groupid = GroupID;
            if (groupid != "")
            {
                using (var mc = new DBProjectEntities())
                {
                    V_USER_GROUP grp = mc.V_USER_GROUPS.Where(x => x.Group_ID == groupid).FirstOrDefault();
                    if (grp != null)
                    {
                        if (grp.Group_ID.ToUpper()=="G-001")
                        {
                            list = mc.M_MENUS.Where(x=> x.Menu_For=="Web" && x.Is_Active).OrderBy(x => x.Code).ToList();
                        } else
                        {
                            //var listm = mc.V_USER_GROUP_PRIVILEGES.Where(x => x.Group_ID == grp.Group_ID).OrderBy(x => x.Code);

                            var listm = mc.Database.SqlQuery<M_MENU>("select * from V_USER_GROUP_PRIVILEGES where not code like '99%' and group_id = '" + grp.Group_ID + "' order by code");
                            foreach (var item in listm){
                                list.Add(new M_MENU { 
                                    ID= item.ID,
                                    Detail = item.Detail,
                                    Code = item.Code,
                                    Module = item.Module,
                                    Module_Parent = item.Module_Parent,
                                    Name = item.Name,
                                    Parent_ID = item.Parent_ID
                                });
                            }
                        }
                    }
                }
            }
            return PartialView(list);
        }

        [HttpPost]
        public ActionResult Login(M_USER user)
        {
            return Transactions(user,
                delegate (DBProjectEntities model, object obj, Message message)
                {
                    M_USER u = model.M_USERS.Where(x => x.User_ID == user.User_ID).FirstOrDefault();
                    if (u == null)
                    {
                        TempData["Message"] = new Message { Title = "Login", MessageText = "Your User Id not regitered", Succes = false };
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        string salt = "";
                        string passwd = Commons.Commons.EncryptMD5(user.Password); //.EncryptPWDTK(user.Password, u.Salt, out salt);
                        u = model.M_USERS.Where(x => x.User_ID == user.User_ID && x.Password == passwd).FirstOrDefault();
                        if (u == null)
                        {
                            TempData["Message"] = new Message { Title = "Login", MessageText = "Your User ID and/or Password invalid", Succes = false };
                            return RedirectToAction("Login");
                        }
                        else
                        {
                            string sess = GetSessionsID(u.User_ID);
                            Commons.Commons.SetSessions("web_session", new T_USER_SESSION { User_ID = u.User_ID, Session_ID = sess });
                        }
                    }
                    return RedirectToAction("Home");
                }, true
                );
            //return View();
        }
        public ActionResult Logout()
        {
            Commons.Commons.SetSessionsClear();
            TempData["Message"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult CreateMessage()
        {
            MVCProp.ModuleName = "CheckList";
            //MVCProp.CreateFilter = false;
            MVCProp.CreateDataTable = false;
            MVCProp.DataObject = TempData["Message"];
            // TempData["Message"] = message;
            return View(MVCProp);
        }

        public ActionResult LoginFromDesktopApp(string method,string id1)
        {
            using(var db=new DBProjectEntities())
            {
                M_USER u = db.M_USERS.Where(x => x.User_ID == method && x.Password == id1).FirstOrDefault();
                if (u == null)
                {
                    TempData["Message"] = new Message { Title = "Login", MessageText = "Your User Id not regitered", Succes = false };
                    return RedirectToAction("Login");
                }
                else
                {
                   // string salt = "";
                    //string passwd = Commons.Commons.EncryptMD5(.Password); //.EncryptPWDTK(user.Password, u.Salt, out salt);
                    u = db.M_USERS.Where(x => x.User_ID == method && x.Password == id1).FirstOrDefault();
                    if (u == null)
                    {
                        TempData["Message"] = new Message { Title = "Login", MessageText = "Your User ID and/or Password invalid", Succes = false };
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        string sess = GetSessionsID(u.User_ID);
                        Commons.Commons.SetSessions("web_session", new T_USER_SESSION { User_ID = u.User_ID, Session_ID = sess });
                        return RedirectToAction("Home");
                    }
                }
               
            }
            //return RedirectToAction("Home");
        }
    }
}