using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Trial.Controls.AreaLoader
{
    public partial class JigStorage : UserControl
    {
        private List<JigOnStorage> FListJigOnStorage;
        private int FJigCount;
        public int JigCount { get { return FJigCount; }set { SetJigCount(value); } }

        private void SetJigCount(int value)
        {
            FJigCount = value;
            ClearJigs();
            if (FJigCount != 0)
            {
                for (int i = FJigCount; i >=1; i--)
                {
                    JigOnStorage jig = new JigOnStorage { Index = i,IsAvailable = true };
                    jig.Dock = DockStyle.Top;
                    jig.Parent = pnlJigs;
                    FListJigOnStorage.Add(jig);
                }
            }
        }
        private void ClearJigs()
        {
            for (int i = FListJigOnStorage.Count - 1; i >= 0; i--)
            {
                JigOnStorage jig = FListJigOnStorage[i];
                pnlJigs.Controls.Remove(jig);
                FListJigOnStorage.RemoveAt(i);
            }
        }
        public int JigAvailableCount { get { return GetJigAvailableCount(); } }

        private int GetJigAvailableCount()
        {
            return (FListJigOnStorage.Where(x => x.IsAvailable).Count() );
        }

        public bool IsStorageEmpty()
        {
            //return (JigCount != 0 && JigAvailableCount > 0);
            return (JigCount == 0 || JigAvailableCount == 0);
        }
        public bool IsStorageFull()
        {
            return (JigAvailableCount == JigCount);
        }
        public void GetJig()
        {
            JigOnStorage jig = null; 
            if (!IsStorageEmpty())
            {
                jig = FListJigOnStorage.Where(x => x.IsAvailable).OrderBy(x => x.Index).FirstOrDefault();
                jig.IsAvailable = false;
            } 
        }
        public void SetJig( )
        {
            JigOnStorage jig = null;
            if (!IsStorageFull())
            {
                jig = FListJigOnStorage.Where(x => !x.IsAvailable).OrderBy(x => x.Index).FirstOrDefault();
                jig.IsAvailable = true;
            } 
        }
        public JigStorage()
        {
            InitializeComponent();
            FListJigOnStorage = new List<JigOnStorage>();
            JigCount = 0;
        }
    }
}
