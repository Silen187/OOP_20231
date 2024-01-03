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
    public partial class usc_DM_NhaXe : UserControl
    {
        public usc_DM_NhaXe()
        {
            InitializeComponent();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {

        }

        private void btnThemNX_Click(object sender, EventArgs e)
        {
            usc_DM_ThemNhaXe a = new usc_DM_ThemNhaXe();
            // Thêm User Control vào Form chứa nó
            this.Controls.Add(a);
            // Đặt vị trí và kích thước cho User Control
            a.Dock = DockStyle.Fill;
            // Hiển thị User Control lên trước cùng
            a.BringToFront();
        }
    }
}
