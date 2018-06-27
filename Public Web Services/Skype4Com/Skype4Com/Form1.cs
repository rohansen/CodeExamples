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
using System.Threading;

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
            SKYPE4COMLib.Skype skype = new Skype();

            try
            {
                skype.Attach();
                var usr = skype.CurrentUser;
                skype.CallStatus += Skype_CallStatus;

                var currentCall = skype.PlaceCall("echo123");//Indtast caller id her (har indtastet skypes ekko service for test)
                label1.Text = "Started: " + currentCall.Timestamp.ToString() + "";
                label2.Text = "Ended: " + currentCall.Timestamp.ToString() + "";
                Thread.Sleep(4000);

                currentCall.Finish();
                label2.Text = "Ended: " + DateTime.Now.ToString() + "";

                label3.Text = "Duration: " + (DateTime.Now - currentCall.Timestamp).TotalSeconds;

            }
            catch (COMException come)
            {
                throw;
            }
        }

        private void Skype_CallStatus(Call pCall, TCallStatus Status)
        {
            if (Status == TCallStatus.clsRinging)
            {
                //Currently ringing (either calling ,or being called)
            }
            if (Status == TCallStatus.clsFinished)
            {
                //hung up
            }
            //osv
        }
    }
}
