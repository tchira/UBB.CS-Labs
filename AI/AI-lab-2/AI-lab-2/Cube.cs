using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_lab_2
{
    public class Cube
    {
        public int size;
        public int color;



        public Cube(int s, int c)
        {
            this.size = s;
            this.color = c;
        }

        public override string ToString()
        {
            return " " + size + "|" + color;
        }


    
    
    
    }






}
