using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller cont = new Controller();
            cont.initValues();
            Console.WriteLine("FORWARD INFERENCE\n____________________________________");
            Console.WriteLine(cont.findCycle().ToString());
            Console.WriteLine();
            cont.initReverseValues();
            Console.WriteLine("REVERSE INFERENCE\n____________________________________");
            Console.WriteLine(cont.findReverse().ToString());

            Console.ReadKey();

        }
    }
}
