using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Server.Data
{
    public class WatchedVideo
    {
        [BsonId]
        public ObjectId IDWatchedVideo { get; set; }
        [BsonElement("UserID")]
        public ObjectId UserId { get; set; }

        [BsonElement("WatchedList")]
        public List<WatchedVideoDetail> WatchedVideosList { get; set; }
    }

    public class WatchedVideoDetail
    {
        [BsonElement("VideoID")]
        public string VideoID { get; set; }

        [BsonElement("WatchedTime")]
        public DateTime WatchedTime { get; set; } = DateTime.Now;
    }
}
