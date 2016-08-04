namespace AnimalLookupWebservice.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AnimalContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Location> Locations { get; set; }
        public AnimalContext()
            : base("name=DefaultConnectionString")
        {
        }

    }

}