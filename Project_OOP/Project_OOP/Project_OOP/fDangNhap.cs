using Project_OOP.DAO;
using Project_OOP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_OOP
{
    public partial class fDangNhap : Form
    {
        public fDangNhap()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            {
                string userName = guna2TextBox1.Text;
                string passWord = guna2TextBox2.Text;
                int userID = Login(userName, passWord);

                InfoDTO loginAccount = AccountDAO.Instance.GetAccountByUserID(userID);
                if (userID != -1)
                {
                    if (permission_login(userID) == 1)
                    {
                        fKhachHang form_khach_hang = new fKhachHang(loginAccount);
                        this.Hide();
                        form_khach_hang.ShowDialog();
                        this.Show();
                    }
                    if (permission_login(userID) == 2)
                    {
                        fNhanVien form_nhan_vien = new fNhanVien(loginAccount);
                        this.Hide();
                        form_nhan_vien.ShowDialog();
                        this.Show();
                    }
                    if (permission_login(userID) == 3)
                    {
                        fQuanLy form_quan_ly = new fQuanLy(loginAccount);
                        this.Hide();
                        form_quan_ly.ShowDialog();
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
                }
            }
        }
        int Login(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }
        int permission_login(int user_id)
        {
            return AccountDAO.Instance.permission(user_id);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void fDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
