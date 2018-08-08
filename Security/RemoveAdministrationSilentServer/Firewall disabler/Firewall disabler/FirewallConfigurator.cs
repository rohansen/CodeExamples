using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firewall_disabler
{
    public class FirewallConfigurator
    {
        public void SetFirewallEnabled(bool v)
        {
            Type firewallPolicyType = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 mgr = (INetFwPolicy2)Activator.CreateInstance(firewallPolicyType);
            NET_FW_PROFILE_TYPE2_ fwCurrentProfileTypes = (NET_FW_PROFILE_TYPE2_)mgr.CurrentProfileTypes;
            mgr.FirewallEnabled[fwCurrentProfileTypes] = v;
        }



        public void AllowProgramInFirewall(bool allowProgram)
        {
            string commandArguments = "";
            if (allowProgram)
            {
                commandArguments = $"advfirewall firewall add rule name=\"XXXXXXXX\" dir=out action=allow program={System.AppDomain.CurrentDomain.FriendlyName} enable=yes profile=domain,private,public";
            }
            else
            {
                commandArguments = "advfirewall firewall delete rule name=\"XXXXXXXX\" dir=out";
            }
            ProcessStartInfo info = new ProcessStartInfo("netsh", commandArguments);
            info.CreateNoWindow = true;
            info.UseShellExecute = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info);
        }
    }
}
