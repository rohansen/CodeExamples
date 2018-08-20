using SecureService.Clients.WebMVCClientWithCookie.AuthServiceReference;
using SecureService.Clients.WebMVCClientWithCookie.Helpers.Interfaces;
using SecureService.Clients.WebMVCClientWithCookie.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureService.Clients.WebMVCClientWithCookie.Helpers
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private ICookieSetup _cookieSetup;
        public bool Login(string username, string password)
        {
            AuthServiceClient authClient = ServiceManager.GetAuthServiceClient();
            if (authClient.Login(username, password))
            {
                var cookie = _cookieSetup.CreateEncryptedAuthenticationCookie("roh", "han"); //Cookie is encrypted using AES and transmitted to the client. Key is on server. Cannot realistically be decrypted. Password not transmitted in this case
                System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                SessionManager.SetLoggedInSession(new CustomPrincipalSerializeModel { FirstName = "John", LastName = "Doe" });
                return true;

            }else
            {
                return false;
            }
        }

        public void Logout()
        {
            SessionManager.ClearSession();
            _cookieSetup.ClearAuthenticationCookie();
        }
    }
}