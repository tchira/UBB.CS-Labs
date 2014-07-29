using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenMAP_C
{
    class Transaction
    {
        public CommSp item;
        public int month, year;

        public Transaction(CommSp item, int year, int month)
        {
            this.item = item;
            this.year = year;
            this.month = month;
        }

        public override string ToString()
        {
            return item.ToString() + "," + year + "," + month;
        }
    }
}
