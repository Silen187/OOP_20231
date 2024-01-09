﻿using Project_OOP.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace Project_OOP
{
    public partial class usc_DM_ThemUser : UserControl
    {
        public usc_DM_ThemUser(string user_name, string pass_word)
        {
            InitializeComponent();
            this.user_name = user_name;
            this.pass_word = pass_word;
        }
        private string user_name;
        private string pass_word;

        public string User_name { get => user_name; set => user_name = value; }
        public string Pass_word { get => pass_word; set => pass_word = value; }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            string STK = tb_STK.Text;
            string Bank = cb_Bank.Text;
            string CCCD = tb_CCCD.Text;
            string name = tb_Name.Text;
            DateTime Birth = DateTime_NgaySinh.Value;
            string sex = cb_Sex.Text;
            if (sex == "Nam")
            {
                sex = "male";
            }
            else if(sex == "Nữ")
            {
                sex = "female";
            }
            else
            {
                sex = "Unknow";
            }
            string city = cb_City.Text;
            string contact_number = tb_SDT.Text;
            string permission_name = cb_permission.Text;
            DateTime register_date = DateTime_NgayDangKy.Value;
            string ticket_id = tb_MaVe.Text;
            string salary_level = tb_BacLuong.Text;
            string level_name = cb_KhuVucLamViec.Text;
            bool check_CCCD = AccountDAO.Instance.CHECK_TRUNGLAP_CCCD(CCCD);

            if (STK == "")
            {
                MessageBox.Show("Vui lòng nhập STK");
            }
            else if (Bank == "")
            {
                MessageBox.Show("Vui lòng nhập ngân hàng");
            }
            else if (CCCD == "")
            {
                MessageBox.Show("Vui lòng nhập CCCD");
            }
            else if (name == "")
            {
                MessageBox.Show("Vui lòng nhập tên");
            }
            else if (city == "")
            {
                MessageBox.Show("Vui lòng điền địa chỉ");
            }
            else if (contact_number == "")
            {
                MessageBox.Show("Vui lòng điền SDT");
            }
            else if (permission_name == "")
            {
                MessageBox.Show("Hãy chọn chức vụ cho người dùng");
            }
            else if (ticket_id == "" && tb_MaVe.Enabled == true)
            {
                MessageBox.Show("Hãy nhập mã vé");
            }
            else if (string.IsNullOrWhiteSpace(salary_level) && tb_BacLuong.Enabled)
            {
                MessageBox.Show("Hãy nhập bậc lương");
            }
            else if (level_name == "" && cb_KhuVucLamViec.Enabled == true)
            {
                MessageBox.Show("Hãy chọn khu vực làm việc");
            }
            else
            {
                if (check_CCCD == false)
                {
                    if (permission_name == "Quản lý")
                    {
                        Add_Admin(User_name, Pass_word, name, Birth, sex, city, contact_number, register_date, salary_level, STK, Bank, CCCD);
                        MessageBox.Show("Đăng ký thành công quản lý " + name);
                        this.Parent.Controls.Remove(this);
                    }
                    else if (permission_name == "Nhân viên")
                    {
                        Add_employee(User_name, Pass_word, name, Birth, sex, city, contact_number, register_date, salary_level, STK, Bank, CCCD, level_name, ticket_id);
                        MessageBox.Show("Đăng ký thành công nhân viên " + name);
                        this.Parent.Controls.Remove(this);
                    }
                    else if (permission_name == "Người dùng")
                    {
                        Add_customer(User_name, Pass_word, name, Birth, sex, city, contact_number, register_date, STK, Bank, CCCD, ticket_id);
                        MessageBox.Show("Đăng ký thành công người dùng " + name);
                        this.Parent.Controls.Remove(this);
                    }
                }
                else
                {
                    MessageBox.Show("Căn cước công dân đã tồn tại");
                }
            }
        }
        void Add_Admin(string username, string password, string name, DateTime Birth, string sex, string city, string contact_number, DateTime register_date, string salary_level, string STK, string Bank, string CCCD)
        {
            AccountDAO.Instance.ADD_ADMIN(User_name, Pass_word, name, Birth, sex, city, contact_number, register_date, salary_level, STK, Bank, CCCD);
        }
        void Add_employee(string username, string password, string name, DateTime Birth, string sex, string city, string contact_number, DateTime register_date, string salary_level, string STK, string Bank, string CCCD, string level_name, string ticket_id)
        {
            AccountDAO.Instance.ADD_EMPLOYEE(User_name, Pass_word, name, Birth, sex, city, contact_number, register_date, salary_level, STK, Bank, CCCD, level_name, ticket_id);
        }
        void Add_customer(string username, string password, string name, DateTime Birth, string sex, string city, string contact_number, DateTime register_date, string STK, string Bank, string CCCD, string ticket_id)
        {
            AccountDAO.Instance.ADD_CUSTOMER(User_name, Pass_word, name, Birth, sex, city, contact_number, register_date, STK, Bank, CCCD, ticket_id);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);

            // Kiểm tra kết quả từ MessageBox
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, hiển thị UserControl usc_DM_NhanVien
                this.Parent.Tag = this;
                this.Parent.Controls.Remove(this);
            }
        }

        private void comboBox4_SelectedValueChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if (cb.Text == "Quản lý")
            {
                cb_KhuVucLamViec.Text = "";
                tb_MaChucVu.Text = "Admin";
                tb_MaVe.Enabled = false;
                check.Enabled = false;
                tb_BacLuong.Enabled = true;
                cb_KhuVucLamViec.Enabled = false;
            }
            else if (cb.Text == "Nhân viên")
            {
                tb_MaChucVu.Text = "Employee";
                tb_MaVe.Enabled = true;
                check.Enabled = true;
                tb_BacLuong.Enabled = true;
                cb_KhuVucLamViec.Enabled = true;
            }
            else if (cb.Text == "Người dùng")
            {
                cb_KhuVucLamViec.Text = "";
                tb_MaChucVu.Text = "Customer";
                tb_MaVe.Enabled = true;
                check.Enabled = true;
                tb_BacLuong.Enabled = false;
                cb_KhuVucLamViec.Enabled = false;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string ticket_id = tb_MaVe.Text;
            bool check_user_name = AccountDAO.Instance.CHECK_TRUNGLAP_TICKET(ticket_id);
            if (check_user_name == true)
            {
                MessageBox.Show("Vé đã tồn tại");
            }
            else
            {
                MessageBox.Show("Vé hợp lệ");
            }
        }

        private void usc_DM_ThemNhanVien_Load(object sender, EventArgs e)
        {
            Get_level_name();
            cb_Bank.DataSource = AccountDAO.Instance.GetBank();
        }
        void Get_level_name()
        {
            List<string> list_level_name = new List<string>();
            list_level_name = ZoneDAO.Instance.level_name_list();
            cb_KhuVucLamViec.DataSource = list_level_name;
        }
    }
}
