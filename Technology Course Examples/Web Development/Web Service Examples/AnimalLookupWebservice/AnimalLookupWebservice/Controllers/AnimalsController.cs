using AnimalLookupWebservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.Entity;
namespace AnimalLookupWebservice.Controllers
{
    public class AnimalsController : ApiController
    {
        private AnimalContext db = new AnimalContext();
        public IEnumerable<Animal> Get()
        {
            return db.Animals.Include(x=>x.Location).ToList();
        }

        public Animal Get(int id)
        {
            return db.Animals.Find(id);
        }

        public void Post(Animal animal)
        {
            db.Animals.Add(animal);
            db.SaveChanges();
        }

        public void Put(Animal animal)
        {
            db.Entry(animal).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var animalToDelete = new Animal { AnimalId = id };
            db.Entry(animalToDelete).State = EntityState.Deleted;
            db.SaveChanges();
        }
    }
}
