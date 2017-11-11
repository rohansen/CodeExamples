
//using SecureClient.SecureServiceReference;
using SecureClient.InSecureServiceReference;
using SecureClient.SecureServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecureClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var client = new SecureServiceClient("WSHttpBinding_ISecureService");
            //var client = new SecureServiceClient("NetTcpBinding_ISecureService");
            //var client = new InSecureServiceClient("BasicHttpBinding_IInSecureService");
            //var client = new InSecureServiceClient("NetTcpBinding_IInSecureService");

            //Remove the certificate authority validation --> dont do this in production
            ServicePointManager.ServerCertificateValidationCallback = (obj, certificate, chain, errors) => true;
            //Communicate credentials with every request to the web service
            //Unfortunate, but otherwise we would need another scheme. eg tokenbased auth
            //In your web application, you will store the credentials in memory, this is also problematic, however we will have to make do for now

            client.ClientCredentials.UserName.UserName = "roh@ucn.dk";
            client.ClientCredentials.UserName.Password = "1234";

            try
            {
                client.Open();
                while (true)
                {
                    try
                    {
                        var input = Convert.ToInt32(Console.ReadLine());

                        var response = client.GetData(input);
                       // var response = client.DoSomethingInsecure(input.ToString());
                        Console.WriteLine(response);

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Incorrect input.. valid values er int.MinValue to int.MaxValue");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                if(e.InnerException!=null)
                    Console.WriteLine(e.InnerException.Message);
                
            }
            
        }
    }
}
