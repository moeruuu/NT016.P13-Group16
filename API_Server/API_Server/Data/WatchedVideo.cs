using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Server.Data
{
    public class WatchedVideo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string WatchedVideoId { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }

        [BsonElement("VideoId")]
        public string VideoId { get; set; }

        [BsonElement("WatchedDate")]
        public DateTime WatchedDate { get; set; } = DateTime.UtcNow;

        [BsonElement("WatchCount")]
        public int WatchCount { get; set; } = 1;

    }
}
