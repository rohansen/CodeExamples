using SecureService.DataAccess.Interfaces;
using SecureService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureService.DataAccess.Dapper
{
    public class DapperUser : IDatabaseUserLogin<User>
    {
        public event Action<string> InvalidLoginAttempt;
        public event Action<string> LoginAttempt;

        public void Add(User entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(string query)
        {
            throw new NotImplementedException();
        }

        public User Get(string q)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
