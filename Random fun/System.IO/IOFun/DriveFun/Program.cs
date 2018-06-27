using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.Claims;
using System.Threading;
using System.IdentityModel.Services;

namespace DriveFun
{//SIKE, not really IO! huhuhu 
    class Program
    {
        static void Main(string[] args)
        {
            object o = 1;
            var x = (int)(decimal)o;
            Console.WriteLine(x);
            var anyPrincipal = System.Threading.Thread.CurrentPrincipal;
           
           
            ClaimsIdentity myClaimsIdentity = new ClaimsIdentity(Thread.CurrentPrincipal.Identity);
            Claim claim = new Claim("urn:CanExecuteAMethod", "TRUE", "string", "ROH", "N/A");
            Claim claim2 = new Claim(ClaimTypes.Name, "Knud", "string", "ROH", "N/A");
            myClaimsIdentity.AddClaim(claim);
            myClaimsIdentity.AddClaim(claim2);
            System.Threading.Thread.CurrentPrincipal = new ClaimsPrincipal(myClaimsIdentity);
            
            SecureMethod();
        }

        //In System.IdentityModel.Services
        //https://dotnetcodr.com/2013/02/21/introduction-to-claims-based-security-in-net4-5-with-c-part-4-authorisation-with-claims/
        [ClaimsPrincipalPermission(SecurityAction.Demand, Resource = ClaimTypes.Name, Operation ="Jens")]
        static void SecureMethod()
        {
            RNGCryptoServiceProvider ra = new RNGCryptoServiceProvider();
            
            Console.WriteLine("Inside");
        }
    }
}
