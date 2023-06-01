using Desktop.Forms.Trial.Class;
using Desktop.Forms.Trial.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop.Forms.Trial
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void CreateLayout()
        {

            //tlpLayout.ColumnStyles.Clear();
            //tlpLayout.ColumnCount = 4;
            //tlpLayout.RowStyles.Clear();
            //tlpLayout.RowCount = 16;
            //tlpLayout.SuspendLayout();
            //int cch = 1;
            //for (int row = 1; row <= 16; row++)
            //{
            //    tlpLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            //    for (int col = 1; col <= 4; col++)
            //    {
            //        tlpLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            //        tlpLayout.Controls.Add(new CalibrationControl { CalibrationCellResult = null,Dock=DockStyle.Fill,
            //            Font = new Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))) 

            //    }, cch -1, 0);
            //        cch++;
            //    }
            //}
            //tlpLayout.ResumeLayout();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            //MessageBox.Show("Form width = " + Width.ToString() + "\r\nCalibration Width = " + calibrationControl1.Width.ToString());
           // CreateLayout();
            //CalendarColumn col = new CalendarColumn();
            //dgvGrid.Columns.Add(col);
            //dgvGrid.RowCount = 5;
            //int cch = 1;
            //foreach (DataGridViewRow row in dgvGrid.Rows)
            //{
            //    row.Cells[0].Value = cch;
            //    row.Cells[1].Value = DateTime.Now;
            //    row.Cells[2].Value = true;
            //    cch++;
            //}
            //dgvGrid.Rows.Add(1, 2, 3, 4, 5, 6, 7, DateTime.Now);
        }

        private void dgvGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void calibrationControl1_Load(object sender, EventArgs e)
        {

        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            
        }
    }
}
