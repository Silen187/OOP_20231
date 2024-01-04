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
    public partial class usc_LichSuRaVao : UserControl
    {
        public usc_LichSuRaVao(int userID)
        {
            InitializeComponent();
            User_id = userID;
        }
        private int user_id;

        public int User_id { get => user_id; set => user_id = value; }

        private void usc_LichSuRaVao_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Show_History_Entry();
        }
        void Show_History_Entry()
        {
            DateTime start_date = guna2DateTimePicker2.Value;
            DateTime end_date = guna2DateTimePicker1.Value;
            if (start_date.Date <= end_date.Date)
            {
                DataTable data = AccountDAO.Instance.History_Entry(user_id, start_date, end_date);
                if (data.Rows.Count > 0)
                {
                    dataGridView1.DataSource = data;
                }
            }
            else
            {
                MessageBox.Show("Giá trị ngày không hợp lệ!");
            }
        }
    }
}
