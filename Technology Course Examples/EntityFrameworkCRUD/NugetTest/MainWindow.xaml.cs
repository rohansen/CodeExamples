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

namespace NugetTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ApplicationDbContext db;
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationDbContext();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            User myUser = new User { Email = txtEmail.Text, Password = txtPassword.Text, SecurityQuestion = txtSecQuestion.Text };
            db.Users.Add(myUser);
            db.SaveChanges();
            MessageBox.Show("Created...");
        }



        private User CurrentlyFoundUser { get; set; }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var foundUser = db.Users.FirstOrDefault(x => x.Email.ToLower().Contains(txtSearch.Text.ToLower()));
            if (foundUser != null)
            {
                txtFoundId.Text = foundUser.Id.ToString();
                txtFoundEmail.Text = foundUser.Email;
                txtFoundPassword.Text = foundUser.Password;
                txtFoundQuestion.Text = foundUser.SecurityQuestion;
                CurrentlyFoundUser = foundUser;
            }else
            {
               
                txtFoundId.Text = "Nothing found";
                txtFoundPassword.Text = "Nothing found";
                txtFoundQuestion.Text = "Nothing found";
                txtFoundEmail.Text = "Nothing found";
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
          
            if (CurrentlyFoundUser != null)
            {
                CurrentlyFoundUser.Password = txtFoundPassword.Text;
                CurrentlyFoundUser.Email = txtFoundEmail.Text;
                CurrentlyFoundUser.SecurityQuestion = txtFoundQuestion.Text;
                MessageBox.Show("Updated data");
            }
            else
            {
                MessageBox.Show("user with given id not found, nothing updated");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
                       
            db.Entry(CurrentlyFoundUser).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();
            MessageBox.Show($"Removed {txtFoundEmail.Text}");
        }
    }
}
