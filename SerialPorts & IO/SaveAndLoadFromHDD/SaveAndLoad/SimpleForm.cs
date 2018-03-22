using SaveAndLoad.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SerializationLibrary;
namespace SaveAndLoad
{
    public partial class SimpleForm : Form
    {
        public SimpleForm()
        {
            InitializeComponent();
        }

        private void btnSaveClick(object sender, EventArgs e)
        {
            
            Person p1 = new Person { FirstName =txtFirstName.Text, LastName = txtLastName.Text, Birthday = dpBirthday.Value};
            
            p1.SerializeAndSave();
           
         
        }


        private void SimpleForm_Load(object sender, EventArgs e)
        {
            ClearAndLoadItems();

        }

        private void btnSaveBooking_Click(object sender, EventArgs e)
        {
            Booking b1 = new Booking { StartTime = dpStartTime.Value, EndTime = dpEndTime.Value, Title = txtTitle.Text};
            b1.SerializeAndSave();
        }

        private void ClearAndLoadItems()
        {
            listBox1.Items.Clear();
            var allsaved = JsonSerialization.DeSerializeAndLoadAll<Person>();
            var allsaved2 = JsonSerialization.DeSerializeAndLoadAll<Booking>();
            if (allsaved != null)
            {
                foreach (var item in allsaved)
                {
                    listBox1.Items.Add(item.FirstName);
                }
            }
            if (allsaved2 != null)
            {
                foreach (var item in allsaved2)
                {
                    listBox1.Items.Add(item.Title);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            ClearAndLoadItems();
        }
    }
}
