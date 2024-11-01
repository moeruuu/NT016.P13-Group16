using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace API_Server.Data
{
    public class Video
    {
       
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string VideoId { get; set; }

        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Url")]
        public string Url { get; set; }

        [BsonElement("UploaderId")]
        public string UploaderId { get; set; }
        [BsonElement("UploadedDate")]
        public DateTime UploadedDate { get; set; } = DateTime.UtcNow;

        [BsonElement("Size")]
        public long Size { get; set; }
    }
}
