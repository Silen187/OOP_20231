using Project_OOP.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_OOP
{
    public partial class fXacNhan : Form
    {
        public fXacNhan(int user_id, string displayName, string sex, string city, string SDT, string CCCD, DateTime Birth, string STK, string Bank)
        {
            InitializeComponent();
            User_id = user_id;
            DisplayName = displayName;
            Sex = sex;
            City = city;
            SDT1 = SDT;
            CCCD1 = CCCD;
            Birth1 = Birth;
            STK1 = STK;
            Bank1 = Bank;
        }
        private string STK;
        private string Bank;
        private string displayName;
        private int user_id;
        private string sex;
        private string city;
        private string SDT;
        private DateTime Birth;
        private string CCCD;
        public int User_id { get => user_id; set => user_id = value; }
        public string DisplayName { get => displayName; set => displayName = value; }
        public string Sex { get => sex; set => sex = value; }
        public string City { get => city; set => city = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public DateTime Birth1 { get => Birth; set => Birth = value; }
        public string CCCD1 { get => CCCD; set => CCCD = value; }
        public string STK1 { get => STK; set => STK = value; }
        public string Bank1 { get => Bank; set => Bank = value; }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string input_password = guna2TextBox2.Text;
            if (AccountDAO.Instance.input_password_change(user_id, input_password) == true)
            {
                if (AccountDAO.Instance.UpdateAccount(user_id, displayName, sex, city, SDT, CCCD, Birth, STK, Bank) == true)
                {
                    MessageBox.Show("Cập nhật thành công");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai mật khẩu");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fXacNhan_Load(object sender, EventArgs e)
        {

        }
    }
}
