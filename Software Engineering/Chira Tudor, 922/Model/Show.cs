using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManagement.Model
{
    public class Show
    {
        public int id { get; set; }
        public String name { get; set; }
        public DateTime date { get; set; }

        public Show(int id, String name, DateTime date)
        {
            this.id = id;
            this.name = name;
            this.date = date;
        }
    }
}
