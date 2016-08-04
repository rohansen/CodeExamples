using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace FormsAuthTest.Controllers
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class HomeController : Controller
    {

        public ActionResult Index()
        {



            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        //Gad ikke lave en database; men lad som om jeg har hentet ham gutten her fra min database
        User theKing = new User { Email = "roh@ucn.dk", Password = "1234", UserId = 1 };
        [HttpPost]
        public ActionResult Login(User u, bool RememberMe)
        {
            if (u.Email == theKing.Email && u.Password == theKing.Password)
            {
                //Opbygger en ticket med det data der skal bruges i cookien; herunder en email og en udløbstid(20 minutter) 
                var formsTicket = new FormsAuthenticationTicket(1, u.Email, DateTime.Now, DateTime.Now.AddMinutes(1), false, "someUserData");
                //krypterer ticketen, så den ikke kan læses når den transmitteres
                var encryptedTicket = FormsAuthentication.Encrypt(formsTicket);
                //laver den faktiske cookie ud fra vores ticket, og adder den til vores Response.Cookies
                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                HttpContext.Response.Cookies.Add(authCookie);
                return RedirectToAction("TheKingsSecretChambers");
            }
            else
            {
                ViewBag.Message = "Incorrect credentials";
                return View();
            }

        }


        public ActionResult TheKingsSecretChambers()
        {

            //Informationerne i cookien kan findes i User.Identity
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Name = User.Identity.Name;
                return View();
            }
            else
            {
                return Content("How did you even get here!? ... Dont you ever come back");
            }

        }
        //Logger ud
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}
