using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms
{
    public partial class frmSearchDevice : Desktop.BaseForms.frmBaseList
    {
        private TextBox DeviceID { get; set; }
        private TextBox DeviceName { get; set; }

        public string DefaultDeviceID { get; set; }
        protected override void OnFormShown(object sender, EventArgs e)
        {
            Commons.AppCollections.GridFormat[] gr = new Commons.AppCollections.GridFormat[2];


            gr[0].fieldName = "Device_ID";
            gr[0].fieldNameFilter = "Device_ID";
            gr[0].formatField = "";
            gr[0].indexForSearch = 0;
            gr[0].filterType = Commons.AppCollections.FilterType.ftString;
            gr[0].headerText = "Device ID";
            gr[0].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[0].colVisible = true;
            gr[0].colWidth = 100;

            gr[1].fieldName = "Device_Name";
            gr[1].fieldNameFilter = "Device_Name";
            gr[1].formatField = "";
            gr[1].indexForSearch = 1;
            gr[1].filterType = Commons.AppCollections.FilterType.ftString;
            gr[1].headerText = "Device Name";
            gr[1].textAlign = DataGridViewContentAlignment.MiddleLeft;
            gr[1].colVisible = true;
            gr[1].colWidth = 300;
            GridFormat = gr; 
            base.OnFormShown(sender, e); 


        }
        protected override void GridCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dbgView.CurrentCell;
            if (cell != null)
            {
                DeviceID.Text = dbgView.Rows[cell.RowIndex].Cells[0].Value.ToString();
                DeviceName.Text = dbgView.Rows[cell.RowIndex].Cells[1].Value.ToString();
                DialogResult = DialogResult.OK;
            }
            else DialogResult = DialogResult.Cancel;
            Close();
        } 

        protected override void DoOpenData(DBProjectEntities model)
        {
            //IQueryable data = null;
            var data = model.M_DEVICES.Where(x=>x.Device_ID!= DefaultDeviceID).OrderBy(x => x.Device_ID).ToList();
            dbgView.DataSource = data;
        }

        public override void RefreshData(bool JustRefresh = false)
        {
            string nmField = "";
            //string defFltr = "";
            Commons.AppCollections.FilterType ft = Commons.AppCollections.FilterType.ftEmpty;
            List<M_DEVICE> data = new List<M_DEVICE>();
            using (var db = new DBProjectEntities())
            {

                if (JustRefresh)
                {
                    data = db.M_DEVICES.Where(x => x.Device_ID != DefaultDeviceID).OrderBy(x => x.Device_ID).ToList();
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
                    if (ft == Commons.AppCollections.FilterType.ftString)
                    {
                        //data =

                        switch (cmbOperand.SelectedIndex)
                        {
                            case 0:
                                data = (from x in (db.M_DEVICES.Where(x => x.Device_ID != DefaultDeviceID).OrderBy(x => x.Device_ID).ToList())
                                        where ((string)x.GetType().GetProperty(nmField).GetValue(x)) == txtText.Text
                                        select x).ToList();
                                break;
                            case 2:
                                data = (from x in (db.M_DEVICES.Where(x => x.Device_ID != DefaultDeviceID).OrderBy(x => x.Device_ID).ToList())
                                        where ((string)x.GetType().GetProperty(nmField).GetValue(x)).EndsWith(txtText.Text)
                                        select x).ToList();
                                break;
                            case 1:
                                data = (from x in (db.M_DEVICES.Where(x => x.Device_ID != DefaultDeviceID).OrderBy(x => x.Device_ID).ToList())
                                        where ((string)x.GetType().GetProperty(nmField).GetValue(x)).StartsWith(txtText.Text)
                                        select x).ToList();
                                break;
                            case 3:
                                data = (from x in (db.M_DEVICES.Where(x => x.Device_ID != DefaultDeviceID).OrderBy(x => x.Device_ID).ToList())
                                        where ((string)x.GetType().GetProperty(nmField).GetValue(x)).Contains(txtText.Text)
                                        select x).ToList();
                                break;
                        }

                    }
                }
                dbgView.DataSource = data;
            }
        }
        public frmSearchDevice()
        {
            InitializeComponent();
        }

        public frmSearchDevice(TextBox TextDeviceID,TextBox TextDeviceName,string ADefaultDeviceID)
        {
            DeviceID = TextDeviceID;
            DeviceName = TextDeviceName;
            DefaultDeviceID = ADefaultDeviceID;
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            GridCellDoubleClick(sender, null);
        }
    }
}
