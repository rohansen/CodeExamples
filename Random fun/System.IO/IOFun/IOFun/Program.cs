using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace IOFun
{
    class Program
    {
        private static byte[] readBuffer = new byte[4096];
        private static int readCount = 0;
        static void Main(string[] args)
        {
            
            TcpClient client = new TcpClient("127.0.0.1", 89752);
            NetworkStream readStream = client.GetStream();
            BufferedStream str = new BufferedStream(readStream);
            while(str.Length > 0)
            {
                str.Read(readBuffer, 0, readBuffer.Length);
                Console.WriteLine(Encoding.UTF8.GetString(readBuffer));
                readCount++;
            }
            str.Flush();
            Console.ReadLine();
        }

    }
}
