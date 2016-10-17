using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientApplication
{
    class Program
    {
        private const int SERVER_PORT = 8888;
        private static IPEndPoint remoteEndpoint = new IPEndPoint(new IPAddress(new byte[]{192,168,1,34}), SERVER_PORT);
        private static Socket connection = new Socket(SocketType.Stream,ProtocolType.Tcp);
        static void Main(string[] args)
        {
            ConnectToServer();
            Console.WriteLine("Connection established: " + connection.Connected);
            Console.WriteLine("Type something..");
            
            do
            {
                
                string inputString = Console.ReadLine();
                switch (inputString)
                {
                    case "help":
                        Console.WriteLine("type direction -from- -to-, to get the distance of the addresses");
                        Console.WriteLine("type weather -city- to get the weather in the city");
                        Console.WriteLine("type start -program- to start a program on the server");
                        Console.WriteLine("type process -containingtext- to get the processes running on the server");
                        Console.WriteLine("type \"move cursor\" to move the cursor randomly on the server");
                        Console.WriteLine("type person -firstname- -lastname- -birthday- to to add er person");
                        break;
                    case "cls":
                        Console.Clear();

                        break;
                    default:
                        SendMessage(inputString);
                        break;
                }
            } while (true);

        }

        public static void ConnectToServer()
        {
            connection.Connect(remoteEndpoint);

            Thread t = new Thread(new ThreadStart(RecieveMessages));
            t.Start();
        }

        public static void RecieveMessages()
        {
            NetworkStream nws = new NetworkStream(connection);
            byte[] readBuffer = new byte[connection.ReceiveBufferSize];
            byte[] sendBuffer = new byte[connection.SendBufferSize];
            string recievedData = "";
            int streamSize = -1;
            while (connection.Connected)
            {
                while ((streamSize = nws.Read(readBuffer, 0, readBuffer.Length)) != 0)
                {
                    recievedData = Encoding.UTF8.GetString(readBuffer, 0, streamSize);
                    Console.WriteLine("Message Recieved: " + recievedData);

                }
            }
        }

        public static void SendMessage(string message)
        {
            connection.Send(Encoding.UTF8.GetBytes(message));
        }
    }
}
