using Guna.UI2.WinForms;
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
    public partial class usc_TK_SuCo : UserControl
    {
        public usc_TK_SuCo(int user_admin_id)
        {
            InitializeComponent();
            Admin_id = AccountDAO.Instance.GetAdmin_ID_By_UserID(user_admin_id);
        }
        private DataTable data;
        private int admin_id;

        public DataTable Data { get => data; set => data = value; }
        public int Admin_id { get => admin_id; set => admin_id = value; }

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
            DateTime start = DateTime_Start.Value;
            DateTime end = DateTime_End.Value;
            if(tb_admin_id.Text == "")
            {
                btn_SinhBaoCao.Visible = true;
                DataTable dt = AccountDAO.Instance.Get_AllSuCo(start, end);
                Data = dt;
                dgv_ThongKeSuCo.DataSource = dt;
                string totalCompensation = ((dt.AsEnumerable().Sum(row => row.Field<int>("Thiệt hại")))/1000000).ToString();
                string totalissue = dt.Rows.Count.ToString();
                tb_total_compensation.Text = totalCompensation + " Triệu";
                tb_SoLuong.Text = totalissue;
            }
            else
            {
                btn_SinhBaoCao.Visible=false;
                try
                {
                    int user_admin_id = int.Parse(tb_admin_id.Text);
                    DataTable dt = AccountDAO.Instance.Get_AllSuCo_UserID( start, end, user_admin_id);
                    dgv_ThongKeSuCo.DataSource = dt;
                    string totalCompensation = ((dt.AsEnumerable().Sum(row => row.Field<int>("Thiệt hại"))) / 1000000).ToString();
                    string totalissue = dt.Rows.Count.ToString();
                    tb_total_compensation.Text = totalCompensation + " Triệu";
                    tb_SoLuong.Text = totalissue;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra " + ex.Message);
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string start_date = DateTime_Start.Text;
            string end_date = DateTime_End.Text;
            string suco_string = "Thống kê sự cố từ " + start_date + " đến " + end_date;

            Excel_Export.Instance.ExportSuCo(Data, "Báo cáo sự cố", suco_string);
            DataProvider.Instance.ExecuteQuery("INSERT INTO reports (start_date, end_date, admin_id, report_description) VALUES ( @start_date , @end_date , @admin_id , N'" + suco_string + "');", new object[] { start_date, end_date, Admin_id });
        }
    }
}
