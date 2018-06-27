using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceReference1.Service1Client cl = new ServiceReference1.Service1Client();
            cl.GetAll();
            ServiceReference1.Service2Client cl2 = new ServiceReference1.Service2Client();
            cl2.GetAll();
        }
    }
}
