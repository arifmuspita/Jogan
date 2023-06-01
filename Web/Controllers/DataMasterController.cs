using DBProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class DataMasterController : BaseController
    {
        public ActionResult SignalDeviceParameter(string method, string id1, string id2)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "SignalDeviceParameter";
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
                        act = Transactions(new V_DEVICE_DEVICE_SIGNAL_PARAMETER(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = "0"; }
                                int id_ = Convert.ToInt32(id1);
                                V_DEVICE_DEVICE_SIGNAL_PARAMETER p = model.V_DEVICE_DEVICE_SIGNAL_PARAMETERS.Where(x => x.ID==id_).FirstOrDefault();
                                if (p == null)
                                {
                                    p = new V_DEVICE_DEVICE_SIGNAL_PARAMETER();

                                }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        act = Transactions(new V_DEVICE_DEVICE_SIGNAL_PARAMETER { ID = 0  },
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
        public ActionResult SignalDeviceParameter(M_SIGNAL_DEVICE_PARAMETER p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            if (p != null)
            {
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        M_SIGNAL_DEVICE_PARAMETER p2 = model.M_SIGNAL_DEVICE_PARAMETERS.Where(x => x.ID == p.ID  ).FirstOrDefault();
                        if (p2 == null)
                        {
                            p2 = new M_SIGNAL_DEVICE_PARAMETER();
                            Commons.Commons.CopyProperties(p, p2);
                            p2.Created_User = UserID;
                            model.M_SIGNAL_DEVICE_PARAMETERS.Add(p2);
                        }
                        else
                        {
                            Commons.Commons.CopyProperties(p, p2);
                            p2.Updated_User = UserID;
                            model.Entry(p2).CurrentValues.SetValues(p2);
                        }

                        //model.M_JIG_CLOSE_SOCKETS.Add();

                        model.SaveChanges();
                        return RedirectToAction("SignalDeviceParameter");
                    }, false
                );
            }
            return act;
        }
        public ActionResult NoiseDevice(string method, string id1, string id2)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "NoiseDevice";
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
                        act = Transactions(new V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = ""; }
                                //int id_ = Convert.ToInt32(id1);
                                V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER p = model.V_NOISE_DEVICE_NOISE_DEVICE_PARAMETERS.Where(x => x.Test_Type_ID == id2 && x.Device_ID == id1).FirstOrDefault();
                                if (p == null)
                                {
                                    p = new V_NOISE_DEVICE_NOISE_DEVICE_PARAMETER();

                                }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        act = Transactions(new M_NOISE_DEVICE { Test_Type_ID = id2,Device_ID=id1 },
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
        public ActionResult NoiseDevice(M_NOISE_DEVICE p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            if (p != null)
            {
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        M_NOISE_DEVICE p2 = model.M_NOISE_DEVICES.Where(x => x.Test_Type_ID == p.Test_Type_ID && x.Device_ID==p.Device_ID).FirstOrDefault();
                        if (p2 == null)
                        {
                            p2 = new M_NOISE_DEVICE();
                            Commons.Commons.CopyProperties(p, p2);
                            p2.Created_User = UserID;
                            model.M_NOISE_DEVICES.Add(p2);
                        }
                        else
                        {
                            Commons.Commons.CopyProperties(p, p2);
                            p2.Updated_User = UserID;
                            model.Entry(p2).CurrentValues.SetValues(p2);
                        }

                        //model.M_JIG_CLOSE_SOCKETS.Add();

                        model.SaveChanges();
                        return RedirectToAction("NoiseDevice");
                    }, false
                );
            }
            return act;
        }
        public ActionResult NoiseDeviceParameter(string method, string id1)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "NoiseDeviceParameter";
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
                        act = Transactions(new M_NOISE_DEVICE_PARAMETER(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = ""; }
                                //int id_ = Convert.ToInt32(id1);
                                M_NOISE_DEVICE_PARAMETER p = model.M_NOISE_DEVICE_PARAMETERS.Where(x => x.Test_Type_ID == id1).FirstOrDefault();
                                if (p == null)
                                {
                                    p = new M_NOISE_DEVICE_PARAMETER();

                                }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        act = Transactions(new M_NOISE_DEVICE_PARAMETER { Test_Type_ID = id1 },
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
        public ActionResult NoiseDeviceParameter(M_NOISE_DEVICE_PARAMETER p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            if (p != null)
            {
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        M_NOISE_DEVICE_PARAMETER p2 = model.M_NOISE_DEVICE_PARAMETERS.Where(x => x.Test_Type_ID == p.Test_Type_ID).FirstOrDefault();
                        if (p2 == null)
                        {
                            p2 = new M_NOISE_DEVICE_PARAMETER();
                            Commons.Commons.CopyProperties(p, p2);
                            p2.Created_User = UserID;
                            model.M_NOISE_DEVICE_PARAMETERS.Add(p2);  
                        }
                        else
                        {
                            Commons.Commons.CopyProperties(p, p2);
                            p2.Updated_User = UserID;
                            model.Entry(p2).CurrentValues.SetValues(p2); 
                        }

                        //model.M_JIG_CLOSE_SOCKETS.Add();

                        model.SaveChanges();
                        return RedirectToAction("NoiseDeviceParameter");
                    }, false
                );
            }
            return act;
        }
        // GET: DataMaster
        public ActionResult Jig(string method, string id1)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "Jig";
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
                        act = Transactions(new V_JIG_JIG_CLOSE_SOCKET(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = ""; }
                                //int id_ = Convert.ToInt32(id1);
                                V_JIG_JIG_CLOSE_SOCKET p = model.V_JIG_JIG_CLOSE_SOCKETS.Where(x => x.Jig_ID == id1).FirstOrDefault();
                                if (p == null) {
                                    p = new V_JIG_JIG_CLOSE_SOCKET();
                                    M_JIG j = model.M_JIGS.Where(x => x.Jig_ID == id1).FirstOrDefault();
                                    p.Jig_ID = j.Jig_ID;
                                    p.Jig_Carrier_Name = j.Jig_Carrier_Name;
                                }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        act = Transactions(new M_JIG { Jig_ID = id1 },
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
        public ActionResult Jig(V_JIG_JIG_CLOSE_SOCKET p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            if (p != null)
            {
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        V_JIG_JIG_CLOSE_SOCKET p2 = model.V_JIG_JIG_CLOSE_SOCKETS.Where(x => x.Jig_ID == p.Jig_ID).FirstOrDefault();
                        //model.Database.ExecuteSqlCommand("delete from M_JIG_CLOSE_SOCKET where jig_id ='" + p.Jig_ID + "'");
                        M_JIG_CLOSE_SOCKET jig = model.M_JIG_CLOSE_SOCKETS.Where(x => x.Jig_ID == p.Jig_ID).FirstOrDefault();

                        if (p2 == null)
                        {
                            jig =  new M_JIG_CLOSE_SOCKET();
                            model.M_JIGS.Add(new M_JIG
                            {
                                Jig_ID = p.Jig_ID,
                                Jig_Carrier_Name = p.Jig_Carrier_Name,
                                Created_User = UserID,
                            });
                            //Commons.Commons.CopyProperties(p, jig);
                            //jig.Created_User = UserID;
                            //jig.Created_Date = DateTime.Now; 
                            //model.M_JIG_CLOSE_SOCKETS.Add(jig);
                        }
                        else
                        {
                            p2.Jig_ID = p.Jig_ID;
                            p2.Jig_Carrier_Name = p.Jig_Carrier_Name;
                            p2.Updated_User = UserID;
                            model.Entry(p2).CurrentValues.SetValues(p2);
                            //Commons.Commons.CopyProperties(p, jig);
                            //jig.Updated_User = UserID;
                            //jig.Updated_Date = DateTime.Now;
                            //model.Entry(jig).CurrentValues.SetValues(jig);
                        }

                        //model.M_JIG_CLOSE_SOCKETS.Add();

                        model.SaveChanges();
                        return RedirectToAction("Jig");
                    }, false
                );
            }
            return act;
        }

        public ActionResult Device(string method, string id1)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "Jig";
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
                        act = Transactions(new M_DEVICE(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = ""; }
                                //int id_ = Convert.ToInt32(id1);
                                M_DEVICE p = model.M_DEVICES.Where(x => x.Device_ID == id1).FirstOrDefault();
                                if (p == null) { p = new M_DEVICE(); }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        act = Transactions(new M_DEVICE { Device_ID = id1 },
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
        public ActionResult Device(M_DEVICE p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            if (p != null)
            {
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        M_DEVICE p2 = model.M_DEVICES.Where(x => x.Device_ID == p.Device_ID).FirstOrDefault(); 

                        if (p2 == null)
                        { 
                            model.M_DEVICES.Add(new M_DEVICE
                            {
                                Device_ID = p.Device_ID,
                                Device_Name = p.Device_Name,
                                Device_Status=p.Device_Status,
                                Created_User = UserID,
                            });
                            
                        }
                        else
                        {
                            p2.Device_ID = p.Device_ID;
                            p2.Device_Name = p.Device_Name;
                            p2.Device_Status = p.Device_Status;
                            p2.Updated_User = UserID;
                            model.Entry(p2).CurrentValues.SetValues(p2); 
                        }

                        //model.M_JIG_CLOSE_SOCKETS.Add();

                        model.SaveChanges();
                        return RedirectToAction("Device");
                    }, false
                );
            }
            return act;
        }
        public ActionResult Machine(string method, string id1)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "Machine";
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
                        act = Transactions(new M_MACHINE_TESTER(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = ""; }
                                //int id_ = Convert.ToInt32(id1);
                                M_MACHINE_TESTER p = model.M_MACHINE_TESTERS.Where(x => x.Machine_ID == id1).FirstOrDefault();
                                if (p == null) { p = new M_MACHINE_TESTER(); }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        act = Transactions(new M_MACHINE_TESTER { Machine_ID = id1 },
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
        public ActionResult Machine(M_MACHINE_TESTER p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            if (p != null)
            {
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        M_MACHINE_TESTER p2 = model.M_MACHINE_TESTERS.Where(x => x.Machine_ID == p.Machine_ID).FirstOrDefault();

                        if (p2 == null)
                        {
                            model.M_MACHINE_TESTERS.Add(new M_MACHINE_TESTER
                            {
                                Machine_ID = p.Machine_ID,
                                Machine_Name = p.Machine_Name,
                                Machines_Type = p.Machines_Type,
                                Created_User = UserID,
                            });

                        }
                        else
                        {
                            p2.Machine_ID = p.Machine_ID;
                            p2.Machine_Name = p.Machine_Name;
                            p2.Machines_Type = p.Machines_Type;
                            p2.Updated_User = UserID;
                            model.Entry(p2).CurrentValues.SetValues(p2);
                        }

                        //model.M_JIG_CLOSE_SOCKETS.Add();

                        model.SaveChanges();
                        return RedirectToAction("Machine");
                    }, false
                );
            }
            return act;
        }
        public ActionResult MachineCalibrationType(string method, string id1)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "MachineCalibrationType";
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
                        act = Transactions(new M_MACHINE_TESTER_CALIBRATION_TYPE(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = ""; }
                                //int id_ = Convert.ToInt32(id1);
                                M_MACHINE_TESTER_CALIBRATION_TYPE p = model.M_MACHINE_TESTER_CALIBRATION_TYPES.Where(x => x.Calibration_Type == id1).FirstOrDefault();
                                if (p == null) { p = new M_MACHINE_TESTER_CALIBRATION_TYPE(); }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        act = Transactions(new M_MACHINE_TESTER_CALIBRATION_TYPE { Calibration_Type = id1 },
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
        public ActionResult MachineCalibrationType(M_MACHINE_TESTER_CALIBRATION_TYPE p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            if (p != null)
            {
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        M_MACHINE_TESTER_CALIBRATION_TYPE p2 = model.M_MACHINE_TESTER_CALIBRATION_TYPES.Where(x => x.Calibration_Type == p.Calibration_Type).FirstOrDefault();

                        if (p2 == null)
                        {
                            model.M_MACHINE_TESTER_CALIBRATION_TYPES.Add(new M_MACHINE_TESTER_CALIBRATION_TYPE
                            {
                                Calibration_Type = p.Calibration_Type, 
                                Created_User = UserID,
                            });

                        }
                        else
                        {
                            p2.Calibration_Type = p.Calibration_Type; 
                            p2.Updated_User = UserID;
                            model.Entry(p2).CurrentValues.SetValues(p2);
                        }

                        //model.M_JIG_CLOSE_SOCKETS.Add();

                        model.SaveChanges();
                        return RedirectToAction("MachineCalibrationType");
                    }, false
                );
            }
            return act;
        }
        public ActionResult MachineCalibration(string method, string id1)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "MachineCalibration";
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
                        act = Transactions(new M_MACHINE_TESTER_CALIBRATION(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = ""; }
                                int id_ = Convert.ToInt32(id1);
                                M_MACHINE_TESTER_CALIBRATION p = model.M_MACHINE_TESTER_CALIBRATIONS.Where(x => x.ID == id_).FirstOrDefault();
                                if (p == null) { p = new M_MACHINE_TESTER_CALIBRATION(); }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        int id2_ = Convert.ToInt32(id1);
                        act = Transactions(new M_MACHINE_TESTER_CALIBRATION { ID = id2_ },
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
        public ActionResult MachineCalibrationDetail(string method, string id1, string id2)
        {
            V_MACHINE_MACHINE_CALIBRATION p = null;
            M_MACHINE_TESTER m = null;
            ActionResult act = null;
            MVCProp.ModuleName = "MachineCalibrationDetail";
            MVCProp.GetUserRightAccess(GroupID);
            if (method == "list")
            {
              
                using (var db = new DBProjectEntities())
                {
                    p = db.V_MACHINE_MACHINE_CALIBRATIONS.Where(x => x.Machine_ID == id1).FirstOrDefault();
                    m = db.M_MACHINE_TESTERS.Where(x => x.Machine_ID == id1).FirstOrDefault();
                }
                if (p == null) { p = new V_MACHINE_MACHINE_CALIBRATION();
                    p.Machine_ID = m.Machine_ID;
                    p.Machine_Name = m.Machine_Name; 
                }
                MVCProp.DataObject = p;
                //MVCProp.CreateDataTable = false;
                MVCProp.Method = "list";

                act = View(MVCProp);
            }
            else
            {
                switch (method)
                {
                    case "add":
                    case "edit": 
                        act = Transactions(new V_MACHINE_MACHINE_CALIBRATION(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = ""; }
                                // int id_ = Convert.ToInt32(id1);
                                p = model.V_MACHINE_MACHINE_CALIBRATIONS.Where(x => x.Machine_ID == id2 && x.Calibration_Type == id1).FirstOrDefault();
                                m = model.M_MACHINE_TESTERS.Where(x => x.Machine_ID == id2).FirstOrDefault();
                                if (p == null) { p = new V_MACHINE_MACHINE_CALIBRATION(); p.Machine_ID = m.Machine_ID;
                                    p.Machine_Name = m.Machine_Name;
                                }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        //int id2_ = Convert.ToInt32(id1);
                        act = Transactions(new M_MACHINE_TESTER_CALIBRATION { Machine_ID = id1,  Calibration_Type = id2 },
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
        public ActionResult MachineCalibrationDetail(V_MACHINE_MACHINE_CALIBRATION p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            if (p != null)
            {
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        string cal = p.Calibration_Type == null ? p.Calibration_Type2 : p.Calibration_Type;
                        M_MACHINE_TESTER_CALIBRATION p2 = model.M_MACHINE_TESTER_CALIBRATIONS.Where(x => x.Machine_ID == p.Machine_ID && x.Calibration_Type == cal).FirstOrDefault();

                        if (p2 == null)
                        {
                            //M_MACHINE_TESTER_CALIBRATION p3 = new M_MACHINE_TESTER_CALIBRATION();
                            Commons.Commons.CopyProperties(p, p2);
                            p2.Created_User = UserID;
                            model.M_MACHINE_TESTER_CALIBRATIONS.Add(p2);

                        }
                        else
                        {
                           
                            Commons.Commons.CopyProperties(p, p2);
                            p2.Updated_User = UserID;
                            model.Entry(p2).CurrentValues.SetValues(p2);
                        }

                        //model.M_JIG_CLOSE_SOCKETS.Add();

                        model.SaveChanges();
                        return RedirectToAction("MachineCalibrationDetail");

                        //return RedirectToAction("MachineCalibrationDetail" "list/" + p.Machine_ID });
                    }, false
                );
            }
            return act;
        }


        public ActionResult GoldenSample(string method, string id1)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "GoldenSample";
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
                        act = Transactions(new M_GOLDEN_SAMPLE(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = ""; }
                                //int id_ = Convert.ToInt32(id1);
                                M_GOLDEN_SAMPLE p = model.M_GOLDEN_SAMPLES.Where(x => x.Device_Test_Ref == id1).FirstOrDefault();
                                if (p == null) { p = new M_GOLDEN_SAMPLE(); }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        act = Transactions(new M_GOLDEN_SAMPLE { Device_Test_Ref = id1 },
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
        public ActionResult GoldenSampleDetail(string method, string id1)
        {
            ActionResult act = null;
            MVCProp.ModuleName = "GoldenSample";
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
                        act = Transactions(new M_GOLDEN_SAMPLE(),
                            delegate (DBProjectEntities model, object obj, Message message)
                            {
                                if (id1 == null) { id1 = ""; }
                                //int id_ = Convert.ToInt32(id1);
                                M_GOLDEN_SAMPLE p = model.M_GOLDEN_SAMPLES.Where(x => x.Device_Test_Ref == id1).FirstOrDefault();
                                if (p == null) { p = new M_GOLDEN_SAMPLE(); }
                                MVCProp.DataObject = p;
                                MVCProp.Method = "edit";
                                MVCProp.CreateDataTable = false;
                                return View(MVCProp);
                            }, true
                            );
                        break;
                    case "delete":
                        act = Transactions(new M_GOLDEN_SAMPLE { Device_Test_Ref = id1 },
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
        public ActionResult GoldenSampleDetail(M_GOLDEN_SAMPLE_POST p)// POSMVCProp Prop)
        {
            ActionResult act = null;
            if (p != null)
            {
                act = Transactions(p,
                    delegate (DBProjectEntities model, object obj, Message message)
                    {
                        model.Database.ExecuteSqlCommand("delete from M_GOLDEN_SAMPLE where Device_Test_Ref = '" + p.Device_Test_Ref + "'");
                        int len = p.Golden_Sample_Type.Count();
                        //int cch = 0;
                        for (int i = 0; i <= len-1; i++)
                        {
                            DateTime dt = DateTime.Now;
                            M_GOLDEN_SAMPLE gs = new M_GOLDEN_SAMPLE
                            {
                                Created_Date = dt,
                                Created_User=UserID,
                                Device_Test_Ref = p.Device_Test_Ref,
                                Golden_Sample_Type = p.Golden_Sample_Type[i],
                                Socket_1=p.Socket_1[i],
                                Socket_2=p.Socket_2[i],
                                Socket_3=p.Socket_3[i],
                                Socket_4=p.Socket_4[i],
                                Socket_5=p.Socket_5[i],
                                Socket_6=p.Socket_6[i],
                                Socket_7=p.Socket_7[i],
                                Socket_8=p.Socket_8[i],
                                Socket_9=p.Socket_9[i],
                                Socket_10=p.Socket_10[i],
                                Socket_11=p.Socket_11[i],
                                Socket_12=p.Socket_12[i],
                                Socket_13=p.Socket_13[i],
                                Socket_14=p.Socket_14[i],
                                Socket_15=p.Socket_15[i],
                                Socket_16=p.Socket_16[i],
                                Socket_17=p.Socket_17[i],
                                Socket_18=p.Socket_18[i],
                                Socket_19=p.Socket_19[i],
                                Socket_20=p.Socket_20[i],
                                Socket_21=p.Socket_21[i],
                                Socket_22=p.Socket_22[i],
                                Socket_23=p.Socket_23[i],
                                Socket_24=p.Socket_24[i],
                                Socket_25=p.Socket_25[i],
                                Socket_26=p.Socket_26[i],
                                Socket_27=p.Socket_27[i],
                                Socket_28=p.Socket_28[i],
                                Socket_29=p.Socket_29[i],
                                Socket_30=p.Socket_30[i],
                                Socket_31=p.Socket_31[i],
                                Socket_32=p.Socket_32[i],
                                Socket_33=p.Socket_33[i],
                                Socket_34=p.Socket_34[i],
                                Socket_35=p.Socket_35[i],
                                Socket_36=p.Socket_36[i],
                                Socket_37=p.Socket_37[i],
                                Socket_38=p.Socket_38[i],
                                Socket_39=p.Socket_39[i],
                                Socket_40=p.Socket_40[i],
                                Socket_41=p.Socket_41[i],
                                Socket_42=p.Socket_42[i],
                                Socket_43=p.Socket_43[i],
                                Socket_44=p.Socket_44[i],
                                Socket_45=p.Socket_45[i],
                                Socket_46=p.Socket_46[i],
                                Socket_47=p.Socket_47[i],
                                Socket_48=p.Socket_48[i],
                                Socket_49=p.Socket_49[i],
                                Socket_50=p.Socket_50[i],
                                Socket_51=p.Socket_51[i],
                                Socket_52=p.Socket_52[i],
                                Socket_53=p.Socket_53[i],
                                Socket_54=p.Socket_54[i],
                                Socket_55=p.Socket_55[i],
                                Socket_56=p.Socket_56[i],
                                Socket_57=p.Socket_57[i],
                                Socket_58=p.Socket_58[i],
                                Socket_59=p.Socket_59[i],
                                Socket_60=p.Socket_60[i],
                                Socket_61=p.Socket_61[i],
                                Socket_62=p.Socket_62[i],
                                Socket_63=p.Socket_63[i],
                                Socket_64 = p.Socket_64[i],
                                ID=0,
                                Updated_Date=dt,
                                Updated_User=UserID
                            };
                            model.M_GOLDEN_SAMPLES.Add(gs);
                        }
                        model.SaveChanges();
                        return RedirectToAction("GoldenSample");
                    }, false
                );
            }
            return act;
        }

    }
}