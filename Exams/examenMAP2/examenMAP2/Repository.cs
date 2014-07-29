using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenMAP2
{
    interface Repository<T>
    {
        void addVehicle(T elem);
        List<T> getAll();
    }
}
