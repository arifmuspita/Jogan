using DBProject.Models.Properties;
using DBProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using DBProject.Models;
using System.Web.Configuration;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        public string WebRoot
        {
            get { return WebConfigurationManager.AppSettings["WebRoot"].ToString(); }
        }
        // GET: Baseprivate MVCProp FMVCProp;
        private MVCProp FMVCProp; 
        public MVCProp MVCProp
        {
            get
            {
                if (FMVCProp == null) { FMVCProp = new MVCProp(); FMVCProp.WebRoot = WebRoot; }
                return FMVCProp;
            }
        }
       
        public string GetSessionsID(string UserID)
        {
            string ret = "";
            using (var mc = new DBProjectEntities())
            {

                bool isExist = false;
                T_USER_SESSION us = mc.T_USER_SESSIONS.Where(x => x.User_ID == UserID).FirstOrDefault();
                isExist = (us != null);
                if (!isExist) { us = new T_USER_SESSION { User_ID = UserID }; }

                us.Session_ID = Guid.NewGuid().ToString("N");
                us.Session_Token = Guid.NewGuid().ToString("N");
                if (isExist) { mc.Entry(us).CurrentValues.SetValues(us); }
                else
                {
                    mc.T_USER_SESSIONS.Add(us);
                }
                //mc.AccountSessions.
                mc.SaveChanges();

                ret = us.Session_ID;

            }
            return ret;
        }
        public string UserID
        {
            get
            {
                string ret = "";
                T_USER_SESSION sess = Commons.Commons.JSONToObjectFromCookies<T_USER_SESSION>("web_session");
                if (sess != null)
                {
                    ret = sess.User_ID;
                }
                return ret;
            }
        }

        public string GroupID
        {
            get
            {
                string nm = "";
                using (var mc = new DBProjectEntities())
                {
                    M_USER member = mc.M_USERS.Where(x => x.User_ID == UserID).FirstOrDefault();
                    nm = member.Group_ID;
                }
                return nm;
            }
        }

        public string UserName
        {
            get
            {
                string nm = "";
                using (var mc = new DBProjectEntities())
                {
                    M_USER member = mc.M_USERS.Where(x => x.User_ID == UserID).FirstOrDefault();
                    nm = member.Name;
                }
                return nm;
            }
        }

        public string GetUserName(string userid)
        {
            string nm = "";
            using (var mc = new DBProjectEntities())
            {
                M_USER member = mc.M_USERS.Where(x => x.User_ID == userid).FirstOrDefault();
                nm = member.Name;
            }
            return nm;
        }
        public string GetGroupName(string groupid)
        {
            string nm = "";
            using (var mc = new DBProjectEntities())
            {
                M_USER_GROUP member = mc.M_USER_GROUPS.Where(x => x.Group_ID == groupid).FirstOrDefault();
                nm = member.Group_Name;
            }
            return nm;
        }

        // GET: Base
        //public string GroupID
        //{
        //    get
        //    {
        //        string nm = "";
        //        using (var mc = new DBProjectEntities())
        //        {
        //            //UserGroup grp = mc.UserGroups.Where(x => x.ID == UserID).FirstOrDefault();
        //            //nm = member.Name;
        //        }
        //        return nm;
        //    }
        //}

        //public string GroupName
        //{
        //    get
        //    {
        //        string nm = "";
        //        using (var mc = new DBProjectEntities())
        //        {
        //            //User member = mc.Users.Where(x => x.ID == MemberID).FirstOrDefault();
        //            //nm = member.Name;
        //        }
        //        return nm;
        //    }
        //} 

        public delegate ActionResult Transaction(DBProjectEntities model, object obj, Message message);
        public ActionResult Transactions(object obj, Transaction MyTransaction, bool IsGetData, string MessageAction = "CreateMessage", Message message = null, Message message2 = null)
        {

            if (message == null) { message = new Message(); }
            if (message2 == null) { message2 = new Message(); }
            ActionResult ret = null;

            try
            {
                if (IsGetData)
                {
                    using (var mc = new DBProjectEntities())
                    {
                        ret = MyTransaction(mc, obj, message);
                    }
                }
                else
                {
                    using (TransactionScope trans = new TransactionScope())
                    {
                        using (var mc = new DBProjectEntities())
                        {
                            ret = MyTransaction(mc, obj, message);
                        }
                        trans.Complete();
                    }
                }
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("<br/>", errorMessages);

                // Combine the original exception message with the new one.
                //var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                string msg = "The validation errors are: <br/>" + fullErrorMessage;

                message.MessageText = msg;
                TempData["Message"] = message;
                if (MessageAction != "") { return RedirectToAction(MessageAction,"Home"); }
            }
            catch (Exception e)
            {
                string msg = e.Message;
                if (e.InnerException != null)
                {
                    msg = msg + "<br/>" + e.InnerException.Message;
                    if (e.InnerException.InnerException != null)
                    {
                        msg = msg + "<br/>" + e.InnerException.InnerException.Message;
                    }
                }
                message.MessageText = msg;
                TempData["Message"] = message;
                if (MessageAction != "") { return RedirectToAction(MessageAction, "Home"); }
            }

            return ret;
        }
    }
}