using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidget22;
using Phidget22.Events;
using System.Threading;
using System.Net.Mail;
using System.Diagnostics;

namespace FidgetTest
{
    public partial class Form1 : Form
    {
        private DigitalOutput dig;
        private RFID rfid;
        private int amountSent = 0;
        //RFID Reader: Channel 0
        //5V Digital Output: Channel 0
        //LED Driver Ourput: Channel 1
        //Onboard LED: Channel 2
        public Form1()
        {
            InitializeComponent();

            dig = new DigitalOutput();
            dig.Channel = 2;
            dig.Open();
            rfid = new RFID();
            rfid.Open();
            rfid.Attach += new AttachEventHandler(rfid_Attach);
            rfid.Detach += new DetachEventHandler(rfid_Detach);
            rfid.Error += new ErrorEventHandler(rfid_Error);
            rfid.Tag += new RFIDTagEventHandler(rfid_Tag);
            rfid.TagLost += new RFIDTagLostEventHandler(rfid_TagLost);
        }

        public void WriteNewTag(string rfidTag)
        {
            rfid.Write("EN BESKED DER SKAL LIGGE PÅ RFID", RFIDProtocol.PhidgetTAG, false);
        }

        private void rfid_TagLost(object sender, RFIDTagLostEventArgs e)
        {
            //throw new NotImplementedException();
        }
        private void rfid_Tag(object sender, RFIDTagEventArgs e)
        {


            RFID rf = (RFID)sender;
            rf.Channel = 2;
            rf.Open();



            SendEmail();
            label2.Text = "Amount sent: " + amountSent;
            dig.BeginSetState(true, TurnOn, null);
            this.BackColor = Color.Green;
            //Process.Start("chrome", "http://www.google.dk");
            
            dig.BeginSetState(false, TurnOff, null);
           // this.BackColor = Color.Gray;


            

        }

        public bool Login(string username,string password)
        {
            string sql = "SELECT * FROM Users WHERE username="+username+" AND password="+password;


            return true;
        }

        private void SendEmail()
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(new MailAddress("brhv@ucn.dk", "Brian"));
            msg.From = new MailAddress("roh@ucn.dk", "Ronni");
            msg.Subject = "Important message";
            msg.Body = "You looked";
            msg.IsBodyHtml = true;

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("roh@ucn.dk", "XXXXXX");
            client.Port = 587;
            client.Host = "smtp.office365.com";
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            try
            {
                client.Send(msg);
                amountSent++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending mail");
            }
        }

        private void TurnOn(IAsyncResult ar)
        {
            
        }

        private void TurnOff(IAsyncResult ar)
        {
            
        }

        private void rfid_Error(object sender, ErrorEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void rfid_Attach(object sender, AttachEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void rfid_Detach(object sender, DetachEventArgs e)
        {
            //  throw new NotImplementedException();
        }
    }
}
