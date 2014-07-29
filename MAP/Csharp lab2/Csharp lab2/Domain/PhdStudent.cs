using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_lab2.Domain
{
    [Serializable]
    public class PhdStudent : Student, Identifiable, ComparableObject<Student>
    {
        public String supervisor;
        public String thesis;
        public int grade2;
        public int grade3;
        public PhdStudent(int id, String name, String supervisor, String thesis, int grade, int grade2,int grade3):base (id, name, grade) {
                                this.supervisor = supervisor;
                                this.thesis = thesis;
                                this.grade2 = grade2;
                                this.grade3 = grade3;
                        }

                        public override float getAverage() {
                                return (this.grade + this.grade2+this.grade3) / 2;
                        }

                        public bool isGreaterThan(Student student) {
                                return (this.getAverage() > this.getAverage());
                        }


                        public override String ToString()
                        {
                            //Override for the string output function
                            //Precond:- function called by a student object
                            //Postcont:- outputs the object values in a string format

                            return id + " " + supervisor + " " + thesis + " " + name + " " + grade + " " + grade2 + " " + grade3;
                        }
    }
}
