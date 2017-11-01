namespace NugetTest.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ApplicationDbContext : DbContext
    {
   
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }

}