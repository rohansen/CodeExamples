using AuthenticationTest;
using System;
using System.Collections.Generic;
using System.IdentityModel.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHosting
{
    class Program
    {
        static void Main(string[] args)
        {

            using (ServiceHost host = new ServiceHost(typeof(SecureService)))
            {
                foreach (var hostedEndpoint in host.BaseAddresses)
                {
                    Console.WriteLine(hostedEndpoint.AbsoluteUri);
                    Console.WriteLine(hostedEndpoint.LocalPath);
                }

                host.Open();
                Console.WriteLine(host.State);
                //Do readline here--> if you exit the using block, the connection is closed
                Console.WriteLine("Listening");
                Console.ReadLine();
            }
            //Could start this in another thread
            //using (ServiceHost host = new ServiceHost(typeof(InSecureService)))
            //{
            //    host.Open();
            //}
        

        }

    }
}
