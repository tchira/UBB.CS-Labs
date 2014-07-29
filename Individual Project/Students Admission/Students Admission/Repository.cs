using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Admission
{
    class Repository
    {
        public List<Candidate> candidates { get; set; }
        public List<Department> departments { get; set; }
      


        public Repository()
        {
            candidates = new List<Candidate>();
            departments = new List<Department>();
           

        }

       
        private String getNameById(int id){
            foreach(Department dpt in this.departments){
                if (dpt.id == id)
                    return dpt.name;

            }
            return null;
        }

        public Results generateResults()
        {
            Results res = new Results();
            int open, i;
            bool adm;
            for (i = 1; i < 11; i++)
            {
                res.stats[i] = 0;
            }
            
            Dictionary<int, int> openPlaces = new Dictionary<int, int>();
            foreach (Department dpt in this.departments)
            {
                openPlaces.Add(dpt.id, dpt.places);
            }

            this.candidates.Sort((x, y) => x.gradeFinal.CompareTo(y.gradeFinal));
            this.candidates.Reverse();
            foreach (Candidate cand in this.candidates)
            {
                adm = false;
                for (i = 0; i < cand.options.Count;i++)
                {
                    open = openPlaces[cand.options[i]];

                    if (open > 0)
                    {
                        res.stats[i+1]++;
                        res.admitted.Add(cand.name, getNameById(cand.options[i]));
                        adm = true;
                        openPlaces[cand.options[i]] = open - 1;
                        break;
                    }


                }
                if (adm == false)
                {
                    res.rejected.Add(cand);
                }
            }
            return res;
        }

        public void readDepartmentsFromFile(String filename)
        {
            String line;
            String[] tokens;
            String name;
            int id, places;
            System.IO.StreamReader infile = new System.IO.StreamReader(filename);
            while ((line = infile.ReadLine()) != null)
            {   
                tokens = line.Split(':');
                if (tokens.Length != 3)
                    continue;
                id = Convert.ToInt32(tokens[0]);
                name = tokens[1];
                places = Convert.ToInt32(tokens[2]);
                Department dpt = new Department(id, name, places);
                this.departments.Add(dpt);
             

            }
            infile.Close();
       }

        public void readCandidatesFromFile(String filename)
        {
            String line;
            String[] tokens;
            String CNP,name,adr;
            

            double gradeMI,gradeBac;
            List<int> opt;
            int length;
            System.IO.StreamReader infile = new System.IO.StreamReader(filename);
            while ((line = infile.ReadLine()) != null)
            {
                opt=new List<int>();
                tokens = line.Split(':');
                CNP = tokens[0];
                name = tokens[1];
                adr = tokens[2];
                gradeMI = Convert.ToDouble(tokens[3]);
                gradeBac = Convert.ToDouble(tokens[4]);
                foreach(String g in tokens[5].Split(','))
                    opt.Add(Convert.ToInt32(g));
                Candidate cand = new Candidate(CNP, name, adr, gradeMI, gradeBac, opt);
                this.candidates.Add(cand);

            }
            infile.Close();
        }

        public void writeCandidatesToFile(string filename){

            System.IO.StreamWriter outfile=new System.IO.StreamWriter(filename);
            foreach(Candidate c in this.candidates)
                outfile.WriteLine(c.ToString());
            outfile.Close();


        }

        public void writeDepartmentsToFile(string filename){

            System.IO.StreamWriter outfile=new System.IO.StreamWriter(filename);
            foreach(Department dpt in this.departments)
                outfile.WriteLine(dpt.ToString());
            outfile.Close();


        }

        
    }
}
