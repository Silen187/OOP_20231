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
using OfficeOpenXml;
using Guna.UI2.WinForms;
using Project_OOP.DTO;

namespace Project_OOP
{
    public partial class usc_TK_DoanhThuNgay : UserControl
    {
        public usc_TK_DoanhThuNgay(int user_admin_id)
        {
            InitializeComponent();
            Admin_id = AccountDAO.Instance.GetAdmin_ID_By_UserID(user_admin_id);
        }
        private DataTable data;
        private int admin_id;

        public DataTable Data { get => data; set => data = value; }
        public int Admin_id { get => admin_id; set => admin_id = value; }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime ngay = DateTime_Start.Value;
            DateTime startOfDay = ngay.Date;
            DateTime endOfDay = startOfDay.AddDays(1).AddMilliseconds(-1);
           
            DataTable result = ZoneDAO.Instance.GetHistoryByDay(startOfDay, endOfDay);
            Data = result;
            dgv_TongHopVaoRa.DataSource = result;

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
            tb_TongDoanhThu.Text = totalRenueve.ToString();
            tb_DoanhThuVeMotLan.Text = totalRenueveForOnceTimeTicket.ToString();
            tb_DoanhThuVeThuong.Text = totalRenueveForCustomerTicket.ToString();

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

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string start_date = DateTime_Start.Text;
            string doanhthu_string = "Thống kê doanh thu ngày " + start_date;
            Excel_Export.Instance.ExportDoanhThu(data, "Báo cáo doanh thu ngày", doanhthu_string);
            DataProvider.Instance.ExecuteQuery("INSERT INTO reports (start_date, end_date, admin_id, report_description) VALUES ( @start_date , @end_date , @admin_id , N'" + doanhthu_string + "');", new object[] { start_date, start_date, Admin_id });
        }
    }
}
