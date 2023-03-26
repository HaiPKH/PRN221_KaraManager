using KaraManager.Windows;
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
    /// Interaction logic for GuestMenu.xaml
    /// </summary>
    public partial class GuestMenu : Window
    {
        public GuestMenu()
        {
            InitializeComponent();
        }

        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            GuestMessage message = new GuestMessage();
            Application.Current.MainWindow.Content = message.Content;
            Application.Current.MainWindow.Height= message.Height;
            Application.Current.MainWindow.Width= message.Width;
            Application.Current.MainWindow.Title = "Messages";
        }

        private void btnGuestLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Application.Current.MainWindow.Content = mw.Content;
            Application.Current.MainWindow.Title = "Holy fuck i'm cumming";
        }
    }
}
