using DataCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Data.Entity;
namespace DataCollection.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserInputDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<UserInputData> Get()
        {
            return db.UserInputData.Include(x=>x.Element).ToArray();
        }

        // GET: api/UserInputData/5
        public UserInputData Get(int id)
        {
            return db.UserInputData.Include(x => x.Element).Where(x=>x.UserInputDataId==id).FirstOrDefault();
        }

        // POST: api/UserInputData
        public void Post([FromBody]UserInputData value)
        {
            db.UserInputData.Add(value);
            db.SaveChanges();
        }

        // PUT: api/UserInputData/5
        public void Put(int id, [FromBody]UserInputData value)
        {
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            
        }

        // DELETE: api/UserInputData/5
        public void Delete(int id)
        {
            var toRemove = db.UserInputData.Find(id);
            db.UserInputData.Remove(toRemove);
            db.SaveChanges();
        }
    }
}
