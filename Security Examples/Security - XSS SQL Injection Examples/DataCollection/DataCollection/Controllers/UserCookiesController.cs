using DataCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DataCollection.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserCookiesController : ApiController
    {
        // GET: api/UserCookies
        private ApplicationDbContext db = new ApplicationDbContext();
        public IEnumerable<UserCookies> Get()
        {
            return db.UserCookies.ToArray();
        }

        // GET: api/UserInputData/5
        public UserCookies Get(int id)
        {
            return db.UserCookies.Find(id);
        }

        // POST: api/UserInputData
        public void Post([FromBody]UserCookies value)
        {
            db.UserCookies.Add(value);
            db.SaveChanges();
        }

        // PUT: api/UserInputData/5
        public void Put(int id, [FromBody]UserCookies value)
        {
            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

        }

        // DELETE: api/UserInputData/5
        public void Delete(int id)
        {
            var toRemove = db.UserCookies.Find(id);
            db.UserCookies.Remove(toRemove);
            db.SaveChanges();
        }
    }
}
