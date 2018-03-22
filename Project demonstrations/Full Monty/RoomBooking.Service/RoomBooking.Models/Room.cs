using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.Models
{
    public class Room
    {
        public Room()
        {
            Bookings = new List<Booking>();
        }
        public int Id { get; set; }
        public int Size { get; set; }
        public string Title { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
    }
}
