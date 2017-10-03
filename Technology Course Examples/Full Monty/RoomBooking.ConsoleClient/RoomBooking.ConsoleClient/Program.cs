using RoomBooking.ConsoleClient.RoomBookingServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomBookingServiceClient client = new RoomBookingServiceClient();
            var booking = new Booking();
            booking.StartTime = new DateTime(2017, 9, 27, 14, 00, 00);
            booking.EndTime = new DateTime(2017, 9, 27, 15, 00, 00);
            booking.RoomId = 1;
            booking.UserId = 1;
            client.Book(booking);
        }
    }
}
