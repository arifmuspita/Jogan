using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Controls
{
    public partial class NGConfiguration : UserControl
    {
        private Dictionary<string, string> FItemsValue;
        public Dictionary<string, string> ItemsValue
        {
            get
            {
                if (FItemsValue != null)
                {
                    FItemsValue.Clear();
                    foreach (NGConfiguraionItem kvp in FItems)
                    {
                        FItemsValue.Add(kvp.ID, kvp.Value);
                    }
                }
                return FItemsValue;
            }
            set
            {
                FItemsValue = value;
                if (value != null)
                {
                    foreach (KeyValuePair<string, string> kvp in FItemsValue)
                    {
                        NGConfiguraionItem ci = FItems.Where(x => x.ID == kvp.Key).FirstOrDefault();
                        if (ci != null) { ci.TellOwner = true; ci.Value = kvp.Value; ci.TellOwner = false; }
                    }
                }
            }
        }
        private List<NGConfiguraionItem> FItems;
        public List<NGConfiguraionItem> Items
        {
            get
            {
                return FItems;
            }
        }
        private void ClearValues()
        { 
            foreach (NGConfiguraionItem kvp in FItems)
            {
                kvp.TellOwner = false;
                kvp.Value = "";
            }
            FItemsValue.Clear();
        }
        private void ClearItems()
        {
            foreach (NGConfiguraionItem kvp in FItems)
            {
                pnlMain.Controls.Remove(kvp);
                kvp.Dispose();
            }
            FItems.Clear();
        }
        private void CreateNGConfigurationItems()
        {
            ClearItems();
            int h = 0;
            for (int i = 7; i >= 1; i--)
            {
                NGConfiguraionItem ci = new NGConfiguraionItem();
                Width = ci.Width;
                ci.Dock = DockStyle.Top;
                ci.Index = i;
                ci.Owner = this;
                ci.Parent = pnlMain;
                h = h + ci.Height;
                FItems.Add(ci);
            }
            Height = h;
        }
        protected override void Dispose(bool disposing)
        {
            ClearItems();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            
            base.Dispose(disposing);
        }
        public void RemoveDuplicate(NGConfiguraionItem Ref, string Value)
        {
            foreach ( NGConfiguraionItem kvp in FItems)
            {
                if (kvp != Ref)
                {
                    if (kvp.Value == Value) { kvp.TellOwner = false; kvp.Value = ""; }
                }
            }
        }
        public NGConfiguration()
        {
            FItems = new List<NGConfiguraionItem>();
            FItemsValue = new Dictionary<string, string> ();
            InitializeComponent();
            CreateNGConfigurationItems();
        }
    }
}
