using Guna.UI2.WinForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
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
        public bool UpdateAccount(int user_id, string displayName, string sex, string city, string SDT, string CCCD, DateTime Birth, string STK, string Bank)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("exec USP_Change_Info @userID , @Birth , @displayName , @sex , @city , @SDT , @CCCD , @STK , @Bank", new object[] { user_id, Birth, displayName, sex, city, SDT, CCCD, STK, Bank });

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

            DataTable result = DataProvider.Instance.ExecuteQuery("USP_HistoryMoney @user_id , @start_date , @end_date", new object[] { user_id, start_date, end_date });
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
            if (result.Rows.Count > 0)
            {
                return new TicketInfoDTO(result.Rows[0]);
            }
            return null;
        }

        public List<TicketInfoDTO> LoadTicketList(List<int> userid_list)
        {
            List<TicketInfoDTO> TicketList = new List<TicketInfoDTO>();
            foreach (int user_id in userid_list)
            {
                DataTable ticket_table = DataProvider.Instance.ExecuteQuery("VIEW_TICKET_INFO @userid", new object[] { user_id });
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
            DataTable result3 = DataProvider.Instance.ExecuteQuery("ADD_INFO @user_id , @name , @Birth , @Age , @City , @contact_number , @role_id , @sex , @CCCD , @STK , @Bank", new object[] { user_id, name, Birth, Age, city, contact_number, 3, sex, CCCD, STK, Bank });
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
            DataTable result2 = DataProvider.Instance.ExecuteQuery("ADD_CUSTOMER @user_id , @start_date", new object[] { user_id, register_date });
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
        public List<string> GetBank()
        {
            List<string> Bank = new List<string>();
            DataTable result = DataProvider.Instance.ExecuteQuery("SELECT DISTINCT(Bank) FROM info");
            foreach (DataRow row in result.Rows)
            {
                Bank.Add(row["Bank"].ToString());
            }
            return Bank;
        }

        internal List<EmployeeInfoDTO> GetEmployeeInFoByLevel(string level_name)
        {
            List<EmployeeInfoDTO> employee_info = new List<EmployeeInfoDTO>();
            DataTable result = DataProvider.Instance.ExecuteQuery("SELECT * FROM employees LEFT JOIN info on employees.user_id = info.user_id LEFT JOIN monthly_subscription ON employees.user_id = monthly_subscription.person_id WHERE level_area = '" + level_name + "'");
            foreach (DataRow row in result.Rows)
            {
                EmployeeInfoDTO employee_dto = new EmployeeInfoDTO(row);
                employee_info.Add(employee_dto);
            }
            return employee_info;
        }
        public EmployeeInfoDTO GetEmployeeInFoByEmployeeID(int employee_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SELECT * FROM employees LEFT JOIN info on employees.user_id = info.user_id LEFT JOIN monthly_subscription ON employees.user_id = monthly_subscription.person_id WHERE employee_id ='" + employee_id + "'");
            EmployeeInfoDTO employee_dto = new EmployeeInfoDTO(result.Rows[0]);
            return employee_dto;
        }
        public void UpdateEmployeeByEmployeeID(string employee_id, string name, string SDT, string salary_level, string STK, string Bank, string CCCD, string level_name, string password)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("UPDATE_EMPLOYEE_users @employee_id , @password", new object[] { int.Parse(employee_id), password });
            DataTable result2 = DataProvider.Instance.ExecuteQuery("UPDATE employees SET level_area = @levelname , salary_level = @salarylevel WHERE employee_id = @employeeid", new object[] { level_name, salary_level, int.Parse(employee_id) });
            DataTable result3 = DataProvider.Instance.ExecuteQuery("UPDATE_EMPLOYEE_INFO @employee_id , @name , @SDT , @STK , @bank , @CCCD", new object[] { int.Parse(employee_id), name, SDT, STK, Bank, CCCD });
        }
        public void DeleteEmployee(object user_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("DELETE FROM employees WHERE user_id = " + user_id);
            DataTable result4 = DataProvider.Instance.ExecuteQuery("DELETE FROM salary_pass WHERE user_id = " + user_id);
            DataTable result3 = DataProvider.Instance.ExecuteQuery("DELETE FROM info WHERE user_id = " + user_id);
            DataTable result5 = DataProvider.Instance.ExecuteQuery("DELETE FROM monthly_subscription WHERE person_id = " + user_id);
            DataTable result2 = DataProvider.Instance.ExecuteQuery("DELETE FROM users WHERE user_id = " + user_id);
        }
        public void UpdateTicketMoney(string ticket_id, int money)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("UPDATE monthly_subscription SET money = money + @money WHERE ticket_id = @ticketid", new object[] { money, ticket_id });
        }
        public void Delete_Customer(int user_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("DELETE FROM customers WHERE user_id = " + user_id);
            DataTable result2 = DataProvider.Instance.ExecuteQuery("DELETE FROM info WHERE user_id = " + user_id);
            DataTable result5 = DataProvider.Instance.ExecuteQuery("DELETE FROM monthly_subscription WHERE person_id = " + user_id);
            DataTable result3 = DataProvider.Instance.ExecuteQuery("DELETE FROM users WHERE user_id = " + user_id);
        }
        public void UpdateTicket()
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("UPDATE monthly_subscription SET type_card = 3 , start_date = NULL , end_date = NULL WHERE type_card = 2 AND end_date < @now", new object[] { DateTime.Now });
        }
        public DataTable Get_AllSalaryByDate(DateTime start, DateTime end)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SEARCH_SALARY_DATE @start , @end", new object[] { start, end });
            return result;
        }
        public DataTable Get_AllSalaryByDate(DateTime start, DateTime end, int user_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SEARCH_SALARY_DATE @start , @end", new object[] { start, end });
            return result;
        }
        public DataTable Get_AllSalaryByDateUserID(DateTime start, DateTime end, int user_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("SEARCH_SALARY_DATEID @user_id , @start , @end", new object[] { user_id, start, end });
            return result;
        }
        public DataTable Get_AllSuCo(DateTime start, DateTime end)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("GET_ISSUEDATE @start , @end", new object[] { start, end });
            return result;
        }
        public DataTable Get_AllSuCo_UserID(DateTime start, DateTime end, int user_id)
        {
            DataTable result = DataProvider.Instance.ExecuteQuery("GET_ISSUEDATE_ID @user_id , @start , @end", new object[] { user_id, start, end });
            return result;
        }
        public void ADD_TRANSACTION_TYPE6(string zone, string level, string ticket_id, string name, string vehicle, string vehicle_id, string money, DateTime ngay, string user_id_did, string description)
        {
            string level_name = zone + level;
            int type_vehicle;
            if (vehicle == "Car")
            {
                type_vehicle = 1;
            }
            else if (vehicle == "Bike")
            {
                type_vehicle = 2;
            }
            else
            {
                type_vehicle = 3;
            }
            DataTable result = DataProvider.Instance.ExecuteQuery("insert into transactions(ticket_id, transaction_time, renueve, description, type, vehicle_id, type_vehicle, user_id_did, level_name) VALUES( @ticket_id , @ngay , @money , @description , 6 , @vehicle_id , @type_vehicle , @user_id_did , @level_name )", new object[] {ticket_id, ngay, int.Parse(money), description, vehicle_id, type_vehicle, int.Parse(user_id_did), level_name });
        }
    }
}

