using System;
using System.Collections.Generic;
using System.IdentityModel.Services;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace AuthenticationTest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SecureService : ISecureService
    {
        //https://www.codeproject.com/Articles/802435/Authentication-and-Authorization-with-ASP-NET-Iden
        [PrincipalPermission(SecurityAction.Demand,Role ="Admin")]//if multiple roles are needed, comma seperate  
        public string GetData(int value)
        {
            
            var x =  ClaimsPrincipal.Current;
            return string.Format("(SECURE COMMUNICATION WITH USR & PW)You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
