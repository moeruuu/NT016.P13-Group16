using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Server.Data
{
    public class WatchedVideo
    {
        [BsonElement("UserId")]
        public ObjectId UserId { get; set; }

        [BsonElement("VideoId")]
        public List<WatchedVideoDetails> VideoDetails { get; set; }

    }
}
