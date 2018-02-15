using SecureService.DataAccess;
using SecureService.DataAccess.ADO.SQLServer;
using SecureService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureService.Controllers
{
    public class UserController : IController<User>
    {
        private DbUser dbUser;
        public UserController()
        {
            dbUser = new DbUser();
        }

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(string query)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return dbUser.Get(id);
        }
        public User Get(string email)
        {
            return dbUser.Get(email);
        }
        public User Login(string username, string password)
        {
            return dbUser.Login(username, password);
        }
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

    }
}
