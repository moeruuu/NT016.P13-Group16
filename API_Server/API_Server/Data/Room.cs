using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace API_Server.Data
{

    public class VideoQueue
    {
        public string VideoID { get; set; }
        public bool IsPlaying { get; set; }
        public double Progress { get; set; }
    }

    public class MessageChat
    {
        public string UserID { get; set; }
        public string Message { get; set; }
        public DateTime DateSend { get; set; }
    }
    public class Room
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement("RoomId")]
        public string RoomId { get; set; }

        [BsonElement("HostId")]
        public string HostId { get; set; }
        [BsonIgnore] //ko lưu trực tiếp vào MongoDB
        public Queue<VideoStatus> VideoQueue { get; set; } = new Queue<VideoStatus>();
        [BsonElement("VideoQueue")]
        public List<VideoQueue> videoQueues { get; set; }
        [BsonElement("Message")]
        public List<MessageChat> Messages { get; set; }
        [BsonElement("ParticipantId")]
        public List<string> Participants { get; set; } = new List<string>();

        [BsonElement("StartTime")]
        public DateTime StartTime { get; set; }
    }
}