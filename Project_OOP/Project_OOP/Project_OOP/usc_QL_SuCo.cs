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
    public partial class usc_QL_SuCo : UserControl
    {
        public usc_QL_SuCo(string user_id = null)
        {
            InitializeComponent();
            if (user_id != null)
            {
                guna2Button1.Visible = true;
                User_id = user_id;
            }
        }
        private string user_id;

        public string User_id { get => user_id; set => user_id = value; }

        private void btnThemSuCo_Click(object sender, EventArgs e)
        {
            string transaction_id = guna2TextBox6.Text;
            if (transaction_id == "")
            {
                MessageBox.Show("Vui lòng nhập mã sự cố");
            }
            else
            {
                DataRow row = ZoneDAO.Instance.Tim_SuCo(transaction_id);
                if (row != null)
                {
                    guna2TextBox9.Text = System.Text.RegularExpressions.Regex.Split(row["level_name"].ToString(), @"([^\d]+)")[1];
                    guna2TextBox8.Text = System.Text.RegularExpressions.Regex.Split(row["level_name"].ToString(), @"([^\d]+)")[2];
                    guna2TextBox1.Text = row["ticket_id"].ToString();
                    guna2TextBox4.Text = row["name"].ToString();
                    guna2TextBox10.Text = row["vehicle_name"].ToString();
                    guna2TextBox2.Text = row["vehicle_id"].ToString();
                    guna2TextBox3.Text = row["renueve"].ToString();
                    guna2DateTimePicker2.Value = (DateTime)row["transaction_time"];
                    guna2TextBox7.Text = row["user_id_did"].ToString();
                    guna2TextBox5.Text = row["description"].ToString();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sự cố");
                }
            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            usc_ThemSuCo f = new usc_ThemSuCo(User_id);
            this.Controls.Add(f);
            f.Dock = DockStyle.Fill;
            f.BringToFront();
        }
    }
}
