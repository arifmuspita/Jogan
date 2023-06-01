using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Desktop.DesktopProperties;
using Commons;

namespace Desktop.BaseControls
{
    
    public partial class BaseTestingItemControl : UserControl
    {
        public Color[] ArrayColor = new Color[]{ Color.FromArgb(0, 0, 0), Color.FromArgb(255, 0, 0), Color.FromArgb(255, 128, 0), Color.FromArgb(0, 0, 255), Color.FromArgb(255, 0, 255) };
        private int FIndex;
        public int Index { get { return FIndex; }set { SetIndex(value); } }
        public event EventStatusChanged StatusChanged;
        public event EventButtonFinishClick ButtonFinishClick;
        public event EventValueChanged ValueChanged;
        protected virtual void SetIndex(int value)
        {
            FIndex = value;
            gbMainItem.Text = " Station " + value.ToString() + " ";
            //BasicColor = ArrayColor[2];
            //if (!DesignMode)
            //{
            //    if (value > (ArrayColor.Count()) || value < 0)
            //    {
            //        BasicColor = ArrayColor[0];
            //    }
            //    else
            //    {
            //        BasicColor = ArrayColor[value];
            //    }
            //}
        }
        
        //private List<Control> FListLabel;
        private List<ControlProperty> FControlProperty;
        private string FCode;
        public string Code { get { return FCode; } set { FCode = value; } }

        private BaseTestingControl FOwner;
        public BaseTestingControl Owner { get { return FOwner; } set { FOwner = value; } }

        public StatusTestingControl GetStatusFromString(string AStatus)
        {
            StatusTestingControl ret = StatusTestingControl.None;
            foreach (StatusTestingControl val in Enum.GetValues(typeof(StatusTestingControl)))
            {
                if (val.ToString().ToUpper() == AStatus.ToUpper())
                {
                    ret = val;
                    break;
                }
            }
            return ret;
        }
        private Color FBasicColor;
        public Color BasicColor
        {
            get { return FBasicColor; }
            set { SetBasicColor(value); }
        }

        protected virtual void SetBasicColor(Color value)
        {
            FBasicColor = value;
        }
        private bool FShowButtonFinish;
        public bool ShowButtonFinish { get { return FShowButtonFinish; } set { FShowButtonFinish = value; } }
        private object FValue;
        [Browsable(false)]
        public object Value
        {
            get { return GetValue(); }
            set { SetValue2(value); }
        }

        protected virtual object GetValue()
        {
            return FValue;
        }
        private void SetValue2(object value)
        {
            if (FValue != value)
            {
                SetValue(value);
                if (ValueChanged != null) { ValueChanged(this, value); }
            }

        }
        protected virtual void SetValue(object value)
        { 
                FValue = value; 
        }

        private StatusTestingControl FStatus;
        public StatusTestingControl Status
        {
            get { return FStatus; }
            set { SetStatus(value); }
        }

        private bool FStartBlinking;
        private bool FIsBlinking;
        public bool StartBlinking
        {
            get { return FStartBlinking; }
            set { SetStartBlinking(value); }
        }

        private void SetBlinking(bool value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<bool>(SetBlinking), new object[] { value });
                return;
            }
            FControlProperty.Clear();
            GetAllLabelsPrivate(gbMainItem, FControlProperty);
            tmrBlinking.Enabled = value;
            if (value) tsMain.Visible = FShowButtonFinish;
        }

        private void SetStartBlinking(bool value)
        {
            FStartBlinking = value;
            FIsBlinking = value;
            SetBlinking(value);
            //FControlProperty.Clear();
            //GetAllLabelsPrivate(gbMainItem, FControlProperty);
            //tmrBlinking.Enabled = value;
        }

        private void GetAllLabelsPrivate(Control AParent, List<ControlProperty> AControlProperty)
        {
            GetAllLabels(AParent,FControlProperty);
        }

        private void SetBlinkingColor(bool IsBlinking)
        {  
            foreach (var item in FControlProperty)
            {
                item.TextControl.ForeColor = IsBlinking ? Color.White : item.ForeColor;
               // item.Label.ForeColor = IsBlinking ? Color.White : item.ForeColor;
            }
            gbMainItem.ForeColor = IsBlinking ? Color.White : Color.Black;
            gbMainItem.BackColor = IsBlinking ? Color.Red : SystemColors.Control;
        }

        private void SetLabelBlinkingColor(bool IsBlinking)
        {
            foreach (var item in FControlProperty)
            {
                item.TextControl.ForeColor = IsBlinking ? Color.White : item.ForeColor;
                //item.Label.ForeColor = IsBlinking ? Color.White : item.ForeColor;
            }
        }

        protected virtual void GetAllLabels(Control AParent,List<ControlProperty> AListLabels)
        {
            AListLabels.Add(new ControlProperty { TextControl = AParent, ForeColor = AParent.ForeColor });
            List<Control> c = AParent.Controls.OfType<Label>().Cast<Control>().ToList();
            foreach (Label item in c)
            {
                Label txt = (Label)item;
                //AListLabels.Add(new ControlProperty { Label = item, ForeColor = txt.ForeColor });
                AListLabels.Add(new ControlProperty { TextControl = item, ForeColor = txt.ForeColor });
            }
        } 
        protected virtual void SetStatus(StatusTestingControl value)
        {

            if (FStatus != value)
            {
                FStatus = value;
                if (FOwner != null)
                {
                    FOwner.ExecStatusChanged(this, value);
                }
                else
                {
                    if (StatusChanged != null) { StatusChanged(this, value); }
                }
            }
        } 
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            //FListLabel.Clear();
            FControlProperty.Clear();
            base.Dispose(disposing);
        }

        public BaseTestingItemControl()
        {
            //FListLabel = new List<Control>();
            FControlProperty = new List<ControlProperty>();
            InitializeComponent();
            Index = 1;
            Code = "";
            tsMain.Visible = false;
        }

        private void BaseTestingItemControl_Resize(object sender, EventArgs e)
        {
            //gbMainItem.Text = Height.ToString() + " " + Width.ToString();
        } 
        private void tmrBlinking_Tick_1(object sender, EventArgs e)
        {
            SetBlinkingColor(FIsBlinking);
            FIsBlinking = !FIsBlinking;
        }

        private void tsFinish_Click(object sender, EventArgs e)
        {
            Value = null;
            tsMain.Visible = false;
            StartBlinking = false;
            if (ButtonFinishClick != null) ButtonFinishClick(this);
        }
    }
}
