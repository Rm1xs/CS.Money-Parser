using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudParser.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task Send(string message)
        {
            await this.Clients.All.SendAsync("Send", message);
        }
    }
}
