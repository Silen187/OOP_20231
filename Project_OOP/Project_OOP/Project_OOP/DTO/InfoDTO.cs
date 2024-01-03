using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP.DTO
{
    public class InfoDTO
    {
        public InfoDTO(string id, string name, DateTime Birth, string age, string City, string SDT, string sex, string CCCD, string role_name)
        {
            this.ID = id;
            this.Name = name;
            this.Birth = Birth;
            this.Age = age;
            this.City = City;
            this.SDT = SDT;
            this.sex = sex;
            this.CCCD = CCCD;
            this.role_name = role_name;
        }

        public InfoDTO(DataRow row)
        {
            this.ID = row["Mã_người_dùng"].ToString();
            this.Name = row["Tên"].ToString();
            this.Birth = (DateTime)row["Ngày_sinh"];
            this.Age = row["Tuổi"].ToString();
            this.City = row["Thành_phố"].ToString();
            this.SDT = row["SDT"].ToString();
            this.sex = row["Giới_tính"].ToString();
            this.CCCD = row["CCCD"].ToString();
            this.role_name = row["Mã_chức_vụ"].ToString();
        }

        public string ID1 { get => ID; set => ID = value; }
        public string Name1 { get => Name; set => Name = value; }
        public DateTime Birth1 { get => Birth; set => Birth = value; }
        public string Age { get => age; set => age = value; }
        public string City1 { get => City; set => City = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public string Sex { get => sex; set => sex = value; }
        public string CCCD1 { get => CCCD; set => CCCD = value; }
        public string Role_name { get => role_name; set => role_name = value; }

        private string ID;
        private string Name;
        private DateTime Birth;
        private string age;
        private string City;
        private string SDT;
        private string sex;
        private string CCCD;
        private string role_name;
    }
}
