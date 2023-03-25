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
                                   (value) =>
                                   {
                                       Dispatcher.BeginInvoke((Action)(() =>

                                       {
                                           //MessageBox.Show("A message was received");
                                           Room room = lvRooms.SelectedItem as Room;
                                           lvMessages.ItemsSource = context.Messages
                                           .Where(m => m.Sendername == Application.Current.Properties["Username"] as string &&
                                                       m.Receivername == room.Name)
                                           .OrderBy(m => m.Timesent)
                                           .ToList();
                                       }));
                                   });
            lvRooms.ItemsSource = context.Rooms.ToList();
        }

        private void lvRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Room room = lvRooms.SelectedItem as Room;
                lvMessages.ItemsSource = context.Messages
                .Where(m => m.Sendername == Application.Current.Properties["Username"] as string &&
                            m.Receivername == room.Name)
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
    }
}
