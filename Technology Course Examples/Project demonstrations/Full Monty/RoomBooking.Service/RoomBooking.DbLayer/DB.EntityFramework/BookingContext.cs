using RoomBooking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.DbLayer.DB.EntityFramework
{
    public class BookingContext : DbContext
    {
        public BookingContext():base("name=DefaultConnection"){        }

        public DbSet<Booking> Booking { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
