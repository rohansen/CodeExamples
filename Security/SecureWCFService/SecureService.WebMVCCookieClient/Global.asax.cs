using SecureService.Clients.WebMVCClientWithCookie.DependencyInjection;
using SecureService.Clients.WebMVCClientWithCookie.Helpers;
using SecureService.Clients.WebMVCClientWithCookie.Helpers.Interfaces;
using SecureService.Clients.WebMVCClientWithCookie.Models.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace SecureService.Clients.WebMVCClientWithCookie
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private ICookieSetup _cookieSetup = new CookieSetup();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityBootstrapper.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;

        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                HttpContext.Current.User = _cookieSetup.RetrieveUserFromCookie(authCookie);
            }
        }
    }
}
