using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms.Configuration
{
    public partial class frmNGConfiguration : Desktop.BaseForms.frmBaseTransactions
    {
        protected override void CreateToolStripButton(bool CreateDefaultButton = true)
        {
            base.CreateToolStripButton(false);
        }
        private void GetNGConfigurationDatas()
        {
            using (var db = new DBProjectEntities())
            {
                DateTime maxdate = db.Database.SqlQuery<DateTime>("select max(created_date) from M_NG_CONFIG").FirstOrDefault();
                List<M_NG_CONFIG> datas = db.M_NG_CONFIGS.Where(x => x.Created_Date == maxdate).ToList();
                Dictionary<string, string> values = new Dictionary<string, string>();
                foreach(var item in datas)
                {
                    values.Add(item.Box_ID, item.NG_Code);
                }
                ngConfiguration1.ItemsValue = values;
            }
        }
        protected override void Transaction(DBProjectEntities model = null)
        {
            DateTime dt = DateTime.Now;
            foreach (KeyValuePair<string, string> kvp in ngConfiguration1.ItemsValue)
            {
                M_NG_CONFIG ng = new M_NG_CONFIG
                {
                    Box_ID = kvp.Key,
                    Created_Date = dt,
                    Created_User = UserProp.User_ID,
                    Date_String = dt.ToString(),
                    ID=0,
                    NG_Code=kvp.Value,
                };
                model.M_NG_CONFIGS.Add(ng);
            }
            model.SaveChanges();
        }
        public frmNGConfiguration()
        {
            InitializeComponent();
            GetNGConfigurationDatas();
        }
    }
}
