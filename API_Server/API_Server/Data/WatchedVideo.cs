using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Server.Data
{
    public class WatchedVideo
    {
        public string VideoID { get; set; }
        public DateTime WatchedTime { get; set; } = DateTime.Now;
    }
}
