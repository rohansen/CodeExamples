using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DbUser
    {

        public User Get(int id)
        {
            List<Role> userRoles = new List<Role> { new Role { Id = 1, Name = "Admin" } };
            return new User { Id = 1, Email = "roh@ucn.dk", Password = "1234", Roles=userRoles };
        }
        public User Get(string email)
        {
            List<Role> userRoles = new List<Role> { new Role { Id = 1, Name = "Admin" } };
            return new User { Id = 1, Email = "roh@ucn.dk", Password = "1234", Roles = userRoles };
        }
    }
}
