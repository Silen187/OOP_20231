using Project_OOP.DAO;
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
        public usc_LichSuNapTien(int userID)
        {
            InitializeComponent();
            User_id = userID;
        }
        private int user_id;

        public int User_id { get => user_id; set => user_id = value; }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
        void Show_History_Money()
        {
            DateTime start_date = DateTime_Start.Value;
            DateTime end_date = DateTime_End.Value;
            if (start_date.Date <= end_date.Date)
            {
                DataTable data = AccountDAO.Instance.History_Money(user_id, start_date, end_date);
                if (data.Rows.Count > 0)
                {
                    dgv_LichSuNapTien.DataSource = data;
                }
            }
            else
            {
                MessageBox.Show("Giá trị ngày không hợp lệ!");
            }
        }

        private void usc_LichSuNapTien_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Show_History_Money();
        }
    }
}
