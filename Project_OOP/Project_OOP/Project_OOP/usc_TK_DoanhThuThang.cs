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
using System.Windows.Markup;

namespace Project_OOP
{
    public partial class usc_TK_DoanhThuThang : UserControl
    {
        public usc_TK_DoanhThuThang(int user_admin_id)
        {
            InitializeComponent();
            User_admin_id = user_admin_id;
        }
        private DataTable dt;
        private int user_admin_id;

        public DataTable Dt { get => dt; set => dt = value; }
        public int User_admin_id { get => user_admin_id; set => user_admin_id = value; }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime ngay_bat_dau = DateTime_Start.Value;
            DateTime ngay_ket_thuc = DateTime_End.Value;
            DateTime start_Day = ngay_bat_dau.Date;
            DateTime end_Day = ngay_ket_thuc.Date;
            
            DataTable result = ZoneDAO.Instance.GetHistoryByDay(start_Day, end_Day);
            Dt = result;

            dgv_TongHopVaoRaThang.DataSource = result;

            int totalRenueveForOnceTimeTicket = result.AsEnumerable()
            .Where(row => row.Field<string>("Loại vé") == "Vé dùng một lần")
            .Sum(row => row.Field<int>("Số tiền"));

            int totalRenueveForCustomerTicket = result.AsEnumerable()
            .Where(row => row.Field<string>("Loại vé") == "Vé tháng" || row.Field<string>("Loại vé") == "Vé khách hàng")
            .Sum(row => row.Field<int>("Số tiền"));

            int totalrowCountWithCar = result.Select("[Loại xe] = 'Car'").Length;
            int totalrowCountWithBike = result.Select("[Loại xe] = 'Bike'").Length;
            int totalrowCountWithBicycle = result.Select("[Loại xe] = 'Bicycle'").Length;

            int totalrowCountWithCarOnce = result.Select("[Loại xe] = 'Car' AND [Loại vé] = 'Vé dùng một lần'").Length;
            int totalrowCountWithBikeOnce = result.Select("[Loại xe] = 'Bike' AND [Loại vé] = 'Vé dùng một lần'").Length;
            int totalrowCountWithBicycleOnce = result.Select("[Loại xe] = 'Bicycle' AND [Loại vé] = 'Vé dùng một lần'").Length;

            int totalrowCountWithCarCustomer = result.Select("[Loại xe] = 'Car' AND ([Loại vé] = 'Vé tháng' OR [Loại vé] = 'Vé khách hàng')").Length;
            int totalrowCountWithBikeCustomer = result.Select("[Loại xe] = 'Bike' AND ([Loại vé] = 'Vé tháng' OR [Loại vé] = 'Vé khách hàng')").Length;
            int totalrowCountWithBicycleCustomer = result.Select("[Loại xe] = 'Bicycle' AND ([Loại vé] = 'Vé tháng' OR [Loại vé] = 'Vé khách hàng')").Length;

            int totalRenueve = result.AsEnumerable().Sum(row => row.Field<int>("Số tiền"));
            tb_DoanhThu_all.Text = totalRenueve.ToString();
            tb_DoanhThu_once.Text = totalRenueveForOnceTimeTicket.ToString();
            tb_DoanhThu.Text = totalRenueveForCustomerTicket.ToString();

            tb_car_all.Text = totalrowCountWithCar.ToString();
            tb_bike_all.Text = totalrowCountWithBike.ToString();
            tb_bicycle_all.Text = totalrowCountWithBicycle.ToString();

            tb_car_once.Text = totalrowCountWithCarOnce.ToString();
            tb_bike_once.Text = totalrowCountWithBikeOnce.ToString();
            tb_bicycle_once.Text = totalrowCountWithBicycleCustomer.ToString();

            tb_car.Text = totalrowCountWithCarCustomer.ToString();
            tb_bike.Text = totalrowCountWithBikeCustomer.ToString();
            tb_bicycle.Text = totalrowCountWithBicycleCustomer.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string start_date = DateTime_Start.Text;
            string end_date = DateTime_End.Text;
            DataTable data = Dt;
            int admin_id = AccountDAO.Instance.GetAdmin_ID_By_UserID(User_admin_id);
            string doanhthu_string = "Thống kê doanh thu từ " + start_date + " đến " + end_date;

            Excel_Export.Instance.ExportDoanhThu(data, "Báo cáo doanh thu", doanhthu_string);
            DataProvider.Instance.ExecuteQuery("INSERT INTO reports (start_date, end_date, admin_id, report_description) VALUES ( @start_date , @end_date , @admin_id , N'" + doanhthu_string + "');", new object[] { start_date, end_date, admin_id });
        }
    }
}
