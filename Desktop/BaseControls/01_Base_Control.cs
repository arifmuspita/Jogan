using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DBProject.Models;
using Desktop.BaseComponents;
using System.Data.Entity.Validation;
using System.Transactions;
using Desktop.DesktopProperties;
using Utilities;
using Commons;

namespace Desktop.BaseControls
{ 
    public partial class BaseControl : UserControl
    {
        [Browsable(false)]
        public T_TRANSACTION_INPUT FTransactionInput;

        [Browsable(false)]
        public T_TRANSACTION_INPUT TransactionInput
        {
           // get { if (FTransactionInput == null) FTransactionInput = new T_TRANSACTION_INPUT(); return FTransactionInput; }
            //get { if (FTransactionInput != null) FTransactionInput = new T_TRANSACTION_INPUT();return FTransactionInput; }
            get {  return FTransactionInput; }
            set { SetTransactionInput (value); }
        }
        protected virtual void SetTransactionInput(T_TRANSACTION_INPUT Value)
        {
            FTransactionInput = Value;
            //if (Value != null)
            //{
            //    FTransactionInput.AQL_Reference = Value.AQL_Reference;
            //    FTransactionInput.Created_Date = Value.Created_Date;
            //    FTransactionInput.Created_User = Value.Created_User;
            //    FTransactionInput.Default_Test_Mode = Value.Default_Test_Mode;
            //    FTransactionInput.Device_ID = Value.Device_ID;
            //    FTransactionInput.End_Test = Value.End_Test;
            //    FTransactionInput.LotBox_ID = Value.LotBox_ID;
            //    FTransactionInput.LotBox_Position_Fukuda = Value.LotBox_Position_Fukuda;
            //    FTransactionInput.LotBox_Position_Laser = Value.LotBox_Position_Laser;
            //    FTransactionInput.LotBox_Position_Laser_Downgrade = Value.LotBox_Position_Laser_Downgrade;
            //    FTransactionInput.Noise_Type_Parameter_Ref = Value.Noise_Type_Parameter_Ref;
            //    FTransactionInput.PO_Number = "AAAA";// Value.PO_Number;
            //    FTransactionInput.Quantity = Value.Quantity;
            //    FTransactionInput.Signal_Device_ID_Ref = Value.Signal_Device_ID_Ref;
            //    FTransactionInput.Start_Test = Value.Start_Test;
            //    FTransactionInput.Status = Value.Status;
            //    FTransactionInput.Updated_Date = Value.Updated_Date;
            //    FTransactionInput.Updated_User = Value.Updated_User;
            //    FTransactionInput.User_ID = Value.User_ID;
            //}
            //Commons.Commons.CopyProperties(Value, FTransactionInput);
        }
        private T_TRANSACTION_LASER FTransactionLaser;
        [Browsable(false)]
        public T_TRANSACTION_LASER TransactionSorter
        {
            //get { if (FTransactionLaser == null) FTransactionLaser = new T_TRANSACTION_LASER(); return FTransactionLaser; }
            get {  return FTransactionLaser; }
            set { FTransactionLaser = value; }
        }
        private ButtonControlDisabled FButtonControlDisabled;
        //[Browsable(true)]
        public ButtonControlDisabled ButtonControlDisabled { get { return FButtonControlDisabled; } set { SetButtonControlDisabled(value); } }
        private int FLotboxPosition { get; set; }
        public int LotboxPosition { get { return FLotboxPosition; } set { FLotboxPosition = value; } }
        private TestMode FTestMode;
       // [Browsable(false)]
        public TestMode TestMode { get { return FTestMode; } set { FTestMode = value; } }
        private string FUserID { get; set; }
        [Browsable(false)]
        public string UserID { get { return FUserID; } set { FUserID = value; } }
        
        private void SetButtonControlDisabled(ButtonControlDisabled AValue)
        {
            FButtonControlDisabled = AValue;
            if (AValue == ButtonControlDisabled.bceNone)
            {
                btnCancel.Enabled = true;
                btnSetReady.Enabled = true;
            } else
            if (AValue == ButtonControlDisabled.bceAll)
            {
                btnCancel.Enabled = false;  
                btnSetReady.Enabled = false;
            }
            else
            if (AValue == ButtonControlDisabled.bceCancel)
            {
                btnCancel.Enabled = false;  
            }
            else
            if (AValue == ButtonControlDisabled.bceSetReady)
            {
                btnSetReady.Enabled = false;
            }
        }
        protected virtual string GetPONumber(int AIndex)
        {
            return "";
        }
        protected virtual void SetPONumber(int AIndex,string Value)
        {

        }
        [Browsable(false)]
        public string PONumber {
            get { return GetPONumber(0); }
            set { SetPONumber(0,value); }
        }
        //[Browsable(false)]
        //private DBProjectEntities FDBEntities;
        [Browsable(false)]
        public Control FocusControl { get; set; }
        //private PanelMessage FPanelMessage;
        public event EventSetReadyClick OnBeforeSetReadyClick;
        public event EventHandler OnAfterSetReadyClick;
        public event EventHandler OnSetReadyClick;
        public event EventHandler OnCancelClick;

