﻿using KaraManager.Windows;
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
            Application.Current.MainWindow.Title = "KaraManager 2.0";
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
            Income income = new Income();
            Application.Current.MainWindow.Content = income.Content;
            Application.Current.MainWindow.Height= income.Height;
            Application.Current.MainWindow.Width= income.Width;
            Application.Current.MainWindow.Title = "View Income";
        }

        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            AdminMessage message = new AdminMessage();
            Application.Current.MainWindow.Content = message.Content;
            Application.Current.MainWindow.Height= message.Height;
            Application.Current.MainWindow.Width= message.Width;
            Application.Current.MainWindow.Title = "Messages";
        }

        private void btnAdminCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateAdmin cad = new CreateAdmin();
            cad.Show();
        }
    }
}
