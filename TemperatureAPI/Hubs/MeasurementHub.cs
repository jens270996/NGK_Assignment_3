using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TemperatureAPI.Hubs
{
    public class MeasurementHub : Hub<IMeasurment> 
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.ReceiveMessage( message, user);
        }
    }

    public interface IMeasurment
    {
        Task ReceiveMessage(string user, string message);
    }
}