using Project_OOP.DAO;
using Project_OOP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP.DAO
{
    public class InfoDAO
    {
        private static InfoDAO instance;

        public static InfoDAO Instance
        {
            get { if (instance == null) instance = new InfoDAO(); return InfoDAO.instance; }
            private set { InfoDAO.instance = value; }
        }

        private InfoDAO() { }

        public InfoDTO LoadTableList(int user_id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_INFO " + user_id);

            InfoDTO table = new InfoDTO(data.Rows[0]);
            return table;
        }
    }
}
