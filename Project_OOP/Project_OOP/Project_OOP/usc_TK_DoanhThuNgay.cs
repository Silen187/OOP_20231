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
            DateTime ngay = guna2DateTimePicker2.Value;
            DateTime startOfDay = ngay.Date;
            DateTime endOfDay = startOfDay.AddDays(1).AddMilliseconds(-1);
           
            DataTable result = ZoneDAO.Instance.GetHistoryByDay(startOfDay, endOfDay);
            Data = result;
            dataGridView1.DataSource = result;

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
            guna2TextBox4.Text = totalRenueve.ToString();
            guna2TextBox1.Text = totalRenueveForOnceTimeTicket.ToString();
            guna2TextBox2.Text = totalRenueveForCustomerTicket.ToString();

            guna2TextBox3.Text = totalrowCountWithCar.ToString();
            guna2TextBox7.Text = totalrowCountWithBike.ToString();
            guna2TextBox10.Text = totalrowCountWithBicycle.ToString();

            guna2TextBox5.Text = totalrowCountWithCarOnce.ToString();
            guna2TextBox8.Text = totalrowCountWithBikeOnce.ToString();
            guna2TextBox11.Text = totalrowCountWithBicycleCustomer.ToString();

            guna2TextBox6.Text = totalrowCountWithCarCustomer.ToString();
            guna2TextBox9.Text = totalrowCountWithBikeCustomer.ToString();
            guna2TextBox12.Text = totalrowCountWithBicycleCustomer.ToString();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            string start_date = guna2DateTimePicker2.Text;
            string doanhthu_string = "Thống kê doanh thu ngày " + start_date;
            Excel_Export.Instance.ExportDoanhThu(data, "Báo cáo doanh thu ngày", doanhthu_string);
            DataProvider.Instance.ExecuteQuery("INSERT INTO reports (start_date, end_date, admin_id, report_description) VALUES ( @start_date , @end_date , @admin_id , N'" + doanhthu_string + "');", new object[] { start_date, start_date, Admin_id });
        }
    }
}
