using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NaiveClient
{
    class Program
    {
        private static Socket socket;
        private const short PORT = 6568;
        static void Main(string[] args)
        {

            Connect();
            while (true)
            {
                Console.WriteLine("Type Message");
                string message = Console.ReadLine();
                if (message.Length > 0)
                {
                    Console.Clear();
                    try
                    {
                        SendMessage(message);
                    }
                    catch (IOException ioex)
                    {
                        Console.WriteLine(ioex.Message);
                    }
                    catch (SocketException sex)
                    {
                        Console.WriteLine(sex.Message);
                    }
                }
            }
        }
        private static void Connect()
        {
            IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(x => x.AddressFamily == AddressFamily.InterNetwork).First();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipAddress, PORT);
        }
        private static void SendMessage(string message)
        {
            Console.WriteLine("Sending message\"{0}\" to: {1}", message, socket.RemoteEndPoint.ToString());

            if (message.Equals("quit"))
            {
                Disconnect(socket);
            }
            byte[] msg = Encoding.UTF8.GetBytes(message);
            int bytesSent = socket.Send(msg);
        }

        private static void Disconnect(Socket socket)
        {
            socket.Close();
            socket.Dispose();
            System.Environment.Exit(1);
        }
    }
}
