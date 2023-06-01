using Commons;
using DBProject.Models;
using Desktop.DesktopProperties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Desktop.Controls
{
    public partial class FukudaAQLTestControl : Desktop.Controls.FukudaNormalTestControl
    {
        public override event EventMachineBook OnTransactionMachineBook;

        [Browsable(false)]
        public string PONumber1
        {
            get { return GetPONumber(1); }
            set { SetPONumber(1,value); }
        }

        [Browsable(false)]
        public string PONumber2
        {
            get { return GetPONumber(2); }
            set { SetPONumber(2, value); }
        }

        [Browsable(false)]
        public string PONumber3
        {
            get { return GetPONumber(3); }
            set { SetPONumber(3, value); }
        }

        [Browsable(false)]
        public string PONumber4
        {
            get { return GetPONumber(4); }
            set { SetPONumber(4, value); }
        }

        protected override string GetPONumber(int AIndex)
        {
            if (AIndex == 0) return base.GetPONumber(0);
            else
            {
                TextBox txt = null;
                switch (AIndex)
                {
                    case 1: txt = txtPONumber1; break;
                    case 2: txt = txtPONumber2; break;
                    case 3: txt = txtPONumber3; break;
                    case 4: txt = txtPONumber4; break;
                }
                return txt.Text;
            }
        }
        protected override void SetPONumber(int AIndex, string Value)
        {
            if (AIndex == 0) base.SetPONumber(0, Value);
            else
            {
                TextBox txt = null;
                switch (AIndex)
                {
                    case 1: txt = txtPONumber1; break;
                    case 2: txt = txtPONumber2; break;
                    case 3: txt = txtPONumber3; break;
                    case 4: txt = txtPONumber4; break;
                }
                txt.Text = Value;
            }
        }

        protected override void ControlLoad(object sender, EventArgs e)
        {
           
            base.ControlLoad(sender, e);
         
        }
        public void GenerateAQLCode(int Station)
        {
            if (!DesignMode)
            {
                using (var db = new DBProjectEntities())
                {
                    int cch = db.T_TRANSACTION_INPUTS.Where(x => x.PO_Number.Contains("AQL")).Count();
                    cch = cch + Station;
                    string code = "AQL" + string.Concat(Enumerable.Repeat("0", 10 - (cch.ToString()).Length)) + cch.ToString();
                    txtPONumber.Text = code;
                }
            }
        }

        protected override bool ValidateForm(out Control ControlToFocus, Control ParentControl = null)
        {
            TestMode = TestMode.tmAQL;
            bool ret = base.ValidateForm(out ControlToFocus, ParentControl);
            if (ret)
            {
                for (int i = 1; i <= 4; i++)
                {
                    TextBox txt = null;
                    switch (i)
                    {
                        case 1: txt = txtPONumber1; break;
                        case 2: txt = txtPONumber2; break;
                        case 3: txt = txtPONumber3; break;
                        case 4: txt = txtPONumber4; break;
                    }
                    using (var db = new DBProjectEntities())
                    {
                        T_TRANSACTION_INPUT inp = db.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == txt.Text).FirstOrDefault();
                        if (inp == null)
                        {
                            ControlToFocus = txt;
                            panelMessage.Message = "PO Number " + txt.Text + " not exist\r\nPlease insert it on PO Number List first";
                            ret = false;
                            break;
                        }
                    }
                }
            }
            return ret;
        }

        protected override void Transaction(DBProjectEntities model = null)
        {
            if (!DesignMode)
            {
                TestMode = TestMode.tmAQL;
                base.Transaction(model);
                for (int i = 1; i <= 4; i++)
                {
                    TextBox txt = null;
                    switch (i)
                    {
                        case 1: txt = txtPONumber1; break;
                        case 2: txt = txtPONumber2; break;
                        case 3: txt = txtPONumber3; break;
                        case 4: txt = txtPONumber4; break;
                    }
                    DateTime dt = DateTime.Now;
                    T_TRANSACTION_INPUT inp = model.T_TRANSACTION_INPUTS.Where(x => x.PO_Number == txt.Text).FirstOrDefault();
                    if (inp != null)
                    {
                        inp.AQL_Reference = txtPONumber.Text;      
                        inp.Updated_Date = dt;
                        inp.Updated_User = UserID;
                        model.Entry(inp).CurrentValues.SetValues(inp);
                    }
                    else
                    {
                        inp = new T_TRANSACTION_INPUT
                        {
                            AQL_Reference = txtPONumber.Text,
                            Created_Date = dt,
                            Created_User = UserID,
                            Device_ID = txtDeviceID.Text,
                            End_Test = dt,
                            LotBox_Position_Fukuda = LotboxPosition,
                            LotBox_Position_Laser = 1,
                            Noise_Type_Parameter_Ref = TransactionInput.Noise_Type_Parameter_Ref,
                            PO_Number = txt.Text,
                            Quantity = 0,
                            Signal_Device_ID_Ref = TransactionInput.Signal_Device_ID_Ref,
                            Start_Test = dt,
                            Status = "QUEUE",
                            Updated_Date = dt,
                            Updated_User = UserID,
                            User_ID = UserID,
                        };
                        model.T_TRANSACTION_INPUTS.Add(inp);
                    }
                    Thread.Sleep(200);
                }
            }
        }
        public FukudaAQLTestControl()
        {
            
            InitializeComponent();
            txtQuantity.Text = "125";
            TestMode = TestMode.tmAQL;
        }

        private void txtPONumber_Leave(object sender, EventArgs e)
        {
            if (!DesignMode) { if (TestMode != TestMode.tmAQL) CheckPONumber(); }
        }
    }
}
