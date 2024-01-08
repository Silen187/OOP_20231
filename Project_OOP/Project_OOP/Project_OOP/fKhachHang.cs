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
            LoginAccount = acc;
            label1.Text = "Xin chào - Khách hàng " + acc.Name1;
        }

        private void ResetOtherButtonFillColors(Guna.UI2.WinForms.Guna2Button currentButton)
        {
            // Danh sách các tên nút cần bỏ qua
            List<string> excludedButtonNames = new List<string> { "btnHeThong", "guna2Button14" };

            foreach (Control ctrl in flowLayoutPanel1.Controls)
            {
                if (ctrl is FlowLayoutPanel panel)
                {
                    foreach (Control innerCtrl in panel.Controls)
                    {
                        if (innerCtrl is Guna.UI2.WinForms.Guna2Button button && button != currentButton)
                        {
                            // Kiểm tra tên của nút và chỉ thay đổi màu fill nếu không phải là các nút cần bỏ qua
                            if (!excludedButtonNames.Contains(button.Name))
                            {
                                button.FillColor = Color.DimGray;
                            }
                        }
                    }
                }
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
                    if (sidebar.Width <= 105)
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
            btnThongTinTK.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnThongTinTK);
            info.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(info);
            info.BringToFront();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            usc_HT_DoiMK f = new usc_HT_DoiMK(loginAccount);
            btnDoiMK.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnDoiMK);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            usc_LichSuNapTien f = new usc_LichSuNapTien(int.Parse(loginAccount.ID1));
            guna2Button15.FillColor = Color.Red;
            ResetOtherButtonFillColors(guna2Button15);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            usc_LichSuRaVao f = new usc_LichSuRaVao(int.Parse(loginAccount.ID1));
            guna2Button11.FillColor = Color.Red;
            ResetOtherButtonFillColors(guna2Button11);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
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
