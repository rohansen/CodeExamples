using SecureService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureService.Domain;

namespace SecureService.ServiceLibrary
{
    public  class AuthService : IAuthService
    {
        private UserController userCtrl = new UserController();
        public bool Login(string username, string password)
        {
            var user = userCtrl.Login(username,password);
            if(user == null)
            {
                return false;
            }
            return true;
        }

        public User LoginABC()
        {
            throw new NotImplementedException();
        }
    }
}
