using Controllers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Selectors;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DMAISecureService.AccessValidation
{
    public class CredentialValidator : UserNamePasswordValidator
    {
        private UserController userCtrl = new UserController();
        public override void Validate(string userName, string password)
        {
            var foundUser = userCtrl.GetUser(userName);
            if (foundUser != null && foundUser.Email == userName && foundUser.Password == password)
            {
                //email pw are valid
            }else
            {
                throw new FaultException<Exception>(new Exception("Invalid Login..."), "Invalid Credentials");
            }
        }
    }
}
