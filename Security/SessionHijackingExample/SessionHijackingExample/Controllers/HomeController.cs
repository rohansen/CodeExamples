using SessionHijackingExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionHijackingExample.Controllers
{
    public class HomeController : Controller
    {
        //How to use:
        //Upload the web application to another server
        //Try to log in with incorrect credentials
        //Either use wireshark to sniff the session id when a user logs in on the local network, or log in with remote desktop, and copy the session id from 
        //the other machine, paste it into the session value on you local machine in "Application" tab in chrome, then try the safe area again
        //This should simulate that the session id was sniffed, and put into a browser -----my machine doesnt have the sniffing hardware
        public ActionResult Index()
        {
            return View();
        }
        string sessionName = "LoggedInUser";
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(SystemUser user)
        {
            if(!IsCredentialsValid(user)){
                TempData["Message"] = "Not authorized to view requested page";
                return RedirectToAction("Index");
            }else
            {
                Session[sessionName] = new SystemUser { Username = user.Username, Password = user.Password };
               return  RedirectToAction("VerySecureSite");
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return View();
        }

        public ActionResult VerySecureSite()
        {
            SystemUser user = Session[sessionName] as SystemUser;
            if (IsCredentialsValid(user))
            {
                return View(user);
            }else
            {
                TempData["Message"] = "Not authorized to view requested page";
                return RedirectToAction("Index");
            }
        }

        public bool IsCredentialsValid(SystemUser user)
        {
            if (user == null) return false;
            return user.Username == "roh" && user.Password == "1234";
        }
    }
}