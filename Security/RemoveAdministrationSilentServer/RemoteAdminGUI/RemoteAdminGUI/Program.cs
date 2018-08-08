using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteAdminGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect("127.0.0.1", 8099);
            while (true)
            {
                Console.WriteLine("Enter cmd");
                string cmd = Console.ReadLine();
                clientSocket.Send(Encoding.ASCII.GetBytes(cmd));
                
            }
            //clientSocket.Disconnect(false);
            //clientSocket.Close();
        }
    }
}
