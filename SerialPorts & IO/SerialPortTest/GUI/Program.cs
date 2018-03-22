using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    class Program
    {
        private static SerialPort port = new SerialPort("COM4", 115200);
        static void Main(string[] args)
        {
            
            port.DataReceived += Port_DataReceived;
            port.Open();
            port.ReadExisting();
            Console.ReadLine();
        }

        private static void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = port.ReadLine();
            Console.WriteLine(data);
        }
    }
}
