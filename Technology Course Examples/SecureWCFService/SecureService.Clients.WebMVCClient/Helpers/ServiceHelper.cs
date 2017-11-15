using SecureService.Clients.WebMVCClient.AuthServiceReference;
using SecureService.Clients.WebMVCClient.SecureUserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace SecureService.Clients.WebMVCClient.Helpers
{
    public static class ServiceHelper 
    {
        public static SecureUserServiceClient GetServiceClientWithCredentials(string username, string password)
        {
            SecureUserServiceClient client = new SecureUserServiceClient("WSHttpBinding_ISecureUserService");
            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = username;
            return client;
        }

        public static AuthServiceClient GetAuthServiceClient()
        {
            return new AuthServiceClient("WSHttpBinding_IAuthService");
        }
    }
}