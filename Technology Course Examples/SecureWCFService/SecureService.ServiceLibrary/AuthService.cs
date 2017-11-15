using SecureService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureService.ServiceLibrary
{
    public  class AuthService : IAuthService
    {
        private UserController userCtrl = new UserController();
        public bool Login(string username, string password)
        {
            var user = userCtrl.GetUser(username);
            return user.Email == username && user.Password == password;
        }
    }
}
