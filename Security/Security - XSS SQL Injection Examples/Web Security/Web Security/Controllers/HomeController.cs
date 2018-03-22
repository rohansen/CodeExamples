using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_Security.Models;

namespace Web_Security.Controllers
{

    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index()
        {
            
            var model = db.SystemUsers.ToList();
            return View(model);
        }
        //Opret bruger, XSS sårbarhed
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SystemUser user)
        {
            
            db.SystemUsers.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }
        //Opret bruger SQL Injection Sårbarhed
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create2([Bind(Include ="UserName, Password")]SystemUser user)
        {
            

            string sql = "INSERT INTO SystemUsers(UserName, Password, Role) VALUES ('"+user.UserName + "','" + user.Password + "', 'SystemUser')";  //SystemUser = Role as String
            
            var users = db.Database.ExecuteSqlCommand(System.Data.Entity.TransactionalBehavior.DoNotEnsureTransaction,sql,null);
            return RedirectToAction("Index");
        }
        public ActionResult Create2()
        {
            return View();
        }
        //Vis brugere - SQL Injection sårbarhed
        [HttpPost]
        public ActionResult ShowSystemUserInformation(string username, string password)
        {
            
            string sql = "SELECT * FROM SystemUsers Where UserName = '" + username + "' AND Role='Admin' AND Password = '" + password + "'";
            var users = db.Database.SqlQuery<SystemUser>(sql);
            if (users.Any())
            {
                var allSystemUsers = db.Database.SqlQuery<SystemUser>("SELECT * FROM SystemUsers");
                return View(allSystemUsers);
            }
            TempData["Message"] = "Du har ikke rettigheder til at hente alle brugere";
            return RedirectToAction("Index");
        }


        public ActionResult OverPostingEdit(int id)
        {
            
            var oldSystemUser = db.SystemUsers.Find(id);
            return View(oldSystemUser);
        }

        [HttpPost]
        public ActionResult OverPostingEdit(SystemUser user)
        {
            
            db.Entry(user).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return View();
        }


        //[Bind(Include = "SystemUserId, Name, Password")]

    }
}