using SecureService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;

namespace SecureService.ServiceLibrary
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SecureUserService : ISecureUserService
    {
        public UserController UserController { get; set; }
        public SecureUserService()
        {
            UserController = new UserController();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Admin")]
        public string GetData(int value)
        {
            var found = UserController.Get(1337);
            return string.Format("Pssst, the data you requested back was: {0}, hi {1}, you are allowed to know!", value, OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name);
        }

   
    }
}
