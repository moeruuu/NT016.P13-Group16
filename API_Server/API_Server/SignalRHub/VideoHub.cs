using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using API_Server.Data;
using System.Text.RegularExpressions;
using API_Server.Service;
using System.Runtime.CompilerServices;

namespace API_Server.SignalRHub
{
    public class VideoHub : Hub
    {
        static int usercount = 0;
        static string getroom;
        public async Task CreateRoom(string roomid)
        {
            await Clients.All.SendAsync("RoomCreated", roomid);
        }

        public async Task JoinRoom(string roomid)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomid);

        }

        public async Task AddQueueVideo(string roomid, string videoid)
        {
            await Clients.Group(roomid).SendAsync(videoid);
        }

        public async Task SendMessage(string fullname, string roomid, string message)
        {
            await Clients.Group(roomid).SendAsync("ReceivedMessage", fullname, message);
        }

    }
}
