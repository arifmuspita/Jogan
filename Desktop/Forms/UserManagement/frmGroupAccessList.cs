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
    public partial class frmGroupAccessList : Desktop.BaseForms.frmBaseList
    {
        protected override void OnFormShown(object sender, EventArgs e)
        {
            Commons.AppCollections.GridFormat[] gr = new Commons.AppCollections.GridFormat[4];
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

            gr[2].fieldName = "GroupName";
            gr[2].fieldNameFilter = "GroupName";
            gr[2].formatField = "";
            gr[2].indexForSearch = 1;
            gr[2].filterType = Commons.AppCollections.FilterType.ftString;
            gr[2].headerText = "Group Name";
            gr[2].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[2].colVisible = true;
            gr[2].colWidth =300;

            gr[3].fieldName = "IsSet";
            gr[3].fieldNameFilter = "IsSet";
            gr[3].formatField = "";
            gr[3].indexForSearch = -1;
            gr[3].filterType = Commons.AppCollections.FilterType.ftBoolean;
            gr[3].headerText = "Is Set";
            gr[3].textAlign = DataGridViewContentAlignment.MiddleCenter;
            gr[3].colVisible = true;
            gr[3].colWidth = 60;
            GridFormat = gr;
            base.OnFormShown(sender, e);
        }
        protected override void DoOpenData(DBProjectEntities model)
        {
            //IQueryable data = null;
            var data = model.V_USER_GROUP_PRIVILEGES_IS_SETS.Where(x => x.Group_ID != "ADMINISTRATOR").OrderBy(x => x.Group_ID).ToList();
            dbgView.DataSource = data;
        }
        public frmGroupAccessList()
        {
            InitializeComponent();
        }
    }
}
