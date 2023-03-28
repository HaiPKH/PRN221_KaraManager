using KaraManager.Model;
using Microsoft.AspNetCore.SignalR.Client;
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

namespace KaraManager.Windows
{
    /// <summary>
    /// Interaction logic for AdminMessage.xaml
    /// </summary>
    public partial class AdminMessage : Window
    {
        KaraManagerContext context = new KaraManagerContext();
        HubConnection connection;
        private static object _syncLock = new object();
        public AdminMessage()
        {
            InitializeComponent();
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5277/karachathub")
                .Build();
            connection.StartAsync().ContinueWith(task =>
            {
                if(task.Exception != null)
                {
                    MessageBox.Show(task.Exception + "\n" +task.Exception.StackTrace, "Warning");
                    connection.StartAsync();
                }
            });
            connection.On<Message>("ReceiveKaraMessage",
                                   (message) =>
                                   {
                                       Dispatcher.BeginInvoke((Action)(() =>

                                       {
                                           //MessageBox.Show("A message was received");
                                           Room room = lvRooms.SelectedItem as Room;
                                           lvMessages.ItemsSource = context.Messages
                                           .Where(m => m.Sendername == Application.Current.Properties["Username"] as string &&
                                                       m.Receivername == room.Name
                                                       ||
                                                       m.Sendername == room.Name &&
                                                       m.Receivername == Application.Current.Properties["Username"] as string)
                                           .OrderBy(m => m.Timesent)
                                           .ToList();
                                       }));
                                   });
            connection.On<Message>("RemoveKaraMessage",
                                   (message) =>
                                   {
                                       Dispatcher.BeginInvoke((Action)(() =>

                                       {
                                           //MessageBox.Show("A message was received");
                                           Room room = lvRooms.SelectedItem as Room;
                                           lvMessages.ItemsSource = context.Messages
                                           .Where(m => m.Sendername == Application.Current.Properties["Username"] as string &&
                                                       m.Receivername == room.Name
                                                       ||
                                                       m.Sendername == room.Name &&
                                                       m.Receivername == Application.Current.Properties["Username"] as string)
                                           .OrderBy(m => m.Timesent)
                                           .ToList();
                                       }));
                                   });
            lvRooms.ItemsSource = context.Rooms.ToList().OrderBy(r => r.Name);
        }

        private void lvRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                txtMessage.Visibility = Visibility.Visible;
                btnSend.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Visible;
                Room room = lvRooms.SelectedItem as Room;
                lvMessages.ItemsSource = context.Messages
                .Where(m => m.Sendername == Application.Current.Properties["Username"] as string &&
                            m.Receivername == room.Name 
                            || 
                            m.Sendername == room.Name &&
                            m.Receivername == Application.Current.Properties["Username"] as string)
                .OrderBy(m => m.Timesent)
                .ToList();
                BindingOperations.EnableCollectionSynchronization(lvMessages.ItemsSource, _syncLock);
            }
            catch (Exception ex)
            {
                return;
            }
            
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            Room room = lvRooms.SelectedItem as Room;
            Message message = new Message();
            message.Content = txtMessage.Text;
            message.Sendername = Application.Current.Properties["Username"] as string;
            message.Receivername = room.Name;
            message.Timesent = DateTime.Now;
            this.connection.InvokeAsync("SendMessage", message);           
            txtMessage.Clear();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adm = new AdminMenu();
            Application.Current.MainWindow.Content = adm.Content;
            Application.Current.MainWindow.Title = "Admin Menu";
            Application.Current.MainWindow.Width = adm.Width;
            Application.Current.MainWindow.Height = adm.Height;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Message message = lvMessages.SelectedItem as Message;
            this.connection.InvokeAsync("DeleteMessage", message);
        }
    }
}
