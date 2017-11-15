using DMAISecureService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecureHostApp
{
    class Program
    {
  
        static void Main(string[] args)
        {
            //This will host both wsHttp and netTcp bindings of secureservice
            ServiceHost host = new ServiceHost(typeof(SecureService));
            //This will host both wsHttp and netTcp bindings of authservice
            ServiceHost authhost = new ServiceHost(typeof(AuthService));
            host.Open();
            Console.WriteLine("SecureService host is running...");
            authhost.Open();
            Console.WriteLine("AuthService is running");
            Console.ReadLine();
            host.Close();
            authhost.Close();

        }
    }
}
