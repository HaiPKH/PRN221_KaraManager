using KaraManager.Model;
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

namespace KaraManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void SetPage(UserControl page)
        {
            this.Content = page;
        }
        private void AdminLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            Account accountInput = new Account();
            accountInput.Username = txtUsername.Text;
            accountInput.Password = txtPassword.Password;
            var AccountDb = new KaraManagerContext();
            foreach (var account in AccountDb.Accounts.ToList())
            {
                if(accountInput.Username.Equals(account.Username) && accountInput.Password.Equals(account.Password))
                {
                    AdminMenu adm = new AdminMenu();
                    Application.Current.MainWindow.Content = adm.Content;
                    Application.Current.MainWindow.Title = "Admin Menu";
                }
                else
                {
                    MessageBox.Show("oof");
                }
            }
            
        }

        private void GuestLoginBtn_Click(object sender, RoutedEventArgs e)
        {
            GuestMenu gm = new GuestMenu();
            Application.Current.MainWindow.Content = gm.Content;
            Application.Current.MainWindow.Title = "Guest Menu";
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
