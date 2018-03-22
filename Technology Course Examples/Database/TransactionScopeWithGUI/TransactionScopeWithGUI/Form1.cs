using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionScopeWithGUI
{
    public partial class Form1 : Form
    {
        ICRUD<User> userdb = new DbUser();
        DbMeeting meetingDb = new DbMeeting();
        ICRUD<Consultant> consultants = new DbConsultant();
        public Form1()
        {
            InitializeComponent();
            SetupEvents();

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            AddMeetingsToCalendar(1);
            AddConsultantsToDropDown();

        }

        #region helper methods

        private void AddMeetingsToTextBox(DateTime startDate)
        {

            var meetings = meetingDb.GetAllConsultantMeetingsOnDate(SelectedConsultantId, monthCalendar1.SelectionRange.Start);
            listBox1.Items.Clear();
            foreach (var item in meetings)
            {
                listBox1.Items.Add(item);
            }


        }

        private void AddConsultantsToDropDown()
        {
            var cons = consultants.GetAll();
            comboBox1.Items.Clear();
            foreach (var item in cons)
            {
                comboBox1.Items.Add(item);
            }
            selectedConsultantId = cons.First().Id;
            comboBox1.SelectedIndex = 0;
        }

        private void AddMeetingsToCalendar(int consultantId)
        {
            var currentConsultantMeetings = meetingDb.GetAllConsultantMeetings(consultantId);
            foreach (var item in currentConsultantMeetings)
            {
                monthCalendar1.AddBoldedDate(item.BeginTime);

            }
        }
        #endregion



        #region properties
        private int selectedConsultantId;
        public int SelectedConsultantId
        {
            get
            {
                return selectedConsultantId;
            }
            set
            {
                this.selectedConsultantId = value;
            }
        }
        #endregion

        #region events
        private void button2_Click(object sender, EventArgs e)
        {
            var meeting = new Meeting();
            var startClock = DateTime.Parse(textBox1.Text);
            var endClock = DateTime.Parse(textBox2.Text);
            var begintime = new DateTime(monthCalendar1.SelectionRange.Start.Year,
                monthCalendar1.SelectionRange.Start.Month,
                monthCalendar1.SelectionRange.Start.Day, startClock.Hour, startClock.Minute, startClock.Second);
            var endtime = new DateTime(monthCalendar1.SelectionRange.Start.Year,
                monthCalendar1.SelectionRange.Start.Month,
                monthCalendar1.SelectionRange.Start.Day, endClock.Hour, endClock.Minute, endClock.Second);
            meeting.BeginTime = begintime;
            meeting.EndTime = endtime;
            meeting.ConsultantId = SelectedConsultantId;
            meeting.UserId = 1;
            try
            {
                meetingDb.Create(meeting);
                AddMeetingsToCalendar(SelectedConsultantId);
                AddMeetingsToTextBox(meeting.BeginTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void changeConsultant(object sender, EventArgs e)
        {

            var currConsultant = ((Consultant)comboBox1.SelectedItem).Id;
            SelectedConsultantId = currConsultant;
            monthCalendar1.RemoveAllBoldedDates();
            foreach (var item in meetingDb.GetAllConsultantMeetings(SelectedConsultantId))
            {
                monthCalendar1.AddBoldedDate(item.BeginTime);
                
            }
            monthCalendar1.UpdateBoldedDates();
            AddMeetingsToTextBox(monthCalendar1.SelectionRange.Start);
        }
        private void SetupEvents()
        {
            monthCalendar1.DateSelected += MonthCalendar1_DateSelected;
        }

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            MonthCalendar mcl = (MonthCalendar)sender;
            AddMeetingsToTextBox(monthCalendar1.SelectionRange.Start);
            label4.Text = $"Selected date: {mcl.SelectionRange.Start.ToShortDateString()}";
        }
        #endregion
    }
}
