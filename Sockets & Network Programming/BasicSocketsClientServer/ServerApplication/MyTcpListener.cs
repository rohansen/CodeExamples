using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication
{
    public class MyTcpListener : TcpListener
    {
        public MyTcpListener(IPEndPoint localEP) : base(localEP)
        {

        }

        public MyTcpListener(IPAddress localaddr, int port) : base(localaddr, port)
        {
        }

        public MyTcpListener(int port) : base(port)
        {
        }

        
    }
}
