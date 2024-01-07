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
    public partial class usc_SuaNhanVien : UserControl
    {
        public usc_SuaNhanVien(string employee_id)
        {
            InitializeComponent();
            employeeid = employee_id;
            User_id = DataProvider.Instance.ExecuteQuery("SELECT user_id AS uid FROM employees WHERE employee_id = " + employee_id).Rows[0]["uid"].ToString();
            user_name = DataProvider.Instance.ExecuteQuery("SELECT username AS uname FROM users WHERE user_id = " + User_id).Rows[0]["uname"].ToString();
            pass_word = DataProvider.Instance.ExecuteQuery("SELECT password AS pwd FROM users WHERE user_id = " + User_id).Rows[0]["pwd"].ToString();
        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {

        }
        private string employeeid;
        private string user_name;
        private string pass_word;
        private string user_id;

        public string Employeeid { get => employeeid; set => employeeid = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string Pass_word { get => pass_word; set => pass_word = value; }
        public string User_id { get => user_id; set => user_id = value; }

        private void usc_SuaNhanVien_Load(object sender, EventArgs e)
        {
            guna2TextBox9.Text = employeeid;
            comboBox5.DataSource = AccountDAO.Instance.GetBank();
            guna2TextBox19.Text = user_name;
            guna2TextBox6.Text = pass_word;
            comboBox1.DataSource = ZoneDAO.Instance.level_name_list();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = guna2TextBox12.Text;
                string SDT = guna2TextBox8.Text;
                string salary_level = guna2TextBox4.Text;
                string STK = guna2TextBox1.Text;
                string Bank = comboBox5.Text;
                string CCCD = guna2TextBox15.Text;
                string level_name = comboBox1.Text;
                string password = guna2TextBox6.Text;
                AccountDAO.Instance.UpdateEmployeeByEmployeeID(employeeid, name, SDT, salary_level, STK, Bank, CCCD, level_name, password);
                MessageBox.Show("Cập nhật thành công");
                this.Parent.Controls.Remove(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra " + ex.Message);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);

            // Kiểm tra kết quả từ MessageBox
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, hiển thị UserControl usc_DM_NhanVien
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
