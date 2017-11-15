using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMAISecureService
{
    public class AuthService : IAuthService
    {
        public bool Login(string username, string password)
        {
            if(username=="roh" && password == "1234")
            {
                return true;
            }else
            {
                return false;
            }
        }
    }
}
