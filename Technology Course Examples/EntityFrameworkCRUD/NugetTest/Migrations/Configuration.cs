namespace NugetTest.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NugetTest.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NugetTest.Models.ApplicationDbContext context)
        {
                      
            var entitiesToAdd = new List<User>();
            for (int i = 0; i < 30; i++)
            {
                entitiesToAdd.Add(new User
                {
                    Age = i + 5,
                    Email = $"User{i}@ucn.dk",
                    Password = $"Pw{i}{i + 1}{i + 2}{i + 3}",
                    SecurityQuestion = $"BLANK{i}"
                });

            }
            //Seeding some random users into the DB, if they do not already exist
            context.Users.AddOrUpdate(x => x.Email, entitiesToAdd.ToArray());
        }
    }
}
