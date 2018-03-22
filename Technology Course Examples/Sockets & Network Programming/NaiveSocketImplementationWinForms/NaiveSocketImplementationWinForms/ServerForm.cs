using Networking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NaiveSocketImplementationWinForms
{
    public partial class ServerForm : Form
    {
        private ServerNetworking serverApi;
        public ServerForm()
        {
            InitializeComponent();
            serverApi = new ServerNetworking();
            
        }
        private void UpdateText(string text)
        {
            textBox1.Text += text + Environment.NewLine;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            serverApi.StartListen();
            textBox1.Text = "Began listening for clients" + Environment.NewLine;
            
            try
            {
                textBox1.Text += "Accepting incoming connections..." + Environment.NewLine;
                serverApi.WaitForClient(
                    (message) =>
                    {
                        textBox1.Invoke((Action)delegate () { UpdateText(message); });
                        
                    },
                    (message) =>
                    {
                        textBox1.Invoke((Action)delegate () { UpdateText(message); });
                    });
                // serverApi.ReadDataFromClient(tcpclient);
            }
            catch (IOException ioex)
            {
                MessageBox.Show("Ex1: " + ioex.Message);
            }
            catch (SocketException sex)
            {
                MessageBox.Show("Ex2: " + sex.Message);
            }
            finally
            {
                //serverApi.CloseConnection(tcpclient);
            }
        }


        //private delegate void SetPropertyThreadSafeDelegate<TResult>(Control @this, Expression<Func<TResult>> property, TResult value);

        //public static void SetPropertyThreadSafe<TResult>(this Control @this, Expression<Func<TResult>> property, TResult value)
        //{
        //    var propertyInfo = (property.Body as MemberExpression).Member
        //        as PropertyInfo;

        //    if (propertyInfo == null || !@this.GetType().IsSubclassOf(propertyInfo.ReflectedType) || @this.GetType().GetProperty(propertyInfo.Name, propertyInfo.PropertyType) == null)
        //    {
        //        throw new ArgumentException("The lambda expression 'property' must reference a valid property on this Control.");
        //    }

        //    if (@this.InvokeRequired)
        //    {
        //        @this.Invoke(new SetPropertyThreadSafeDelegate<TResult>(SetPropertyThreadSafe), new object[] { @this, property, value });
        //    }
        //    else
        //    {
        //        @this.GetType().InvokeMember(propertyInfo.Name, BindingFlags.SetProperty, null, @this, new object[] { value });
        //    }
        //}
    }
    }
