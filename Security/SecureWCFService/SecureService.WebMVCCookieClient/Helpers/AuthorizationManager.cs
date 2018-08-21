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
        private ISessionManager _sessionManager;
        private IServiceManager _serviceManager;
        public AuthorizationManager(ICookieSetup cookieSetup, ISessionManager sessionManager, IServiceManager serviceManager)
        {
            _cookieSetup = cookieSetup;
            _sessionManager = sessionManager;
            _serviceManager = serviceManager;
        }

        public bool Login(string username, string password)
        {
            using (AuthServiceClient authClient = _serviceManager.GetAuthServiceClient())
            {
                if (authClient.Login(username, password))
                {
                    var cookie = _cookieSetup.CreateEncryptedAuthenticationCookie("roh", "han"); //Cookie is encrypted using AES(using machineKey and transmitted to the client. Key is on server. Cannot realistically be decrypted. Password not transmitted in this case
                    System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
                    _sessionManager.SetLoggedInSession(new CustomPrincipalSerializeModel { FirstName = "John", LastName = "Doe" });
                    return true;

                }
                else
                {
                    return false;
                }
            }
        }

        public void Logout()
        {
            _sessionManager.ClearSession();
            _cookieSetup.ClearAuthenticationCookie();
        }
    }
}