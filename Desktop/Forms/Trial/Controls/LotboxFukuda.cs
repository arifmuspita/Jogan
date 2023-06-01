using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Trial.Controls
{
    public enum LotBoxState { Netral,Ready,Unload,FinishUnload};
    public partial class LotboxFukuda : UserControl
    {
        private Color[] LotBoxColor = new Color[4] { SystemColors.Control, Color.FromArgb(192, 255, 192), Color.FromArgb(128, 128, 255), Color.FromArgb(255, 128, 128) };
        private List<bool> FJigAvalailabe;
        public List<bool>  JigAvalailabe { get { return FJigAvalailabe; } set { SetJigAvalailabe(value); } }

        private void SetJigAvalailabe(List<bool> value)
        {
            if (value == null) return;
            FJigAvalailabe = value;
            if (!DesignMode)
            {
                for (int i = 0; i < 10; i++)
                {
                    if (i+1 > FJigAvalailabe.Count) break;
                    Control ctn = gbLotBox.Controls["chkJigFukuda" + (i + 1).ToString()];
                    if (ctn != null)
                    {
                        (ctn as CheckBox).Enabled = value[i];
                    }
                }
            }
        }

        private LotBoxState FLotBoxState;
        public LotBoxState LotBoxState { get { return FLotBoxState; } set { SetLotBoxState(value); } }

        private void SetLotBoxState(LotBoxState value)
        {
            //MessageBox.Show(((int)value).ToString());
            FLotBoxState = value;
            BackColor = LotBoxColor[(int)value];
        }

        private int FStation;
        public int Station { get { return FStation; } set { SetStation(value); } }

        private void SetStation(int value)
        {
            if (value < 1) value = 1;
            if (value > 4) value = 4;
            FStation = value;
            gbLotBox.Text = " Station " + value.ToString() + " ";
        }

        public LotboxFukuda()
        {
            InitializeComponent();
            LotBoxState = LotBoxState.Netral;
            Station = 1;
        }
    }
}
