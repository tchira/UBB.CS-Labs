using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenMAP_C
{
    class Repository:IRepository
    {
        public List<Transaction> repo;

        public Repository(){
            repo = new List<Transaction>();
        }

        public List<Transaction> getAll()
        {
            List<Transaction> copy = new List<Transaction>(repo);
            return copy;

            
        }

        public void addObject(Transaction cs)
        {
            this.repo.Add(cs);
        }

        
    }
}
