using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PingFun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            bool isConnectedToNetwork = NetworkInterface.GetIsNetworkAvailable();
            bool hasInternetConnection = PingAttempt();
            if (isConnectedToNetwork && hasInternetConnection)
            {
                label1.Text = "Connection to internet (and network) OK";
            }
            else
            {
                label1.Text = "No network or internet connection";
            }
         
        }
        
        public bool PingAttempt()
        {
            Ping p = new Ping();
            var reply = p.Send("173.194.44.95",300);//your servername (google for debugging purposes)
            if (reply.Status == IPStatus.TimedOut)
                return false;
            return true;
        }



    }
}
