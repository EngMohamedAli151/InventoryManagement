using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Database.Model
{
    public class InventoryHub:Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("newMessage", "anonymous", message);
        }

    }
}
