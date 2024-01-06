using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP.DTO
{
    public class EmployeeInfoDTO
    {
        private string employee_id;
        private string employee_name;
        private string ticket_id;
        private string level_name;
        private DateTime register_date;
        private string SDT;
        private string salary_level;
        private string STK;
        private string bank;
        private string CCCD;
        public EmployeeInfoDTO(string employee_id, string employee_name, string ticket_id, string level_name, DateTime register_date, string SDT, string salary_level, string STK, string bank, string CCCD) 
        { 
            this.employee_id = employee_id;
            this.employee_name = employee_name;
            this.ticket_id = ticket_id;
            this.level_name = level_name;
            this.register_date = register_date;
            this.SDT = SDT;
            this.STK = STK;
            this.salary_level = salary_level;
            this.bank = bank;
            this.CCCD = CCCD;
        }
        public EmployeeInfoDTO(DataRow row)
        {
            this.employee_id = row["employee_id"].ToString();
            this.employee_name = row["name"].ToString();
            this.ticket_id = row["ticket_id"].ToString();
            this.level_name= row["level_area"].ToString();
            this.register_date = (DateTime)row["Birth"];
            this.SDT = row["contact_number"].ToString();
            this.STK = row["STK"].ToString();
            this.salary_level = row["salary_level"].ToString();
            this.bank = row["Bank"].ToString();
            this.CCCD = row["CCCD"].ToString();
        }

        public string Employee_id { get => employee_id; set => employee_id = value; }
        public string Employee_name { get => employee_name; set => employee_name = value; }
        public string Ticket_id { get => ticket_id; set => ticket_id = value; }
        public string Level_name { get => level_name; set => level_name = value; }
        public DateTime Register_date { get => register_date; set => register_date = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public string Salary_level { get => salary_level; set => salary_level = value; }
        public string STK1 { get => STK; set => STK = value; }
        public string Bank { get => bank; set => bank = value; }
        public string CCCD1 { get => CCCD; set => CCCD = value; }
    }
}
