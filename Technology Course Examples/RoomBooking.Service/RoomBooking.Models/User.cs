using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Models
{
    public class User
    {
        public User()
        {
            Bookings = new List<Booking>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
    }
}
