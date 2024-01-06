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
        public usc_DM_NhanVien()
        {
            InitializeComponent();
        }

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
            comboBox3.DataSource = list_level_name;
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

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string name = comboBox1.Text;
            string employee_id = comboBox2.Text;
            string level_name = comboBox3.Text;
            Show_Employee(int.Parse(employee_id));
        }

        private void comboBox3_SelectedValueChanged(object sender, EventArgs e)
        {
            flowLayoutPanel2.Controls.Clear();
            ComboBox cb = sender as ComboBox;
            string level_name = cb.Text;
            List<EmployeeInfoDTO> employee_list = AccountDAO.Instance.GetEmployeeInFoByLevel(level_name);
            comboBox1.DataSource = employee_list;
            comboBox1.DisplayMember = "employee_name";
            comboBox2.DataSource = employee_list;
            comboBox2.DisplayMember = "employee_id";
            foreach (EmployeeInfoDTO item in employee_list)
            {
                Button btn = new Button() { Width = 375, Height = 47 };
                btn.Text = "Mã nhân viên: " + item.Employee_id + " | Mã vé: " + item.Ticket_id;
                btn.Click += btn_Click;
                btn.Tag = item;
                btn.BackColor = Color.DarkViolet;

                flowLayoutPanel2.Controls.Add(btn);
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
            guna2TextBox9.Text = info.Employee_id.ToString();
            guna2TextBox12.Text = info.Employee_name.ToString();
            guna2TextBox6.Text = info.Ticket_id.ToString();
            guna2DateTimePicker1.Value = info.Register_date;
            guna2TextBox8.Text = info.SDT1.ToString();
            guna2TextBox4.Text = info.Salary_level.ToString();
            guna2TextBox1.Text = info.STK1.ToString();
            guna2TextBox14.Text = info.Bank.ToString();
            guna2TextBox15.Text = info.CCCD1.ToString();
        }
    }
}
