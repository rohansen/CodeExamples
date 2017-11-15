using SecureService.DataAccess;
using SecureService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureService.Controllers
{
    public class UserController
    {
        private DbUser dbUser;
        public UserController()
        {
            dbUser = new DbUser();
        }
        public User GetUser(int id)
        {
            return dbUser.Get(id);
        }
        public User GetUser(string email)
        {
            return dbUser.Get(email);
        }
    }
}
