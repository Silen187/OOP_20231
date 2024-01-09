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
            btnDoiMK.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnDoiMK);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
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
                if (menuQuanLy.Height >= 70)
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
            btnThongTinTK.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnThongTinTK);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }


        private void guna2Button11_Click(object sender, EventArgs e)
        {
            usc_HT_DangKy f = new usc_HT_DangKy();
            btnDangKyNguoiDung.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnDangKyNguoiDung);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            usc_DM_NhanVien f = new usc_DM_NhanVien(loginAccount.ID1);
            btnDanhSachNhanVien.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnDanhSachNhanVien);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            usc_XemToanBoVe f = new usc_XemToanBoVe( int.Parse(loginAccount.ID1), "3");
            btnDanhSachVeXe.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnDanhSachVeXe);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            usc_DM_NhaXe f = new usc_DM_NhaXe();
            btnDanhSachNhaXe.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnDanhSachNhaXe);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button6_Click_1(object sender, EventArgs e)
        {
            usc_DM_NguoiDung f = new usc_DM_NguoiDung(loginAccount.ID1);
            btnDanhSachNguoiDung.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnDanhSachNguoiDung);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            
        }
        private void ResetOtherButtonFillColors(Guna.UI2.WinForms.Guna2Button currentButton)
        {
            // Danh sách các tên nút cần bỏ qua
            List<string> excludedButtonNames = new List<string> { "btnDanhMuc", "btnHeThong", "btnQuanLy", "btnThongKe" };

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

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            usc_TK_DoanhThuNgay f = new usc_TK_DoanhThuNgay(int.Parse(loginAccount.ID1));
            btn_TK_DoanhThuNgay.FillColor = Color.Red;
            ResetOtherButtonFillColors(btn_TK_DoanhThuNgay);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            usc_TK_DoanhThuThang f = new usc_TK_DoanhThuThang(int.Parse(loginAccount.ID1));
            btn_TK_DoanhThuThang.FillColor = Color.Red;
            ResetOtherButtonFillColors(btn_TK_DoanhThuThang);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            usc_TK_LuongNhanVien f = new usc_TK_LuongNhanVien(int.Parse(loginAccount.ID1));
            btn_ThongKe_LuongNhanVien.FillColor = Color.Red;
            ResetOtherButtonFillColors(btn_ThongKe_LuongNhanVien);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            usc_QL_SuCo f = new usc_QL_SuCo(loginAccount.ID1.ToString());
            btnQuanLySuCo.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnQuanLySuCo);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {
            usc_TK_SuCo f = new usc_TK_SuCo(int.Parse(loginAccount.ID1));
            btn_TK_SuCo.FillColor = Color.Red;
            ResetOtherButtonFillColors(btn_TK_SuCo);
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

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fQuanLy_Load(object sender, EventArgs e)
        {

        }

        private void pnlMain_SizeChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button15_MouseClick(object sender, MouseEventArgs e)
        {
            btn_TK_DoanhThuNgay.FillColor = Color.White;
        }

        private void btnHeThong_MouseClick(object sender, MouseEventArgs e)
        {
            btnHeThong.FillColor = Color.White;
        }

        private void btnHeThong_MouseLeave(object sender, EventArgs e)
        {
            btnHeThong.FillColor = Color.Black;
        }

        private void guna2Button17_MouseClick(object sender, MouseEventArgs e)
        {
            btn_ThongKe_LuongNhanVien.FillColor = Color.Red;
        }

        private void guna2Button17_MouseLeave(object sender, EventArgs e)
        {
            btn_ThongKe_LuongNhanVien.FillColor = Color.DimGray;
        }

        private void btnLichSuChinhSua_Click(object sender, EventArgs e)
        {
            usc_LichSuChinhSua f = new usc_LichSuChinhSua(int.Parse(loginAccount.ID1));
            btnLichSuChinhSua.FillColor = Color.Red;
            ResetOtherButtonFillColors(btnLichSuChinhSua);
            f.Dock = DockStyle.Fill;
            this.pnlMain.Controls.Add(f);
            f.BringToFront();
        }
    }
}
