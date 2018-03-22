using LoginSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserDrivenApplication
{
    public partial class Form1 : Form
    {
        private DbUser dbuser = new DbUser();
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            dbuser.Register(textBox1.Text, textBox2.Text);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(dbuser.Login(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("LOGGED IN!");
            }else
            {
                MessageBox.Show("INVALID CREDENTIALS");
            }
        }
    }
}
