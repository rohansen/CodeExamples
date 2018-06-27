using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DriveFun
{
    public class MyClaimsManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {

            return true;
        }
        //public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
        //{
        //    if (incomingPrincipal != null && incomingPrincipal.Identity.IsAuthenticated == true)
        //    {
        //        ((ClaimsIdentity)incomingPrincipal.Identity).AddClaim(new Claim(ClaimTypes.Role, "User"));
        //    }
        //    return incomingPrincipal;
        //}
    }
}
