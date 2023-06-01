using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TwinCAT.Ads; 
using Utilities;

namespace Desktop.BaseForms
{
   
    public partial class frmBaseTwinCAT : Desktop.BaseForms.frmBaseTransactions
    {
        private string FNetID;
        public TwinCat3Utility TwinCat3Utility { get; set; }          
        public string NetID { get { if (FNetID == "") FNetID = ConfigurationManager.AppSettings["TwinCatNetID"]; return FNetID; } set { FNetID = value; } }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (TwinCat3Utility != null)
            {
                TwinCat3Utility.Dispose();
                TwinCat3Utility = null;
            }
        } 
        public frmBaseTwinCAT()
        {
            InitializeComponent();
            TwinCat3Utility = new TwinCat3Utility();
            //AdsDataStream = new AdsStream(31); 
            //BinaryReader = new BinaryReader(AdsDataStream, System.Text.Encoding.ASCII);
        }

        
    }
}
