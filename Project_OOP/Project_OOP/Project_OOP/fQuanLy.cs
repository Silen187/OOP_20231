using Project_OOP.DTO;
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
    public partial class fQuanLy : Form
    {

        private InfoDTO loginAccount;

        public InfoDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }
        public fQuanLy(InfoDTO acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            label1.Text = "Xin chào - Quản lý " + acc.Name1;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            menuHTTransition.Start();
            
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            usc_HT_DoiMK f = new usc_HT_DoiMK(loginAccount);
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        bool menuExpand1 = false;
        private void menuHTTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand1 == false)
            {
               menuHeThong.Height += 10;
                if(menuHeThong.Height >= 175)
                {
                    menuHTTransition.Stop();
                    menuExpand1 = true;
                }
            }
            else
            {
                menuHeThong.Height -= 10;
                if(menuHeThong.Height <= 35)
                {
                    menuHTTransition.Stop();
                    menuExpand1 = false;
                }
            }
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            menuDMTransition.Start();
        }

        bool menuExpand2 = false;
        private void menuDMTransistion_Tick(object sender, EventArgs e)
        {
            if (menuExpand2 == false)
            {
                menuDanhMuc.Height += 10;
                if (menuDanhMuc.Height >= 175)
                {
                    menuDMTransition.Stop();
                    menuExpand2 = true;
                }
            }
            else
            {
                menuDanhMuc.Height -= 10;
                if (menuDanhMuc.Height <= 35)
                {
                    menuDMTransition.Stop();
                    menuExpand2 = false;
                }
            }
        }


        bool menuExpand3 = false;
        private void menuQLTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand3 == false)
            {
                menuQuanLy.Height += 10;
                if (menuQuanLy.Height >= 140)
                {
                    menuQLTransition.Stop();
                    menuExpand3 = true;
                }
            }
            else
            {
                menuQuanLy.Height -= 10;
                if (menuQuanLy.Height <= 35)
                {
                    menuQLTransition.Stop();
                    menuExpand3 = false;
                }
            }
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            menuQLTransition.Start();
        }


        bool menuExpand4 = false;
        private void menuTKTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand4 == false)
            {
                menuThongKe.Height += 10;
                if (menuThongKe.Height >= 175)
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

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            menuTKTransition.Start();
        }

        private void panelDesktop_Paint(object sender, PaintEventArgs e)
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
                    if(sidebar.Width <= 55)
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

        private void btnThongTinTK_Click(object sender, EventArgs e)
        {
            usc_HT_ThongTin_Tk f = new usc_HT_ThongTin_Tk(loginAccount);
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            usc_HT_DangKy f = new usc_HT_DangKy();
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            usc_DM_NhanVien f = new usc_DM_NhanVien();
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            usc_XemToanBoVe f = new usc_XemToanBoVe("3");
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

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            usc_DM_NguoiDung f = new usc_DM_NguoiDung();
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            usc_TK_DoanhThuNgay f = new usc_TK_DoanhThuNgay();
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            usc_TK_DoanhThuThang f = new usc_TK_DoanhThuThang();
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            usc_TK_LuongNhanVien f = new usc_TK_LuongNhanVien();
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }
    }
}
