using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms.UserManagement
{
    public partial class frmUserGroupList : Desktop.BaseForms.frmBaseList
    {
        protected override void OnFormShown(object sender, EventArgs e)
        { 
            Commons.AppCollections.GridFormat[] gr = new Commons.AppCollections.GridFormat[5];
            gr[0].fieldName = "ID";
            gr[0].formatField = "";
            gr[0].headerText = "ID";
            gr[0].fieldNameFilter = "ID";
            gr[0].indexForSearch = -1;
            gr[0].filterType = Commons.AppCollections.FilterType.ftString;
            gr[0].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[0].colVisible = false;
            gr[0].colWidth = 120;

            gr[1].fieldName = "Group_ID";
            gr[1].fieldNameFilter = "Group_ID";
            gr[1].formatField = "";
            gr[1].indexForSearch = 0;
            gr[1].filterType = Commons.AppCollections.FilterType.ftString;
            gr[1].headerText = "Group ID";
            gr[1].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[1].colVisible = true;
            gr[1].colWidth = 100;

            gr[2].fieldName = "Group_Name";
            gr[2].fieldNameFilter = "Group_Name";
            gr[2].formatField = "";
            gr[2].indexForSearch = 1;
            gr[2].filterType = Commons.AppCollections.FilterType.ftString;
            gr[2].headerText = "Group Name";
            gr[2].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[2].colVisible = true;
            gr[2].colWidth = 300;

            gr[3].fieldName = "Created_Date";
            gr[3].fieldNameFilter = "Created_Date";
            gr[3].formatField = "";
            gr[3].indexForSearch = 2;
            gr[3].filterType = Commons.AppCollections.FilterType.ftDate;
            gr[3].headerText = "Created Date";
            gr[3].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[3].colVisible = true;
            gr[3].colWidth = 100;

            gr[4].fieldName = "Created_User";
            gr[4].fieldNameFilter = "Created_User";
            gr[4].formatField = "";
            gr[4].indexForSearch = -1;
            gr[4].filterType = Commons.AppCollections.FilterType.ftEmpty;
            gr[4].headerText = "Created User";
            gr[4].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[4].colVisible = true;
            gr[4].colWidth = 150;
            GridFormat = gr;
            base.OnFormShown(sender, e); 
        }
        
        
        protected override void DoOpenData(DBProjectEntities model)
        {
            //IQueryable data = null;
            var data = model.M_USER_GROUPS.Where(x=>x.Group_ID!="ADMINISTRATOR").OrderBy(x => x.Group_ID).Select(x => new UserGroup2 {  Group_ID = x.Group_ID, Group_Name = x.Group_Name, Created_Date = x.Created_Date.Value, Created_User = x.Created_User }).ToList();
            dbgView.DataSource = data;
        }
        public override void RefreshData(bool JustRefresh = false)
        {
            string nmField = "";
            //string defFltr = "";
            Commons.AppCollections.FilterType ft = Commons.AppCollections.FilterType.ftEmpty;
            List<UserGroup2> data = new List<UserGroup2>();
            using (var db = new DBProjectEntities())
            {

                if (JustRefresh)
                {
                    data = db.M_USER_GROUPS.OrderBy(x => x.Group_ID).Select(x => new UserGroup2 {Group_ID = x.Group_ID, Group_Name = x.Group_Name, Created_Date = x.Created_Date.Value, Created_User = x.Created_User }).ToList();
                }
                else
                {
                    int idk = cmbFieldName.SelectedIndex;
                    foreach (Commons.AppCollections.GridFormat gr in GridFormat)
                    {
                        if (gr.indexForSearch == idk)
                        {
                            nmField = gr.fieldNameFilter;
                            ft = gr.filterType;
                            break;
                        }
                    }
                    if (ft == Commons.AppCollections.FilterType.ftDate)
                    {
                        DateTime dt1 = dtpDate1.Value;
                        DateTime dt2 = dtpDate2.Value;
                        if (!dtpDate2.Checked)
                        {
                            data = db.M_USER_GROUPS.OrderBy(x => x.Group_ID).Select(x => new UserGroup2 {  Group_ID = x.Group_ID, Group_Name = x.Group_Name, Created_Date = x.Created_Date.Value, Created_User = x.Created_User }).Where(x => x.Created_Date == dt1).ToList();
                        }
                        else { data = db.M_USER_GROUPS.OrderBy(x => x.Group_ID).Select(x => new UserGroup2 {  Group_ID = x.Group_ID, Group_Name = x.Group_Name, Created_Date = x.Created_Date.Value, Created_User = x.Created_User }).Where(x => x.Created_Date >= dt1 && x.Created_Date <= dt2).ToList(); }
                    }
                    if (ft == Commons.AppCollections.FilterType.ftString)
                    {
                        //data =
                        
                        switch (cmbOperand.SelectedIndex)
                        {
                            case 0:
                                data = (from x in (db.M_USER_GROUPS.OrderBy(x => x.Group_ID).Select(x => new UserGroup2 {Group_ID = x.Group_ID, Group_Name = x.Group_Name, Created_Date = x.Created_Date.Value, Created_User = x.Created_User }).ToList())
                                        where ((string)x.GetType().GetProperty(nmField).GetValue(x))==txtText.Text
                                        select x).ToList();
                                break;
                            case 2:
                                data = (from x in (db.M_USER_GROUPS.OrderBy(x => x.Group_ID).Select(x => new UserGroup2 {Group_ID = x.Group_ID, Group_Name = x.Group_Name, Created_Date = x.Created_Date.Value, Created_User = x.Created_User }).ToList())
                                        where ((string)x.GetType().GetProperty(nmField).GetValue(x)).EndsWith(txtText.Text)
                                        select x).ToList();
                                break;
                            case 1:
                                data = (from x in (db.M_USER_GROUPS.OrderBy(x => x.Group_ID).Select(x => new UserGroup2 {Group_ID = x.Group_ID, Group_Name = x.Group_Name, Created_Date = x.Created_Date.Value, Created_User = x.Created_User }).ToList())
                                        where ((string)x.GetType().GetProperty(nmField).GetValue(x)).StartsWith(txtText.Text)
                                        select x).ToList();
                                break;
                            case 3:
                                data = (from x in (db.M_USER_GROUPS.OrderBy(x => x.Group_ID).Select(x => new UserGroup2 {Group_ID = x.Group_ID, Group_Name = x.Group_Name, Created_Date = x.Created_Date.Value, Created_User = x.Created_User }).ToList())
                                        where ((string)x.GetType().GetProperty(nmField).GetValue(x)).Contains(txtText.Text)
                                        select x).ToList();
                                break; 
                        }

                    }
                } 
                dbgView.DataSource = data;
            }
        }
        public frmUserGroupList()
        {
            InitializeComponent();
        }

        private void frmUserGroupList_Load(object sender, EventArgs e)
        {

        }
    }
}
