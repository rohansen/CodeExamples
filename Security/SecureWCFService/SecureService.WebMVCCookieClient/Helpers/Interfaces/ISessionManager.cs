using SecureService.Clients.WebMVCClientWithCookie.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureService.Clients.WebMVCClientWithCookie.Helpers.Interfaces
{
    public interface ISessionManager
    {
        CustomPrincipalSerializeModel CurrentUser { get; set; }
        bool IsLoggedIn();
        void SetLoggedInSession(CustomPrincipalSerializeModel lvm);
        void ClearSession();

    }
}