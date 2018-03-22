using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocketScaffold
{
    public partial class Form1 : Form
    {
        private Socket socket;
        private IPAddress localAddress;
        private IPEndPoint localEndpoint;
        private byte[] receiveBuffer;
        public Form1()
        {
            InitializeComponent();
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            localAddress = IPAddress.Parse("127.0.0.1");
            localEndpoint = new IPEndPoint(localAddress, 6689);
            socket.Bind(localEndpoint);
            socket.Listen(200);//200 is the maximum amount of clients that can be queued up to be accepted
            socket.BeginAccept(AcceptingClient, socket);
            
        }
        
        private void AcceptingClient(IAsyncResult ar)
        {
            Socket clientSocket = socket.EndAccept(ar);
            //Immediately begin accepting new clients!
            socket.BeginAccept(AcceptingClient, socket);

            receiveBuffer = new byte[clientSocket.ReceiveBufferSize];
            clientSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, SocketFlags.None, RecievingData, clientSocket);
            
        }
        
        private void RecievingData(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;
            var bytesReceived = clientSocket.EndReceive(ar);
            clientSocket.BeginReceive(receiveBuffer, 0, receiveBuffer.Length, 0, RecievingData, clientSocket);
            byte[] actualDataReceived = new byte[bytesReceived];
            Array.Copy(receiveBuffer, actualDataReceived, bytesReceived);
            string receivedData = Encoding.Unicode.GetString(actualDataReceived);
        }

        public void Send(string message, Socket clientSocket)
        {
            byte[] sendBuffer = Encoding.Unicode.GetBytes(message);
            clientSocket.BeginSend(sendBuffer, 0, sendBuffer.Length, 0, SendingData, clientSocket);
        }
        private void SendingData(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;
            clientSocket.EndSend(ar);
        }
    }
}
