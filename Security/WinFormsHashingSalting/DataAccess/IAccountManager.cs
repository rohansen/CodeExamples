using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IAccountManager
    {
        void Register(string username, string password);
        bool Login(string username, string password);
    }
}
