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

namespace SocketScaffoldAsyncAwait
{
    public partial class Form1 : Form
    {
        private TcpListener socket;
        private List<Socket> clientSockets = new List<Socket>();
        private bool isListening = false;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            socket = new TcpListener(IPAddress.Parse("127.0.0.1"), 6689);
            socket.Start();
            isListening = true;
            Task t1 = new Task(() => { AcceptClientsAndReceive(); });
            t1.Start();
            

        }
        private async void AcceptClientsAndReceive()
        {
            //Get first client
            
            while (isListening)
            {
                Socket acceptedSocket = await socket.AcceptSocketAsync();
                clientSockets.Add(acceptedSocket);
                acceptedSocket.ReceiveAsync(GetReceiveEventArgs(acceptedSocket));
            }
        }
        private SocketAsyncEventArgs GetReceiveEventArgs(Socket receivingSocket, int bufferSize = 8192)
        {
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.AcceptSocket = receivingSocket;
            args.SetBuffer(new byte[bufferSize], 0, bufferSize);
            args.Completed += ReceiveCompleted;
            return args;
        }

        private SocketAsyncEventArgs GetSendEventArgs(string messageToSend, Socket sendingSocket)
        {
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.AcceptSocket = sendingSocket;
            byte[] sendBuffer = Encoding.Unicode.GetBytes(messageToSend);
            args.SetBuffer(sendBuffer, 0, sendBuffer.Length);
            args.Completed += SendCompleted;
            return args;
        }

        private void ReceiveCompleted(object sender, SocketAsyncEventArgs e)
        {
            byte[] dataRecieved = new byte[e.BytesTransferred];
            Array.Copy(e.Buffer, dataRecieved, dataRecieved.Length);
            textBox1.AppendText(Encoding.Unicode.GetString(dataRecieved) + Environment.NewLine);
            //Keep receiving!
            e.AcceptSocket.ReceiveAsync(GetReceiveEventArgs(e.AcceptSocket));

            //When a message is sent the server, the server receives it, and forwards it(sends it) to all its connected clients
            //TODO: Stop server from sending the message to the sender.
            SendMessage(Encoding.Unicode.GetString(dataRecieved) + Environment.NewLine);
        }
        private void SendCompleted(object sender, SocketAsyncEventArgs e)
        {
            textBox1.AppendText("Sent to all: " + Encoding.Unicode.GetString(e.Buffer));
        }

        private void SendMessage(string message)
        {
            foreach (var socket in clientSockets)
            {
                socket.SendAsync(GetSendEventArgs(message, socket));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMessage(textBox2.Text);
        }
    }
}
