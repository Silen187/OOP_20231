﻿using Project_OOP.DAO;
using Project_OOP.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
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
    }
}

