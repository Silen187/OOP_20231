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
    public partial class usc_QL_DangKyVeXe : UserControl
    {
        public usc_QL_DangKyVeXe()
        {
            InitializeComponent();
        }

        private void btnDangKyVeXe_Click(object sender, EventArgs e)
        {
            // Tạo một hộp thoại MessageBox
            DialogResult result = MessageBox.Show("Bạn có muốn đăng ký vé xe không?", "Xác nhận", MessageBoxButtons.YesNoCancel);

            // Kiểm tra kết quả từ MessageBox
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, hiển thị UserControl usc_DM_NhanVien
                usc_QL_VeXe b = new usc_QL_VeXe();
                this.Controls.Add(b);
                b.Dock = DockStyle.Fill;
                b.BringToFront();
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNoCancel);

            // Kiểm tra kết quả từ MessageBox
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, hiển thị UserControl usc_DM_NhanVien
                usc_QL_VeXe b = new usc_QL_VeXe();
                this.Controls.Add(b);
                b.Dock = DockStyle.Fill;
                b.BringToFront();
            }
        }
    }
}
