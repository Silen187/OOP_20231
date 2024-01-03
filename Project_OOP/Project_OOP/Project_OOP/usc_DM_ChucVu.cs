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
    public partial class usc_DM_ChucVu : UserControl
    {
        public usc_DM_ChucVu()
        {
            InitializeComponent();
        }

        private void btnThemCV_Click(object sender, EventArgs e)
        {
            // Tạo một hộp thoại MessageBox
            usc_DM_ThemChucVu a = new usc_DM_ThemChucVu();
            // Thêm User Control vào Form chứa nó
            this.Controls.Add(a);
            // Đặt vị trí và kích thước cho User Control
            a.Dock = DockStyle.Fill;
            // Hiển thị User Control lên trước cùng
            a.BringToFront();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
