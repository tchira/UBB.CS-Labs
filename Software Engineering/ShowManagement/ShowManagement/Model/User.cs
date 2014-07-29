using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowManagement.Model
{
    public interface User
    {
       int cid { get; set; }
      String name { get; set; }
      String password { get; set; }
      bool isManager { get; set; }
         String adr { get; set; }

        

    }
}
