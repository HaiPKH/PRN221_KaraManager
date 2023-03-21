using KaraManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

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
            LoadInvoiceList();
            
        }

        private void LoadInvoiceList()
        {
            
            KaraManagerContext context = new KaraManagerContext();
            var list = context.Invoices.Join(context.Rooms,
                                  invoices => invoices.Rid,
                                  rooms => rooms.Rid,
                                  (_invoices, _rooms) => new
                                  {
                                      RoomName = _rooms.Name,
                                      Datecreated = _invoices.Datecreated,
                                      Timestarted = _invoices.Timestarted,
                                      Timeended = _invoices.Timeended,
                                      Timeelapsed = _invoices.Timeelapsed,
                                      Othercost = _invoices.Othercost,
                                      Totalcost = _invoices.Totalcost 
                                  }
                                  ).ToList();
            lvInvoices.ItemsSource = list;
        }
    }
}
