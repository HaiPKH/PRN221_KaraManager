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
using System.Windows.Shapes;

namespace KaraManager
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Window
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void btnAdminLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Application.Current.MainWindow.Content = mw.Content;
            Application.Current.MainWindow.Title = "Holy fuck i'm cumming";
        }

        private void btnRooms_Click(object sender, RoutedEventArgs e)
        {
            Rooms rooms = new Rooms();
            Application.Current.MainWindow.Content = rooms.Content;
            Application.Current.MainWindow.Title = "Manage Rooms";
        }

        private void btnInvoice_Click(object sender, RoutedEventArgs e)
        {
            Invoices invoices = new Invoices();
            Application.Current.MainWindow.Content = invoices.Content;
            Application.Current.MainWindow.Height= invoices.Height;
            Application.Current.MainWindow.Width= invoices.Width;
            Application.Current.MainWindow.Title = "View Invoices";
        }

        private void btnIncome_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
