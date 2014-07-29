using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenMAP2
{
    class UserConsole
    {
        public Controller cont;

        public UserConsole(Controller c)
        {
            this.cont = c;
        }

        public void run()
        {
            int option = -1;
            while (option != 0)
            {
                string type, name;
                bool rep;
                Console.WriteLine("____________________________");
                Console.WriteLine("0.Exit");
                Console.WriteLine("1.Insert vehicle");
                Console.WriteLine("2.Print all repaired trucks");
                Console.WriteLine("3.Print all vehicles not yet repaired");
                Console.WriteLine("4.Print all vehicles");
                option = Int32.Parse(Console.ReadLine());

                if (option == 1)
                {
                    Console.WriteLine("Vehicle name:");
                    name = Console.ReadLine();
                    Console.WriteLine("Is repaired: ( true / false )");

                    rep = Convert.ToBoolean(Console.ReadLine());
                    Console.WriteLine("choose type: car/truck/motorcycle");
                    type = Console.ReadLine();
                   
                    switch (type)
                    {
                        case "car":
                            Car c1 = new Car(name, rep);
                            cont.addVehicle(c1);
                            break;

                        case "truck":
                            Truck t1 = new Truck(name, rep);
                            cont.addVehicle(t1);
                            break;

                        case "motorcycle":
                            Motorcycle m1 = new Motorcycle(name, rep);
                            cont.addVehicle(m1);
                            break;
                    }

                }

                if(option==2){
                    foreach (Vehicle v in cont.getAll())
                    {
                         
                        if (v.isRepaired() && v.type() == "truck")
                            Console.WriteLine(v);
                    }
                }

                if (option == 3)
                {
                    foreach (Vehicle v in cont.getAll())
                    {
                        if (!v.isRepaired())
                        {
                            Console.WriteLine(v);
                        }
                    }
                }

                if (option == 4)
                {
                    foreach (Vehicle v in cont.getAll())
                        Console.WriteLine(v);
                }
            }
        }


    }
}
