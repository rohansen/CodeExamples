using DataAccessLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class UserController
    {
        public DbUser DbUser { get; set; }
        public UserController()
        {
            DbUser = new DbUser();
        }

        public User GetUser(int id)
        {
            return new User();
        }
    }
}
