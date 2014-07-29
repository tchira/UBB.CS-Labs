using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_lab2.controller;
using Csharp_lab2.Domain;

namespace Csharp_lab2.Repository
{
    class CObserver2 : IObserver<Controller>
    {
        private Controller cont;

        public CObserver2(Controller c)
        {
            this.cont = c;
        }
        public void OnCompleted()
        {
            Console.WriteLine("Unsubbed");
        }

        public void OnError(Exception error)
        {
            //some error handling
        }

        public void OnNext(Controller c)
        {
            Console.WriteLine("Lower than 5:\n");
            foreach (Student s in this.cont.getAll())
                if (s.getAverage() <= 5)
                    Console.WriteLine(s);
        }


    }
}
