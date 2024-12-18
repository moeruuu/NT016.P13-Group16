﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace API_Server.Data
{
    public class Video
    {
       
        [BsonId]
        public ObjectId VideoId { get; set; }
        [BsonElement("ID")]
        public string id {  get; set; }
        [BsonElement("Title")]
        public string Title { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Url")]
        public string Url { get; set; }
        [BsonElement("UrlImage")]
        public string UrlImage { get; set; }
        [BsonElement("UploaderID")]
        public ObjectId UploaderID { get; set; }
        [BsonElement("UploadedDate")]
        public DateTime UploadedDate { get; set; }

        [BsonElement("Size")]
        public long Size { get; set; }

        [BsonElement("Rating")]
        public double Rating { get; set; }
        [BsonElement("NumRate")]
        public int NumRate { get; set; }
        [BsonElement("Tag")]
        public string Tag { get; set; }
        [BsonElement("Views")]
        public long Views { get; set; }
    }
}
