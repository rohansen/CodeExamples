using RoomBooking.DbLayer;
using RoomBooking.DbLayer.Interfaces;
using RoomBooking.Exceptions;
using RoomBooking.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace RoomBooking.DbLayer.DB.EntityFramework
{
    public class DbBookingEntityFramework : IDbCRUD<Booking>
    {
        
        public void Create(Booking entity)
        {
            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.Serializable };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, to))
            {
                using (BookingContext db = new BookingContext())
                {
                    var amountOfBookings = db.Booking.Count(x => x.StartTime <= entity.StartTime && x.EndTime >= entity.EndTime);
                    if (amountOfBookings == 0)
                    {
                        db.Booking.Add(entity);
                        db.SaveChanges();
                    }else
                    {
                        Trace.TraceInformation($"User {entity.UserId} tried to book something that was already booked");
                        Trace.Flush();
                        throw new FaultException<BookingExistsException>(new BookingExistsException("Booking exists at that time"));
                    }
                  
                }
                scope.Complete();
            }
        }

        public void Delete(int id)
        {
            using (BookingContext db = new BookingContext())
            {
                Booking b = new Booking { Id = id };
                db.Entry(b).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public Booking Get(int id)
        {
            Booking current;
            using (BookingContext db = new BookingContext())
            {
                return db.Booking.FirstOrDefault(x => x.Id == id);

            }
        }
        public IEnumerable<Booking> GetAll()
        {
       
            using (BookingContext db = new BookingContext())
            {
                return db.Booking.ToList();
            }
        }

        public void Update(Booking entity)
        {

            TransactionOptions to = new TransactionOptions { IsolationLevel = IsolationLevel.Serializable };
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.RequiresNew, to))
            {
                using (BookingContext db = new BookingContext())
                {
                    var amountOfBookings = db.Booking.Count(x => x.StartTime <= entity.StartTime && x.EndTime >= entity.EndTime);
                    if (amountOfBookings == 0)
                    {
                        db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    else
                    {
                        Trace.TraceInformation($"User {entity.UserId} tried to rebook something at a time that was already booked");
                        Trace.Flush();
                        throw new FaultException<BookingExistsException>(new BookingExistsException("Booking exists at that time"));
                    }

                }
                scope.Complete();
            }
        }
    }
}
