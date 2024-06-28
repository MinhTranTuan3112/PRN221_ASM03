using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRAssignment.BusinessLogic.Hubs
{
    public class PostHub : Hub
    {
        public async Task NotifyPostUpdate(int postId)
        {
            await Clients.All.SendAsync("ReceivePostUpdate", postId);
        }

        public async Task NotifyPostDeleted()
        {
            await Clients.All.SendAsync("ReceivePostDeleted");
        }
    }
}