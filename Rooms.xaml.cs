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
            lvRooms.ItemsSource = context.Rooms.ToList();
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
                if(GetRoomByName(room.Name) != null)
                {
                    throw new Exception("Room name already existed.");
                }
                else
                {
                    KaraManagerContext context = new KaraManagerContext();
                    context.Rooms.Add(room);
                    context.SaveChanges();
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

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lvRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Room room = lvRooms.SelectedItem as Room;
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

        private void btnReserveRoom_Click(object sender, RoutedEventArgs e)
        {
            if(btnReserveRoom.Content == "Room vacant")
            {
                Room room = lvRooms.SelectedItem as Room;
                room.Timestarted = DateTime.Now;
                room.Isused = true;
                spRoom.Background = new SolidColorBrush(Colors.Red);
                btnReserveRoom.Content = "Create Invoice";
                MessageBox.Show(room.Timestarted.ToString());
                
            }
            else if(btnReserveRoom.Content == "Create Invoice")
            {
                Room room = lvRooms.SelectedItem as Room;
                spRoom.Background = new SolidColorBrush(Colors.Green);
                btnReserveRoom.Content = "Room vacant";
                room.Isused = false;
                TimeSpan ts = (TimeSpan)(DateTime.Now - room.Timestarted);
                //MessageBox.Show(room.Rid.ToString() + "\n" + ts.ToString() + "\n" + DateTime.Now.ToShortDateString()
                //+ "\n" + DateTime.Now.ToString("HH:mm:ss") + "\n" + room.Timestarted, "Invoice attributes");
                CreateInvoice createInvoice = new CreateInvoice();
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
