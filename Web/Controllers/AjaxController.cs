using DBProject.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class AjaxController : BaseController
    {
        private Int16 FCounter { get; set; }
        public List<object> SearchDevice(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            List<M_DEVICE> list__ = null;
            int id2 = 0;


            if (query.ContainsKey("term"))
            {
                string qry = query["term"];
                list__ = mc.M_DEVICES.Where(x => x.Device_ID.Contains(qry)).OrderBy(x => x.Device_ID).ToList();
            }
            else
            {
                list__ = mc.M_DEVICES.OrderBy(x => x.Device_ID).ToList();
                //var listm = mc.Database.SqlQuery<V_JIG_JIG_CLOSE_SOCKET>("select * from V_JIG_JIG_CLOSE_SOCKETS order by jig_id ");

            }

            int idxx = 1;
            foreach (var x in list__)
            {
                M_DEVICE mylist1 = new M_DEVICE();
                // mylist1.ID = 0;
                //mylist1.Calibration_Type = x.Calibration_Type;
                Commons.Commons.CopyProperties(x, mylist1);
                mylist.Add(mylist1);
            }
            return mylist;
        }
        public List<object> SearchTypeTest(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            List<M_NOISE_DEVICE_PARAMETER> list__ = null;
            int id2 = 0;


            if (query.ContainsKey("term"))
            {
                string qry = query["term"];
                list__ = mc.M_NOISE_DEVICE_PARAMETERS.Where(x => x.Test_Type_ID.Contains(qry)).OrderBy(x => x.Test_Type_ID).ToList();
            }
            else
            {
                list__ = mc.M_NOISE_DEVICE_PARAMETERS.OrderBy(x => x.Test_Type_ID).ToList();
                //var listm = mc.Database.SqlQuery<V_JIG_JIG_CLOSE_SOCKET>("select * from V_JIG_JIG_CLOSE_SOCKETS order by jig_id ");

            }

            int idxx = 1;
            foreach (var x in list__)
            {
                M_NOISE_DEVICE_PARAMETER mylist1 = new M_NOISE_DEVICE_PARAMETER();
                // mylist1.ID = 0;
                //mylist1.Calibration_Type = x.Calibration_Type;
                Commons.Commons.CopyProperties(x, mylist1);
                mylist.Add(mylist1);
            }
            return mylist;
        }
        public List<object> SignalDeviceParameter(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            List<V_DEVICE_DEVICE_SIGNAL_PARAMETER> list__ = null;
            int id2 = 0;

            if (id != "all")
            {
                //if (Int32.TryParse(id, out id2))
                //{
                //    list__ = mc.M_USER_GROUPS.Where(x => x.Group_ID == id2);
                //}
                //list__ = mc.M_NOISE_DEVICE_PARAMETERS.Where(x => x.Test_Type_ID == id).OrderBy(x => x.Test_Type_ID).ToList();
                list__ = mc.Database.SqlQuery<V_DEVICE_DEVICE_SIGNAL_PARAMETER>("select * from V_DEVICE_DEVICE_SIGNAL_PARAMETER where ID =" + id + " order by Device_ID").ToList();
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    //list__ = mc.M_NOISE_DEVICE_PARAMETERS.Where(x => x.Test_Type_Name.Contains(qry)).OrderBy(x => x.Test_Type_Name).ToList();
                    list__ = mc.Database.SqlQuery<V_DEVICE_DEVICE_SIGNAL_PARAMETER>("select * from V_DEVICE_DEVICE_SIGNAL_PARAMETER where Device_Name like '%" + qry + "%' order by Test_Type_ID").ToList();
                }
                else
                {
                    list__ = mc.Database.SqlQuery<V_DEVICE_DEVICE_SIGNAL_PARAMETER>("select * from V_DEVICE_DEVICE_SIGNAL_PARAMETER  order by Device_ID").ToList();
                    //var listm = mc.Database.SqlQuery<V_JIG_JIG_CLOSE_SOCKET>("select * from V_JIG_JIG_CLOSE_SOCKETS order by jig_id ");

                }
            }
            int idxx = 1;
            foreach (var x in list__)
            {
                V_DEVICE_DEVICE_SIGNAL_PARAMETER mylist1 = new V_DEVICE_DEVICE_SIGNAL_PARAMETER();
                //mylist1.ID = x.Device_ID;
                //mylist1.Device_ID = x.Device_ID;
                //mylist1.Device_Name = x.Device_Name;
                //mylist1.Response_Grp_Max = x.Response_Grp_Max;
                //mylist1.Offset_Min = x.Offset_Min;
                //mylist1.Offset_Max = x.Offset_Max;
                //mylist1.Offset_Grp_Min = x.Offset_Grp_Min;
                //mylist1.Offset_Grp_Max = x.Offset_Grp_Max;
                //mylist1.No_Response = x.No_Response;
                //mylist1.Response_Min = x.Response_Min;
                //mylist1.Response_Max = x.Response_Max;
                // mylist1.ID = 0;
                //mylist1.Calibration_Type = x.Calibration_Type;
                Commons.Commons.CopyProperties(x, mylist1);
                mylist1.ID = x.ID;
                mylist.Add(mylist1);
            }
            return mylist;
        }
        public List<object> NoiseDevice(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            List<V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER> list__ = null;
            int id2 = 0;

            if (id != "all")
            {
                //if (Int32.TryParse(id, out id2))
                //{
                //    list__ = mc.M_USER_GROUPS.Where(x => x.Group_ID == id2);
                //}
                //list__ = mc.M_NOISE_DEVICE_PARAMETERS.Where(x => x.Test_Type_ID == id).OrderBy(x => x.Test_Type_ID).ToList();
                list__ = mc.Database.SqlQuery<V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER>("select * from V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER where Test_Type_ID ='" + id + "' order by Test_Type_ID").ToList();
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    //list__ = mc.M_NOISE_DEVICE_PARAMETERS.Where(x => x.Test_Type_Name.Contains(qry)).OrderBy(x => x.Test_Type_Name).ToList();
                    list__ = mc.Database.SqlQuery<V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER>("select * from V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER where Test_Type_ID like '%" + qry + "%' order by Test_Type_ID").ToList();
                }
                else
                {
                    list__ = mc.Database.SqlQuery<V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER>("select * from V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER  order by Device_ID,Test_Type_ID").ToList();
                    //var listm = mc.Database.SqlQuery<V_JIG_JIG_CLOSE_SOCKET>("select * from V_JIG_JIG_CLOSE_SOCKETS order by jig_id ");

                }
            }
            int idxx = 1;
            foreach (var x in list__)
            {
                V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER mylist1 = new V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER();
                // mylist1.ID = 0;
                //mylist1.Calibration_Type = x.Calibration_Type;
                Commons.Commons.CopyProperties(x, mylist1);
                mylist.Add(mylist1);
            }
            return mylist;
        }
        public List<object> NoiseDeviceParameter(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            List<M_NOISE_DEVICE_PARAMETER> list__ = null;
            int id2 = 0;

            if (id != "all")
            {
                //if (Int32.TryParse(id, out id2))
                //{
                //    list__ = mc.M_USER_GROUPS.Where(x => x.Group_ID == id2);
                //}
                list__ = mc.M_NOISE_DEVICE_PARAMETERS.Where(x => x.Test_Type_ID == id).OrderBy(x => x.Test_Type_ID).ToList();
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    list__ = mc.M_NOISE_DEVICE_PARAMETERS.Where(x => x.Test_Type_Name.Contains(qry)).OrderBy(x => x.Test_Type_Name).ToList();
                }
                else
                {
                    list__ = mc.M_NOISE_DEVICE_PARAMETERS.OrderBy(x => x.Test_Type_ID).ToList();
                    //var listm = mc.Database.SqlQuery<V_JIG_JIG_CLOSE_SOCKET>("select * from V_JIG_JIG_CLOSE_SOCKETS order by jig_id ");

                }
            }
            int idxx = 1;
            foreach (var x in list__)
            {
                M_NOISE_DEVICE_PARAMETER mylist1 = new M_NOISE_DEVICE_PARAMETER();
                // mylist1.ID = 0;
                //mylist1.Calibration_Type = x.Calibration_Type;
                Commons.Commons.CopyProperties(x, mylist1);
                mylist.Add(mylist1);
            }
            return mylist;
        }
        public List<object> MachineCalibrationDetail(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            List<V_MACHINE_MACHINE_CALIBRATION> list__ = null;
            int id2 = 0;

            if (id != "all")
            {
                //list__ = mc.V_MACHINE_MACHINE_CALIBRATIONS.Where(x => x.Machine_ID == id).OrderBy(x => x.Machine_ID).ToList();
                list__ = mc.Database.SqlQuery<V_MACHINE_MACHINE_CALIBRATION>("select * from V_MACHINE_MACHINE_CALIBRATION where machine_id = '"+id+"' order by Machine_ID,Calibration_Type").ToList();
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    //list__ = mc.V_MACHINE_MACHINE_CALIBRATIONS.Where(x => x.Machine_Name.Contains(qry)).OrderBy(x => x.Machine_Name).ToList();
                    list__ = mc.Database.SqlQuery<V_MACHINE_MACHINE_CALIBRATION>("select * from V_MACHINE_MACHINE_CALIBRATION where machine_name like '%" + qry + "%' order by Machine_ID,Calibration_Type").ToList();
                }
                else
                {
                    //list__ = mc.V_MACHINE_MACHINE_CALIBRATIONS.OrderBy(x => x.Machine_ID).ThenBy(x=>x.Calibration_Type).ToList();
                    //var listm = mc.Database.SqlQuery<V_JIG_JIG_CLOSE_SOCKET>("select * from V_JIG_JIG_CLOSE_SOCKETS order by jig_id ");
                    list__ = mc.Database.SqlQuery<V_MACHINE_MACHINE_CALIBRATION>("select * from V_MACHINE_MACHINE_CALIBRATION where machine_id = '" + id + "' order by Machine_ID,Calibration_Type").ToList();
                }
            }
            int idxx = 1;
            foreach (var x in list__)
            {
                V_MACHINE_MACHINE_CALIBRATION mylist1 = new V_MACHINE_MACHINE_CALIBRATION();
                // mylist1.ID = 0;
                mylist1.Calibration_Type = x.Calibration_Type;
                mylist.Add(mylist1);
            }
            return mylist;
        }

        public List<object> MachineCalibrationType(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            List<M_MACHINE_TESTER_CALIBRATION_TYPE> list__ = null;
            int id2 = 0;

            if (id != "all")
            {
                //if (Int32.TryParse(id, out id2))
                //{
                //    list__ = mc.M_USER_GROUPS.Where(x => x.Group_ID == id2);
                //}
                list__ = mc.M_MACHINE_TESTER_CALIBRATION_TYPES.Where(x => x.Calibration_Type == id).OrderBy(x => x.Calibration_Type).ToList();
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    list__ = mc.M_MACHINE_TESTER_CALIBRATION_TYPES.Where(x => x.Calibration_Type.Contains(qry)).OrderBy(x => x.Calibration_Type).ToList();
                }
                else
                {
                    list__ = mc.M_MACHINE_TESTER_CALIBRATION_TYPES.OrderBy(x => x.Calibration_Type).ToList();
                    //var listm = mc.Database.SqlQuery<V_JIG_JIG_CLOSE_SOCKET>("select * from V_JIG_JIG_CLOSE_SOCKETS order by jig_id ");

                }
            }
            int idxx = 1;
            foreach (var x in list__)
            {
                M_MACHINE_TESTER_CALIBRATION_TYPE mylist1 = new M_MACHINE_TESTER_CALIBRATION_TYPE();
                // mylist1.ID = 0;
                mylist1.Calibration_Type = x.Calibration_Type; 
                mylist.Add(mylist1);
            }
            return mylist;
        }
        public List<object> Machine(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            List<M_MACHINE_TESTER> list__ = null;
            int id2 = 0;

            if (id != "all")
            {
                //if (Int32.TryParse(id, out id2))
                //{
                //    list__ = mc.M_USER_GROUPS.Where(x => x.Group_ID == id2);
                //}
                list__ = mc.M_MACHINE_TESTERS.Where(x => x.Machine_ID == id).OrderBy(x => x.Machine_ID).ToList();
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    list__ = mc.M_MACHINE_TESTERS.Where(x => x.Machine_Name.Contains(qry)).OrderBy(x => x.Machine_Name).ToList();
                }
                else
                {
                    list__ = mc.M_MACHINE_TESTERS.OrderBy(x => x.Machine_ID).ToList();
                    //var listm = mc.Database.SqlQuery<V_JIG_JIG_CLOSE_SOCKET>("select * from V_JIG_JIG_CLOSE_SOCKETS order by jig_id ");

                }
            }
            int idxx = 1;
            foreach (var x in list__)
            {
                M_MACHINE_TESTER mylist1 = new M_MACHINE_TESTER();
                // mylist1.ID = 0;
                mylist1.Machine_ID = x.Machine_ID;
                mylist1.Machine_Name = x.Machine_Name;
                mylist1.Machines_Type = x.Machines_Type; 
                mylist1.Machine_Number = x.Machine_Number;
                mylist1.Machine_Line_Number = x.Machine_Line_Number;
                mylist.Add(mylist1);
            }
            return mylist;
        }
        public List<object> Device(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            List<M_DEVICE> list__ = null;
            int id2 = 0;

            if (id != "all")
            {
                //if (Int32.TryParse(id, out id2))
                //{
                //    list__ = mc.M_USER_GROUPS.Where(x => x.Group_ID == id2);
                //}
                list__ = mc.M_DEVICES.Where(x => x.Device_ID == id).OrderBy(x => x.Device_ID).ToList();
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    list__ = mc.M_DEVICES.Where(x => x.Device_Name.Contains(qry)).OrderBy(x => x.Device_Name).ToList();
                }
                else
                {
                    list__ = mc.M_DEVICES.OrderBy(x => x.Device_ID).ToList();
                    //var listm = mc.Database.SqlQuery<V_JIG_JIG_CLOSE_SOCKET>("select * from V_JIG_JIG_CLOSE_SOCKETS order by jig_id ");

                }
            }
            int idxx = 1;
            foreach (var x in  list__)
            {
                M_DEVICE mylist1 = new M_DEVICE();
                // mylist1.ID = 0;
                mylist1.Device_ID = x.Device_ID;
                mylist1.Device_Name = x.Device_Name;
                mylist1.Device_Status = x.Device_Status;
                mylist.Add(mylist1);
            }
            return mylist;
        }
        public List<object> Jig(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            IQueryable list__ = null;
            int id2 = 0;

            if (id != "all")
            {
                //if (Int32.TryParse(id, out id2))
                //{
                //    list__ = mc.M_USER_GROUPS.Where(x => x.Group_ID == id2);
                //}
                list__ = mc.M_JIGS.Where(x => x.Jig_ID == id).OrderBy(x => x.Jig_ID);
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    list__ = mc.M_JIGS.Where(x => x.Jig_Carrier_Name.Contains(qry)).OrderBy(x => x.Jig_Carrier_Name);
                }
                else
                {
                    list__ = mc.M_JIGS.OrderBy(x => x.Jig_ID);
                    //var listm = mc.Database.SqlQuery<V_JIG_JIG_CLOSE_SOCKET>("select * from V_JIG_JIG_CLOSE_SOCKETS order by jig_id ");

                }
            }
            int idxx = 1;
            foreach (var x in (IQueryable<M_JIG>)list__)
            {
                M_JIG mylist1 = new M_JIG();
                // mylist1.ID = 0;
                mylist1.Jig_ID = x.Jig_ID;
                mylist1.Jig_Carrier_Name = x.Jig_Carrier_Name;
                mylist.Add(mylist1);
            }
            return mylist;
        }

        public List<object> UserGroup(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            IQueryable list__ = null;
            int id2 = 0;

            if (id != "all")
            {
                //if (Int32.TryParse(id, out id2))
                //{
                //    list__ = mc.M_USER_GROUPS.Where(x => x.Group_ID == id2);
                //}
                list__ = mc.M_USER_GROUPS.Where(x => x.Group_ID == id).OrderBy(x => x.Group_ID);
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    list__ = mc.M_USER_GROUPS.Where(x => x.Group_Name.Contains(qry)).OrderBy(x => x.Group_ID);
                }
                else
                {
                    list__ = mc.M_USER_GROUPS.OrderBy(x => x.Group_ID);
                }
            }
            int idxx = 1;
            foreach (var x in (IQueryable<M_USER_GROUP>)list__)
            {
                M_USER_GROUP mylist1 = new M_USER_GROUP();
               // mylist1.ID = 0;
                mylist1.Group_ID = x.Group_ID;
                mylist1.Group_Name = x.Group_Name; 
                mylist.Add(mylist1);
            }
            return mylist;
        }

        public List<object> Users(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            List<V_USER_GROUP> list__ = null;
            int id2 = 0;
            //list__ = (from x in ((IQueryable<V_USER_GROUP>)mc.Database.SqlQuery<V_USER_GROUP>("select * from V_USER_GROUP").ToList())
            //          select x
            //          ) ;
            if (id != "all")
            {
                //list__ = mc.V_USER_GROUPS.Where(x => x.User_ID == id);
                list__ = mc.Database.SqlQuery<V_USER_GROUP>("select * from V_USER_GROUP where User_ID '"+id+ "' order by group_id,name").ToList();
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    //list__ = mc.V_USER_GROUPS.Where(x => x.Name.Contains(qry)).OrderBy(x => x.Group_ID).ThenBy(x => x.Name);
                    list__ =  mc.Database.SqlQuery<V_USER_GROUP>("select * from V_USER_GROUP where name like '%" + qry + "%' order by group_id,name").ToList();
                }
                else
                {
                    //list__ = mc.V_USER_GROUPS.OrderBy(x => x.Group_ID).ThenBy(x => x.Name);
                    list__ =  mc.Database.SqlQuery<V_USER_GROUP>("select * from V_USER_GROUP  order by group_id,name").ToList();
                }
            }
            int idxx = 1;
            foreach (var x in list__)
            {
                V_USER_GROUP mylist1 = new V_USER_GROUP();
                mylist1.ID = x.ID;
                mylist1.Group_ID = x.Group_ID;
                mylist1.Group_Name = x.Group_Name;
                mylist1.Name = x.Name; 
                mylist1.Password = x.Password; 
                mylist1.User_ID = x.User_ID; 
                mylist.Add(mylist1);
            }
            return mylist;
        }
        // GET: Ajax
        public List<object> GoldenSample(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            IQueryable list__ = null;
            int id2 = 0;

            if (id != "all")
            {
                list__ = mc.M_GOLDEN_SAMPLES.Select(x => x.Device_Test_Ref).Distinct();
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    list__ = mc.M_GOLDEN_SAMPLES.Where(x => x.Device_Test_Ref.Contains(qry)).Distinct();
                }
                else
                {
                    list__ = mc.M_GOLDEN_SAMPLES.Select(x => x.Device_Test_Ref).Distinct();
                }
            }
            int idxx = 1;
           // foreach (var x in (IQueryable<M_GOLDEN_SAMPLE>)list__)
            foreach (var x in  list__)
            {
                M_GOLDEN_SAMPLE mylist1 = new M_GOLDEN_SAMPLE();
                // mylist1.ID = 0;
                mylist1.Device_Test_Ref = (string)x; //(string)x.GetType().GetProperty(nmField).GetValue(x);
                mylist.Add(mylist1);
            }
            return mylist;
        }

        public List<object> GoldenSampleDetail(DBProjectEntities mc, string id, Dictionary<string, string> query)
        {
            List<object> mylist = new List<object>();
            List<M_GOLDEN_SAMPLE> list__ = new List<M_GOLDEN_SAMPLE>();
            //IQueryable list__ = null;
            int id2 = 0;

            if (id != "all")
            {
                list__ = mc.M_GOLDEN_SAMPLES.Where(x => x.Device_Test_Ref==id).OrderBy(x => x.Golden_Sample_Type).ToList();
            }
            else
            {
                if (query.ContainsKey("q"))
                {
                    string qry = query["q"];
                    list__ = mc.M_GOLDEN_SAMPLES.Where(x => x.Device_Test_Ref.Contains(qry)).OrderBy(x => x.Golden_Sample_Type).ToList();
                }
                else
                {
                    list__ = mc.M_GOLDEN_SAMPLES.Where(x => x.Device_Test_Ref == id).OrderBy(x => x.Golden_Sample_Type).ToList();
                }
            }
            int idxx = 1;
            // foreach (var x in (IQueryable<M_GOLDEN_SAMPLE>)list__)
            foreach (var x in list__)
            {
                M_GOLDEN_SAMPLE mylist1 = new M_GOLDEN_SAMPLE();
                Commons.Commons.CopyProperties(x, mylist1);
                // mylist1.ID = 0;
                //mylist1.Device_Test_Ref = (string)x; //(string)x.GetType().GetProperty(nmField).GetValue(x);
                mylist.Add(mylist1);
            }
            return mylist;
        }

        public ActionResult GetDataTableList(string submodul, string idx)
        {
            Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(submodul);

            string input = Request.Url.Query;
            var parsedQuery = HttpUtility.ParseQueryString(input);
            Dictionary<string, string> queries = new Dictionary<string, string>();

            foreach (var aa in parsedQuery.AllKeys)
            {
                queries.Add(aa, parsedQuery[aa]);
            }

            List<object> mylist = null;
            using (var mc = new DBProjectEntities())
            {
                mylist = (List<object>)theMethod.Invoke(this, new object[] { mc, idx, queries });
            }
            int pageDisplay = 25;
            if (queries.ContainsKey("length")) { pageDisplay=Convert.ToInt32(queries["length"]); }
            int start = 0;
            if (queries.ContainsKey("start")) { start = Convert.ToInt32(queries["start"]); } 
            int ttlRecord = mylist.Count;
            if (start != 0) { mylist = mylist.Skip(start).ToList(); }
            if (pageDisplay != -1) { mylist = mylist.Take(pageDisplay).ToList(); }

            int colid = -1;
            if (queries.ContainsKey("order[0][column]")) { colid = Convert.ToInt32(queries["order[0][column]"]); }
            string coldir = "";
            if (queries.ContainsKey("order[0][dir]")) { coldir = queries["order[0][dir]"]; }
            string colnm = ""; //columns[1][data]
            if (queries.ContainsKey("columns[" + colid.ToString() + "][data]")) { colnm = queries["columns[" + colid.ToString() + "][data]"]; }
            if (colnm.ToUpper() != "ACTION")
            {
                if (colid!=-1 && coldir!="" && colnm != "")
                {
                    if (coldir.ToUpper() == "ASC")
                    {
                        mylist = (from x in mylist
                                  orderby ( x.GetType().GetProperty(colnm).GetValue(x)) ascending
                                  select x).ToList();
                    } else
                    {
                        mylist = (from x in mylist
                                  orderby ( x.GetType().GetProperty(colnm).GetValue(x)) descending
                                  select x).ToList();
                    }
                }
            }


            //    var model = _db.MyDataBase
            //.OrderBy(row => row.ID)
            //.Skip((start - 1) * pageDisplay)
            //.Take(pageDisplay)
            //.ToList();

            return Json(new
            {
                draw = FCounter,//pageDisplay,
                recordsTotal = ttlRecord,
                recordsFiltered = ttlRecord,
                data = mylist,
            }, JsonRequestBehavior.AllowGet);
            FCounter++;
        }
        public ActionResult AutoComplete(string submodul, string idx)
        {
            Type thisType = this.GetType();
            MethodInfo theMethod = thisType.GetMethod(submodul);

            string input = Request.Url.Query;
            var parsedQuery = HttpUtility.ParseQueryString(input);
            Dictionary<string, string> queries = new Dictionary<string, string>();

            foreach (var aa in parsedQuery.AllKeys)
            {
                queries.Add(aa, parsedQuery[aa]);
            }

            List<object> mylist = null;
            using (var mc = new DBProjectEntities())
            {
                mylist = (List<object>)theMethod.Invoke(this, new object[] { mc, idx, queries });
            }

            return Json(mylist, JsonRequestBehavior.AllowGet);
        }
    }
}