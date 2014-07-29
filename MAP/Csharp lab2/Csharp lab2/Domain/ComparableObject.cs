using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_lab2.Domain
{
   interface ComparableObject<T>
    {
        bool isGreaterThan(T element);
    }
}
