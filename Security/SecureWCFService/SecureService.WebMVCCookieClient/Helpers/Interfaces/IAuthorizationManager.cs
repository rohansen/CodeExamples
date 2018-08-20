using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureService.Clients.WebMVCClientWithCookie.Helpers.Interfaces
{
    public interface IAuthorizationManager
    {
        bool Login(string username, string password);
        void Logout();

    }
}