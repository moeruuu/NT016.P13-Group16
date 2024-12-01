using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using API_Server.Data;
using System.Text.RegularExpressions;
using API_Server.Service;

namespace API_Server.SignalRHub
{
    public class VideoHub : Hub
    {
        public async Task CreateRoom(string roomid)
        {
            await Clients.All.SendAsync("RoomCreated", roomid);
        }

        public async Task JoinedRoom(string roomid, string fullname)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomid);
            await Clients.Group(roomid).SendAsync("ReceiveNotification", $"{fullname} has joined.");
        }
    }
}
