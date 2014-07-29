using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenMAP_C
{
    class House:CommSp

    {

        public int floors, rooms;
        public House(int floors, int rooms, int surface, string zone) : base(surface,zone)
        {
            
            this.floors = floors;
            this.rooms = rooms;
        }

        public override string ToString()
        {
            return "House," + floors + "," + rooms + "," + surface;
        }
    }
}
