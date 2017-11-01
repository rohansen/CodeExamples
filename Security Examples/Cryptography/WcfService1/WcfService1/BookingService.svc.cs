using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.


    public class Service1 : IBookingService
    {
        public void Create(Equipment equipment)
        {
            //Send videre til control layer, som gemmer i Db
        }

        public void EditEquipment(Equipment equipment)
        {
            //Gem equipment i database
        }

        public Booking Get(int id)
        {
            return new WcfService1.Booking { Id = id,
                EndTime = DateTime.Now.AddDays(1),
                StartTime = DateTime.Now,
                Equipment = new Equipment { Id = id, Title = "Plæneklipper", Price=1000.0 } };
        }

        public IEnumerable<Booking> GetAll()
        {
            List<Booking> allBookings = new List<Booking>();
            for (int i = 1; i <= 10; i++)
            {
                allBookings.Add(new WcfService1.Booking
                {
                    Id = i,
                    EndTime = DateTime.Now.AddDays(1),
                    StartTime = DateTime.Now,
                    Equipment = new Equipment { Id = i, Title = "Plæneklipper " + i, Price=i*50 }
                });
            }

            return allBookings;
        }

        public IEnumerable<Equipment> GetAllEquipments()
        {
            List<Equipment> allEquipments = new List<Equipment>();
            for (int i = 0; i < 10; i++)
            {
                allEquipments.Add(new Equipment { Id = i, Title = "Plæneklipper " });
            }
            return allEquipments;
        }

        public Equipment GetEquipment(int id)
        {
            return new Equipment { Id = id, Title = "Plæneklipper" };
        }
    }
}
