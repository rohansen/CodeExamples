using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OauthExample
{
    public partial class Form1 : Form
    {
        private FacebookLoginDialog dialog;
        public Form1()
        {
            InitializeComponent();
            dialog = new FacebookLoginDialog();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
           
            dialog.Login();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dialog.Logout();
        }
    }
}
