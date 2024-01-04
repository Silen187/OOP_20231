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
    public partial class usc_LichSuNhanLuong : UserControl
    {
        public usc_LichSuNhanLuong(int userID)
        {
            InitializeComponent();
            User_id = userID;
        }
        private int user_id;

        public int User_id { get => user_id; set => user_id = value; }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Show_Salary_Pass(user_id);
        }
        void Show_Salary_Pass(int user_id)
        {
            DataTable data = AccountDAO.Instance.Salary_Pass(user_id);
            if (data.Rows.Count > 0)
            {
                dataGridView1.DataSource = data;
            }
            else
            {
                MessageBox.Show("Không có dữ liệu lịch sử");
            }
        }
    }
}
