using MongoDB.Driver;
using API_Server.Data;
using Microsoft.Extensions.Configuration;
using API_Server.DTOs;
using MongoDB.Bson;
using System.Net.WebSockets;
namespace API_Server.Service
{
    public class CoopService
    {
        private readonly IMongoCollection<Room> rooms;

        public CoopService(IMongoDatabase database)
        {
            rooms = database.GetCollection<Room>("Rooms");
        }

        public async Task<Room> CreateRoom(ObjectId Userid)
        {
            string ID = new Random().Next().ToString("D6");
            var filter = Builders<Room>.Filter.Eq(r => r.RoomId, ID);
            var checkroom = await rooms.Find(filter).FirstOrDefaultAsync();
            if (checkroom != null)
            {
                throw new Exception("Mã phòng đã tồn tại!");
            }
            var CreateNewRoom = new Room
            {
                Id = ObjectId.GenerateNewId(),
                RoomId = ID,
                HostId = Userid.ToString(),
                StartTime = DateTime.UtcNow,

            };

            await rooms.InsertOneAsync(CreateNewRoom);
            return CreateNewRoom;
        }

        public async Task UserJoined(string roomid, ObjectId userid)
        {
            var filter = Builders<Room>.Filter.Eq(r => r.RoomId, roomid);
            var update = Builders<Room>.Update.AddToSet(r => r.Participants, userid.ToString());
            var result = await rooms.UpdateOneAsync(filter, update);
            if (result.MatchedCount == 0)
            {
                throw new Exception("Không tìm thấy phòng");
            }
            if (result.ModifiedCount == 0)
            {
                throw new Exception("Người dùng này đã tồn tại");
            }
        }

        public async Task UserLeft(string roomid, ObjectId userid)
        {
            var filter = Builders<Room>.Filter.Eq(r=>r.RoomId, roomid);
            var update = Builders<Room>.Update.Pull(r=>r.Participants, userid.ToString());

            var result = await rooms.UpdateOneAsync(filter, update);
            if (result.MatchedCount == 0)
            {
                throw new Exception("Không tìm thấy phòng");
            }
            if (result.ModifiedCount == 0)
            {
                throw new Exception("Người này không có trong phòng");
            }
        }

        public async Task<bool> DeleteRoom(string roomid)
        {
            var filter = Builders<Room>.Filter.Eq(r=>r.RoomId, roomid);
            var room = await rooms.Find(filter).FirstOrDefaultAsync();
            if (room == null)
            {
                throw new Exception("Phòng này không tồn tại");
            }
            if (room.Participants.Count == 0)
            {
                return true;
            }
            return false;
        }
        public async Task<Room> GetRoomByID(string id)
        {
            var filter = Builders<Room>.Filter.Eq(r => r.RoomId, id);
            var room = await rooms.Find(filter).FirstOrDefaultAsync();
            if (room == null)
            {
                return null;
            }
            return room;
        }

        public async Task<bool> AddVideo(AddVideoDTOs videos)
        {
            try
            {
                var filter = Builders<Room>.Filter.Eq(r => r.RoomId, videos.roomid);
                var update = Builders<Room>.Update.Push(r => r.videoQueues, videos.videoid);
                var rs = await rooms.UpdateOneAsync(filter, update);
                return rs.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
               // Console.WriteLine(ex.Message);
                return false;
            }

        }

    }

}
