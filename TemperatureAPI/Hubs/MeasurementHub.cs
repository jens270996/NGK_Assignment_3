using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TemperatureAPI.Hubs
{
    public class MeasurementHub : Hub<IMeasurement> 
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.ReceiveMessage( message, user);
        }
    }

    public interface IMeasurement
    {
        Task ReceiveMessage(string user, string message);
    }
}