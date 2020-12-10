using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TemperatureAPI.Hubs
{
    public class MeasurementHub : Hub 
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }

}