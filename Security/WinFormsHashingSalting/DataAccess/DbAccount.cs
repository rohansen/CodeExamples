using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbAccount : IAccountManager
    {
        public bool Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void Register(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
