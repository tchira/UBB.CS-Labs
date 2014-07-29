using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csharp_lab2.controller;
using Csharp_lab2.Repository;
using Csharp_lab2.Domain;
using Csharp_lab2.Ui;
using System.Drawing;
using System.Windows.Forms;

namespace Csharp_lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            RepositoryHashmap<Student> rs = new RepositoryHashmap<Student>();
            Controller cont = new Controller(rs);
            Validator valid = new Validator();
            /*Menu console = new Menu(cont,valid);
            CObserver1 co1 = new CObserver1(cont);
            CObserver2 co2 = new CObserver2(cont);
            var unsubscriber1 = cont.Subscribe(co1);
            var unsubscriber2=cont.Subscribe(co2);
             console.runMenu();
             unsubscriber1.Dispose();
             unsubscriber2.Dispose();*/
             Application.Run(new Mainform(cont));
               

        }
    }
}
