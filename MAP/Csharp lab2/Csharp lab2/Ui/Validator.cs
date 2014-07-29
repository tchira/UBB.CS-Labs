using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_lab2.Domain;

namespace Csharp_lab2.Ui
{
    class Validator
    {
        public bool validateGrade(int g)
        {
            if (g < 1 || g > 10)
                throw new MyException("Invalid grade");
            return true;
        }

        public bool validateName(string name)
        {
            if (name == "")
                throw new MyException("Empty string for name");
            return true;
        }

        public bool validateId(int id)
        {
            if (id < 1)
                throw new MyException("Id cannot be below 1");
            return true;
        }
    }
}
