using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManagement.Model
{
    public class Ticket
    {
        public int client { get; set; }
        public int seat { get; set; }
        public int show { get; set; }
        public DateTime date { get; set; }
        public Boolean confirmed { get; set; }

        public Ticket(int client,int seat, int show,DateTime date,Boolean confirmed){
            this.client=client;
            this.seat=seat;
            this.show=show;
            this.date=date;
            this.confirmed=confirmed;
        }

        public override string ToString()
        {
            return client + " " + seat + " " + show;
        }
    }
}
