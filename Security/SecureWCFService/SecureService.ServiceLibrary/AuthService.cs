using SecureService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureService.Domain;
using SecureService.DataAccess.ADO.SQLServer;
using SecureService.DataAccess.Interfaces;

namespace SecureService.ServiceLibrary
{
    public class AuthService : IAuthService
    {
        private IAuthorizeUserController<User> userCtrl = new UserController(new ADOUser());

        public void AddUser(User user)
        {
            userCtrl.Add(user);
        }

        //When this method returns, the data is serialized as a SOAP message by the datacontractserializer, and sent to the client using the protocol 
        //specified in the bindings section og ABC
        //Idea.. look into performance on using fault exceptions instead of true/false/null values

        //Connection is secured with TLS. Certificate information in the config file of the host project
        public bool Login(string username, string password)
        {
            var user = userCtrl.Login(username, password);
            if (user == null)
            {
                return false;
            }
            return true;

        }



    }
}
