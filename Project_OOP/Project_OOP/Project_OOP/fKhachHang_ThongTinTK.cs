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
    public partial class fKhachHang_ThongTinTK : Form
    {
        private InfoDTO loginAccount;

        public InfoDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }
        public fKhachHang_ThongTinTK(InfoDTO acc)
        {
            InitializeComponent();
            LoginAccount = acc;
            label1.Text = "Xin chào - Khách hàng " + acc.Name1;
        }

        void ChangeAccount(InfoDTO acc)
        {
            guna2TextBox1.Text = acc.ID1;
            guna2TextBox2.Text = acc.Name1;
            guna2DateTimePicker1.Value = (DateTime)acc.Birth1;
            if (acc.Sex == "female")
            {
                comboBox1.Text = "Nữ";
            }
            else
            {
                comboBox1.Text = "Nam";
            }
            comboBox2.Text = acc.City1;
            guna2TextBox6.Text = acc.SDT1;
            comboBox3.Text = acc.Role_name;
            if (acc.Role_name == "admin")
            {
                comboBox4.Text = "Quản lý";
            }
            else if (acc.Role_name == "employee")
            {
                comboBox4.Text = "Nhân viên";
            }    
            else
            {
                comboBox4.Text = "Người dùng";
            }
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

        }

        private void fKhachHang_ThongTinTK_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
