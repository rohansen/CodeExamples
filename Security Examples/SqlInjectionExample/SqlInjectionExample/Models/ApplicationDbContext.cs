namespace SqlInjectionExample.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationDbContext : DbContext
    {
        // Your context has been configured to use a 'ApplicationDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SqlInjectionExample.Models.ApplicationDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ApplicationDbContext' 
        // connection string in the application configuration file.
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PasswordEntry> PasswordEntries { get; set; }

        public System.Data.Entity.DbSet<SqlInjectionExample.Models.Post> Posts { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}