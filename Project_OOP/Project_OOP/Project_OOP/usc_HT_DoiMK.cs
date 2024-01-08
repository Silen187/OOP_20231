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
                            int user_id = int.Parse(loginAccount.ID1);
                            if (loginAccount.Role_name == "customer")
                            {
                                TicketInfoDTO ticket = AccountDAO.Instance.GetTicketInfoByUserID(user_id);
                                string ticket_id = ticket.Ticket_id;
                                DataProvider.Instance.ExecuteQuery("INSERT INTO transactions(ticket_id, transaction_time, description, type) VALUES( @ticket_id , @transaction_time , N'Thay đổi mật khẩu người dùng', 2);", new object[] { ticket_id, DateTime.Now });
                            }    
                            else if (loginAccount.Role_name == "employee")
                            {
                                TicketInfoDTO ticket = AccountDAO.Instance.GetTicketInfoByUserID(user_id);
                                string ticket_id = ticket.Ticket_id;
                                DataProvider.Instance.ExecuteQuery("INSERT INTO transactions(ticket_id, transaction_time, description, type) VALUES( @ticket_id , @transaction_time , N'Thay đổi mật khẩu nhân viên', 3);", new object[] { ticket_id, DateTime.Now });
                            }    
                            else if (loginAccount.Role_name == "admin")
                            {
                                DataProvider.Instance.ExecuteQuery("INSERT INTO transactions(transaction_time, description, type, user_id_did) VALUES( @transaction_time , N'Thay đổi mật khẩu quản lý', 4 , @user_id );", new object[] { DateTime.Now, user_id });
                            }
                                
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
            guna2TextBox3.UseSystemPasswordChar = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            guna2TextBox5.UseSystemPasswordChar = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            guna2TextBox4.UseSystemPasswordChar = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guna2TextBox5.UseSystemPasswordChar = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2TextBox5.UseSystemPasswordChar = !guna2TextBox5.UseSystemPasswordChar;
            guna2TextBox5.PasswordChar = '\0';
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2TextBox3.UseSystemPasswordChar = !guna2TextBox3.UseSystemPasswordChar;
            guna2TextBox3.PasswordChar = '\0';
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2TextBox4.UseSystemPasswordChar = !guna2TextBox4.UseSystemPasswordChar;
            guna2TextBox4.PasswordChar = '\0';
        }
    }
}
