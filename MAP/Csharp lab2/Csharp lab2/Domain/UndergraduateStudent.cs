using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_lab2.Domain
{
    [Serializable]
    public class UndergraduateStudent : Student, Identifiable, ComparableObject<Student>
    {
        public int grade2;

        public UndergraduateStudent(int id, String name, int grade, int grade2)
            : base(id, name, grade)
        {
            this.grade2 = grade2;
        }

        public override float getAverage()
        {
            return (this.grade + this.grade2) / 2;
        }

        public bool isGreaterThan(Student s)
        {
            return (this.getAverage() > s.getAverage());
        }

        public override string ToString()
        {
            //Override for the string output function
            //Precond:- function called by a student object
            //Postcont:- outputs the object values in a string format

            return id + " " + name + " " + grade + " " + grade2;
        }
    }
}
