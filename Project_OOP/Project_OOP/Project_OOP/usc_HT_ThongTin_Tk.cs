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
            guna2TextBox4.Text = acc.CCCD1;
        }
        public usc_HT_ThongTin_Tk(InfoDTO acc)
        {
            InitializeComponent();
            LoginAccount = acc;
            this.user_id = int.Parse(acc.ID1);
        }
        void UpdateAccountInfo()
        {
            DateTime Birth = guna2DateTimePicker1.Value;
            string displayName = guna2TextBox2.Text;
            string sex = comboBox1.Text;
            string city = comboBox2.Text;
            string SDT = guna2TextBox6.Text;
            string CCCD = guna2TextBox4.Text;
            if (AccountDAO.Instance.UpdateAccount(this.user_id, displayName, sex, city, SDT, CCCD, Birth) == true)
                MessageBox.Show("Cập nhật thành công");
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
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel11_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UpdateAccountInfo();
        }


    }
}
