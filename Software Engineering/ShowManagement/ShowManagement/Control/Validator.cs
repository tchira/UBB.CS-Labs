using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManagement.Control
{
    public static class Validator
    {
        public static bool validateString(string s){
            if (s == "")
            {
                throw new Exception("Invalid input");
                return false;
            }
            return true;
        }
    }
}
