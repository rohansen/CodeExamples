using SecureService.ServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
namespace SecureService.Hosts.ConsoleHost
{
   public class Program
    {
        static void Main(string[] args)
        {
            //This will host both wsHttp and netTcp bindings of secureservice
            ServiceHost host = new ServiceHost(typeof(SecureUserService));
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
