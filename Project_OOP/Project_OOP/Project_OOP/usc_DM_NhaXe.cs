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
    public partial class usc_DM_NhaXe : UserControl
    {
        public usc_DM_NhaXe()
        {
            InitializeComponent();
            Load_Zone();   
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kryptonColorButton1_SelectedColorChanged(object sender, ComponentFactory.Krypton.Toolkit.ColorEventArgs e)
        {

        }
        void Load_Zone()
        {
            int khuA = ZoneDAO.Instance.count_empty_slot("A%");
            int khuB = ZoneDAO.Instance.count_empty_slot("B%");
            int khuC = ZoneDAO.Instance.count_empty_slot("C%");
            int khuD = ZoneDAO.Instance.count_empty_slot("D%");
            guna2Button1.Text = "Khu A - Đang sử dụng " + khuA + "/3600";
            guna2Button2.Text = "Khu B - Đang sử dụng " + khuB + "/3600";
            guna2Button3.Text = "Khu C - Đang sử dụng " + khuC + "/3600";
            guna2Button4.Text = "Khu D - Đang sử dụng " + khuD + "/3600";
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            string level_name = guna2Button8.Text.Split(' ')[1];
            DataTable data = ZoneDAO.Instance.Get_Count_Vehicle(level_name);
            Fill_Car_Bike(data);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            int khuA1 = ZoneDAO.Instance.count_empty_slot("A1%");
            int khuA2 = ZoneDAO.Instance.count_empty_slot("A2%");
            int khuA3 = ZoneDAO.Instance.count_empty_slot("A3%");
            int khuA4 = ZoneDAO.Instance.count_empty_slot("A4%");
            int khuA5 = ZoneDAO.Instance.count_empty_slot("A5%");
            guna2Button7.Text = "Tầng A1 - " + khuA1 + "/750";
            guna2Button9.Text = "Tầng A2 - " + khuA2 + "/750";
            guna2Button8.Text = "Tầng A3 - " + khuA3 + "/750";
            guna2Button10.Text = "Tầng A4 - " + khuA4 + "/750";
            guna2Button11.Text = "Tầng A5 - " + khuA5 + "/750";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            int khuB1 = ZoneDAO.Instance.count_empty_slot("B1%");
            int khuB2 = ZoneDAO.Instance.count_empty_slot("B2%");
            int khuB3 = ZoneDAO.Instance.count_empty_slot("B3%");
            int khuB4 = ZoneDAO.Instance.count_empty_slot("B4%");
            int khuB5 = ZoneDAO.Instance.count_empty_slot("B5%");
            guna2Button7.Text = "Tầng B1 - " + khuB1 + "/750";
            guna2Button9.Text = "Tầng B2 - " + khuB2 + "/750";
            guna2Button8.Text = "Tầng B3 - " + khuB3 + "/750";
            guna2Button10.Text = "Tầng B4 - " + khuB4 + "/750";
            guna2Button11.Text = "Tầng B5 - " + khuB5 + "/750";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int khuC1 = ZoneDAO.Instance.count_empty_slot("C1%");
            int khuC2 = ZoneDAO.Instance.count_empty_slot("C2%");
            int khuC3 = ZoneDAO.Instance.count_empty_slot("C3%");
            int khuC4 = ZoneDAO.Instance.count_empty_slot("C4%");
            int khuC5 = ZoneDAO.Instance.count_empty_slot("C5%");
            guna2Button7.Text = "Tầng C1 - " + khuC1 + "/750";
            guna2Button9.Text = "Tầng C2 - " + khuC2 + "/750";
            guna2Button8.Text = "Tầng C3 - " + khuC3 + "/750";
            guna2Button10.Text = "Tầng C4 - " + khuC4 + "/750";
            guna2Button11.Text = "Tầng C5 - " + khuC5 + "/750";
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            int khuD1 = ZoneDAO.Instance.count_empty_slot("D1%");
            int khuD2 = ZoneDAO.Instance.count_empty_slot("D2%");
            int khuD3 = ZoneDAO.Instance.count_empty_slot("D3%");
            int khuD4 = ZoneDAO.Instance.count_empty_slot("D4%");
            int khuD5 = ZoneDAO.Instance.count_empty_slot("D5%");
            guna2Button7.Text = "Tầng D1 - " + khuD1 + "/750";
            guna2Button9.Text = "Tầng D2 - " + khuD2 + "/750";
            guna2Button8.Text = "Tầng D3 - " + khuD3 + "/750";
            guna2Button10.Text = "Tầng D4 - " + khuD4 + "/750";
            guna2Button11.Text = "Tầng D5 - " + khuD5 + "/750";
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            string ticket_id = guna2TextBox2.Text;
            string vehicle_id = guna2TextBox1.Text;
            if ((vehicle_id == "Nhập biển số xe" && ticket_id == "Nhập vé xe")||(vehicle_id == "" && ticket_id == ""))
            {
                MessageBox.Show("Vui lòng nhập giá trị tìm kiếm");
            }
            else if (ticket_id == "" || ticket_id == "Nhập vé xe")
            {
                try
                {
                    Load_Info_By_Search_vehicle_id(vehicle_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
                }
            }
            else if (vehicle_id == "" || vehicle_id == "Nhập biển số xe")
            {
                try
                {
                    Load_Info_By_Search_ticket_id(ticket_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    Load_Info_By_Search_All(ticket_id, vehicle_id);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã có lỗi xảy ra: " + ex.Message);
                }
            }
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            string level_name = guna2Button7.Text.Split(' ')[1];
            DataTable data = ZoneDAO.Instance.Get_Count_Vehicle(level_name);
            Fill_Car_Bike(data);
        }
        void Fill_Car_Bike(DataTable data)
        {
            guna2Button13.Text = "Số xe đạp: " + data.Rows[0]["SoLuong"].ToString();
            guna2Button12.Text = "Số xe máy: " +data.Rows[1]["SoLuong"].ToString();
            guna2Button6.Text = "Số ô tô: " +data.Rows[2]["SoLuong"].ToString();
        }
        void Load_Info_By_Search_vehicle_id(string vehicle_id)
        {
            DataRow row = ZoneDAO.Instance.Get_Search_Vehicle_ID(vehicle_id);
            Fill_panel(row);
        }
        void Load_Info_By_Search_ticket_id(string ticket_id)
        {
            DataRow row = ZoneDAO.Instance.Get_Search_Ticket_ID(ticket_id);
            Fill_panel(row);
        }
        void Load_Info_By_Search_All(string ticket_id, string vehicle_id)
        {
            DataRow row = ZoneDAO.Instance.Get_Search_All(ticket_id, vehicle_id);
            Fill_panel(row);
        }
        void Fill_panel(DataRow row)
        {
            guna2TextBox3.Text = row["vehicle_id"].ToString();
            guna2TextBox6.Text = row["ticket_id"].ToString();
            guna2TextBox4.Text = row["slot_id"].ToString();
            guna2TextBox5.Text = row["vehicle_name"].ToString();
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            string level_name = guna2Button9.Text.Split(' ')[1];
            DataTable data = ZoneDAO.Instance.Get_Count_Vehicle(level_name);
            Fill_Car_Bike(data);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            string level_name = guna2Button10.Text.Split(' ')[1];
            DataTable data = ZoneDAO.Instance.Get_Count_Vehicle(level_name);
            Fill_Car_Bike(data);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            string level_name = guna2Button11.Text.Split(' ')[1];
            DataTable data = ZoneDAO.Instance.Get_Count_Vehicle(level_name);
            Fill_Car_Bike(data);
        }

        private void usc_DM_NhaXe_Load(object sender, EventArgs e)
        {

        }
    }
}
