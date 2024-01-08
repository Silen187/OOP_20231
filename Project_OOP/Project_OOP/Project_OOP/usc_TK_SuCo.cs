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
    public partial class usc_TK_SuCo : UserControl
    {
        public usc_TK_SuCo()
        {
            InitializeComponent();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {            

        }

        private void guna2TextBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            DateTime start = guna2DateTimePicker2.Value;
            DateTime end = guna2DateTimePicker1.Value;
            if(guna2TextBox13.Text == "")
            {
                DataTable dt = AccountDAO.Instance.Get_AllSuCo(start, end);
                dataGridView1.DataSource = dt;
                string totalCompensation = ((dt.AsEnumerable().Sum(row => row.Field<int>("Thiệt hại")))/1000000).ToString();
                string totalissue = dt.Rows.Count.ToString();
                guna2TextBox4.Text = totalCompensation + " Triệu";
                guna2TextBox1.Text = totalissue;
            }
            else
            {
                try
                {
                    int user_admin_id = int.Parse(guna2TextBox13.Text);
                    DataTable dt = AccountDAO.Instance.Get_AllSuCo_UserID( start, end, user_admin_id);
                    dataGridView1.DataSource = dt;
                    string totalCompensation = ((dt.AsEnumerable().Sum(row => row.Field<int>("Thiệt hại"))) / 1000000).ToString();
                    string totalissue = dt.Rows.Count.ToString();
                    guna2TextBox4.Text = totalCompensation + " Triệu";
                    guna2TextBox1.Text = totalissue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra " + ex.Message);
                }
            }
        }
    }
}
