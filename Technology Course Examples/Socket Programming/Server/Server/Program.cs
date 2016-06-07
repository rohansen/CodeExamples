using ChatLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        public static List<User> OnlineUsers { get; set; }
        private static TcpListener listener;
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            OnlineUsers = new List<User>();
            Start();
        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            listener.Stop();
        }

        private static void Start()
        {
            listener = new TcpListener(IPAddress.Any, 1339);
            listener.Start();
            Console.WriteLine("Listening...");
            StartAccept();
            Console.ReadLine();
        }

        private static void StartAccept()
        {
            listener.BeginAcceptTcpClient(HandleAsyncConnection, listener);
        }
        private static void HandleAsyncConnection(IAsyncResult res)
        {
            StartAccept(); //listen for new connections again
            TcpClient client = listener.EndAcceptTcpClient(res);
            
            try
            {
                // Program is suspended while waiting for an incoming connection.
                IPEndPoint ipe = (IPEndPoint)listener.LocalEndpoint;
                NetworkStream nws = client.GetStream();

                while (true)
                {
                    string data = null;
                    byte[] bytes = new byte[1024];
                    int i;

                    // Loop to receive all the data sent by the client. 
                    while ((i = nws.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = Encoding.UTF8.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        //byte[] themsg = Encoding.UTF8.GetBytes(data);
                        if (data.Equals("quit"))//quit cmd stops the server
                        {
                            client.GetStream().Close();
                            client.Close();
                            listener.Stop();
                            System.Environment.Exit(1);
                        }

                    }

                   
                }
            }
            catch (ArgumentNullException argn)
            {
                Console.WriteLine(argn.Message);
                Console.ReadLine();
            }
            catch (SocketException sex)
            {
                Console.WriteLine(sex.Message);
                Console.ReadLine();
            }
            catch (ObjectDisposedException ode)
            {
                Console.WriteLine(ode.Message);
                Console.ReadLine();
            }
            catch (System.Security.SecurityException sec)
            {
                Console.WriteLine(sec.Message);
                Console.ReadLine();
            }

        }
       
        
    }
}
