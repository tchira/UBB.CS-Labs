using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenMAP_C
{
    class Flat:CommSp
    {
        public int rooms;
        public Flat(int rooms, int surface, string zone): base(surface,zone)
        {
            this.rooms = rooms;
            
        }

        public override string ToString()
        {
            return "Flat," + rooms + "," + surface + "," + zone;
        }
    }
}
