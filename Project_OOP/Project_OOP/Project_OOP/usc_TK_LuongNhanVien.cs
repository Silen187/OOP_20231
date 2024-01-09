using Project_OOP.DAO;
using Project_OOP.DTO;
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
        public usc_TK_LuongNhanVien(int user_admin_id)
        {
            InitializeComponent();
            Admin_id = AccountDAO.Instance.GetAdmin_ID_By_UserID(user_admin_id);
        }
        private DataTable data;
        private int admin_id;
        public DataTable Data { get => data; set => data = value; }
        public int Admin_id { get => admin_id; set => admin_id = value; }
        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {  
            DateTime ngay_bat_dau = DateTime_Start.Value;
            DateTime ngay_ket_thuc = DateTime_End.Value;
            if (tb_MaNguoiDung.Text == "")
            {
                btn_SinhBaoCao.Visible = true;
                DataTable dt = AccountDAO.Instance.Get_AllSalaryByDate(ngay_bat_dau, ngay_ket_thuc);
                Data = dt;
                dgv_ThongKeLuong.DataSource = dt;
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
                    tb_avg_admin_income.Text = Average_admin_salary + " Triệu";
                    tb_avg_employee_income.Text = Average_Employee_Salary + " Triệu";
                }
                catch
                {

                }
                 
                tb_total_income.Text = totalSalary.ToString() + " Triệu";
                tb_total_admin.Text = totalSalaryAdmin.ToString() + " Triệu";
                tb_total_employee.Text = totalSalaryEmployee.ToString() + " Triệu";

                tb_admin_income.Text = totalrowCountAdmin.ToString();
                tb_employee_income.Text = totalrowCountEmployee.ToString();
            }
            else
            {
                btn_SinhBaoCao.Visible = false;
                try
                {
                    int user_id = int.Parse(tb_MaNguoiDung.Text);
                    DataTable dt = AccountDAO.Instance.Get_AllSalaryByDateUserID(ngay_bat_dau, ngay_ket_thuc, user_id);
                    dgv_ThongKeLuong.DataSource = dt;
                    string totalSalary = dt.AsEnumerable().Sum(row => row.Field<int>("Lương") / 1000000).ToString();
                    tb_total_income.Text = totalSalary + " Triệu";
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

        private void guna2TextBox13_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string start_date = DateTime_Start.Text;
            string end_date = DateTime_End.Text;
            string luong_string = "Thống kê lương trả nhân viên từ " + start_date + " đến " + end_date;

            Excel_Export.Instance.ExportLuong(data, "Báo cáo lương", luong_string);
            DataProvider.Instance.ExecuteQuery("INSERT INTO reports (start_date, end_date, admin_id, report_description) VALUES ( @start_date , @end_date , @admin_id , N'" + luong_string + "');", new object[] { start_date, end_date, Admin_id });
        }
    }
}
