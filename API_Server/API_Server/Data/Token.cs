﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_Server.Data
{
    public class Token
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("RefreshToken")]
        public string RefreshToken { get; set; }
        [BsonElement("UserId")]
        public ObjectId UserId { get; set; }
        [BsonElement("ExpiryTime")]
        public DateTime ExpiryTime { get; set; }
        [BsonElement("UsedToken")]
        public List<string> UsedToken { get; set; } = new List<string>();
        [BsonElement("Jti")]
        public string Jti { get; set; }
    }
}
