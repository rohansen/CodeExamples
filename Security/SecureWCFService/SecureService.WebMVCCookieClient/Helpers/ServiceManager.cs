using SecureService.Clients.WebMVCClientWithCookie.AuthServiceReference;
using SecureService.Clients.WebMVCClientWithCookie.Helpers.Interfaces;
using SecureService.Clients.WebMVCClientWithCookie.SecureUserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace SecureService.Clients.WebMVCClientWithCookie.Helpers
{
    public class ServiceManager : IServiceManager
    {
        public SecureUserServiceClient GetServiceClientWithCredentials(string username, string password)
        {
            SecureUserServiceClient client = new SecureUserServiceClient("WSHttpBinding_ISecureUserService");
            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = password;
            return client;
        }

        public AuthServiceClient GetAuthServiceClient()
        {
            return new AuthServiceClient("WSHttpBinding_IAuthService");
        }
    }
}