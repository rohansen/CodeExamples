using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecureService.Clients.WebMVCClient.Helpers;
using SecureService.Clients.WebMVCClient.Models;

namespace SecureService.Clients.WebMVCClient.Controllers
{
    public class AuthController : Controller
    {
        // GET: AuthController
        public ActionResult Index()
        {
       
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel lvm)
        {
            bool canLogIn = false;
            using (var authsvc = ServiceHelper.GetAuthServiceClient())
            {
                canLogIn = authsvc.Login(lvm.Email, lvm.Password);
            }
            if (!canLogIn)
            {
                ViewBag.StatusMessage = "Could not login with the given credentials";
                return View();
            }
            else
            {
                
                AuthHelper.Login(lvm);
                return RedirectToAction("MembersOnly");
            }

        }
   
        public ActionResult Logout()
        {

            AuthHelper.Logout();
            return RedirectToAction("Index");
            
        }
        public ActionResult MembersOnly()
        {
            return View();
        }
    }
}