using Guna.UI2.WinForms;
using Project_OOP.DAO;
using Project_OOP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_OOP
{
    public partial class fXacNhan : Form
    {
        public fXacNhan(string role_name, int user_id, string displayName, string sex, string city, string SDT, string CCCD, DateTime Birth, string STK, string Bank)
        {
            InitializeComponent();
            User_id = user_id;
            DisplayName = displayName;
            Sex = sex;
            City = city;
            SDT1 = SDT;
            CCCD1 = CCCD;
            Birth1 = Birth;
            STK1 = STK;
            Bank1 = Bank;
            Role_name = role_name;
        }
        private string role_name;
        private string STK;
        private string Bank;
        private string displayName;
        private int user_id;
        private string sex;
        private string city;
        private string SDT;
        private DateTime Birth;
        private string CCCD;
        public int User_id { get => user_id; set => user_id = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Sex { get => sex; set => sex = value; }
        public string City { get => city; set => city = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public DateTime Birth1 { get => Birth; set => Birth = value; }
        public string CCCD1 { get => CCCD; set => CCCD = value; }
        public string STK1 { get => STK; set => STK = value; }
        public string Bank1 { get => Bank; set => Bank = value; }
        public string Role_name { get => role_name; set => role_name = value; }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string input_password = guna2TextBox2.Text;
            if (AccountDAO.Instance.input_password_change(user_id, input_password) == true)
            {
                if (AccountDAO.Instance.UpdateAccount(user_id, displayName, sex, city, SDT, CCCD, Birth, STK, Bank) == true)
                {
                    if (role_name == "customer")
                    {
                        TicketInfoDTO ticket = AccountDAO.Instance.GetTicketInfoByUserID(user_id);
                        string ticket_id = ticket.Ticket_id;
                        DataProvider.Instance.ExecuteQuery("INSERT INTO transactions(ticket_id, transaction_time, description, type) VALUES( @ticket_id , @transaction_time , N'Thay đổi thông tin người dùng', 2);", new object[] { ticket_id, DateTime.Now });
                    }    
                    else if (role_name == "employee")
                    {
                        TicketInfoDTO ticket = AccountDAO.Instance.GetTicketInfoByUserID(user_id);
                        string ticket_id = ticket.Ticket_id;
                        DataProvider.Instance.ExecuteQuery("INSERT INTO transactions(ticket_id, transaction_time, description, type) VALUES( @ticket_id , @transaction_time , N'Thay đổi thông tin nhân viên', 3);", new object[] { ticket_id, DateTime.Now });
                    }
                    else if (role_name == "admin")
                    {
                        DataProvider.Instance.ExecuteQuery("INSERT INTO transactions(transaction_time, description, type, user_id_did) VALUES( @transaction_time , N'Thay đổi thông tin quản lý', 4 , @user_id );", new object[] { DateTime.Now, user_id });
                    }    

                        MessageBox.Show("Cập nhật thành công");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fXacNhan_Load(object sender, EventArgs e)
        {

        }
    }
}
