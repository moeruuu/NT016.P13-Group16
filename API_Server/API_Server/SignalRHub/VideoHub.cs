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

        public async Task JoinedRoom(string roomid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomid);
            var fullname = Context.User?.Identity?.Name ?? Context.ConnectionId;
            await Clients.Group(roomid).SendAsync("ReceiveNotification", $"{fullname} has joined.");
        }

        public async Task LeaveRoom(string roomid)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomid);
            var username = Context.User?.Identity?.Name ?? Context.ConnectionId;
            await Clients.Group(roomid).SendAsync("ReceiveNotifiction", $"{username} has left the room {roomid}");
        }

        public async Task DeleteRoom(string roomid)
        {
            await Clients.All.SendAsync("RoomDeleted", roomid);
        }
    }
}
