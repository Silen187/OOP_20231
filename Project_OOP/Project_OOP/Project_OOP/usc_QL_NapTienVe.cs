using Project_OOP.DAO;
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
    public partial class usc_QL_NapTienVe : UserControl
    {
        public usc_QL_NapTienVe(string ticket_id, string name, string type_card)
        {
            InitializeComponent();
            this.ticket_id = ticket_id;
            this.name = name;
            this.type_card = type_card;
        }
        private string ticket_id;
        private string name;
        private string type_card;

        public string Ticket_id { get => ticket_id; set => ticket_id = value; }
        public string Name1 { get => name; set => name = value; }
        public string Type_card { get => type_card; set => type_card = value; }


        private void usc_QL_NapTienVe_Load(object sender, EventArgs e)
        {
            guna2TextBox4.Text = ticket_id;
            guna2TextBox4.Text = name;
            guna2TextBox3.Text = type_card;
        }

        private void btnDangKyVeXe_Click(object sender, EventArgs e)
        {
            try
            {
                int money = int.Parse(comboBox4.Text);
                AccountDAO.Instance.UpdateTicketMoney(Ticket_id, money);
                MessageBox.Show("Nạp tiền thành công");
                this.Parent.Controls.Remove(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);

            // Kiểm tra kết quả từ MessageBox
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, hiển thị UserControl usc_DM_NhanVien
                this.Parent.Controls.Remove(this);
            }
        }
    }
}
