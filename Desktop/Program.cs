 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JOGAN
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ComputerInfo ci = new ComputerInfo(); 
            //System.Windows.Forms.MessageBox.Show(
            //    "Operation System Information" + "\r\n" +
            //"----------------------------" + "\r\n" +
            //"Name = " + ci.OSFullName + "\r\n" +
            //"Edition = " + ci.OSPlatform + "\r\n" + 
            //"Version = " + ci.OSVersion + "\r\n"   );

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             //Application.Run(new Desktop.frmMain());
           Application.Run(new Desktop.Forms.Trial.Form8());
        }
    }
}
