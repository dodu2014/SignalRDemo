using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRDemo.Hubs
{
    public class TestHub : Hub
    {
        public async Task Test(string num) {
            await Clients.All.SendAsync("OnTest", new { id = Guid.NewGuid(), num });
        }
    }
}
