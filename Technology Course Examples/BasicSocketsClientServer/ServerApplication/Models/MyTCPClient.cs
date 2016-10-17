using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Models
{
    public class MyTcpClient
    {
        public int ClientId { get; set; }
        public TcpClient TcpClient { get; set; }
    }
}
