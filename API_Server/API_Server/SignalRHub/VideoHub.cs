using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using API_Server.Data;
using System.Text.RegularExpressions;
using API_Server.Service;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API_Server.SignalRHub
{
    public class VideoHub : Hub
    {
        static int usercount = 0;
        private static readonly object Lock = new object();
        private static Dictionary<string, List<string>> roommovies = new Dictionary<string, List<string>>();
        private static Dictionary<string, List<string>> roomusers = new Dictionary<string, List<string>>();
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

        public async Task GetMovies(string roomid)
        {
            lock (Lock)
            {
                if (!roommovies.ContainsKey(roomid))
                {
                    roommovies[roomid] = new List<string>();
                }
            }
            await Clients.Caller.SendAsync("ReceiveMovies", roommovies[roomid]);
        }

        public async Task AddMovie(string roomid, string movie)
        {
            if (!roommovies.ContainsKey(roomid))
            {
                roommovies[roomid] = new List<string>();
            }
            roommovies[roomid].Add(movie);
            await Clients.Group(roomid).SendAsync("ReceiveMovies", roommovies[roomid]);
        }

        public async Task LeaveRoom(string roomid)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomid);
        }

        public async Task DeleteRoom(string roomid)
        {
            if (roommovies.ContainsKey(roomid))
            {
                roommovies.Remove(roomid);
            }
          
            if (roomusers.ContainsKey(roomid))
            {
                roomusers.Remove(roomid);
            }
        }

        public async Task PlayVideo(string roomid, string videoid)
        {
            await Clients.Group(roomid).SendAsync("ReceivedPlayVideo", videoid);
        }

        public async Task SyncPlaybackPosition(string roomid, double position)
        {
            await Clients.Group(roomid).SendAsync("ReceivePlaybackPosition", position);
        }

        public async Task DeleteVideoFromQueue(string roomid, string videoid)
        {
            roommovies[roomid].Remove(videoid);
            await Clients.Caller.SendAsync("ReceiveDeletedMovies", roommovies[roomid]);
        }

    }
}
