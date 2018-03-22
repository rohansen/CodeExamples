using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Shared;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using MongoDBExample.Models;

namespace MongoDBExample.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult ListPersons()
        {
            var server = ConnectAndGetServer();
            var database = server.GetDatabase("MongoTestSystem");
            var collection = database.GetCollection<Person>("Persons");

            var list = collection.AsQueryable()
                .Where(x=>x.FirstName=="Finn")
                .ToList();
            return View(list);
        }

        public MongoServer ConnectAndGetServer()
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            return client.GetServer();
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(Person person)
        {
            var connectionString = "mongodb://localhost";
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            var database = server.GetDatabase("MongoTestSystem");
            var collection = database.GetCollection<Person>("Persons");
            collection.Insert(person);
            
            return RedirectToAction("ListPersons");
        }
    }
}