        public virtual event EventMachineBook OnTransactionMachineBook;
        [Browsable(false)]
        //public DBProjectEntities DBEntities
        //{
        //    get { if (FDBEntities == null) FDBEntities = new DBProjectEntities(); return FDBEntities; }
        //    set { FDBEntities = value; }
        //}
        public BaseControl()
        {
            FTransactionInput = new T_TRANSACTION_INPUT();
            FTransactionLaser = new T_TRANSACTION_LASER();
            InitializeComponent();
            panelMessage.Parent = this;
            //ButtonControlDisabled = ButtonControlDisabled.bceNone;
        }

        private void BaseControl_Load(object sender, EventArgs e)
        {
            ControlLoad(sender, e);
        }

        protected virtual void ControlLoad(object sender, EventArgs e)
        {
            //FPanelMessage = new PanelMessage();
            //panelMessage.Parent = this;
           // TestMode = TestMode.tmNormal;
        }

        protected virtual bool ValidateForm(out Control ControlToFocus,Control ParentControl = null)
        {
            bool ret = true;
            //bool isbreak = false;
            if (ParentControl == null) { ParentControl = this; }
            List<Control> c = ParentControl.Controls.OfType<TextBox>().Cast<Control>().ToList();
            c = c.OrderBy(x => x.TabIndex).ToList();
            TextBox txtFocus = null;
            foreach (TextBox item in c)
            {
                txtFocus = (TextBox)item;
                if (txtFocus.Enabled && txtFocus.Visible)
                {
                    string msg = (string)txtFocus.Tag == null ? "" : (string)txtFocus.Tag;
                    if (txtFocus.Text == "") { panelMessage.Message = "Please fill this " + msg + " first"; ret = false; break; }
                }
            }
            c.Clear();
            ControlToFocus = txtFocus;
            return ret;
        }

        protected virtual bool IsDataExist()
        {
            return true;
        }

        //public PanelMessage PanelMessage { get { return FPanelMessage; } }

        protected virtual bool SetReadyClick(object sender, EventArgs e)
        {
            return true;
        }

        protected virtual void CancelClick(object sender, EventArgs e)
        {
            frmAuthCancelTest frm = new frmAuthCancelTest(UserID, PONumber);
            frm.ShowDialog();
        }
        private void btnSetReady_Click(object sender, EventArgs e)
        {
            bool allow = true;
            if (OnBeforeSetReadyClick != null) { OnBeforeSetReadyClick(sender, out allow); }
            if (allow)
            {
                SetReadyClick(sender, e);
                if (OnAfterSetReadyClick != null) { OnAfterSetReadyClick(this, e); }
            }
           // if (OnSetReadyClick != null) { OnSetReadyClick(sender, e); }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CancelClick(sender, e);
            if (OnCancelClick != null) { OnCancelClick(sender, e); }
        }

        protected virtual void Transaction(DBProjectEntities model = null)
        {

        }
        protected bool SaveData(bool SkipValidate = false, bool ShowMassage = true, Control ParentControl = null)
        {
            bool ret = false;
            Control cntrl = null;
            if (ValidateForm(out cntrl, ParentControl) || SkipValidate)
            {
                try
                {
                    using (TransactionScope trans = new TransactionScope())
                    {
                        using (var db = new DBProjectEntities())
                        {
                            Transaction(db);
                            db.SaveChanges();
                            ret = true;
                        }
                        trans.Complete();
                        if (ShowMassage) { MessageBox.Show("Success update/insert/delete data"); }
                    }
                }
                catch (DbEntityValidationException ex)
                {
                    // Retrieve the error messages as a list of strings.
                    var errorMessages = ex.EntityValidationErrors
                            .SelectMany(x => x.ValidationErrors)
                            .Select(x => x.ErrorMessage);

                    // Join the list to a single string.
                    var fullErrorMessage = string.Join("\r\n", errorMessages);

                    // Combine the original exception message with the new one.
                    //var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                    // Throw a new DbEntityValidationException with the improved exception message.
                    //throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                    string msg = "The validation errors are:\r\n" + fullErrorMessage;
                    if (ShowMassage)
                    { MessageBox.Show("Error while update/insert/delete data.\r\nError description : \r\n" + msg); }
                    ret = false;
                }
                catch (Exception e)
                {
                    string msg = e.Message;
                    if (e.InnerException != null)
                    {
                        msg = msg + "\r\n" + e.InnerException.Message;
                        if (e.InnerException.InnerException != null)
                        {
                            msg = msg + "\r\n" + e.InnerException.InnerException.Message;
                        }
                    }
                    if (ShowMassage)
                    { MessageBox.Show("Error while update/insert/delete data.\r\nError description : \r\n" + msg); }
                    ret = false;
                }
            }
            FocusControl = cntrl;
            return ret;
        }
    }
}
