using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ai_lab1_console
{
    class Program
    {
        static void Main(string[] args)
        {
        Controller cont=new Controller();
        Menu mainMenu = new Menu(cont);
        mainMenu.runConsole();

        }
    }
}
