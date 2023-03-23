using KaraManager.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace KaraManager
{
    /// <summary>
    /// Interaction logic for Invoices.xaml
    /// </summary>
    public partial class Invoices : Window
    {
        public Invoices()
        {
            InitializeComponent();
            LoadInvoiceList(0);
            
        }

        private void LoadInvoiceList(int RecordsNum)
        {
            KaraManagerContext context = new KaraManagerContext();
            var list = context.Invoices.Join(context.Rooms,
                                  invoices => invoices.Rid,
                                  rooms => rooms.Rid,
                                  (_invoices, _rooms) => new
                                  {
                                      Bid = _invoices.Bid,
                                      Rid = _rooms.Rid,
                                      RoomName = _rooms.Name,
                                      PricePerHour = _rooms.Priceperhour,
                                      Datecreated = _invoices.Datecreated.ToShortDateString(),
                                      Timestarted = _invoices.Timestarted,
                                      Timeended = _invoices.Timeended,
                                      Timeelapsed = _invoices.Timeelapsed,
                                      Othercost = _invoices.Othercost,
                                      Totalcost = _invoices.Totalcost 
                                  }
                                  ).ToList();
                if (RecordsNum > 0)
                {
                    lvInvoices.ItemsSource = context.Invoices.Join(context.Rooms,
                                  invoices => invoices.Rid,
                                  rooms => rooms.Rid,
                                  (_invoices, _rooms) => new
                                  {
                                      Bid = _invoices.Bid,
                                      Rid = _rooms.Rid,
                                      RoomName = _rooms.Name,
                                      PricePerHour = _rooms.Priceperhour,
                                      Datecreated = _invoices.Datecreated.ToShortDateString(),
                                      Timestarted = _invoices.Timestarted,
                                      Timeended = _invoices.Timeended,
                                      Timeelapsed = _invoices.Timeelapsed,
                                      Othercost = _invoices.Othercost,
                                      Totalcost = _invoices.Totalcost
                                  }
                                  ).Take(RecordsNum).ToList();
                }
                else
                {
                    lvInvoices.ItemsSource = list;
                }
        }

        private void lvInvoices_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvInvoices.SelectedItem != null)
            {
                dynamic dynamic = lvInvoices.SelectedItem;
                txtRoomNum.Text = dynamic.RoomName;
                txtDateCreated.Text = dynamic.Datecreated.ToString();
                txtTimestarted.Text= dynamic.Timestarted.ToString();
                txtTimeended.Text= dynamic.Timeended.ToString();
                txtTimeelapsed.Text= dynamic.Timeelapsed.ToString();
                txtOthercost.Text= dynamic.Othercost.ToString();
                txtTotalcost.Text= dynamic.Totalcost.ToString();
            }
            
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            KaraManagerContext context = new KaraManagerContext();
            dynamic dynamic = lvInvoices.SelectedItem;
            Invoice invoice = new Invoice();
            invoice.Bid = dynamic.Bid;
            invoice.Rid = dynamic.Rid;
            invoice.Datecreated = DateTime.Parse(dynamic.Datecreated.ToString());
            invoice.Timestarted = DateTime.Parse(dynamic.Timestarted.ToString());
            invoice.Timeended = DateTime.Parse(dynamic.Timeended.ToString());
            invoice.Timeelapsed = TimeSpan.Parse(dynamic.Timeelapsed.ToString());
            invoice.Othercost = int.Parse(txtOthercost.Text);
            invoice.Totalcost = int.Parse(txtTotalcost.Text);
            context.Entry<Invoice>(invoice).State = EntityState.Modified;
            context.SaveChanges();
            LoadInvoiceList(int.Parse(txtRecordsNum.Text));
            }
            catch (Exception ex)
            {
                LoadInvoiceList(0);
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            KaraManagerContext context = new KaraManagerContext();
            dynamic dynamic = lvInvoices.SelectedItem;
            Invoice invoice = new Invoice();
            invoice.Bid = dynamic.Bid;
            invoice.Rid = dynamic.Rid;
            invoice.Datecreated = DateTime.Parse(dynamic.Datecreated.ToString());
            invoice.Timestarted = DateTime.Parse(dynamic.Timestarted.ToString());
            invoice.Timeended = DateTime.Parse(dynamic.Timeended.ToString());
            invoice.Timeelapsed = TimeSpan.Parse(dynamic.Timeelapsed.ToString());
            invoice.Othercost = int.Parse(txtOthercost.Text);
            invoice.Totalcost = int.Parse(txtTotalcost.Text);
            context.Invoices.Remove(invoice);
            context.SaveChanges();
            txtRoomNum.Clear();
            txtDateCreated.Clear();
            txtTimestarted.Clear();
            txtTimeended.Clear();
            txtTimeelapsed.Clear();
            txtOthercost.Clear();
            txtTotalcost.Clear();
            LoadInvoiceList(int.Parse(txtRecordsNum.Text));
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "Warning");
                LoadInvoiceList(0);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            KaraManagerContext context = new KaraManagerContext();
            var RecordsNum = txtRecordsNum.Text.ToString();
            try
            {
                LoadInvoiceList(int.Parse(RecordsNum));
            }
            catch(Exception ex)
            {
                LoadInvoiceList(0);
            }
                  
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            AdminMenu adm = new AdminMenu();
            Application.Current.MainWindow.Content = adm.Content;
            Application.Current.MainWindow.Title = "Admin Menu";
            Application.Current.MainWindow.Height = adm.Height;
            Application.Current.MainWindow.Width = adm.Width;
        }

        private void txtOthercost_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
            dynamic dynamic = lvInvoices.SelectedItem;
            int othercost = Convert.ToInt32(txtOthercost.Text);
            int priceperhour = dynamic.PricePerHour;
            int timeelapsed;
            if ((int)Convert.ToUInt32(TimeSpan.Parse(txtTimeelapsed.Text).TotalHours) == 0)
            {
                timeelapsed = 1;
            }
            else
            {
                timeelapsed = (int)Convert.ToUInt32(TimeSpan.Parse(txtTimeelapsed.Text).TotalHours);
            }
            if (othercost < 0)
            {
                MessageBox.Show("Cost cannot be negative", "Warning");
                txtOthercost.Text = dynamic.Othercost.ToString();
            }
            int totalcost = (priceperhour * timeelapsed) + othercost;
            txtTotalcost.Text = totalcost.ToString();
            }catch (Exception ex)
            {
                return;
            }
        }
    }
}
