using MVCDemo.RoomBookingServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
    public class BookingController : Controller
    {
        private RoomBookingServiceClient client = new RoomBookingServiceClient();
        // GET: Booking
        public ActionResult Index()
        {
            var items = client.GetAll();
            return View(items);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Booking booking)
        {
           
            client.Create(booking);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var toEdit = client.Get(id.Value);
            return View(toEdit);
        }
        [HttpPost]
        public ActionResult Edit(Booking booking)
        {
            client.Update(booking);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(client.Get(id.Value));
        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return View(client.Get(id.Value));
        }

        public ActionResult DeleteConfirmation(int? id)
        {
            if(id==null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            client.Delete(id.Value);
            return RedirectToAction("Index");
        }
    }
}