using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NotificationTest.model
{
    public class NotificationHub : Hub
    {
        //docs: https://docs.microsoft.com/en-us/aspnet/signalr/overview/guide-to-the-api/mapping-users-to-connections
        //https://stackoverflow.com/questions/19522103/signalr-sending-a-message-to-a-specific-user-using-iuseridprovider-new-2-0/21222303
        public void Show(string userId)
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

            //declaration of displayStatus() for client invoke
            //context.Clients.All.displayStatus();
            System.Diagnostics.Debug.WriteLine("hub show()");
            System.Diagnostics.Debug.WriteLine("1:" + Context.ConnectionId);
            System.Diagnostics.Debug.WriteLine("2:" + userId);
            System.Diagnostics.Debug.WriteLine("3:" + Context.User.Identity.Name);
            context.Clients.All.displayStatus("Sending from all");
            context.Clients.User(userId).displayStatus("sending a from hub to specific client..");
            context.Clients.Client(userId).displayStatus("sending b from hub to specific client..");
        }

        /*
        public async Task CacheUserId(string userIdentifier)
        {

            await Task.Run(() => User.setUserId(userIdentifier));

            System.Diagnostics.Debug.WriteLine("cache:"+userIdentifier);
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

            //delete this away  
            context.Clients.All.cached("done cache");
        }*/

        public override Task OnConnected()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();
            context.Clients.All.getUserId();


        //    string name = Context.User.Identity.Name;
        //    Groups.Add(Context.ConnectionId, name);

            return base.OnConnected();
        }

  
    }
}