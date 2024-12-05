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
            Console.WriteLine($"RoomCreated event fired with roomId: {roomid}");
            await Clients.All.SendAsync("RoomCreated", roomid);


        }

        public async Task JoinedRoom(string roomid)
        {
            try
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, roomid);
                var fullname = Context.User?.Identity?.Name ?? Context.ConnectionId;
                await Clients.Group(roomid).SendAsync("ReceiveNotification", $"{fullname} has joined.");
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }


    }
}
