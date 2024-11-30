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
            var userid = Context.User?.FindFirst("UserId")?.Value;
            if (string.IsNullOrEmpty(userid))
            {
                await Clients.Caller.SendAsync("Error", "User is not authenticated.");
                return;
            }
            var room = videoroom.Find(v => v.RoomId == roomid).FirstOrDefault();
            if (room == null)
            {
                await Clients.Caller.SendAsync("RoomNotFound", roomid);
                return;
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, roomid);

            var filter = Builders<Room>.Filter.Eq(r => r.RoomId, roomid);
            var update = Builders<Room>.Update.AddToSet(r => r.Participants, Context.ConnectionId);

            foreach (var videos in room.videoQueues)
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
                else
                {
                    await Clients.Group(eachroom.RoomId).SendAsync("UserLeft", Context.ConnectionId);
                }

            }
            await base.OnDisconnectedAsync(exception);
        }

        public async Task PlayNextVideoFromQueue(string roomid)
        {
            var room = await videoroom.Find(r => r.RoomId == roomid).FirstOrDefaultAsync();
            if (room == null || room.videoQueues.Count == 0)
            {
                return;
            }

            //lọc ra video chưa được phát
            var nextVideo = room.videoQueues.FirstOrDefault(v => !v.IsPlaying);
            if (nextVideo != null)
            {
                //cập nhật trạng thái video thành đang phát
                var filter = Builders<Room>.Filter.Eq(r => r.RoomId, roomid);
                var update = Builders<Room>.Update.Set(r => r.videoQueues[-1].IsPlaying, true);
                await videoroom.UpdateOneAsync(filter, update);

                await Clients.Group(roomid).SendAsync("PlayVideo", nextVideo.VideoID);
            }
            else
            {
                await Clients.Group(roomid).SendAsync("NoVideoToPlay");
            }
        }

        public async Task PauseVideo(string roomid, string videoid)
        {
            await videoroom.UpdateOneAsync(Builders<Room>.Filter.And
                            (Builders<Room>.Filter.Eq(r => r.RoomId, roomid), Builders<Room>.Filter.ElemMatch(r => r.videoQueues, v => v.VideoID == videoid)),
                            Builders<Room>.Update.Set("VideoStatus.$.IsPlaying", false));

            await Clients.Group(roomid).SendAsync("PauseVideo", videoid);
        }

        public async Task UpdateProgress(string roomid, string videoid, double progress)
        {
            await videoroom.UpdateOneAsync(Builders<Room>.Filter.And
                            (Builders<Room>.Filter.Eq(r => r.RoomId, roomid), Builders<Room>.Filter.ElemMatch(r => r.videoQueues, v => v.VideoID == videoid)),
                             Builders<Room>.Update.Set("VideoStatus.$.Progress", progress));

            await Clients.Group(roomid).SendAsync("UpdateProgress", videoid, progress);
        }

        public async Task AddVideoToQueue(string roomid, string videoid)
        {
            var room = await videoroom.Find(r => r.RoomId == roomid).FirstOrDefaultAsync();
            if (room == null)
            {
                await Clients.Caller.SendAsync("RoomNotFound", roomid);
                return;
            }
            var video = new VideoQueue
            {
                VideoID = videoid,
                IsPlaying = false,
                Progress = 0
            };
            var filter = Builders<Room>.Filter.Eq(r => r.RoomId, roomid);
            var update = Builders<Room>.Update.Push(r => r.videoQueues, video);
            await videoroom.UpdateOneAsync(filter, update);
            await Clients.Group(roomid).SendAsync("VideoAddedToQueue", videoid);

            if (room.videoQueues.Count == 1)
            {
                await PlayNextVideoFromQueue(roomid);
            }
        }

        public async Task SendMessage(string roomid, string userid, string message)
        {
            var chat = new MessageChat
            {
                UserID = userid,
                Message = message,
                DateSend = DateTime.Now
            };

            var filter = Builders<Room>.Filter.Eq(r => r.RoomId, roomid);
            var update = Builders<Room>.Update.Push(r => r.Messages, chat);
            await videoroom.UpdateOneAsync(filter, update);

            await Clients.Group(roomid).SendAsync("ReceiveMessage", chat);
        }

    }
}
