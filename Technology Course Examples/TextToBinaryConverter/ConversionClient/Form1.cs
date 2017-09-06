using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConversionClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text.Replace("\n", string.Empty);
                textBox1.Text = textBox1.Text.Replace("\r", string.Empty);
                //with extension methods
                // var text = textBox1.Text.FromBinary();
                var text = BinaryConverter.FromBinary(textBox1.Text);
                textBox2.Text = text;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Make sure you only have binary in your input field", "Warning");
            }
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //with extension methods
            // var binaryStr = textBox1.Text.FromBinary();
            var binaryStr = BinaryConverter.ToBinary(textBox1.Text);
            textBox2.Text = binaryStr;
        }
    }
}
