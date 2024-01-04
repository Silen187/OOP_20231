using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_OOP
{
    public partial class usc_LichSuNapTien : UserControl
    {
        public usc_LichSuNapTien()
        {
            InitializeComponent();
        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Show_History_Money();
        }
        void Show_History_Money()
        {
            DateTime start_date = guna2DateTimePicker2.Value.Date;
            DateTime end_date = guna2DateTimePicker1.Value.Date;

        }
    }
}
