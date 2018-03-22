using RoomBooking.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking.ServiceHosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(RoomBookingService));
            host.Open();
            Console.WriteLine("Host is running on: " + host.BaseAddresses.First());
            Console.ReadLine();
        }
    }
}
