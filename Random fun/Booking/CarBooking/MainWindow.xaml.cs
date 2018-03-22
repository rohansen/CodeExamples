using CarBookingLogic.DAL;
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

namespace CarBooking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DbBooking b = new DbBooking();
            //b.InsertBooking(1, 1, DateTime.Now, DateTime.Now);
            var xxx = b.GetAllUnits(false);
            foreach (var item in xxx)
            {

                Button b1 = new Button();
                b1.Content = item.Name;
                b1.Click += (sender, evt) => b.InsertBooking(item.UnitId, 1, DateTime.Now, DateTime.Now);
                stackPanel.Children.Add(b1);
            }

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ShowUnits_Click(object sender, RoutedEventArgs e)
        {
            ShowUnits su = new ShowUnits();
            su.ShowDialog();
        }



    }
}
