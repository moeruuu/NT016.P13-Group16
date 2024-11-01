using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace API_Server.Models
{
    public class Coop
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RoomId { get; set; }

        [BsonElement("HostId")]
        public string HostId { get; set; }

        [BsonElement("VideoId")]
        public string VideoId { get; set; } 

        [BsonElement("ParticipantId")]
        public List<string> ParticipantId { get; set; }  

        [BsonElement("StartTime")]
        public DateTime StartTime { get; set; } = DateTime.UtcNow;
    }
}