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
        public override void Validate(string userName, string password)
        {
            if(userName=="roh" && password == "1234")
            {

            }else
            {
                throw new FaultException<Exception>(new Exception("Invalid Login..."), "Invalid Credentials");
            }
        }
    }
}
