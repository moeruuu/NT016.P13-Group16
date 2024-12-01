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
            var filter = Builders<Room>.Filter.Eq(r=>r.RoomId, ID);
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

        
    }

}
