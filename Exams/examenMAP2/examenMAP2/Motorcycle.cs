using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examenMAP2
{   [Serializable]
    class Motorcycle:Vehicle
    {
          public string name;
        public bool rep;

        public Motorcycle(string n, bool i)
        {
            this.name = n;
            this.rep = i;
        }

        public bool isRepaired(){
            return this.rep;
        }

        public override string ToString(){
            return "Motorcycle "+name+" "+rep;
        }

        public string type()
        {
            return "motorcycle";
        }
    }
}
