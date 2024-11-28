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
        [BsonIgnore] //ko lưu trực tiếp vào MongoDB
        public Queue<VideoStatus> VideoQueue { get; set; } = new Queue<VideoStatus>();
        [BsonElement("VideoStatus")]
        public List<VideoStatus> VideoStatus
        {
            get => new List<VideoStatus>(VideoQueue); //chuyển từ Queue sang List
            set => VideoQueue = new Queue<VideoStatus>(value); //chuyển từ List sang Queue
        }

        [BsonElement("ParticipantId")]
        public List<string> Participants { get; set; } = new List<string>();

        [BsonElement("StartTime")]
        public DateTime StartTime { get; set; } 
    }
}