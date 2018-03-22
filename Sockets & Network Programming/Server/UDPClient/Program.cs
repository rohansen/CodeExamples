using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDPClient
{
    class Program
    {
        public static void Disconnect(Socket sender)
        {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
            sender.Dispose();
            System.Environment.Exit(1);
        }

        public static void SendMessage(string message)
        {
            //Connection code
            // Establish the remote endpoint for the socket.
            // This example uses port 11000 on the local computer.
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[3];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1339);

            // Create a TCP/IP  socket.
            Socket sender = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);
            
            //NO REMOTE ENDPOINT....
            //sender.Connect(remoteEP); <-- no connection - UDP
    


            byte[] bytes = new byte[1024];
            // Encode the data string into a byte array.
            byte[] msg = Encoding.UTF8.GetBytes(message);
            // Send the data through the socket.
            int bytesSent = sender.SendTo(msg,remoteEP);
            if (message.Equals("quit"))
            {
                //if quit has been sent, do not try and read a response
               // Disconnect(sender);

            }
            //else
            //{
            //    //If the command sent is not a disconnect command, read the servers Echo response
            //    // Receive the response from the remote device.

            //    int bytesRec = sender.Receive(bytes);
            //    Console.WriteLine("Server response was: {0}",
            //        Encoding.UTF8.GetString(bytes, 0, bytesRec));
            //}
        }

        static void Main(string[] args)
        {

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
