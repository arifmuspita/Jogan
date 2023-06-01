using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.BaseForms
{
    public partial class frmBaseList : Desktop.BaseForms.frmBaseTransactions
    {
        private Commons.AppCollections.GridFormat[] FGridFormat;
        public frmBaseList()
        {
            InitializeComponent();
        }
        [Browsable(false)]
        public Commons.AppCollections.GridFormat[] GridFormat
        {
            get { return FGridFormat; }
            set
            {
                dbgView.Rows.Clear();
                dbgView.Columns.Clear();
                dbgView.DataSource = null;
                dbgView.AutoGenerateColumns = false;
                if (value.Length == 0) { MessageBox.Show("Please full fill grid format first..."); }
                else
                {
                    //int i = 0;
                    //dbgView.ColumnCount = value.Length;
                    //foreach (Commons.AppCollections.GridFormat gr in value)
                    //{
                    //    DataGridViewColumn c = dbgView.Columns[i];
                    //    c.HeaderCell.Style.Alignment = gr.textAlign;
                    //    c.DefaultCellStyle.Alignment = gr.textAlign;
                    //    c.DefaultCellStyle.Format = gr.formatField;
                    //    c.DataPropertyName = gr.fieldName;
                    //    c.HeaderText = gr.headerText;
                    //    c.Width = gr.colWidth;
                    //    c.Visible = gr.colVisible;
                    //    i++;
                    //}
                    foreach (Commons.AppCollections.GridFormat gr in value)
                    {
                        DataGridViewColumn c = new DataGridViewColumn();
                        c.CellTemplate = new DataGridViewTextBoxCell();
                        if (gr.filterType == Commons.AppCollections.FilterType.ftBoolean)
                        {
                            c = new DataGridViewCheckBoxColumn();
                            c.CellTemplate = new DataGridViewCheckBoxCell();
                        }
                        //if (gr.filterType != Commons.AppCollections.FilterType.ftBoolean)
                        //{
                        //    DataGridViewColumn c = new DataGridViewColumn();// dbgView.Columns[i];

                        //} else
                        //{
                        //    DataGridViewCheckBoxColumn c = new DataGridViewCheckBoxColumn();// dbgView.Columns[i];
                        //    c.HeaderCell.Style.Alignment = gr.textAlign;
                        //    c.DefaultCellStyle.Alignment = gr.textAlign;
                        //    c.DefaultCellStyle.Format = gr.formatField;
                        //    c.DataPropertyName = gr.fieldName;
                        //    c.HeaderText = gr.headerText;
                        //    c.Width = gr.colWidth;
                        //    c.Visible = gr.colVisible;
                        //    dbgView.Columns.Add(c);
                        //}
                        
                        c.HeaderCell.Style.Alignment = gr.textAlign;
                        c.DefaultCellStyle.Alignment = gr.textAlign;
                        c.DefaultCellStyle.Format = gr.formatField;
                        c.DataPropertyName = gr.fieldName;
                        c.HeaderText = gr.headerText;
                        c.Width = gr.colWidth;
                        c.Visible = gr.colVisible;
                        
                        //dbgView.CellTemplate = dataGridViewCell;
                        dbgView.Columns.Add(c);
                    }
                }
                FGridFormat = value;
            }
        }

        
        private Commons.AppCollections.FilterType GetFieldComboProperty()
        {
            Commons.AppCollections.FilterType ft;
            ft = Commons.AppCollections.FilterType.ftEmpty;
            int idk = cmbFieldName.SelectedIndex;
            if (cmbFieldName.Items.Count == 0) { MessageBox.Show("Filter tidak boleh kosong"); }
            else
            {
                foreach (Commons.AppCollections.GridFormat gr in GridFormat)
                {
                    if (gr.indexForSearch == idk) { ft = gr.filterType; break; }
                }
            }
            return ft;
        }
        private void createFilterFieldsName()
        {
            cmbFieldName.Items.Clear();
            try
            {
                foreach (Commons.AppCollections.GridFormat gr in GridFormat)
                {
                    if (gr.indexForSearch != -1) { cmbFieldName.Items.Add(gr.headerText); }
                }
                if (cmbFieldName.Items.Count > 0)
                {
                    cmbFieldName.SelectedIndex = 0;
                    cmbFieldNameSelectedIndexChanged(null, null);
                }
            }
            catch
            {
                if (cmbFieldName.Items.Count > 0)
                {
                    cmbFieldName.SelectedIndex = 0;
                    cmbFieldNameSelectedIndexChanged(null, null);
                }
            }
        }
        protected virtual void cmbFieldNameSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ExitProc)
            {
                Commons.AppCollections.FilterType ft = GetFieldComboProperty();
                pnlDate.Visible = (ft != Commons.AppCollections.FilterType.ftEmpty) && (ft == Commons.AppCollections.FilterType.ftDate);
                pnlString.Visible = (ft != Commons.AppCollections.FilterType.ftEmpty) && (ft != Commons.AppCollections.FilterType.ftDate);
                cmbOperand.Enabled = (ft != Commons.AppCollections.FilterType.ftEmpty) && (ft == Commons.AppCollections.FilterType.ftString);
                if (cmbOperand.Enabled) { cmbOperand.SelectedIndex = 3; }
                else { cmbOperand.SelectedIndex = 0; }
            }
        }
        protected override void OnFormShown(object sender, EventArgs e)        
        {
            base.OnFormShown(sender, e);
            pnlDate.BringToFront();
            pnlDate.Dock = DockStyle.Fill;
            pnlString.BringToFront();
            pnlString.Dock = DockStyle.Fill;

            dtpDate1.Value = DateTime.Today;
            dtpDate2.Value = DateTime.Today;
            createFilterFieldsName();
        }

        protected override void OnCloseButtonClick(object sender, EventArgs e)
        {
            ShowForm("frmAccesses");
            base.OnCloseButtonClick(sender, e);

        }

       

        private void cmbFieldName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbFieldNameSelectedIndexChanged(sender, e);
        }
        private void txtText_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtTexKeyPress(sender, e);
        } 
        protected virtual void txtTexKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) { RefreshData(); }
        }
        protected virtual void dtpDate1KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) { RefreshData(); }
        }

        private void dtpDate1_KeyPress(object sender, KeyPressEventArgs e)
        {
            dtpDate1KeyPress(sender, e);
        } 

        public virtual void RefreshData(bool JustRefresh = false) 
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            RefreshData(true);
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        protected virtual void GridCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           // btnEdit_Click(btnEdit, null);
        }
        private void dbgView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GridCellDoubleClick(sender, e);
        }
        private void dbgView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //
        }

        protected virtual string GetEntryFormName()
        {
            return "frm" + ModuleName + "Entry";
        }

        protected virtual void btnEditClick(object sender, EventArgs e)
        {
            string str;
            DataGridViewCell cell = dbgView.CurrentCell;
            Button btn = (Button)sender;
            int id = 0;
            string ids = "";
            if (btn.Tag == "Edit")
            {
                ids = dbgView.Rows[cell.RowIndex].Cells[0].Value.ToString();
                id = Convert.ToInt32(ids);
            }
            Form form = OpenForm(GetEntryFormName());
            BaseForms.frmBaseEntry frmBaseEntry1 = (form as BaseForms.frmBaseEntry);
            frmBaseEntry1.SetUserData(UserProp);
            frmBaseEntry1.ID = id;
            frmBaseEntry1.FormList = this;
            frmBaseEntry1.ShowDialog();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEditClick(sender, e);
        }

       
    }
}
