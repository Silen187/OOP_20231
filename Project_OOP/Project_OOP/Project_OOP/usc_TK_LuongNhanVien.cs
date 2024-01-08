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
                string totalSalaryAdmin = dt.AsEnumerable()
                .Where(row => row.Field<string>("Chức vụ") == "Quản lý")
                .Sum(row => row.Field<int>("Lương")/1000000).ToString();

                string totalSalaryEmployee = dt.AsEnumerable()
                .Where(row => row.Field<string>("Chức vụ") == "Nhân viên")
                .Sum(row => row.Field<int>("Lương")/1000000).ToString();

                string totalSalary = dt.AsEnumerable().Sum(row => row.Field<int>("Lương")/1000000).ToString();

                int totalrowCountAdmin = dt.Select("[Chức vụ] = 'Quản lý'").Length;
                int totalrowCountEmployee = dt.Select("[Chức vụ] = 'Nhân viên'").Length;
                try
                {
                    string Average_admin_salary = (int.Parse(totalSalaryAdmin) / totalrowCountAdmin).ToString();
                    string Average_Employee_Salary = (int.Parse(totalSalaryEmployee) / totalrowCountEmployee).ToString();
                    guna2TextBox5.Text = Average_admin_salary + " Triệu";
                    guna2TextBox6.Text = Average_Employee_Salary + " Triệu";
                }
                catch
                {

                }
                 
                guna2TextBox4.Text = totalSalary.ToString() + " Triệu";
                guna2TextBox3.Text = totalSalaryAdmin.ToString() + " Triệu";
                guna2TextBox7.Text = totalSalaryEmployee.ToString() + " Triệu";

                guna2TextBox1.Text = totalrowCountAdmin.ToString();
                guna2TextBox2.Text = totalrowCountEmployee.ToString();
            }
            else
            {
                try
                {
                    int user_id = int.Parse(guna2TextBox13.Text);
                    DataTable dt = AccountDAO.Instance.Get_AllSalaryByDateUserID(ngay_bat_dau, ngay_ket_thuc, user_id);
                    dataGridView1.DataSource = dt;
                    string totalSalary = dt.AsEnumerable().Sum(row => row.Field<int>("Lương") / 1000000).ToString();
                    guna2TextBox4.Text = totalSalary + " Triệu";
                }
                catch 
                { 

                }
            }    

        }

        private void usc_TK_LuongNhanVien_Load(object sender, EventArgs e)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("ADD_SALARYPASS_DATE");
            DataTable result2 = DataProvider.Instance.ExecuteQuery("UPDATE_SALARYPASS_DATE");
        }
    }
}
