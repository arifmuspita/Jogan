using Desktop.Controls.Testing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Desktop.BaseControls
{
    public partial class BaseInfoTestingItemControl : Desktop.BaseControls.BaseTestingItemControl
    {
        private InfoTestingControl FOwner;
        public InfoTestingControl Owner { get; set; }
        private string FCaption;
        public string Caption
        {
            get { return FCaption; }
            set { SetCaption(value); }
        }

        protected virtual void SetCaption(string value)
        {
            FCaption = value;
            gbMainItem.Text = " " + value + " ";
        }
        protected override void SetIndex(int value)
        {
            base.SetIndex(value);
            gbMainItem.Text = " " + FCaption + " ";
        }

        public BaseInfoTestingItemControl()
        {
            InitializeComponent();
        }
    }
}
