using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ExamenMAP_C
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repo = new Repository();
            Controller cont = new Controller(repo);
            cont.readFromFile();
            Application.Run(new Mainform(cont));
        }
    }
}
