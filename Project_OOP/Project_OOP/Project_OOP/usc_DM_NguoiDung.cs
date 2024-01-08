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
    public partial class usc_DM_NguoiDung : UserControl
    {
        public usc_DM_NguoiDung(string user_admin_id)
        {
            InitializeComponent();
            User_admin_id = int.Parse(user_admin_id);
        }
        private InfoDTO account;
        private TicketInfoDTO ticket;
        private int user_admin_id;

        public InfoDTO Account { get => account; set => account = value; }
        public TicketInfoDTO Ticket { get => ticket; set => ticket = value; }
        public int User_admin_id { get => user_admin_id; set => user_admin_id = value; }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel13_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel7_Click(object sender, EventArgs e)
        {

        }

        private void usc_DM_NguoiDung_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string user_id = guna2TextBox16.Text;
            try
            {
                if (user_id == "")
                {
                    MessageBox.Show("Nhập mã người dùng");
                }
                else
                {
                    Ticket = AccountDAO.Instance.GetTicketInfoByUserID(int.Parse(user_id));
                    Account = AccountDAO.Instance.GetAccountByUserID(int.Parse(user_id));

                    guna2TextBox5.Text = Account.Name1;
                    guna2TextBox12.Text = Account.Name1;
                    guna2TextBox23.Text = Account.Username;
                    if (Account.Sex == "male")
                    {
                        comboBox1.Text = "Nam";
                    }    
                    else if (Account.Sex == "female")
                    {
                        comboBox1.Text = "Nữ";
                    }
                    else
                    {
                        comboBox1.Text = "Khác";
                    }
                    guna2TextBox20.Text = Account.Password;
                    guna2DateTimePicker1.Value = Account.Birth1;
                    guna2TextBox18.Text = Ticket.Ticket_id;
                    comboBox2.Text = Account.City1;
                    guna2DateTimePicker4.Text = Ticket.Start_date;
                    guna2TextBox4.Text = Account.SDT1;
                    guna2TextBox28.Text = Account.CCCD1;
                    guna2TextBox1.Text = Account.STK1;
                    comboBox3.Text = Account.Bank1;
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                usc_SuaNguoiDung f = new usc_SuaNguoiDung(Ticket, Account, User_admin_id);
                this.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.BringToFront();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa người dùng này ?", "Xác nhận", MessageBoxButtons.YesNo);
            int user_id = int.Parse(guna2TextBox16.Text);
            // Kiểm tra kết quả từ MessageBox
            if (result == DialogResult.Yes)
            {
                try
                {
                    AccountDAO.Instance.Delete_Customer(user_id);
                    DataProvider.Instance.ExecuteQuery("INSERT INTO transactions(ticket_id, transaction_time, description, type, user_id_did) VALUES( @ticket_id , @transaction_time , N'Xóa người dùng' , 4 , @user_id_did );", new object[] { Ticket.Ticket_id, DateTime.Now, User_admin_id });
                    MessageBox.Show("Xóa thành công");
                }
                catch
                {
                    MessageBox.Show("Đã có lỗi xảy ra");
                }
            }
        }
    }
}
