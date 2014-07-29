using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowManagement.Model;

namespace ShowManagement.Repository
{
    public class UserRepo
    {
        public List<User> users { get; set; }

        public UserRepo()
        {
            users = new List<User>();
        }

        public List<User> getUsers()
        {
            return this.users;
        }

        public int getUserCount()
        {
            return this.users.Count;
        }
    }
}
