using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP.DTO
{
    public class TicketInfoDTO
    {
        public TicketInfoDTO(string user_id, string name, string ticket_id, string start_date, string end_date, string money, string type_card)
        { 
            this.name = name;
            this.ticket_id = ticket_id;
            this.user_id = user_id;
            this.start_date = start_date;
            this.end_date = end_date;
            this.money = money;
            this.type_card = type_card;
        }
        public TicketInfoDTO(DataRow Row)
        {
            this.user_id = Row["person_id"].ToString();
            this.name = Row["name"].ToString();
            this.ticket_id = Row["ticket_id"].ToString();
            this.start_date = Row["start_date"].ToString();
            this.end_date = Row["end_date"].ToString();
            this.money = Row["money"].ToString();
            this.type_card= Row["type_card"].ToString();
        }

        private string user_id;
        private string name;
        private string ticket_id;
        private string start_date;
        private string end_date;
        private string money;
        private string type_card;

        public string Name { get => name; set => name = value; }
        public string Start_date { get => start_date; set => start_date = value; }
        public string End_date { get => end_date; set => end_date = value; }
        public string Ticket_id { get => ticket_id; set => ticket_id = value; }
        public string User_id { get => user_id; set => user_id = value; }
        public string Money { get => money; set => money = value; }
        public string Type_card { get => type_card; set => type_card = value; }
    }
}
