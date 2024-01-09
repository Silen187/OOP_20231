using Guna.UI2.WinForms;
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
        private void ResetOtherButtonFillColors(Guna.UI2.WinForms.Guna2Button currentButton)
        {
            // Danh sách các tên nút cần bỏ qua
            List<string> excludedButtonNames = new List<string> { "btnHeThong", "guna2Button14", "guna2Button8" };

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
        private void btnHeThong_Click(object sender, EventArgs e)
        {

        }
        bool menuExpand1 = false;
        private void menuHTTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand1 == false)
            {
                menuHeThong.Height += 10;
                if (menuHeThong.Height >= 175)
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
            btnThongTinTK.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnThongTinTK);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
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

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            usc_LichSuNhanLuong f = new usc_LichSuNhanLuong(int.Parse(loginAccount.ID1));
            btnLichSuNhanLuong.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnLichSuNhanLuong);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            usc_ThongTinVe f = new usc_ThongTinVe(int.Parse(loginAccount.ID1));
            btnXemVe.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnXemVe);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            usc_XemToanBoVe f = new usc_XemToanBoVe(int.Parse(loginAccount.ID1));
            btnXemToanBoVe.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnXemToanBoVe);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            usc_DM_NhaXe f = new usc_DM_NhaXe();
            btnXemHamDeXe.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnXemHamDeXe);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            usc_QL_SuCo f = new usc_QL_SuCo();
            btnXemSuCo.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnXemSuCo);
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

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
        bool menuExpand3=false;
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
    }
}
