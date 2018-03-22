using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketServer
{
    public class MySocketClient
    {
        public MySocketClient(string name, Socket clientSocket)
        {
            Id = Guid.NewGuid().ToString();
            ClientSocket = clientSocket;
            Name = name;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public Socket ClientSocket { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
