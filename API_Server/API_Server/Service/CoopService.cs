using MongoDB.Driver;
using API_Server.Data;
using Microsoft.Extensions.Configuration;
using API_Server.DTOs;
using MongoDB.Bson;
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
            string ID = new Random().Next().ToString("D8");
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
            if (result.MatchedCount == 0)
            {
                throw new Exception("Người dùng này đã tồn tại");
            }
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
    }

}
