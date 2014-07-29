using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_lab2.Domain
{
    [Serializable]
    public class GraduateStudent:Student,Identifiable,ComparableObject<Student>
    {
        public int grade2;
        public int grade3;
        public string supervisor;
        public GraduateStudent(int id, string name, string supervisor, int grade, int grade2, int grade3)
            : base(id, name, grade)
        {
            this.grade2 = grade2;
            this.grade3 = grade3;
            this.supervisor = supervisor;
        }

        public override float getAverage()
        {
            return (grade + grade2 + grade3) / 3;
        }

        public bool isGreaterThan(Student s)
        {
            return this.getAverage() > s.getAverage();
        }

        public override string ToString()
        {
            return id + " " + supervisor+" "+ name + " " + grade + " " + grade2 + " " + grade3;
        }
    }
}
