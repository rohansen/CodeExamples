using Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace DMAISecureService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SecureService : ISecureService
    {
        public UserController UserController { get; set; }
        public SecureService()
        {
            UserController = new UserController();
        }

        [PrincipalPermission(SecurityAction.Demand, Role ="Admin")]
        public string GetData(int value)
        {
            var found = UserController.GetUser(1337);
            return string.Format("Pssst, the data you requested back was: {0}, hi {1}, you are allowed to know!", value,OperationContext.Current.ServiceSecurityContext.PrimaryIdentity.Name);
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
