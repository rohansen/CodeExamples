using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SqlInjectionExample.Models;
using Microsoft.AspNet.Identity;
namespace SqlInjectionExample.Controllers
{
    [Authorize]
    public class PasswordEntriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PasswordEntries
        public ActionResult Index()
        {
            var currentUserId =User.Identity.GetUserId();
            var passwordEntries = db.PasswordEntries.Include(p => p.User).Where(x=>x.UserId==currentUserId);
            return View(passwordEntries.ToList());
        }

        // GET: PasswordEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PasswordEntry passwordEntry = db.PasswordEntries.Find(id);
            if (passwordEntry == null)
            {
                return HttpNotFound();
            }
            return View(passwordEntry);
        }

        // GET: PasswordEntries/Create
        public ActionResult Create()
        {
         
            return View();
        }

        // POST: PasswordEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Url,Title,Password,Note,UserId")] PasswordEntry passwordEntry)
        {
            passwordEntry.UserId = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                db.PasswordEntries.Add(passwordEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", passwordEntry.UserId);
            return View(passwordEntry);
        }

        // GET: PasswordEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PasswordEntry passwordEntry = db.PasswordEntries.Find(id);
            if (passwordEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", passwordEntry.UserId);
            return View(passwordEntry);
        }
        // GET: PasswordEntries/Edit/5
        public ActionResult Search(string Search)
        {
            var userid = User.Identity.GetUserId();
            var foundpws = db.Database.SqlQuery<PasswordEntry>("SELECT * FROM PasswordEntries WHERE (Title LIKE '%"+Search+"%' OR Note LIKE ' %"+Search+ "%') AND UserId = '" + userid + "'");
 
            if (!foundpws.Any())
            {
                ViewBag.Message = "Nothing found...";
                return View("Index", new List<PasswordEntry>());
            }
            return View("Index",foundpws);
        }

        // POST: PasswordEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Url,Title,Password,Note,UserId")] PasswordEntry passwordEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(passwordEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "Email", passwordEntry.UserId);
            return View(passwordEntry);
        }

        // GET: PasswordEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PasswordEntry passwordEntry = db.PasswordEntries.Find(id);
            if (passwordEntry == null)
            {
                return HttpNotFound();
            }
            return View(passwordEntry);
        }

        // POST: PasswordEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PasswordEntry passwordEntry = db.PasswordEntries.Find(id);
            db.PasswordEntries.Remove(passwordEntry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {

            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
