using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortWithThreads
{
    public partial class Form1 : Form
    {
       private SerialPort port;
        private bool isRunning = true;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Start();
        }
        void Start()
        {
            port = new SerialPort("COM4", 115200,Parity.None,8);

            port.Open();
            Thread serialData = new Thread(() =>
            {
                Listen((s) => { textBox1.AppendText(s); });
            });
            serialData.Start();
        }
        public delegate void SerialPortCallback(string s);
        private void Listen(SerialPortCallback cb)
        {
            byte[] readBuffer = new byte[4092];
            int i = 0;
            string readData = "";
            while ((i = port.Read(readBuffer, 0, readBuffer.Length)) > 0 && isRunning)
            {
                readData += Encoding.ASCII.GetString(readBuffer);
                cb(readData);
            }
           
        }
    }
}
