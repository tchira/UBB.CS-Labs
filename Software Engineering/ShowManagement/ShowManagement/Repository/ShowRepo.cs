using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowManagement.Model;

namespace ShowManagement.Repository
{
    public class ShowRepo
    {
        public List<Show> shows { get; set; }

        public ShowRepo()
        {
            shows = new List<Show>();
        }

        public List<Show> getShows()
        {

            return this.shows;
        }
    }
}
