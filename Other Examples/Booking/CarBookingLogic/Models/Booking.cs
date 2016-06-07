using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingLogic.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        /// <summary>
        /// The unit to be booked
        /// </summary>
        public Unit Unit { get; set; }
        /// <summary>
        /// The Customer whom books a Unit
        /// </summary>
        public Customer Customer { get; set; }
        public Booking() { }
        public Booking(Unit unit, Customer customer)
        {
            Unit = unit;
            Customer = customer;
        }

        public void Book(Unit unit)
        {
            Unit = unit;
        }
    }
}
