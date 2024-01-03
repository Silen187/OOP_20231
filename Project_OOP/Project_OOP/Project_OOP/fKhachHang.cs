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
    public partial class fKhachHang : Form
    {
        private InfoDTO loginAccount;

        public InfoDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; }
        }
        public fKhachHang(InfoDTO acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            label1.Text = "Xin chào - Khách hàng " + acc.Name1;
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

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            menuHTTransition.Start();
        }
        bool menuExpand4=false;
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

        private void btnThongTinTK_Click(object sender, EventArgs e)
        {
            Load_info();
        }
        void Load_info()
        {
            usc_HT_ThongTin_Tk info = new usc_HT_ThongTin_Tk(loginAccount);
            this.Controls.Add(info);
            info.Dock = DockStyle.Fill;
            info.BringToFront();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            usc_HT_DoiMK f = new usc_HT_DoiMK(loginAccount);
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }
    }
}
