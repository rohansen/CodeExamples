using Core;
using Core.Factories;
using Core.Strategies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DependencyInjectionExample
{
    public partial class Form1 : Form
    {
        private UserStrategy strategy;
        public Form1()
        {
            InitializeComponent();
            SetupDependencyInjection();
        }

        private void SetupDependencyInjection()
        {
            //GUI Only knows about the concrete factory class, interface, and the IUser interface
            //The concrete domain model is now known by the form class

            //A factory is a type that can construct other objects. This factory constructs an object with the interface IUser
            //You can add multiple factories for different types; the "strategy" will figure out which factory should construct the object
            var factories = new List<IFactory<IUser>>();
            factories.Add(new UserFactory());
            //We create a strategy with all our factories; we use this strategy to create the objects we ask for (see below)
            strategy = new UserStrategy(factories);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           //to create a new instance of an object with the interface IUser, we ask the strategy to create something with the interface IUser
            var newUser = strategy.Create(typeof(IUser));
            
            newUser.Id = 1;
            newUser.UserName = "ROH";
            newUser.Password = "1234";
            newUser.Address = "Nowhere 1";
            MessageBox.Show($"Created {newUser.UserName}");
        }
    }
}
