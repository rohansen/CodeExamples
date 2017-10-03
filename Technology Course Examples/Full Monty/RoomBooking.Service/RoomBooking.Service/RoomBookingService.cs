using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using RoomBooking.Models;
using RoomBooking.BLL;

namespace RoomBooking.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class RoomBookingService : IRoomBookingService
    {
        private IController<Booking> bookingCtrl;
        public RoomBookingService()
        {
            bookingCtrl = new BookingController();
        }
        public void Create(Booking booking)
        {
            bookingCtrl.Create(booking);
        }

        public void Delete(int id)
        {
            bookingCtrl.Delete(id);
        }

        public Booking Get(int id)
        {
            return bookingCtrl.Get(id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return bookingCtrl.GetAll();
        }

        public void Update(Booking booking)
        {
            bookingCtrl.Update(booking);
        }
    }
}
