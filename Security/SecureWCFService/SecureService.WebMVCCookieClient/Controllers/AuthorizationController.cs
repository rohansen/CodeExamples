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
    public class AuthorizationController : Controller
    {
        //TODO: Install package to inject dependencies in the controller
        private ICookieSetup _cookieSetup;
        private IAuthorizationManager _authManager;
        public AuthorizationController()
        {
            _cookieSetup = new CookieSetup();
            _authManager = new AuthorizationManager();
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
    }
}