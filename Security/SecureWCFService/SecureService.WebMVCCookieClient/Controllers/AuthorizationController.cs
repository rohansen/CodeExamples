using SecureService.Clients.WebMVCClientWithCookie.Helpers;
using SecureService.Clients.WebMVCClientWithCookie.AuthServiceReference;
using SecureService.Clients.WebMVCClientWithCookie.Models.Authorization;
using SecureService.Clients.WebMVCClientWithCookie.SecureUserServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using SecureService.Clients.WebMVCClientWithCookie.Helpers.Interfaces;

namespace SecureService.Clients.WebMVCClientWithCookie.Controllers
{
    //Todo: sanitize inputs from the modelbinder using [Bind]
    //Use antiforgery tokens to prevent CSRF
    //Implement another controller that uses the [Authorize] attribute (cookie authentication has already been hooked up to identity)
    //Maybe could be fun to show the students caching as well

    public class AuthorizationController : Controller
    {
        //TODO: Install package to inject dependencies in the controller
        private ICookieSetup _cookieSetup;
        private IAuthorizationManager _authManager;
        private IServiceManager _serviceManager;
        public AuthorizationController(IAuthorizationManager _authManager, ICookieSetup _cookieSetup, IServiceManager _serviceManager)
        {
            this._authManager = _authManager;
            this._cookieSetup = _cookieSetup;
            this._serviceManager = _serviceManager;
        }
        // GET: Authorization
        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(string username, string password, string ReturnUrl)
        {
            if (_authManager.Login(username, password))
            {
                //TODO: Always validate urls to prevent unvalidated redirect and forwards vulnerability
                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ErrorMessage = "Could not log in, invalid credentials";
            return View();
        }
        public ActionResult Logout()
        {
            _authManager.Logout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User u)
        {
            using (AuthServiceClient client = _serviceManager.GetAuthServiceClient())
            {
                try
                {
                    client.AddUser(u);
                    return RedirectToAction("Login", new { username = u.Email, password = u.Password });
                }
                catch (Exception ex)
                {
                    //bad practice.. what are you doing! 
                    ViewBag.Message = ex.Message;
                    return View();
                }
            }
            
        }
    }
}