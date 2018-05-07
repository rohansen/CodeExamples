using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKYPE4COMLib;
using System.Runtime.InteropServices;

namespace Skype4Com
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var app = new SKYPE4COMLib.Application();
            SKYPE4COMLib.Call call = new Call();
            SKYPE4COMLib.IClient cl = new Client();

            SKYPE4COMLib.Skype skype = new Skype(); //Så vidt jeg kan regne ud er skype objektet "indgangen" til størstedelen af funktionaliteten.
            
            try
            {
                skype.Attach();
                var usr = skype.CurrentUser;
                skype.PlaceCall("live:h_hvarregaard");//Indtast caller id her (mit login er eks. hansen.ronni
            }
            catch (COMException come)
            {
                
                throw;
            }
        }
    }
}
