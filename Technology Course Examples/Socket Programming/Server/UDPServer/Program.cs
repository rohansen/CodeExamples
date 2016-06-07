using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPServer
{
    class Program
    {

        private static UdpClient listener;
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Start();
        }

        private static void Start()
        {
            listener = new UdpClient(1339);
            Console.WriteLine("Listening...");

            StartAccept();



        }

        private static void StartAccept()
        {
            while (true)
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 1339);
                byte[] recievedBytes = listener.Receive(ref ep);
                var recievedData = Encoding.ASCII.GetString(recievedBytes, 0, recievedBytes.Length);
                Console.WriteLine(recievedData);
            }
        }
        //private static void HandleAsyncConnection(IAsyncResult res)
        //{
        //    StartAccept(); //listen for new connections again
        //    TcpClient client = listener.EndAcceptTcpClient(res);

        //    try
        //    {
        //        // Program is suspended while waiting for an incoming connection.
        //        IPEndPoint ipe = (IPEndPoint)listener.LocalEndpoint;
        //        //listener.BeginAcceptTcpClient();
        //        //Console.WriteLine("Someone has connected: " + Dns.GetHostEntry(ipe.Address).HostName);
        //        NetworkStream nws = client.GetStream();
        //        // An incoming connection needs to be processed.

        //        while (true)
        //        {
        //            string data = null;
        //            byte[] bytes = new byte[1024];
        //            int i;

        //            // Loop to receive all the data sent by the client. 
        //            while ((i = nws.Read(bytes, 0, bytes.Length)) != 0)
        //            {
        //                // Translate data bytes to a ASCII string.
        //                data = Encoding.UTF8.GetString(bytes, 0, i);
        //                Console.WriteLine("Received: {0}", data);

        //                byte[] themsg = Encoding.UTF8.GetBytes(data);

        //                // Send back a response.
        //                //nws.Write(themsg, 0, themsg.Length);
        //                //Console.WriteLine("Sent back: {0}", data);
        //                if (data.Equals("quit"))//quit cmd stops the server
        //                {
        //                    client.Close();
        //                    listener.Stop();

        //                    System.Environment.Exit(1);
        //                }

        //            }


        //        }
        //    }
        //    catch (ArgumentNullException argn)
        //    {
        //        Console.WriteLine(argn.Message);
        //        Console.ReadLine();
        //    }
        //    catch (SocketException sex)
        //    {
        //        Console.WriteLine(sex.Message);
        //        Console.ReadLine();
        //    }
        //    catch (ObjectDisposedException ode)
        //    {
        //        Console.WriteLine(ode.Message);
        //        Console.ReadLine();
        //    }
        //    catch (System.Security.SecurityException sec)
        //    {
        //        Console.WriteLine(sec.Message);
        //        Console.ReadLine();
        //    }

        //}
    }
}
