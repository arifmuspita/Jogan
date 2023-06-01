using DBProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Desktop.Forms.EntryData
{
    public partial class frmEntryData : Desktop.BaseForms.frmBaseDB
    {
        protected override void OnFormShown(object sender, EventArgs e)
        {
            M_USER u = DBEntities.M_USERS.Where(x => x.User_ID == UserProp.User_ID).FirstOrDefault();
            if (u == null)
            {
                MessageBox.Show("Your Username and/or Password not valid.\r\nPlease Try Again");
            }
            else
            {
                string urlbase =  ConfigurationManager.AppSettings["JoganWebUrl"];
                string url = urlbase +"/Home/LoginFromDesktopApp/" + UserProp.User_ID + "/" + u.Password;
                webBrowser.Url = new Uri(url);
            }
            base.OnFormShown(sender, e);
        }
        protected override void OnCloseButtonClick(object sender, EventArgs e)
        {
            Close();
        }
        public frmEntryData()
        {
            InitializeComponent();
        }

        private void webBrowser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            //progressBar1.Maximum = 100;
            //progressBar1.Minimum = 0;
            //if ((e.CurrentProgress > 0) && (e.CurrentProgress < 100))
            //{
            //    progressBar1.Value = (int)e.CurrentProgress;
            //}
        }

        private void webBrowser_ProgressChanged_1(object sender, WebBrowserProgressChangedEventArgs e)
        {

        }
    }
}
