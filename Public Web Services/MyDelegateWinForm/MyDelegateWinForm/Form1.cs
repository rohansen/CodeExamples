using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDelegateWinForm
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                listBox1.Items.Add("Element nr. " + i);
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread t1 = new Thread(DoWork);
            t1.Start();
            //DbCustomer db = new DbCustomer();
            //db.CustomerCreated += DoneCreating;
            //db.Create(new Customer { Name = "Ronni" });


        }

        private void DoneCreating(string message)
        {
            MessageBox.Show("Inserted Customer: " + message);
        }


        public void DoWork()
        {
            GetDataFromExternalSource((data)=> {
                listBox1.Invoke(new Action(() => { listBox1.Items.Add(data); }));
                return "Im done calling the callback";
            });
        }
   
        public void GetDataFromExternalSource(Func<string,string> callback)
        {
            Thread.Sleep(2000);
            MessageBox.Show(callback("Element X"));
            
        }
    }
}
