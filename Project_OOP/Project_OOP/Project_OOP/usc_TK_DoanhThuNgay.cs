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
    public partial class usc_TK_DoanhThuNgay : UserControl
    {
        public usc_TK_DoanhThuNgay()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DateTime ngay = guna2DateTimePicker2.Value;
            DateTime startOfDay = ngay.Date;
            DateTime endOfDay = startOfDay.AddDays(1).AddMilliseconds(-1);
           
            DataTable result = ZoneDAO.Instance.GetHistoryByDay(startOfDay, endOfDay);
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
    }
}
