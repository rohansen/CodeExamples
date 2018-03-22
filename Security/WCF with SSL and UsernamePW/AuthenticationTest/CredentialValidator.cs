using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Threading;
using System.Security.Claims;
using System.ServiceModel;
using System.Security.Principal;
using DataAccess;
using System.Data.Entity;

namespace AuthenticationTest
{

    public class RoleAuthorizationManager : ServiceAuthorizationManager
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected override bool CheckAccessCore(OperationContext operationContext)
        {

            var identity = operationContext.ServiceSecurityContext.PrimaryIdentity;
            //var user = db.Users.Where(x=>x.userName==identity.Name); Get the user from the database, using the username
            var user = db.Users.Include(x=>x.Roles).Where(x=>x.Email==identity.Name).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("User not found");
            }
            else
            {
                //Assign roles to the Principal property for runtime to match with PrincipalPermissionAttributes decorated on the service operation.
                var roleNames = user.Roles.Select(x=>x.RoleName).ToArray();//Get the current users roles from the database
                var principal = new GenericPrincipal(operationContext.ServiceSecurityContext.PrimaryIdentity, roleNames);
                //assign principal to auth context
                operationContext.ServiceSecurityContext.AuthorizationContext.Properties["Principal"] = principal;

                return true;
            }
        }

    }
    
}
public class CredentialValidator : UserNamePasswordValidator
{
    private ApplicationDbContext db = new ApplicationDbContext();
    public override void Validate(string userName, string password)
    {
        //var user = db.Users.Where(x=>x.userName==userName && x.password==password); Get the user from the database
        var user = db.Users.Where(x => x.Email == userName && x.Password == password);
        if (user.Any())
        {
            //You are logged in
        }
        else
        {
            //No user with the username password combination was found.
            throw new FaultException<Exception>(new Exception("Invalid login"),"Invalid Login");
        }

    }
}
