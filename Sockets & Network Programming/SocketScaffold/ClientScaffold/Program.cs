using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientScaffold
{
    class Program
    {
        private static Socket socket;
        private static Thread t;
        static void Main(string[] args)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //This method call will block untill a connection is accepted
            Console.WriteLine("Press key to connect");
            Console.ReadLine();
            socket.Connect("localhost", 6689);
            //Start up a Thread ti keep receiving data "in the background"
            t = new Thread(Recieve);
            t.Start();
            while (true)
            {
                Console.WriteLine("Enter message to send");
                string messageToSend = Console.ReadLine();
                Send(messageToSend); 
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
        private static void Send(string message)
        {
            
                if (message == "q")
                {
                    socket.Disconnect(true);
                    t.Abort();//i know. i know. just making sure for this example
                    System.Environment.Exit(0);//Quit
                }
                else
                {
                    socket.Send(Encoding.Unicode.GetBytes(message));
                }

            
        }


    }
}
