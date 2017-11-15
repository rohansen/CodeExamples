using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceProcess;
using System.Configuration;
using System.Configuration.Install;
using SecureService.ServiceLibrary;

namespace SecureService.Hosts.WindowsServiceHost
{

    //To install service type installutil <exename>
    //to uninstall, append /u to the installutil
    //Easiest if you use VS Dev Console (admin rights)
    public class Service : ServiceBase
    {
        private ServiceHost serviceHost;
        public Service()
        {
            serviceHost = new ServiceHost(typeof(AuthService));
        }
        public static void Main()
        {
            ServiceBase.Run(new Service());
        }
        protected override void OnStart(string[] args)
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
            }

            // Create a ServiceHost for the CalculatorService type and 
            // provide the base address.
            serviceHost = new ServiceHost(typeof(AuthService));

            // Open the ServiceHostBase to create listeners and start 
            // listening for messages.
            serviceHost.Open();
        }
        protected override void OnStop()
        {
            if (serviceHost != null)
            {
                serviceHost.Close();
                serviceHost = null;
            }
        }

        private void InitializeComponent()
        {
            // 
            // Service
            // 
            this.ServiceName = "WCF Test Service";

        }
    }
}
