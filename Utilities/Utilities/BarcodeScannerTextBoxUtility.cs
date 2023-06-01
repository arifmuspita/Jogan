using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Utilites
{
    public delegate void EventBarcodeScannerTextBoxUtility(object sender,  TextBox ATextBox);
    public delegate void EventBeforeBarcodeScannerTextBoxUtility(object sender, ref bool AllowTextChange, TextBox ATextBox);
    //this class will handle textchange on textbox when using barcode scanner to prevent event textchange fired before all text finish received
    public class BarcodeScannerTextBoxUtility : Timer
    { 
        private TextBox FTextBox;
        public TextBox TextBox { get { return FTextBox; } set { SetTextBox(value); } }
        public event EventBarcodeScannerTextBoxUtility OnTimerAfterTick;
        public event EventBeforeBarcodeScannerTextBoxUtility OnTimerBeforeTick;
        public BarcodeScannerTextBoxUtility()
        { 
            Interval = 1000;
            Tick += new EventHandler(Timer_Tick);
        }
        public BarcodeScannerTextBoxUtility(TextBox ATextBox) 
        { 
            Interval = 1000;
            FTextBox = ATextBox;
            if (ATextBox != null)
            {
                ATextBox.TextChanged -= new System.EventHandler(TextBox_TextChanged);
                ATextBox.TextChanged += new System.EventHandler(TextBox_TextChanged);
            }
            Tick += new EventHandler(Timer_Tick);
        }

        private void SetTextBox(TextBox AValue)
        {
            if (FTextBox != null) FTextBox.TextChanged -= new System.EventHandler(TextBox_TextChanged);
            FTextBox = AValue;
            if (AValue != null)
            {
                //AValue.TextChanged -= new System.EventHandler(TextBox_TextChanged);
                AValue.TextChanged += new System.EventHandler(TextBox_TextChanged);
            }
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            bool allowchange = true;
            if (OnTimerBeforeTick != null) OnTimerBeforeTick(sender, ref allowchange, FTextBox);
            if (!allowchange) return; 
            try
            { 
                if (FTextBox.Text.Trim().Length == 1)
                {
                    //FTextBox.TextChanged -= new System.EventHandler(TextBox_TextChanged);
                    
                    Enabled = true;
                    Start();
                    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                Stop();
                string strCurrentString = FTextBox.Text.Trim().ToString();
                if (strCurrentString != "")
                {
                    if (OnTimerAfterTick != null) OnTimerAfterTick(sender, FTextBox); 
                    //FTextBox.TextChanged += new System.EventHandler(TextBox_TextChanged);
                }
                FTextBox.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (FTextBox!=null) FTextBox.TextChanged -= new System.EventHandler(TextBox_TextChanged);
            }
        }
    }
}
