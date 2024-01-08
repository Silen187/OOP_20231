﻿using Project_OOP.DTO;
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
    public partial class fNhanVien : Form
    {

        private InfoDTO loginAccount;

        public InfoDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }
        public fNhanVien(InfoDTO acc)
        {
            InitializeComponent();
            LoginAccount = acc;
            label1.Text = "Xin chào - Nhân viên " + acc.Name1;
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {

        }
        bool menuExpand1 = false;
        private void menuHTTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand1 == false)
            {
                menuHeThong.Height += 10;
                if (menuHeThong.Height >= 140)
                {
                    menuHTTransition.Stop();
                    menuExpand1 = true;
                }
            }
            else
            {
                menuHeThong.Height -= 10;
                if (menuHeThong.Height <= 35)
                {
                    menuHTTransition.Stop();
                    menuExpand1 = false;
                }
            }
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {

        }
        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                if (sidebarExpand)
                {
                    sidebar.Width -= 10;
                    if (sidebar.Width <= 55)
                    {
                        sidebarExpand = false;
                        sidebarTransition.Stop();
                    }

                }

            }
            else
            {
                sidebar.Width += 10;
                if (sidebar.Width >= 230)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        private void btnHeThong_Click_1(object sender, EventArgs e)
        {
            menuHTTransition.Start();
        }
        bool menuExpand4 = false;
        private void guna2Button14_Click(object sender, EventArgs e)
        {
            menuTKTransition.Start();
        }

        private void menuTKTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand4 == false)
            {
                menuThongKe.Height += 10;
                if (menuThongKe.Height >= 70)
                {
                    menuTKTransition.Stop();
                    menuExpand4 = true;
                }
            }
            else
            {
                menuThongKe.Height -= 10;
                if (menuThongKe.Height <= 35)
                {
                    menuTKTransition.Stop();
                    menuExpand4 = false;
                }
            }
        }

        private void btnThongTinTK_Click(object sender, EventArgs e)
        {
            usc_HT_ThongTin_Tk f = new usc_HT_ThongTin_Tk(loginAccount);
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            usc_HT_DoiMK f = new usc_HT_DoiMK(loginAccount);
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            usc_LichSuNhanLuong f = new usc_LichSuNhanLuong(int.Parse(loginAccount.ID1));
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            usc_ThongTinVe f = new usc_ThongTinVe(int.Parse(loginAccount.ID1));
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            usc_XemToanBoVe f = new usc_XemToanBoVe();
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            usc_DM_NhaXe f = new usc_DM_NhaXe();
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            usc_QL_SuCo f = new usc_QL_SuCo();
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo);

            // Kiểm tra kết quả từ MessageBox
            if (result == DialogResult.Yes)
            {
                // Nếu người dùng chọn Yes, hiển thị UserControl usc_DM_NhanVien
                this.Close();
            }
        }
    }
}
