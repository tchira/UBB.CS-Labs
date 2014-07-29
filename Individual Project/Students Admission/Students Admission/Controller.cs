using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Admission
{
    class Controller
    {
        private Repository mod;
        private String candfile, dptfile;



        public Controller(Repository m,String candfile,String dptfile)
        {
            this.mod = m;
            this.candfile = candfile;
            this.dptfile = dptfile;
            mod.readCandidatesFromFile(candfile);
            mod.readDepartmentsFromFile(dptfile);
        }

        public Results getResults(){
            return mod.generateResults();
        }

        public Candidate getCandidateByCNP(String CNP)
        {
            foreach (Candidate c in mod.candidates)
            {
                if (c.CNP == CNP)
                    return c;
            }
            return null;
        }

        public Department getDepartmentById(int id)
        {
            foreach (Department d in this.mod.departments)
                if(d.id==id)
                    return d;
            return null;
        }

        public void addCandidate(Candidate c)
        {
            if (getCandidateByCNP(c.CNP) == null)
            {
                this.mod.candidates.Add(c);
                printCToFile();
            }
            else throw new Exception("Candidate CNP already exists");
            
        }

        public void addDepartment(Department d)
        {   if(getDepartmentById(d.id)==null)
            {
            this.mod.departments.Add(d);
            printDToFile();
             }
            else 
            throw new Exception("Department id already exists");
           
        }

        public List<Candidate> getCandidates(){
            return mod.candidates;
        }

        public List<Department> getDepartments()
        {
            return mod.departments;
        }


        public void deleteCandidatebyCnp(String cnp)
        {
            Candidate del = new Candidate();
            
            foreach(Candidate c in mod.candidates)
                if (c.CNP==cnp){
                    del = c;
                }

            mod.candidates.Remove(del);
            printCToFile();
        }

        public void deleteDepartmentById(int did)
        {
            Department deldpt = new Department();
            foreach (Department d in mod.departments)
            {
                if (d.id == did)
                    deldpt = d;
            }

            mod.departments.Remove(deldpt);
            printDToFile();
        }

        public void printDToFile()
        {
            mod.writeDepartmentsToFile(dptfile);
            
        }

        public void printCToFile()
        {
            mod.writeCandidatesToFile(candfile);
        }
    }
}
