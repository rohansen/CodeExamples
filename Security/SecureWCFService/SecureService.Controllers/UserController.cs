﻿using SecureService.DataAccess;
using SecureService.DataAccess.ADO.SQLServer;
using SecureService.DataAccess.Interfaces;
using SecureService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureService.Controllers
{
    //This is supposed to do some business logic
    //In this vertical example, not alot of validation is needed
    //You could consider doing preemptive validation on business models, and save the roundtrip to the WCF service
    public class UserController : IAuthorizeUserController<User>
    {
        private IDatabaseUserLogin<User> dbUser;
        public UserController(IDatabaseUserLogin<User> userData)
        {
            dbUser = userData;
        }

        public void Add(User entity)
        {
            dbUser.Add(entity);
        }

        public IEnumerable<User> Find(string query)
        {
            throw new NotImplementedException();
        }

        public User Get(int id)
        {
            return dbUser.Get(id);
        }
        public User Get(string email)
        {
            return dbUser.Get(email);
        }
        public User Login(string username, string password)
        {
            return dbUser.Login(username, password);
            
        }
        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }

    }
}
