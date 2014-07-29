using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Admission
{
    public class Candidate
    {
       
        public String name { get; set; }
        public String CNP{ get; set; }
        public String address { get; set; }
        public double gradeMI {get; set; }
        public double gradeBac {get; set; }
        public double gradeFinal { get; set; }
        public List<int> options { get; set; }

        public Candidate()
        {

        }
        public Candidate(String CNP, String name, String address, double gradeMI, double gradeBac, List<int> options)
        {
            this.CNP = CNP;
            this.name = name;
            this.address = address;
            this.gradeBac = gradeBac;
            this.gradeMI = gradeMI;
            this.gradeFinal = (this.gradeBac + this.gradeMI) / 2;
            this.options = options;
        }

        public override string ToString()
        {
            String str = this.CNP + ":" + this.name + ":" + this.address + ":" + this.gradeMI.ToString() + ":" + this.gradeBac.ToString() + ":";
            foreach (int opt in this.options)
            {
                str += opt.ToString() + ",";
            }
            str = str.Remove(str.Length - 1, 1);
            return str;
        }
       




         
    }
}
