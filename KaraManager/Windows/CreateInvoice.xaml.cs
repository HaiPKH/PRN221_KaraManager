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
    /// Interaction logic for CreateInvoice.xaml
    /// </summary>
    public partial class CreateInvoice : Window
    {
        KaraManagerContext context = new KaraManagerContext();
        public CreateInvoice()
        {
            InitializeComponent();
        }

        private void txtOtherCost_TextChanged(object sender, TextChangedEventArgs e)
        {
            int othercost = Convert.ToInt32(txtOtherCost.Text);
            int priceperhour = (int)Convert.ToUInt32(lbPricePerHour.Content.ToString());
            int timeelapsed;
            if ((int)Convert.ToUInt32(TimeSpan.Parse(lbTimeElapsed.Content.ToString()).TotalHours) == 0)
            {
                timeelapsed = 1;
            }
            else
            {
                timeelapsed = (int)Convert.ToUInt32(TimeSpan.Parse(lbTimeElapsed.Content.ToString()).TotalHours);
            }            
            if (othercost < 0)
            {
                MessageBox.Show("Cost cannot be negative", "Warning");
            }
            int totalcost = (priceperhour * timeelapsed) + othercost;
            lbTotalCost.Content = totalcost.ToString();
        }

        private void btnCreateInvoice_Click(object sender, RoutedEventArgs e)
        {
            Invoice invoice = new Invoice();
            invoice.Rid = int.Parse(txtRid.Content.ToString());
            invoice.Datecreated = DateTime.Parse(lbDateCreated.Content.ToString());
            invoice.Timestarted = DateTime.Parse(lbTimeStarted.Content.ToString());
            invoice.Timeended = DateTime.Parse(lbTimeEnded.Content.ToString());
            invoice.Timeelapsed = TimeSpan.Parse(lbTimeElapsed.Content.ToString());
            invoice.Othercost=int.Parse(txtOtherCost.Text.ToString());
            invoice.Totalcost=int.Parse(lbTotalCost.Content.ToString());
            context.Invoices.Add(invoice);
            //Remove all messages associated with the room
            Room room = context.Rooms.Where(r => r.Rid == invoice.Rid).FirstOrDefault();
            context.Messages.RemoveRange(context.Messages.Where(m => m.Sendername == room.Name || m.Receivername == room.Name));
            context.SaveChanges();
            Close();
        }
    }
}
