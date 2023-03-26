using KaraManager.Model;
using Microsoft.EntityFrameworkCore;
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
    /// Interaction logic for Rooms.xaml
    /// </summary>
    public partial class Rooms : Window
    {
        public Rooms()
        {
            
            InitializeComponent();
            LoadRoomList();
            
        }

        private void LoadRoomList()
        {
            KaraManagerContext context = new KaraManagerContext();
            lvRooms.ItemsSource = context.Rooms.OrderBy(r => r.Name).ToList();
        }

        private Room GetRoomObject()
        {
            Room room = null;
            try
            {
                room = new Room
                {
                    Name = txtRoomNum.Text,
                    Priceperhour = int.Parse(txtPricePerHour.Text),
                    Isused = false,
                    Timestarted = null                   
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Room");
            }
            return room;
        }

        public Room GetRoomByName(String name)
        {
            Room room = null;
            try
            {
                KaraManagerContext context = new KaraManagerContext();
                room = context.Rooms.SingleOrDefault(room => room.Name == name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return room;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Room room = GetRoomObject();
                Account account = new Account();
                if(GetRoomByName(room.Name) != null)
                {
                    throw new Exception("Room name already existed.");
                }
                if (room.Priceperhour <= 0)
                {
                    throw new Exception("Price cannot be zero or negative.");
                }
                else
                {
                    KaraManagerContext context = new KaraManagerContext();
                    account.Username = room.Name;
                    account.Password = "guest";
                    account.Role = "guest";
                    context.Rooms.Add(room);
                    context.Accounts.Add(account);
                    context.SaveChanges();
                    txtPricePerHour.Clear();
                    txtRoomNum.Clear();
                    spRoom.Background = new SolidColorBrush(Colors.LightBlue);
                    LoadRoomList();
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on adding a Room");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Room room = lvRooms.SelectedItem as Room;
            room.Name = txtRoomNum.Text;
            if (GetRoomByName(room.Name) != null)
            {
                MessageBox.Show("Room name already existed.", "Warning");
                return;
            }
            room.Priceperhour = int.Parse(txtPricePerHour.Text);
            if(room.Priceperhour <= 0)
            {
                MessageBox.Show("Price cannot be zero or negative", "Warning");
                return;
            }
            KaraManagerContext context = new KaraManagerContext();
            context.Entry<Room>(room).State = EntityState.Modified;
            context.SaveChanges();
            LoadRoomList();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("This will also remove the corresponding account, messages and invoices", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                 KaraManagerContext context = new KaraManagerContext();
                Room room = lvRooms.SelectedItem as Room;
                context.Rooms.Remove(room);
                context.Accounts.RemoveRange(context.Accounts.Where(x => x.Username == room.Name));
                context.Invoices.RemoveRange(context.Invoices.Where(x => x.Rid == room.Rid));
                context.Messages.RemoveRange(context.Messages.Where(x => x.Receivername == room.Name || x.Sendername == room.Name));
                context.SaveChanges();
                txtPricePerHour.Text = "";
                txtRoomNum.Text = "";
                spRoom.Background = new SolidColorBrush(Colors.LightBlue);           
                LoadRoomList();
            }
            else
            {
                return;
            }
               
        }

        private void lvRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room room = lvRooms.SelectedItem as Room;
            if(room != null)
            {
                txtRoomNum.Text = room.Name;
                txtPricePerHour.Text = room.Priceperhour.ToString();
                if(room.Isused == false)
                {
                    spRoom.Background = new SolidColorBrush(Colors.Green);
                    btnReserveRoom.Visibility = Visibility.Visible;
                    btnReserveRoom.Content = "Room vacant";
                }
                else {
                    spRoom.Background = new SolidColorBrush(Colors.Red);
                    btnReserveRoom.Visibility = Visibility.Visible;
                    btnReserveRoom.Content = "Create Invoice";
                }
            }
            
        }

        private void btnReserveRoom_Click(object sender, RoutedEventArgs e)
        {
            if(btnReserveRoom.Content == "Room vacant")
            {
                KaraManagerContext context = new KaraManagerContext();
                Room room = lvRooms.SelectedItem as Room;
                room.Timestarted = DateTime.Now;
                room.Isused = true;               
                context.Entry<Room>(room).State = EntityState.Modified;
                context.SaveChanges();
                spRoom.Background = new SolidColorBrush(Colors.Red);
                btnReserveRoom.Content = "Create Invoice";
                MessageBox.Show($"Reserved at {room.Timestarted.ToString()}", "Reserve success");
                
            }
            else if(btnReserveRoom.Content == "Create Invoice")
            {
                Room room = lvRooms.SelectedItem as Room;
                spRoom.Background = new SolidColorBrush(Colors.Green);
                btnReserveRoom.Content = "Room vacant";
                room.Isused = false;
                TimeSpan ts = (TimeSpan)(DateTime.Now - room.Timestarted);
                KaraManagerContext context = new KaraManagerContext();
                context.Entry<Room>(room).State = EntityState.Modified;
                context.SaveChanges();
                CreateInvoice createInvoice = new CreateInvoice();
                createInvoice.txtRid.Content = room.Rid;
                createInvoice.lbRoomName.Content += room.Name;
                createInvoice.lbPricePerHour.Content = room.Priceperhour.ToString();
                createInvoice.lbDateCreated.Content = room.Timestarted.Value.ToShortDateString();
                createInvoice.lbTimeStarted.Content = room.Timestarted;
                createInvoice.lbTimeEnded.Content = DateTime.Now;
                createInvoice.lbTimeElapsed.Content = ts;
                createInvoice.Show();
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adm = new AdminMenu();
            Application.Current.MainWindow.Content = adm.Content;
            Application.Current.MainWindow.Title = "Admin Menu";
        }
    }
}