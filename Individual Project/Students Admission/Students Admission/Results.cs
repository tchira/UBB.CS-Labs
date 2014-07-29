using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Admission
{
    class Results
    {
        public List<Candidate> rejected { get; set; }
       public Dictionary<String, String> admitted { get; set; }
        public int[] stats { get; set; }


          public Results()
          {
              rejected = new List<Candidate>();
              admitted = new Dictionary<String, String>();
              stats = new int[11];
          }
        
          public Results(List<Candidate> rej,Dictionary<String,String> adm, int[] st)
          {
              this.rejected = rej;
              this.admitted = adm;
              this.stats = st;
          }
    }
}
