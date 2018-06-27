using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MultiServiceProblem
{
 public class program
    {
        static void Main()
        {
            ServiceHost host = new ServiceHost(typeof(Service1));
            ServiceHost host2 = new ServiceHost(typeof(Service2));
            host.Open();
            host2.Open();
            Console.WriteLine("Service Running");
            Console.ReadLine();

            host.Close();
            host2.Close();
            ((IDisposable)host).Dispose();
            ((IDisposable)host2).Dispose();



        }
    }
}
