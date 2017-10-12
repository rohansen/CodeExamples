using Microsoft.Owin.Security;
using SqlInjectionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SqlInjectionExample.Controllers
{
    public class AuthenticationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Login(string retUrl = "/Home/Index")
        {
            LoginViewModel lvm = new LoginViewModel { ReturnUrl = retUrl };
            return View(lvm);
        }
        // GET: Authentication
        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            var foundUser = db.Database.SqlQuery<User>("SELECT * FROM Users WHERE Email='" + lvm.Email + "' AND Password='" + lvm.Password+"'");
            
            if (foundUser.Any())
            {
                var identity = new ClaimsIdentity(new Claim[] {
                                                    new Claim(ClaimTypes.NameIdentifier, foundUser.FirstOrDefault().Id),
                                                    new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity", "http://www.w3.org/2001/XMLSchema#string"),
                                                    new Claim(ClaimTypes.Name,lvm.Email),
                                                 
                                                    // optionally you could add roles if any
                                                    new Claim(ClaimTypes.Role, foundUser.FirstOrDefault().Role) },"ApplicationCookie");
                HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties { IsPersistent = true }, identity);
                return Redirect(lvm.ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout(string returnUrl)
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect(returnUrl);
        }

     
    }

    //Solutions 
    //UPDATE Users SET Role='Admin' WHERE Email='useremail@useremail.com'--
    //DROP Users--
    //%') UNION SELECT * FROM USERS --
    //%') UNION SELECT * FROM INFORMATION_SCHEMA.COLUMNS --

}