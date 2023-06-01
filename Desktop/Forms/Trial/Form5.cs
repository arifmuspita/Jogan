using DBProject.Models;
using Desktop.Reports;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Trial
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public static Stream loadEmbededReportDefinition(string reportName)
        {
            Assembly _assembly = Assembly.GetExecutingAssembly();
            Stream _reportStream = _assembly.GetManifestResourceStream("Desktop.Reports." + reportName);

            return _reportStream;
        }

        private void SetErrorSummary(T_SORTER_SUMMARY Sorter, string ErrorCode)
        {
            using (var db = new DBProjectEntities())
            {
                DateTime maxdate = db.Database.SqlQuery<DateTime>("select max(created_date) from M_NG_CONFIG").FirstOrDefault();

                M_NG_CONFIG conf = db.M_NG_CONFIGS.Where(x => x.NG_Code == ErrorCode && x.Created_Date == maxdate).FirstOrDefault();
                if (conf == null)
                {
                    Sorter.Qty_NG_Other++;
                }
                else
                {
                    switch (ErrorCode)
                    {
                        case "E1": Sorter.Qty_NG1++;break;
                        case "E2": Sorter.Qty_NG2++;break;
                        case "E3": Sorter.Qty_NG3++;break;
                        case "E4": Sorter.Qty_NG4++;break;
                        case "E5": Sorter.Qty_NG5++;break;
                        case "E6": Sorter.Qty_NG6++;break;
                        case "E7": Sorter.Qty_NG7++;break;
                    }
                }
            }
        }
        private void TrySaveChange(DBProjectEntities context)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {


                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                ); // Add the original exception as the innerException
            }
        }
        private void PrepareTestResult(string PONumber, string JidID = "")
        {
            using (var db = new DBProjectEntities())
            {
                //db.Database.ExecuteSqlCommand("delete from T_SORTER_SUMMARY where po_number = '" + PONumber + "'");
                //db.Database.ExecuteSqlCommand("delete from T_SORTER_RESULT where po_number = '" + PONumber + "'");
                DateTime dt = DateTime.Now;
                //List< SP_TESTING_STATUS> data = db.Database.SqlQuery<SP_TESTING_STATUS>("SP_TESTING_STATUS @PONumber", new SqlParameter("PONumber", PONumber)).ToList();
                //var jigs = db.Database.SqlQuery<string>("select distinct jig_id from v_testing_status where po_number ='" + PONumber + "'").ToList();
                string sql = "select distinct jig_id from v_testing_status where po_number ='" + PONumber + "'";
                if (JidID != "") { sql = sql + " and Jig_ID='" + JidID + "'"; }
                var jigs = db.Database.SqlQuery<string>(sql).ToList();
                T_SORTER_SUMMARY ss = new T_SORTER_SUMMARY
                {
                    Created_Date = dt,
                    Created_User = "",
                    ID = 0,
                    PO_Number = PONumber,
                    Jig_ID= JidID,
                    Qty_Downgrade = 0,
                    Qty_NG1 = 0,
                    Qty_NG2 = 0,
                    Qty_NG3 = 0,
                    Qty_NG4 = 0,
                    Qty_NG5 = 0,
                    Qty_NG6 = 0,
                    Qty_NG7 = 0,
                    Qty_NG_Other = 0,
                    Qty_Pass = 0,
                    Qty_Reject = 0
                };
                foreach (var item in jigs)
                {
                    V_TESTING_STATUS noise = db.Database.SqlQuery<V_TESTING_STATUS>("select * from v_testing_status where testtype='Noise' and po_number ='" + PONumber + "' and jig_id='" + item + "'").FirstOrDefault();
                    V_TESTING_STATUS resistance = null;// db.Database.SqlQuery<V_TESTING_STATUS>("select * from v_testing_status where testtype='Resistance' and po_number ='" + PONumber + "' and jig_id='" + item + "'").FirstOrDefault();
                    V_TESTING_STATUS signal = null;//db.Database.SqlQuery<V_TESTING_STATUS>("select * from v_testing_status where testtype='Signal' and po_number ='" + PONumber + "' and jig_id='" + item + "'").FirstOrDefault();
                    T_SORTER_RESULT sr = new T_SORTER_RESULT
                    {
                        Created_Date = dt,
                        Created_User = "",
                        Jig_ID = item,
                        Machine_ID = "",
                        ID = 0,
                        PO_Number = PONumber
                    };
                    string noise_val = "";
                    string resistance_val = "";
                    string signal_val = "";
                    string field = "";
                    for (int i = 1; i <= 64; i++)
                    {
                        field = "Socket_" + i.ToString();
                        if (noise != null) { sr.Machine_ID = noise.Machine_ID; noise_val = (string)Commons.Commons.GetValueFromProperty(noise, field); }
                        if (resistance != null) { sr.Machine_ID = resistance.Machine_ID; resistance_val = (string)Commons.Commons.GetValueFromProperty(resistance, field); }
                        if (signal != null) { sr.Machine_ID = signal.Machine_ID; signal_val = (string)Commons.Commons.GetValueFromProperty(signal, field); }

                        //if (noise_val == "NOD" && resistance_val == "NOD" && signal_val == "NOD")
                        if (noise_val == "NOD")// && resistance_val == "NOD" && signal_val == "NOD")
                        {
                            Commons.Commons.SetValueOfProperty(sr, field, "NOD");
                            ss.Qty_NOD++;
                        }
                        else
                        //if (noise_val == "PASS" && resistance_val == "PASS" && signal_val == "PASS")
                        if (noise_val == "PASS")// && resistance_val == "PASS" && signal_val == "PASS")
                        {
                            Commons.Commons.SetValueOfProperty(sr, field, "PASS");
                            ss.Qty_Pass++;
                        }
                        else
                        if (noise_val != "PASS")
                        {
                            Commons.Commons.SetValueOfProperty(sr, field, noise_val);
                            SetErrorSummary(ss, noise_val);
                        }
                        //else
                        //if (resistance_val != "PASS")
                        //{
                        //    Commons.Commons.SetValueOfProperty(sr, field, resistance_val);
                        //    SetErrorSummary(ss, resistance_val);
                        //}
                        //else
                        //if (signal_val != "PASS")
                        //{
                        //    Commons.Commons.SetValueOfProperty(sr, field, signal_val);
                        //    SetErrorSummary(ss, signal_val);
                        //}
                    }
                     
                    db.T_SORTER_RESULTS.Add(sr);
                }
                db.T_SORTER_SUMMARIES.Add(ss);
                //db.SaveChanges();
                TrySaveChange(db);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new DBProjectEntities())
            {
                PrepareTestResult(txtPONumber.Text,txtJigID.Text);
                var data = db.V_REPORT_SORTER_SUMMARIES.Where(x => x.PO_Number == txtPONumber.Text).ToList(); 
                reportViewer1.LocalReport.DataSources.Clear();
                ReportDataSource datasource = new ReportDataSource("dtReport", data);
                reportViewer1.LocalReport.DataSources.Add(datasource);

                Stream rpt = loadEmbededReportDefinition("rptTestResult.rdlc");
                reportViewer1.LocalReport.LoadReportDefinition(rpt);
                reportViewer1.RefreshReport();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var db = new DBProjectEntities())
            {
                PrepareTestResult(txtPONumber.Text, txtJigID.Text);
                var data = db.V_REPORT_SORTER_SUMMARIES.Where(x => x.PO_Number == txtPONumber.Text).ToList();

                LocalReport report = null;
                // Create a LocalReport object directly
                report = new LocalReport();

                report.DataSources.Clear();
                ReportDataSource datasource = new ReportDataSource("dtReport", data);
                report.DataSources.Add(datasource);

                Stream rpt = loadEmbededReportDefinition("rptTestResult.rdlc");
                report.LoadReportDefinition(rpt);
                ReportPrintDocument printdoc = new ReportPrintDocument(report);
                printdoc.Print();
                //reportViewer1.RefreshReport();
            }

        }
    }
}
