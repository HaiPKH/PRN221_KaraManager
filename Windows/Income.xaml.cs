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

namespace KaraManager.Windows
{
    /// <summary>
    /// Interaction logic for Income.xaml
    /// </summary>
    public partial class Income : Window
    {
        public Income()
        {
            InitializeComponent();
        }
        private void LoadInvoiceList()
        {
            try
            {
                DateTime startdate = (DateTime)dpStartDate.SelectedDate;
                DateTime enddate = (DateTime)dpEndDate.SelectedDate;
                ComboBoxItem typeItem = (ComboBoxItem)cboOrder.SelectedItem;
                string order = typeItem.Content.ToString();
                KaraManagerContext context = new KaraManagerContext();
                int TotalIncome = 0;
                var list = context.Invoices.Join(context.Rooms,
                                     invoices => invoices.Rid,
                                     rooms => rooms.Rid,
                                    (_invoices, _rooms) => new
                                    {
                                        Bid = _invoices.Bid,
                                        Rid = _rooms.Rid,
                                        RoomName = _rooms.Name,
                                        PricePerHour = _rooms.Priceperhour,
                                        Datecreated = _invoices.Datecreated,
                                        Timestarted = _invoices.Timestarted,
                                        Timeended = _invoices.Timeended,
                                        Timeelapsed = _invoices.Timeelapsed,
                                        Othercost = _invoices.Othercost,
                                        Totalcost = _invoices.Totalcost
                                    }
                                    ).Where(i => i.Datecreated >= startdate &&
                                               i.Datecreated <= enddate);
                switch (order)
                {
                    case "Date Ascending":
                        lvInvoices.ItemsSource = list.OrderBy(l => l.Datecreated).ToList();
                        break;
                    case "Date Descending":
                        lvInvoices.ItemsSource = list.OrderByDescending(l => l.Datecreated).ToList();
                        break;
                    case "Revenue Ascending":
                        lvInvoices.ItemsSource = list.OrderBy(l => l.Totalcost).ToList();
                        break;
                    case "Revenue Descending":
                        lvInvoices.ItemsSource = list.OrderByDescending(l => l.Totalcost).ToList();
                        break;
                    default:
                        MessageBox.Show("default");
                        lvInvoices.ItemsSource = list.ToList();
                        break;
                }
                foreach (var item in list.ToList())
                {
                    TotalIncome += item.Totalcost;
                }
                lbTotalIncome.Content = TotalIncome.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter the fields correctly", "An error occured");
                return;
            }
            
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            LoadInvoiceList();
        }
    }
}
