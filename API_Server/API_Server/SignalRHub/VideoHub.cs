using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using API_Server.Data;
using System.Text.RegularExpressions;

namespace API_Server.SignalRHub
{
    public class VideoHub : Hub
    {
        private readonly IMongoCollection<Room> videoroom;
        public VideoHub(IMongoDatabase database)
        {
            videoroom = database.GetCollection<Room>("Rooms");
        }
        public async Task CreateRoom(string roomid)
        {
            var existroom = await videoroom.Find(r => r.RoomId == roomid).FirstOrDefaultAsync();
            if (existroom == null)
            {
                var newroom = new Room
                {
                    RoomId = roomid,
                    StartTime = DateTime.Now,

                };

                await videoroom.InsertOneAsync(newroom);
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, roomid);
            var filter = Builders<Room>.Filter.Eq(v => v.RoomId, roomid);
            var update = Builders<Room>.Update.AddToSet(r => r.Participants, roomid);
            await videoroom.UpdateOneAsync(filter, update);

            await Clients.Caller.SendAsync("CreateRoom", roomid);
        }

        public async Task JoinRoom(string roomid)
        {
            var room = videoroom.Find(v => v.RoomId == roomid).FirstOrDefault();
            if (room == null)
            {
                await Clients.Caller.SendAsync("RoomNotFound", roomid);
                return;
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, roomid);

            var filter = Builders<Room>.Filter.Eq(r => r.RoomId, roomid);
            var update = Builders<Room>.Update.AddToSet(r => r.Participants, Context.ConnectionId);

            foreach (var videos in room.VideoStatus)
            {
                await Clients.Caller.SendAsync("VideoStatus", videos.VideoID, videos);
            }

            await Clients.Group(roomid).SendAsync("UserJoined", Context.ConnectionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            var room = await videoroom.Find(r => r.Participants.Contains(Context.ConnectionId)).ToListAsync();

            foreach (var eachroom in room)
            {
                var filter = Builders<Room>.Filter.Eq(r => r.RoomId, eachroom.RoomId);
                var pull = Builders<Room>.Update.Pull(r => r.Participants, Context.ConnectionId);

                await videoroom.UpdateOneAsync(filter, pull);

                var updateroom = await videoroom.Find(r => r.RoomId == eachroom.RoomId).FirstOrDefaultAsync();
                if (updateroom.Participants.Count == 0)
                {
                    await videoroom.DeleteOneAsync(filter);
                    await Clients.Caller.SendAsync("DeleteRoom", eachroom.RoomId);
                }

            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task PlayVideo(string roomid, string videoid)
        {
            var videos = new VideoStatus
            {
                VideoID = videoid,
                IsPlaying = true,
                Progress = 0,
            };

            var filter = Builders<Room>.Filter.Eq(r => r.RoomId, videoid);
            var update = Builders<Room>.Update.AddToSet(r => r.VideoStatus, videos);
            await videoroom.UpdateOneAsync(filter, update);

            await Clients.Group(roomid).SendAsync("PlayVideo", videoid);

        }

        public async Task PauseVideo(string roomid, string videoid)
        {
            await videoroom.UpdateOneAsync(Builders<Room>.Filter.And
                            (Builders<Room>.Filter.Eq(r => r.RoomId, roomid), Builders<Room>.Filter.ElemMatch(r => r.VideoStatus, v => v.VideoID == videoid)),
                            Builders<Room>.Update.Set("VideoStatus.$.IsPlaying", false));

            await Clients.Group(roomid).SendAsync("PauseVideo", videoid);
        }

        public async Task UpdateProgress(string roomid, string videoid, double progress)
        {
            await videoroom.UpdateOneAsync(Builders<Room>.Filter.And
                            (Builders<Room>.Filter.Eq(r => r.RoomId, roomid), Builders<Room>.Filter.ElemMatch(r => r.VideoStatus, v => v.VideoID == videoid)),
                             Builders<Room>.Update.Set("VideoStatus.$.Progress", progress));

            await Clients.Group(roomid).SendAsync("UpdateProgress", videoid, progress);
        }

    }
}
