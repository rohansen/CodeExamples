using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Firewall_disabler
{
    public class RemoteAdministrationFeatures
    {
        static int WM_SYSCOMMAND = 0x112;
        static int SC_MONITORPOWER = 0xF170;
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);
        public void ToggleMonitor(bool turnOff)
        {
            Form f = new Form();
            SendMessage(f.Handle, WM_SYSCOMMAND, (IntPtr)SC_MONITORPOWER, (IntPtr)(turnOff ? 2 : -1));
        }
        //Before using this, disable the firewall toast/notification in windows 10 netsh firewall set notifications mode = disable  --> cant get it to work reliably!?

    }
}
