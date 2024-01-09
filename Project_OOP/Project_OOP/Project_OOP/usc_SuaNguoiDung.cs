using Guna.UI2.WinForms;
using Project_OOP.DAO;
using Project_OOP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_OOP
{
    public partial class usc_SuaNguoiDung : UserControl
    {
        public usc_SuaNguoiDung(TicketInfoDTO ticket, InfoDTO account, int user_admin_id)
        {
            InitializeComponent();
            Load_info(ticket, account);
            Old_pass = account.Password;
            Old_CCCD = account.CCCD1;
            User_admin_id = user_admin_id;
            Ticket = ticket;
        }
        private TicketInfoDTO ticket;
        private int user_admin_id;
        private string old_pass;
        private string old_CCCD;
        public string Old_pass { get => old_pass; set => old_pass = value; }
        public string Old_CCCD { get => old_CCCD; set => old_CCCD = value; }
        public int User_admin_id { get => user_admin_id; set => user_admin_id = value; }
        public TicketInfoDTO Ticket { get => ticket; set => ticket = value; }

        private void usc_SuaNguoiDung_Load(object sender, EventArgs e)
        {
            cb_Bank.DataSource = AccountDAO.Instance.GetBank();
        }
        void Load_info(TicketInfoDTO ticket, InfoDTO account) 
        {
            DateTime_NgaySinh.Value = account.Birth1;
            tb_MaNguoiDung.Text = account.ID1;
            tb_TenKhachHang.Text = account.Name1;
            cb_City.Text = account.City1;
            tb_SDT.Text = account.SDT1;
            tb_STK.Text = account.STK1;
            tb_TenDangNhap.Text = account.Username;
            tb_PW.Text = account.Password;
            cb_Sex.Text = account.Sex;
            tb_CCCD.Text = account.CCCD1;
            cb_Bank.Text = account.Bank1;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);

            // Kiểm tra kết quả từ MessageBox
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, hiển thị UserControl usc_DM_NhanVien
                this.Parent.Controls.Remove(this);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_CCCD.Text == Old_CCCD || AccountDAO.Instance.CHECK_TRUNGLAP_CCCD(tb_CCCD.Text) == false)
                {
                    int user_id = int.Parse(tb_MaNguoiDung.Text);
                    string username = tb_TenDangNhap.Text;
                    string name = tb_TenKhachHang.Text;
                    string city = cb_City.Text;
                    string SDT = tb_SDT.Text;
                    string STK = tb_STK.Text;
                    string password = tb_PW.Text;
                    string CCCD = tb_CCCD.Text;
                    string Bank = cb_Bank.Text;
                    string sex = cb_Sex.Text;
                    DateTime birth = DateTime_NgaySinh.Value;
                    AccountDAO.Instance.UpdateAccount(user_id, name, sex, city, SDT, CCCD, birth, STK, Bank);
                    AccountDAO.Instance.UpdatePassWordAccount(username, Old_pass, password);
                    DataProvider.Instance.ExecuteQuery("INSERT INTO transactions(ticket_id, transaction_time, description, type, user_id_did) VALUES( @ticket_id , @transaction_time , N'Thay đổi thông tin người dùng' , 4 , @user_id_did );", new object[] {Ticket.Ticket_id, DateTime.Now, User_admin_id });
                    MessageBox.Show("Cập nhật thành công");
                    this.Parent.Controls.Remove(this);
                }
                else
                {
                    MessageBox.Show("Căn cước công dân đã tồn tại");
                }
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            }
        }
    }
}
