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
    public partial class frmUserList : Desktop.BaseForms.frmBaseList
    {
        protected override void OnFormShown(object sender, EventArgs e)
        {
            Commons.AppCollections.GridFormat[] gr = new Commons.AppCollections.GridFormat[7];
            gr[0].fieldName = "ID";
            gr[0].formatField = "";
            gr[0].headerText = "ID";
            gr[0].fieldNameFilter = "ID";
            gr[0].indexForSearch = -1;
            gr[0].filterType = Commons.AppCollections.FilterType.ftString;
            gr[0].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[0].colVisible = false;
            gr[0].colWidth = 120;

            gr[1].fieldName = "GroupID";
            gr[1].fieldNameFilter = "GroupID";
            gr[1].formatField = "";
            gr[1].indexForSearch = 0;
            gr[1].filterType = Commons.AppCollections.FilterType.ftString;
            gr[1].headerText = "Group ID";
            gr[1].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[1].colVisible = true;
            gr[1].colWidth = 100;

            gr[2].fieldName = "UserName";
            gr[2].fieldNameFilter = "UserName";
            gr[2].formatField = "";
            gr[2].indexForSearch = 1;
            gr[2].filterType = Commons.AppCollections.FilterType.ftString;
            gr[2].headerText = "User Name";
            gr[2].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[2].colVisible = true;
            gr[2].colWidth = 200;

            gr[3].fieldName = "BagdeNo";
            gr[3].fieldNameFilter = "BagdeNo";
            gr[3].formatField = "";
            gr[3].indexForSearch = 1;
            gr[3].filterType = Commons.AppCollections.FilterType.ftString;
            gr[3].headerText = "Bagde No";
            gr[3].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[3].colVisible = true;
            gr[3].colWidth = 100;

            gr[4].fieldName = "IsActive";
            gr[4].fieldNameFilter = "IsActive";
            gr[4].formatField = "";
            gr[4].indexForSearch = -1;
            gr[4].filterType = Commons.AppCollections.FilterType.ftBoolean;
            gr[4].headerText = "Is Active";
            gr[4].textAlign = DataGridViewContentAlignment.MiddleCenter;
            gr[4].colVisible = true;
            gr[4].colWidth = 60;

            gr[5].fieldName = "CreatedDate";
            gr[5].fieldNameFilter = "CreatedDate";
            gr[5].formatField = "";
            gr[5].indexForSearch = 2;
            gr[5].filterType = Commons.AppCollections.FilterType.ftDate;
            gr[5].headerText = "Created Date";
            gr[5].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[5].colVisible = true;
            gr[5].colWidth = 100;

            gr[6].fieldName = "CreatedUser";
            gr[6].fieldNameFilter = "CreatedUser";
            gr[6].formatField = "";
            gr[6].indexForSearch = -1;
            gr[6].filterType = Commons.AppCollections.FilterType.ftString;
            gr[6].headerText = "Created User";
            gr[6].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[6].colVisible = true;
            gr[6].colWidth = 150;
            GridFormat = gr;
            base.OnFormShown(sender, e);
        }
        protected override void DoOpenData(DBProjectEntities model)
        {
            //IQueryable data = null;
            var data = model.V_USER_GROUPS.OrderBy(x => x.Group_ID).ThenBy(x=>x.Name).ToList();
            dbgView.DataSource = data;
        }
        public override void RefreshData(bool JustRefresh = false)
        {
            string nmField = "";
            //string defFltr = "";
            Commons.AppCollections.FilterType ft = Commons.AppCollections.FilterType.ftEmpty;
            List<V_USER_GROUP> data = new List<V_USER_GROUP>();
            using (var db = new DBProjectEntities())
            {

                if (JustRefresh)
                {
                    data = db.V_USER_GROUPS.OrderBy(x => x.Group_ID).ThenBy(x=>x.Name).ToList();
                }
                else
                {
                    //int idk = cmbFieldName.SelectedIndex;
                    //foreach (Commons.AppCollections.GridFormat gr in GridFormat)
                    //{
                    //    if (gr.indexForSearch == idk)
                    //    {
                    //        nmField = gr.fieldNameFilter;
                    //        ft = gr.filterType;
                    //        break;
                    //    }
                    //}
                    //if (ft == Commons.AppCollections.FilterType.ftDate)
                    //{
                    //    DateTime dt1 = dtpDate1.Value;
                    //    DateTime dt2 = dtpDate2.Value;
                    //    if (!dtpDate2.Checked)
                    //    {
                    //        data = db.UserGroups.OrderBy(x => x.GroupID).Select(x => new UserGroup2 { ID = x.ID, GroupID = x.GroupID, GroupName = x.GroupName, CreatedDate = x.CreatedDate, CreatedUser = x.CreatedUser }).Where(x => x.CreatedDate == dt1).ToList();
                    //    }
                    //    else { data = db.UserGroups.OrderBy(x => x.GroupID).Select(x => new UserGroup2 { ID = x.ID, GroupID = x.GroupID, GroupName = x.GroupName, CreatedDate = x.CreatedDate, CreatedUser = x.CreatedUser }).Where(x => x.CreatedDate >= dt1 && x.CreatedDate <= dt2).ToList(); }
                    //}
                    //if (ft == Commons.AppCollections.FilterType.ftString)
                    //{
                    //    //data =

                    //    switch (cmbOperand.SelectedIndex)
                    //    {
                    //        case 0:
                    //            data = (from x in (db.UserGroups.OrderBy(x => x.GroupID).Select(x => new UserGroup2 { ID = x.ID, GroupID = x.GroupID, GroupName = x.GroupName, CreatedDate = x.CreatedDate, CreatedUser = x.CreatedUser }).ToList())
                    //                    where ((string)x.GetType().GetProperty(nmField).GetValue(x)) == txtText.Text
                    //                    select x).ToList();
                    //            break;
                    //        case 2:
                    //            data = (from x in (db.UserGroups.OrderBy(x => x.GroupID).Select(x => new UserGroup2 { ID = x.ID, GroupID = x.GroupID, GroupName = x.GroupName, CreatedDate = x.CreatedDate, CreatedUser = x.CreatedUser }).ToList())
                    //                    where ((string)x.GetType().GetProperty(nmField).GetValue(x)).EndsWith(txtText.Text)
                    //                    select x).ToList();
                    //            break;
                    //        case 1:
                    //            data = (from x in (db.UserGroups.OrderBy(x => x.GroupID).Select(x => new UserGroup2 { ID = x.ID, GroupID = x.GroupID, GroupName = x.GroupName, CreatedDate = x.CreatedDate, CreatedUser = x.CreatedUser }).ToList())
                    //                    where ((string)x.GetType().GetProperty(nmField).GetValue(x)).StartsWith(txtText.Text)
                    //                    select x).ToList();
                    //            break;
                    //        case 3:
                    //            data = (from x in (db.UserGroups.OrderBy(x => x.GroupID).Select(x => new UserGroup2 { ID = x.ID, GroupID = x.GroupID, GroupName = x.GroupName, CreatedDate = x.CreatedDate, CreatedUser = x.CreatedUser }).ToList())
                    //                    where ((string)x.GetType().GetProperty(nmField).GetValue(x)).Contains(txtText.Text)
                    //                    select x).ToList();
                    //            break;
                    //    }
                    //}
                }
                dbgView.DataSource = data;
            }
        }
        public frmUserList()
        {
            InitializeComponent();
        }
    }
}
