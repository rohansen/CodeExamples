using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static Socket sender;
        private static Random rnd;
        public static void Disconnect(Socket sender)
        {
            
            
            sender.Close();
            sender.Dispose();
            System.Environment.Exit(1);
        }

        static void CurrentDomain_ProcessExit(object s, EventArgs e)
        {
            
            Disconnect(sender);
        }

        public static void SendMessage(string message)
        {

            IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(x => x.AddressFamily == AddressFamily.InterNetwork).First();
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1339);
            // Create a TCP/IP  socket.
            sender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sender.Connect(remoteEP);
            Console.WriteLine("Sending message\"{0}\" to: {1}", message, sender.RemoteEndPoint.ToString());
            byte[] bytes = new byte[1024];
            if (message.Equals("random"))
            {
                
                rnd.NextBytes(bytes);
                int bytesSent = sender.Send(bytes);
            }
            else
            {
                byte[] msg = Encoding.UTF8.GetBytes(message);
                int bytesSent = sender.Send(msg);
            }
            

            if (message.Equals("quit"))
            {
                Disconnect(sender);
            }

        }

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            rnd = new Random();

            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.WriteLine("Client App - Type message");
                string message = Console.ReadLine();

                if (message.Length > 0)
                {
                    Console.Clear();
                    SendMessage(message);
                }
            }


        }
    }
}
