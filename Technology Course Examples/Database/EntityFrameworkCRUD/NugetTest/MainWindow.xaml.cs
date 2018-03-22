using NugetTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Threading;
using System.Collections.ObjectModel;

namespace NugetTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<User> CurrentlyRetrievedUsers { get; set; }
        public ObservableCollection<User> test { get; set; }
        private ApplicationDbContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationDbContext();
            test = new ObservableCollection<User>(); test.Add(new User { Email = "123123123123132123" });
            listBox2.DataContext = test;
            CurrentlyRetrievedUsers = new ObservableCollection<User>();
            listBox.DataContext = CurrentlyRetrievedUsers;
           
            //DataContext = CurrentlyRetrievedUsers;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {

            User myUser = new User { Email = txtEmail.Text, Password = txtPassword.Text, SecurityQuestion = txtSecQuestion.Text };
            db.Users.Add(myUser);
            db.SaveChanges();
            PopulateSearchTextFields(myUser);
            MessageBox.Show("Created...");
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var foundUsers = SearchUser(txtSearch.Text);
            CurrentlyRetrievedUsers.Clear();
            if (foundUsers.Count() == 1)
            {
                PopulateSearchTextFields(foundUsers.First());
            }
            else if (foundUsers.Count() > 1)
            {
                foreach (var item in foundUsers)
                {
                    CurrentlyRetrievedUsers.Add(item);
                }
            }

        }
        private IEnumerable<User> SearchUser(string query)
        {
            var users = db.Users.Where(x => x.Email.ToLower().Contains(query.ToLower()));
            return users;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int selectedUserId = -1;
            var conversion = int.TryParse(txtFoundId.Text, out selectedUserId);

            if (conversion)
            {
                User u = db.Users.Find(selectedUserId);
                u.Password = txtFoundPassword.Text;
                u.Email = txtFoundEmail.Text;
                u.SecurityQuestion = txtFoundQuestion.Text;
                db.SaveChanges();
            }
            else
            {
                MessageBox.Show("user with given id not found, nothing updated");
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

            db.Entry(listBox.SelectedItem).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            MessageBox.Show($"Removed {txtFoundEmail.Text}");
        }
        //ListBoxChanged is called when the collection is cleared(weird) .. remove listener and add it before calling clear
        public void PopulateSearchTextFields(User user)
        {
            CurrentlyRetrievedUsers.Clear();
            CurrentlyRetrievedUsers.Add(user);
            listBox.SelectedItem = user;
        }
    }
}
