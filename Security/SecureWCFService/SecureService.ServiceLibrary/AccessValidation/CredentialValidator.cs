using SecureService.Controllers;
using SecureService.DataAccess.ADO.SQLServer;
using SecureService.Domain;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SecureService.ServiceLibrary.AccessValidation
{
    public class CredentialValidator : UserNamePasswordValidator
    {
        private IAuthorizeUserController<User> userCtrl = new UserController(new ADOUser());
        public override void Validate(string userName, string password)
        {
            var foundUser = userCtrl.Login(userName,password);
            if (foundUser!=null)
            {
                //email pw are valid
            }
            else
            {
                throw new FaultException<Exception>(new Exception("Invalid Login..."), "Invalid Credentials");
            }
        }
    }
}
