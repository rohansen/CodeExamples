using BusinessLogicLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Database
{
    public class DrinkSystemContext : DbContext
    {
        public DrinkSystemContext() : base("Name=ConnectionStringFoundInConfigFile")
        {

        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
