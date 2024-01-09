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
    public partial class usc_LichSuChinhSua : UserControl
    {
        public usc_LichSuChinhSua(int user_admin_id)
        {
            InitializeComponent();
            User_admin_id1 = user_admin_id;
        }
        private int User_admin_id;

        public int User_admin_id1 { get => User_admin_id; set => User_admin_id = value; }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb_admin_id.Text == "")
                {
                    DataTable dt = AccountDAO.Instance.transaction(User_admin_id1);
                    dgv_ThongKeTacDong.DataSource = dt;
                }
                else
                {
                    int user_admin_ID = int.Parse(tb_admin_id.Text);
                    DataTable dt = AccountDAO.Instance.transaction(user_admin_ID);
                    dgv_ThongKeTacDong.DataSource = dt;
                }
            }
            catch 
            {
                MessageBox.Show("Đã có lỗi xảy ra");
            }
        }
    }
}
