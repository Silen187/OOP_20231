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
    public partial class usc_ThongTinVe : UserControl
    {
        public usc_ThongTinVe(int userID)
        {
            InitializeComponent();
            TicketInfoDTO ticketAccount = AccountDAO.Instance.GetTicketInfoByUserID(userID);
            Load_Info(ticketAccount);
        }

        void Load_Info(TicketInfoDTO ticketAccount)
        {
            guna2TextBox1.Text = ticketAccount.User_id.ToString();
            guna2TextBox2.Text = ticketAccount.Name;
            guna2TextBox6.Text = ticketAccount.Ticket_id.ToString();
            guna2TextBox5.Text = ticketAccount.Start_date;
            guna2TextBox8.Text = ticketAccount.End_date;
            guna2TextBox4.Text = ticketAccount.Money.ToString();
            guna2TextBox10.Text = ticketAccount.Type_card.ToString();
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
