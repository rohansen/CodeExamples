using SecureService.Clients.WebMVCClientWithCookie.Helpers;
using SecureService.Clients.WebMVCClientWithCookie.Helpers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;

namespace SecureService.Clients.WebMVCClientWithCookie.DependencyInjection
{
    public static class UnityBootstrapper
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IAuthorizationManager, AuthorizationManager>();
            container.RegisterType<ICookieSetup, CookieSetup>();
            container.RegisterType<ISessionManager, SessionManager>();
            container.RegisterType<IServiceManager, ServiceManager>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}