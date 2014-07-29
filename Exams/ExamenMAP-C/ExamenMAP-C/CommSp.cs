using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenMAP_C
{
    class CommSp
    {
        public string zone;
        public int surface;

        public CommSp(int surface,string zone)
        {
            this.zone = zone;
            this.surface = surface;
        }

        public override string ToString()
        {
            return "CommSp," + surface + "," + zone;
        }
    
    }


    
}
