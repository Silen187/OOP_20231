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
        public usc_SuaNhanVien(string employee_id, string ticket_id, int admin_id)
        {
            Admin_id = admin_id;
            Ticket_id = ticket_id;
            InitializeComponent();
            employeeid = employee_id;
            User_id = DataProvider.Instance.ExecuteQuery("SELECT user_id AS uid FROM employees WHERE employee_id = " + employee_id).Rows[0]["uid"].ToString();
            user_name = DataProvider.Instance.ExecuteQuery("SELECT username AS uname FROM users WHERE user_id = " + User_id).Rows[0]["uname"].ToString();
            pass_word = DataProvider.Instance.ExecuteQuery("SELECT password AS pwd FROM users WHERE user_id = " + User_id).Rows[0]["pwd"].ToString();
        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {

        }
        private string ticket_id;
        private string employeeid;
        private string user_name;
        private string pass_word;
        private string user_id;
        private int admin_id;
        public string Employeeid { get => employeeid; set => employeeid = value; }
        public string User_name { get => user_name; set => user_name = value; }
        public string Pass_word { get => pass_word; set => pass_word = value; }
        public string User_id { get => user_id; set => user_id = value; }
        public string Ticket_id { get => ticket_id; set => ticket_id = value; }
        public int Admin_id { get => admin_id; set => admin_id = value; }

        private void usc_SuaNhanVien_Load(object sender, EventArgs e)
        {
            tb_MaNhanVien.Text = employeeid;
            cb_Bank.DataSource = AccountDAO.Instance.GetBank();
            tb_TenDangNhap.Text = user_name;
            tb_PW.Text = pass_word;
            cb_KhuVuc.DataSource = ZoneDAO.Instance.level_name_list();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
            string name = tb_TenNhanVien.Text;
            string SDT = tb_SDT.Text;
            string salary_level = tb_BacLuong.Text;
            string STK = tb_STK.Text;
            string Bank = cb_Bank.Text;
            string CCCD = tb_CCCD.Text;
            string level_name = cb_KhuVuc.Text;
            string password = tb_PW.Text;
            AccountDAO.Instance.UpdateEmployeeByEmployeeID(employeeid, name, SDT, salary_level, STK, Bank, CCCD, level_name, password);
            DataProvider.Instance.ExecuteQuery("INSERT INTO transactions(ticket_id, transaction_time, description, type, user_id_did) VALUES( @ticket_id , @transaction_time , N'Thay đổi thông tin nhân viên' , 4 , @user_id_did );", new object[] {Ticket_id, DateTime.Now, Admin_id});
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
