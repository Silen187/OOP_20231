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
                btn_Add.Visible = true;
                User_id = user_id;
            }
        }
        private string user_id;

        public string User_id { get => user_id; set => user_id = value; }

        private void btnThemSuCo_Click(object sender, EventArgs e)
        {
            string transaction_id = tb_MaSuCo.Text;
            if (transaction_id == "")
            {
                MessageBox.Show("Vui lòng nhập mã sự cố");
            }
            else
            {
                DataRow row = ZoneDAO.Instance.Tim_SuCo(transaction_id);
                if (row != null)
                {
                    tb_KhuVuc.Text = System.Text.RegularExpressions.Regex.Split(row["level_name"].ToString(), @"([^\d]+)")[1];
                    tb_Tang.Text = System.Text.RegularExpressions.Regex.Split(row["level_name"].ToString(), @"([^\d]+)")[2];
                    tb_MaVe.Text = row["ticket_id"].ToString();
                    tb_ChuVe.Text = row["name"].ToString();
                    tb_LoaiXe.Text = row["vehicle_name"].ToString();
                    tb_BienSoXe.Text = row["vehicle_id"].ToString();
                    tb_ThietHai.Text = row["renueve"].ToString();
                    DateTime_SuCo.Value = (DateTime)row["transaction_time"];
                    tb_MaQuanLy.Text = row["user_id_did"].ToString();
                    tb_MoTaSuCo.Text = row["description"].ToString();
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

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void usc_QL_SuCo_Load(object sender, EventArgs e)
        {

        }
    }
}
