using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Networking
{
    public class ServerNetworking
    {
        private const short PORT = 6568;
        private static TcpListener listener;
        public TcpClient CurrentClient { get; set; }
        public List<TcpClient> Clients { get; set; }
        private object syncObj = new object();
        public ServerNetworking()
        {
            Clients = new List<TcpClient>();
        }
        public void StartListen()
        {
            listener = new TcpListener(IPAddress.Any, PORT);
            listener.Start();
        }
        public void ReadDataFromClient(TcpClient tcpclient, Action<string> callback)
        {
            var nwStream = tcpclient.GetStream();
            var buffer = new byte[4096];
            int i = 0;
            string message = "";
            while ((i = nwStream.Read(buffer, 0, buffer.Length)) != 0)
            {
                message = Encoding.UTF8.GetString(buffer, 0, i);
                callback(message);
            }
        }

        private class TcpCallback
        {
            public TcpListener Listener { get; set; }
            public Action<string> ConnectionCallback { get; set; }
            public Action<string> ReaderCallback { get; set; }
        }
        public async Task WaitForClient(Action<string> connectionCallback, Action<string> readerCallback)
        {
          
            var callbackObj = new TcpCallback();
            callbackObj.Listener = listener;
            callbackObj.ConnectionCallback = connectionCallback;
            callbackObj.ReaderCallback = readerCallback;
            
            listener.BeginAcceptTcpClient(AcceptCallback, callbackObj);
            
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            TcpCallback cb = (TcpCallback)ar.AsyncState;
            TcpListener listener = cb.Listener;
            TcpClient client = listener.EndAcceptTcpClient(ar);
            lock (syncObj)
            {
                Clients.Add(client);
            }
            cb.ConnectionCallback("Client connected");
            WaitForClient(cb.ConnectionCallback, cb.ReaderCallback);
            //Begin reading data
            ReadDataFromClient(client,cb.ReaderCallback);

        }

        public void CloseConnection(TcpClient client)
        {
            client.Close();
            listener.Stop();
            client = null;
            listener = null;

        }
    }
}
