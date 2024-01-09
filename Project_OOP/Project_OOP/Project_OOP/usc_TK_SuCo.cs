﻿using Guna.UI2.WinForms;
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
            DateTime start = guna2DateTimePicker2.Value;
            DateTime end = guna2DateTimePicker1.Value;
            if(guna2TextBox13.Text == "")
            {
                guna2Button2.Visible = true;
                DataTable dt = AccountDAO.Instance.Get_AllSuCo(start, end);
                Data = dt;
                dataGridView1.DataSource = dt;
                string totalCompensation = ((dt.AsEnumerable().Sum(row => row.Field<int>("Thiệt hại")))/1000000).ToString();
                string totalissue = dt.Rows.Count.ToString();
                guna2TextBox4.Text = totalCompensation + " Triệu";
                guna2TextBox1.Text = totalissue;
            }
            else
            {
                guna2Button2.Visible=false;
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string start_date = guna2DateTimePicker2.Text;
            string end_date = guna2DateTimePicker1.Text;
            string suco_string = "Thống kê sự cố từ " + start_date + " đến " + end_date;

            Excel_Export.Instance.ExportSuCo(Data, "Báo cáo sự cố", suco_string);
            DataProvider.Instance.ExecuteQuery("INSERT INTO reports (start_date, end_date, admin_id, report_description) VALUES ( @start_date , @end_date , @admin_id , N'" + suco_string + "');", new object[] { start_date, end_date, Admin_id });
        }
    }
}
