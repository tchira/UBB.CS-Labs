using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenMAP_C
{
    interface IRepository
    {
        List<Transaction> getAll();
        void addObject(Transaction t);
    }
}
