using SimpleNoteKeeper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleNoteKeeper.Controllers
{
    public class NoteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var notes = db.Notes.ToList();
            return View(notes);
        }
    
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Note note)
        {
            db.Notes.Add(note);
            db.SaveChanges();
            return View();
        }

        [HttpPost]
        public ActionResult CreateAjax(string txtNote, int txtCategoryId)
        {
            Note note = new Note();
            note.CategoryId = txtCategoryId;
            note.NoteText = txtNote;
            db.Notes.Add(note);
            db.SaveChanges();
            note.Category = db.Categories.Find(txtCategoryId);
            return PartialView(note);
        }

        public ActionResult Delete(int id)
        {
            var noteToDelete = db.Notes.Find(id);

            return View(noteToDelete);
        }
        [HttpPost]
        public ActionResult DeleteConfirmation(Note note)
        {
            var toDelete = db.Notes.Find(note.NoteId);
            db.Notes.Remove(toDelete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var toEdit = db.Notes.Find(id);
            return View(toEdit);
        }
        [HttpPost]
        public ActionResult Edit(Note note)
        {
            db.Entry(note).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}