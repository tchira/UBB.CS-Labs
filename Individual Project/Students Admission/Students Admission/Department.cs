using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Admission
{
    public class Department
    {
        public int id{get;set;}
        public int places { get; set; }
        public String name { get; set; }

        public Department()
        {

        }

        public Department(int id, String name, int places)
        {
            this.id = id;
            this.name = name;
            this.places = places;
        }

        

        public override string ToString()
        {
            String str = this.id + ":" + this.name + ":" + this.places;
            return str;
        }

    }
}
