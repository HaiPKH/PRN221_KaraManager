using KaraManager.Model;
using System;
using Microsoft.AspNetCore.SignalR.Client;
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

namespace KaraManager.Windows
{
    /// <summary>
    /// Interaction logic for GuestMessage.xaml
    /// </summary>
    public partial class GuestMessage : Window
    {
        KaraManagerContext context = new KaraManagerContext();
        HubConnection connection;
        private static object _syncLock = new object();
        public GuestMessage()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5277/karachathub")
                .Build();
            connection.StartAsync().ContinueWith(task =>
            {
                if (task.Exception != null)
                {
                    MessageBox.Show(task.Exception + "\n" +task.Exception.StackTrace, "Warning");
                    connection.StartAsync();
                }
            });
            connection.On<Message>("ReceiveKaraMessage",
                                   (value) =>
                                   {
                                       Dispatcher.BeginInvoke((Action)(() =>

                                       {
                                           //MessageBox.Show("A message was received");
                                           Account acc = lvAdmins.SelectedItem as Account;
                                           lvMessages.ItemsSource = context.Messages
                                           .Where(m => m.Sendername == Application.Current.Properties["Username"] as string &&
                                                       m.Receivername == acc.Username
                                                       ||
                                                       m.Sendername == acc.Username &&
                                                       m.Receivername == Application.Current.Properties["Username"] as string
                                                       )
                                           .OrderBy(m => m.Timesent)
                                           .ToList();
                                       }));
                                   });

            lvAdmins.ItemsSource = context.Accounts.Where(a => a.Role == "admin").ToList();
        }

        private void lvAdmins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txtMessage.Visibility = Visibility.Visible;
                btnSend.Visibility = Visibility.Visible;
                Account acc = lvAdmins.SelectedItem as Account;
                lvMessages.ItemsSource = context.Messages
                .Where(m => m.Sendername == Application.Current.Properties["Username"] as string &&
                            m.Receivername == acc.Username 
                            ||
                            m.Sendername == acc.Username &&
                            m.Receivername == Application.Current.Properties["Username"] as string
                            )
                .OrderBy(m => m.Timesent)
                .ToList();
                BindingOperations.EnableCollectionSynchronization(lvMessages.ItemsSource, _syncLock);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            Account acc = lvAdmins.SelectedItem as Account;
            Message message = new Message();
            message.Content = txtMessage.Text;
            message.Sendername = Application.Current.Properties["Username"] as string;
            message.Receivername = acc.Username;
            message.Timesent = DateTime.Now;
            this.connection.InvokeAsync("SendMessage", message);
            txtMessage.Clear();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            GuestMenu gm = new GuestMenu();
            Application.Current.MainWindow.Content = gm.Content;
            Application.Current.MainWindow.Title = "Guest Menu";
        }
    }
}
