using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_lab2.controller;
using Csharp_lab2.Domain;

namespace Csharp_lab2.Ui
{
    class CObserver1:IObserver<Controller>
    {
        private Controller cont;

        public CObserver1(Controller c)
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
            Console.WriteLine("Greater than 5:\n");
            foreach (Student s in this.cont.getAll())
                if (s.getAverage() > 5)
                    Console.WriteLine(s);
        }

        
    }
}
