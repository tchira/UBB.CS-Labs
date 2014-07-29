using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShowManagement.Model;
using ShowManagement.Repository;
namespace ShowManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ShowRepo sr = new ShowRepo();
            UserRepo ur = new UserRepo();
            TicketRepo tr = new TicketRepo();

            Controller cont = new Controller(sr, tr, ur);
            Application.Run(new Form1(cont));
           
        }
    }
}
