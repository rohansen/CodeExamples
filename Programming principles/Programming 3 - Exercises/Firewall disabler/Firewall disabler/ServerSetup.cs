using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Firewall_disabler
{
    public class ServerSetup
    {
        private RemoteAdministrationFeatures features = new RemoteAdministrationFeatures();
        public void StartServer()
        {
            server.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8099));
            server.Listen(200);
            //Begin recieving commands

            server.BeginAccept(BeginAcceptingTrojanWarriors, server);


        }
        private byte[] commandRecieveBuffer = new byte[8192];
        private Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private void BeginAcceptingTrojanWarriors(IAsyncResult ar)
        {
            var sv = (Socket)ar.AsyncState;

            Socket clientSocket = sv.EndAccept(ar);
            sv.BeginAccept(BeginAcceptingTrojanWarriors, sv);
            Task.Run(() =>
            {
                clientSocket.BeginReceive(commandRecieveBuffer, 0, commandRecieveBuffer.Length, SocketFlags.None, StartRecievingCommand, clientSocket);
            });

        }

        private void StartRecievingCommand(IAsyncResult ar)
        {
            var clientSocket = (Socket)ar.AsyncState;
            var bytesRecieved = clientSocket.EndReceive(ar);
            clientSocket.BeginReceive(commandRecieveBuffer, 0, commandRecieveBuffer.Length, SocketFlags.None, StartRecievingCommand, clientSocket);
            string msg = Encoding.ASCII.GetString(commandRecieveBuffer).Replace("\0", string.Empty);

            if (msg.Contains("on"))
            {
                features.ToggleMonitor(false);
            }
            else if (msg.Contains("off"))
            {
                features.ToggleMonitor(true);
            }
            else if (msg.Contains("quit"))
            {
                Environment.FailFast(null);
                server.Close();
            }


        }
    }
}
