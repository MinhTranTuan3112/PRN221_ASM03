using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRAssignment.BusinessLogic.Hubs
{
    public class PostHub : Hub
    {
        public async Task NotifyPostUpdate(int postId, int userId)
        {
            await Clients.All.SendAsync("ReceivePostUpdate", postId, userId);
        }

        public async Task NotifyPostCreated(int postId, int userId)
        {
            await Clients.All.SendAsync("ReceivePostCreated", postId, userId);
        }

        public async Task NotifyPostDeleted()
        {
            await Clients.All.SendAsync("ReceivePostDeleted");
        }
    }
}