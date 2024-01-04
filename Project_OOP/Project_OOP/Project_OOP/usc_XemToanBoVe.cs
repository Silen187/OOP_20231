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
    public partial class usc_XemToanBoVe : UserControl
    {
        public usc_XemToanBoVe()
        {
            InitializeComponent();
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
            guna2TextBox5.Text = ticketAccount.Start_date;
            guna2TextBox8.Text = ticketAccount.End_date;
            guna2TextBox4.Text = ticketAccount.Money.ToString();
            guna2TextBox15.Text = ticketAccount.Type_card.ToString();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
        void btn_Click(object sender, EventArgs e)
        {
            int userID = int.Parse(((sender as Button).Tag as TicketInfoDTO).User_id);
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

        
    }
}
