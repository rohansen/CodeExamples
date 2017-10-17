using SqlInjectionExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
namespace SqlInjectionExample.Controllers
{

    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Posts
        public ActionResult Index()
        {
            var posts = db.Posts.ToList();
            return View(posts);
        }

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        //Used for CSRF AND  XSS
        [HttpGet]
        
        public ActionResult AddPoint(string userid)
        {
            var myId = User.Identity.GetUserId();
            if (myId == userid)
            {
                TempData["Message"] = "You cannot give yourself points";
            }else
            {
                var user = db.Users.Find(userid);
                user.Points++;
                db.SaveChanges();

            }
            return RedirectToAction("Index");
        }
        //Used for CSRF AND  XSS

        [Authorize]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Post post)
        {
            post.UserId = User.Identity.GetUserId();
            db.Posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}