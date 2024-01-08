using Project_OOP.DAO;
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
    public partial class usc_ThemSuCo : UserControl
    {
        public usc_ThemSuCo(string user_id)
        {
            InitializeComponent();
            guna2TextBox7.Text = user_id.ToString();
        }

        private void usc_ThemSuCo_Load(object sender, EventArgs e)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SELECT MAX(transaction_id) + 1 AS transaction_id FROM transactions");
            guna2TextBox6.Text = result.Rows[0]["transaction_id"].ToString();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string zone = comboBox2.Text;
            string level = comboBox3.Text;
            string ticket_id = guna2TextBox1.Text;
            string name = guna2TextBox4.Text;
            string vehicle = comboBox1.Text;
            string vehicle_id = guna2TextBox2.Text;
            string money = guna2TextBox3.Text;
            DateTime ngay = guna2DateTimePicker2.Value;
            string user_id_did = guna2TextBox7.Text;
            string description = guna2TextBox5.Text;
            try
            {
                AccountDAO.Instance.ADD_TRANSACTION_TYPE6(zone, level, ticket_id, name, vehicle, vehicle_id, money, ngay, user_id_did, description);
                MessageBox.Show("Thành công");
                this.Parent.Controls.Remove(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã có lỗi xảy ra " + ex.Message);
            }
        }
        private void guna2TextBox1_Leave(object sender, EventArgs e)
        {
            string ticket_id = guna2TextBox1.Text;
            DataTable result = DataProvider.Instance.ExecuteQuery("SELECT * FROM monthly_subscription LEFT JOIN info ON monthly_subscription.person_id = info.user_id WHERE ticket_id = '" + ticket_id + "'");
            guna2TextBox4.Text = result.Rows[0]["name"].ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
