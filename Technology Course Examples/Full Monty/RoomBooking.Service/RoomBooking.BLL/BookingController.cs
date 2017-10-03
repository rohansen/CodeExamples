using RoomBooking.DbLayer;
using RoomBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.BLL
{
    public class BookingController : IController<Booking>
    {
        private IDbCRUD<Booking> dbCrud;
        public BookingController()
        {
            dbCrud = new DbBooking();
        }
        public void Create(Booking entity)
        {
            if(entity.StartTime > entity.EndTime)
            {
                throw new FaultException<ArgumentException>(new ArgumentException("Start time is after end time"));
            }
            dbCrud.Create(entity);
        }

        public void Delete(int id)
        {
            dbCrud.Delete(id);
        }

        public Booking Get(int id)
        {
            return dbCrud.Get(id);
        }

        public IEnumerable<Booking> GetAll()
        {
            return dbCrud.GetAll();
        }

        public void Update(Booking entity)
        {
            dbCrud.Update(entity);
        }
    }
}
