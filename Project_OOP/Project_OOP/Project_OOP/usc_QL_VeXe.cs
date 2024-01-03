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
    public partial class usc_QL_VeXe : UserControl
    {
        public usc_QL_VeXe()
        {
            InitializeComponent();
        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnDangKyVeXe_Click(object sender, EventArgs e)
        {
            usc_QL_DangKyVeXe a = new usc_QL_DangKyVeXe();
            // Thêm User Control vào Form chứa nó
            this.Controls.Add(a);
            // Đặt vị trí và kích thước cho User Control
            a.Dock = DockStyle.Fill;
            // Hiển thị User Control lên trước cùng
            a.BringToFront();
        }
    }
}
