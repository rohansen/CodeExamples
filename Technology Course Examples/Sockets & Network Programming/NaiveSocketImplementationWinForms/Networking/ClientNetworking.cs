using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public class ClientNetworking
    {
        private Socket socket;
        private const short PORT = 6568;
     
        public void Connect()
        {
            IPAddress ipAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.Where(x => x.AddressFamily == AddressFamily.InterNetwork).First();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipAddress, PORT);
        }
        public void SendMessage(string message)
        {
            

            if (message.Equals("quit"))
            {
                Disconnect(socket);
            }
            byte[] msg = Encoding.UTF8.GetBytes(message);
            int bytesSent = socket.Send(msg);
        }

        public static void Disconnect(Socket socket)
        {
            socket.Close();
            socket.Dispose();
            System.Environment.Exit(1);
        }
    }
}
