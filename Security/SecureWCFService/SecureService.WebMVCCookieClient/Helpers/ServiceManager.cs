using SecureService.Clients.WebMVCClientWithCookie.AuthServiceReference;
using SecureService.Clients.WebMVCClientWithCookie.SecureUserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace SecureService.Clients.WebMVCClientWithCookie.Helpers
{
    public static class ServiceManager 
    {
        public static SecureUserServiceClient GetServiceClientWithCredentials(string username, string password)
        {
            SecureUserServiceClient client = new SecureUserServiceClient("WSHttpBinding_ISecureUserService");
            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = password;
            return client;
        }

        public static AuthServiceClient GetAuthServiceClient()
        {
            return new AuthServiceClient("WSHttpBinding_IAuthService");
        }
    }
}