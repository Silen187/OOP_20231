using Project_OOP.DAO;
using Project_OOP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_OOP
{
    public partial class usc_XemToanBoVe : UserControl
    {
        public usc_XemToanBoVe(string permission = null)
        {
            InitializeComponent();
            if (permission == "3" ) 
            {
                guna2Button2.Visible = true;
                guna2Button3.Visible = true;
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel15_Click(object sender, EventArgs e)
        {

        }
        void Load_All_Ticket(List<int> userid_list)
        {
            List<TicketInfoDTO> Ticket_List = AccountDAO.Instance.LoadTicketList(userid_list);

            foreach (TicketInfoDTO item in Ticket_List)
            {
                Button btn = new Button() { Width = 375, Height = 47 };
                btn.Text = "Mã người dùng: " + item.User_id + " | Mã vé: " + item.Ticket_id;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Type_card)
                {
                    case "Vé nhân viên":
                        btn.BackColor = Color.Violet;
                        break;
                    case "Vé khách hàng":
                        btn.BackColor = Color.BlueViolet;
                        break;
                    case "Vé dùng một lần":
                        btn.BackColor = Color.DarkViolet;
                        break;
                }

                flowLayoutPanel2.Controls.Add(btn);
            }
        }
        void ShowTicket(int user_id)
        {
            TicketInfoDTO ticketAccount = AccountDAO.Instance.GetTicketInfoByUserID(user_id);
            Load_Info(ticketAccount);
        }

        void Load_Info(TicketInfoDTO ticketAccount)
        {
            guna2TextBox9.Text = ticketAccount.User_id.ToString();
            guna2TextBox12.Text = ticketAccount.Name;
            guna2TextBox6.Text = ticketAccount.Ticket_id.ToString();
            try
            {
                guna2DateTimePicker1.Visible = true;
                guna2DateTimePicker4.Visible = true;
                guna2DateTimePicker1.Value = DateTime.Parse(ticketAccount.Start_date);
                guna2DateTimePicker4.Value = DateTime.Parse(ticketAccount.End_date);
                guna2DateTimePicker1.Text = ticketAccount.Start_date;
                guna2DateTimePicker4.Text = ticketAccount.End_date;
            }
            catch
            {
                guna2DateTimePicker1.Visible = false;
                guna2DateTimePicker4.Visible = false;
            }
            guna2TextBox4.Text = ticketAccount.Money.ToString();
            guna2TextBox15.Text = ticketAccount.Type_card.ToString();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int userID = int.Parse((btn.Tag as TicketInfoDTO).User_id);
            ShowTicket(userID);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            string string_list_userid = guna2TextBox1.Text;
            if (string_list_userid.Split(',').Length > 10)
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm hợp lệ");
            }
            else
            {
                List<int> list_userid = new List<int>();
                try
                {
                    foreach (string item in string_list_userid.Split(','))
                    {
                        list_userid.Add(int.Parse(item));
                    }
                    Load_All_Ticket(list_userid);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
                }
            }

        }

        private void usc_XemToanBoVe_Load(object sender, EventArgs e)
        {
            AccountDAO.Instance.UpdateTicket();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string ticket_id = guna2TextBox6.Text;
            string name = guna2TextBox12.Text;
            string type_card = guna2TextBox15.Text;
            usc_QL_NapTienVe f = new usc_QL_NapTienVe(ticket_id, name, type_card);
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int money = int.Parse(guna2TextBox4.Text);
                string ticket_id = guna2TextBox6.Text;
                if (money > 100000)
                {
                    DialogResult result = MessageBox.Show("Đăng ký vé tháng ?", "Xác nhận", MessageBoxButtons.YesNo);

                    // Kiểm tra kết quả từ MessageBox
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            DataTable dt = DataProvider.Instance.ExecuteQuery("UPDATE monthly_subscription SET money = money + @money , start_date = @start , end_date = @end , monthly_subscription.type_card = 2 WHERE ticket_id = @ticket_id AND type_card = 3", new object[] { -100000, DateTime.Now, DateTime.Now.AddDays(30), ticket_id });
                            MessageBox.Show("Đăng ký vé tháng thành công");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã có lỗi xảy ra " + ex.Message);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Số dư không đủ");
                }
            }
            catch 
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            }
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            int user_id = int.Parse(guna2TextBox9.Text);
            ShowTicket(user_id);
        }
    }
}
