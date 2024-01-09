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
            tb_MaNguoiDung.Text = ticketAccount.User_id.ToString();
            tb_TenNguoiDung.Text = ticketAccount.Name;
            tb_MaVe.Text = ticketAccount.Ticket_id.ToString();
            tb_VeThang_Start.Text = ticketAccount.Start_date;
            tb_VeThang_End.Text = ticketAccount.End_date;
            tb_Money.Text = ticketAccount.Money.ToString();
            tb_LoaiVe.Text = ticketAccount.Type_card.ToString();
        }

        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }
    }
}
