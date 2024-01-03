﻿using System;
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
    public partial class usc_DM_ThemNhanVien : UserControl
    {
        public usc_DM_ThemNhanVien()
        {
            InitializeComponent();
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            // Tạo một hộp thoại MessageBox
            DialogResult result = MessageBox.Show("Bạn có muốn thêm nhân viên không?", "Xác nhận", MessageBoxButtons.YesNoCancel);

            // Kiểm tra kết quả từ MessageBox
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, hiển thị UserControl usc_DM_NhanVien
                usc_DM_NhanVien b = new usc_DM_NhanVien();
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
                usc_DM_NhanVien b = new usc_DM_NhanVien();
                this.Controls.Add(b);
                b.Dock = DockStyle.Fill;
                b.BringToFront();
            }
        }
    }
}