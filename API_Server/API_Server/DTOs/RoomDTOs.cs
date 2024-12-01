using MongoDB.Bson.Serialization.Attributes;

namespace API_Server.DTOs
{

    public class CreateRoomDTOs
    {
        public string Randomidroom { get; set; }
        public string HostId { get; set; }
        public DateTime StartTime { get; set; }

    }
}
