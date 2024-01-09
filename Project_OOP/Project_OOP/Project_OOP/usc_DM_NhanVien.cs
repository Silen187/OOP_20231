using Project_OOP.DAO;
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
    public partial class usc_DM_NhanVien : UserControl
    {
        public usc_DM_NhanVien(string user_admin_id)
        {
            InitializeComponent();
            User_admin_id = int.Parse(user_admin_id);
        }
        private string user_id;
        private int user_admin_id;
        public string User_id { get => user_id; set => user_id = value; }
        public int User_admin_id { get => user_admin_id; set => user_admin_id = value; }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void usc_DM_NhanvVien_Load(object sender, EventArgs e)
        {
            Get_level_name();

        }
        void Get_level_name()
        {
            List<string> list_level_name = new List<string>();
            list_level_name = ZoneDAO.Instance.level_name_list();
            cb_levelname.DataSource = list_level_name;
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            /*usc_DM_ThemNhanVien a = new usc_DM_ThemNhanVien();
            // Thêm User Control vào Form chứa nó
            this.Controls.Add(a);
            // Đặt vị trí và kích thước cho User Control
            a.Dock = DockStyle.Fill;
            // Hiển thị User Control lên trước cùng
            a.BringToFront();*/
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                usc_SuaNhanVien f = new usc_SuaNhanVien(tb_MaNhanVien.Text, tb_ticketid.Text, User_admin_id);
                this.Controls.Add(f);
                f.Dock = DockStyle.Fill;
                f.BringToFront();
            }
            catch
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            };

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                string name = cb_HoTen.Text;
                string employee_id = cb_MaNhanVien.Text;
                string level_name = cb_levelname.Text;
                Show_Employee(int.Parse(employee_id));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra " + ex.Message);
            }
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            flp_DanhSachNhanVien.Controls.Clear();
            ComboBox cb = sender as ComboBox;
            string level_name = cb.Text;
            List<EmployeeInfoDTO> employee_list = AccountDAO.Instance.GetEmployeeInFoByLevel(level_name);
            cb_HoTen.DataSource = employee_list;
            cb_HoTen.DisplayMember = "employee_name";
            cb_MaNhanVien.DataSource = employee_list;
            cb_MaNhanVien.DisplayMember = "employee_id";
            foreach (EmployeeInfoDTO item in employee_list)
            {
                Button btn = new Button() { Width = 375, Height = 47 };
                btn.Text = "Mã nhân viên: " + item.Employee_id + " | Mã vé: " + item.Ticket_id;
                btn.Click += btn_Click;
                btn.Tag = item;
                btn.BackColor = Color.DarkViolet;

                flp_DanhSachNhanVien.Controls.Add(btn);
            }
        }
        void btn_Click(object sender, EventArgs e)
        {
            int employee_id = int.Parse(((sender as Button).Tag as EmployeeInfoDTO).Employee_id);
            Show_Employee(employee_id);
        }
        void Show_Employee(int employee_id)
        {
            EmployeeInfoDTO info = AccountDAO.Instance.GetEmployeeInFoByEmployeeID(employee_id);
            tb_MaNhanVien.Text = info.Employee_id.ToString();
            tb_TenNhanVien.Text = info.Employee_name.ToString();
            tb_ticketid.Text = info.Ticket_id.ToString();
            DateTime_NgayBatDau.Value = info.Register_date;
            tb_SDT.Text = info.SDT1.ToString();
            tb_salary_level.Text = info.Salary_level.ToString();
            tb_STK.Text = info.STK1.ToString();
            tb_Bank.Text = info.Bank.ToString();
            tb_CCCD.Text = info.CCCD1.ToString();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa nhân viên này ?", "Xác nhận", MessageBoxButtons.YesNo);

            // Kiểm tra kết quả từ MessageBox
            if (result == DialogResult.Yes)
            {
                try
                {
                    string ticket_id = tb_ticketid.Text;
                    User_id = DataProvider.Instance.ExecuteQuery("SELECT user_id AS uid FROM employees WHERE employee_id = " + tb_MaNhanVien.Text).Rows[0]["uid"].ToString();
                    // Nếu người dùng chọn Yes, hiển thị UserControl usc_DM_NhanVien
                    AccountDAO.Instance.DeleteEmployee(User_id);
                    DataProvider.Instance.ExecuteQuery("INSERT INTO transactions(ticket_id, transaction_time, description, type, user_id_did) VALUES( @ticket_id , @transaction_time , N'Xóa nhân viên', 4 , @user_id_did );", new object[] {ticket_id, DateTime.Now, User_admin_id});
                    MessageBox.Show("Xóa thành công");
                }
                // Nếu người dùng chọn Yes, hiển thị UserControl usc_DM_NhanVien
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra " + ex.Message);
                }
            }
        }
    }
}
