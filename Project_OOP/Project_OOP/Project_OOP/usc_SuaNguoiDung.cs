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
        public usc_SuaNguoiDung(TicketInfoDTO ticket, InfoDTO account)
        {
            InitializeComponent();
            Load_info(ticket, account);
            Old_pass = account.Password;
            Old_CCCD = account.CCCD1;
        }
        private string old_pass;
        private string old_CCCD;
        public string Old_pass { get => old_pass; set => old_pass = value; }
        public string Old_CCCD { get => old_CCCD; set => old_CCCD = value; }

        private void usc_SuaNguoiDung_Load(object sender, EventArgs e)
        {
            comboBox5.DataSource = AccountDAO.Instance.GetBank();
        }
        void Load_info(TicketInfoDTO ticket, InfoDTO account) 
        {
            guna2DateTimePicker1.Value = account.Birth1;
            guna2TextBox9.Text = account.ID1;
            guna2TextBox12.Text = account.Name1;
            comboBox1.Text = account.City1;
            guna2TextBox4.Text = account.SDT1;
            guna2TextBox1.Text = account.STK1;
            guna2TextBox6.Text = account.Username;
            guna2TextBox15.Text = account.Password;
            comboBox2.Text = account.Sex;
            guna2TextBox19.Text = account.CCCD1;
            comboBox5.Text = account.Bank1;
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
                if (guna2TextBox19.Text == Old_CCCD || AccountDAO.Instance.CHECK_TRUNGLAP_CCCD(guna2TextBox19.Text) == false)
                {
                    int user_id = int.Parse(guna2TextBox9.Text);
                    string username = guna2TextBox6.Text;
                    string name = guna2TextBox12.Text;
                    string city = comboBox1.Text;
                    string SDT = guna2TextBox4.Text;
                    string STK = guna2TextBox1.Text;
                    string password = guna2TextBox15.Text;
                    string CCCD = guna2TextBox19.Text;
                    string Bank = comboBox5.Text;
                    string sex = comboBox2.Text;
                    DateTime birth = guna2DateTimePicker1.Value;
                    AccountDAO.Instance.UpdateAccount(user_id, name, sex, city, SDT, CCCD, birth, STK, Bank);
                    AccountDAO.Instance.UpdatePassWordAccount(username, Old_pass, password);
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
