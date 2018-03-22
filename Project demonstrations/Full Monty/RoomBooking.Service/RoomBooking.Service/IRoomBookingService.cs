using RoomBooking.Exceptions;
using RoomBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RoomBooking.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IRoomBookingService
    {
        [OperationContract]
        [FaultContract(typeof(BookingExistsException))]
        void Create(Booking booking);
        [OperationContract]
        void Update(Booking booking);
        [OperationContract]
        void Delete(int id);
        [OperationContract]
        IEnumerable<Booking> GetAll();
        [OperationContract]
        Booking Get(int id);
    }

}
