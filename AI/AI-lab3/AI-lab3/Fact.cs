using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_lab3
{
    class Fact
    {
        public Boolean val { get; set; }
        public String desc { get; set; }

        public Fact()
        {

        }

        public override string ToString()
        {
            return this.desc;
        }
    }
}
