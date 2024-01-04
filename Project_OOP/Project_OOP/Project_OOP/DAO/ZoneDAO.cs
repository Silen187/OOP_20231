using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP.DAO
{
    public class ZoneDAO
    {
        private static ZoneDAO instance;

        public static ZoneDAO Instance
        {
            get { if (instance == null) instance = new ZoneDAO(); return instance; }
            private set { instance = value; }
        }

        private ZoneDAO() { }

        public int count_empty_slot(string zone_name)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SELECT COUNT(*) AS SoLuong FROM ticket_pass WHERE slot_id LIKE @zonename", new object[] { zone_name });
            return int.Parse(result.Rows[0]["SoLuong"].ToString());
        }
        public DataRow Get_Search_Vehicle_ID(string vehicle_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SEARCH_VEHICLE_BY_ID @vehicle_id", new object[] { vehicle_id });
            if (result.Rows.Count > 0)
            {
                return result.Rows[0];
            }
            return null;
        }
        public DataRow Get_Search_Ticket_ID(string ticket_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SEARCH_VEHICLE_BY_TICKET @ticket_id", new object[] { ticket_id });
            if (result.Rows.Count > 0)
            {
                return result.Rows[0];
            }
            return null;
        }
        public DataRow Get_Search_All(string ticket_id, string vehicle_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SEARCH_VEHICLE_BY_ID_AND_TICKET @vehicle_id , @ticket_id", new object[] { vehicle_id, ticket_id });
            if (result.Rows.Count > 0)
            {
                return result.Rows[0];
            }
            return null;
        }
        public DataTable Get_Count_Vehicle(string level_name)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("COUNT_VEHICLE @level_name", new object[] { level_name });
            return result;
        }
    }
}
