using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenMAP2
{
    class Program
    {
        static void Main(string[] args)
        {
            VehicleRepository<Vehicle> repo = new VehicleRepository<Vehicle>();
            Controller cont = new Controller(repo);
            UserConsole cons = new UserConsole(cont);
            cons.run();
        }
    }
}
