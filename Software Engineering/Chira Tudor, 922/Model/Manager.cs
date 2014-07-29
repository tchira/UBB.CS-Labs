using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManagement.Model
{
    public class Manager:User
    {

         public int cid { get; set; }
        public String name { get; set; }
       public String password { get; set; }
       public bool isManager { get; set; }
       public String adr { get; set; }

        public Manager(int cid, String name, String password,String adr,bool isManager)
        {
            this.adr = adr;
            this.cid = cid;
            this.name = name;
            this.password = password;
            this.isManager = isManager;
        }

        public override string ToString()
        {
            return name + "| " + password;
        }
    }
}
