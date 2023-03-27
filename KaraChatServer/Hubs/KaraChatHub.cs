using KaraManager.Model;
using Microsoft.AspNetCore.SignalR;
using System.Windows;

namespace KaraChatServer.KaraChatHub
{
    public class KaraChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            //MessageBox.Show("Connected", "Wutdehell");
            return Task.CompletedTask;
        }
        public async Task SendMessage(Message message)
        {
            try
            {
                //MessageBox.Show("Message Sent", "Sent");
                KaraManagerContext context = new KaraManagerContext();
                context.Messages.Add(message);
                context.SaveChanges();
                //await Clients.All.SendAsync("ReceiveKaraMessage",message);
                await Clients.Users(message.Receivername,message.Sendername).SendAsync("ReceiveKaraMessage",message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to send message","An error occurred");
            }           
        }

        public async Task DeleteMessage(Message message)
        {
            try
            {
                KaraManagerContext context = new KaraManagerContext();
                context.Messages.Remove(message);
                context.SaveChanges();
                //await Clients.All.SendAsync("RemoveKaraMessage", message);
                await Clients.Users(message.Receivername, message.Sendername).SendAsync("RemoveKaraMessage", message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to remove message", "An error occurred");
            }
        }
    }
}
