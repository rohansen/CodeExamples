using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static Socket socket;
        private static Thread t;
        static void Main(string[] args)
        {
            Console.WriteLine("press any key to connect");
            Console.ReadLine();
            StartClient();

        }
        private static int amountOfRetries = 0;
        private static void StartClient()
        {

            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect("localhost", 6689);
            }
            catch (SocketException sex)
            {
                Console.WriteLine(sex.Message);

            }

            if (socket.Connected)
            {
                t = new Thread(Recieve);
                t.Start();
            }


            while (socket.Connected)
            {

                Console.WriteLine("Enter message to send");
                string messageToSend = Console.ReadLine();
                if (messageToSend == "q")
                {
                    socket.Disconnect(true);
                    t.Abort();//i know. i know. just making sure for this example
                    break;
                }
                else
                {
                    socket.Send(Encoding.Unicode.GetBytes(messageToSend));
                }

            }
        }

        private static void Recieve()
        {
            byte[] recieveBuffer = new byte[socket.ReceiveBufferSize];
            while (socket.Connected)
            {
                int amountRecieved = socket.Receive(recieveBuffer, 0, socket.ReceiveBufferSize, 0);

                byte[] actualDataRecieved = new byte[amountRecieved];
                Array.Copy(recieveBuffer, actualDataRecieved, amountRecieved);
                Console.WriteLine(Encoding.Unicode.GetString(actualDataRecieved));
            }
        }
    }
}
