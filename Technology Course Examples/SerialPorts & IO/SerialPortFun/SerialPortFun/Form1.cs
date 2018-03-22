using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialPortFun
{
    public partial class Form1 : Form
    {
        private SerialPort serialPort = new SerialPort("COM4", 115200);
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            serialPort.Open();
            serialPort.ReadExisting();
            serialPort.DataReceived += SerialPort_DataReceived;

        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string recievedData = serialPort.ReadLine();
            textBox1.AppendText(recievedData + Environment.NewLine);
            if (recievedData.StartsWith("A0:"))
            {
                //PotMeter
                string onlyNumber = recievedData.Replace("A0:", "");
                int num = int.Parse(onlyNumber);
                trackBar1.Value = num;
            }
            else if (recievedData.StartsWith("A6:"))
            {
                 
            }




        }
    }
}
