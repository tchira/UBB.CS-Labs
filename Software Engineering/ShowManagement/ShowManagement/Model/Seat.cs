using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManagement.Model
{
    class Seat
    {
        public int number{get;set;}
        public int row{get;set;}
        public int price { get; set; }

        public Seat(int n, int r, int p)
        {
            this.number = n;
            this.row = r;
            this.price = p;
        }
    }
}
