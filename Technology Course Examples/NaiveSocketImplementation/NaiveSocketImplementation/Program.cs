using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace NaiveSocketImplementation
{
    class Program
    {

        private const short PORT = 6568;
        private static TcpListener listener;
        static void Main(string[] args)
        {
            TcpClient tcpclient = ListenForClient();
            try
            {
                ReadDataFromClient(tcpclient);
            }
            catch (IOException ioex)
            {
                Console.WriteLine("Ex1: " + ioex.Message);
            }
            catch (SocketException sex)
            {
                Console.WriteLine("Ex2: " + sex.Message);
            }
            finally
            {
                CloseConnection(tcpclient);
            }

        }

        private static void ReadDataFromClient(TcpClient tcpclient)
        {
            var nwStream = tcpclient.GetStream();
            var buffer = new byte[4096];
            int i = 0;
            string message = "";
            while ((i = nwStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                message = Encoding.UTF8.GetString(buffer, 0, i);
                Console.WriteLine("Recieved {0}", message);
            }
        }
        private static TcpClient ListenForClient()
        {
            listener = new TcpListener(IPAddress.Any, PORT);
            Console.WriteLine("Listening on port: {0}", PORT);
            listener.Start();
            return listener.AcceptTcpClient();
        }

        private static void CloseConnection(TcpClient client)
        {
            client.Close();
            listener.Stop();
            client = null;
            listener = null;

        }
    }
}
