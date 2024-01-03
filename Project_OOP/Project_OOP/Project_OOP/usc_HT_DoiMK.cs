using Guna.UI2.WinForms;
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
    public partial class usc_HT_DoiMK : UserControl
    {
        public usc_HT_DoiMK(InfoDTO acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        private InfoDTO loginAccount;
        public InfoDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        void ChangeAccount(InfoDTO acc)
        {
            guna2TextBox1.Text = acc.Username;
            guna2TextBox2.Text = acc.Name1;
        }

        private void usc_HT_DoiMK_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UpdatePassWord();
        }
        void UpdatePassWord()
        {
            string oldPass = guna2TextBox5.Text;
            string newPass = guna2TextBox3.Text;
            string reNewPass = guna2TextBox4.Text;
            if (oldPass != loginAccount.Password)
            {
                MessageBox.Show("Mật khẩu sai.");
            }
            else
            {
                if (newPass == reNewPass)
                {
                    if (newPass == oldPass)
                    {
                        MessageBox.Show("Mật khẩu của bạn không có sự thay đổi!");
                    }
                    else if (newPass == "")
                    {
                        MessageBox.Show("Vui lòng nhập mật khẩu mới");
                    }
                    else
                    {
                        if (AccountDAO.Instance.UpdatePassWordAccount(loginAccount.Username, oldPass, newPass) == true)
                        {
                            MessageBox.Show("Cập nhật mật khẩu thành công");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới nhập lại không khớp!");
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            guna2TextBox3.UseSystemPasswordChar = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            guna2TextBox5.UseSystemPasswordChar = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            guna2TextBox4.UseSystemPasswordChar = false;
        }
    }
}
