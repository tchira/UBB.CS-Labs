using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowManagement.Model;

namespace ShowManagement.Repository
{
    public class TicketRepo
    {
        public List<Ticket> tickets { get; set; }

        public TicketRepo()
        {
            tickets = new List<Ticket>();
        }


        public List<Ticket> getTickets()
        {
            
            return this.tickets;
        }

    }
}
