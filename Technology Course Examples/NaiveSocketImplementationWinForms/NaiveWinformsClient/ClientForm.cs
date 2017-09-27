using Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaiveWinformsClient
{
    public partial class ClientForm : Form
    {
        private ClientNetworking networkApi;
        public ClientForm()
        {
            InitializeComponent();
            networkApi = new ClientNetworking();
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try { 
            networkApi.Connect();
                label1.Text = "Connected...";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            while (true)
            {
             
                if (textBox1.Text.Length > 0)
                {
                    
                    try
                    {
                        networkApi.SendMessage(textBox1.Text);
                    }
                    catch (IOException ioex)
                    {
                        MessageBox.Show(ioex.Message);
                    }
                    catch (SocketException sex)
                    {
                        MessageBox.Show(sex.Message);
                    }
                }
            }
        }
    }
}
