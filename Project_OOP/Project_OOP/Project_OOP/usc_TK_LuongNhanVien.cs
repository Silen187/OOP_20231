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
    public partial class usc_TK_LuongNhanVien : UserControl
    {
        public usc_TK_LuongNhanVien()
        {
            InitializeComponent();
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime ngay_bat_dau = guna2DateTimePicker2.Value;
            DateTime ngay_ket_thuc = guna2DateTimePicker1.Value;
            if (guna2TextBox13.Text == "")
            {
                DataTable dt = AccountDAO.Instance.Get_AllSalaryByDate(ngay_bat_dau, ngay_ket_thuc);
                dataGridView1.DataSource = dt;
                int totalSalary = dt.AsEnumerable()
                .Where(row => row.Field<string>("Loại vé") == "Vé dùng một lần")
                .Sum(row => row.Field<int>("Số tiền"));
            }    

        }

        private void usc_TK_LuongNhanVien_Load(object sender, EventArgs e)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("ADD_SALARYPASS_DATE");
            DataTable result2 = DataProvider.Instance.ExecuteQuery("UPDATE_SALARYPASS_DATE");
        }
    }
}
