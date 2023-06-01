using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms.UserManagement
{
    public partial class frmGroupAccessEntry : Desktop.BaseForms.frmBaseEntry
    {
        protected override void OnFormShown(object sender, EventArgs e)
        {
            dbgGroupAccess.AutoGenerateColumns = false;
            base.OnFormShown(sender, e);

        }
        protected override void DoOpenData(DBProjectEntities model)
        {
            

            //return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_GroupAccess_Result>("SP_GroupAccess", groupIDParameter);
            ////var data = DBEntities.Database.SqlQuery<SP_GroupAccess>("exec SP_GroupAccess ", ID).ToList<SP_GroupAccess>(); 
            var data = DBEntities.Database.SqlQuery<SP_GROUP_PRIVILEGES>("SP_GROUP_PRIVILEGES @GroupID", new SqlParameter("GroupID", ID)).ToList();
            dbgGroupAccess.DataSource = data;
        }
        public frmGroupAccessEntry()
        {
            InitializeComponent();
        }

        private void chkAllMenu_CheckedChanged(object sender, EventArgs e)
        {
            int cols = dbgGroupAccess.ColumnCount;
            int rows = dbgGroupAccess.RowCount;
            CheckBox chk = (CheckBox)sender;
            bool allmenu =  chkAllMenu.Checked;

            if (chk == chkAllMenu)
            {
                chkAllRead.Enabled = !allmenu;
                chkAllAdd.Enabled = !allmenu;
                chkAllEdit.Enabled = !allmenu;
                chkAllDelete.Enabled = !allmenu;
                chkAllReport.Enabled = !allmenu;

                chkAllRead.Checked = allmenu;
                chkAllAdd.Checked = allmenu;
                chkAllEdit.Checked = allmenu;
                chkAllDelete.Checked = allmenu;
                chkAllReport.Checked = allmenu;
            }

            bool allread = chkAllRead.Checked;
            bool alladd =  chkAllAdd.Checked;
            bool alledit =  chkAllEdit.Checked;
            bool alldelete = chkAllDelete.Checked;
            bool allreport = chkAllReport.Checked;
            dbgGroupAccess.EditMode = DataGridViewEditMode.EditProgrammatically;
            dbgGroupAccess.BeginEdit(true);
            for (int i = 1; i <= cols - 1; i++) //start from col 1
            {
                for (int j = 0; j <= rows - 1; j++)
                {
                    switch (i)
                    {
                        case 1:
                            dbgGroupAccess.Rows[j].Cells[i].Value = allmenu || allread;
                            break;
                        case 2:
                            dbgGroupAccess.Rows[j].Cells[i].Value = allmenu || alladd;
                            break;
                        case 3:
                            dbgGroupAccess.Rows[j].Cells[i].Value = allmenu || alledit;
                            break;
                        case 4:
                            dbgGroupAccess.Rows[j].Cells[i].Value = allmenu || alldelete;
                            break;
                        case 5:
                            dbgGroupAccess.Rows[j].Cells[i].Value = allmenu || allreport;
                            break;
                    }

                }
            }
            dbgGroupAccess.EndEdit();
        }

        private void dbgGroupAccess_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cols = dbgGroupAccess.ColumnCount;
            int rows = dbgGroupAccess.RowCount;
            int col = e.ColumnIndex;
            int row = e.RowIndex;
            string code = "";
            bool val = false;
            int cch = 0;
            if (col >= 1)
            {
                code = dbgGroupAccess.Rows[row].Cells[9].Value.ToString();
                val = dbgGroupAccess.Rows[row].Cells[col].Value==null?false:(bool)dbgGroupAccess.Rows[row].Cells[col].Value;
                val = !val;
                bool det = (bool)dbgGroupAccess.Rows[row].Cells[6].Value;
                if (det)
                {

                } else
                {
                    int colnotdet = e.ColumnIndex;
                    int rownotdet = e.RowIndex;
                    for (int i = rownotdet; i <= rows - 1; i++)
                    {
                        string val2 = dbgGroupAccess.Rows[i].Cells[9].Value.ToString();
                        if (val2.Substring(0, code.Length) == code)
                        {
                            cch++;
                            dbgGroupAccess.Rows[i].Cells[col].Value = val;
                        }
                    }
                }
            }
        }
    }
}
