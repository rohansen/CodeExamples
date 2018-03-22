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

namespace SocketServer
{
    public partial class ServerForm : Form
    {
        private Socket socket;
        private IPAddress localAddress;
        private IPEndPoint localEndpoint;
        private List<MySocketClient> connectedClients = new List<MySocketClient>();
        public ServerForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SetupSocket();

        }
        //Start listening on socket. If a client connects, begin acccepting client asynchronously
        private void ListenOnSocket()
        {
            socket.Listen(200);//200 is the maximum amount of clients that can be queued up to be accepted
            socket.BeginAccept(AcceptingClient, socket);
        }
        //When a client is accepted, begin recieving data
        private byte[] recieveBuffer = new byte[8192];
        private void AcceptingClient(IAsyncResult ar)
        {
            Socket clientSocket = socket.EndAccept(ar);
            //Immediately begin accepting new clients!
            socket.BeginAccept(AcceptingClient,socket);
            MySocketClient newClient = new MySocketClient("Client " + (connectedClients.Count + 1), clientSocket);
            connectedClients.Add(newClient);
            listBox1.Items.Add(newClient);

            recieveBuffer = new byte[clientSocket.ReceiveBufferSize];
            try
            {
                if(clientSocket!=null && clientSocket.Connected)
                    clientSocket.BeginReceive(recieveBuffer, 0, recieveBuffer.Length, 0, RecievingData, clientSocket);
            }
            catch (SocketException sex)
            {
                MessageBox.Show(sex.Message);
                var items = listBox1.Items.Cast<MySocketClient>();
                listBox1.Items.Remove(items.FirstOrDefault(x => x.ClientSocket == clientSocket));//remove the client with socket that currently disconnected
                clientSocket.Dispose();
                clientSocket = null;
            }

        }
        //End recieving data
        private void RecievingData(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;
            try
            {
                var bytesRecieved = clientSocket.EndReceive(ar);
                byte[] actualDataRecieved = new byte[bytesRecieved];
                Array.Copy(recieveBuffer, actualDataRecieved, bytesRecieved);
                textBox1.AppendText(Encoding.Unicode.GetString(actualDataRecieved) + Environment.NewLine);
            }
            catch (SocketException sex)
            {
                MessageBox.Show(sex.Message);
                var items = listBox1.Items.Cast<MySocketClient>();
                listBox1.Items.Remove(items.FirstOrDefault(x => x.ClientSocket == clientSocket));//remove the client with socket that currently disconnected
                clientSocket.Dispose();
                clientSocket = null;
                return;
            }
            try
            {
                //Immediately begin to recieve new message on socket again
                if (clientSocket != null && clientSocket.Connected)
                    clientSocket.BeginReceive(recieveBuffer, 0, recieveBuffer.Length, 0, RecievingData, clientSocket);
            }
            catch (SocketException sex)
            {
                MessageBox.Show(sex.Message);
                var items = listBox1.Items.Cast<MySocketClient>();
                listBox1.Items.Remove(items.FirstOrDefault(x => x.ClientSocket == clientSocket));//remove the client with socket that currently disconnected
                clientSocket.Dispose();
                clientSocket = null;
                return;
            }

        }

        private void SetupSocket()
        {
            socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            localAddress = IPAddress.Parse("127.0.0.1");
            localEndpoint = new IPEndPoint(localAddress, 6689);
            socket.Bind(localEndpoint);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListenOnSocket();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            if(connectedClients.Count > 0)
            {

                byte[] sendBuffer = Encoding.Unicode.GetBytes(textBox2.Text);
                //send same message to all clients
                foreach (var client in connectedClients.Where(x=>x.ClientSocket.Connected))
                {
                    client.ClientSocket.BeginSend(sendBuffer, 0, sendBuffer.Length, 0, SendingData, client.ClientSocket);
                }
            }
        }

        private void SendingData(IAsyncResult ar)
        {
            Socket clientSocket = (Socket)ar.AsyncState;
            clientSocket.EndSend(ar);
        }
    }
}
