using SecureService.Clients.WebMVCClientWithCookie.AuthServiceReference;
using SecureService.Clients.WebMVCClientWithCookie.SecureUserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureService.Clients.WebMVCClientWithCookie.Helpers.Interfaces
{
    public interface IServiceManager
    {
        SecureUserServiceClient GetServiceClientWithCredentials(string username, string password);
        AuthServiceClient GetAuthServiceClient();
    }
}