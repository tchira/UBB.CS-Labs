using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenMAP_C
{
    class Controller
    {
       public IRepository repo;
       public String[] zonelist = { "Z1", "Z2", "Z3", "Z4" };

        public Controller(IRepository repo)
        {
            this.repo = repo;
        }

        public List<Transaction> getAll()
        {
            return repo.getAll();
        }

        public void addObject(Transaction t)
        {
            this.repo.addObject(t);
        }

        public void readFromFile()
        {
            String line;
            String[] tokens;
            int length;
            int corrupted = 0;
            System.IO.StreamReader infile = new System.IO.StreamReader("transactions.txt");
            while ((line = infile.ReadLine()) != null)
            {
                tokens = line.Split(',');

                try
                {
                    switch (tokens[0])
                    {
                        case "House":
                            if (!zonelist.Contains(tokens[4]))
                                throw new Exception("Invalid zone");
                            House h = new House(Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2]), Convert.ToInt32(tokens[3]), tokens[4]);
                            this.addObject(new Transaction(h, Convert.ToInt32(tokens[5]), Convert.ToInt32(tokens[6])));
                            break;
                        case "Flat":
                            if (!zonelist.Contains(tokens[3]))
                                throw new Exception("Invalid zone");
                            Flat f = new Flat(Convert.ToInt32(tokens[1]), Convert.ToInt32(tokens[2]), tokens[3]);
                            this.addObject(new Transaction(f, Convert.ToInt32(tokens[4]), Convert.ToInt32(tokens[5])));
                            break;
                        case "CommSp":
                            if (!zonelist.Contains(tokens[2]))
                                throw new Exception("Invalid zone");
                            CommSp cs = new CommSp(Convert.ToInt32(tokens[1]), tokens[2]);
                            this.addObject(new Transaction(cs, Convert.ToInt32(tokens[3]), Convert.ToInt32(tokens[4])));
                            break;

                        default:
                            corrupted++;
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    corrupted++;
                }
            }
            Console.WriteLine(corrupted + " corrupted lines \n");

            infile.Close();


        }
    }
}
