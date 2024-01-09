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
    public partial class usc_HT_DangKy : UserControl
    {
        public usc_HT_DangKy()
        {
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string user_name = tb_username.Text;
            bool check_user_name = AccountDAO.Instance.CHECK_TRUNGLAP_USERNAME(user_name);
            if (check_user_name == true)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại");
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hợp lệ");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                usc_DM_ThemUser f = this.Tag as usc_DM_ThemUser;
                this.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.BringToFront();
            }
            else
            {
                string user_name = tb_username.Text;
                bool check_user_name = AccountDAO.Instance.CHECK_TRUNGLAP_USERNAME(user_name);
                if (check_user_name == true)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại");
                }
                else
                {
                    if (tb_repw.Text == tb_pw.Text && tb_pw.Text != "")
                    {
                        string password = tb_pw.Text;
                        usc_DM_ThemUser f = new usc_DM_ThemUser(user_name, password);
                        this.Controls.Add(f);
                        f.Dock = DockStyle.Fill;
                        f.BringToFront();
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng kiểm tra lại mật khẩu");
                    }
                }
            }

        }

        private void usc_HT_DangKy_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tb_pw.UseSystemPasswordChar = !tb_pw.UseSystemPasswordChar;
            tb_pw.PasswordChar = '\0';
            
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            tb_repw.UseSystemPasswordChar = !tb_repw.UseSystemPasswordChar;
            tb_repw.PasswordChar = '\0';
        }
    }
}
