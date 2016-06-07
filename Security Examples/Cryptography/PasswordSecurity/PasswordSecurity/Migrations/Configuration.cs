namespace PasswordSecurity.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PasswordSecurity.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PasswordSecurity.ApplicationDbContext context)
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseAlways<ApplicationDbContext>());
            #region Code to add a new User to DB
            var newUsers = new List<User>();
            var usr = SecurityHelpers.CreateUser("ronni@hansen.dk", "1234");
            var usr2 = SecurityHelpers.CreateUser("1337gUrU@hax.dk", "a!1337_360HeadSh0t");
            var usr3 = SecurityHelpers.CreateUser("lise2006@sejhest.dk", "musse<3");
            var usr4 = SecurityHelpers.CreateUser("knud52@sol.dk", "password");
            newUsers.Add(usr);
            newUsers.Add(usr2);
            newUsers.Add(usr3);
            newUsers.Add(usr4);
            Console.WriteLine("Hashedandsalted : " + usr.PasswordHash);
            Console.WriteLine("Salt : " + usr.PasswordSalt);
            context.Users.AddRange(newUsers);
            context.SaveChanges();
            #endregion
        }
    }
}
