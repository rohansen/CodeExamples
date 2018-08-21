using SecureService.Clients.WebMVCClientWithCookie.Helpers.Interfaces;
using SecureService.Clients.WebMVCClientWithCookie.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureService.Clients.WebMVCClientWithCookie.Helpers
{
    public class SessionManager : ISessionManager
    {
        private string LoginSessionName = "LoggedInUser";
        private CustomPrincipalSerializeModel currentUser;
        public CustomPrincipalSerializeModel CurrentUser
        {
            get
            {
                return HttpContext.Current.Session[LoginSessionName] as CustomPrincipalSerializeModel;
            }
            set
            {
                currentUser = value;
            }
        }
        
        public bool IsLoggedIn()
        {
            return HttpContext.Current.Session[LoginSessionName] != null;
        }
        public void SetLoggedInSession(CustomPrincipalSerializeModel lvm)
        {
            HttpContext.Current.Session[LoginSessionName] = lvm;
        }
        public void ClearSession()
        {
            System.Web.HttpContext.Current.Session.Abandon();
        }
    }
}