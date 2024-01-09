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
        public usc_XemToanBoVe(int user_admin_id, string permission = null)
        {
            InitializeComponent();
            if (permission == "3" ) 
            {
                btn_NapTien.Visible = true;
                btn_DangKyThang.Visible = true;
                User_admin_id = user_admin_id;
            }
        }
        private int User_admin_id;

        public int User_admin_id1 { get => User_admin_id; set => User_admin_id = value; }

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
            tb_MaNguoiDung.Text = ticketAccount.User_id.ToString();
            tb_TenNguoiDung.Text = ticketAccount.Name;
            tb_MaVe.Text = ticketAccount.Ticket_id.ToString();
            try
            {
                DateTime_Start.Visible = true;
                DateTime_End.Visible = true;
                DateTime_Start.Value = DateTime.Parse(ticketAccount.Start_date);
                DateTime_End.Value = DateTime.Parse(ticketAccount.End_date);
                DateTime_Start.Text = ticketAccount.Start_date;
                DateTime_End.Text = ticketAccount.End_date;
            }
            catch
            {
                DateTime_Start.Visible = false;
                DateTime_End.Visible = false;
            }
            tb_Money.Text = ticketAccount.Money.ToString();
            tb_LoaiVe.Text = ticketAccount.Type_card.ToString();
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
            string ticket_id = tb_MaVe.Text;
            string name = tb_TenNguoiDung.Text;
            string type_card = tb_LoaiVe.Text;
            usc_QL_NapTienVe f = new usc_QL_NapTienVe(ticket_id, name, type_card, User_admin_id);
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                int money = int.Parse(tb_Money.Text);
                string ticket_id = tb_MaVe.Text;
                if (money > 100000)
                {
                    DialogResult result = MessageBox.Show("Đăng ký vé tháng ?", "Xác nhận", MessageBoxButtons.YesNo);

                    // Kiểm tra kết quả từ MessageBox
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            
                            DataTable dt = DataProvider.Instance.ExecuteQuery("UPDATE monthly_subscription SET money = money + @money , start_date = @start , end_date = @end , monthly_subscription.type_card = 2 WHERE ticket_id = @ticket_id AND type_card = 3", new object[] { -100000, DateTime.Now, DateTime.Now.AddDays(30), ticket_id });
                            DataProvider.Instance.ExecuteQuery("INSERT INTO transactions(ticket_id, transaction_time, renueve, description, type, user_id_did) VALUES( @ticket_id , @transaction_time , -100000 , N'Đăng ký tháng' , 4 , @user_id_did )", new object[] { ticket_id, DateTime.Now, User_admin_id });
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
            int user_id = int.Parse(tb_MaNguoiDung.Text);
            ShowTicket(user_id);
        }
    }
}
