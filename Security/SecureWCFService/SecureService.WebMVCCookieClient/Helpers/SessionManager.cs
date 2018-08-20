using SecureService.Clients.WebMVCClientWithCookie.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureService.Clients.WebMVCClientWithCookie.Helpers
{
    public static class SessionManager
    {
        private static string LoginSessionName = "LoggedInUser";
        private static CustomPrincipalSerializeModel currentUser;
        public static CustomPrincipalSerializeModel CurrentUser
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
        
        public static bool IsLoggedIn()
        {
            return HttpContext.Current.Session[LoginSessionName] != null;
        }
        public static void SetLoggedInSession(CustomPrincipalSerializeModel lvm)
        {
            HttpContext.Current.Session[LoginSessionName] = lvm;
        }
        public static void ClearSession()
        {
            System.Web.HttpContext.Current.Session.Abandon();
        }
    }
}