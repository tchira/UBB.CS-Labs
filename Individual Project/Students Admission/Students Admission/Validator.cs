using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Students_Admission
{
    static class Validator
    {
        public static bool validateName(String name)
        {
            if (Regex.IsMatch(name, @"^[a-zA-Z ]+$"))
                return true;
            else
            {
                throw new Exception("Name contains invalid characters");
                return false;
            }
        }

        public static bool validateCNP(String CNP)
        {
            if (!Regex.IsMatch(CNP, @"^[0-9]+$"))
            {
                throw new Exception("CNP contains invalid characters");
                return false;
            }

            if (CNP.Length != 13)
            {
                throw new Exception("Invalid CNP length");
                return false;
            }

            if (!(CNP[0] == '1' || CNP[0] == '2'))
            {
                throw new Exception("CNP must begin with 1 or 2");
                return false;
            }
            return true;
        }

        public static bool validateGrade(double grade)
        {
            if (grade < 1 || grade > 10)
            {
                throw new Exception("Grade must be between 1 and 10");
                return false;
            }
            return true;
        }

    }
}
