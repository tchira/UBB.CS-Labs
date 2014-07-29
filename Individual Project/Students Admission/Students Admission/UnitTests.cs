using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;



namespace Students_Admission
{


    public class UnitTests
    {
            private Repository testRepo = new Repository();
            private Controller testCont;

            public void runTests()
            {
                
                Debug.Assert(testRepo.candidates.Count == 0);
                Debug.Assert(testRepo.departments.Count == 0);
                testCont = new Controller(testRepo,"testc.txt","testd.txt");
               
                testRepo.candidates.Clear();
                testRepo.departments.Clear();
                String name = "Chira Tud0r";
                String CNP = "194010305505a";
                try
                {
                   
                    Validator.validateName(name);
                }
                catch (Exception ae)
                {
                    Debug.Assert("Name contains invalid characters"==ae.Message);
                }

                try
                {

                    Validator.validateCNP(CNP);
                }
                catch (Exception ae)
                {
                    Debug.Assert("CNP contains invalid characters"==ae.Message);
                }
                
                CNP="194010305505";
                 try
                {

                    Validator.validateCNP(CNP);
                }
                catch (Exception ae)
                {
                    Debug.Assert("Invalid CNP length"==ae.Message);
                }

                 CNP = "3940103055050";
                 try
                 {

                     Validator.validateCNP(CNP);
                 }
                 catch (Exception ae)
                 {
                     Debug.Assert("CNP must begin with 1 or 2" == ae.Message);
                 }

                 double grade = 0.5;

                 try
                 {
                     Validator.validateGrade(grade);
                 }
                 catch (Exception ae)
                 {
                     Debug.Assert("Grade must be between 1 and 10" == ae.Message);
                 }

                 List<int> test = new List<int> { 1,2 };
                 this.testRepo.departments.Add(new Department(1, "test Dep", 1));
                 this.testRepo.departments.Add(new Department(2, "test Dep2", 1));
                 this.testRepo.candidates.Add(new Candidate("1940103055050", "Chira Tudor", "adr", 9, 9, test));
                 this.testRepo.candidates.Add(new Candidate("1940103055051", "Chira Mihai", "adr", 9, 8, test));
                 this.testRepo.candidates.Add(new Candidate("1940103055052", "Chiriac", "adr", 8, 8, test));
                 Debug.Assert(testRepo.candidates.Count == 3);
                 Debug.Assert(testRepo.departments.Count == 2);
                 Results testRes = testRepo.generateResults();
                 Debug.Assert(testRes.rejected[0].name == "Chiriac");
                 Debug.Assert(testRes.admitted["Chira Tudor"] == "test Dep");
                 Debug.Assert(testRes.admitted["Chira Mihai"] == "test Dep2");
                 Debug.Assert(testRes.stats[1] == 1);
                 Debug.Assert(testRes.stats[2] == 1);
                 Debug.Assert(testRepo.candidates[0] == testCont.getCandidateByCNP("1940103055050"));
                 Debug.Assert(testRepo.departments[0]==testCont.getDepartmentById(1));
                 testCont.deleteCandidatebyCnp("1940103055052");
                 testCont.deleteDepartmentById(2);
                 Debug.Assert(testRepo.candidates.Count == 2);
                 Debug.Assert(testRepo.departments.Count == 1);

                 
                 
                



               
                
                
            }

            
        
    }
}
