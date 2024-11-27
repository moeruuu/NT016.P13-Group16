using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace API_Server.Data
{
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string RoomId { get; set; }

        [BsonElement("HostId")]
        public string HostId { get; set; }

        [BsonElement("VideoStatus")]
        public List<VideoStatus> VideoStatus { get; set; } = new List<VideoStatus>();

        [BsonElement("ParticipantId")]
        public List<string> Participants { get; set; } = new List<string>();

        [BsonElement("StartTime")]
        public DateTime StartTime { get; set; } 
    }
}