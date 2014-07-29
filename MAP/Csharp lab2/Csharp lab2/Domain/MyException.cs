using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_lab2.Domain
{
    public class MyException : Exception
    {
        
            public MyException(string msg)
                : base(msg)
            {
            }
        
    }
}
