using Guna.UI2.WinForms;
using Project_OOP.DAO;
using Project_OOP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Project_OOP
{
    public partial class usc_HT_ThongTin_Tk : UserControl
    {
        private InfoDTO loginAccount;

        public InfoDTO LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount); }
        }

        void ChangeAccount(InfoDTO acc)
        {
            tb_MaNguoiDung.Text = acc.ID1;
            tb_HoVaTen.Text = acc.Name1;
            DateTime_NgaySinh.Value = (DateTime)acc.Birth1;
            if (acc.Sex == "female")
            {
                cb_Sex.Text = "Nữ";
            }
            else if (acc.Sex == "male")
            {
                cb_Sex.Text = "Nam";
            }
            else
            {
                cb_Sex.Text = "Khác";
            }
            cb_City.Text = acc.City1;
            tb_SDT.Text = acc.SDT1;
            cb_MaChucVu.Text = acc.Role_name;
            if (acc.Role_name == "admin")
            {
                cb_ChucVu.Text = "Quản lý";
            }
            else if (acc.Role_name == "employee")
            {
                cb_ChucVu.Text = "Nhân viên";
            }
            else if (acc.Role_name == "customer")
            {
                cb_ChucVu.Text = "Người dùng";
            }
            tb_CCCD.Text = acc.CCCD1;
            tb_STK.Text = acc.STK1;
        }
        public usc_HT_ThongTin_Tk(InfoDTO acc)
        {
            InitializeComponent();
            LoginAccount = acc;
            this.user_id = int.Parse(acc.ID1);
        }
        void UpdateAccountInfo(string role_name)
        {
            DateTime Birth = DateTime_NgaySinh.Value;
            string displayName = tb_HoVaTen.Text;
            string sex = cb_Sex.Text;
            string city = cb_City.Text;
            string SDT = tb_SDT.Text;
            string CCCD = tb_CCCD.Text;
            string STK = tb_STK.Text;
            string Bank = cb_Bank.Text;
            fXacNhan f = new fXacNhan(role_name, this.user_id, displayName, sex, city, SDT, CCCD, Birth, STK, Bank);
            f.ShowDialog();
        }
        private int user_id;
        public int User_id { get => user_id; set => user_id = value; }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void usc_HT_ThongTin_Tk_Load(object sender, EventArgs e)
        {
            cb_Bank.DataSource = AccountDAO.Instance.GetBank();
            cb_Bank.Text = loginAccount.Bank1;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo(loginAccount.Role_name);
            Application.Restart();
        }


    }
}
