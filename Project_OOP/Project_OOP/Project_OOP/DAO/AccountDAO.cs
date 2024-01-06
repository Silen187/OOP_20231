using Project_OOP.DAO;
using Project_OOP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_OOP.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public int Login(string userName, string passWord)
        {
            string query = "USP_Login @userName , @passWord";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, passWord });

            if (result.Rows.Count > 0)
            {
                int userId = Convert.ToInt32(result.Rows[0]["user_id"]);
                return userId;
            }
            else
            {
                return -1;
            }
        }
        public int permission(int user_id)
        {
            string query = "SELECT * FROM dbo.info WHERE user_id = " + user_id.ToString();
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            if (result.Rows.Count > 0)
            {
                int userId = Convert.ToInt32(result.Rows[0]["role_id"]);
                return userId;
            }
            else
            {
                return -1;
            }
        }

        public DataTable info(int user_id)
        {
            string query = "SELECT * FROM dbo.info WHERE user_id = " + user_id.ToString();
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public InfoDTO GetAccountByUserID(int userID)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("USP_INFO " + userID);

            foreach (DataRow item in data.Rows)
            {
                return new InfoDTO(item);
            }
            return null;

        }
        public bool UpdateAccount(int user_id, string displayName, string sex, string city, string SDT, string CCCD, DateTime Birth)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Change_Info @userID , @Birth , @displayName , @sex , @city , @SDT , @CCCD", new object[] { user_id, Birth, displayName, sex, city, SDT, CCCD });

            return result > 0;
        }

        public bool UpdatePassWordAccount(string username, string old_password, string new_password)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("USP_UpdatePassword @userName , @oldpassword , @newpassword", new object[] { username, old_password, new_password });
            return result > 0;
        }
        public bool input_password_change(int user_id, string password)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("USP_INPUTPASSWORDCHECK @user_id , @password", new object[] { user_id, password });
            return result.Rows.Count > 0;
        }

        public DataTable History_Money(int user_id, DateTime start_date, DateTime end_date)
        {

            DataTable result = DataProvider.Instance.ExecuteQuery("USP_HistoryMoney @user_id , @start_date , @end_date", new object[] {user_id , start_date, end_date});
            return result;
            
        }
        public DataTable History_Entry(int user_id, DateTime start_date, DateTime end_date)
        {

            DataTable result = DataProvider.Instance.ExecuteQuery("USP_HistoryEntry @user_id , @start_date , @end_date", new object[] { user_id, start_date, end_date });
            return result;

        }

        public DataTable Salary_Pass(int user_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("USP_SALARYPASS @userid", new object[] { user_id });
            return result;
        }

        public TicketInfoDTO GetTicketInfoByUserID(int user_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("VIEW_TICKET_INFO @userid", new object[] { user_id });
            return new TicketInfoDTO(result.Rows[0]);
        }

        public List<TicketInfoDTO> LoadTicketList(List<int> userid_list)
        {
            List<TicketInfoDTO> TicketList = new List<TicketInfoDTO>();
            foreach(int user_id in userid_list)
            {
                DataTable ticket_table = DataProvider.Instance.ExecuteQuery("VIEW_TICKET_INFO @userid", new object[] {user_id});
                TicketInfoDTO ticket = new TicketInfoDTO(ticket_table.Rows[0]);
                TicketList.Add(ticket);
            }
            return TicketList;
        }

        public bool CHECK_TRUNGLAP_USERNAME(string username)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("CHECK_TRUNGLAP_USERNAME @username", new object[] { username });
            if (result.Rows.Count > 0)
            { return true; }
            return false;
        }

        public bool CHECK_TRUNGLAP_TICKET(string ticket_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SELECT * FROM monthly_subscription WHERE ticket_id = '" + ticket_id + "'");
            if (result.Rows.Count > 0)
            { return true; }
            return false;
        }

        public void ADD_ADMIN(string username, string password, string name, DateTime Birth, string sex, string city, string contact_number, DateTime register_date, string salary_level, string STK, string Bank, string CCCD)
        {
            int Age = DateTime.Now.Year - Birth.Year;
            DataTable result = DataProvider.Instance.ExecuteQuery("ADD_USER @username , @password", new object[] { username, password });
            int user_id = int.Parse(result.Rows[0]["user_id"].ToString());
            DataTable result2 = DataProvider.Instance.ExecuteQuery("ADD_ADMIN @user_id , @start_date , @salary_level", new object[] { user_id, register_date, int.Parse(salary_level) });
            DataTable result3 = DataProvider.Instance.ExecuteQuery("ADD_INFO @user_id , @name , @Birth , @Age , @City , @contact_number , @role_id , @sex , @CCCD , @STK , @Bank", new object[] {user_id, name, Birth, Age, city, contact_number, 3, sex, CCCD, STK, Bank});
        }

        public void ADD_EMPLOYEE(string username, string password, string name, DateTime Birth, string sex, string city, string contact_number, DateTime register_date, string salary_level, string STK, string Bank, string CCCD, string level_name, string ticket_id)
        {
            int Age = DateTime.Now.Year - Birth.Year;
            DataTable result = DataProvider.Instance.ExecuteQuery("ADD_USER @username , @password", new object[] { username, password });
            int user_id = int.Parse(result.Rows[0]["user_id"].ToString());
            DataTable result2 = DataProvider.Instance.ExecuteQuery("ADD_EMPLOYEE @user_id , @start_date , @salary_level , @level_name", new object[] { user_id, register_date, int.Parse(salary_level), level_name });
            DataTable result3 = DataProvider.Instance.ExecuteQuery("ADD_INFO @user_id , @name , @Birth , @Age , @City , @contact_number , @role_id , @sex , @CCCD , @STK , @Bank", new object[] { user_id, name, Birth, Age, city, contact_number, 2, sex, CCCD, STK, Bank });
            DataTable result4 = DataProvider.Instance.ExecuteQuery("ADD_TICKET_EMPLOYEE_CUSTOMER @user_id , @ticket_id , @type_card", new object[] { user_id, ticket_id, 1 });
        }
        public void ADD_CUSTOMER(string username, string password, string name, DateTime Birth, string sex, string city, string contact_number, DateTime register_date, string STK, string Bank, string CCCD, string ticket_id)
        {
            int Age = DateTime.Now.Year - Birth.Year;
            DataTable result = DataProvider.Instance.ExecuteQuery("ADD_USER @username , @password", new object[] { username, password });
            int user_id = int.Parse(result.Rows[0]["user_id"].ToString());
            DataTable result2 = DataProvider.Instance.ExecuteQuery("ADD_CUSTOMER @user_id , @start_date", new object[] { user_id, register_date});
            DataTable result3 = DataProvider.Instance.ExecuteQuery("ADD_INFO @user_id , @name , @Birth , @Age , @City , @contact_number , @role_id , @sex , @CCCD , @STK , @Bank", new object[] { user_id, name, Birth, Age, city, contact_number, 1, sex, CCCD, STK, Bank });
            DataTable result4 = DataProvider.Instance.ExecuteQuery("ADD_TICKET_EMPLOYEE_CUSTOMER @user_id , @ticket_id , @type_card", new object[] { user_id, ticket_id, 3 });
        }
        public bool CHECK_TRUNGLAP_CCCD(string CCCD)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SELECT * FROM info WHERE CCCD = '" + CCCD + "'");
            if (result.Rows.Count > 0)
            { return true; }
            return false;
        }
    }
}

